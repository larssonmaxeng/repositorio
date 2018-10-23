using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wf = System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;
using Funcoes;
using RevitDB = Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace Apresentacao
{
    public partial class frmSelComposicaoAvancar : wf.Form
    {
        private List<conjuntoComp> listaConjuntoComp = new List<conjuntoComp>();
        public DataView dvConjuntoComp;
        public DataTable dtConjuntoComp;
        public DateTime diaRealizado;        
        public double percentAvanco;
        public Boolean avancar;
        public UIApplication uiApp;
        private AcaoFormAvanco acaoFormAvanco;
        private ACESSO_ACOMPANHA_CONTRATO_UAU objNeg = new ACESSO_ACOMPANHA_CONTRATO_UAU();
        private string strDir = wf.Application.StartupPath + "\\";

        public frmSelComposicaoAvancar(List<string> conjuntos, double percentAvancoPar, string strUau_Com_Vista, UIApplication iuiApp, string dir, AcaoFormAvanco iacaoFormAvanco)
        {
            uiApp = iuiApp;
            InitializeComponent();
            acaoFormAvanco = iacaoFormAvanco;
            switch (acaoFormAvanco)
            {
                case AcaoFormAvanco.Avanco:
                    btnAvancar.Text = "Avançar";
                    break;
                case AcaoFormAvanco.PCP:
                    btnAvancar.Text = "PCP";
                    break;
                case AcaoFormAvanco.LookAHead:
                    btnAvancar.Text = "Lookahead";
                    break;
                case AcaoFormAvanco.Excluir:
                    btnAvancar.Text = "Excluir";
                    break;
                case AcaoFormAvanco.SubGrafico:
                    btnAvancar.Text = "Substituir";
                    tabReultados.Hide();
                    break;
                default:
                    break;
            }

            diaRealizado =  Convert.ToDateTime(dtDiaRealizado.Value.ToString());
            percentAvanco = percentAvancoPar;

            edtFiltro.TextChanged += edtFiltro_TextChanged;
            edtFiltro.Validated += edtFiltro_Validated;
            grdResultadoAvanco.DataBindingComplete += grdResultadoAvanco_DataBindingComplete;
            grdResultadoAvanco.RowEnter += grdResultadoAvanco_RowEnter;
            grdErro.RowEnter += grdErro_RowEnter;
            objectList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(HandleCellEditStarting);
            objectList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(HandleCellEditFinishing);
            objectList.SubItemChecking += objectList_SubItemChecking;
            //objectList.Click += new BrightIdeasSoftware.CellClickEventArgs();

            CriarListaConformeConjuntoComp(conjuntos, percentAvanco, strUau_Com_Vista);
            
            dtConjuntoComp = FuncaoApresentacao.ToDataTable(listaConjuntoComp);
            dvConjuntoComp = new DataView(dtConjuntoComp);           

            grdConjuntoComp.DataSource = dvConjuntoComp;
            OrganizaColunasGrdConjuntoComp();

            OrganizaObjectListView();
        }

        private void OrganizaColunasGrdConjuntoComp()
        {
            //Definir título das colunas
            grdConjuntoComp.Columns["conjunto"].HeaderText = "CONJUNTO";
            grdConjuntoComp.Columns["composicao"].HeaderText = "COMPOSIÇÃO";
            grdConjuntoComp.Columns["servico"].HeaderText = "SERVIÇO";
            grdConjuntoComp.Columns["percentual"].HeaderText = "PERCENTUAL";
            switch (acaoFormAvanco)
            {
                case AcaoFormAvanco.Avanco:
                    grdConjuntoComp.Columns["avancar"].HeaderText = "AVANÇAR?";

                    break;
                case AcaoFormAvanco.PCP:
                    grdConjuntoComp.Columns["avancar"].HeaderText = "PCP?";

                    break;
                case AcaoFormAvanco.LookAHead:
                    grdConjuntoComp.Columns["avancar"].HeaderText = "LookAHead?";

                    break;
                case AcaoFormAvanco.SubGrafico:
                    grdConjuntoComp.Columns["avancar"].HeaderText = "SubGrafico";

                    break;
                case AcaoFormAvanco.Excluir:
                    grdConjuntoComp.Columns["avancar"].HeaderText = "Excluir avanço?";

                    break;
                default:
                    break;
            }
            
            //Definir colunas que podem ser editadas
            grdConjuntoComp.Columns["conjunto"].ReadOnly = true;
            grdConjuntoComp.Columns["composicao"].ReadOnly = true;
            grdConjuntoComp.Columns["servico"].ReadOnly = true;
            grdConjuntoComp.Columns["percentual"].ReadOnly = false;
            grdConjuntoComp.Columns["avancar"].ReadOnly = false;          

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdConjuntoComp.Columns["conjunto"].AutoSizeMode = wf.DataGridViewAutoSizeColumnMode.AllCells;
            grdConjuntoComp.Columns["composicao"].AutoSizeMode = wf.DataGridViewAutoSizeColumnMode.AllCells;
            grdConjuntoComp.Columns["percentual"].AutoSizeMode = wf.DataGridViewAutoSizeColumnMode.AllCells;
            grdConjuntoComp.Columns["avancar"].AutoSizeMode = wf.DataGridViewAutoSizeColumnMode.AllCells;

            switch (acaoFormAvanco)
            {
                case AcaoFormAvanco.Avanco:

                    break;
                case AcaoFormAvanco.PCP:
                    break;
                case AcaoFormAvanco.LookAHead:
                    break;
                case AcaoFormAvanco.SubGrafico:
                    grdConjuntoComp.Columns["percentual"].Visible = false;
                    break;
                case AcaoFormAvanco.Excluir:
                    grdConjuntoComp.Columns["percentual"].Visible = false;
                    break;
                default:
                    break;
            }
        }

        public bool FazerSubGraficoParaApenasParaOsSelecionados()
        {
            wf.DialogResult dialogResult = wf.MessageBox.Show("Subgrafico para apenas selecionados?", "TocBIM", wf.MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case wf.DialogResult.Yes:
                    return true;
                    break;
                case wf.DialogResult.No:
                    return false;
                    break;
                default:
                    return false;
                    break;
            }

         }

        private void edtFiltro_TextChanged(object sender, EventArgs e)
        {
            //FuncaoApresentacao.FiltraDataTable((sender as System.Windows.Forms.TextBox), grdConjuntoComp, dvConjuntoComp, dtConjuntoComp);
            FuncaoApresentacao.FiltraOlvDataTable((sender as System.Windows.Forms.TextBox), objectList, dvConjuntoComp, dtConjuntoComp);
        }

        private void edtFiltro_Validated(object sender, System.EventArgs e)
        {
            diaRealizado = Convert.ToDateTime(dtDiaRealizado.Value.ToString());            
        }

        public wf.ProgressBar GetProgressoBar()
        {
            return pgc;
        }
        public void EsconderTabResultado()
        {
            tabReultados.Hide();
        }

        public void CriarListaConformeConjuntoComp(List<string> conjuntos, double percentAvanco, string strUau_Com_Vista)
        {            
            int servicoId;
            string strServico = "";
            foreach (string conj in conjuntos)
            {
                foreach (string strUauComp in conj.Split(';'))
                {
                    if (strUauComp.Trim() == "")
                        break;

                    conjuntoComp regConjuntoComp = new conjuntoComp();
                    if (strUau_Com_Vista == "")
                        regConjuntoComp.avancar = true;
                    else
                       if (strUau_Com_Vista.Contains(strUauComp))
                            regConjuntoComp.avancar = true;
                       else
                            regConjuntoComp.avancar = false;

                    regConjuntoComp.conjunto = conj;
                    regConjuntoComp.composicao = strUauComp;
                    servicoId = new Negocios.ACESSO_SERVICO().SelecionaPorComplemento(strDir, strUauComp, ref strServico);
                    regConjuntoComp.percentual = percentAvanco;
                    regConjuntoComp.servico = strServico;

                    List<ContratoAssociacao> listaContratoAssociacaos = objNeg.ListaContratosAssociados(strDir, servicoId, "T");
                    if (listaContratoAssociacaos.Count == 1)
                    {
                        regConjuntoComp.contrato = listaContratoAssociacaos[0].contratoErpId;
                        regConjuntoComp.itemContrato = listaContratoAssociacaos[0].itemContratoErpId;
                    }

                    listaConjuntoComp.Add(regConjuntoComp);
                }
            }
        }        

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            avancar = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            avancar = false;
            Close();
        }

        private void grdResultadoAvanco_DataBindingComplete(object sender, wf.DataGridViewBindingCompleteEventArgs e)
        {
            if(acaoFormAvanco==AcaoFormAvanco.Avanco)
            for (int i = 0; i < grdResultadoAvanco.RowCount; i++)
            {
                string acao = grdResultadoAvanco.Rows[i].Cells["ACAO"].Value.ToString();
                if (acao == Funcoes.Properties.Settings.Default.avancado || acao == Funcoes.Properties.Settings.Default.avancadoSemCriterio)
                    grdResultadoAvanco.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                if (acao == Funcoes.Properties.Settings.Default.elementoTotalmenteAvancado)
                    grdResultadoAvanco.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                if (acao == Funcoes.Properties.Settings.Default.percentualAvancadoMenor)
                    grdResultadoAvanco.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                if (acao == Funcoes.Properties.Settings.Default.percentualIndicadoNaoFazParte)
                    grdResultadoAvanco.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;                
            }
        }

        public void SetarResultadoAvanco(DataTable dtResultado)
        {
            grdResultadoAvanco.DataSource = dtResultado;
            tabControl.SelectedIndex = 1;
            wf.MessageBox.Show("Avanço finalizado!");
        }

        public void SetarErrosAvanco(List<ErroAvanco> lista)
        {
            grdErro.DataSource = lista;                        
        }

        private void grdResultadoAvanco_RowEnter(object sender, wf.DataGridViewCellEventArgs e)
        {
            try
            {
                IList<RevitDB.ElementId> lista = new List<RevitDB.ElementId>();
                lista.Add(new RevitDB.ElementId(Convert.ToInt32(grdResultadoAvanco.CurrentRow.Cells["ID_BIM"].Value)));
                uiApp.ActiveUIDocument.Selection.SetElementIds(lista);
                uiApp.ActiveUIDocument.ShowElements(lista);
            }
            catch
            {

            }
        }

        private void grdErro_RowEnter(object sender, wf.DataGridViewCellEventArgs e)
        {
            try
            {
                IList<RevitDB.ElementId> lista = new List<RevitDB.ElementId>();
                lista.Add(new RevitDB.ElementId(Convert.ToInt32(grdErro.CurrentRow.Cells["ID_BIM"].Value)));
                uiApp.ActiveUIDocument.Selection.SetElementIds(lista);
                uiApp.ActiveUIDocument.ShowElements(lista);
            }
            catch
            {

            }
        }

        private void HandleCellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.AspectName == "contrato")
            {
                if (((wf.ComboBox)e.Control).SelectedItem != null)
                {
                    e.NewValue = ((wf.ComboBox)e.Control).SelectedItem.ToString();
                    int servicoId = 0;
                    string strServico = "";
                    servicoId = new Negocios.ACESSO_SERVICO().SelecionaPorComplemento(strDir, dvConjuntoComp[e.ListViewItem.Index].Row["composicao"].ToString(), ref strServico);
                    dvConjuntoComp[e.ListViewItem.Index].Row["itemContrato"] =
                        objNeg.ListaContratosAssociados(strDir, servicoId, "T").Find(x => x.contratoErpId == Convert.ToInt32(e.NewValue)).itemContratoErpId;                                   
                }
                else
                {
                    e.NewValue = 0;
                    dvConjuntoComp[e.ListViewItem.Index].Row["itemContrato"] = 0;
                }
            }
        }

        private void HandleCellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            string strUauComp = "";
            string strServico = "";
                       

            if (e.Column.AspectName == "contrato")
            {
                int servicoId = 0;                                
                wf.ComboBox cmbbBool = new wf.ComboBox();
                cmbbBool.Bounds = e.CellBounds;
                cmbbBool.Font = ((BrightIdeasSoftware.ObjectListView)sender).Font;
                cmbbBool.DropDownStyle = wf.ComboBoxStyle.DropDownList;
                strUauComp = objectList.Items[e.ListViewItem.Index].SubItems[1].Text;
                if (!string.IsNullOrEmpty(strUauComp))
                {
                    servicoId = new Negocios.ACESSO_SERVICO().SelecionaPorComplemento(strDir, strUauComp, ref strServico);
                    List<ContratoAssociacao> listaContratoAssociacaos = objNeg.ListaContratosAssociados(strDir, servicoId, "T");
                    foreach (ContratoAssociacao regContratoAssociacao in listaContratoAssociacaos)
                    {
                        cmbbBool.Items.Add(regContratoAssociacao.contratoErpId);
                    }
                }

                e.Control = cmbbBool;
            }
        }

        private void objectList_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (e.Column.AspectName == "avancar")
            {
                if (e.Column.GetCheckState(e.RowObject) == wf.CheckState.Checked)
                    e.Column.PutCheckState(e.RowObject, wf.CheckState.Unchecked);
                else
                    e.Column.PutCheckState(e.RowObject, wf.CheckState.Checked);
            }                
        }

        private void OrganizaObjectListView()
        {
            //Criar colunas
            BrightIdeasSoftware.OLVColumn conjunto = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn composicao = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn servico = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn percentual = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn contrato = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn itemContrato = new BrightIdeasSoftware.OLVColumn();
            BrightIdeasSoftware.OLVColumn avancar = new BrightIdeasSoftware.OLVColumn();            

            conjunto.IsEditable = false;
            composicao.IsEditable = false;
            servico.IsEditable = false;
            contrato.IsEditable = true;
            itemContrato.IsEditable = false;

            avancar.CheckBoxes = true;
            avancar.TriStateCheckBoxes = true;
            avancar.IsEditable = true;
            

            //Adicionar colunas ao Objectlistview
            objectList.AllColumns.Add(conjunto);
            objectList.AllColumns.Add(composicao);
            objectList.AllColumns.Add(servico);
            objectList.AllColumns.Add(percentual);
            objectList.AllColumns.Add(contrato);
            objectList.AllColumns.Add(itemContrato);
            objectList.AllColumns.Add(avancar);            

            //Direcionando as colunas para os nomes corretos das variáveis.
            conjunto.AspectName = "conjunto";// <-- these names need to be the same as the ones in your class
            composicao.AspectName = "composicao";
            servico.AspectName = "servico";
            percentual.AspectName = "percentual";
            contrato.AspectName = "contrato";
            itemContrato.AspectName = "itemContrato";
            avancar.AspectName = "avancar";

            //Definir título das colunas
            conjunto.Text = "Conjunto"; 
            composicao.Text = "Composição";
            servico.Text = "Serviço";
            percentual.Text = "Percentual";
            contrato.Text = "Contrato";
            itemContrato.Text = "Item Contrato";
            avancar.Text = "Avançar?";

            switch (acaoFormAvanco)
            {
                case AcaoFormAvanco.Avanco:
                    avancar.Text = "Avançar?";
                    break;

                case AcaoFormAvanco.PCP:
                    avancar.Text = "PCP?";
                    contrato.IsVisible = false;
                    itemContrato.IsVisible = false;
                    break;

                case AcaoFormAvanco.LookAHead:
                    avancar.Text = "LookAHead?";
                    contrato.IsVisible = false;
                    itemContrato.IsVisible = false;
                    break;

                case AcaoFormAvanco.SubGrafico:
                    avancar.Text = "SubGrafico";
                    percentual.IsVisible = false;
                    contrato.IsVisible = false;
                    itemContrato.IsVisible = false;
                    break;

                case AcaoFormAvanco.Excluir:
                    avancar.Text = "Excluir avanço?";
                    percentual.IsVisible = false;
                    contrato.IsVisible = false;
                    itemContrato.IsVisible = false;
                    break;

                default:
                    break;
            }

            //Definir as colunas para preencher a largura da objectlistview
            conjunto.FillsFreeSpace = true;
            composicao.FillsFreeSpace = true;
            servico.FillsFreeSpace = true;
            percentual.FillsFreeSpace = true;
            contrato.FillsFreeSpace = true;
            itemContrato.FillsFreeSpace = true;
            avancar.FillsFreeSpace = true;            

            //Cria cabeçalho
            objectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {conjunto,
                composicao,
                servico,
                percentual,
                contrato,
                itemContrato,
                avancar});

            //Adicionar lista no Objectlistview
            objectList.SetObjects(dvConjuntoComp);
            objectList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways;          
        }

        private void btnAssociacaoContrato_Click(object sender, EventArgs e)
        {
            WindowsFormsApp2.frmAssociacaoPsaContrato frmAssociacaoPsaContrato = new WindowsFormsApp2.frmAssociacaoPsaContrato();
            frmAssociacaoPsaContrato.TopMost = true;
            frmAssociacaoPsaContrato.Show();            
        }
    }

    class conjuntoComp
    {
        public string conjunto { get; set; }
        public string composicao { get; set; }
        public string servico { get; set; }
        public double percentual { get; set; }
        public int contrato { get; set; }
        public int itemContrato { get; set; }
        public Boolean avancar { get; set; }        
    }

    public class ErroAvanco
    {
        public int PSA_ID { get; set; }
        public string ACAO { get; set; }
        public int ID_BIM { get; set; }
        public string ERRO { get; set; }
    }
}
