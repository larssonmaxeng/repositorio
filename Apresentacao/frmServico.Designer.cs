namespace Apresentacao
{
    partial class frmServico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtribuirUAUCOMP = new System.Windows.Forms.Button();
            this.edtFiltro = new System.Windows.Forms.TextBox();
            this.btnAtribuirItem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImportarComposicoes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdServico = new Apresentacao.NDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAtribuirUAUCOMP);
            this.panel1.Controls.Add(this.edtFiltro);
            this.panel1.Controls.Add(this.btnAtribuirItem);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnImportarComposicoes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 58);
            this.panel1.TabIndex = 0;
            // 
            // btnAtribuirUAUCOMP
            // 
            this.btnAtribuirUAUCOMP.Location = new System.Drawing.Point(12, 8);
            this.btnAtribuirUAUCOMP.Name = "btnAtribuirUAUCOMP";
            this.btnAtribuirUAUCOMP.Size = new System.Drawing.Size(144, 24);
            this.btnAtribuirUAUCOMP.TabIndex = 4;
            this.btnAtribuirUAUCOMP.Text = "Atribuir UAU_COMP";
            this.btnAtribuirUAUCOMP.UseVisualStyleBackColor = true;
            this.btnAtribuirUAUCOMP.Click += new System.EventHandler(this.btnAtribuirUAUCOMP_Click);
            // 
            // edtFiltro
            // 
            this.edtFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFiltro.Location = new System.Drawing.Point(0, 38);
            this.edtFiltro.Name = "edtFiltro";
            this.edtFiltro.Size = new System.Drawing.Size(931, 20);
            this.edtFiltro.TabIndex = 3;
            this.edtFiltro.TextChanged += new System.EventHandler(this.edtFiltro_TextChanged);
            // 
            // btnAtribuirItem
            // 
            this.btnAtribuirItem.Location = new System.Drawing.Point(162, 8);
            this.btnAtribuirItem.Name = "btnAtribuirItem";
            this.btnAtribuirItem.Size = new System.Drawing.Size(88, 24);
            this.btnAtribuirItem.TabIndex = 2;
            this.btnAtribuirItem.Text = "Atribuir item";
            this.btnAtribuirItem.UseVisualStyleBackColor = true;
            this.btnAtribuirItem.Click += new System.EventHandler(this.btnAtribuirItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Importar itemização";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImportarComposicoes
            // 
            this.btnImportarComposicoes.Location = new System.Drawing.Point(524, 3);
            this.btnImportarComposicoes.Name = "btnImportarComposicoes";
            this.btnImportarComposicoes.Size = new System.Drawing.Size(117, 23);
            this.btnImportarComposicoes.TabIndex = 0;
            this.btnImportarComposicoes.Text = "Importar serviços";
            this.btnImportarComposicoes.UseVisualStyleBackColor = true;
            this.btnImportarComposicoes.Click += new System.EventHandler(this.btnImportarComposicoes_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdServico);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 398);
            this.panel2.TabIndex = 1;
            // 
            // grdServico
            // 
            this.grdServico.AllowUserToAddRows = false;
            this.grdServico.AllowUserToDeleteRows = false;
            this.grdServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdServico.Location = new System.Drawing.Point(0, 0);
            this.grdServico.Name = "grdServico";
            this.grdServico.PermitirFullSelect = false;
            this.grdServico.Size = new System.Drawing.Size(931, 398);
            this.grdServico.TabIndex = 0;
            this.grdServico.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.nDataGridView1_CellValueChanged);
            this.grdServico.DoubleClick += new System.EventHandler(this.nDataGridView1_DoubleClick);
            // 
            // frmServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmServico";
            this.Text = "frmServico";
            this.Load += new System.EventHandler(this.frmServico_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdServico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImportarComposicoes;
        private System.Windows.Forms.Panel panel2;
        private NDataGridView grdServico;
        private System.Windows.Forms.Button btnAtribuirItem;
        private System.Windows.Forms.TextBox edtFiltro;
        private System.Windows.Forms.Button btnAtribuirUAUCOMP;
    }
}