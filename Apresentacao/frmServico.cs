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
    public partial class frmServico : NForm
    {
        public NBindingSource bsServico = new NBindingSource();
        public NDataTable dtServico = new NDataTable("Servico");
        public DataView dv;
        public FbsqlConnection sqlConnection = new FbsqlConnection();
        public DataSet ds = new DataSet("Tabelas");
        public Boolean continuar = false;
        public Plan_servico_amoNegocio manipulacao;
        public string dir;
        public string UAU_COMP_SELECIONADA = "";
        public frmServico()
        {
            InitializeComponent();
        }
        public frmServico(string idir)
        {
            InitializeComponent();
            dir = idir;
            manipulacao = new Plan_servico_amoNegocio(idir);
        }


        private void frmServico_Load(object sender, EventArgs e)
        {

        }
        public void TrataGrid()
        {
           
         
        }
        public void DefinirServico()
        {
            dtServico.Rows.Clear();
            dtServico.ifbcommandSelect.Connection = sqlConnection.FbConexao;
            dtServico.ifbcommandSelect.CommandText = "select s.servico_id," +
                                                           " S.SERVICO,  " +
                                                           " S.ELEMENTO, "+
                                                           " S.UNID, " +
                                                           " S.COMPLEMENTO, " +
                                                           " e.item, "+
                                                           " S.POSICAO, " +
                                                           " S.ETAPA_ID, " +
                                                           

                                                           " E.ETAPA " +

                                                        " from servico s " +
                                                          " left join etapa e on s.etapa_id = e.etapa_id " +
                                                          " ORDER BY  E.ITEM, s.etapa_id desc, S.SERVICO ";

                                
            dtServico.ida = new FbDataAdapter(dtServico.ifbcommandSelect);
            dtServico.ifbUpdate = new FbCommand(" UPDATE SERVICO S SET  " +
                                                    " S.UNID = @UNID , "+
                                                    " S.POSICAO = @POSICAO, " +

                                                    " S.ETAPA_ID = @ETAPA_ID, " +
                                                    " S.ELEMENTO = @ELEMENTO " +
                                                    " WHERE S.SERVICO_ID = @SERVICO_ID " , sqlConnection.FbConexao);


            dtServico.ifbUpdate.Parameters.Add(new FbParameter("UNID", FbDbType.VarChar, 0, "UNID"));
            dtServico.ifbUpdate.Parameters.Add(new FbParameter("POSICAO", FbDbType.Integer, 0, "POSICAO"));

            dtServico.ifbUpdate.Parameters.Add(new FbParameter("ETAPA_ID", FbDbType.Integer, 0, "ETAPA_ID"));
            dtServico.ifbUpdate.Parameters.Add(new FbParameter("ELEMENTO_ID", FbDbType.Integer, 0, "ELEMENTO_ID"));
            dtServico.ifbUpdate.Parameters.Add(new FbParameter("SERVICO_ID", FbDbType.Integer, 0, "SERVICO_ID"));

            dtServico.ida.UpdateCommand = dtServico.ifbUpdate;

            dtServico.ida.Fill(dtServico);
            ds.Tables.Add(dtServico);
        }
        public void Abrir()
            {

                bsServico.abrindo = true;
                grdServico.PermitirFullSelect = true;

                sqlConnection.Diretorio = dir;
                sqlConnection.Ativo(true);
                DefinirServico();
                dv = new DataView(dtServico);
            grdServico.DataSource = dv;    

            this.TrataColunas("Código;Descrição;Elemento;Unid;Uau;Item;Posicao;Etapa;Desc. etapa;", ";", grdServico);
            this.TrataColunasLargura("80;250;80;60;80;80;100;150;80;", ";", grdServico);
            grdServico.Columns["ITEM"].ReadOnly = true;
            grdServico.Columns["ETAPA_ID"].ReadOnly = true;
            grdServico.Columns["ETAPA"].ReadOnly = true;

            bsServico.abrindo = false;
            this.ShowDialog();
         
        }
        private void btnImportarComposicoes_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==DialogResult.OK)
            {
                System.IO.StreamReader arquivo = new System.IO.StreamReader(op.FileName, Encoding.GetEncoding("iso-8859-1"));
                string linha = "";
                while (true)
                {
                    linha = arquivo.ReadLine();
                    if (linha != null)
                    {
                        try
                        {
                            string[] DadosColetados = linha.Split(';');
                            new ACESSO_SERVICO().Inserir(dir, new Servico
                            {
                                Complemento = DadosColetados[0],
                                DescServico = DadosColetados[1],
                                Unid = DadosColetados[2],

                            });
                        }
                        catch
                        {

                        }
                    }
                    else
                  break;
                }
                MessageBox.Show("Processo concluído");*/
            foreach (Composicoes item in new ACESSO_COMPOSICOES().Seleciona())
            {
                string unid = "";
                if (item.Unid_comp == "UN") unid = "Contador";
                if (item.Unid_comp == "M") unid = "Comprimento";
                if (item.Unid_comp == "M2") unid = "Área";
                if (item.Unid_comp == "M3") unid = "Volume";



                new ACESSO_SERVICO().Inserir(dir, new Servico { Complemento = item.Cod_comp, DescServico = item.Descr_comp, Unid = item.Unid_comp , Elemento = unid});
            }
            MessageBox.Show("Processo concluído");
            Abrir();
            
        }

        private void btnAtribuirItem_Click(object sender, EventArgs e)
        {
            FrmProcurar procurar = new FrmProcurar();
            StringBuilder sb = new StringBuilder();
            sb.Append("    select ");
            sb.Append("   etapa_id,  ");
            sb.Append("   item,  ");
            sb.Append("   etapa, etapa_id  ");
            sb.Append(" from etapa order by item ");

            ResultadoProcura rp = new ResultadoProcura();
            rp = procurar.Pesquisar(dir, "Escolher o item",
                                      sb.ToString(), "Código;Item;Descrição;Id;",
                                                    "80;100;350;50;");


            if (!rp.fResultadoProcura) return;
            int etapaid = Convert.ToInt32( ( rp.linha as DataGridViewRow).Cells["ETAPA_ID"].Value);
            string item = (rp.linha as DataGridViewRow).Cells["ITEM"].Value.ToString();
            string etapa = (rp.linha as DataGridViewRow).Cells["ETAPA"].Value.ToString();

            if (grdServico.SelectedRows.Count < 2)
            {
                grdServico.CurrentRow.Cells["ETAPA_ID"].Value = etapaid;
                grdServico.CurrentRow.Cells["ITEM"].Value = item;
                grdServico.CurrentRow.Cells["ETAPA"].Value = etapa;
                manipulacao.PRC_EXECUTAR_DIRETO("UPDATE SERVICO S SET S.ETAPA_ID = " + etapaid.ToString() + 
                    " WHERE S.SERVICO_ID = " +
                    grdServico.CurrentRow.Cells["SERVICO_ID"].Value.ToString());

            }
            else
            {
                foreach (DataGridViewRow item1 in grdServico.SelectedRows)
                {
                    item1.Cells["ETAPA_ID"].Value = etapaid;
                    item1.Cells["ITEM"].Value = item;
                    item1.Cells["ETAPA"].Value = etapa;
                    manipulacao.PRC_EXECUTAR_DIRETO("UPDATE SERVICO S SET S.ETAPA_ID = " + etapaid.ToString() +
    " WHERE S.SERVICO_ID = " +
    grdServico.CurrentRow.Cells["SERVICO_ID"].Value.ToString());
                }
            }
            
        }

        private void edtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = "";
            int j = 0;
            if (string.IsNullOrEmpty(edtFiltro.Text))
            {

                dv.RowFilter = "";
                grdServico.DataSource = dv;
            }
            else
            {



                for (int i = 0; i <= dtServico.Columns.Count - 1; i++)
                {


                    switch (dtServico.Columns[i].DataType.Name)
                    {
                        case "String":
                            if (j == 0)
                            {
                                filtro = "(" + dtServico.Columns[i].ColumnName + " like '" + edtFiltro.Text + "')";

                                j = j + 1;

                            }
                            else
                            {

                                filtro = filtro + " or (" + dtServico.Columns[i].ColumnName + " like '" + edtFiltro.Text + "')";
                                j = j + 1;

                            }
                            break;
                        case "Int32":
                        case "DOUBLE":
                            if (j == 0)
                            {
                                try
                                {
                                    Convert.ToDouble(edtFiltro.Text);
                                    filtro = "(" + dtServico.Columns[i].ColumnName + " = " + edtFiltro.Text + ")";
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
                                    Convert.ToDouble(edtFiltro.Text);
                                    filtro = filtro + " or (" + dtServico.Columns[i].ColumnName + " = " + edtFiltro.Text + ")";
                                    j = j + 1;

                                }
                                catch
                                {

                                }


                            }

                            break;

                    }
                }


                dv.RowFilter = filtro;
                grdServico.DataSource = dv;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader arquivo = new System.IO.StreamReader(op.FileName, Encoding.GetEncoding("iso-8859-1"));
                string linha = "";
                while (true)
                {
                    linha = arquivo.ReadLine();
                    if (linha != null)
                    {
                        try
                        {
                            string[] DadosColetados = linha.Split(';');
                            new ACESSO_ETAPA().Inserir(dir, new ETAPA
                            {
                                ITEM = DadosColetados[0],
                                ETAPA_DESCRICAO = DadosColetados[1]

                            });
                        }
                        catch
                        {

                        }
                    }
                    else
                        break;
                }
                MessageBox.Show("Processo concluído");
            }
        }

        private void btnAtribuirUAUCOMP_Click(object sender, EventArgs e)
        {

            if(grdServico.SelectedRows.Count>1)
            {
                MessageBox.Show("Esta opção apenas uma linha selecionada");
                return;
            }
            continuar = true;
            UAU_COMP_SELECIONADA = grdServico.CurrentRow.Cells["COMPLEMENTO"].Value.ToString();
            Close();
        }

        private void nDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if ((grdServico.Columns[grdServico.CurrentCell.ColumnIndex].Name == "ITEM") |
                (grdServico.Columns[grdServico.CurrentCell.ColumnIndex].Name == "ETAPA") |
                (grdServico.Columns[grdServico.CurrentCell.ColumnIndex].Name == "ETAPA_ID"))
            {

                btnAtribuirItem_Click(btnAtribuirItem, null);
            }
            else
            {
                if (grdServico.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Esta opção apenas uma linha selecionada");
                    return;
                }
                continuar = true;
                UAU_COMP_SELECIONADA = grdServico.CurrentRow.Cells["COMPLEMENTO"].Value.ToString();
                Close();
            }
        }

        private void nDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!bsServico.abrindo)
            
                if ((grdServico.Columns[e.ColumnIndex].Name == "ELEMENTO") | (grdServico.Columns[e.ColumnIndex].Name == "POSICAO"))
                {
                    manipulacao.PRC_EXECUTAR_DIRETO("UPDATE SERVICO S SET " +
                        " S.ELEMENTO = '" + grdServico.Rows[e.RowIndex].Cells["ELEMENTO"].Value.ToString() + "'," +
                        " S.POSICAO = '" + grdServico.Rows[e.RowIndex].Cells["POSICAO"].Value.ToString() + "' " +
                        " WHERE S.SERVICO_ID = " +
                        grdServico.Rows[e.RowIndex].Cells["SERVICO_ID"].Value.ToString());
                }
            
        }
    }
}
