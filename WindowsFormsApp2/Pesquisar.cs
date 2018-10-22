using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Pesquisar : Form
    {
        public Boolean Continuar { get; set; }
        public DataGridViewRow LinhaSelecionada {get;set;}
        public Pesquisar()
        {
            InitializeComponent();
        }
        public Pesquisar(object lista)
        {
            InitializeComponent();
            dataGridView1.DataSource = lista;
            dataGridView1.ReadOnly = true;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1_DoubleClick(dataGridView1, e);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Continuar = true;
            LinhaSelecionada = dataGridView1.CurrentRow;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Continuar = false;
            LinhaSelecionada = null;
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
