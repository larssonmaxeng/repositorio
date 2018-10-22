namespace WindowsFormsApp2
{
    partial class frmConsultaHistExpQtdeInsumo
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
            this.grdInsumos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdInsumos
            // 
            this.grdInsumos.AllowUserToAddRows = false;
            this.grdInsumos.AllowUserToDeleteRows = false;
            this.grdInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInsumos.Location = new System.Drawing.Point(0, 0);
            this.grdInsumos.Margin = new System.Windows.Forms.Padding(4);
            this.grdInsumos.Name = "grdInsumos";
            this.grdInsumos.ReadOnly = true;
            this.grdInsumos.Size = new System.Drawing.Size(512, 248);
            this.grdInsumos.TabIndex = 12;
            // 
            // frmConsultaHistExpQtdeInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 248);
            this.Controls.Add(this.grdInsumos);
            this.Name = "frmConsultaHistExpQtdeInsumo";
            this.Text = "Histórico Insumos";
            ((System.ComponentModel.ISupportInitialize)(this.grdInsumos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdInsumos;
    }
}