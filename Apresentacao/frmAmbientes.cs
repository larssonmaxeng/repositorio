using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public partial class frmAmbientes : NForm
    {
        public string idir;
        public Plan_servico_amoNegocio manipulacao;
        public ExternalCommandData irevit;
        public AMBIENTES ambientes = new AMBIENTES();
        public frmAmbientes()
        {
            InitializeComponent();
        }
        public void SelecionarAmbientes()
        {


            manipulacao.SELECIONAR(ref ambientes);
            //ambiente.SELECIONAR(ref ambientes);
            dataGridView1.DataSource = ambientes.ambientes;
            this.TopMost = true;
            this.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Close();
            /* revitDB.Element element;
            foreach (revitDB.ElementId ele in irevit.Application.ActiveUIDocument.Selection.GetElementIds())
            {
                try
                {
                   
                    element = irevit.Application.ActiveUIDocument.Document.GetElement(ele);
              //      int ambienteId = 
                 //   element.

                }
                catch (Exception e2)
                {

                }*/

            
        }
    }
}
