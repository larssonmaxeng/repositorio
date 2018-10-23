using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data;
using FirebirdSql.Data.FirebirdClient;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using revitDB = Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using appRevit = Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using AcessoBancoDados;
using Negocios;
using ObjetoTransferencia;
using Funcoes;

namespace Apresentacao
{
    public partial class FrmAcompPCP : NForm
    {
        public Plan_servico_amoNegocio manipulacao;
        public NBindingSource bsElemento = new NBindingSource();
        public NBindingSource bsCriterio = new NBindingSource();
        public NBindingSource bsCausas = new NBindingSource();
        public NDataTable dtElemento = new NDataTable("Elemento");
        public NDataTable dtCriterio = new NDataTable("Criterio");
        public NDataTable dtCausa = new NDataTable("Causa");
        public DataSet ds = new DataSet("Tabelas");
        public DataRelation drCriterioPlanServicoAmoId;
        public DataRelation drCausa;
        public string elementosSelecionados = "";
        public FbsqlConnection sqlConnection = new FbsqlConnection();
        private UIApplication uiApp;
        public ExternalCommandData revit;
        private revitDB.ElementId ele1;
        private revitDB.Document uiDoc;
        private revitDB.Element ele;
        public string dir = "";
        public string novaCausa = "";
        public string ItemText { get; set; }
        DataView dv = new DataView();
        private revitDB.ElementId preenchimentoId;

        public List<Funcoes.SubstituicaoDeGrafico> listaDeGraficOverride = new List<Funcoes.SubstituicaoDeGrafico>();

        public Autodesk.Revit.DB.OverrideGraphicSettings GetOverrideGraficPorNome(string nome)
        {
            return listaDeGraficOverride.Find(x => x.nome == nome).org;
        }

        public FrmAcompPCP(string idir)
        {
            InitializeComponent();
            manipulacao = new Plan_servico_amoNegocio(idir);
        }

        public void Abrir()
        {

            bsCausas.abrindo = true;
            bsCriterio.abrindo = true;
            bsElemento.abrindo = true;
            grdElementos.PermitirFullSelect = true;

            sqlConnection.Diretorio = dir;
            sqlConnection.Ativo(true);
            DefinirElemento();
            DefinirCriterio();
            DefinirCausa();
            bsElemento.DataSource = ds;
            bsElemento.DataMember = dtElemento.TableName;
            bsElemento.icampoPrimaryKey = "";
            bsElemento.igen_id = "";
            bsElemento.ifbConnection = sqlConnection.FbConexao;
            drCriterioPlanServicoAmoId = new DataRelation("CriterioPlanServicoAmoId",
                                                                ds.Tables[dtElemento.TableName].Columns["PLAN_SERVICO_AMO_ID"],
                                                                ds.Tables[dtCriterio.TableName].Columns["plan_servico_amo_id"]);

            ds.Relations.Add(drCriterioPlanServicoAmoId);
            bsCriterio.DataSource = bsElemento;
            bsCriterio.DataMember = "CriterioPlanServicoAmoId";
            bsCriterio.ifbConnection = sqlConnection.FbConexao;

            drCausa = new DataRelation("CausaCriterio",
                                                    ds.Tables[dtCriterio.TableName].Columns["criterio_plan_servico_amo_id"],
                                                    ds.Tables[dtCausa.TableName].Columns["criterio_plan_servico_amo_id"]);

            ds.Relations.Add(drCausa);
            bsCausas.DataSource = bsCriterio;
            bsCausas.DataMember = "CausaCriterio";
            bsCausas.ifbConnection = sqlConnection.FbConexao;
            bsCausas.icampoPrimaryKey = "CAUSA_CRITERIO_ID";
            bsCausas.igen_id = "GEN_CAUSA_CRITERIO_ID";

            grdElementos.DataSource = bsElemento;
            grdCriterio.DataSource = bsCriterio;
            grdCausa.DataSource = bsCausas;
            bnElemento.BindingSource = bsElemento;
            bnCausa.BindingSource = bsCausas;
            bnCriterio.BindingSource = bsCriterio;
            bsCausas.abrindo = false;
            bsCriterio.abrindo = false;
            bsElemento.abrindo = false;
            TrataGrids();
            this.ShowDialog();
        }

        public void TrataGrids()
        {
            TrataGrdElementoColunaInvisivel();
            TrataGrdElementoFormatoNumero();
            TrataGrdElementoNomear();
            TrataGrdElementoOrdena();
            TrataGrdCriterioNomear();
            TrataGrdCriterioOrdena();
            TrataDtCausaNomear();
            TrataGrdCausaOrdena(grdCausa);
        }

        private void TrataGrdElementoColunaInvisivel()
        {
            grdElementos.Columns["COMPLEMENTO"].Visible = false;
            grdElementos.Columns["POSICAO"].Visible = false;
        }

        private void TrataGrdElementoFormatoNumero()
        {
            grdElementos.Columns["PROJETO"].DefaultCellStyle.Format = "N2";
            grdElementos.Columns["PROJECAO"].DefaultCellStyle.Format = "N2";
            grdElementos.Columns["QTDE_REALIZADA_FILHO"].DefaultCellStyle.Format = "N2";
        }
        private void TrataGrdElementoOrdena()
        {
            int i = 0;
            List<DataGridViewColumn> lista = new List<DataGridViewColumn>();
            lista.Add(grdElementos.Columns["ID_BIM"]);
            lista.Add(grdElementos.Columns["DESCRICAO"]);
            lista.Add(grdElementos.Columns["PROJETO"]);
            lista.Add(grdElementos.Columns["PROJETO"]);
            lista.Add(grdElementos.Columns["QTDE_REALIZADA_FILHO"]);
            lista.Add(grdElementos.Columns["PROJECAO"]);
            lista.Add(grdElementos.Columns["SERVICO"]);
            foreach (DataGridViewColumn item in lista)
            {
                item.DisplayIndex = i;
                i++;
            }
        }

        private void TrataGrdElementoNomear()
        {
            grdElementos.Columns["PLAN_SERVICO_AMO_ID"].HeaderText = "Código";
            grdElementos.Columns["DESCRICAO"].HeaderText = "Descrição";
            grdElementos.Columns["COMPLEMENTO"].HeaderText = "Complemento";
            grdElementos.Columns["POSICAO"].HeaderText = "Posição";
            grdElementos.Columns["PROJETO"].HeaderText = "Projeto";
            grdElementos.Columns["SERVICO_AMO_ID"].HeaderText = "Serviço amo id";
            grdElementos.Columns["OBS"].HeaderText = "Obs";
            grdElementos.Columns["MEDICAO_BLOCO_ID"].HeaderText = "Medição bloco Id";
            grdElementos.Columns["MEDICAO"].HeaderText = "Desc. medição";
            grdElementos.Columns["BLOCO_ID"].HeaderText = "Bloco";
            grdElementos.Columns["BLOCO"].HeaderText = "Desc. bloco";
            grdElementos.Columns["GRUPO_PLAN_SERVICO_ID"].HeaderText = "Grupo";
            grdElementos.Columns["GRUPO"].HeaderText = "Desc. grupo";
            grdElementos.Columns["CAD"].HeaderText = "CAD";
            grdElementos.Columns["DATA_CAD"].HeaderText = "DATA_CAD";
            grdElementos.Columns["ALT"].HeaderText = "ALT";
            grdElementos.Columns["DATA_ALT"].HeaderText = "DATA_ALT";
            grdElementos.Columns["SERVICO_ID"].HeaderText = "Serviço";
            grdElementos.Columns["SERVICO"].HeaderText = "Desc. serviço";
            grdElementos.Columns["UNID"].HeaderText = "Unid.";
            grdElementos.Columns["ID_BIM"].HeaderText = "ID  BIM";
            grdElementos.Columns["PROJECAO"].HeaderText = "Projeção";
            grdElementos.Columns["QTDE_REALIZADA_FILHO"].HeaderText = "Realizado";



        }


        private void TrataGrdCriterioOrdena()
        {
            int i = 0;
            List<DataGridViewColumn> lista = new List<DataGridViewColumn>();

            lista.Add(grdCriterio.Columns["CRITERIO_DESCRICAO"]);
            lista.Add(grdCriterio.Columns["PESO"]);
            lista.Add(grdCriterio.Columns["INICIO"]);
            lista.Add(grdCriterio.Columns["EXECUTADO"]);
            lista.Add(grdCriterio.Columns["TIPO_ATIVO_ID"]);
            lista.Add(grdCriterio.Columns["EMPREITEIRO"]);

            lista.Add(grdCriterio.Columns["CRITERIO_PLAN_SERVICO_AMO_ID"]);
            lista.Add(grdCriterio.Columns["PLAN_SERVICO_AMO_ID"]);



            lista.Add(grdCriterio.Columns["ENCARREGADO"]);
            lista.Add(grdCriterio.Columns["CRITERIO_QTDE_MAPA_SERVICO_ID"]);
            lista.Add(grdCriterio.Columns["FORNECEDOR_EMPREITEIRO_ID"]);
            lista.Add(grdCriterio.Columns["FORNECEDOR_ENCARREGADO_ID"]);
            lista.Add(grdCriterio.Columns["LATENCIA"]);

            lista.Add(grdCriterio.Columns["TERMINO"]);
            lista.Add(grdCriterio.Columns["QTDE_MAPA_SERVICO_ID"]);
            lista.Add(grdCriterio.Columns["PRODUTIVIDADE"]);

            lista.Add(grdCriterio.Columns["TIPO_ESTATO_ID"]);



            foreach (DataGridViewColumn item in lista)
            {
                item.DisplayIndex = i;
                i++;
            }
        }

        private void TrataGrdCriterioNomear()
        {

            grdCriterio.Columns["CRITERIO_PLAN_SERVICO_AMO_ID"].HeaderText = "Código";
            grdCriterio.Columns["PLAN_SERVICO_AMO_ID"].HeaderText = "PsaId";
            grdCriterio.Columns["CRITERIO_DESCRICAO"].HeaderText = "Descrição";
            grdCriterio.Columns["PESO"].HeaderText = "Peso";
            grdCriterio.Columns["EMPREITEIRO"].HeaderText = "Empreiteiro";
            grdCriterio.Columns["ENCARREGADO"].HeaderText = "Encarregado";
            grdCriterio.Columns["CRITERIO_QTDE_MAPA_SERVICO_ID"].HeaderText = "qmdId";
            grdCriterio.Columns["FORNECEDOR_EMPREITEIRO_ID"].HeaderText = "Empreiteiro";
            grdCriterio.Columns["FORNECEDOR_ENCARREGADO_ID"].HeaderText = "Encarregado";
            grdCriterio.Columns["LATENCIA"].HeaderText = "Latência";
            grdCriterio.Columns["INICIO"].HeaderText = "Início";
            grdCriterio.Columns["TERMINO"].HeaderText = "Término";
         //   grdCriterio.Columns["QTDE_MAPA_SERVICO_ID"].HeaderText = "";
         //   grdCriterio.Columns["PRODUTIVIDADE"].HeaderText = "";
            grdCriterio.Columns["TIPO_ATIVO_ID"].HeaderText = "Ativo";
          //  grdCriterio.Columns["TIPO_ESTATO_ID"].HeaderText = "";
            grdCriterio.Columns["EXECUTADO"].HeaderText = "Executado";

        }
        private void TrataDtCausaNomear()
        {

            grdCausa.Columns["CAUSA"].HeaderText = "Causa";
            grdCausa.Columns["DESCRICAO_CAUSA"].HeaderText = "Descrição causa";
            grdCausa.Columns["CAUSA_CRITERIO_ID"].HeaderText = "Causa critério";
            grdCausa.Columns["CRITERIO_PLAN_SERVICO_AMO_ID"].HeaderText = "PsaId";



        }
        private void TrataGrdCausaOrdena(DataGridView gridCausa)
        {
            int i = 0;
            List<DataGridViewColumn> lista = new List<DataGridViewColumn>();
            lista.Add(gridCausa.Columns["CAUSA"]);
            lista.Add(gridCausa.Columns["DESCRICAO_CAUSA"]);
            lista.Add(gridCausa.Columns["CAUSA_CRITERIO_ID"]);
            lista.Add(gridCausa.Columns["CRITERIO_PLAN_SERVICO_AMO_ID"]);
            foreach (DataGridViewColumn item in lista)
            {
                item.DisplayIndex = i;
                i++;
            }
        }
        public void DefinirDataSets()
        {

        }
        public void DefinirDataSourceGris()
        {

        }


        public StringBuilder sqlPLAN_SERVICO_AMO_ID(string elementos1)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Clear();
            sb1.Append(" select psa.plan_servico_amo_id, ");
            sb1.Append(" coalesce(samo.id_bim, 0) || ' ' descricao, ");
            sb1.Append(" samo.descricao COMPLEMENTO, ");
            sb1.Append(" psa.posicao, ");
            sb1.Append("   samo.unidade_principal projeto, ");
            sb1.Append("   psa.servico_amo_id, ");
            sb1.Append("  psa.obs, ");
            sb1.Append("  samo.medicao_bloco_id, ");
            sb1.Append(" m.medicao, ");
            sb1.Append(" mb.bloco_id, ");
            sb1.Append(" b.bloco, ");
            sb1.Append(" psa.grupo_plan_servico_id, ");
            sb1.Append(" gps.grupo, psa.cad, psa.data_cad, psa.alt, psa.data_alt, samo.servico_id, s.servico, ");
            sb1.Append(" s.unid, SAMO.ID_BIM, ");
            sb1.Append(" jj.peso * samo.unidade_principal   projecao,");
            sb1.Append(" y.QTDE_REALIZADA_FILHO ");
            sb1.Append(" from plan_servico_amo psa ");
            sb1.Append(" inner join servico_amo samo on psa.servico_amo_id = samo.servico_amo_id ");
            sb1.Append(" inner join medicao_bloco mb on samo.medicao_bloco_id = mb.medicao_bloco_id ");
            sb1.Append(" inner join grupo_plan_servico gps on psa.grupo_plan_servico_id = gps.grupo_plan_servico_id ");
            sb1.Append(" inner join servico s on samo.servico_id = s.servico_id ");
            sb1.Append(" inner join bloco b on mb.bloco_id = b.bloco_id ");
            sb1.Append(" inner join medicao m on mb.medicao_id = m.medicao_id ");
            sb1.Append(" left join (select  sum(psa1.qtde_realizada) QTDE_REALIZADA_FILHO, psaf.plan_servico_amo_pai_id ");
            sb1.Append("     from plan_servico_amo psa1 ");
            sb1.Append("   inner join plan_servico_amo_filho psaf on psa1.plan_servico_amo_id = psaf.plan_servico_amo_filho_id ");
            sb1.Append("    group by psaf.plan_servico_amo_pai_id) y on psa.plan_servico_amo_id = y.plan_servico_amo_pai_id ");

            sb1.Append(" left join (select sum(cps.peso) peso, cps.plan_servico_amo_id ");
            sb1.Append("     from criterio_plan_servico_amo cps ");
            sb1.Append("   where cps.tipo_ativo_id = gen_id(const_ativo_id,0) ");
            sb1.Append("    group by cps.plan_servico_amo_id) jj on psa.plan_servico_amo_id = jj.plan_servico_amo_id ");

            sb1.Append("  where psa.plan_servico_amo_id in  (" + elementos1 + ")");
            
            return sb1;

        }

        public StringBuilder sqlCRITERIO(string elementos1)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Clear();
            sb1.Append(" select cps.criterio_plan_servico_amo_id,  ");
            sb1.Append(" cps.plan_servico_amo_id, ");

            sb1.Append(" cms.criterio_descricao, ");
            sb1.Append(" cps.peso, ");
            sb1.Append(" fe.fornecedor empreiteiro, ");
            sb1.Append(" fenc.fornecedor encarregado, ");
            sb1.Append(" cps.criterio_qtde_mapa_servico_id, ");
            sb1.Append(" cps.fornecedor_empreiteiro_id, ");
            sb1.Append(" cps.fornecedor_encarregado_id, ");
            sb1.Append(" cps.latencia, ");
            sb1.Append(" cps.inicio, ");
            sb1.Append(" cps.termino, ");
            sb1.Append(" cps.qtde_mapa_servico_id, ");
            sb1.Append(" cps.produtividade, ");
            sb1.Append(" cps.tipo_ativo_id, ");
            sb1.Append(" cps.tipo_estato_id, ");
            sb1.Append(" cps.executado ");
            sb1.Append(" from criterio_plan_servico_amo cps ");
            sb1.Append("  INNER JOIN criterio_qtde_mapa_servico cms ON cps.criterio_qtde_mapa_servico_id = cms.criterio_qtde_mapa_servico_id ");
            sb1.Append("  LEFT JOIN FORNECEDOR FE ON cps.fornecedor_empreiteiro_id = FE.fornecedor_id ");
            sb1.Append("  LEFT JOIN FORNECEDOR FENC ON cps.fornecedor_encarregado_id = FENC.fornecedor_id ");
            sb1.Append(" inner join plan_servico_amo psa on cps.plan_servico_amo_id = psa.plan_servico_amo_id ");
            sb1.Append(" where psa.plan_servico_amo_id in (" + elementos1 + ")");
            sb1.Append(" and cps.executado <> 1");

            sb1.Append(" order by cps.criterio_plan_servico_amo_id desc ");



            return sb1;

        }

        public StringBuilder sqlCAUSAS(string elementos1)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Clear();

            sb1.Append(" select CC.CAUSA_CRITERIO_ID, CC.CRITERIO_PLAN_SERVICO_AMO_ID, CC.DESCRICAO_CAUSA, cp.CAUSA ");

            sb1.Append(" FROM CAUSA_CRITERIO CC ");
            sb1.Append("  inner join criterio_plan_servico_amo cps  on cc.criterio_plan_servico_amo_id = cps.criterio_plan_servico_amo_id ");
            sb1.Append("  inner join plan_servico_amo psa on cps.plan_servico_amo_id = psa.plan_servico_amo_id ");
            sb1.Append("  inner join CAUSA_PCP cp on cc.CAUSA_PCP_ID = cp.CAUSA_PCP_ID ");
            sb1.Append("    where psa.plan_servico_amo_id in (" + elementos1 + ") order by cps.criterio_plan_servico_amo_id desc ");

            return sb1;

        }

        public void DefinirElemento()
        {
            dtElemento.ifbcommandSelect.Connection = sqlConnection.FbConexao;
            dtElemento.ifbcommandSelect.CommandText = sqlPLAN_SERVICO_AMO_ID(elementosSelecionados).ToString();
            dtElemento.ida = new FbDataAdapter(dtElemento.ifbcommandSelect);
            dtElemento.ifbUpdate = new FbCommand("update plan_servico_amo " +
                                       " set prof_concretada = @prof_concretada,  " +
                                       "     prof_escavada = @prof_escavada, " +
                                       "     vol_relatorio = @vol_relatorio " +
                                       " where (plan_servico_amo_id = @plan_servico_amo_id)", sqlConnection.FbConexao);
            dtElemento.ifbUpdate.Parameters.Add(new FbParameter("plan_servico_amo_id", FbDbType.Integer, 0, "plan_servico_amo_id"));
            dtElemento.ifbUpdate.Parameters.Add(new FbParameter("prof_concretada", FbDbType.Double, 0, "prof_concretada"));
            dtElemento.ifbUpdate.Parameters.Add(new FbParameter("prof_escavada", FbDbType.Double, 0, "prof_escavada"));
            dtElemento.ifbUpdate.Parameters.Add(new FbParameter("vol_relatorio", FbDbType.Double, 0, "vol_relatorio"));
            dtElemento.ida.UpdateCommand = dtElemento.ifbUpdate;
            dtElemento.ida.Fill(dtElemento);
            ds.Tables.Add(dtElemento);
        }

        public void DefinirCriterio()
        {
            dtCriterio.ifbcommandSelect.Connection = sqlConnection.FbConexao;
            dtCriterio.ifbcommandSelect.CommandText = sqlCRITERIO(elementosSelecionados).ToString();
            dtCriterio.ida = new FbDataAdapter(dtCriterio.ifbcommandSelect);
            dtCriterio.ifbUpdate = new FbCommand("UPDATE criterio_plan_servico_amo SET " +
                          " CRITERIO_QTDE_MAPA_SERVICO_ID = @CRITERIO_QTDE_MAPA_SERVICO_ID, " +
                          " FORNECEDOR_EMPREITEIRO_ID = @FORNECEDOR_EMPREITEIRO_ID, " +
                          " FORNECEDOR_ENCARREGADO_ID = @FORNECEDOR_ENCARREGADO_ID, " +
                          " INICIO = @INICIO, " +
                         "  TERMINO = @TERMINO " +
                        " WHERE  criterio_plan_servico_amo.CRITERIO_PLAN_SERVICO_AMO_ID = @CRITERIO_PLAN_SERVICO_AMO_ID", sqlConnection.FbConexao);

            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("CRITERIO_QTDE_MAPA_SERVICO_ID", FbDbType.Integer, 0, "CRITERIO_QTDE_MAPA_SERVICO_ID"));
            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("FORNECEDOR_EMPREITEIRO_ID", FbDbType.Integer, 0, "FORNECEDOR_EMPREITEIRO_ID"));
            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("FORNECEDOR_ENCARREGADO_ID", FbDbType.Integer, 0, "FORNECEDOR_ENCARREGADO_ID"));
            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("INICIO", FbDbType.Date, 0, "INICIO"));
            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("TERMINO", FbDbType.Date, 0, "TERMINO"));
            dtCriterio.ifbUpdate.Parameters.Add(new FbParameter("CRITERIO_PLAN_SERVICO_AMO_ID", FbDbType.Integer, 0, "CRITERIO_PLAN_SERVICO_AMO_ID"));
            dtCriterio.ida.UpdateCommand = dtCriterio.ifbUpdate;
            dtCriterio.ida.Fill(dtCriterio);
            ds.Tables.Add(dtCriterio);
        }

        public void DefinirCausa()
        {
            dtCausa.ifbcommandSelect.Connection = sqlConnection.FbConexao;
            dtCausa.ifbcommandSelect.CommandText = sqlCAUSAS(elementosSelecionados).ToString();
            dtCausa.ida = new FbDataAdapter(dtCausa.ifbcommandSelect);
            dtCausa.ifbUpdate = new FbCommand("UPDATE causa_criterio SET " +
              " DESCRICAO_CAUSA = @DESCRICAO_CAUSA, " +
              " CRITERIO_PLAN_SERVICO_AMO_ID = @CRITERIO_PLAN_SERVICO_AMO_ID " +
            " WHERE  causa_criterio_ID = @causa_criterio_ID", sqlConnection.FbConexao);
            dtCausa.ifbUpdate.Parameters.Add(new FbParameter("DESCRICAO_CAUSA", FbDbType.VarChar, 250, "DESCRICAO_CAUSA"));
            dtCausa.ifbUpdate.Parameters.Add(new FbParameter("CRITERIO_PLAN_SERVICO_AMO_ID", FbDbType.Integer, 0, "CRITERIO_PLAN_SERVICO_AMO_ID"));
            dtCausa.ifbUpdate.Parameters.Add(new FbParameter("causa_criterio_ID", FbDbType.Integer, 0, "causa_criterio_ID"));
            dtCausa.ida.UpdateCommand = dtCausa.ifbUpdate;

            dtCausa.ifbDelete = new FbCommand("DELETE FROM CAUSA_CRITERIO WHERE CAUSA_CRITERIO_ID = @CAUSA_CRITERIO_ID", sqlConnection.FbConexao);
            dtCausa.ifbDelete.Parameters.Add(new FbParameter("causa_criterio_ID", FbDbType.Integer, 0, "causa_criterio_ID"));
            dtCausa.ida.DeleteCommand = dtCausa.ifbDelete;

            dtCausa.ifbInsert = new FbCommand("insert into CAUSA_CRITERIO (DESCRICAO_CAUSA, CRITERIO_PLAN_SERVICO_AMO_ID, CAUSA_PCP_ID) VALUES " +
                                            " (@DESCRICAO_CAUSA, @CRITERIO_PLAN_SERVICO_AMO_ID, CAUSA_PCP_ID)", sqlConnection.FbConexao);

            dtCausa.ifbInsert.Parameters.Add(new FbParameter("DESCRICAO_CAUSA", FbDbType.VarChar, 250, "DESCRICAO_CAUSA"));
            dtCausa.ifbInsert.Parameters.Add(new FbParameter("CRITERIO_PLAN_SERVICO_AMO_ID", FbDbType.Integer, 0, "CRITERIO_PLAN_SERVICO_AMO_ID"));
            dtCausa.ifbInsert.Parameters.Add(new FbParameter("CAUSA_PCP_ID", FbDbType.Integer, 0, "CAUSA_PCP_ID"));
            dtCausa.ida.InsertCommand = dtCausa.ifbInsert;

            dtCausa.ida.Fill(dtCausa);
            ds.Tables.Add(dtCausa);
        }

        private void btnNovaCausa_Click(object sender, EventArgs e)
        {
            DataRow r;
            r = dtCausa.NewRow();
            r[bsCausas.icampoPrimaryKey] = FbSequence.Generator(bsCausas.igen_id, bsCausas.ifbConnection);
            r["insumo_id"] = (resultadoProcura.linha as DataGridViewRow).Cells["INSUMO_ID"].Value;
            r["insumo"] = (resultadoProcura.linha as DataGridViewRow).Cells["INSUMO"].Value;
            r["Unid"] = (resultadoProcura.linha as DataGridViewRow).Cells["UNID"].Value;
            dtCausa.Rows.InsertAt(r, 0);
            bsCausas.EndEdit();

            bsCausas.Find("sgi_material_controlado_id", r[bsCausas.icampoPrimaryKey]);
        }

        private void grdCausa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            // Perguntar inputBox = new Perguntar();
            //inputBox.Inputar("Digite a unidade de medição", "Selecionar unidade de medição");
            // = inputBox.resultadoProcura.vCampo[0].ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Perguntar inputBox = new Perguntar();
            inputBox.Inputar("Digite a causa", "");
            novaCausa = inputBox.resultadoProcura.vCampo.ToString();
            PAR_INCLUIR_CAUSA par = new PAR_INCLUIR_CAUSA();
            par.DESCRICAO_CAUSA = novaCausa;
            par.CRITERIO_PLAN_SERVICO_AMO_ID = Convert.ToInt32(grdCriterio.CurrentRow.Cells["CRITERIO_PLAN_SERVICO_AMO_ID"].Value);
            manipulacao.PRC_INCLUIR_CAUSA(par);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bsCausas.RemoveCurrent();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            revitDB.FilteredElementCollector selecao;
        

            double percentAvanco;
            uiApp = revit.Application;
            uiDoc = uiApp.ActiveUIDocument.Document;
            Selection sel = uiApp.ActiveUIDocument.Selection;
            Util.uiDoc = uiDoc;


           
            preenchimentoId = (Util.FindElementByName( typeof(revitDB.Material), "Previsto") as revitDB.Material).SurfacePatternId;

            string p = comboBox1.SelectedItem.ToString();

            p = p.Replace("%", "");

            percentAvanco = Convert.ToDouble( p )/ 100;
            EscolherData escolherData = new EscolherData();
            DialogResult resultado = escolherData.inputar(ref diaProjecao, "Escolha o dia", ref continuar);

            if (!continuar)
            {
                return;
            }

            escolherData.Dispose();


            List<Autodesk.Revit.DB.ElementId> listaElemento = new List<revitDB.ElementId>();
            listaElemento.Clear();
            if (grdElementos.SelectedRows.Count > 0)
                foreach (DataGridViewRow row in grdElementos.SelectedRows)

                {
                    listaElemento.Add(new Autodesk.Revit.DB.ElementId(Convert.ToInt32(row.Cells["DESCRICAO"].Value)));
                }
            else
            {
                listaElemento.Add(new Autodesk.Revit.DB.ElementId(Convert.ToInt32(grdElementos.CurrentRow.Cells["DESCRICAO"].Value)));
            }

            Util.RodarPCP(manipulacao, uiApp, lista, CampoMark, diaProjecao, percentAvanco, GetOverrideGraficPorNome("orgProjecao"),
                GetOverrideGraficPorNome("orgIniciadoComProjecao"), "", "", listaElemento );

            int psaId = Convert.ToInt32(grdElementos.CurrentRow.Cells["plan_servico_amo_id"].Value);

            dtCausa.Rows.Clear();
            dtCriterio.Rows.Clear();
            dtElemento.Rows.Clear();
            dtElemento.ida.Fill(dtElemento);
            dtCriterio.ida.Fill(dtCriterio);
            dtCausa.ida.Fill(dtCausa);

            bsElemento.Position = bsElemento.Find("PLAN_SERVICO_AMO_ID", psaId);


        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            int psaId = 0;


            PAR_FECHAR_PCP par = new PAR_FECHAR_PCP();

            if (grdElementos.SelectedRows.Count > 0)
            {

                EscolherData escolherData = new EscolherData();
                DialogResult resultado = escolherData.inputar(ref diaProjecao, "Escolha o dia", ref continuar);
                foreach (DataGridViewRow row in grdElementos.SelectedRows)
                {
                    if (!continuar)
                    {
                        return;
                    }
                    par.ENOVO_TERMINO = diaProjecao;
                    par.EPSA_ID = Convert.ToInt32(row.Cells["plan_servico_amo_id"].Value);
                    manipulacao.PRC_FECHAR_PCP(par);
                }
            }
            else
            {
                EscolherData escolherData = new EscolherData();
                DialogResult resultado = escolherData.inputar(ref diaProjecao, "Escolha o dia", ref continuar);

                if (!continuar)
                {
                    return;
                }
                par.ENOVO_TERMINO = diaProjecao;
                par.EPSA_ID = Convert.ToInt32(grdElementos.CurrentRow.Cells["plan_servico_amo_id"].Value);
                manipulacao.PRC_FECHAR_PCP(par);
            }

            psaId = Convert.ToInt32(grdElementos.CurrentRow.Cells["plan_servico_amo_id"].Value);

            dtCausa.Rows.Clear();
            dtCriterio.Rows.Clear();
            dtElemento.Rows.Clear();
            dtElemento.ida.Fill(dtElemento);
            dtCriterio.ida.Fill(dtCriterio);
            dtCausa.ida.Fill(dtCausa);
            bsElemento.Position = bsElemento.Find("PLAN_SERVICO_AMO_ID", psaId);


        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            uiApp = revit.Application;
            uiDoc = uiApp.ActiveUIDocument.Document;
            Util.uiDoc = uiDoc;

            preenchimentoId = (Util.FindElementByName( typeof(revitDB.Material), "Previsto") as revitDB.Material).SurfacePatternId;

/*

            orgProjecao = Util.GetOverrideGraphicSettings(Util.GetColorRevit(corLinhaPCP),
                                 Util.GetColorRevit(corSuperficiePCP),
                                 preenchimentoId, 0);
            orgCompleto= Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaCompleto),
                                             Util.GetColorRevit(CorSuperficieCompleto),
                                             preenchimentoId, 50);
            orgCompleto = Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaCompleto),
                                            Util.GetColorRevit(CorSuperficieCompleto),
                                            preenchimentoId, 0);
            orgNaoIniciado = Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaNaoIniciado),
                                             Util.GetColorRevit(CorSuperficieNaoIniciado),
                                             preenchimentoId, 0);
            orgIniciado = Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaIniciado),
                                 Util.GetColorRevit(CorSuperficieIniciado),
                                 preenchimentoId, 0);
            orgTerminado = Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaCompleto),
                                             Util.GetColorRevit(CorSuperficieCompleto),
                                             preenchimentoId, 0);
            orgCompletoAposDataLimite = Util.GetOverrideGraphicSettings(Util.GetColorRevit(CorLinhaExecutadoAposLimite),
                                             Util.GetColorRevit(CorSuperficieExecutadoAposLimite),
                                             preenchimentoId, 0);

            int id = Convert.ToInt32(grdElementos.CurrentRow.Cells["PLAN_SERVICO_AMO_ID"].Value);

            if (grdElementos.SelectedRows.Count > 0)

                foreach (DataGridViewRow row in grdElementos.SelectedRows)
                {
                    manipulacao.PRC_EXECUTAR_DIRETO("EXECUTE PROCEDURE PRC_ELIMINAR_PCP_PSA(" +
                        Convert.ToString(row.Cells["PLAN_SERVICO_AMO_ID"].Value) + ")");
                    Util.RodarSubGraficoPorElemento(uiApp, new revitDB.ElementId(Convert.ToInt32(row.Cells["ID_BIM"].Value)),
                                                    dir, orgProjecao, orgIniciado, orgNaoIniciado, orgCompleto,
                                                    orgTerminado, orgCompletoAposDataLimite,  CampoMark);
                }

            else
            {
                manipulacao.PRC_EXECUTAR_DIRETO("EXECUTE PROCEDURE PRC_ELIMINAR_PCP_PSA(" +
                    Convert.ToString(grdElementos.CurrentRow.Cells["PLAN_SERVICO_AMO_ID"].Value) + ")");
                Util.RodarSubGraficoPorElemento(uiApp, new revitDB.ElementId(Convert.ToInt32(grdElementos.CurrentRow.Cells["ID_BIM"].Value)),
                                dir, orgProjecao, orgIniciado, orgNaoIniciado, orgCompleto,
                                                    orgTerminado, orgCompletoAposDataLimite, CampoMark);
            }
            dtCausa.Rows.Clear();
            dtCriterio.Rows.Clear();

            dtElemento.Rows.Clear();

            dtElemento.ida.Fill(dtElemento);
            dtCriterio.ida.Fill(dtCriterio);
            dtCausa.ida.Fill(dtCausa);
            bsElemento.Position = bsElemento.Find("PLAN_SERVICO_AMO_ID", id);
            */
        }

        private void grdCriterio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((sender as DataGridView).)
        }

        private void grdCriterio_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = "";
            int j = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                bsElemento.Filter = "";
                return;
            }
            else
            {



                for (int i = 0; i < dtElemento.Columns.Count - 1; i++)
                {


                    switch (dtElemento.Columns[i].DataType.Name)
                    {
                        case "String":
                            if (j == 0)
                            {
                                filtro = "(" + dtElemento.Columns[i].ColumnName + " like '%" + textBox1.Text + "%')";

                                j = j + 1;

                            }
                            else
                            {

                                filtro = filtro + " or (" + dtElemento.Columns[i].ColumnName + " like '%" + textBox1.Text + "%')";
                                j = j + 1;

                            }
                            break;
                        case "Int32":
                        case "DOUBLE":
                            if (j == 0)
                            {
                                try
                                {
                                    Convert.ToDouble(textBox1.Text);
                                    filtro = "(" + dtElemento.Columns[i].ColumnName + " = " + textBox1.Text + ")";
                                    j = j + 1;

                                }
                                catch
                                {

                                }

                            }
                            else
                            {
                                try
                                {
                                    Convert.ToDouble(textBox1.Text);
                                    filtro = filtro + " or (" + dtElemento.Columns[i].ColumnName + " = " + textBox1.Text + ")";
                                    j = j + 1;

                                }
                                catch
                                {

                                }


                            }

                            break;

                    }
                }

                bsElemento.Filter = filtro;
            }
        }

        private void bnElemento_RefreshItems(object sender, EventArgs e)
        {

        }

        private void grdElementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnIncluirCausa_Click(object sender, EventArgs e)
        {
           FrmProcurar frmProcurar  = new FrmProcurar();
           ResultadoProcura rp  =  frmProcurar.PesquisarCausaPCP(dir, "Causa raíz",     "Tipo;Causa;Controlavél;", "80;200;80;");

           if (rp.fResultadoProcura)
            {
                Perguntar inputBox = new Perguntar();
                inputBox.Inputar("Digite o detalhe da causa", "Causas");
                string detalheCausa = inputBox.resultadoProcura.vCampo.ToString();
                if (grdElementos.SelectedRows.Count > 0)
                    foreach (DataGridViewRow row in grdElementos.SelectedRows)
                    {
                        IncluirCausa(rp, detalheCausa, row.Cells["PLAN_SERVICO_AMO_ID"].Value.ToString());

                    }
                else
                {
                    IncluirCausa(rp, detalheCausa, grdElementos.CurrentRow.Cells["PLAN_SERVICO_AMO_ID"].Value.ToString());

                }

            }

            dtCausa.Rows.Clear();
            dtCriterio.Rows.Clear();
            dtElemento.Rows.Clear();
            dtElemento.ida.Fill(dtElemento);
            dtCriterio.ida.Fill(dtCriterio);
            dtCausa.ida.Fill(dtCausa);


        }

        private void IncluirCausa(ResultadoProcura rp, string detalheCausa, string psaId)
        {
            manipulacao.PRC_EXECUTAR_DIRETO_SEM_RETORNO("  insert into causa_criterio (" +
 "                 causa_pcp_id," +
 "                 criterio_plan_servico_amo_id," +
 "                 descricao_causa) " +

" select " + rp.vCampo.ToString() + "  , " +
"      cps.criterio_plan_servico_amo_id, " +
"      '" + detalheCausa + "'" +
" from criterio_plan_servico_amo cps" +
"   inner " +
" join plan_servico_amo psa on cps.plan_servico_amo_id = psa.plan_servico_amo_id " +

"  inner " +
"  join servico_amo samo on psa.servico_amo_id = samo.servico_amo_id " +
"     where cps.tipo_ativo_id = gen_id(const_inativo_id, 0) " +
"      and psa.plan_servico_amo_id = " + psaId+
"        and cps.criterio_plan_servico_amo_id not in " +
 " (select distinct cc.criterio_plan_servico_amo_id " +
    " from causa_criterio cc)");
        }

        private void grdCriterio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdCriterio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((sender as DataGridView).Rows[e.RowIndex].Cells["TIPO_ATIVO_ID"].Value.ToString()=="46")
            {
                (sender as DataGridView).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                (sender as DataGridView).Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
