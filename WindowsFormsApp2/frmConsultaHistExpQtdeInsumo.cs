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
    public partial class frmConsultaHistExpQtdeInsumo : Form
    {
        public frmConsultaHistExpQtdeInsumo(int HISTORICO_EXPORTA_QTDE_ID)
        {
            List<Hist_Exporta_Qtde_Insumo> listaHistoricoInsumos = new List<Hist_Exporta_Qtde_Insumo>();
            listaHistoricoInsumos = new Acesso_Hist_Exporta_Qtde_Insumo().Listar(Application.StartupPath + "\\", HISTORICO_EXPORTA_QTDE_ID);
            InitializeComponent();
            grdInsumos.DataSource = listaHistoricoInsumos;
            OrganizaColunasGrdInsumos();
        }

        private void OrganizaColunasGrdInsumos()
        {
            //Ocultar colunas
            grdInsumos.Columns["HIST_EXPORTA_QTDE_INSUMO_ID"].Visible = false;
            grdInsumos.Columns["COMPLEMENTO"].Visible = false;

            //Definir título das colunas
            grdInsumos.Columns["HISTORICO_EXPORTA_QTDE_ID"].HeaderText = "Histórico";
            grdInsumos.Columns["INSUMO_ID"].HeaderText = "Insumo";
            grdInsumos.Columns["INSUMO"].HeaderText = "Descrição";


            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdInsumos.Columns["HIST_EXPORTA_QTDE_INSUMO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdInsumos.Columns["INSUMO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdInsumos.Columns["INSUMO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
        }
    }    
}
