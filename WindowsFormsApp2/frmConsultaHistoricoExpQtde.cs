using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;

namespace WindowsFormsApp2
{
    public partial class frmConsultaHistoricoExpQtde : Form
    {
        public DataTable dtUltimaVersao;
        public DataView dvUltimaVersao;
        public List<Historico_Exporta_Qtde> listaUltimaVersao;
        public DataTable dtVersoesAnteriores;
        public DataView dvVersoesAnteriores;
        public List<Historico_Exporta_Qtde> listaVersoesAnteriores;
        public Acesso_Historico_Exporta_Qtde objNeg = new Acesso_Historico_Exporta_Qtde();

        public frmConsultaHistoricoExpQtde()
        {
            InitializeComponent();

            grdUltimaVersao.RowEnter += grdUltimaVersao_RowEnter;

            listaUltimaVersao = objNeg.Listar(Application.StartupPath + "\\", 0, Acesso_Historico_Exporta_Qtde.tipoHistorico.UltimoHistorico, "");
            dtUltimaVersao = ToDataTable(listaUltimaVersao);
            dvUltimaVersao = new DataView(dtUltimaVersao);
            grdUltimaVersao.DataSource = dvUltimaVersao;
            OrganizaColunasGrdUltimaVersao();
        }

        private void edtFiltroUltimaVersao_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdUltimaVersao, dvUltimaVersao, dtUltimaVersao);            
        }

        private void grdUltimaVersao_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUltimaVersao.RowCount > 0)
            {
                string CHAVE_ERP = Convert.ToString(grdUltimaVersao.Rows[e.RowIndex].Cells["CHAVE_ERP"].Value);
                listaVersoesAnteriores = objNeg.Listar(Application.StartupPath + "\\", 0, Acesso_Historico_Exporta_Qtde.tipoHistorico.VersoesAnteriore, CHAVE_ERP);
                dtVersoesAnteriores = ToDataTable(listaVersoesAnteriores);
                dvVersoesAnteriores = new DataView(dtVersoesAnteriores);
                grdVersoesAnteriores.DataSource = dvVersoesAnteriores;
                OrganizaColunasGrdVersoesAnteriores();
            }
        }

        private void edtFiltroVersoesAnteriores_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdVersoesAnteriores, dvVersoesAnteriores, dtVersoesAnteriores);
        }

        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public void FiltraDataTable(System.Windows.Forms.TextBox textBox1, DataGridView dtgProcurar, DataView dv, DataTable dt)
        {
            string filtro = "";
            int j = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                dv.RowFilter = "";
                dtgProcurar.DataSource = dv;
            }
            else
            {
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {


                    switch (dt.Columns[i].DataType.Name)
                    {
                        case "String":
                            if (j == 0)
                            {
                                filtro = "(" + dt.Columns[i].ColumnName + " like '%" + textBox1.Text + "%')";

                                j = j + 1;
                            }
                            else
                            {
                                filtro = filtro + " or (" + dt.Columns[i].ColumnName + " like '%" + textBox1.Text + "%')";
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
                                    filtro = "(" + dt.Columns[i].ColumnName + " = " + textBox1.Text + ")";
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
                                    filtro = filtro + " or (" + dt.Columns[i].ColumnName + " = " + textBox1.Text + ")";
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
                dtgProcurar.DataSource = dv;
            }
        }

        private void OrganizaColunasGrdUltimaVersao()
        {
            //Ocultar colunas
            grdUltimaVersao.Columns["SERVICO_ID"].Visible = false;
            grdUltimaVersao.Columns["CHAVE_ERP"].Visible = false;
            grdUltimaVersao.Columns["NIVEL"].Visible = false;
            grdUltimaVersao.Columns["ITEM_NOVO"].Visible = false;
            grdUltimaVersao.Columns["INSUMO_INSTALACAO"].Visible = false;

            //Definir título das colunas
            grdUltimaVersao.Columns["HISTORICO_EXP_QTDE_ID"].HeaderText = "Histórico";
            grdUltimaVersao.Columns["ITEM"].HeaderText = "Item";
            grdUltimaVersao.Columns["TIPO"].HeaderText = "Tipo";
            grdUltimaVersao.Columns["COMPLEMENTO"].HeaderText = "Complemento";
            grdUltimaVersao.Columns["EXPORTADO"].HeaderText = "Exportado";
            grdUltimaVersao.Columns["SERVICO"].HeaderText = "Serviço";
            grdUltimaVersao.Columns["ACAO"].HeaderText = "Ação";
            grdUltimaVersao.Columns["UNID"].HeaderText = "Unid";
            grdUltimaVersao.Columns["QTDE_ANTERIOR"].HeaderText = "Qtde Anterior";
            grdUltimaVersao.Columns["QTDE_ATUAL"].HeaderText = "Qtde Atual";
            grdUltimaVersao.Columns["DIFERENCA"].HeaderText = "Diferença";
            grdUltimaVersao.Columns["DESVINCULADO_ANTERIOR"].HeaderText = "Desvinculado Anterior";
            grdUltimaVersao.Columns["DESVINCULADO_ATUAL"].HeaderText = "Desvinculado Atual";
            grdUltimaVersao.Columns["EXCLUIDO"].HeaderText = "Excluído";
            grdUltimaVersao.Columns["VERSAO"].HeaderText = "Versão";
            grdUltimaVersao.Columns["DATA_CAD"].HeaderText = "Data Cad.";
            grdUltimaVersao.Columns["DATA_ALT"].HeaderText = "Data Alt.";
            grdUltimaVersao.Columns["CAD"].HeaderText = "Usuário Cad.";
            grdUltimaVersao.Columns["ALT"].HeaderText = "Usuário Alt.";

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdUltimaVersao.Columns["HISTORICO_EXP_QTDE_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["ITEM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["TIPO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["COMPLEMENTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["EXPORTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grdUltimaVersao.Columns["SERVICO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["SERVICO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["UNID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["ACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["QTDE_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["QTDE_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["DIFERENCA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["DESVINCULADO_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["DESVINCULADO_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdUltimaVersao.Columns["EXCLUIDO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Formatar valores
            grdUltimaVersao.Columns["QTDE_ANTERIOR"].DefaultCellStyle.Format = "N";
            grdUltimaVersao.Columns["QTDE_ATUAL"].DefaultCellStyle.Format = "N";
            grdUltimaVersao.Columns["DIFERENCA"].DefaultCellStyle.Format = "N";
        }

        private void OrganizaColunasGrdVersoesAnteriores()
        {
            //Ocultar colunas
            grdVersoesAnteriores.Columns["SERVICO_ID"].Visible = false;
            grdVersoesAnteriores.Columns["NIVEL"].Visible = false;
            grdVersoesAnteriores.Columns["ITEM_NOVO"].Visible = false;
            grdVersoesAnteriores.Columns["CHAVE_ERP"].Visible = false;
            grdVersoesAnteriores.Columns["INSUMO_INSTALACAO"].Visible = false;

            //Definir título das colunas
            grdVersoesAnteriores.Columns["HISTORICO_EXP_QTDE_ID"].HeaderText = "Histórico";
            grdVersoesAnteriores.Columns["ITEM"].HeaderText = "Item";
            grdVersoesAnteriores.Columns["TIPO"].HeaderText = "Tipo";
            grdVersoesAnteriores.Columns["COMPLEMENTO"].HeaderText = "Complemento";
            grdVersoesAnteriores.Columns["EXPORTADO"].HeaderText = "Exportado";
            grdVersoesAnteriores.Columns["SERVICO"].HeaderText = "Serviço";
            grdVersoesAnteriores.Columns["ACAO"].HeaderText = "Ação";
            grdVersoesAnteriores.Columns["UNID"].HeaderText = "Unid";
            grdVersoesAnteriores.Columns["QTDE_ANTERIOR"].HeaderText = "Qtde Anterior";
            grdVersoesAnteriores.Columns["QTDE_ATUAL"].HeaderText = "Qtde Atual";
            grdVersoesAnteriores.Columns["DIFERENCA"].HeaderText = "Diferença";
            grdVersoesAnteriores.Columns["DESVINCULADO_ANTERIOR"].HeaderText = "Desvinculado Anterior";
            grdVersoesAnteriores.Columns["DESVINCULADO_ATUAL"].HeaderText = "Desvinculado Atual";
            grdVersoesAnteriores.Columns["EXCLUIDO"].HeaderText = "Excluído";
            grdVersoesAnteriores.Columns["VERSAO"].HeaderText = "Versão";
            grdVersoesAnteriores.Columns["DATA_CAD"].HeaderText = "Data Cad.";
            grdVersoesAnteriores.Columns["DATA_ALT"].HeaderText = "Data Alt.";
            grdVersoesAnteriores.Columns["CAD"].HeaderText = "Usuário Cad.";
            grdVersoesAnteriores.Columns["ALT"].HeaderText = "Usuário Alt.";

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdVersoesAnteriores.Columns["HISTORICO_EXP_QTDE_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["ITEM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["TIPO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["COMPLEMENTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["EXPORTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grdVersoesAnteriores.Columns["SERVICO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["SERVICO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["UNID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["ACAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["QTDE_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["QTDE_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["DIFERENCA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["DESVINCULADO_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["DESVINCULADO_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdVersoesAnteriores.Columns["EXCLUIDO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Formatar valores
            grdVersoesAnteriores.Columns["QTDE_ANTERIOR"].DefaultCellStyle.Format = "N";
            grdVersoesAnteriores.Columns["QTDE_ATUAL"].DefaultCellStyle.Format = "N";
            grdVersoesAnteriores.Columns["DIFERENCA"].DefaultCellStyle.Format = "N";
        }

        private void btnInsumosUltVersao_Click(object sender, EventArgs e)
        {

            if (grdUltimaVersao.RowCount > 0)
            {
                int HISTORICO_EXPORTA_QTDE_ID = Convert.ToInt32(grdUltimaVersao.CurrentRow.Cells["HISTORICO_EXP_QTDE_ID"].Value);
                frmConsultaHistExpQtdeInsumo frmHistInsumos = new frmConsultaHistExpQtdeInsumo(HISTORICO_EXPORTA_QTDE_ID);
                frmHistInsumos.Show();
            }
        }

        private void btnInsumosVersoesAnt_Click(object sender, EventArgs e)
        {
            if (grdVersoesAnteriores.RowCount > 0)
            {
                int HISTORICO_EXPORTA_QTDE_ID = Convert.ToInt32(grdVersoesAnteriores.CurrentRow.Cells["HISTORICO_EXP_QTDE_ID"].Value);
                frmConsultaHistExpQtdeInsumo frmHistInsumos = new frmConsultaHistExpQtdeInsumo(HISTORICO_EXPORTA_QTDE_ID);
                frmHistInsumos.Show();
            }
        }
    }
}
