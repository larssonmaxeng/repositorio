namespace Apresentacao
{
    partial class Vinculacao
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbVinculos = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.edtFiltroTocBIM = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnConfirmaVinculo = new System.Windows.Forms.Button();
            this.btnDesvincular = new System.Windows.Forms.Button();
            this.btnVincular = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.edtFiltroRevit = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chkTipoFamiliaAlt = new System.Windows.Forms.CheckBox();
            this.grdTocBIM = new Apresentacao.NDataGridView();
            this.grdRevit = new Apresentacao.NDataGridView();
            this.grdVinculos = new Apresentacao.NDataGridView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbVinculos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTocBIM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRevit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVinculos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 515);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1525, 201);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbVinculos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1525, 201);
            this.tabControl1.TabIndex = 0;
            // 
            // tbVinculos
            // 
            this.tbVinculos.Controls.Add(this.grdVinculos);
            this.tbVinculos.Location = new System.Drawing.Point(4, 25);
            this.tbVinculos.Margin = new System.Windows.Forms.Padding(4);
            this.tbVinculos.Name = "tbVinculos";
            this.tbVinculos.Padding = new System.Windows.Forms.Padding(4);
            this.tbVinculos.Size = new System.Drawing.Size(1517, 172);
            this.tbVinculos.TabIndex = 0;
            this.tbVinculos.Text = "Vínculos";
            this.tbVinculos.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1525, 515);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(716, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(809, 515);
            this.panel4.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdTocBIM);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(809, 515);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serviço";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.edtFiltroTocBIM);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 19);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(801, 41);
            this.panel6.TabIndex = 1;
            // 
            // edtFiltroTocBIM
            // 
            this.edtFiltroTocBIM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edtFiltroTocBIM.Location = new System.Drawing.Point(0, 19);
            this.edtFiltroTocBIM.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroTocBIM.Name = "edtFiltroTocBIM";
            this.edtFiltroTocBIM.Size = new System.Drawing.Size(801, 22);
            this.edtFiltroTocBIM.TabIndex = 1;
            this.edtFiltroTocBIM.TextChanged += new System.EventHandler(this.edtFiltroTocBIM_TextChanged);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(712, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 515);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 515);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdRevit);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(712, 515);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revit";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnConfirmaVinculo);
            this.panel7.Controls.Add(this.btnDesvincular);
            this.panel7.Controls.Add(this.btnVincular);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(616, 60);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(92, 451);
            this.panel7.TabIndex = 1;
            // 
            // btnConfirmaVinculo
            // 
            this.btnConfirmaVinculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfirmaVinculo.Location = new System.Drawing.Point(0, 56);
            this.btnConfirmaVinculo.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmaVinculo.Name = "btnConfirmaVinculo";
            this.btnConfirmaVinculo.Size = new System.Drawing.Size(92, 42);
            this.btnConfirmaVinculo.TabIndex = 3;
            this.btnConfirmaVinculo.Text = "Confirma Vínculos";
            this.btnConfirmaVinculo.UseVisualStyleBackColor = true;
            this.btnConfirmaVinculo.Click += new System.EventHandler(this.btnConfirmaVinculo_Click);
            // 
            // btnDesvincular
            // 
            this.btnDesvincular.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDesvincular.Location = new System.Drawing.Point(0, 28);
            this.btnDesvincular.Margin = new System.Windows.Forms.Padding(4);
            this.btnDesvincular.Name = "btnDesvincular";
            this.btnDesvincular.Size = new System.Drawing.Size(92, 28);
            this.btnDesvincular.TabIndex = 1;
            this.btnDesvincular.Text = "Desvincular";
            this.btnDesvincular.UseVisualStyleBackColor = true;
            this.btnDesvincular.Click += new System.EventHandler(this.btnDesvincular_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVincular.Location = new System.Drawing.Point(0, 0);
            this.btnVincular.Margin = new System.Windows.Forms.Padding(4);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(92, 28);
            this.btnVincular.TabIndex = 0;
            this.btnVincular.Text = "Vincular";
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkTipoFamiliaAlt);
            this.panel5.Controls.Add(this.edtFiltroRevit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 19);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(704, 41);
            this.panel5.TabIndex = 0;
            // 
            // edtFiltroRevit
            // 
            this.edtFiltroRevit.Location = new System.Drawing.Point(0, 19);
            this.edtFiltroRevit.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroRevit.Name = "edtFiltroRevit";
            this.edtFiltroRevit.Size = new System.Drawing.Size(612, 22);
            this.edtFiltroRevit.TabIndex = 2;
            this.edtFiltroRevit.TextChanged += new System.EventHandler(this.edtFiltroRevit_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 511);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1525, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // chkTipoFamiliaAlt
            // 
            this.chkTipoFamiliaAlt.Location = new System.Drawing.Point(616, 21);
            this.chkTipoFamiliaAlt.Name = "chkTipoFamiliaAlt";
            this.chkTipoFamiliaAlt.Size = new System.Drawing.Size(89, 21);
            this.chkTipoFamiliaAlt.TabIndex = 4;
            this.chkTipoFamiliaAlt.Text = "Alterado";
            this.chkTipoFamiliaAlt.UseVisualStyleBackColor = true;
            this.chkTipoFamiliaAlt.Click += new System.EventHandler(this.chkTipoFamiliaAlt_Click);
            // 
            // grdTocBIM
            // 
            this.grdTocBIM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTocBIM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTocBIM.Location = new System.Drawing.Point(4, 60);
            this.grdTocBIM.Margin = new System.Windows.Forms.Padding(4);
            this.grdTocBIM.Name = "grdTocBIM";
            this.grdTocBIM.PermitirFullSelect = false;
            this.grdTocBIM.Size = new System.Drawing.Size(801, 451);
            this.grdTocBIM.TabIndex = 3;
            // 
            // grdRevit
            // 
            this.grdRevit.AllowUserToAddRows = false;
            this.grdRevit.AllowUserToDeleteRows = false;
            this.grdRevit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRevit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRevit.Location = new System.Drawing.Point(4, 60);
            this.grdRevit.Margin = new System.Windows.Forms.Padding(4);
            this.grdRevit.Name = "grdRevit";
            this.grdRevit.PermitirFullSelect = false;
            this.grdRevit.ReadOnly = true;
            this.grdRevit.Size = new System.Drawing.Size(612, 451);
            this.grdRevit.TabIndex = 2;
            // 
            // grdVinculos
            // 
            this.grdVinculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVinculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVinculos.Location = new System.Drawing.Point(4, 4);
            this.grdVinculos.Margin = new System.Windows.Forms.Padding(4);
            this.grdVinculos.Name = "grdVinculos";
            this.grdVinculos.PermitirFullSelect = false;
            this.grdVinculos.Size = new System.Drawing.Size(1509, 164);
            this.grdVinculos.TabIndex = 3;
            // 
            // Vinculacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 716);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Vinculacao";
            this.Text = "Vinculacao";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbVinculos.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTocBIM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRevit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVinculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private NDataGridView grdTocBIM;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private NDataGridView grdRevit;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnDesvincular;
        private System.Windows.Forms.Button btnVincular;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox edtFiltroTocBIM;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbVinculos;
        private NDataGridView grdVinculos;
        private System.Windows.Forms.Button btnConfirmaVinculo;
        private System.Windows.Forms.TextBox edtFiltroRevit;
        private System.Windows.Forms.CheckBox chkTipoFamiliaAlt;
    }
}