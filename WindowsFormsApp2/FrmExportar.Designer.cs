namespace WindowsFormsApp2
{
    partial class FrmExportar
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabAcompanhaContrato = new System.Windows.Forms.TabControl();
            this.tabAvanco = new System.Windows.Forms.TabPage();
            this.dtgExportaAvanco = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnObraAvanco = new System.Windows.Forms.Button();
            this.btnExportarAvanco = new System.Windows.Forms.Button();
            this.tabAcomContrato = new System.Windows.Forms.TabPage();
            this.grdAcompanhaContrato = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnObra = new System.Windows.Forms.Button();
            this.btnAcompanhaContrato = new System.Windows.Forms.Button();
            this.tabAtualizaObra = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtualizaObra = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabDadosContrato = new System.Windows.Forms.TabPage();
            this.grdContrato = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbTabelas = new System.Windows.Forms.ComboBox();
            this.btnImportarDadosContrato = new System.Windows.Forms.Button();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnsalvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMedicaoBloco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBloco = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdgPavGrupoServ = new System.Windows.Forms.RadioButton();
            this.rdgGrupoServPav = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdBaselineNao = new System.Windows.Forms.RadioButton();
            this.rdBaselineSim = new System.Windows.Forms.RadioButton();
            this.btnExportarProject = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdTodasNao = new System.Windows.Forms.RadioButton();
            this.rdTodasSim = new System.Windows.Forms.RadioButton();
            this.btnImportarProject = new System.Windows.Forms.Button();
            this.pgr = new System.Windows.Forms.ProgressBar();
            this.tabAtualizaOrcamento = new System.Windows.Forms.TabPage();
            this.grpInsumos = new System.Windows.Forms.GroupBox();
            this.grdInsumos = new System.Windows.Forms.DataGridView();
            this.grdExportaQtde = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblVersao = new System.Windows.Forms.Label();
            this.cbxVersao = new System.Windows.Forms.ComboBox();
            this.btnConsultarHistorico = new System.Windows.Forms.Button();
            this.btnExportaQtde = new System.Windows.Forms.Button();
            this.btnConultarExportaQtde = new System.Windows.Forms.Button();
            this.tabAcompanhaContrato.SuspendLayout();
            this.tabAvanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExportaAvanco)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabAcomContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAcompanhaContrato)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabAtualizaObra.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabDadosContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContrato)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabAtualizaOrcamento.SuspendLayout();
            this.grpInsumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsumos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExportaQtde)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAcompanhaContrato
            // 
            this.tabAcompanhaContrato.Controls.Add(this.tabAvanco);
            this.tabAcompanhaContrato.Controls.Add(this.tabAcomContrato);
            this.tabAcompanhaContrato.Controls.Add(this.tabAtualizaObra);
            this.tabAcompanhaContrato.Controls.Add(this.tabDadosContrato);
            this.tabAcompanhaContrato.Controls.Add(this.tabProject);
            this.tabAcompanhaContrato.Controls.Add(this.tabAtualizaOrcamento);
            this.tabAcompanhaContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAcompanhaContrato.Location = new System.Drawing.Point(0, 0);
            this.tabAcompanhaContrato.Margin = new System.Windows.Forms.Padding(4);
            this.tabAcompanhaContrato.Name = "tabAcompanhaContrato";
            this.tabAcompanhaContrato.SelectedIndex = 0;
            this.tabAcompanhaContrato.Size = new System.Drawing.Size(1111, 523);
            this.tabAcompanhaContrato.TabIndex = 7;
            // 
            // tabAvanco
            // 
            this.tabAvanco.Controls.Add(this.dtgExportaAvanco);
            this.tabAvanco.Controls.Add(this.panel3);
            this.tabAvanco.Location = new System.Drawing.Point(4, 25);
            this.tabAvanco.Margin = new System.Windows.Forms.Padding(4);
            this.tabAvanco.Name = "tabAvanco";
            this.tabAvanco.Padding = new System.Windows.Forms.Padding(4);
            this.tabAvanco.Size = new System.Drawing.Size(1103, 494);
            this.tabAvanco.TabIndex = 2;
            this.tabAvanco.Text = "Exporta Avanço";
            this.tabAvanco.UseVisualStyleBackColor = true;
            // 
            // dtgExportaAvanco
            // 
            this.dtgExportaAvanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExportaAvanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgExportaAvanco.Location = new System.Drawing.Point(4, 57);
            this.dtgExportaAvanco.Margin = new System.Windows.Forms.Padding(4);
            this.dtgExportaAvanco.Name = "dtgExportaAvanco";
            this.dtgExportaAvanco.Size = new System.Drawing.Size(1095, 433);
            this.dtgExportaAvanco.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnObraAvanco);
            this.panel3.Controls.Add(this.btnExportarAvanco);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1095, 53);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 17);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(349, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Exportar avanço p/ planejamento";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnObraAvanco
            // 
            this.btnObraAvanco.Enabled = false;
            this.btnObraAvanco.Location = new System.Drawing.Point(4, 17);
            this.btnObraAvanco.Margin = new System.Windows.Forms.Padding(4);
            this.btnObraAvanco.Name = "btnObraAvanco";
            this.btnObraAvanco.Size = new System.Drawing.Size(107, 28);
            this.btnObraAvanco.TabIndex = 13;
            this.btnObraAvanco.Text = "Obra";
            this.btnObraAvanco.UseVisualStyleBackColor = true;
            this.btnObraAvanco.Click += new System.EventHandler(this.btnObraAvanco_Click);
            // 
            // btnExportarAvanco
            // 
            this.btnExportarAvanco.Location = new System.Drawing.Point(119, 17);
            this.btnExportarAvanco.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarAvanco.Name = "btnExportarAvanco";
            this.btnExportarAvanco.Size = new System.Drawing.Size(128, 28);
            this.btnExportarAvanco.TabIndex = 7;
            this.btnExportarAvanco.Text = "Exportar avanço";
            this.btnExportarAvanco.UseVisualStyleBackColor = true;
            this.btnExportarAvanco.Click += new System.EventHandler(this.btnExportarAvanco_Click);
            // 
            // tabAcomContrato
            // 
            this.tabAcomContrato.Controls.Add(this.grdAcompanhaContrato);
            this.tabAcomContrato.Controls.Add(this.panel4);
            this.tabAcomContrato.Location = new System.Drawing.Point(4, 25);
            this.tabAcomContrato.Margin = new System.Windows.Forms.Padding(4);
            this.tabAcomContrato.Name = "tabAcomContrato";
            this.tabAcomContrato.Padding = new System.Windows.Forms.Padding(4);
            this.tabAcomContrato.Size = new System.Drawing.Size(1103, 494);
            this.tabAcomContrato.TabIndex = 3;
            this.tabAcomContrato.Text = "Acompanha Contrato";
            this.tabAcomContrato.UseVisualStyleBackColor = true;
            // 
            // grdAcompanhaContrato
            // 
            this.grdAcompanhaContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAcompanhaContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAcompanhaContrato.Location = new System.Drawing.Point(4, 57);
            this.grdAcompanhaContrato.Margin = new System.Windows.Forms.Padding(4);
            this.grdAcompanhaContrato.Name = "grdAcompanhaContrato";
            this.grdAcompanhaContrato.Size = new System.Drawing.Size(1095, 433);
            this.grdAcompanhaContrato.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnObra);
            this.panel4.Controls.Add(this.btnAcompanhaContrato);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1095, 53);
            this.panel4.TabIndex = 3;
            // 
            // btnObra
            // 
            this.btnObra.Enabled = false;
            this.btnObra.Location = new System.Drawing.Point(7, 17);
            this.btnObra.Margin = new System.Windows.Forms.Padding(4);
            this.btnObra.Name = "btnObra";
            this.btnObra.Size = new System.Drawing.Size(123, 28);
            this.btnObra.TabIndex = 12;
            this.btnObra.Text = "Obra";
            this.btnObra.UseVisualStyleBackColor = true;
            this.btnObra.Click += new System.EventHandler(this.btnObra_Click);
            // 
            // btnAcompanhaContrato
            // 
            this.btnAcompanhaContrato.Location = new System.Drawing.Point(137, 17);
            this.btnAcompanhaContrato.Margin = new System.Windows.Forms.Padding(4);
            this.btnAcompanhaContrato.Name = "btnAcompanhaContrato";
            this.btnAcompanhaContrato.Size = new System.Drawing.Size(173, 28);
            this.btnAcompanhaContrato.TabIndex = 7;
            this.btnAcompanhaContrato.Text = "Exportar";
            this.btnAcompanhaContrato.UseVisualStyleBackColor = true;
            this.btnAcompanhaContrato.Click += new System.EventHandler(this.btnAcompanhaContrato_Click);
            // 
            // tabAtualizaObra
            // 
            this.tabAtualizaObra.Controls.Add(this.panel1);
            this.tabAtualizaObra.Controls.Add(this.dataGridView1);
            this.tabAtualizaObra.Location = new System.Drawing.Point(4, 25);
            this.tabAtualizaObra.Margin = new System.Windows.Forms.Padding(4);
            this.tabAtualizaObra.Name = "tabAtualizaObra";
            this.tabAtualizaObra.Padding = new System.Windows.Forms.Padding(4);
            this.tabAtualizaObra.Size = new System.Drawing.Size(1103, 494);
            this.tabAtualizaObra.TabIndex = 0;
            this.tabAtualizaObra.Text = "Atualiza Obra";
            this.tabAtualizaObra.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAtualizaObra);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnAtualizaObra
            // 
            this.btnAtualizaObra.Location = new System.Drawing.Point(0, 7);
            this.btnAtualizaObra.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizaObra.Name = "btnAtualizaObra";
            this.btnAtualizaObra.Size = new System.Drawing.Size(93, 28);
            this.btnAtualizaObra.TabIndex = 3;
            this.btnAtualizaObra.Text = "Atualizar";
            this.btnAtualizaObra.UseVisualStyleBackColor = true;
            this.btnAtualizaObra.Click += new System.EventHandler(this.btnAtualizaObra_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1095, 486);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabDadosContrato
            // 
            this.tabDadosContrato.Controls.Add(this.grdContrato);
            this.tabDadosContrato.Controls.Add(this.panel2);
            this.tabDadosContrato.Location = new System.Drawing.Point(4, 25);
            this.tabDadosContrato.Margin = new System.Windows.Forms.Padding(4);
            this.tabDadosContrato.Name = "tabDadosContrato";
            this.tabDadosContrato.Padding = new System.Windows.Forms.Padding(4);
            this.tabDadosContrato.Size = new System.Drawing.Size(1103, 494);
            this.tabDadosContrato.TabIndex = 1;
            this.tabDadosContrato.Text = "Atualiza Contrato";
            this.tabDadosContrato.UseVisualStyleBackColor = true;
            // 
            // grdContrato
            // 
            this.grdContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContrato.Location = new System.Drawing.Point(4, 52);
            this.grdContrato.Margin = new System.Windows.Forms.Padding(4);
            this.grdContrato.Name = "grdContrato";
            this.grdContrato.Size = new System.Drawing.Size(1095, 438);
            this.grdContrato.TabIndex = 1;
            this.grdContrato.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdContrato_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbTabelas);
            this.panel2.Controls.Add(this.btnImportarDadosContrato);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1095, 48);
            this.panel2.TabIndex = 0;
            // 
            // cmbTabelas
            // 
            this.cmbTabelas.FormattingEnabled = true;
            this.cmbTabelas.Location = new System.Drawing.Point(280, 15);
            this.cmbTabelas.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTabelas.Name = "cmbTabelas";
            this.cmbTabelas.Size = new System.Drawing.Size(160, 24);
            this.cmbTabelas.TabIndex = 4;
            // 
            // btnImportarDadosContrato
            // 
            this.btnImportarDadosContrato.Location = new System.Drawing.Point(4, 12);
            this.btnImportarDadosContrato.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportarDadosContrato.Name = "btnImportarDadosContrato";
            this.btnImportarDadosContrato.Size = new System.Drawing.Size(236, 28);
            this.btnImportarDadosContrato.TabIndex = 3;
            this.btnImportarDadosContrato.Text = "Importar dados contratos";
            this.btnImportarDadosContrato.UseVisualStyleBackColor = true;
            this.btnImportarDadosContrato.Click += new System.EventHandler(this.btnImportarDadosContrato_Click_1);
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.panel6);
            this.tabProject.Controls.Add(this.panel5);
            this.tabProject.Location = new System.Drawing.Point(4, 25);
            this.tabProject.Margin = new System.Windows.Forms.Padding(4);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(4);
            this.tabProject.Size = new System.Drawing.Size(1103, 494);
            this.tabProject.TabIndex = 4;
            this.tabProject.Text = "MsProject";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnsalvar);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txtMedicaoBloco);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtServico);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtGrupo);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtBloco);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 111);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1095, 379);
            this.panel6.TabIndex = 1;
            // 
            // btnsalvar
            // 
            this.btnsalvar.Location = new System.Drawing.Point(203, 23);
            this.btnsalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnsalvar.Name = "btnsalvar";
            this.btnsalvar.Size = new System.Drawing.Size(100, 28);
            this.btnsalvar.TabIndex = 8;
            this.btnsalvar.Text = "Salvar";
            this.btnsalvar.UseVisualStyleBackColor = true;
            this.btnsalvar.Click += new System.EventHandler(this.btnsalvar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Medição bloco";
            // 
            // txtMedicaoBloco
            // 
            this.txtMedicaoBloco.Location = new System.Drawing.Point(20, 177);
            this.txtMedicaoBloco.Margin = new System.Windows.Forms.Padding(4);
            this.txtMedicaoBloco.Name = "txtMedicaoBloco";
            this.txtMedicaoBloco.Size = new System.Drawing.Size(141, 22);
            this.txtMedicaoBloco.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Serviço";
            // 
            // txtServico
            // 
            this.txtServico.Location = new System.Drawing.Point(20, 129);
            this.txtServico.Margin = new System.Windows.Forms.Padding(4);
            this.txtServico.Name = "txtServico";
            this.txtServico.Size = new System.Drawing.Size(141, 22);
            this.txtServico.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(20, 78);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(141, 22);
            this.txtGrupo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bloco";
            // 
            // txtBloco
            // 
            this.txtBloco.Location = new System.Drawing.Point(20, 31);
            this.txtBloco.Margin = new System.Windows.Forms.Padding(4);
            this.txtBloco.Name = "txtBloco";
            this.txtBloco.Size = new System.Drawing.Size(141, 22);
            this.txtBloco.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Controls.Add(this.pgr);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1095, 107);
            this.panel5.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.btnExportarProject);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.btnImportarProject);
            this.groupBox3.Location = new System.Drawing.Point(20, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1043, 74);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo de project";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdgPavGrupoServ);
            this.groupBox4.Controls.Add(this.rdgGrupoServPav);
            this.groupBox4.Location = new System.Drawing.Point(669, 17);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(317, 52);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo";
            // 
            // rdgPavGrupoServ
            // 
            this.rdgPavGrupoServ.AutoSize = true;
            this.rdgPavGrupoServ.Location = new System.Drawing.Point(159, 18);
            this.rdgPavGrupoServ.Margin = new System.Windows.Forms.Padding(4);
            this.rdgPavGrupoServ.Name = "rdgPavGrupoServ";
            this.rdgPavGrupoServ.Size = new System.Drawing.Size(148, 21);
            this.rdgPavGrupoServ.TabIndex = 1;
            this.rdgPavGrupoServ.TabStop = true;
            this.rdgPavGrupoServ.Text = "Pav->Grupo->Serv";
            this.rdgPavGrupoServ.UseVisualStyleBackColor = true;
            // 
            // rdgGrupoServPav
            // 
            this.rdgGrupoServPav.AutoSize = true;
            this.rdgGrupoServPav.Location = new System.Drawing.Point(8, 18);
            this.rdgGrupoServPav.Margin = new System.Windows.Forms.Padding(4);
            this.rdgGrupoServPav.Name = "rdgGrupoServPav";
            this.rdgGrupoServPav.Size = new System.Drawing.Size(148, 21);
            this.rdgGrupoServPav.TabIndex = 0;
            this.rdgGrupoServPav.TabStop = true;
            this.rdgGrupoServPav.Text = "Grupo->Serv->Pav";
            this.rdgGrupoServPav.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBaselineNao);
            this.groupBox2.Controls.Add(this.rdBaselineSim);
            this.groupBox2.Location = new System.Drawing.Point(504, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(137, 42);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base line ";
            // 
            // rdBaselineNao
            // 
            this.rdBaselineNao.AutoSize = true;
            this.rdBaselineNao.Location = new System.Drawing.Point(72, 21);
            this.rdBaselineNao.Margin = new System.Windows.Forms.Padding(4);
            this.rdBaselineNao.Name = "rdBaselineNao";
            this.rdBaselineNao.Size = new System.Drawing.Size(55, 21);
            this.rdBaselineNao.TabIndex = 1;
            this.rdBaselineNao.TabStop = true;
            this.rdBaselineNao.Text = "Não";
            this.rdBaselineNao.UseVisualStyleBackColor = true;
            // 
            // rdBaselineSim
            // 
            this.rdBaselineSim.AutoSize = true;
            this.rdBaselineSim.Location = new System.Drawing.Point(8, 21);
            this.rdBaselineSim.Margin = new System.Windows.Forms.Padding(4);
            this.rdBaselineSim.Name = "rdBaselineSim";
            this.rdBaselineSim.Size = new System.Drawing.Size(52, 21);
            this.rdBaselineSim.TabIndex = 0;
            this.rdBaselineSim.TabStop = true;
            this.rdBaselineSim.Text = "Sim";
            this.rdBaselineSim.UseVisualStyleBackColor = true;
            // 
            // btnExportarProject
            // 
            this.btnExportarProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarProject.Location = new System.Drawing.Point(8, 18);
            this.btnExportarProject.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarProject.Name = "btnExportarProject";
            this.btnExportarProject.Size = new System.Drawing.Size(164, 42);
            this.btnExportarProject.TabIndex = 1;
            this.btnExportarProject.Text = "Exportar project";
            this.btnExportarProject.UseVisualStyleBackColor = true;
            this.btnExportarProject.Click += new System.EventHandler(this.btnExportarProject_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdTodasNao);
            this.groupBox1.Controls.Add(this.rdTodasSim);
            this.groupBox1.Location = new System.Drawing.Point(375, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(121, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todas";
            // 
            // rdTodasNao
            // 
            this.rdTodasNao.AutoSize = true;
            this.rdTodasNao.Location = new System.Drawing.Point(61, 21);
            this.rdTodasNao.Margin = new System.Windows.Forms.Padding(4);
            this.rdTodasNao.Name = "rdTodasNao";
            this.rdTodasNao.Size = new System.Drawing.Size(55, 21);
            this.rdTodasNao.TabIndex = 1;
            this.rdTodasNao.TabStop = true;
            this.rdTodasNao.Text = "Não";
            this.rdTodasNao.UseVisualStyleBackColor = true;
            // 
            // rdTodasSim
            // 
            this.rdTodasSim.AutoSize = true;
            this.rdTodasSim.Location = new System.Drawing.Point(8, 21);
            this.rdTodasSim.Margin = new System.Windows.Forms.Padding(4);
            this.rdTodasSim.Name = "rdTodasSim";
            this.rdTodasSim.Size = new System.Drawing.Size(52, 21);
            this.rdTodasSim.TabIndex = 0;
            this.rdTodasSim.TabStop = true;
            this.rdTodasSim.Text = "Sim";
            this.rdTodasSim.UseVisualStyleBackColor = true;
            // 
            // btnImportarProject
            // 
            this.btnImportarProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarProject.Location = new System.Drawing.Point(183, 18);
            this.btnImportarProject.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportarProject.Name = "btnImportarProject";
            this.btnImportarProject.Size = new System.Drawing.Size(155, 41);
            this.btnImportarProject.TabIndex = 2;
            this.btnImportarProject.Text = "Importar project";
            this.btnImportarProject.UseVisualStyleBackColor = true;
            this.btnImportarProject.Click += new System.EventHandler(this.btnImportarProject_Click);
            // 
            // pgr
            // 
            this.pgr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgr.Location = new System.Drawing.Point(0, 79);
            this.pgr.Margin = new System.Windows.Forms.Padding(4);
            this.pgr.Name = "pgr";
            this.pgr.Size = new System.Drawing.Size(1095, 28);
            this.pgr.Step = 1;
            this.pgr.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgr.TabIndex = 5;
            // 
            // tabAtualizaOrcamento
            // 
            this.tabAtualizaOrcamento.Controls.Add(this.grpInsumos);
            this.tabAtualizaOrcamento.Controls.Add(this.grdExportaQtde);
            this.tabAtualizaOrcamento.Controls.Add(this.panel7);
            this.tabAtualizaOrcamento.Location = new System.Drawing.Point(4, 25);
            this.tabAtualizaOrcamento.Margin = new System.Windows.Forms.Padding(4);
            this.tabAtualizaOrcamento.Name = "tabAtualizaOrcamento";
            this.tabAtualizaOrcamento.Padding = new System.Windows.Forms.Padding(4);
            this.tabAtualizaOrcamento.Size = new System.Drawing.Size(1103, 494);
            this.tabAtualizaOrcamento.TabIndex = 5;
            this.tabAtualizaOrcamento.Text = "Atualiza Orçamento";
            this.tabAtualizaOrcamento.UseVisualStyleBackColor = true;
            // 
            // grpInsumos
            // 
            this.grpInsumos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInsumos.Controls.Add(this.grdInsumos);
            this.grpInsumos.Location = new System.Drawing.Point(4, 336);
            this.grpInsumos.Name = "grpInsumos";
            this.grpInsumos.Size = new System.Drawing.Size(1095, 155);
            this.grpInsumos.TabIndex = 7;
            this.grpInsumos.TabStop = false;
            this.grpInsumos.Text = "Insumos";
            // 
            // grdInsumos
            // 
            this.grdInsumos.AllowUserToAddRows = false;
            this.grdInsumos.AllowUserToDeleteRows = false;
            this.grdInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInsumos.Location = new System.Drawing.Point(3, 18);
            this.grdInsumos.Margin = new System.Windows.Forms.Padding(4);
            this.grdInsumos.Name = "grdInsumos";
            this.grdInsumos.ReadOnly = true;
            this.grdInsumos.Size = new System.Drawing.Size(1089, 134);
            this.grdInsumos.TabIndex = 7;
            // 
            // grdExportaQtde
            // 
            this.grdExportaQtde.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdExportaQtde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExportaQtde.Location = new System.Drawing.Point(4, 43);
            this.grdExportaQtde.Margin = new System.Windows.Forms.Padding(4);
            this.grdExportaQtde.Name = "grdExportaQtde";
            this.grdExportaQtde.Size = new System.Drawing.Size(1095, 286);
            this.grdExportaQtde.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblVersao);
            this.panel7.Controls.Add(this.cbxVersao);
            this.panel7.Controls.Add(this.btnConsultarHistorico);
            this.panel7.Controls.Add(this.btnExportaQtde);
            this.panel7.Controls.Add(this.btnConultarExportaQtde);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1095, 39);
            this.panel7.TabIndex = 4;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(4, 10);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(53, 17);
            this.lblVersao.TabIndex = 7;
            this.lblVersao.Text = "Versão";
            // 
            // cbxVersao
            // 
            this.cbxVersao.FormattingEnabled = true;
            this.cbxVersao.Location = new System.Drawing.Point(63, 7);
            this.cbxVersao.Name = "cbxVersao";
            this.cbxVersao.Size = new System.Drawing.Size(50, 24);
            this.cbxVersao.TabIndex = 6;
            // 
            // btnConsultarHistorico
            // 
            this.btnConsultarHistorico.Location = new System.Drawing.Point(322, 4);
            this.btnConsultarHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarHistorico.Name = "btnConsultarHistorico";
            this.btnConsultarHistorico.Size = new System.Drawing.Size(135, 28);
            this.btnConsultarHistorico.TabIndex = 5;
            this.btnConsultarHistorico.Text = "Consultar Histórico";
            this.btnConsultarHistorico.UseVisualStyleBackColor = true;
            this.btnConsultarHistorico.Click += new System.EventHandler(this.btnConsultarHistorico_Click);
            // 
            // btnExportaQtde
            // 
            this.btnExportaQtde.Location = new System.Drawing.Point(221, 4);
            this.btnExportaQtde.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportaQtde.Name = "btnExportaQtde";
            this.btnExportaQtde.Size = new System.Drawing.Size(93, 28);
            this.btnExportaQtde.TabIndex = 4;
            this.btnExportaQtde.Text = "Exportar";
            this.btnExportaQtde.UseVisualStyleBackColor = true;
            this.btnExportaQtde.Click += new System.EventHandler(this.btnExportaQtde_Click);
            // 
            // btnConultarExportaQtde
            // 
            this.btnConultarExportaQtde.Location = new System.Drawing.Point(120, 4);
            this.btnConultarExportaQtde.Margin = new System.Windows.Forms.Padding(4);
            this.btnConultarExportaQtde.Name = "btnConultarExportaQtde";
            this.btnConultarExportaQtde.Size = new System.Drawing.Size(93, 28);
            this.btnConultarExportaQtde.TabIndex = 3;
            this.btnConultarExportaQtde.Text = "Consultar";
            this.btnConultarExportaQtde.UseVisualStyleBackColor = true;
            this.btnConultarExportaQtde.Click += new System.EventHandler(this.btnConultarExportaQtde_Click);
            // 
            // FrmExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 523);
            this.Controls.Add(this.tabAcompanhaContrato);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmExportar";
            this.Text = "Exportar dados";
            this.tabAcompanhaContrato.ResumeLayout(false);
            this.tabAvanco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExportaAvanco)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabAcomContrato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAcompanhaContrato)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tabAtualizaObra.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabDadosContrato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContrato)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabAtualizaOrcamento.ResumeLayout(false);
            this.grpInsumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInsumos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExportaQtde)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabAcompanhaContrato;
        private System.Windows.Forms.TabPage tabAtualizaObra;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabDadosContrato;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAtualizaObra;
        private System.Windows.Forms.TabPage tabAvanco;
        private System.Windows.Forms.DataGridView dtgExportaAvanco;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportarAvanco;
        private System.Windows.Forms.TabPage tabAcomContrato;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAcompanhaContrato;
        private System.Windows.Forms.Button btnObraAvanco;
        private System.Windows.Forms.Button btnObra;
        private System.Windows.Forms.DataGridView grdAcompanhaContrato;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnImportarProject;
        private System.Windows.Forms.Button btnExportarProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdBaselineNao;
        private System.Windows.Forms.RadioButton rdBaselineSim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdTodasNao;
        private System.Windows.Forms.RadioButton rdTodasSim;
        private System.Windows.Forms.ProgressBar pgr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBloco;
        private System.Windows.Forms.Button btnsalvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMedicaoBloco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdgPavGrupoServ;
        private System.Windows.Forms.RadioButton rdgGrupoServPav;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabAtualizaOrcamento;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbTabelas;
        private System.Windows.Forms.Button btnImportarDadosContrato;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnExportaQtde;
        private System.Windows.Forms.Button btnConultarExportaQtde;
        private System.Windows.Forms.DataGridView grdContrato;
        private System.Windows.Forms.DataGridView grdExportaQtde;
        private System.Windows.Forms.Button btnConsultarHistorico;
        private System.Windows.Forms.GroupBox grpInsumos;
        private System.Windows.Forms.DataGridView grdInsumos;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ComboBox cbxVersao;
    }
}

