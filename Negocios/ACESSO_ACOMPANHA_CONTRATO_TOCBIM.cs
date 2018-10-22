using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_ACOMPANHA_CONTRATO_UAU
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string strSql;

        public List<PAR_ACOMPANHA_CONTRATO_UAU> EXPORTA_ACOMP_CONTRATO(string dir, PAR_ACOMPANHA_CONTRATO_UAU epar)
        {
            List<PAR_ACOMPANHA_CONTRATO_UAU> lista = new List<PAR_ACOMPANHA_CONTRATO_UAU>();

            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.input_obra_id);
            sql.AdicionarParametros("@EINICIO", epar.input_inicio);
            sql.AdicionarParametros("@EFIM", epar.input_fim);

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_ACOMPANHAR_SERVICO_CONTRATO");

            while (fb.Read())
            {
                try
                {
                    lista.Add(new PAR_ACOMPANHA_CONTRATO_UAU
                    {
                        empresa = Convert.ToInt32(fb["EMPRESA"]),
                        obra = Convert.ToString(fb["OBRA"]),
                        contratoServico = Convert.ToInt32(fb["CONTRATO_SERVICO"]),
                        itemContrato = Convert.ToInt32(fb["ITEM_CONTRATO"]),
                        servico = Convert.ToString(fb["SERVICO"]),
                        dataInicio = Convert.ToString(fb["DATA_INICIO"]),
                        dataFim = Convert.ToString(fb["DATA_FIM"]),
                        mesPl = Convert.ToString(fb["MES_PL"]),
                        quantidade = Convert.ToDouble(fb["QUANTIDADE"]),
                        porcentagemAcomp = Convert.ToDouble(fb["PORCENTAGEM_ACOMP"]),
                        observacoes = Convert.ToString(fb["OBSERVACOES"]),
                        etapa = Convert.ToString(fb["ETAPA"]),
                        codEstrutura = Convert.ToString(fb["COD_ESTRUTURA"]),
                        sequencia = Convert.ToString(fb["SEQUENCIA"]),
                        usuarioLogado = Convert.ToString(fb["USUARIO_LOGADO"]),
                        input_obra_id = epar.input_obra_id,
                        acompanhamentoContrato = Convert.ToString(fb["ACOMPANHAMENTO_CONTRATO"]),
                        medicao = Convert.ToString(fb["MEDICAO"])
                    }
                    );
                }
                catch
                {
                }
            }
            sql.t.Commit();
            sql.Close();
            return lista;

        }
        public Boolean GravaAcompanhamentoNoTocBIM(string dir, PAR_ACOMPANHA_CONTRATO_TOCBIM par)
        {
            List<PAR_ACOMPANHA_CONTRATO_TOCBIM> lista = new List<PAR_ACOMPANHA_CONTRATO_TOCBIM>();
            /*AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.EOBRA_ID);
            sql.AdicionarParametros("@EINICIO", epar.EINICIO);
            sql.AdicionarParametros("@EFIM", epar.EFIM);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_AVANCO");
            while (fb.Read())
            {
                lista.Add(new PAR_ACOMPANHA_SERVICO_ORCADO
                {
                    empresa = Convert.ToInt32(fb["empresa"]),
                    obra = fb["obra"].ToString(),
                    servico = fb["servico"].ToString(),
                    item = fb["item"].ToString(),
                    orcamento = Convert.ToInt32(fb["orcamento"]),
                    periodo = Convert.ToDateTime(fb["periodo"].ToString()).ToString("dd/MM/yyyy"),
                    quantidade = Convert.ToDouble(fb["quantidade"]),
                    usuarioLogado = fb["usuario_logado"].ToString(),
                    sequencia = fb["sequencia"].ToString()

                }
                );
            }
            sql.t.Commit();
            sql.Close();*/
            return true;
        }

        public List<PAR_ACOMPANHA_CONTRATO_UAU> GravaAcompanhamentoNoTocBIM(string dir, List<PAR_ACOMPANHA_CONTRATO_UAU> par)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);

            sql.t = sql.FbConexao.BeginTransaction();
            try
            {
                foreach (PAR_ACOMPANHA_CONTRATO_UAU epar in par)
                {
                    if (epar.acompanhadoUau == 1)
                    {
                        strSql = MontaUpdateTocBim(epar);
                        sql.ExecutarSemRetorno(System.Data.CommandType.Text, strSql);                                                
                        epar.acompanhadoTocBIM = 1;
                    }
                    else
                    {
                        epar.acompanhadoTocBIM = 0;
                    }                
                }
                sql.t.Commit();
            }
            catch
            {
                sql.t.Rollback();
            }
            
            sql.Close();
 
            return par;
        }

        private string MontaUpdateTocBim(PAR_ACOMPANHA_CONTRATO_UAU RegAcompContrato)
        {
            strSql = "UPDATE PLAN_SERVICO_AMO PSA " +
                "SET PSA.tipo_estato_id = GEN_ID(const_confirmado_id, 0) " +
                "Where PSA.plan_servico_amo_id In( " +
                "Select PSA.plan_servico_amo_id " +
                "From plan_servico_amo psa " +
                "Inner Join servico_amo samo On psa.servico_amo_id = samo.servico_amo_id " +
                "Inner Join medicao_bloco mb On samo.medicao_bloco_id = mb.medicao_bloco_id " +
                "Inner Join medicao m On mb.medicao_id = m.medicao_id " +
                "Inner Join servico s On samo.servico_id = s.servico_id " +
                "Inner Join bloco b On mb.bloco_id = b.bloco_id " +
                "Inner Join obra o On o.obra_id = b.obra_id " +
                "Inner Join etapa e On s.etapa_id = e.etapa_id " +
                "Inner Join qtde_mapa_servico qms On psa.grupo_plan_servico_id = qms.grupo_id " +
                "                     And samo.servico_id = qms.servico_id " +
                "Inner Join item_estrutura_uau imu On imu.obra_id = b.obra_id And imu.desc_cger = m.medicao " +
                "                        And imu.item_eo = iif(s.posicao is null, e.item, iif(s.posicao < 9, e.item || '.0' || s.posicao, " +
                "                                            iif(s.posicao < 99, e.item || '.' || s.posicao, 'todo'))) " +
                "                        And imu.sequencia_eo = B.ordem || '.' || cast(MB.elevacao AS integer) " +
                "                        And imu.serv_eo = s.complemento " +
                "                        And imu.numorca_eo = o.sycrobra_id " +
                "Where psa.filho = 1 " +
                "And psa.tipo_estato_id = gen_id(const_pendente_id, 0) " +
                "And imu.obra_id = " + RegAcompContrato.input_obra_id.ToString() + " " +
                "And qms.contrato_erp = " + RegAcompContrato.contratoServico.ToString() + " " +
                "And qms.item_contrato_erp = " + RegAcompContrato.itemContrato.ToString() + " " +
                "And imu.serv_eo = '" + RegAcompContrato.servico.Trim() + "' " +
                "And psa.dia_realizado = '" + DateTime.Parse(RegAcompContrato.dataInicio).ToString("MM-dd-yyyy") + "' " +
                "And imu.sequencia_eo = '" + RegAcompContrato.sequencia.Trim() + "')";
                
            return strSql;
        }

        public List<MedicaoContrato> ListarMedicoesPsa(string dir, string modeloGuidId)
        {         
            MedicaoContrato regMedicaoContrato;
            List<MedicaoContrato> lista = new List<MedicaoContrato>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select Psa.medicao_erp, Cerp.contrato_erp_id, Cerp.contrato_erp, Frn.fornecedor_id, Frn.fornecedor " +
                "From Servico_Amo Samo " +
                "Inner Join Plan_Servico_Amo Psa On samo.servico_amo_id = Psa.servico_amo_id " +
                "Inner Join Fornecedor Frn On Psa.fornecedor_id = Frn.fornecedor_id " +
                "Inner Join Contrato_Erp Cerp on Cerp.contrato_erp_id = Psa.contrato_erp_id " +
                "Where (psa.medicao_erp is not null And psa.medicao_erp <> '') And Samo.modelo_guid_id = '" + modeloGuidId + "' " +
                "Group By Psa.medicao_erp, Cerp.contrato_erp_id, Cerp.contrato_erp, Frn.fornecedor_id, Frn.fornecedor";



            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regMedicaoContrato = new MedicaoContrato();

                regMedicaoContrato.MEDICAO_ERP = Convert.ToString(fb["MEDICAO_ERP"]);
                regMedicaoContrato.CONTRATO_ERP_ID = Convert.ToInt32(fb["CONTRATO_ERP_ID"]);
                regMedicaoContrato.CONTRATO_ERP = Convert.ToString(fb["CONTRATO_ERP"]);
                regMedicaoContrato.FORNECEDOR_ID = Convert.ToInt32(fb["FORNECEDOR_ID"]);
                regMedicaoContrato.FORNECEDOR = Convert.ToString(fb["FORNECEDOR"]);

                lista.Add(regMedicaoContrato);
            }
            sql.Close();
            return lista;
        }

        public List<string> ListarElementosMedicoesPsa(string dir, string modeloGuidId, string medicaoErp)
        {
            List<string> lista = new List<string>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select Samo.ID_BIM " +
                "From Servico_Amo Samo " +
                "Inner Join Plan_Servico_Amo Psa On samo.servico_amo_id = Psa.servico_amo_id " +
                "Where psa.medicao_erp = '" + medicaoErp + "' And Samo.modelo_guid_id = '" + modeloGuidId + "'";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                lista.Add(Convert.ToString(fb["ID_BIM"]));
            }
            sql.Close();
            return lista;
        }

        public List<AcompanhaContrato> ListarAcompanhamentoContrato(string dir, string modeloGuidId, string strInSamoId)
        {
            AcompanhaContrato regAcompanhaContrato;
            List<AcompanhaContrato> lista = new List<AcompanhaContrato>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "select s.complemento, " +
                            "iif(s.posicao is null, e.item, iif(s.posicao < 9, e.item || '.0' || s.posicao, " +
                            "iif(s.posicao < 99, e.item || '.' || s.posicao, 'todo'))) item, " +
                            "psa.dia_realizado data_inicio, " +
                            "sum(psa.qtde_realizada) qtde_realizada, " +
                            "SAMO.servico_id, " +
                            "coalesce(psa.item_contrato_erp_id, 0) item_contrato_erp_id, " +
                            "coalesce(psa.contrato_erp_id, 0) contrato_erp_id, " +
                            "coalesce(psa.acompanhamento_contrato, '') acompanhamento_contrato, " +
                            "coalesce(psa.medicao_erp, '') medicao_erp, " +
                            "samo.servico_amo_id, psa.plan_servico_amo_id " +
                    "from plan_servico_amo psa " +
                    "inner join servico_amo samo on psa.servico_amo_id = samo.servico_amo_id " +
                    "inner join medicao_bloco mb on samo.medicao_bloco_id = mb.medicao_bloco_id " +
                    "inner join medicao m on mb.medicao_id = m.medicao_id " +
                    "inner join servico s on samo.servico_id = s.servico_id " +
                    "inner join etapa e on s.etapa_id = e.etapa_id " +
                    "where psa.filho = 1 " +
                            "And psa.tipo_estato_id = gen_id(const_pendente_id, 0) " +
                            "And (psa.acompanhamento_contrato is not null And psa.acompanhamento_contrato <> '') " +
                            "And Samo.modelo_guid_id = '" + modeloGuidId + "' " +
                            "And samo.servico_amo_id in (" + strInSamoId + ") " +
                    "group by s.complemento, " +
                    "s.posicao, e.item, " +
                    "psa.dia_realizado, " +
                    "SAMO.servico_id, " +
                    "M.uau_id, " +
                    "psa.item_contrato_erp_id, " +
                    "psa.contrato_erp_id, " +
                    "psa.acompanhamento_contrato, " +
                    "psa.medicao_erp, " +
                    "samo.servico_amo_id, " +
                    "psa.plan_servico_amo_id";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regAcompanhaContrato = new AcompanhaContrato();

                regAcompanhaContrato.COMPLEMENTO = Convert.ToString(fb["COMPLEMENTO"]);
                regAcompanhaContrato.ITEM = Convert.ToString(fb["ITEM"]);
                regAcompanhaContrato.DATA_INICIO = Convert.ToDateTime(fb["DATA_INICIO"]);
                regAcompanhaContrato.QTDE_REALIZADA = Convert.ToDouble(fb["QTDE_REALIZADA"]);
                regAcompanhaContrato.SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]);
                regAcompanhaContrato.CONTRATO_ERP_ID = Convert.ToInt32(fb["CONTRATO_ERP_ID"]);
                regAcompanhaContrato.ITEM_CONTRATO_ERP_ID = Convert.ToInt32(fb["ITEM_CONTRATO_ERP_ID"]);
                regAcompanhaContrato.ACOMPANHAMENTO_CONTRATO = Convert.ToString(fb["ACOMPANHAMENTO_CONTRATO"]);
                regAcompanhaContrato.MEDICAO_ERP = Convert.ToString(fb["MEDICAO_ERP"]);
                regAcompanhaContrato.SERVICO_AMO_ID = Convert.ToInt32(fb["SERVICO_AMO_ID"]);
                regAcompanhaContrato.PLAN_SERVICO_AMO_ID = Convert.ToInt32(fb["PLAN_SERVICO_AMO_ID"]);

                lista.Add(regAcompanhaContrato);
            }
            sql.Close();
            return lista;
        }

        public Boolean ExcluirAcompanhamentoContrato(string dir, List<AcompanhaContrato> listaAcompContrato, Boolean limparContratoItemContrato)
        {
            List<string> lista = new List<string>();

            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            try
            {

                foreach (AcompanhaContrato regAcompContrato in listaAcompContrato)
                {
                    //Verificar no Uau se existe medição. Caso não exista limpar Acompanhamento de Contrato e Medição se estiver preenchido.
                    strSql = "UPDATE PLAN_SERVICO_AMO Psa Set Psa.acompanhamento_contrato = '', Psa.medicao_erp = '' ";

                    if (limparContratoItemContrato == true)
                    {
                        strSql += ", psa.contrato_erp_id = null, psa.item_contrato_erp_id = null ";
                    }

                    strSql += "Where Psa.PLAN_SERVICO_AMO_ID = " + regAcompContrato.PLAN_SERVICO_AMO_ID.ToString() + " " +
                        "And Psa.acompanhamento_contrato = '" + regAcompContrato.ACOMPANHAMENTO_CONTRATO + "' ";

                    sql.ExecutarSemRetorno(System.Data.CommandType.Text, strSql);
                }
            }              
            catch
            {
                sql.t.Rollback();
                return false;
            }

            sql.t.Commit();
            sql.Close();
            return true;
        }

        public List<ArvorePorServico> ListarArvorePorServico(string dir, Int32 obraId)
        {
            ArvorePorServico regArvorePorServico;
            List<ArvorePorServico> lista = new List<ArvorePorServico>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "SELECT  aaf.*, o.obra, m.medicao, s.servico, b.bloco, gps.grupo, " +
                "iif(aaf.nivel = 0, iif((select cast(z.OTOTAL_PROJE_GRUPO_PLAN_GRUPO as integer) from get_tt_proj_grupo_pl_grupo_ifec(aaf.obra_id, " +
                "aaf.grupo_plan_servico_id, -1) z) <> cast(gps.total_projeto as integer), 1, 0) ,null) total_projeto, s.complemento " +
                "FROM arvore_avanco_fisico AAF " +
                "left JOIN OBRA O ON AAF.obra_id = O.obra_id " +
                "left join medicao_bloco mb on aaf.medicao_bloco_id = mb.medicao_bloco_id " +
                "left join bloco b on aaf.bloco_id = b.bloco_id " +
                "left JOIN MEDICAO M ON AAF.medicao_id = M.medicao_id " +
                "left JOIN SERVICO S ON AAF.servico_id = S.servico_id " +
                "left join grupo_plan_servico gps on aaf.grupo_plan_servico_id = gps.grupo_plan_servico_id " +
                "where aaf.obra_id = " + obraId.ToString() + " " +
                "order by aaf.obra_id,  gps.ordem, gps.grupo, s.servico,  b.ordem , aaf.bloco_id , mb.ordem, aaf.medicao_id, aaf.nivel";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);
            char pad = '0';

            while (fb.Read())
            {
                if (Convert.ToInt32(fb["NIVEL"]) == 0)
                    regArvorePorServico = new ArvorePorServico(Convert.ToString(fb["GRUPO_PLAN_SERVICO_ID"]).PadLeft(4, pad) + " - " + Convert.ToString(fb["GRUPO"]));
                else
                    if (Convert.ToInt32(fb["NIVEL"]) == 1)
                        regArvorePorServico = new ArvorePorServico(Convert.ToString(fb["COMPLEMENTO"]) + " - " + Convert.ToString(fb["SERVICO"]));
                    else
                        if (Convert.ToInt32(fb["NIVEL"]) == 2)
                            regArvorePorServico = new ArvorePorServico(Convert.ToString(fb["BLOCO_ID"]).PadLeft(4, pad) + " - " + Convert.ToString(fb["BLOCO"]));
                        else
                            regArvorePorServico = new ArvorePorServico(Convert.ToString(fb["MEDICAO_BLOCO_ID"]).PadLeft(4, pad) + " - " + Convert.ToString(fb["MEDICAO"]));


                regArvorePorServico.medicaoId = Convert.ToInt32(fb["MEDICAO_ID"]);
                regArvorePorServico.medicao = Convert.ToString(fb["MEDICAO"]);
                regArvorePorServico.servicoId = Convert.ToInt32(fb["SERVICO_ID"]);
                regArvorePorServico.servico = Convert.ToString(fb["SERVICO"]);
                regArvorePorServico.blocoId = Convert.ToInt32(fb["BLOCO_ID"]);
                regArvorePorServico.bloco = Convert.ToString(fb["BLOCO"]);
                regArvorePorServico.grupoId = Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]);
                regArvorePorServico.grupo = Convert.ToString(fb["GRUPO"]);
                regArvorePorServico.medicaoBlocoId = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]);
                regArvorePorServico.nivel = Convert.ToInt32(fb["NIVEL"]);
                regArvorePorServico.critico = Convert.ToInt32(fb["CRITICO"]);
                regArvorePorServico.complemento = Convert.ToString(fb["COMPLEMENTO"]);


                lista.Add(regArvorePorServico);
            }
            sql.Close();
            return lista;
        }

        public List<AssociacaoPsa> ListarPsaAssociacao(string dir, ArvorePorServico regArvorePorServico, DateTime dataInicio, DateTime dataFim)
        {
            AssociacaoPsa regAssociacaoPsa;
            List<AssociacaoPsa> lista = new List<AssociacaoPsa>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select s.complemento, iif(s.posicao is null, e.item, iif(s.posicao<9, e.item||'.0'||s.posicao, " +
                "iif(s.posicao < 99, e.item || '.' || s.posicao, 'todo'))) item, psa.dia_realizado dia_realizado, qtde_realizada, " +
                "B.ordem || '.' || cast(MB.elevacao AS integer) SEQUENCIA, B.bloco_id, b.bloco, SAMO.servico_id, s.servico, SAMO.medicao_bloco_id, " +
                "m.medicao, e.etapa, coalesce(psa.contrato_erp_id, '0') contrato_erp_id, coalesce(psa.item_contrato_erp_id, '0') item_contrato_erp_id, " +
                "coalesce(psa.acompanhamento_contrato, '') acompanhamento_contrato, coalesce(psa.medicao_erp, '') medicao_erp, samo.servico_amo_id, " +
                "psa.plan_servico_amo_id " +
                "From plan_servico_amo psa " +
                "Inner Join servico_amo samo On psa.servico_amo_id = samo.servico_amo_id " +
                "Inner Join medicao_bloco mb On samo.medicao_bloco_id = mb.medicao_bloco_id " +
                "Inner Join medicao m On mb.medicao_id = m.medicao_id " +
                "Inner Join servico s On samo.servico_id = s.servico_id " +
                "Inner Join bloco b On mb.bloco_id = b.bloco_id " +
                "Inner Join etapa e On s.etapa_id = e.etapa_id " +
                "Where psa.filho = 1 " +
                "And psa.dia_realizado Between '" + dataInicio.ToString("MM/dd/yyyy") + "' And '" + dataFim.ToString("MM/dd/yyyy") + "' " +
                "And samo.grupo_plan_servico_id = " + regArvorePorServico.grupoId.ToString() + " ";

            if (regArvorePorServico.servicoId != 0)
            {
                strSql += "And samo.servico_id = " + regArvorePorServico.servicoId.ToString() + " ";
            }

            if (regArvorePorServico.blocoId != 0)
            {
                strSql += "And B.bloco_id = " + regArvorePorServico.blocoId.ToString() + " ";
            }

            if (regArvorePorServico.medicaoBlocoId != 0)
            {
                strSql += "And SAMO.medicao_bloco_id = " + regArvorePorServico.medicaoBlocoId.ToString() + " ";
            }

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regAssociacaoPsa = new AssociacaoPsa();

                regAssociacaoPsa.complemento = Convert.ToString(fb["complemento"]);
                regAssociacaoPsa.item = Convert.ToString(fb["item"]);
                regAssociacaoPsa.sequencia = Convert.ToString(fb["sequencia"]);
                regAssociacaoPsa.servicoId = Convert.ToInt32(fb["servico_Id"]);
                regAssociacaoPsa.servico = Convert.ToString(fb["servico"]);
                regAssociacaoPsa.blocoId = Convert.ToInt32(fb["bloco_Id"]);
                regAssociacaoPsa.bloco = Convert.ToString(fb["bloco"]);
                regAssociacaoPsa.medicaoBlocoId = Convert.ToInt32(fb["medicao_Bloco_Id"]);
                regAssociacaoPsa.medicao = Convert.ToString(fb["medicao"]);
                regAssociacaoPsa.diaRealizado = Convert.ToDateTime(fb["dia_Realizado"]);
                regAssociacaoPsa.qtdeRealizada = Convert.ToDouble(fb["qtde_Realizada"]);
                regAssociacaoPsa.etapa = Convert.ToString(fb["etapa"]);
                regAssociacaoPsa.contratoErpId = Convert.ToInt32(fb["contrato_Erp_Id"]);
                regAssociacaoPsa.itemContratoErpId = Convert.ToInt32(fb["item_Contrato_Erp_Id"]);
                regAssociacaoPsa.acompanhamentoContrato = Convert.ToString(fb["acompanhamento_Contrato"]);
                regAssociacaoPsa.medicaoErp = Convert.ToString(fb["medicao_Erp"]);
                regAssociacaoPsa.servicoAmoId = Convert.ToInt32(fb["servico_Amo_Id"]); 
                regAssociacaoPsa.planServicoAmoId = Convert.ToInt32(fb["Plan_Servico_Amo_Id"]);

                lista.Add(regAssociacaoPsa);
            }

            sql.Close();
            return lista;
        }

        public List<ContratoAssociacao> ListaContratosAssociados(string dir, int servicoId, string associado)
        {
            ContratoAssociacao regContratoAssociacao;
            List<ContratoAssociacao> lista = new List<ContratoAssociacao>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select cte.contrato_erp_id, ieu.item_estrutura_uau_id, frn.fornecedor_id, frn.fornecedor " +
                "From contrato_erp cte " +
                "Inner Join item_estrutura_uau ieu On cte.contrato_erp_id = ieu.contrato_erp_id " +
                "Inner Join fornecedor frn On cte.fornecedor_id = frn.fornecedor_id " +
                "Left Join plan_servico_amo psa On Psa.contrato_erp_id = cte.contrato_erp_id " +
                "Where ieu.Servico_Id = " + servicoId.ToString() + " " +
                "And ieu.Tipo = 2 ";

            if (associado == "N")
            {
                strSql += "And psa.plan_servico_amo_id is null ";
            }
            else
            {
                if (associado == "S")
                    strSql += "And psa.plan_servico_amo_id is not null ";
            }

            strSql += "Group by cte.contrato_erp_id, ieu.item_estrutura_uau_id, frn.fornecedor_id, frn.fornecedor";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regContratoAssociacao = new ContratoAssociacao();

                regContratoAssociacao.contratoErpId = Convert.ToInt32(fb["CONTRATO_ERP_ID"]);
                regContratoAssociacao.itemContratoErpId = Convert.ToInt32(fb["ITEM_ESTRUTURA_UAU_ID"]);
                regContratoAssociacao.fornecedorId = Convert.ToInt32(fb["FORNECEDOR_ID"]);
                regContratoAssociacao.fornecedor = Convert.ToString(fb["FORNECEDOR"]);
                lista.Add(regContratoAssociacao);
            }
            sql.Close();
            return lista;
        }

        public Boolean Associar_Contrato_ItemContrato_Acompanhamento_Medicao(string dir, AssociacaoPsa regAssociacao)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {

                strSql = "Update plan_servico_amo Set CONTRATO_ERP_ID = " + regAssociacao.contratoErpId.ToString() + ", " +
                    "ITEM_CONTRATO_ERP_ID = " + regAssociacao.itemContratoErpId.ToString() + ", " +
                    "ACOMPANHAMENTO_CONTRATO = '" + regAssociacao.acompanhamentoContrato + "', " +
                    "MEDICAO_ERP = '" + regAssociacao.medicaoErp + "'" +
                    " Where plan_servico_amo_id = " + regAssociacao.planServicoAmoId.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, strSql);
                sql.t.Commit();
                sql.Close();
                sql.Dipose();
                return true;
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return false;
            }
        }
    }
}