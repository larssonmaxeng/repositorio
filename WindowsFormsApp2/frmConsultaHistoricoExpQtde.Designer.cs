namespace WindowsFormsApp2
{
    partial class frmConsultaHistoricoExpQtde
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
            this.grpUltimaVersao = new System.Windows.Forms.GroupBox();
            this.btnInsumosUltVersao = new System.Windows.Forms.Button();
            this.edtFiltroUltimaVersao = new System.Windows.Forms.TextBox();
            this.grdUltimaVersao = new System.Windows.Forms.DataGridView();
            this.grpVersoesAnteriores = new System.Windows.Forms.GroupBox();
            this.btnInsumosVersoesAnt = new System.Windows.Forms.Button();
            this.edtFiltroVersoesAnteriores = new System.Windows.Forms.TextBox();
            this.grdVersoesAnteriores = new System.Windows.Forms.DataGridView();
            this.grpUltimaVersao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltimaVersao)).BeginInit();
            this.grpVersoesAnteriores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVersoesAnteriores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpUltimaVersao
            // 
            this.grpUltimaVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUltimaVersao.Controls.Add(this.btnInsumosUltVersao);
            this.grpUltimaVersao.Controls.Add(this.edtFiltroUltimaVersao);
            this.grpUltimaVersao.Controls.Add(this.grdUltimaVersao);
            this.grpUltimaVersao.Location = new System.Drawing.Point(11, 13);
            this.grpUltimaVersao.Name = "grpUltimaVersao";
            this.grpUltimaVersao.Size = new System.Drawing.Size(1004, 266);
            this.grpUltimaVersao.TabIndex = 0;
            this.grpUltimaVersao.TabStop = false;
            this.grpUltimaVersao.Text = "Última Versão";
            // 
            // btnInsumosUltVersao
            // 
            this.btnInsumosUltVersao.Location = new System.Drawing.Point(904, 16);
            this.btnInsumosUltVersao.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsumosUltVersao.Name = "btnInsumosUltVersao";
            this.btnInsumosUltVersao.Size = new System.Drawing.Size(93, 28);
            this.btnInsumosUltVersao.TabIndex = 12;
            this.btnInsumosUltVersao.Text = "Insumos";
            this.btnInsumosUltVersao.UseVisualStyleBackColor = true;
            this.btnInsumosUltVersao.Click += new System.EventHandler(this.btnInsumosUltVersao_Click);
            // 
            // edtFiltroUltimaVersao
            // 
            this.edtFiltroUltimaVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFiltroUltimaVersao.Location = new System.Drawing.Point(3, 22);
            this.edtFiltroUltimaVersao.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroUltimaVersao.Name = "edtFiltroUltimaVersao";
            this.edtFiltroUltimaVersao.Size = new System.Drawing.Size(896, 22);
            this.edtFiltroUltimaVersao.TabIndex = 11;
            this.edtFiltroUltimaVersao.TextChanged += new System.EventHandler(this.edtFiltroUltimaVersao_TextChanged);
            // 
            // grdUltimaVersao
            // 
            this.grdUltimaVersao.AllowUserToAddRows = false;
            this.grdUltimaVersao.AllowUserToDeleteRows = false;
            this.grdUltimaVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUltimaVersao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUltimaVersao.Location = new System.Drawing.Point(3, 47);
            this.grdUltimaVersao.Margin = new System.Windows.Forms.Padding(4);
            this.grdUltimaVersao.Name = "grdUltimaVersao";
            this.grdUltimaVersao.ReadOnly = true;
            this.grdUltimaVersao.Size = new System.Drawing.Size(998, 216);
            this.grdUltimaVersao.TabIndex = 10;
            // 
            // grpVersoesAnteriores
            // 
            this.grpVersoesAnteriores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVersoesAnteriores.Controls.Add(this.btnInsumosVersoesAnt);
            this.grpVersoesAnteriores.Controls.Add(this.edtFiltroVersoesAnteriores);
            this.grpVersoesAnteriores.Controls.Add(this.grdVersoesAnteriores);
            this.grpVersoesAnteriores.Location = new System.Drawing.Point(12, 284);
            this.grpVersoesAnteriores.Name = "grpVersoesAnteriores";
            this.grpVersoesAnteriores.Size = new System.Drawing.Size(1004, 220);
            this.grpVersoesAnteriores.TabIndex = 1;
            this.grpVersoesAnteriores.TabStop = false;
            this.grpVersoesAnteriores.Text = "Versões Anteriores";
            // 
            // btnInsumosVersoesAnt
            // 
            this.btnInsumosVersoesAnt.Location = new System.Drawing.Point(903, 16);
            this.btnInsumosVersoesAnt.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsumosVersoesAnt.Name = "btnInsumosVersoesAnt";
            this.btnInsumosVersoesAnt.Size = new System.Drawing.Size(93, 28);
            this.btnInsumosVersoesAnt.TabIndex = 13;
            this.btnInsumosVersoesAnt.Text = "Insumos";
            this.btnInsumosVersoesAnt.UseVisualStyleBackColor = true;
            this.btnInsumosVersoesAnt.Click += new System.EventHandler(this.btnInsumosVersoesAnt_Click);
            // 
            // edtFiltroVersoesAnteriores
            // 
            this.edtFiltroVersoesAnteriores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFiltroVersoesAnteriores.Location = new System.Drawing.Point(2, 22);
            this.edtFiltroVersoesAnteriores.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroVersoesAnteriores.Name = "edtFiltroVersoesAnteriores";
            this.edtFiltroVersoesAnteriores.Size = new System.Drawing.Size(896, 22);
            this.edtFiltroVersoesAnteriores.TabIndex = 12;
            this.edtFiltroVersoesAnteriores.TextChanged += new System.EventHandler(this.edtFiltroVersoesAnteriores_TextChanged);
            // 
            // grdVersoesAnteriores
            // 
            this.grdVersoesAnteriores.AllowUserToAddRows = false;
            this.grdVersoesAnteriores.AllowUserToDeleteRows = false;
            this.grdVersoesAnteriores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVersoesAnteriores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVersoesAnteriores.Location = new System.Drawing.Point(2, 52);
            this.grdVersoesAnteriores.Margin = new System.Windows.Forms.Padding(4);
            this.grdVersoesAnteriores.Name = "grdVersoesAnteriores";
            this.grdVersoesAnteriores.ReadOnly = true;
            this.grdVersoesAnteriores.Size = new System.Drawing.Size(998, 166);
            this.grdVersoesAnteriores.TabIndex = 11;
            // 
            // frmConsultaHistoricoExpQtde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 516);
            this.Controls.Add(this.grpVersoesAnteriores);
            this.Controls.Add(this.grpUltimaVersao);
            this.Name = "frmConsultaHistoricoExpQtde";
            this.Text = "Historico Exporta Quantida";
            this.grpUltimaVersao.ResumeLayout(false);
            this.grpUltimaVersao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltimaVersao)).EndInit();
            this.grpVersoesAnteriores.ResumeLayout(false);
            this.grpVersoesAnteriores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVersoesAnteriores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUltimaVersao;
        private System.Windows.Forms.GroupBox grpVersoesAnteriores;
        private System.Windows.Forms.DataGridView grdUltimaVersao;
        private System.Windows.Forms.DataGridView grdVersoesAnteriores;
        private System.Windows.Forms.TextBox edtFiltroVersoesAnteriores;
        private System.Windows.Forms.TextBox edtFiltroUltimaVersao;
        private System.Windows.Forms.Button btnInsumosUltVersao;
        private System.Windows.Forms.Button btnInsumosVersoesAnt;
    }
}