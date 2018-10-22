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
    public partial class frmAssociacaoPsaContrato : Form
    {
        private Rectangle dragBoxFromMouseDown;
        private object valueFromMouseDown;
        private DataView dvPsa;        
        private DataTable dtPsa;
        private DataView dvContrato;
        private DataTable dtContrato;
        private ArvorePorServico nodeArvore = new ArvorePorServico("");
        private ACESSO_ACOMPANHA_CONTRATO_UAU objNeg = new ACESSO_ACOMPANHA_CONTRATO_UAU();
        private List<AssociacaoPsa> listaAssociacaoPsa = new List<AssociacaoPsa>();
        List<ContratoAssociacao> listaContratoAssociacao = new List<ContratoAssociacao>();
        private string strDir = Application.StartupPath + "\\";
        private string strRdbAssociacao = "T";

        public frmAssociacaoPsaContrato()
        {
            InitializeComponent();
            edtFiltroPsa.TextChanged += edtFiltroPsa_TextChanged;
            edtFiltroContrato.TextChanged += edtFiltroContrato_TextChanged;
            trvPorServico.AfterSelect += trvPorServico_AfterSelect;
            dtpDataInicial.Validated +=dtpDataInicial_Validated;
            dtpDataFinal.Validated += dtpDataFinal_Validated;
            grdPsa.MouseMove += grdPsa_MouseMove;
            grdPsa.DataBindingComplete += grdPsa_DataBindingComplete;
            grdContrato.DragOver += grdContrato_DragOver;
            grdPsa.RowEnter += grdPsa_RowEnter;
            grdContrato.DragDrop += grdContrato_DragDrop;
            grdContrato.DragEnter += grdContrato_DragEnter;
            
            grdPsa.MouseDown += grdPsa_MouseDown;
            grdPsa.CellFormatting += grdPsa_CellFormatting;
            rdbTodos.CheckedChanged += rdbTodos_CheckedChanged;
            rdbSim.CheckedChanged += rdbSim_CheckedChanged;
            rdbNao.CheckedChanged += rdbNao_CheckedChanged;
            this.grdContrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {});
            MontarArvorePorServico();                        
        }
        
        public void MontarArvorePorServico()
        {            
            ACESSO_ACOMPANHA_CONTRATO_UAU objNeg = new ACESSO_ACOMPANHA_CONTRATO_UAU();
            List<ArvorePorServico> listArvore = objNeg.ListarArvorePorServico(strDir, 2);

            trvPorServico.BeginUpdate();
            int countNivel1 = -1;
            int countNivel2 = -1;
            int countNivel3 = -1;

            foreach (ArvorePorServico regArvore in listArvore)
            {
                if (regArvore.nivel == 0)
                {                    
                    countNivel2 = -1;
                    countNivel3 = -1;
                    trvPorServico.Nodes.Add(regArvore);
                    countNivel1++; ;
                }
                else
                {
                    if (regArvore.nivel == 1)
                    {                        
                        countNivel3 = -1;                        
                        trvPorServico.Nodes[countNivel1].Nodes.Add(regArvore);
                        countNivel2++;
                    }
                    else
                    {
                        if (regArvore.nivel == 2)
                        {                            
                            trvPorServico.Nodes[countNivel1].Nodes[countNivel2].Nodes.Add(regArvore);
                            countNivel3++;
                        }
                        else
                        {
                            trvPorServico.Nodes[countNivel1].Nodes[countNivel2].Nodes[countNivel3].Nodes.Add(regArvore);                            
                        }
                    }
                }            
            }

            trvPorServico.EndUpdate();
        }

        private void grdPsa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdPsa.RowCount; i++)
            {
                if (Convert.ToInt32(grdPsa.Rows[i].Cells["contratoErpId"].Value) != 0 && Convert.ToString(grdPsa.Rows[i].Cells["acompanhamentoContrato"].Value) == "")
                {
                    grdPsa.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    if (Convert.ToString(grdPsa.Rows[i].Cells["acompanhamentoContrato"].Value) != ""
                        && Convert.ToString(grdPsa.Rows[i].Cells["medicaoErp"].Value) == "")
                    {
                        grdPsa.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        if (Convert.ToString(grdPsa.Rows[i].Cells["medicaoErp"].Value) != "")
                        {
                            grdPsa.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            grdPsa.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        public void trvPorServico_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {           
            nodeArvore = (ArvorePorServico)e.Node;
            PreencherGrdPsa();
        }

        private void PreencherGrdPsa()
        {
            listaAssociacaoPsa = objNeg.ListarPsaAssociacao(strDir, nodeArvore, Convert.ToDateTime(dtpDataInicial.Value.ToShortDateString()),
                Convert.ToDateTime(dtpDataFinal.Value.ToShortDateString()));

            dtPsa = ToDataTable(listaAssociacaoPsa);
            dvPsa = new DataView(dtPsa);

            grdPsa.DataSource = dvPsa;
            OrganizarColunasGrdPsa();
            if (grdPsa.Rows.Count == 0 && grdContrato.Rows.Count > 0)
            {
                dvContrato.Table.Clear();
                grdContrato.DataSource = dvContrato;
            }
        }

        private void grdPsa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            PreencherGrdContrato(e.RowIndex);
        }

        private void PreencherGrdContrato(int index)
        {
            if (grdPsa.RowCount > 0)
            {
                int servicoId = Convert.ToInt32(grdPsa.Rows[index].Cells["servicoId"].Value);

                VerificarGrbAssociados();
                listaContratoAssociacao = objNeg.ListaContratosAssociados(strDir, servicoId, strRdbAssociacao);

                dtContrato = ToDataTable(listaContratoAssociacao);
                dvContrato = new DataView(dtContrato);
                grdContrato.DataSource = dvContrato;
                OrganizarColunasGrdContrato();
            }
        }

        private void VerificarGrbAssociados()
        {
            if (rdbSim.Checked)
                strRdbAssociacao = "S";

            if (rdbNao.Checked)
                strRdbAssociacao = "N";

            if (rdbTodos.Checked)
                strRdbAssociacao = "T";
        }

        private void dtpDataInicial_Validated(object sender, System.EventArgs e)
        {
            PreencherGrdPsa();
        }

        private void dtpDataFinal_Validated(object sender, System.EventArgs e)
        {
            PreencherGrdPsa();
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

        public void OrganizarColunasGrdContrato()
        {
            //Definir título das colunas
            grdContrato.Columns["contratoErpId"].HeaderText = "Contrato ERP";
            grdContrato.Columns["itemContratoErpId"].HeaderText = "Item Contrato ERP";
            grdContrato.Columns["fornecedorId"].HeaderText = "Código";
            grdContrato.Columns["fornecedor"].HeaderText = "Fornecedor";

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdContrato.Columns["contratoErpId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdContrato.Columns["itemContratoErpId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdContrato.Columns["fornecedorId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdContrato.Columns["fornecedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Definir alinhamento de colunas
            grdContrato.Columns["contratoErpId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdContrato.Columns["itemContratoErpId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdContrato.Columns["fornecedorId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void OrganizarColunasGrdPsa()
        {
            //Ocultar colunas
            grdPsa.Columns["servicoAmoId"].Visible = false;
            grdPsa.Columns["planServicoAmoId"].Visible = false;

            //Definir título das colunas
            grdPsa.Columns["complemento"].HeaderText = "Complemento";
            grdPsa.Columns["item"].HeaderText = "Item";
            grdPsa.Columns["sequencia"].HeaderText = "Sequencia";
            grdPsa.Columns["servicoId"].HeaderText = "Cod. Serviço";
            grdPsa.Columns["servico"].HeaderText = "Serviço";
            grdPsa.Columns["blocoId"].HeaderText = "Cod. Bloco";
            grdPsa.Columns["bloco"].HeaderText = "Bloco";
            grdPsa.Columns["medicaoBlocoId"].HeaderText = "Cod. Med. Bloco";
            grdPsa.Columns["medicao"].HeaderText = "Medição";
            grdPsa.Columns["diaRealizado"].HeaderText = "Dia Realizado";
            grdPsa.Columns["qtdeRealizada"].HeaderText = "Qtde Realizada";
            grdPsa.Columns["etapa"].HeaderText = "Etapa";
            grdPsa.Columns["contratoErpId"].HeaderText = "Contrato Erp";
            grdPsa.Columns["itemContratoErpId"].HeaderText = "Item Contrato Erp";
            grdPsa.Columns["acompanhamentoContrato"].HeaderText = "Acompanhamento Contrato ERP";
            grdPsa.Columns["medicaoErp"].HeaderText = "Medição Erp";

            //Definir alinhamento de colunas
            grdPsa.Columns["servicoId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            grdPsa.Columns["blocoId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPsa.Columns["medicaoBlocoId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPsa.Columns["qtdeRealizada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPsa.Columns["contratoErpId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdPsa.Columns["itemContratoErpId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdPsa.Columns["complemento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["sequencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["servicoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["servico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["blocoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["bloco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["medicaoBlocoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["medicao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["diaRealizado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["qtdeRealizada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["etapa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["contratoErpId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["itemContratoErpId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["acompanhamentoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdPsa.Columns["medicaoErp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            //Formatar quantidade
            grdPsa.Columns["qtdeRealizada"].DefaultCellStyle.Format = "N";            
        }

        private void grdPsa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdPsa.Columns[e.ColumnIndex].ValueType == typeof(int) || grdPsa.Columns[e.ColumnIndex].ValueType == typeof(double))
            {
                double value = Convert.ToDouble(e.Value);

                if (value == 0)
                {
                    e.Value = string.Empty;
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnExcluirAcompContrato_Click(object sender, EventArgs e)
        {
            ACESSO_ACOMPANHA_CONTRATO_UAU objNeg = new ACESSO_ACOMPANHA_CONTRATO_UAU();
            List<AcompanhaContrato> listaAcompContrato = new List<AcompanhaContrato>();
            Boolean excluirContratoItem = false;
            
            if (grdPsa.Rows.Count > 0)
            {
                if (grdPsa.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow linha in grdPsa.SelectedRows)
                    {
                        //Verificar atualização de AC e MED no ERP através de webservice
                        //Peencher listaAcompContrato com registros que podem ser excluídos.
                    }
                    if (listaAcompContrato.Count > 0)
                    {                
                        if (MessageBox.Show("Deseja excluir Contrato/Item Contrato dos itens que excluirem o Acompanhamento?", "Excluir Contrato/ItemContrato", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            excluirContratoItem = true;
                        }
                        objNeg.ExcluirAcompanhamentoContrato(strDir, listaAcompContrato, excluirContratoItem);
                        MessageBox.Show("Exclusão finalizada!");
                    }
                    else
                        MessageBox.Show("Todos os itens selecionados contém Medição no ERP!");
                }
                else
                    MessageBox.Show("É necessário seleciona no mínimo um item no grid PSA!");
            }
            else
                MessageBox.Show("Não existe itens no grid PSA!");
        }

        private void edtFiltroPsa_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdPsa, dvPsa, dtPsa);            
        }

        private void edtFiltroContrato_TextChanged(object sender, EventArgs e)
        {
            FiltraDataTable((sender as System.Windows.Forms.TextBox), grdContrato, dvContrato, dtContrato);
        }

        private void grdPsa_MouseDown(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = grdPsa.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        AssociacaoPsa regAssociacaoPsa = listaAssociacaoPsa.Find(x => x.planServicoAmoId == Convert.ToInt32(grdPsa.Rows[info.RowIndex].Cells["planServicoAmoId"].Value));
                        
                        if (regAssociacaoPsa.planServicoAmoId != 0)
                            grdPsa.DoDragDrop(regAssociacaoPsa, DragDropEffects.Copy);                            
                    }
                }
            }
        }
        
        private void grdPsa_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {                   
                    DragDropEffects dropEffect = grdPsa.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                }
            }
        }

        private void grdContrato_DragDrop(object sender, DragEventArgs e)
        {
            AssociacaoPsa regAssociacaoPsa = e.Data.GetData(typeof(AssociacaoPsa)) as AssociacaoPsa;
            Point cursorLocation = grdContrato.PointToClient(new Point(e.X, e.Y));
            
            System.Windows.Forms.DataGridView.HitTestInfo hittest = grdContrato.HitTest(cursorLocation.X, cursorLocation.Y);
            if (hittest.ColumnIndex != -1 && hittest.RowIndex != -1)
            {
                if (string.IsNullOrEmpty(regAssociacaoPsa.acompanhamentoContrato))
                {
                    Boolean associou = false;
                    regAssociacaoPsa.contratoErpId = (int)grdContrato.Rows[hittest.RowIndex].Cells["contratoErpId"].Value;
                    regAssociacaoPsa.itemContratoErpId = (int)grdContrato.Rows[hittest.RowIndex].Cells["itemContratoErpId"].Value;
                    associou = objNeg.Associar_Contrato_ItemContrato_Acompanhamento_Medicao(strDir, regAssociacaoPsa);
                    grdPsa.CurrentRow.Cells["contratoErpId"].Value = regAssociacaoPsa.contratoErpId;
                    grdPsa.CurrentRow.Cells["itemContratoErpId"].Value = regAssociacaoPsa.itemContratoErpId;
                    if (associou)
                        MessageBox.Show("Associação realizada com sucesso!");
                }
                else
                    MessageBox.Show("Já existe Acompanhamento de Contrato para esse item de PSA!");
            }
        }

        private void grdContrato_DragOver(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;
        }

        private void grdContrato_DragEnter(object sender, DragEventArgs e)
        {            
            e.Effect = DragDropEffects.Copy;
        }

        private void rdbSim_CheckedChanged(object sender, EventArgs e)
        {
            if (grdPsa.Rows.Count > 0)
                if (grdPsa.CurrentRow.Index > 0)
                    PreencherGrdContrato(grdPsa.CurrentRow.Index);
        }

        private void rdbNao_CheckedChanged(object sender, EventArgs e)
        {
            if (grdPsa.Rows.Count > 0)
                if (grdPsa.CurrentRow.Index > 0)
                    PreencherGrdContrato(grdPsa.CurrentRow.Index);
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (grdPsa.Rows.Count > 0)
                if (grdPsa.CurrentRow.Index > 0)
                    PreencherGrdContrato(grdPsa.CurrentRow.Index);
        }

        private void btnAtualizaAcompMed_Click(object sender, EventArgs e)
        {
            if (grdPsa.Rows.Count > 0)
            {
                if (grdPsa.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow linha in grdPsa.SelectedRows)
                    {
                        //Verificar atualização de AC e MED no ERP através de webservice
                    }
                }
                else
                    MessageBox.Show("É necessário seleciona no mínimo um item no grid PSA!");

            }
            else
                MessageBox.Show("Não existe itens no grid PSA!");
        }

        private void btnAtualizaContratoIC_Click(object sender, EventArgs e)
        {
            if (grdPsa.Rows.Count > 0)
            {
                if (grdPsa.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow linha in grdPsa.SelectedRows)
                    {
                        //Verificar atualização de AC e MED no ERP através de webservice
                    }
                }
                else
                    MessageBox.Show("É necessário seleciona no mínimo um item no grid PSA!");

            }
            else
                MessageBox.Show("Não existe itens no grid PSA!");
        }

        private void btnAssociarContrato_Click(object sender, EventArgs e)
        {            
            if (grdPsa.Rows.Count > 0)
            {
                if (grdContrato.Rows.Count > 0)
                {
                    if (grdPsa.SelectedRows.Count > 0)
                    {
                        if (grdContrato.SelectedRows.Count > 0)
                        {
                            if (VerificarComplementosSelecionadosPsa() == true)
                            {
                                Boolean associou = false;
                                foreach (DataGridViewRow linha in grdPsa.SelectedRows)
                                {                                    
                                    AssociacaoPsa regAssociacaoPsa = listaAssociacaoPsa.Find(x => x.planServicoAmoId == Convert.ToInt32(linha.Cells["planServicoAmoId"].Value));                                    
                                    if (string.IsNullOrEmpty(regAssociacaoPsa.acompanhamentoContrato))
                                    {
                                        regAssociacaoPsa.contratoErpId = (int)grdContrato.CurrentRow.Cells["contratoErpId"].Value;
                                        regAssociacaoPsa.itemContratoErpId = (int)grdContrato.CurrentRow.Cells["itemContratoErpId"].Value;
                                        associou = objNeg.Associar_Contrato_ItemContrato_Acompanhamento_Medicao(strDir, regAssociacaoPsa);
                                        grdPsa.Rows[linha.Index].Cells["contratoErpId"].Value = regAssociacaoPsa.contratoErpId;
                                        grdPsa.Rows[linha.Index].Cells["itemContratoErpId"].Value = regAssociacaoPsa.itemContratoErpId;
                                    }
                                }
                                if (associou)
                                {
                                    MessageBox.Show("Associação realizada com sucesso!");
                                }
                                else
                                    MessageBox.Show("Erro ao associar Contrato!");
                            }
                            else
                                MessageBox.Show("Para associar um Contrato a mais de um item de PSA, todos os Complementos devem ser iguais!");
                        }
                        else
                            MessageBox.Show("É necessário seleciona no mínimo um item no grid Contrato/Item Contrato!");
                    }
                    else
                        MessageBox.Show("É necessário seleciona no mínimo um item no grid PSA!");
                }
                else
                    MessageBox.Show("Não existe itens no grid Contrato/Item Contrato!");
            }
            else
                MessageBox.Show("Não existe itens no grid PSA!");
        }

        private Boolean VerificarComplementosSelecionadosPsa()
        {
            string strComplemento = "";
            foreach (DataGridViewRow linha in grdPsa.SelectedRows)
            {
                if (strComplemento == "")
                    strComplemento = linha.Cells["complemento"].Value.ToString();

                if (strComplemento != linha.Cells["complemento"].Value.ToString())
                    return false;
            }

            return true;
        }
    }    
}
