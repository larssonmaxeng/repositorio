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
using AcessoBancoDados;
using System.Globalization;
using ObjetoTransferencia;
using System.Reflection;
using Negocios;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmProcurar :NForm
    {

        public FbDataReader dr;
        public FbDataAdapter da;
        public DataTable dt;
        public FbCommand fbcommand;
        public DataView dv;
        Boolean excluirAcomp;

        public FrmProcurar()
        {
            InitializeComponent();
            dtgProcurar.DataBindingComplete += dtgProcurar_DataBindingComplete;
        }


        public ResultadoProcura Pesquisar<T>(IList<T> lista, string titulo, string nomeColunas, Boolean excluirAcompContrato)
        {
            excluirAcomp = excluirAcompContrato;
            resultadoProcura = new ResultadoProcura();
            
            dt = FuncaoApresentacao.ToDataTable(lista);
            dv = new DataView(dt);
            dv.AllowDelete = false;
            dv.AllowEdit = false;
            dv.AllowNew = false;
            dtgProcurar.DataSource = dv;

            if (!string.IsNullOrEmpty(nomeColunas))
                TrataColunas(nomeColunas, ";", dtgProcurar);

            //            TrataColunasLargura(tamanhoColunas, ";", dtgProcurar);
            //            dtgProcurar.TrataColunasAlinhamento();
            this.Text = titulo;
             ShowDialog();
             return resultadoProcura;
        }

        public ResultadoProcura Pesquisar( string dir, string titulo, string instrucaoSql, string nomeColunas, string tamanhoColunas)
        {            
             resultadoProcura = new ResultadoProcura();
            dt = new DataTable("Procurar");
            fbcommand = new FbCommand();
            FbsqlConnection sqlConnection = new FbsqlConnection();
            sqlConnection.Diretorio = dir;
            sqlConnection.Ativo(true);
            fbcommand.Connection = sqlConnection.FbConexao;
            fbcommand.CommandText = instrucaoSql;
            dr = fbcommand.ExecuteReader();        
            dt.Load(dr);
            dv = new DataView(dt);
            dv.AllowDelete = false;
            dv.AllowEdit = false;
            dv.AllowNew = false;
            dtgProcurar.DataSource = dv;
            TrataColunas(nomeColunas, ";", dtgProcurar);
            TrataColunasLargura(tamanhoColunas, ";", dtgProcurar);
            dtgProcurar.TrataColunasAlinhamento();
            this.Text = titulo;
            ShowDialog();
            return resultadoProcura;
        }

        private void dtgProcurar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (excluirAcomp == true)
            { 
                for (int i = 0; i < dtgProcurar.RowCount; i++)
                {
                    if (!string.IsNullOrEmpty(dtgProcurar.Rows[i].Cells["MEDICAO_ERP"].Value.ToString())) 
                        dtgProcurar.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    else
                        dtgProcurar.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        protected  DataTable buildDataTableFromComplexTypeList<T>(string tableName, List<T> complexList)
        {
            DataTable tabela = new DataTable();
            PropertyInfo[] propriedades = typeof(T).GetProperties();

            tabela.Columns.AddRange(
                propriedades.Select(p => new DataColumn(p.Name, (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(p.PropertyType) : p.PropertyType))).ToArray()
                );

            complexList.ForEach(
                i => tabela.Rows.Add(
                    propriedades.Select(p => p.GetValue(i) ?? DBNull.Value).ToArray()
                    )
                );

            return tabela;
        }
        public ResultadoProcura PesquisarCausaPCP(string dir, string titulo, string nomeColunas, string tamanhoColunas)
        {
            resultadoProcura = new ResultadoProcura();
            Plan_servico_amoNegocio manipulacao = new Plan_servico_amoNegocio(dir);

            dt = buildDataTableFromComplexTypeList("Procurar", manipulacao.SEL_CAUSA_PCP());


            //dr = fbcommand.ExecuteReader();

           // dt.Load(dr);

            dv = new DataView(dt);

            dv.AllowDelete = false;
            dv.AllowEdit = false;
            dv.AllowNew = false;
            dtgProcurar.DataSource = dv;
            TrataColunas(nomeColunas, ";", dtgProcurar);
            TrataColunasLargura(tamanhoColunas, ";", dtgProcurar);
            dtgProcurar.TrataColunasAlinhamento();
            this.Text = titulo;
            ShowDialog();
            return resultadoProcura;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            resultadoProcura.linha = dtgProcurar.CurrentRow;
            resultadoProcura.fResultadoProcura = true;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

                

                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    
                   
                    switch (dt.Columns[i].DataType.Name)
                    {
                        case "String":
                            if (j == 0)
                            {
                                filtro = "("+dt.Columns[i].ColumnName + " like '%" + textBox1.Text + "%')";

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
                                    filtro ="("+ dt.Columns[i].ColumnName + " = " + textBox1.Text+")" ;
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
                                    filtro = filtro + " or (" + dt.Columns[i].ColumnName + " = " + textBox1.Text +")";
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

        private void dtgProcurar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(dtgProcurar, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            resultadoProcura.fResultadoProcura = false;
            Close();
     
        }

        private void dtgProcurar_Paint(object sender, PaintEventArgs e)
        {
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {

        }
    }
}
