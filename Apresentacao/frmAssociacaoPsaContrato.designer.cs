namespace WindowsFormsApp2
{
    partial class frmAssociacaoPsaContrato
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
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.grbBotoes = new System.Windows.Forms.GroupBox();
            this.btnAtualizaAcompMed = new System.Windows.Forms.Button();
            this.btnAtualizaContratoIC = new System.Windows.Forms.Button();
            this.btnExcluirAcompContrato = new System.Windows.Forms.Button();
            this.grbAssociados = new System.Windows.Forms.GroupBox();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.grbPeriodo = new System.Windows.Forms.GroupBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.grbArvorePorServico = new System.Windows.Forms.GroupBox();
            this.trvPorServico = new System.Windows.Forms.TreeView();
            this.grbPsa = new System.Windows.Forms.GroupBox();
            this.grdPsa = new System.Windows.Forms.DataGridView();
            this.edtFiltroPsa = new System.Windows.Forms.TextBox();
            this.grbContrato = new System.Windows.Forms.GroupBox();
            this.edtFiltroContrato = new System.Windows.Forms.TextBox();
            this.grdContrato = new System.Windows.Forms.DataGridView();
            this.grbAssociacao = new System.Windows.Forms.GroupBox();
            this.btnAssociarContrato = new System.Windows.Forms.Button();
            this.grbFiltros.SuspendLayout();
            this.grbBotoes.SuspendLayout();
            this.grbAssociados.SuspendLayout();
            this.grbPeriodo.SuspendLayout();
            this.grbArvorePorServico.SuspendLayout();
            this.grbPsa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsa)).BeginInit();
            this.grbContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContrato)).BeginInit();
            this.grbAssociacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbFiltros
            // 
            this.grbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFiltros.Controls.Add(this.grbAssociacao);
            this.grbFiltros.Controls.Add(this.grbBotoes);
            this.grbFiltros.Controls.Add(this.grbAssociados);
            this.grbFiltros.Controls.Add(this.grbPeriodo);
            this.grbFiltros.Location = new System.Drawing.Point(7, 3);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(1417, 72);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            // 
            // grbBotoes
            // 
            this.grbBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBotoes.Controls.Add(this.btnAtualizaAcompMed);
            this.grbBotoes.Controls.Add(this.btnAtualizaContratoIC);
            this.grbBotoes.Controls.Add(this.btnExcluirAcompContrato);
            this.grbBotoes.Location = new System.Drawing.Point(299, 9);
            this.grbBotoes.Name = "grbBotoes";
            this.grbBotoes.Size = new System.Drawing.Size(441, 55);
            this.grbBotoes.TabIndex = 9;
            this.grbBotoes.TabStop = false;
            this.grbBotoes.Text = "Ação";
            // 
            // btnAtualizaAcompMed
            // 
            this.btnAtualizaAcompMed.Location = new System.Drawing.Point(7, 19);
            this.btnAtualizaAcompMed.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizaAcompMed.Name = "btnAtualizaAcompMed";
            this.btnAtualizaAcompMed.Size = new System.Drawing.Size(149, 28);
            this.btnAtualizaAcompMed.TabIndex = 11;
            this.btnAtualizaAcompMed.Text = "Atu. Acomp./Medição";
            this.btnAtualizaAcompMed.UseVisualStyleBackColor = true;
            this.btnAtualizaAcompMed.Click += new System.EventHandler(this.btnAtualizaAcompMed_Click);
            // 
            // btnAtualizaContratoIC
            // 
            this.btnAtualizaContratoIC.Location = new System.Drawing.Point(310, 19);
            this.btnAtualizaContratoIC.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizaContratoIC.Name = "btnAtualizaContratoIC";
            this.btnAtualizaContratoIC.Size = new System.Drawing.Size(125, 28);
            this.btnAtualizaContratoIC.TabIndex = 10;
            this.btnAtualizaContratoIC.Text = "Atu. Contrato/IC";
            this.btnAtualizaContratoIC.UseVisualStyleBackColor = true;
            this.btnAtualizaContratoIC.Click += new System.EventHandler(this.btnAtualizaContratoIC_Click);
            // 
            // btnExcluirAcompContrato
            // 
            this.btnExcluirAcompContrato.Location = new System.Drawing.Point(156, 19);
            this.btnExcluirAcompContrato.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluirAcompContrato.Name = "btnExcluirAcompContrato";
            this.btnExcluirAcompContrato.Size = new System.Drawing.Size(153, 28);
            this.btnExcluirAcompContrato.TabIndex = 9;
            this.btnExcluirAcompContrato.Text = "Excl. Acomp./Medição";
            this.btnExcluirAcompContrato.UseVisualStyleBackColor = true;
            this.btnExcluirAcompContrato.Click += new System.EventHandler(this.btnExcluirAcompContrato_Click);
            // 
            // grbAssociados
            // 
            this.grbAssociados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbAssociados.Controls.Add(this.rdbTodos);
            this.grbAssociados.Controls.Add(this.rdbNao);
            this.grbAssociados.Controls.Add(this.rdbSim);
            this.grbAssociados.Location = new System.Drawing.Point(907, 9);
            this.grbAssociados.Name = "grbAssociados";
            this.grbAssociados.Size = new System.Drawing.Size(504, 55);
            this.grbAssociados.TabIndex = 7;
            this.grbAssociados.TabStop = false;
            this.grbAssociados.Text = "Associados";
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Location = new System.Drawing.Point(47, 24);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(69, 21);
            this.rdbTodos.TabIndex = 8;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbNao
            // 
            this.rdbNao.AutoSize = true;
            this.rdbNao.Location = new System.Drawing.Point(317, 24);
            this.rdbNao.Name = "rdbNao";
            this.rdbNao.Size = new System.Drawing.Size(55, 21);
            this.rdbNao.TabIndex = 7;
            this.rdbNao.TabStop = true;
            this.rdbNao.Text = "Não";
            this.rdbNao.UseVisualStyleBackColor = true;
            this.rdbNao.CheckedChanged += new System.EventHandler(this.rdbNao_CheckedChanged);
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Location = new System.Drawing.Point(190, 24);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(52, 21);
            this.rdbSim.TabIndex = 6;
            this.rdbSim.TabStop = true;
            this.rdbSim.Text = "Sim";
            this.rdbSim.UseVisualStyleBackColor = true;
            this.rdbSim.CheckedChanged += new System.EventHandler(this.rdbSim_CheckedChanged);
            // 
            // grbPeriodo
            // 
            this.grbPeriodo.Controls.Add(this.lblAte);
            this.grbPeriodo.Controls.Add(this.dtpDataFinal);
            this.grbPeriodo.Controls.Add(this.dtpDataInicial);
            this.grbPeriodo.Location = new System.Drawing.Point(6, 9);
            this.grbPeriodo.Name = "grbPeriodo";
            this.grbPeriodo.Size = new System.Drawing.Size(285, 55);
            this.grbPeriodo.TabIndex = 0;
            this.grbPeriodo.TabStop = false;
            this.grbPeriodo.Text = "Período";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(128, 26);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(28, 17);
            this.lblAte.TabIndex = 1;
            this.lblAte.Text = "até";
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(162, 21);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(110, 22);
            this.dtpDataFinal.TabIndex = 2;
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(12, 21);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(110, 22);
            this.dtpDataInicial.TabIndex = 1;
            // 
            // grbArvorePorServico
            // 
            this.grbArvorePorServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grbArvorePorServico.Controls.Add(this.trvPorServico);
            this.grbArvorePorServico.Location = new System.Drawing.Point(7, 77);
            this.grbArvorePorServico.Name = "grbArvorePorServico";
            this.grbArvorePorServico.Size = new System.Drawing.Size(291, 602);
            this.grbArvorePorServico.TabIndex = 1;
            this.grbArvorePorServico.TabStop = false;
            this.grbArvorePorServico.Text = "Por Serviço";
            // 
            // trvPorServico
            // 
            this.trvPorServico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvPorServico.Location = new System.Drawing.Point(6, 21);
            this.trvPorServico.Name = "trvPorServico";
            this.trvPorServico.Size = new System.Drawing.Size(279, 578);
            this.trvPorServico.TabIndex = 0;
            // 
            // grbPsa
            // 
            this.grbPsa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPsa.Controls.Add(this.grdPsa);
            this.grbPsa.Controls.Add(this.edtFiltroPsa);
            this.grbPsa.Location = new System.Drawing.Point(306, 77);
            this.grbPsa.Name = "grbPsa";
            this.grbPsa.Size = new System.Drawing.Size(602, 602);
            this.grbPsa.TabIndex = 2;
            this.grbPsa.TabStop = false;
            this.grbPsa.Text = "Psa";
            // 
            // grdPsa
            // 
            this.grdPsa.AllowDrop = true;
            this.grdPsa.AllowUserToAddRows = false;
            this.grdPsa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPsa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsa.Location = new System.Drawing.Point(3, 42);
            this.grdPsa.Name = "grdPsa";
            this.grdPsa.ReadOnly = true;
            this.grdPsa.Size = new System.Drawing.Size(596, 557);
            this.grdPsa.TabIndex = 4;
            // 
            // edtFiltroPsa
            // 
            this.edtFiltroPsa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFiltroPsa.Location = new System.Drawing.Point(3, 18);
            this.edtFiltroPsa.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroPsa.Name = "edtFiltroPsa";
            this.edtFiltroPsa.Size = new System.Drawing.Size(596, 22);
            this.edtFiltroPsa.TabIndex = 3;
            // 
            // grbContrato
            // 
            this.grbContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbContrato.Controls.Add(this.edtFiltroContrato);
            this.grbContrato.Controls.Add(this.grdContrato);
            this.grbContrato.Location = new System.Drawing.Point(914, 77);
            this.grbContrato.Name = "grbContrato";
            this.grbContrato.Size = new System.Drawing.Size(510, 602);
            this.grbContrato.TabIndex = 3;
            this.grbContrato.TabStop = false;
            this.grbContrato.Text = "Contrato/Item Contrato";
            // 
            // edtFiltroContrato
            // 
            this.edtFiltroContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtFiltroContrato.Location = new System.Drawing.Point(3, 18);
            this.edtFiltroContrato.Margin = new System.Windows.Forms.Padding(4);
            this.edtFiltroContrato.Name = "edtFiltroContrato";
            this.edtFiltroContrato.Size = new System.Drawing.Size(504, 22);
            this.edtFiltroContrato.TabIndex = 4;
            // 
            // grdContrato
            // 
            this.grdContrato.AllowDrop = true;
            this.grdContrato.AllowUserToAddRows = false;
            this.grdContrato.AllowUserToDeleteRows = false;
            this.grdContrato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContrato.Location = new System.Drawing.Point(3, 42);
            this.grdContrato.MultiSelect = false;
            this.grdContrato.Name = "grdContrato";
            this.grdContrato.ReadOnly = true;
            this.grdContrato.Size = new System.Drawing.Size(504, 557);
            this.grdContrato.TabIndex = 1;
            // 
            // grbAssociacao
            // 
            this.grbAssociacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbAssociacao.Controls.Add(this.btnAssociarContrato);
            this.grbAssociacao.Location = new System.Drawing.Point(746, 9);
            this.grbAssociacao.Name = "grbAssociacao";
            this.grbAssociacao.Size = new System.Drawing.Size(155, 55);
            this.grbAssociacao.TabIndex = 14;
            this.grbAssociacao.TabStop = false;
            this.grbAssociacao.Text = "Associação";
            // 
            // btnAssociarContrato
            // 
            this.btnAssociarContrato.Location = new System.Drawing.Point(8, 19);
            this.btnAssociarContrato.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssociarContrato.Name = "btnAssociarContrato";
            this.btnAssociarContrato.Size = new System.Drawing.Size(140, 28);
            this.btnAssociarContrato.TabIndex = 14;
            this.btnAssociarContrato.Text = "Associar Contrato";
            this.btnAssociarContrato.UseVisualStyleBackColor = true;
            this.btnAssociarContrato.Click += new System.EventHandler(this.btnAssociarContrato_Click);
            // 
            // frmAssociacaoPsaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 685);
            this.Controls.Add(this.grbContrato);
            this.Controls.Add(this.grbPsa);
            this.Controls.Add(this.grbArvorePorServico);
            this.Controls.Add(this.grbFiltros);
            this.Name = "frmAssociacaoPsaContrato";
            this.Text = "Associação de Psa com Contrato";
            this.grbFiltros.ResumeLayout(false);
            this.grbBotoes.ResumeLayout(false);
            this.grbAssociados.ResumeLayout(false);
            this.grbAssociados.PerformLayout();
            this.grbPeriodo.ResumeLayout(false);
            this.grbPeriodo.PerformLayout();
            this.grbArvorePorServico.ResumeLayout(false);
            this.grbPsa.ResumeLayout(false);
            this.grbPsa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsa)).EndInit();
            this.grbContrato.ResumeLayout(false);
            this.grbContrato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContrato)).EndInit();
            this.grbAssociacao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbFiltros;
        private System.Windows.Forms.GroupBox grbPeriodo;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.GroupBox grbArvorePorServico;
        private System.Windows.Forms.GroupBox grbPsa;
        private System.Windows.Forms.GroupBox grbContrato;
        private System.Windows.Forms.TreeView trvPorServico;
        private System.Windows.Forms.DataGridView grdContrato;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.GroupBox grbAssociados;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.DataGridView grdPsa;
        private System.Windows.Forms.TextBox edtFiltroPsa;
        private System.Windows.Forms.GroupBox grbBotoes;
        private System.Windows.Forms.Button btnAtualizaAcompMed;
        private System.Windows.Forms.Button btnAtualizaContratoIC;
        private System.Windows.Forms.Button btnExcluirAcompContrato;
        private System.Windows.Forms.TextBox edtFiltroContrato;
        private System.Windows.Forms.GroupBox grbAssociacao;
        private System.Windows.Forms.Button btnAssociarContrato;
    }
}