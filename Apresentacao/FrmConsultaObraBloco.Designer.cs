namespace Apresentacao
{
    partial class FrmConsultaObraBloco
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
            this.grpBoxObra = new System.Windows.Forms.GroupBox();
            this.grpBoxBloco = new System.Windows.Forms.GroupBox();
            this.grdBloco = new Apresentacao.NDataGridView();
            this.grdObra = new Apresentacao.NDataGridView();
            this.registrarModelo = new System.Windows.Forms.DataGridViewImageColumn();
            this.grpBoxObra.SuspendLayout();
            this.grpBoxBloco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBloco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxObra
            // 
            this.grpBoxObra.Controls.Add(this.grdObra);
            this.grpBoxObra.Location = new System.Drawing.Point(4, 4);
            this.grpBoxObra.Name = "grpBoxObra";
            this.grpBoxObra.Size = new System.Drawing.Size(1235, 467);
            this.grpBoxObra.TabIndex = 0;
            this.grpBoxObra.TabStop = false;
            this.grpBoxObra.Text = "Obras";
            // 
            // grpBoxBloco
            // 
            this.grpBoxBloco.Controls.Add(this.grdBloco);
            this.grpBoxBloco.Location = new System.Drawing.Point(4, 477);
            this.grpBoxBloco.Name = "grpBoxBloco";
            this.grpBoxBloco.Size = new System.Drawing.Size(1235, 219);
            this.grpBoxBloco.TabIndex = 1;
            this.grpBoxBloco.TabStop = false;
            this.grpBoxBloco.Text = "Blocos";
            // 
            // grdBloco
            // 
            this.grdBloco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBloco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBloco.Location = new System.Drawing.Point(3, 18);
            this.grdBloco.Name = "grdBloco";
            this.grdBloco.PermitirFullSelect = false;
            this.grdBloco.RowTemplate.Height = 24;
            this.grdBloco.Size = new System.Drawing.Size(1229, 198);
            this.grdBloco.TabIndex = 2;
            // 
            // grdObra
            // 
            this.grdObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registrarModelo});
            this.grdObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdObra.Location = new System.Drawing.Point(3, 18);
            this.grdObra.Margin = new System.Windows.Forms.Padding(4);
            this.grdObra.Name = "grdObra";
            this.grdObra.PermitirFullSelect = false;
            this.grdObra.RowTemplate.Height = 24;
            this.grdObra.Size = new System.Drawing.Size(1229, 446);
            this.grdObra.TabIndex = 1;
            // 
            // registrarModelo
            // 
            this.registrarModelo.HeaderText = "";
            //this.registrarModelo.Image = global::Apresentacao.Properties.Resources.images;
            this.registrarModelo.Name = "registrarModelo";
            this.registrarModelo.ToolTipText = "Registrar Modelo";
            // 
            // FrmConsultaObraBloco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 708);
            this.Controls.Add(this.grpBoxBloco);
            this.Controls.Add(this.grpBoxObra);
            this.Name = "FrmConsultaObraBloco";
            this.Text = "Consultar Obra";
            this.grpBoxObra.ResumeLayout(false);
            this.grpBoxBloco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBloco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxObra;
        private System.Windows.Forms.GroupBox grpBoxBloco;
        private NDataGridView grdObra;
        private NDataGridView grdBloco;
        private System.Windows.Forms.DataGridViewImageColumn registrarModelo;
    }
}