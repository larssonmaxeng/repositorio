namespace Apresentacao
{
    partial class frmSelComposicaoAvancar
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabComp = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdConjuntoComp = new Apresentacao.NDataGridView();
            this.edtFiltro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.dtDiaRealizado = new System.Windows.Forms.DateTimePicker();
            this.lblDiaRealizado = new System.Windows.Forms.Label();
            this.grpBoxProgresso = new System.Windows.Forms.GroupBox();
            this.pgc = new System.Windows.Forms.ProgressBar();
            this.tabReultados = new System.Windows.Forms.TabPage();
            this.grdResultadoAvanco = new System.Windows.Forms.DataGridView();
            this.tabErros = new System.Windows.Forms.TabPage();
            this.grdErro = new System.Windows.Forms.DataGridView();
            this.tabTeste = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.objectList = new BrightIdeasSoftware.ObjectListView();
            this.btnAssociacaoContrato = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabComp.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConjuntoComp)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBoxProgresso.SuspendLayout();
            this.tabReultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultadoAvanco)).BeginInit();
            this.tabErros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdErro)).BeginInit();
            this.tabTeste.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabComp);
            this.tabControl.Controls.Add(this.tabReultados);
            this.tabControl.Controls.Add(this.tabErros);
            this.tabControl.Controls.Add(this.tabTeste);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(924, 510);
            this.tabControl.TabIndex = 0;
            // 
            // tabComp
            // 
            this.tabComp.Controls.Add(this.panel2);
            this.tabComp.Controls.Add(this.panel1);
            this.tabComp.Controls.Add(this.grpBoxProgresso);
            this.tabComp.Location = new System.Drawing.Point(4, 25);
            this.tabComp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabComp.Name = "tabComp";
            this.tabComp.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabComp.Size = new System.Drawing.Size(916, 481);
            this.tabComp.TabIndex = 0;
            this.tabComp.Text = "Grupo/Composições";
            this.tabComp.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdConjuntoComp);
            this.panel2.Controls.Add(this.edtFiltro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 424);
            this.panel2.TabIndex = 13;
            // 
            // grdConjuntoComp
            // 
            this.grdConjuntoComp.AllowUserToAddRows = false;
            this.grdConjuntoComp.AllowUserToDeleteRows = false;
            this.grdConjuntoComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConjuntoComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConjuntoComp.Location = new System.Drawing.Point(0, 22);
            this.grdConjuntoComp.Margin = new System.Windows.Forms.Padding(4);
            this.grdConjuntoComp.Name = "grdConjuntoComp";
            this.grdConjuntoComp.PermitirFullSelect = false;
            this.grdConjuntoComp.Size = new System.Drawing.Size(910, 402);
            this.grdConjuntoComp.TabIndex = 7;
            // 
            // edtFiltro
            // 
            this.edtFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtFiltro.Location = new System.Drawing.Point(0, 0);
            this.edtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltro.Name = "edtFiltro";
            this.edtFiltro.Size = new System.Drawing.Size(910, 22);
            this.edtFiltro.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 53);
            this.panel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAssociacaoContrato);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAvancar);
            this.groupBox1.Controls.Add(this.dtDiaRealizado);
            this.groupBox1.Controls.Add(this.lblDiaRealizado);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(910, 53);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Atualizar contratos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(324, 18);
            this.btnAvancar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(100, 28);
            this.btnAvancar.TabIndex = 12;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // dtDiaRealizado
            // 
            this.dtDiaRealizado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDiaRealizado.Location = new System.Drawing.Point(103, 21);
            this.dtDiaRealizado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDiaRealizado.Name = "dtDiaRealizado";
            this.dtDiaRealizado.Size = new System.Drawing.Size(109, 22);
            this.dtDiaRealizado.TabIndex = 11;
            // 
            // lblDiaRealizado
            // 
            this.lblDiaRealizado.AutoSize = true;
            this.lblDiaRealizado.Location = new System.Drawing.Point(5, 23);
            this.lblDiaRealizado.Name = "lblDiaRealizado";
            this.lblDiaRealizado.Size = new System.Drawing.Size(100, 17);
            this.lblDiaRealizado.TabIndex = 10;
            this.lblDiaRealizado.Text = "Dia Realizado:";
            // 
            // grpBoxProgresso
            // 
            this.grpBoxProgresso.Controls.Add(this.pgc);
            this.grpBoxProgresso.Location = new System.Drawing.Point(5, 604);
            this.grpBoxProgresso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxProgresso.Name = "grpBoxProgresso";
            this.grpBoxProgresso.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxProgresso.Size = new System.Drawing.Size(827, 48);
            this.grpBoxProgresso.TabIndex = 11;
            this.grpBoxProgresso.TabStop = false;
            // 
            // pgc
            // 
            this.pgc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgc.Location = new System.Drawing.Point(3, 10);
            this.pgc.Margin = new System.Windows.Forms.Padding(4);
            this.pgc.Name = "pgc";
            this.pgc.Size = new System.Drawing.Size(821, 36);
            this.pgc.TabIndex = 14;
            // 
            // tabReultados
            // 
            this.tabReultados.Controls.Add(this.grdResultadoAvanco);
            this.tabReultados.Location = new System.Drawing.Point(4, 25);
            this.tabReultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabReultados.Name = "tabReultados";
            this.tabReultados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabReultados.Size = new System.Drawing.Size(916, 481);
            this.tabReultados.TabIndex = 1;
            this.tabReultados.Text = "Resultados";
            this.tabReultados.UseVisualStyleBackColor = true;
            // 
            // grdResultadoAvanco
            // 
            this.grdResultadoAvanco.AllowUserToAddRows = false;
            this.grdResultadoAvanco.AllowUserToDeleteRows = false;
            this.grdResultadoAvanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultadoAvanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResultadoAvanco.Location = new System.Drawing.Point(3, 2);
            this.grdResultadoAvanco.Margin = new System.Windows.Forms.Padding(4);
            this.grdResultadoAvanco.Name = "grdResultadoAvanco";
            this.grdResultadoAvanco.ReadOnly = true;
            this.grdResultadoAvanco.Size = new System.Drawing.Size(910, 477);
            this.grdResultadoAvanco.TabIndex = 2;
            // 
            // tabErros
            // 
            this.tabErros.Controls.Add(this.grdErro);
            this.tabErros.Location = new System.Drawing.Point(4, 25);
            this.tabErros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErros.Name = "tabErros";
            this.tabErros.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErros.Size = new System.Drawing.Size(916, 481);
            this.tabErros.TabIndex = 2;
            this.tabErros.Text = "Erros";
            this.tabErros.UseVisualStyleBackColor = true;
            // 
            // grdErro
            // 
            this.grdErro.AllowUserToAddRows = false;
            this.grdErro.AllowUserToDeleteRows = false;
            this.grdErro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdErro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdErro.Location = new System.Drawing.Point(3, 2);
            this.grdErro.Margin = new System.Windows.Forms.Padding(4);
            this.grdErro.Name = "grdErro";
            this.grdErro.ReadOnly = true;
            this.grdErro.Size = new System.Drawing.Size(910, 477);
            this.grdErro.TabIndex = 3;
            // 
            // tabTeste
            // 
            this.tabTeste.Controls.Add(this.groupBox2);
            this.tabTeste.Controls.Add(this.objectList);
            this.tabTeste.Location = new System.Drawing.Point(4, 25);
            this.tabTeste.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTeste.Name = "tabTeste";
            this.tabTeste.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTeste.Size = new System.Drawing.Size(916, 481);
            this.tabTeste.TabIndex = 4;
            this.tabTeste.Text = "Teste";
            this.tabTeste.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(910, 53);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 17);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Atualizar contratos";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(432, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(324, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "Avançar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(109, 22);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dia Realizado:";
            // 
            // objectList
            // 
            this.objectList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectList.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectList.GridLines = true;
            this.objectList.Location = new System.Drawing.Point(3, 58);
            this.objectList.Name = "objectList";
            this.objectList.Size = new System.Drawing.Size(910, 420);
            this.objectList.TabIndex = 5;
            this.objectList.UseCompatibleStateImageBehavior = false;
            this.objectList.View = System.Windows.Forms.View.Details;
            // 
            // btnAssociacaoContrato
            // 
            this.btnAssociacaoContrato.Location = new System.Drawing.Point(725, 17);
            this.btnAssociacaoContrato.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssociacaoContrato.Name = "btnAssociacaoContrato";
            this.btnAssociacaoContrato.Size = new System.Drawing.Size(175, 28);
            this.btnAssociacaoContrato.TabIndex = 15;
            this.btnAssociacaoContrato.Text = "Associação Contrato";
            this.btnAssociacaoContrato.UseVisualStyleBackColor = true;
            this.btnAssociacaoContrato.Click += new System.EventHandler(this.btnAssociacaoContrato_Click);
            // 
            // frmSelComposicaoAvancar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 510);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSelComposicaoAvancar";
            this.Text = "frmSelComposicaoAvancar";
            this.tabControl.ResumeLayout(false);
            this.tabComp.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConjuntoComp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxProgresso.ResumeLayout(false);
            this.tabReultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultadoAvanco)).EndInit();
            this.tabErros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdErro)).EndInit();
            this.tabTeste.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabComp;
        private System.Windows.Forms.TabPage tabReultados;
        private System.Windows.Forms.GroupBox grpBoxProgresso;
        private System.Windows.Forms.ProgressBar pgc;
        private System.Windows.Forms.DataGridView grdResultadoAvanco;
        private System.Windows.Forms.TabPage tabErros;
        private System.Windows.Forms.DataGridView grdErro;
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.TextBox edtFiltro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.DateTimePicker dtDiaRealizado;
        private System.Windows.Forms.Label lblDiaRealizado;
        private System.Windows.Forms.Button button1;
        private NDataGridView grdConjuntoComp;
        private System.Windows.Forms.TabPage tabTeste;
        private BrightIdeasSoftware.ObjectListView objectList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAssociacaoContrato;
    }
}