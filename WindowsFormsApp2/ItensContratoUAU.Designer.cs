namespace WindowsFormsApp2
{
    partial class ItensContratoUAU
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
            this.grdItensContratouUAU = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdItensContratouUAU)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 39);
            this.panel1.TabIndex = 0;
            // 
            // grdItensContratouUAU
            // 
            this.grdItensContratouUAU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItensContratouUAU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItensContratouUAU.Location = new System.Drawing.Point(0, 39);
            this.grdItensContratouUAU.Name = "grdItensContratouUAU";
            this.grdItensContratouUAU.Size = new System.Drawing.Size(712, 208);
            this.grdItensContratouUAU.TabIndex = 1;
            // 
            // ItensContratoUAU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 247);
            this.Controls.Add(this.grdItensContratouUAU);
            this.Controls.Add(this.panel1);
            this.Name = "ItensContratoUAU";
            this.Text = "ItensContratoUAU";
            ((System.ComponentModel.ISupportInitialize)(this.grdItensContratouUAU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdItensContratouUAU;
    }
}