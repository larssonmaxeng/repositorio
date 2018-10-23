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
    public static class FuncaoApresentacao
    {
        public static DataTable ToDataTable<T>(IList<T> data)
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

        public static void FiltraDataTable(System.Windows.Forms.TextBox textBox1, DataGridView dtgProcurar, DataView dv, DataTable dt)
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

        public static void FiltraOlvDataTable(System.Windows.Forms.TextBox textBox1, BrightIdeasSoftware.ObjectListView olvProcurar, DataView dv, DataTable dt)
        {
            string filtro = "";
            int j = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                dv.RowFilter = "";
                olvProcurar.SetObjects(dv);
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
                olvProcurar.SetObjects(dv);
            }
        }
    }
}
