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
using System.IO;
using AcessoBancoDados;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Funcoes;


namespace Apresentacao
{
    public partial class FrmConsultaObraBloco : System.Windows.Forms.Form
    {
        public DataView dvBloco;        
        public DataTable dtBloco;
        public DataView dvObra;
        public DataTable dtObra;
        private ACESSO_OBRA ObraNeg = new ACESSO_OBRA();
        private ACESSO_BLOCO BlocoNeg = new ACESSO_BLOCO();
        private ACESSO_EMPRESA EmpresaNeg = new ACESSO_EMPRESA();
        private List<Obra> listaObra;
        private List<Bloco> listaBloco;        
        private int Obra_Id;
        private int alterarBloco;
        private int alterarObra;
        private string dir;
        private Obra RegObraCad = new Obra();
        private Bloco RegBlocoCad = new Bloco();
        private ExternalCommandData modrevit;

        public FrmConsultaObraBloco(ExternalCommandData revit, string idir)
        {
            dir = idir;
            modrevit = revit;
            InitializeComponent();

            listaObra = ObraNeg.Listar(Application.StartupPath + "\\", 0);

            dtObra = ToDataTable(listaObra);            
            dvObra = new DataView(dtObra);
            grdObra.DataSource = dvObra;
            Atualiza_Caption_Obra();
            DesabilitarEdicaoGrdObra();

            grdObra.RowEnter += grdObra_RowEnter;
            grdObra.CellEndEdit += grdObra_CellEndEdit;
            grdObra.RowValidated += grdObra_RowValidated;
            grdObra.UserDeletingRow += grdObra_UserDeletingRow;
            grdObra.CellClick += grdObra_CellClick;

            grdBloco.CellEndEdit += grdBloco_CellEndEdit;
            grdBloco.RowValidated += grdBloco_RowValidated;
            grdBloco.UserDeletingRow += grdBloco_UserDeletingRow;
            TratarColunasDatas();

            if (grdObra.RowCount > 0)
            {                
                Obra_Id = Convert.ToInt32(grdObra.Rows[0].Cells["Obra_Id"].Value); 
                listaBloco = BlocoNeg.ListarPorObra(dir, Obra_Id);

                dtBloco = ToDataTable(listaBloco);
                dvBloco = new DataView(dtBloco);                
                grdBloco.DataSource = dvBloco;
                Atualiza_Caption_Bloco();
                DesabilitarEdicaoGrdBloco();
            }
        }

        private void Atualiza_Caption_Bloco()
        {
            grdBloco.Columns["BLOCO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["BLOCO_ID"].HeaderText = "CÓDIGO BLOCO";
            grdBloco.Columns["OBRA_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["OBRA_ID"].HeaderText = "OBRA";
            grdBloco.Columns["BLOCO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["BLOCO"].HeaderText = "BLOCO";
            grdBloco.Columns["TIPO_ESTATO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["TIPO_ESTATO_ID"].HeaderText = "TIPO ESTATO";
            grdBloco.Columns["TIPO_ATIVO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["TIPO_ATIVO_ID"].HeaderText = "TIPO ATIVO";
            grdBloco.Columns["DATA_CAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["DATA_CAD"].HeaderText = "DATA CADASTRO";
            grdBloco.Columns["DATA_ALT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["DATA_ALT"].HeaderText = "DATA ALTERAÇÃO";
            grdBloco.Columns["OBS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["OBS"].HeaderText = "OBSERVAÇÃO";
            grdBloco.Columns["REPETICAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["REPETICAO"].HeaderText = "REPETIÇÃO";
            grdBloco.Columns["ALT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["ALT"].HeaderText = "ALTERAÇÃO";
            grdBloco.Columns["CAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["CAD"].HeaderText = "CADASTRO";
            grdBloco.Columns["ORDEM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["ORDEM"].HeaderText = "ORDEM";
            grdBloco.Columns["SICRONIZADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["SICRONIZADO"].HeaderText = "SICRONIZADO";
            grdBloco.Columns["SYCRBLOCO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdBloco.Columns["SYCRBLOCO_ID"].HeaderText = "SYCRBLOCO";
    }

        private void Atualiza_Caption_Obra()
        {
            grdObra.Columns["OBRA_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
            grdObra.Columns["OBRA_ID"].HeaderText = "OBRA";
            grdObra.Columns["OBRA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["OBRA"].HeaderText = "CÓDIGO OBRA";
            grdObra.Columns["NOBRA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["NOBRA"].HeaderText = "NOME OBRA";
            grdObra.Columns["EMPRESA_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["EMPRESA_ID"].HeaderText = "EMPRESA";
            grdObra.Columns["EMPRESA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["EMPRESA"].HeaderText = "NOME EMPRESA";
            grdObra.Columns["P_EXECUCAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["P_EXECUCAO"].HeaderText = "PERCENTUAL EXECUÇAO";
            grdObra.Columns["DATA_CAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["DATA_CAD"].HeaderText = "DATA CADASTRO";
            grdObra.Columns["DATA_ALT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["DATA_ALT"].HeaderText = "DATA ALTARAÇÃO";
            grdObra.Columns["DATA_META"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["DATA_META"].HeaderText = "DATA META";
            grdObra.Columns["INICIO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["INICIO"].HeaderText = "INÍCIO";
            grdObra.Columns["TERMINO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["TERMINO"].HeaderText = "TÉRMINO";
            grdObra.Columns["PRAZO_DE_VENDA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["PRAZO_DE_VENDA"].HeaderText = "PRAZO DE VENDA";
            grdObra.Columns["PRAZO_DE_REPASSE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["PRAZO_DE_REPASSE"].HeaderText = "PRAZO DE REPASSE";
            grdObra.Columns["PRECO_OBRA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["PRECO_OBRA"].HeaderText = "PREÇO OBRA";
            grdObra.Columns["TIPO_ESTATO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["TIPO_ESTATO_ID"].HeaderText = "TIPO ESTATO";
            grdObra.Columns["TIPO_ATIVO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["TIPO_ATIVO_ID"].HeaderText = "TIPO ATIVO";
            grdObra.Columns["ALT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["ALT"].HeaderText = "ALTERADO";
            grdObra.Columns["CAD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["CAD"].HeaderText = "CADASTRO";
            grdObra.Columns["PRODUCAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["PRODUCAO"].HeaderText = "PRODUÇÃO";
            grdObra.Columns["DADOS_DO_MAPA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["DADOS_DO_MAPA"].HeaderText = "DADOS DO MAPA";
            grdObra.Columns["MAPA_ORIGEM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["MAPA_ORIGEM"].HeaderText = "MAPA ORIGEM";
            grdObra.Columns["VALOR_MAPA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["VALOR_MAPA"].HeaderText = "VALOR MAPA";
            grdObra.Columns["VALOR_MEDIDO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["VALOR_MEDIDO"].HeaderText = "VALOR MEDIDO";
            grdObra.Columns["VALOR_BRUTO_DA_MEDICAO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["VALOR_BRUTO_DA_MEDICAO"].HeaderText = "VALOR BRUTO DA MEDÇIÃO";
            grdObra.Columns["SALDO_TOTAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["SALDO_TOTAL"].HeaderText = "SALDO TOTAL";
            grdObra.Columns["PERCENT_EXECUTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["PERCENT_EXECUTADO"].HeaderText = "PERCENTUAL EXECUTADO";
            grdObra.Columns["CAMPO_ASSINATURA_01"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["CAMPO_ASSINATURA_01"].HeaderText = "CAMPO ASSINATURA 01";
            grdObra.Columns["CAMPO_ASSINATURA_02"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["CAMPO_ASSINATURA_02"].HeaderText = "CAMPO ASSINATURA 02";
            grdObra.Columns["CAMPO_ASSINATURA_03"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["CAMPO_ASSINATURA_03"].HeaderText = "CAMPO ASSINATURA 03";
            grdObra.Columns["CAMPO_ASSINATURA_04"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["CAMPO_ASSINATURA_04"].HeaderText = "CAMPO ASSINATURA 04";
            grdObra.Columns["TERRENO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["TERRENO_ID"].HeaderText = "TERRENO";
            grdObra.Columns["SYCROBRA_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdObra.Columns["SYCROBRA_ID"].HeaderText = "SYCROBRA";
        }

        private void grdObra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Obra_Id = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value);
            listaBloco = BlocoNeg.ListarPorObra(dir, Obra_Id);

            dtBloco = ToDataTable(listaBloco);
            dvBloco = new DataView(dtBloco);
            grdBloco.DataSource = dvBloco;
            Atualiza_Caption_Bloco();
            DesabilitarEdicaoGrdBloco();
        }

        private void grdObra_UserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e)
        {
            Obra_Id = Convert.ToInt32(grdObra.Rows[e.Row.Index].Cells["Obra_Id"].Value);
            listaBloco = new List<Bloco>();
            listaBloco = BlocoNeg.ListarPorObra(dir, Obra_Id);

            if (listaBloco.Count > 0)
            {
                MessageBox.Show("Não é possível deletar uma Obra que tenha Bloco(s) cadastrado(s)!");
                e.Cancel = true;
            }
            else
            {
                RegObraCad = new Obra();
                RegObraCad.OBRA_ID = Convert.ToInt32(grdObra.Rows[e.Row.Index].Cells["OBRA_ID"].Value);

                if (ObraNeg.Deletar(dir, RegObraCad) == false)
                    MessageBox.Show("Erro ao deletar Obra!");
            }
        }

        private void grdObra_RowValidated(Object sender, DataGridViewCellEventArgs e)
        {
            if (alterarObra > 0)
            {
                if (ObraNeg.Atualizar(dir, RegObraCad) == true)
                {
                    alterarObra = 0;
                }
                else
                    MessageBox.Show("Erro ao atualizar Obra!");
            }
        }

        private void grdObra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RegObraCad = new Obra();

            if (grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString() == "")
                RegObraCad.OBRA_ID = 0;
            else
                RegObraCad.OBRA_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["EMPRESA_ID"].Value.ToString() == "")
                RegObraCad.EMPRESA_ID = 0;
            else
                RegObraCad.EMPRESA_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["EMPRESA_ID"].Value.ToString());

            RegObraCad.OBRA = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["OBRA"].Value);
            RegObraCad.NOBRA = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["NOBRA"].Value);

            if (grdObra.Rows[e.RowIndex].Cells["REALIZADO"].Value.ToString() == "")
                RegObraCad.REALIZADO = 0;
            else
                RegObraCad.REALIZADO = Convert.ToDouble(grdObra.Rows[e.RowIndex].Cells["REALIZADO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["META"].Value.ToString() == "")
                RegObraCad.META = 0;
            else
                RegObraCad.META = Convert.ToDouble(grdObra.Rows[e.RowIndex].Cells["META"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["P_EXECUCAO"].Value.ToString() == "")
                RegObraCad.P_EXECUCAO = 0;
            else
                RegObraCad.P_EXECUCAO = Convert.ToDouble(grdObra.Rows[e.RowIndex].Cells["P_EXECUCAO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["DATA_CAD"].Value.ToString() == "")
                RegObraCad.DATA_CAD = DateTime.Now;
            else
                RegObraCad.DATA_CAD = Convert.ToDateTime(grdObra.Rows[e.RowIndex].Cells["DATA_CAD"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["DATA_META"].Value.ToString() != "")
                RegObraCad.DATA_META = Convert.ToDateTime(grdObra.Rows[e.RowIndex].Cells["DATA_META"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["INICIO"].Value.ToString() != "")
                RegObraCad.INICIO = Convert.ToDateTime(grdObra.Rows[e.RowIndex].Cells["INICIO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["TERMINO"].Value.ToString() != "")
                RegObraCad.TERMINO = Convert.ToDateTime(grdObra.Rows[e.RowIndex].Cells["TERMINO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["PRAZO_DE_VENDA"].Value.ToString() == "")
                RegObraCad.PRAZO_DE_VENDA = 0;
            else
                RegObraCad.PRAZO_DE_VENDA = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["PRAZO_DE_VENDA"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["PRAZO_DE_REPASSE"].Value.ToString() == "")
                RegObraCad.PRAZO_DE_REPASSE = 0;
            else
                RegObraCad.PRAZO_DE_REPASSE = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["PRAZO_DE_REPASSE"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["DATA"].Value.ToString() != "")
                RegObraCad.DATA = Convert.ToDateTime(grdObra.Rows[e.RowIndex].Cells["DATA"].Value.ToString());

            RegObraCad.ENGENHEIRO = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["ENGENHEIRO"].Value);
            RegObraCad.NCTR = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["NCTR"].Value);
            RegObraCad.CONSTRUTORA = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CONSTRUTORA"].Value);
            RegObraCad.NCTC = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["NCTC"].Value);

            if (grdObra.Rows[e.RowIndex].Cells["PRECO_OBRA"].Value.ToString() == "")
                RegObraCad.PRECO_OBRA = 0;
            else
                RegObraCad.PRECO_OBRA = Convert.ToDouble(grdObra.Rows[e.RowIndex].Cells["PRECO_OBRA"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["INCC"].Value.ToString() == "")
                RegObraCad.INCC = 0;
            else
                RegObraCad.INCC = Convert.ToDouble(grdObra.Rows[e.RowIndex].Cells["INCC"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["TIPO_ESTATO_ID"].Value.ToString() == "")
                RegObraCad.TIPO_ESTATO_ID = 0;
            else
                RegObraCad.TIPO_ESTATO_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["TIPO_ESTATO_ID"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["TIPO_ATIVO_ID"].Value.ToString() == "")
                RegObraCad.TIPO_ATIVO_ID = 0;
            else
                RegObraCad.TIPO_ATIVO_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["TIPO_ATIVO_ID"].Value.ToString());
            
            RegObraCad.ALT = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["ALT"].Value);
            RegObraCad.CAD = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CAD"].Value);

            if (grdObra.Rows[e.RowIndex].Cells["PLANEJAMENTO"].Value.ToString() == "")
                RegObraCad.PLANEJAMENTO = 0;
            else
                RegObraCad.PLANEJAMENTO = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["PLANEJAMENTO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["CONTROLE"].Value.ToString() == "")
                RegObraCad.CONTROLE = 0;
            else
                RegObraCad.CONTROLE = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["CONTROLE"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["PRODUCAO"].Value.ToString() == "")
                RegObraCad.PRODUCAO = 0;
            else
                RegObraCad.PRODUCAO = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["PRODUCAO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["GESTOR"].Value.ToString() == "")
                RegObraCad.GESTOR = 0;
            else
                RegObraCad.GESTOR = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["GESTOR"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["CLIENTE"].Value.ToString() == "")
                RegObraCad.CLIENTE = 0;
            else
                RegObraCad.CLIENTE = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["CLIENTE"].Value.ToString());

            RegObraCad.DADOS_DO_MAPA = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["DADOS_DO_MAPA"].Value);
            RegObraCad.MAPA_ORIGEM = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["MAPA_ORIGEM"].Value);
            RegObraCad.VALOR_MAPA = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["VALOR_MAPA"].Value);
            RegObraCad.VALOR_MEDIDO = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["VALOR_MEDIDO"].Value);
            RegObraCad.VALOR_BRUTO_DA_MEDICAO = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["VALOR_BRUTO_DA_MEDICAO"].Value);
            RegObraCad.SALDO_TOTAL = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["SALDO_TOTAL"].Value);
            RegObraCad.PERCENT_EXECUTADO = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["PERCENT_EXECUTADO"].Value);
            RegObraCad.CAMPO_ASSINATURA_01 = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CAMPO_ASSINATURA_01"].Value);
            RegObraCad.CAMPO_ASSINATURA_02 = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CAMPO_ASSINATURA_02"].Value);
            RegObraCad.CAMPO_ASSINATURA_03 = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CAMPO_ASSINATURA_03"].Value);
            RegObraCad.CAMPO_ASSINATURA_04 = Convert.ToString(grdObra.Rows[e.RowIndex].Cells["CAMPO_ASSINATURA_04"].Value);

            if (grdObra.Rows[e.RowIndex].Cells["TERRENO_ID"].Value.ToString() == "")
                RegObraCad.TERRENO_ID = 0;
            else
                RegObraCad.TERRENO_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["TERRENO_ID"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["SICRONIZADO"].Value.ToString() == "")
                RegObraCad.SICRONIZADO = 0;
            else
                RegObraCad.SICRONIZADO = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["SICRONIZADO"].Value.ToString());

            if (grdObra.Rows[e.RowIndex].Cells["SYCROBRA_ID"].Value.ToString() == "")
                RegObraCad.SYCROBRA_ID = 0;
            else
                RegObraCad.SYCROBRA_ID = Convert.ToInt32(grdObra.Rows[e.RowIndex].Cells["SYCROBRA_ID"].Value.ToString());


            if (grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString() != "0" && grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString() != "")
            {
                alterarObra += 1;
                RegObraCad.DATA_ALT = DateTime.Now;
            }
            else
            {
                if (RegObraCad.OBRA_ID == 0 && RegObraCad.EMPRESA_ID != 0)
                {
                    int auxObra_Id;

                    
                    auxObra_Id = ObraNeg.Inserir(dir, RegObraCad);

                    if (auxObra_Id != 0)
                    {
                        grdObra.Rows[e.RowIndex].Cells["OBRA_ID"].Value = auxObra_Id;
                        grdObra.Rows[e.RowIndex].Cells["EMPRESA"].Value = EmpresaNeg.Listar(dir, RegObraCad.EMPRESA_ID)[0].EMPRESA;
                    }                                    
                }
            }
        }        

        private void DesabilitarEdicaoGrdObra()
        {
            grdObra.Columns["OBRA_ID"].ReadOnly = true;
            grdObra.Columns["EMPRESA"].ReadOnly = true;
            grdObra.Columns["DATA_CAD"].ReadOnly = true;
            grdObra.Columns["DATA_ALT"].ReadOnly = true;
            grdObra.Columns["CAD"].ReadOnly = true;
            grdObra.Columns["ALT"].ReadOnly = true;
        }
               
        private void TratarColunasDatas()
        {
            if (grdObra.RowCount > 0)
            {                
                grdObra.Columns["DATA_META"].ValueType = typeof(DateTime);
                grdObra.Columns["INICIO"].ValueType = typeof(DateTime);
                grdObra.Columns["TERMINO"].ValueType = typeof(DateTime);
                grdObra.Columns["DATA"].ValueType = typeof(DateTime);
                grdObra.Columns["DATA_CAD"].ValueType = typeof(DateTime);
                grdObra.Columns["DATA_ALT"].ValueType = typeof(DateTime);                
            }
        }        
       
        private void grdBloco_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RegBlocoCad = new Bloco();

            if (grdBloco.Rows[e.RowIndex].Cells["BLOCO_ID"].Value.ToString() == "")
                RegBlocoCad.BLOCO_ID = 0;
            else
                RegBlocoCad.BLOCO_ID = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["BLOCO_ID"].Value.ToString().Trim());

            if (grdBloco.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString() == "")
                RegBlocoCad.OBRA_ID = 0;
            else
                RegBlocoCad.OBRA_ID = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["OBRA_ID"].Value.ToString());

            RegBlocoCad.BLOCO = Convert.ToString(grdBloco.Rows[e.RowIndex].Cells["BLOCO"].Value);

            if (grdBloco.Rows[e.RowIndex].Cells["TIPO_ESTATO_ID"].Value.ToString() == "")
                RegBlocoCad.TIPO_ESTATO_ID = 0;
            else
                RegBlocoCad.TIPO_ESTATO_ID = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["TIPO_ESTATO_ID"].Value.ToString());

            if (grdBloco.Rows[e.RowIndex].Cells["TIPO_ATIVO_ID"].Value.ToString() == "")
                RegBlocoCad.TIPO_ATIVO_ID = 0;
            else
                RegBlocoCad.TIPO_ATIVO_ID = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["TIPO_ATIVO_ID"].Value.ToString());

            if (grdBloco.Rows[e.RowIndex].Cells["DATA_CAD"].Value.ToString() == "")
                RegBlocoCad.DATA_CAD = DateTime.Now;
            else
                RegBlocoCad.DATA_CAD = Convert.ToDateTime(grdBloco.Rows[e.RowIndex].Cells["DATA_CAD"].Value.ToString());
            
            RegBlocoCad.OBS = Convert.ToString(grdBloco.Rows[e.RowIndex].Cells["OBS"].Value);

            if (grdBloco.Rows[e.RowIndex].Cells["REPETICAO"].Value.ToString() == "")
                RegBlocoCad.REPETICAO = 0;
            else
                RegBlocoCad.REPETICAO = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["REPETICAO"].Value.ToString());

            RegBlocoCad.ALT = Convert.ToString(grdBloco.Rows[e.RowIndex].Cells["ALT"].Value);
            RegBlocoCad.CAD = Convert.ToString(grdBloco.Rows[e.RowIndex].Cells["CAD"].Value);

            if (grdBloco.Rows[e.RowIndex].Cells["ORDEM"].Value.ToString() == "")
                RegBlocoCad.ORDEM = 0;
            else
                RegBlocoCad.ORDEM = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["ORDEM"].Value);

            if (grdBloco.Rows[e.RowIndex].Cells["SICRONIZADO"].Value.ToString() == "")
                RegBlocoCad.SICRONIZADO = 0;
            else
                RegBlocoCad.SICRONIZADO = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["SICRONIZADO"].Value.ToString());

            if (grdBloco.Rows[e.RowIndex].Cells["SYCRBLOCO_ID"].Value.ToString() == "")
                RegBlocoCad.SYCRBLOCO_ID = 0;
            else
                RegBlocoCad.SYCRBLOCO_ID = Convert.ToInt32(grdBloco.Rows[e.RowIndex].Cells["SYCRBLOCO_ID"].Value.ToString());

            if (grdBloco.Rows[e.RowIndex].Cells["BLOCO_ID"].Value.ToString() != "0" && grdBloco.Rows[e.RowIndex].Cells["BLOCO_ID"].Value.ToString() != "")
            {
                alterarBloco += 1;
                RegBlocoCad.DATA_ALT = DateTime.Now;
            }
            else
            {
                if (RegBlocoCad.BLOCO_ID == 0 && RegBlocoCad.BLOCO != "" && RegBlocoCad.BLOCO != null)
                {                 
                    grdBloco.Rows[e.RowIndex].Cells["OBRA_ID"].Value = grdObra.CurrentRow.Cells["OBRA_ID"].Value;
                    RegBlocoCad.OBRA_ID = Convert.ToInt32(grdObra.CurrentRow.Cells["OBRA_ID"].Value);

                    int auxBloco_Id;                    
                    auxBloco_Id = BlocoNeg.Inserir(dir, RegBlocoCad);

                    if (auxBloco_Id != 0)
                    {
                        grdBloco.Columns["BLOCO_ID"].ReadOnly = true;
                        RegBlocoCad = new Bloco();
                        grdBloco.Rows[e.RowIndex].Cells["BLOCO_ID"].Value = auxBloco_Id;
                    }                    
                }
            }
        }

        private void grdBloco_RowValidated(Object sender, DataGridViewCellEventArgs e)
        {
            
            if (alterarBloco > 0)
            {
                if (BlocoNeg.Atualizar(dir, RegBlocoCad) == true)
                {
                    alterarBloco = 0;
                }
                else
                    MessageBox.Show("Erro ao atualizar Bloco!");
            }
        }

        private void grdBloco_UserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e)
        {
            RegBlocoCad = new Bloco();
            RegBlocoCad.BLOCO_ID = Convert.ToInt32(grdBloco.Rows[e.Row.Index].Cells["BLOCO_ID"].Value);

            if (BlocoNeg.Deletar(dir, RegBlocoCad) == false)
                MessageBox.Show("Erro ao deletar Bloco!");
        }        

        private void DesabilitarEdicaoGrdBloco()
        {
            grdBloco.Columns["OBRA_ID"].ReadOnly = true;
            grdBloco.Columns["BLOCO_ID"].ReadOnly = true;
            grdBloco.Columns["DATA_CAD"].ReadOnly = true;
            grdBloco.Columns["DATA_ALT"].ReadOnly = true;
            grdBloco.Columns["CAD"].ReadOnly = true;
            grdBloco.Columns["ALT"].ReadOnly = true;
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

        private void grdObra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.registrarModelo.Index && e.RowIndex >= 0)
            {
                RegistrarModel(modrevit);
            }

        }

        public void RegistrarModel(ExternalCommandData revit)
        {
            UIApplication uiApp = revit.Application;
            Document uiDoc = uiApp.ActiveUIDocument.Document;
            Selection sel = uiApp.ActiveUIDocument.Selection;

            try
            {
                GlobalParameter p = FuncaoNBR15575.globalParameter(uiDoc, "L7GUID");
                ParameterValue pv = p.GetValue();
                StringParameterValue s = pv as StringParameterValue;

                Negocios.ACESSO_MODELO acessoModelo = new Negocios.ACESSO_MODELO(dir);

                MODELO_OBRA mb = new MODELO_OBRA();
                mb.MODELO_GUID_ID = s.Value.ToString();                
                mb.OBRA_ID = Convert.ToInt32(grdObra.Rows[grdObra.CurrentRow.Index].Cells["Obra_Id"].Value);

                acessoModelo.Inserir(dir, mb);
                MessageBox.Show("Modelo cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                TaskDialog.Show("_", e.Message);
            }
        }
    }
}
