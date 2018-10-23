using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using AcessoBancoDados;

namespace Apresentacao
{
    public partial class ArvoreMedicaoBloco : Form
    {
        private string fdir;
        private int fMEDICAO_BLOCO_SELECIONADO_ID;

        public FbsqlConnection fbsqlConnection;
        public FbCommand cmd;
        public DataTable dtDados;
        public FbDataReader drDados;
    public bool icontinuar;



        public int MEDICAO_BLOCO_SELECIONADO_ID
        {
            get { return fMEDICAO_BLOCO_SELECIONADO_ID; }
            set { fMEDICAO_BLOCO_SELECIONADO_ID = value; }
        }

        public string Dir
        {
            get { return fdir ;}
            set 
            { fdir = value ;
              fbsqlConnection.Diretorio = Dir;
              fbsqlConnection.Ativo(true);
            
            }
        }
        public ArvoreMedicaoBloco(string dir)
        {
            InitializeComponent();
            fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            cmd = new FbCommand();
            
            Dir = dir;
            drDados = drDadosOpen();

            dtDados = new DataTable();
            dtDados.Load(drDados);

           
     
            GerarArvore();
        }
        public FbDataReader drDadosOpen()
        {    
        cmd.Connection = fbsqlConnection.FbConexao;
        cmd.CommandText = "select OBRA_ID," +
                            "OBRA," +
                            "NIVEL," +
                            "BLOCO_ID," +
                            "BLOCO," +
                            "MEDICAO_BLOCO_ID," +
                            "MEDICAO_BLOCO," +
                            "ORDEM_OBRA," +
                            "ORDEM_BLOCO," +
                            "ORDEM_MEDICAO_BLOCO from VW_MEDICAO_BLOCO where obra_Id =@OBRA_ID";

         int obra_id= 2;
         cmd.Parameters.Add(new FbParameter("OBRA_ID", obra_id));
            
         return cmd.ExecuteReader();          

        }
        public void GerarArvore()
        {
            arvore.Nodes.Clear();

         
            int i0 = 0;
            int i1 = -1;
            int i2 = -1;



            foreach (DataRow dataRow in dtDados.Rows)
            {

                switch (Convert.ToInt32(dataRow["NIVEL"].ToString()))
                {

                    case 0:
                        arvore.Nodes.Add("Obra");
                        i0 = +i0;
                
                        break;

                    case 1:
                        arvore.Nodes[i0].Nodes.Add(dataRow["BLOCO_ID"].ToString(), dataRow["BLOCO_ID"].ToString().PadLeft(4, '0') + "- " + dataRow["BLOCO"].ToString());
                        i1 = i1 + 1;
                      
                        // arvore.Nodes[i0].Nodes[i1].ToolTipText = "9";             

                        break;
                    case 2:
                        arvore.Nodes[i0].Nodes[i1].Nodes.Add(dataRow["MEDICAO_BLOCO_ID"].ToString(), dataRow["MEDICAO_BLOCO_ID"].ToString().PadLeft(4, '0') + "- " + dataRow["MEDICAO_BLOCO"].ToString());

                        i2 = 1 + i2;
                        
                        // arvore.Nodes[i0].Nodes[i1].Nodes[i2].ToolTipText = "9";             

                        break;

                    default:


                        break;

                }

            }
          
            i0 = 0;
            i1 = 0;
            i2 = 0;


            foreach (DataRow dataRow1 in dtDados.Rows)
            {

                switch (Convert.ToInt32(dataRow1["NIVEL"].ToString()))
                {

                    case 0:
                        arvore.Nodes[i0].Tag = 0;
                        i0 = +i0;
                 
                        break;

                    case 1:
                        arvore.Nodes[i0].Nodes[i1].Tag= 2;//;.Add(dataRow1["BLOCO_ID"].ToString(), dataRow1["BLOCO_ID"].ToString().PadLeft(4, '0') + "- " + dataRow1["BLOCO"].ToString());
                        i1 = i1 + 1;
                      
                        // arvore.Nodes[i0].Nodes[i1].ToolTipText = "9";             

                        break;
                    case 2:
                        try
                        {
                            arvore.Nodes[i0].Nodes[i1].Nodes[i2].Tag = dataRow1["MEDICAO_BLOCO_ID"].ToString();//.Add(dataRow1["MEDICAO_BLOCO_ID"].ToString(), dataRow1["MEDICAO_BLOCO_ID"].ToString().PadLeft(4, '0') + "- " + dataRow1["MEDICAO_BLOCO"].ToString());

                            i2 = 1 + i2;

                            // arvore.Nodes[i0].Nodes[i1].Nodes[i2].ToolTipText = "9";             

                        
                        }
                        catch
                        { 
                        }
                        break;
                    default:


                        break;

                }

            }
        }

            






        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           



        }


        public void inputar(ref string unidadeDeMedicao, ref bool continuar)
        {
            ShowDialog();
            unidadeDeMedicao = "";
            continuar = icontinuar;
            unidadeDeMedicao = Convert.ToString(MEDICAO_BLOCO_SELECIONADO_ID);

            

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            arvore_DoubleClick(arvore, null);
        }

        private void arvore_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            icontinuar = false;
            this.Close();
        }



        private void arvore_DoubleClick(object sender, EventArgs e)
        {
            switch ((sender as TreeView).SelectedNode.Level)
            {
                case 0: case 1: case 2: MessageBox.Show("Marque uma unidade de medição para selecionar");
                break;
                case 3:
                  MessageBox.Show((sender as TreeView).SelectedNode.Text);
                  MessageBox.Show((sender as TreeView).SelectedNode.Tag.ToString());
                break;
                default:
                   
                    
                    break;
            }
           
            icontinuar = true;
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string filtroTexto;
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                filtroTexto = "(Upper(bloco) like '%" + (sender as TextBox).Text.ToUpper() + "%') or " +
                         "(Upper(medicao_bloco) like'%" + (sender as TextBox).Text.ToUpper() + "%')";

                dtDados.Select(filtroTexto);
         
            }
            else
            {
                dtDados.Select();
            }
            GerarArvore();

        }


    }
}
