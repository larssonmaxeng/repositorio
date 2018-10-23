using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using ObjetoTransferencia;
using Negocios;
using AcessoBancoDados;


namespace Apresentacao
{
    public partial class Vinculacao : Form
    {
        public List<CategoriaFamiliaTipoRevit> listaRevitOriginal = new List<CategoriaFamiliaTipoRevit>();
        public List<Servico> listaTocBIMOriginal;
        public List<CategoriaFamiliaTipoRevit> listaVinculoModeloOriginal = new List<CategoriaFamiliaTipoRevit>();
        public DataView dvRevit;
        public DataView dvTocBIM;
        public DataView dvTocVinculo;
        public DataTable dtRevit;
        public DataTable dtTocBIM;
        public DataTable dtTocVinculo;
        
        private ACESSO_VINCULO_MODELO_BIM ObjNegVinculo = new ACESSO_VINCULO_MODELO_BIM();
        private string modeloGuidId;
        private int alterarServico;
        private int linhaAlterarServico;
        private Servico regServico = new Servico();
        private ACESSO_SERVICO objNegServico = new ACESSO_SERVICO();
        private ACESSO_MODELO objNegModeloObra = new ACESSO_MODELO(typeof(MODELO_OBRA));
        private List<MODELO_OBRA> listaModeloObra = new List<MODELO_OBRA>();
        private int obraId;
        private Boolean tipoFamiliaAlterado;
        private string dir;

        public Vinculacao(List<ObjetoTransferencia.CategoriaFamiliaTipoRevit> listaRevit, List<Servico> listaTocBIM, string Modelo, string idir)
        {
            InitializeComponent();
            dir = idir;
            grdVinculos.CellEndEdit += grdVinculos_CellEndEdit;
            grdTocBIM.CellEndEdit += grdTocBIM_CellEndEdit;
            grdTocBIM.RowValidated += grdTocBIM_RowValidated;
            grdTocBIM.UserDeletingRow += grdTocBIM_UserDeletingRow;            

            modeloGuidId = Modelo;

            listaModeloObra = objNegModeloObra.ListarModeloObra(dir, 0, modeloGuidId);
            if (listaModeloObra.Count > 0)
                obraId = listaModeloObra[0].OBRA_ID;

            listaRevitOriginal = listaRevit;
            listaTocBIMOriginal = listaTocBIM;

            dtRevit = FuncaoApresentacao. ToDataTable(listaRevit);
            dtTocBIM = FuncaoApresentacao.ToDataTable(listaTocBIM);

            dvRevit = new DataView(dtRevit);
            dvTocBIM = new DataView(dtTocBIM);

            grdRevit.DataSource = dvRevit;
            grdTocBIM.DataSource = dvTocBIM;

            grdRevit.DataBindingComplete += grdRevit_DataBindingComplete;
            grdRevit.RowEnter += grdRevit_RowEnter;
            grdTocBIM.Columns["ServicoId"].ReadOnly = true;
            grdTocBIM.Columns["Unid"].Visible = false;
        }                

        private void btnVincular_Click(object sender, EventArgs e)
        {
            Boolean confirma = false;
            VINCULO_MODELO_BIM RegVinculo = new VINCULO_MODELO_BIM();
            List<VINCULO_MODELO_BIM> AuxListVinculo = new List<VINCULO_MODELO_BIM>();
            DataGridViewSelectedRowCollection selRevit = grdRevit.SelectedRows;
            DataGridViewSelectedRowCollection selTocBIM = grdTocBIM.SelectedRows;

            foreach (DataGridViewRow rowRevit in selRevit)
            {
                foreach (DataGridViewRow rowTocBIM in selTocBIM)
                {
                    RegVinculo = new VINCULO_MODELO_BIM();
                    RegVinculo.SERVICO_ID = Convert.ToInt32(rowTocBIM.Cells["ServicoId"].Value);
                    RegVinculo.MODELO_GUID_ID = modeloGuidId;
                    RegVinculo.CATEGORIA_ID = Convert.ToString(rowRevit.Cells["CATEGORIA_ID"].Value);
                    RegVinculo.CATEGORIA = Convert.ToString(rowRevit.Cells["CATEGORIA"].Value);
                    RegVinculo.FAMILIA_ID = Convert.ToString(rowRevit.Cells["FAMILIA_ID"].Value);
                    RegVinculo.FAMILIA = Convert.ToString(rowRevit.Cells["FAMILIA"].Value);
                    RegVinculo.TIPO_FAMILIA_ID = Convert.ToInt32(rowRevit.Cells["TIPO_FAMILIA_ID"].Value);
                    RegVinculo.TIPO_FAMILIA = Convert.ToString(rowRevit.Cells["TIPO_FAMILIA"].Value);
                    RegVinculo.ELEMENTO = Convert.ToString(rowTocBIM.Cells["Elemento"].Value);
                    AuxListVinculo = ObjNegVinculo.ListarVinculo(dir, obraId, modeloGuidId, RegVinculo.CATEGORIA_ID, RegVinculo.FAMILIA_ID, RegVinculo.TIPO_FAMILIA_ID,
                        RegVinculo.SERVICO_ID);

                    if (AuxListVinculo.Count == 0)
                        confirma = ObjNegVinculo.Inserir(dir, RegVinculo); 
                    else
                        confirma = ObjNegVinculo.Atualizar(dir, RegVinculo);
                }

            }
            grdVinculos.DataSource = ObjNegVinculo.ListarVinculo(dir, obraId, modeloGuidId, grdRevit.CurrentRow.Cells["CATEGORIA_ID"].Value.ToString(),
                    grdRevit.CurrentRow.Cells["FAMILIA_ID"].Value.ToString(), Convert.ToInt32(grdRevit.CurrentRow.Cells["TIPO_FAMILIA_ID"].Value), 0);
            OrganizaColunasGrdVinculos();

            if (confirma)
                MessageBox.Show("Vínculo realizado com sucesso!");
            else
                MessageBox.Show("Nenhum vínculo realizado!");
        }

        private void btnDesvincular_Click(object sender, EventArgs e)
        {
            Boolean confirma = false;
            VINCULO_MODELO_BIM RegVinculo = new VINCULO_MODELO_BIM();
            DataGridViewSelectedRowCollection selVinculo = grdVinculos.SelectedRows;
           
            foreach (DataGridViewRow rowVinculo in selVinculo)
            {
                new VINCULO_MODELO_BIM();
                RegVinculo.VINCULO_MODELO_BIM_ID = Convert.ToInt32(rowVinculo.Cells["VINCULO_MODELO_BIM_ID"].Value);
                RegVinculo.CATEGORIA_ID = Convert.ToString(rowVinculo.Cells["CATEGORIA_ID"].Value);
                RegVinculo.FAMILIA_ID = Convert.ToString(rowVinculo.Cells["FAMILIA_ID"].Value);
                RegVinculo.TIPO_FAMILIA_ID = Convert.ToInt32(rowVinculo.Cells["TIPO_FAMILIA_ID"].Value);
                RegVinculo.SERVICO_ID = 0;

                confirma = ObjNegVinculo.Deletar(dir, RegVinculo);                
            }
            grdVinculos.DataSource = ObjNegVinculo.ListarVinculo(dir, obraId, modeloGuidId, grdRevit.CurrentRow.Cells["CATEGORIA_ID"].Value.ToString(),
                    grdRevit.CurrentRow.Cells["FAMILIA_ID"].Value.ToString(), Convert.ToInt32(grdRevit.CurrentRow.Cells["TIPO_FAMILIA_ID"].Value), 0);
            OrganizaColunasGrdVinculos();

            if (confirma)
                MessageBox.Show("Vínculo removido com sucesso!");
            else
                MessageBox.Show("Nenhum vínculo removido!");
        }

        public void FiltraDataTable (System.Windows.Forms.TextBox textBox1, DataGridView dtgProcurar, DataView dv, DataTable dt)
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

        private void edtFiltroRevit_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdRevit, dvRevit, dtRevit);
            FiltrarTipoFamiliaAlterado(tipoFamiliaAlterado);
        }

        private void edtFiltroTocBIM_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdTocBIM, dvTocBIM, dtTocBIM);
        }

        private void grdRevit_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRevit.RowCount > 0)
            {
                grdVinculos.DataSource = ObjNegVinculo.ListarVinculo(dir, obraId, modeloGuidId, grdRevit.Rows[e.RowIndex].Cells["CATEGORIA_ID"].Value.ToString(), 
                    grdRevit.Rows[e.RowIndex].Cells["FAMILIA_ID"].Value.ToString(), Convert.ToInt32(grdRevit.Rows[e.RowIndex].Cells["TIPO_FAMILIA_ID"].Value), 0);
                OrganizaColunasGrdVinculos();
            }
        }

        private void grdRevit_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdRevit.RowCount; i++)
            {
                if (Convert.ToBoolean(grdRevit.Rows[i].Cells["VINCULADO_NOME_DIFERENTE"].Value) == true)
                    grdRevit.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else
                    grdRevit.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }             
        }

        private void grdVinculos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Boolean confirma = false;
            VINCULO_MODELO_BIM RegVinculo = new VINCULO_MODELO_BIM();

            RegVinculo.SERVICO_ID = Convert.ToInt32(grdVinculos.Rows[e.RowIndex].Cells["SERVICO_ID"].Value);
            RegVinculo.MODELO_GUID_ID = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["MODELO_GUID_ID"].Value); 
            RegVinculo.CATEGORIA_ID = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["CATEGORIA_ID"].Value);
            RegVinculo.CATEGORIA = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["CATEGORIA"].Value);
            RegVinculo.FAMILIA_ID = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["FAMILIA_ID"].Value);
            RegVinculo.FAMILIA = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["FAMILIA"].Value);
            RegVinculo.TIPO_FAMILIA_ID = Convert.ToInt32(grdVinculos.Rows[e.RowIndex].Cells["TIPO_FAMILIA_ID"].Value);
            RegVinculo.TIPO_FAMILIA = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["TIPO_FAMILIA"].Value);
            RegVinculo.ELEMENTO = Convert.ToString(grdVinculos.Rows[e.RowIndex].Cells["ELEMENTO"].Value);
            RegVinculo.VINCULO_MODELO_BIM_ID = Convert.ToInt32(grdVinculos.Rows[e.RowIndex].Cells["VINCULO_MODELO_BIM_ID"].Value);
            confirma = ObjNegVinculo.Atualizar(dir, RegVinculo);

        }        

        private void btnConfirmaVinculo_Click(object sender, EventArgs e)
        {
            Boolean confirma = false;
            string filtro = "";
            VINCULO_MODELO_BIM RegVinculo = new VINCULO_MODELO_BIM();
            List<VINCULO_MODELO_BIM> listaVinculoAux = new List<VINCULO_MODELO_BIM>();
            List<CategoriaFamiliaTipoRevit> listaRevitAux = new List<CategoriaFamiliaTipoRevit>();
            DataGridViewSelectedRowCollection selRevit = grdRevit.SelectedRows;            

            foreach (DataGridViewRow rowRevit in selRevit)
            {
                if (Convert.ToBoolean(rowRevit.Cells["VINCULADO_NOME_DIFERENTE"].Value))
                {
                    //fazer a consulta na tabela para cada item
                    listaVinculoAux = ObjNegVinculo.ListarVinculo(dir, obraId, modeloGuidId, rowRevit.Cells["CATEGORIA_ID"].Value.ToString(),
                        rowRevit.Cells["FAMILIA_ID"].Value.ToString(), Convert.ToInt32(rowRevit.Cells["TIPO_FAMILIA_ID"].Value), 0);
                    OrganizaColunasGrdVinculos();

                    foreach (var rowVinculo in listaVinculoAux)
                    {

                        RegVinculo.SERVICO_ID = rowVinculo.SERVICO_ID;
                        RegVinculo.MODELO_GUID_ID = modeloGuidId;
                        RegVinculo.CATEGORIA_ID = Convert.ToString(rowRevit.Cells["CATEGORIA_ID"].Value);
                        RegVinculo.CATEGORIA = Convert.ToString(rowRevit.Cells["CATEGORIA"].Value);
                        RegVinculo.FAMILIA_ID = Convert.ToString(rowRevit.Cells["FAMILIA_ID"].Value);
                        RegVinculo.FAMILIA = Convert.ToString(rowRevit.Cells["FAMILIA"].Value);
                        RegVinculo.TIPO_FAMILIA_ID = Convert.ToInt32(rowRevit.Cells["TIPO_FAMILIA_ID"].Value);
                        RegVinculo.TIPO_FAMILIA = Convert.ToString(rowRevit.Cells["TIPO_FAMILIA"].Value);
                        RegVinculo.ELEMENTO = rowVinculo.ELEMENTO;
                        RegVinculo.VINCULO_MODELO_BIM_ID = rowVinculo.VINCULO_MODELO_BIM_ID;
                        confirma = ObjNegVinculo.Atualizar(dir, RegVinculo);
                    }
                }
            }

            listaRevitAux = ObjNegVinculo.VerificarAlteracaoNome(dir, modeloGuidId, listaRevitOriginal);
            filtro = dvRevit.RowFilter;
            dtRevit = FuncaoApresentacao.ToDataTable(listaRevitAux);
            dvRevit = new DataView(dtRevit);
            dvRevit.RowFilter = filtro;
            grdRevit.DataSource = dvRevit;            

            if (confirma)
                MessageBox.Show("Confirmação realizado com sucesso!");
            else
                MessageBox.Show("Não houve confirmação de vínculo!");

        }

        private void OrganizaColunasGrdVinculos()
        {
            //ordem das colunas
            grdVinculos.Columns["TIPO_FAMILIA_ID"].DisplayIndex = 0;
            grdVinculos.Columns["TIPO_FAMILIA"].DisplayIndex = 1;
            grdVinculos.Columns["ELEMENTO"].DisplayIndex = 2;
            grdVinculos.Columns["VINCULO_MODELO_BIM_ID"].DisplayIndex = 3;
            grdVinculos.Columns["SERVICO_ID"].DisplayIndex = 4;
            grdVinculos.Columns["SERVICO"].DisplayIndex = 5;
            grdVinculos.Columns["COMPLEMENTO"].DisplayIndex = 6;
            grdVinculos.Columns["MODELO_GUID_ID"].DisplayIndex = 7;
            grdVinculos.Columns["CATEGORIA_ID"].DisplayIndex = 8;
            grdVinculos.Columns["CATEGORIA"].DisplayIndex = 9;
            grdVinculos.Columns["FAMILIA_ID"].DisplayIndex = 10;
            grdVinculos.Columns["FAMILIA"].DisplayIndex = 11;

            //colunas que podem ou não ser editadas
            grdVinculos.Columns["TIPO_FAMILIA_ID"].ReadOnly = true;
            grdVinculos.Columns["TIPO_FAMILIA"].ReadOnly = true;
            grdVinculos.Columns["ELEMENTO"].ReadOnly = false;
            grdVinculos.Columns["VINCULO_MODELO_BIM_ID"].ReadOnly = true;
            grdVinculos.Columns["SERVICO_ID"].ReadOnly = true;
            grdVinculos.Columns["MODELO_GUID_ID"].ReadOnly = true;
            grdVinculos.Columns["CATEGORIA_ID"].ReadOnly = true;
            grdVinculos.Columns["CATEGORIA"].ReadOnly = true;
            grdVinculos.Columns["FAMILIA_ID"].ReadOnly = true;
            grdVinculos.Columns["FAMILIA"].ReadOnly = true;
        }

        

        private void grdTocBIM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            regServico = new Servico();

            if (grdTocBIM.Rows[e.RowIndex].Cells["ServicoId"].Value.ToString() == "")
                regServico.ServicoId = 0;
            else
                regServico.ServicoId = Convert.ToInt32(grdTocBIM.Rows[e.RowIndex].Cells["ServicoId"].Value.ToString().Trim());

            regServico.DescServico = grdTocBIM.Rows[e.RowIndex].Cells["DescServico"].Value.ToString();
            regServico.Unid = grdTocBIM.Rows[e.RowIndex].Cells["Unid"].Value.ToString();
            regServico.Complemento = grdTocBIM.Rows[e.RowIndex].Cells["Complemento"].Value.ToString();
            regServico.Elemento = grdTocBIM.Rows[e.RowIndex].Cells["Elemento"].Value.ToString();

            if (grdTocBIM.Rows[e.RowIndex].Cells["ServicoId"].Value.ToString() != "")            
            {
                alterarServico += 1;
                linhaAlterarServico = e.RowIndex;
            }
        }

        private void grdTocBIM_RowValidated(Object sender, DataGridViewCellEventArgs e)
        {
            int auxServicoId;

            //verificar e inserir novo Serviço
            if (regServico.ServicoId == 0 && ((regServico.DescServico != "" && regServico.DescServico != null) || 
                                                (regServico.Complemento != "" && regServico.Complemento != null) || 
                                                (regServico.Elemento != "" && regServico.Elemento != null)))
            {
                auxServicoId = objNegServico.InserirServico(dir, regServico);
                if (auxServicoId == 0)
                    MessageBox.Show("Erro ao inserir Serviço!");
                else
                {
                    regServico = new Servico();
                    grdTocBIM.Sort(grdTocBIM.Columns["ServicoId"], ListSortDirection.Ascending);
                    grdTocBIM.Rows[0].Cells["ServicoId"].Value = auxServicoId;
                }
            }

            //verificar e atualizar Serviço
            if (alterarServico > 0)
            {                
                if (objNegServico.AtualizarServico(dir, regServico) == true)
                {
                    regServico = new Servico();
                    alterarServico = 0;
                    linhaAlterarServico = -1;
                }
                else
                    MessageBox.Show("Erro ao atualizar Serviço!");
            }
        }

        private void grdTocBIM_UserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e)
        {
            regServico = new Servico();
            regServico.ServicoId = Convert.ToInt32(grdTocBIM.Rows[e.Row.Index].Cells["ServicoId"].Value);
            if (objNegServico.ExcluirServico(dir, regServico) == false)
                MessageBox.Show("Erro ao excluir Servico!");
        }

        private void chkTipoFamiliaAlt_Click(object sender, EventArgs e)
        {
            tipoFamiliaAlterado = chkTipoFamiliaAlt.Checked;
            FiltrarTipoFamiliaAlterado(tipoFamiliaAlterado);
        }

        private void FiltrarTipoFamiliaAlterado(Boolean Alterado)
        {
            if (Alterado == true)
            {
                if (dvRevit.RowFilter.Trim() == "")
                    dvRevit.RowFilter = "VINCULADO_NOME_DIFERENTE = true";
                else
                    dvRevit.RowFilter = "(" + dvRevit.RowFilter + ") And (VINCULADO_NOME_DIFERENTE = true)";

                grdRevit.DataSource = dvRevit;
            }
            else
            {
                dvRevit.RowFilter = dvRevit.RowFilter.Replace(" And (VINCULADO_NOME_DIFERENTE = true)", "");
                dvRevit.RowFilter = dvRevit.RowFilter.Replace("VINCULADO_NOME_DIFERENTE = true", "");
                grdRevit.DataSource = dvRevit;
            }
        }
    }
}
