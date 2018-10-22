using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;
using System.IO;
using ms = Microsoft.Office.Interop.MSProject;
using Microsoft.Rest;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;
//using System.Net.Http;

namespace WindowsFormsApp2
{
    public partial class FrmExportar : Form
    {
        public ms.Application App;
        public string caminho;
        public object misValue;
        public OpenFileDialog op = new OpenFileDialog();
        public List<ObjetoTransferencia.PAR_QTDE_MEDICAO_BLOCO> qtdeMedicaoBloco = new List<PAR_QTDE_MEDICAO_BLOCO>();

        public List<PAR_BUSCAR_CONTRATOS_UAU> listaDeContratosERP = new List<PAR_BUSCAR_CONTRATOS_UAU>();
        string obra;
        public int obraId;
        public string dir = Application.StartupPath + "\\";
        public int ultimaVersaoHisorico = 0;
        //private HttpRequestMessage request;
        RestClient client;
        RestRequest request;
        string tokenAuthentication;

        public string Obra
        {
            get
            {
                return "Obra: " + obra;
            }
            set
            {
                obraId = Convert.ToInt32(value);
                obra = value;
            }
        }

        public FrmExportar()
        {
            InitializeComponent();
            StreamReader config = new StreamReader(Application.StartupPath + @"\Config.txt");
            config.ReadLine();
            config.ReadLine();
            config.ReadLine();
            Obra = config.ReadLine();
            config.Dispose();
            btnObra.Text = Obra;
            btnObraAvanco.Text = Obra;
            txtBloco.Text = Properties.Settings.Default.BLOCO_ID;
            txtMedicaoBloco.Text = Properties.Settings.Default.MEDICAO_BLOCO_ID;
            txtGrupo.Text = Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID;
            txtServico.Text = Properties.Settings.Default.SERVICO_ID;

            grdExportaQtde.DataBindingComplete += grdExportaQtde_DataBindingComplete;
            grdExportaQtde.RowEnter += grdExportaQtde_RowEnter;
            PreencherComboVersao();
        }       

        private void btnExportarAvanco_Click(object sender, EventArgs e)
        {
            PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO par = new PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO();
            par.EOBRA_ID = 2;
            par.EINICIO = new DateTime(1900, 01, 01);
            par.EFIM = new DateTime(2900, 01, 01);
            par.EXPORTAR_PARA_PLANEJAMENTO = 0;
            wsAcompUAU.wsAcompanhamentosServicosSoapClient wsAcompOrc = new wsAcompUAU.wsAcompanhamentosServicosSoapClient();
            List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> listaOrcado = new ACESSO_PRC_EXPORTA_AVANCO().EXPORTA_AVANCO(Application.StartupPath + "\\", par);
            dtgExportaAvanco.DataSource = listaOrcado;

            foreach (PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO item in listaOrcado)
            {
                try
                {


                    wsAcompOrc.AcompanharServicoOrcado(item.empresa,
                                                        item.obra,
                                                        item.servico,
                                                        item.item,
                                                        item.orcamento,
                                                        item.periodo,
                                                        item.quantidade,
                                                        "ROOT",
                                                        "01.04");

                    item.AvancadoNoUAU = 1;
                    //  wsAcompOrc.AcompanharServicoOrcado(15, "PLAN1", "C12.03.082", "01.01.02.04", 2, "01/10/2017", 1, "ROOT", "1.0");
                    //new Negocios.ACESSO_PRC_EXPORTA_AVANCO().ConfirmaExportaAvanco(Application.StartupPath + "\\", );
                }
                catch (Exception ex)
                {
                    //wsAcompOrc.ExcluirAcompanhamentoServicoOrcado(par.empresa, par.obra, par.servico, par.item, par.orcamento,
                    //                                              par.periodo, par.quantidade, par.sequencia);
                    item.AvancadoNoUAU = 0;
                }
            }
            dtgExportaAvanco.DataSource = new ACESSO_PRC_EXPORTA_AVANCO().ConfirmaExportaAvanco(Application.StartupPath + "\\", listaOrcado);
        }

        private void btnAtualizaObra_Click(object sender, EventArgs e)
        {
            /*WSContratoUAU.AcompContratosSoapClient c = new WSContratoUAU.AcompContratosSoapClient();
            DataSet D = c.BuscarObras(null, 15, "ROOT");
            MessageBox.Show("foi");
            if (D.Tables[0] != null) dataGridView1.DataSource = D.Tables[0];*/
        }

        private void btnImportarDadosContrato_Click_1(object sender, EventArgs e)
        {

            WSContratoUAU.wsContratoMaterialServicoSoap w;

            WSContratoUAU.wsContratoMaterialServicoSoapClient c = new WSContratoUAU.wsContratoMaterialServicoSoapClient();
            // DataSet d1 = c.BuscarContratos(null, 15, "PLAN1");

            cmbTabelas.Items.Clear();
            int qtde = 0;

            /* foreach (DataTable dt in d1.Tables)
             {
                 qtde++;
                 cmbTabelas.Items.Add(qtde);
             }*/
            Clipboard.Clear();
            StringBuilder sb = new StringBuilder();
            /* if (d1.Tables[0] != null) grdContrato.DataSource = d1.Tables[0];

             listaDeContratosERP.Clear();
             foreach (DataRow dr1 in d1.Tables[0].Rows)*/
            {

                /*
                (new PAR_BUSCAR_CONTRATOS_UAU
                {

                }
                );*/

            }

            /* foreach (DataColumn item in d1.Tables[0].Columns)
             {
                 sb.AppendLine("public " + item.DataType.Name + " " + item.ColumnName + " {get; set;}");
             }*/
            Clipboard.SetText(sb.ToString());

        }

        private void btnAcompanhaContrato_Click(object sender, EventArgs e)
        {
            wsAcompUAU.wsAcompanhamentosServicosSoapClient c = new wsAcompUAU.wsAcompanhamentosServicosSoapClient();
            List<PAR_ACOMPANHA_CONTRATO_UAU> listaAcompContrato = new List<PAR_ACOMPANHA_CONTRATO_UAU>();
            PAR_ACOMPANHA_CONTRATO_UAU entrada = new PAR_ACOMPANHA_CONTRATO_UAU();

            entrada.input_obra_id = 2;
            entrada.input_inicio = new DateTime(1900, 01, 01);
            entrada.input_fim = new DateTime(2500, 01, 01);

            listaAcompContrato = new ACESSO_ACOMPANHA_CONTRATO_UAU().EXPORTA_ACOMP_CONTRATO(Application.StartupPath + "\\", entrada);

            grdAcompanhaContrato.DataSource = listaAcompContrato;
            OrganizarColunasAcompContrato();

            Application.DoEvents();
            foreach (PAR_ACOMPANHA_CONTRATO_UAU item in listaAcompContrato)
            {
                try
                {
                    c.AcompanharServicoContrato(item.empresa,
                                                item.obra,
                                                item.contratoServico,
                                                item.itemContrato,
                                                item.servico,
                                                item.dataInicio,
                                                item.dataFim,
                                                item.mesPl,
                                                item.quantidade,
                                                0,
                                                item.observacoes,
                                                item.etapa,
                                                item.codEstrutura,
                                                item.sequencia,//TESTAR
                                                item.usuarioLogado);

                    item.acompanhadoUau = 1;
                    //Verificar no ERP se existe Acompanhamento de Contrato e Medição, e atualizar campos conforme retorno.
                }
                catch (Exception e1)
                {
                    item.acompanhadoUau = 0;

                }

            }
            MessageBox.Show("Processo concluído no UAU!");
            listaAcompContrato = new ACESSO_ACOMPANHA_CONTRATO_UAU().GravaAcompanhamentoNoTocBIM(Application.StartupPath + "\\", listaAcompContrato);
            grdAcompanhaContrato.DataSource = listaAcompContrato;
            OrganizarColunasAcompContrato();
            Application.DoEvents();
            MessageBox.Show("Processo concluído no Modelo!");
        }

        private void OrganizarColunasAcompContrato()
        {
            //Ocultar colunas
            grdAcompanhaContrato.Columns["input_obra_id"].Visible = false;
            grdAcompanhaContrato.Columns["input_inicio"].Visible = false;
            grdAcompanhaContrato.Columns["input_fim"].Visible = false;
            
            //Definir título das colunas
            grdAcompanhaContrato.Columns["empresa"].HeaderText = "Empresa";
            grdAcompanhaContrato.Columns["obra"].HeaderText = "Obra";
            grdAcompanhaContrato.Columns["contratoServico"].HeaderText = "Contrato";
            grdAcompanhaContrato.Columns["itemContrato"].HeaderText = "Item Contrato";
            grdAcompanhaContrato.Columns["servico"].HeaderText = "Serviço";
            grdAcompanhaContrato.Columns["dataInicio"].HeaderText = "Data Início";
            grdAcompanhaContrato.Columns["dataFim"].HeaderText = "Data Fim";
            grdAcompanhaContrato.Columns["mesPl"].HeaderText = "Mes Pl";
            grdAcompanhaContrato.Columns["quantidade"].HeaderText = "Qtde";
            grdAcompanhaContrato.Columns["porcentagemAcomp"].HeaderText = "% Acompanhamento";
            grdAcompanhaContrato.Columns["observacoes"].HeaderText = "Observações";
            grdAcompanhaContrato.Columns["etapa"].HeaderText = "Etapa";
            grdAcompanhaContrato.Columns["codEstrutura"].HeaderText = "Cod. Estrutura";
            grdAcompanhaContrato.Columns["sequencia"].HeaderText = "Sequencia";
            grdAcompanhaContrato.Columns["usuarioLogado"].HeaderText = "Usuario";
            grdAcompanhaContrato.Columns["acompanhadoUau"].HeaderText = "Acompanhado Uau";
            grdAcompanhaContrato.Columns["acompanhadoTocBIM"].HeaderText = "Acompanhado TocBIM";
            grdAcompanhaContrato.Columns["dia_realizado"].HeaderText = "Dia Realizado";
            grdAcompanhaContrato.Columns["acompanhamentoContrato"].HeaderText = "Acompanhamento Contrato";
            grdAcompanhaContrato.Columns["medicao"].HeaderText = "Medição";

            //Definir colunas que podem ser editadas
            /*grdExportaQtde.Columns["ITEM"].ReadOnly = true;
            grdExportaQtde.Columns["TIPO"].ReadOnly = true;
            grdExportaQtde.Columns["COMPLEMENTO"].ReadOnly = true;
            grdExportaQtde.Columns["EXPORTADO"].ReadOnly = true;
            grdExportaQtde.Columns["SERVICO_ID"].ReadOnly = true;
            grdExportaQtde.Columns["SERVICO"].ReadOnly = true;
            grdExportaQtde.Columns["UNID"].ReadOnly = true;
            grdExportaQtde.Columns["QTDE_ANTERIOR"].ReadOnly = true;
            grdExportaQtde.Columns["QTDE_ATUAL"].ReadOnly = true;
            grdExportaQtde.Columns["DIFERENCA"].ReadOnly = true;
            grdExportaQtde.Columns["DESVINCULADO_ANTERIOR"].ReadOnly = true;
            grdExportaQtde.Columns["DESVINCULADO_ATUAL"].ReadOnly = true;
            grdExportaQtde.Columns["EXCLUIDO"].ReadOnly = true;*/

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdAcompanhaContrato.Columns["empresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["obra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["contratoServico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["itemContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["servico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["dataInicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["dataFim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["mesPl"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["porcentagemAcomp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["observacoes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["etapa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["codEstrutura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["sequencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["usuarioLogado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["acompanhadoUau"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["acompanhadoTocBIM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["dia_realizado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["acompanhamentoContrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdAcompanhaContrato.Columns["medicao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Formatar quantidade
            /*grdExportaQtde.Columns["QTDE_ANTERIOR"].DefaultCellStyle.Format = "N";
            grdExportaQtde.Columns["QTDE_ATUAL"].DefaultCellStyle.Format = "N";
            grdExportaQtde.Columns["DIFERENCA"].DefaultCellStyle.Format = "N";*/
        }

        private void grdContrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            /*WSContratoUAU.AcompContratosSoapClient c = new WSContratoUAU.AcompContratosSoapClient();
            DataSet d1 = c.consul(null, 15, "PLAN1");

            cmbTabelas.Items.Clear();
            int qtde = 0;

            foreach (DataTable dt in d1.Tables)
            {
                qtde++;
                cmbTabelas.Items.Add(qtde);
            }
            Clipboard.Clear();
            StringBuilder sb = new StringBuilder();
            if (d1.Tables[0] != null) grdContrato.DataSource = d1.Tables[0];

            listaDeContratosERP.Clear();
            foreach (DataRow dr1 in d1.Tables[0].Rows)
            {

                /*
                (new PAR_BUSCAR_CONTRATOS_UAU
                {

                }
                );*/

            /*            }

       foreach (DataColumn item in d1.Tables[0].Columns)
       {
           sb.AppendLine("public " + item.DataType.Name + " " + item.ColumnName + " {get; set;}");
       }
       Clipboard.SetText(sb.ToString());
       */
        }

        private void btnObraAvanco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obra 02 selecionada");
        }

        private void btnObra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Obra 02 selecionada");
        }

        private void btnEscolherProject_Click(object sender, EventArgs e)
        {
            App = new ms.Application();

            App.Visible = true;
            op.ShowDialog();
            caminho = op.FileName;
            App.FileOpenEx(caminho);
        }

        private void btnExportarProject_Click(object sender, EventArgs e)
        {
            App = new ms.Application();

            App.Visible = true;
            op.ShowDialog();
            caminho = op.FileName;
            App.FileOpenEx(caminho);

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (rdgGrupoServPav.Checked)
                {
                    BlocoGrupoServicoMedicao();
                    return;
                }
                if (rdgPavGrupoServ.Checked)
                {
                    BlocoMedicaoServico();
                    return;
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                Cursor.Current = Cursors.Default;
            }
        }

        private void BlocoGrupoServicoMedicao()
        {
            List<ObjetoTransferencia.PAR_GERAR_MS_PROJECT> lista =
             new Negocios.ACESSO_PRC_GERAR_PROJECT().Seleciona(Application.StartupPath + "\\", 2);
            pgr.Maximum = lista.Count;
            foreach (PAR_GERAR_MS_PROJECT item in lista)
            {
                switch (item.NIVEL)
                {
                    case 2:
                        FuncoesMSProject.InserirNivel2(item, App);
                        break;
                    case 3:
                        FuncoesMSProject.InserirNivel3(item, App);
                        break;
                    case 4:
                        FuncoesMSProject.InserirNivel4(item, App);
                        break;
                    case 5:
                        FuncoesMSProject.InserirNivel5(item, App);
                        break;
                    default:
                        break;
                }
                pgr.PerformStep();
            }
        }

        private void BlocoMedicaoServico()
        {
            List<ObjetoTransferencia.PAR_GERAR_MS_PROJECT> lista =
             new Negocios.ACESSO_PRC_GERAR_PROJECT_PAV_SERV().Seleciona(Application.StartupPath + "\\", 2);
             FuncoesMSProject.SetarPropriedade(App.ActiveProject.Tasks[0], 
                                               Properties.Settings.Default.BLOCO_ID, 
                                               "BlocoMedicaoServico");
            
            pgr.Maximum = lista.Count;
            foreach (PAR_GERAR_MS_PROJECT item in lista)
            {
                switch (item.NIVEL)
                {
                    case 2:
                        FuncoesMSProject.InserirNivel2(item, App);
                        break;
                    case 3:
                        FuncoesMSProject.InserirNivel3(item, App);
                        break;
                    case 4:
                        FuncoesMSProject.InserirNivel4(item, App);
                        break;
                    default:
                        break;
                }
                pgr.PerformStep();
            }
        }

        private void btnImportarProject_Click(object sender, EventArgs e)
        {
            if(rdgGrupoServPav.Checked)
            {
                btnImportarProjectBlocoGrupoServPav(btnImportarProject, null);
            }
            if(rdgPavGrupoServ.Checked)
            {
                btnImportarProjectPavSer(btnImportarProject , null);
            }
        }

        private void btnImportarProjectBlocoGrupoServPav(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateTime inicio, termino;
            inicio = DateTime.Today;
            termino = DateTime.Today;

            int TipoDeCurva = 0;
            if (rdBaselineNao.Checked)
            { TipoDeCurva = 1; }
            else
            { TipoDeCurva = 0; }

            Boolean todas = false;
            if (rdTodasSim.Checked)
            { todas = true; }
            else
            { todas = false; }


            op.ShowDialog();
            string caminho = op.FileName;
            Negocios.Plan_servico_amoNegocio manipulacao = new Plan_servico_amoNegocio(Application.StartupPath + "\\");


            ms.Application App; // Aplicação Excel
            object misValue = System.Reflection.Missing.Value;

            App = new ms.Application();

            App.Visible = true;

            App.FileOpenEx(caminho);

            ms.Tasks tarefas;
            tarefas = App.ActiveProject.Tasks;

            if (!todas)
            {
                tarefas = App.ActiveSelection.Tasks;
            }
            int ITEM_RESUMO_GERAL_GRUPO_ID = 0;
            pgr.Maximum = tarefas.Count - 1;
            pgr.Step = 1;
            List<PAR_SERV_ITEM_RESUMO_GERAL> listaServico = new ACESSO_ITEM_RESUMO_GERAL().Seleciona(Application.StartupPath + "\\");
            foreach (ms.Task task in tarefas)
            {
                pgr.PerformStep();
                try
                {
                    if (task.OutlineLevel == 5)
                    {

                        if (!string.IsNullOrEmpty(task.Text4))
                        {

                            switch (TipoDeCurva)
                            {
                                case 0:
                                    inicio = task.Baseline1Start;
                                    termino = task.Baseline1Finish;
                                    break;
                                case 1:
                                    inicio = task.Start;
                                    termino = task.Finish;
                                    break;

                                default:
                                    break;
                            }

                            int transacao = Convert.ToInt32(manipulacao.PRC_EXECUTAR_DIRETO("select gen_id(CONTADOR_MES_PLANEJAMENTO,1) transacao   from rdb$database").Rows[0]["TRANSACAO"]);
                            PAR_INSERIR_MES_PLAN parametroMesPlan = new PAR_INSERIR_MES_PLAN();
                            parametroMesPlan.INICIO = inicio;
                            parametroMesPlan.TERMICO = termino;
                            parametroMesPlan.TRANSACAO = transacao;
                            parametroMesPlan.PERCENT = 1;
                            manipulacao.PRC_INSERIR_MES_PLAN(parametroMesPlan);
                            ITEM_RESUMO_GERAL_GRUPO_ID = Convert.ToInt32(task.Text3);

                            var filtro = listaServico.Where(x => x.ITEM_RESUMO_GERAL_GRUPO_ID == ITEM_RESUMO_GERAL_GRUPO_ID);
                            foreach (PAR_SERV_ITEM_RESUMO_GERAL item in filtro)
                            {


                                PAR_INSERIR_PLANEJAMENTO parInserirPlanejamento = new PAR_INSERIR_PLANEJAMENTO();
                                if (task.Critical)
                                    parInserirPlanejamento.ECRITICA = 1;
                                else parInserirPlanejamento.ECRITICA = 0;

                                parInserirPlanejamento.EGRUPO_ID = Convert.ToInt32(task.Text2);
                                parInserirPlanejamento.ESERVICO_ID = item.SERVICO_ID;
                                parInserirPlanejamento.EBLOCO_ID = Convert.ToInt32(task.Text1);
                                parInserirPlanejamento.EMEDICAO_BLOCO_ID = Convert.ToInt32(task.Text4);
                                parInserirPlanejamento.ENIVEL = 3;
                                parInserirPlanejamento.ETIPO = TipoDeCurva;
                                parInserirPlanejamento.EIGUALA_ANTERIOR = 0;
                                parInserirPlanejamento.ETRANSACAO = transacao;
                                parInserirPlanejamento.EDATA_LIMITE = inicio.AddDays(-1);
                                parInserirPlanejamento.EDELETAR_ANTERIOR = 1;
                                manipulacao.PRC_INSERIR_PLANEJAMENTO(parInserirPlanejamento);

                                task.Text10 = "OK!";
                            }
                        }
                    }

                }
                catch (Exception e1)
                {
                    task.Text10 = e1.Message;
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void btnImportarProjectPavSer(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateTime inicio, termino;
            inicio = DateTime.Today;
            termino = DateTime.Today;

            int TipoDeCurva = 0;
            if (rdBaselineNao.Checked)
            { TipoDeCurva = 1; }
            else
            { TipoDeCurva = 0; }

            Boolean todas = false;
            if (rdTodasSim.Checked)
            { todas = true; }
            else
            { todas = false; }


            op.ShowDialog();

            string caminho = op.FileName;
            Negocios.Plan_servico_amoNegocio manipulacao = new Plan_servico_amoNegocio(Application.StartupPath + "\\");


            ms.Application App; // Aplicação Excel
            object misValue = System.Reflection.Missing.Value;

            App = new ms.Application();

            App.Visible = false;
            this.Cursor = Cursors.WaitCursor;
           

            App.FileOpenEx(caminho);

            ms.Tasks tarefas;
            tarefas = App.ActiveProject.Tasks;

            if (!todas)
            {
                tarefas = App.ActiveSelection.Tasks;
            }
            int ITEM_RESUMO_GERAL_GRUPO_ID = 0;
            pgr.Maximum = tarefas.Count - 1;
            pgr.Step = 1;
            List<PAR_SERV_ITEM_RESUMO_GERAL> listaServico = new ACESSO_ITEM_RESUMO_GERAL().Seleciona(Application.StartupPath + "\\");
            try
            {
                foreach (ms.Task task in tarefas)
                {
                    pgr.PerformStep();
                    try
                    {
                        DadosTarefaProjec dados = FuncoesMSProject.GetDadosTarefaProject(task);
                        if (dados != null)
                        {
                          
                            switch (TipoDeCurva)
                            {
                                case 0:
                                    inicio = task.Baseline1Start;
                                    termino = task.Baseline1Finish;
                                    break;
                                case 1:
                                    inicio = task.Start;
                                    termino = task.Finish;
                                    break;

                                default:
                                    break;
                            }

                            int transacao = Convert.ToInt32(manipulacao.PRC_EXECUTAR_DIRETO("select gen_id(CONTADOR_MES_PLANEJAMENTO,1) transacao   from rdb$database").Rows[0]["TRANSACAO"]);
                            PAR_INSERIR_MES_PLAN parametroMesPlan = new PAR_INSERIR_MES_PLAN();
                            parametroMesPlan.INICIO = inicio;
                            parametroMesPlan.TERMICO = termino;
                            parametroMesPlan.TRANSACAO = transacao;
                            parametroMesPlan.PERCENT = 1;
                            manipulacao.PRC_INSERIR_MES_PLAN(parametroMesPlan);
                            ITEM_RESUMO_GERAL_GRUPO_ID = dados.SERVICO_ID;

                            var filtro = listaServico.Where(x => x.ITEM_RESUMO_GERAL_GRUPO_ID == ITEM_RESUMO_GERAL_GRUPO_ID);
                            foreach (PAR_SERV_ITEM_RESUMO_GERAL item in filtro)
                            {
                                if (dados.GRUPO_ID == -1)
                                  dados.GRUPO_ID = new Negocios.ACESSO_GRUPO_PLAN_SERVICO().SelecionaPorObraeServico(2, item.SERVICO_ID, Application.StartupPath + "\\");


                                PAR_INSERIR_PLANEJAMENTO parInserirPlanejamento = new PAR_INSERIR_PLANEJAMENTO();
                                if (task.Critical)
                                    parInserirPlanejamento.ECRITICA = 1;
                                else parInserirPlanejamento.ECRITICA = 0;

                                parInserirPlanejamento.EGRUPO_ID = dados.GRUPO_ID;
                                parInserirPlanejamento.ESERVICO_ID = item.SERVICO_ID;
                                parInserirPlanejamento.EBLOCO_ID = dados.BLOCO_D;
                                parInserirPlanejamento.EMEDICAO_BLOCO_ID = dados.MEDICAO_BLOCO_ID;
                                parInserirPlanejamento.ENIVEL = 3;
                                parInserirPlanejamento.ETIPO = TipoDeCurva;
                                parInserirPlanejamento.EIGUALA_ANTERIOR = 0;
                                parInserirPlanejamento.ETRANSACAO = transacao;
                                parInserirPlanejamento.EDATA_LIMITE = inicio.AddDays(-1);
                                parInserirPlanejamento.EDELETAR_ANTERIOR = 1;
                                manipulacao.PRC_INSERIR_PLANEJAMENTO(parInserirPlanejamento);

                                task.Text16 = "OK!";
                            }

                        }

                    }
                    catch (Exception e1)
                    {
                        task.Text16 = e1.Message;
                    }

                }
            }
            finally
            {
                App.Visible = true;
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SERVICO_ID= txtServico.Text;
            Properties.Settings.Default.BLOCO_ID= txtBloco.Text;
            Properties.Settings.Default.MEDICAO_BLOCO_ID= txtMedicaoBloco.Text;
            Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID = txtGrupo.Text;
            Properties.Settings.Default.Save();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO par = new PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO();
            par.EOBRA_ID = 2;
            par.EINICIO = new DateTime(1900, 01, 01);
            par.EFIM = new DateTime(2900, 01, 01);
            par.EXPORTAR_PARA_PLANEJAMENTO = 1;
            

            wsAcompUAU.wsAcompanhamentosServicosSoapClient wsAcompOrc = new wsAcompUAU.wsAcompanhamentosServicosSoapClient();
            //System.Configuration.ConfigurationManager.AppSettings["wsAcompanhamentosServicosSoap"];

            List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> listaOrcado = new ACESSO_PRC_EXPORTA_AVANCO().EXPORTA_AVANCO(Application.StartupPath + "\\", par);
            dtgExportaAvanco.DataSource = listaOrcado;

            foreach (PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO item in listaOrcado)
            {
                try
                {
                       /* string empresa, 
                        string obra, 
                        int produto, 
                        int contrato, 
                        string item, 
                        string servico, 
                        string mes, 
                        string usuario, 
                        double qtde, 
                        string sequencia*/

                    wsAcompOrc.AcompanharServicoPL(item.empresa.ToString(),
                                                        item.obra,
                                                        Convert.ToInt32( item.produto),
                                                        Convert.ToInt32(item.contrato),
                                                        item.item,
                                                        item.servico,
                                                        item.periodo,
                                                        "ROOT",
                                                        item.quantidade,
                                                        item.sequencia);

                    item.AvancadoNoUAU = 1;
                    //  wsAcompOrc.AcompanharServicoOrcado(15, "PLAN1", "C12.03.082", "01.01.02.04", 2, "01/10/2017", 1, "ROOT", "1.0");
                    //  new Negocios.ACESSO_PRC_EXPORTA_AVANCO().ConfirmaExportaAvanco(Application.StartupPath + "\\", );
                }
                catch (Exception ex)
                {
                   // wsAcompOrc.ExcluirAcompanhamentoServicoOrcado(par.empresa, par.obra, par.servico, par.item, par.orcamento,
                                        //                          par.periodo, par.quantidade, par.sequencia);
                    item.AvancadoNoUAU = 0;
                }
            }
            dtgExportaAvanco.DataSource = new ACESSO_PRC_EXPORTA_AVANCO().ConfirmaExportaAvanco(Application.StartupPath + "\\", listaOrcado);
        }

        private void btnConultarExportaQtde_Click(object sender, EventArgs e)
        {
            /*frmAssociacaoPsaContrato frmAss = new frmAssociacaoPsaContrato();
            frmAss.Show();*/
            int OBRA_ID = 2;
            Historico_Exporta_Qtde RegHistorico;
            List<Historico_Exporta_Qtde> listaHistorico = new List<Historico_Exporta_Qtde>();
            List<PRC_EXPORTA_QTDE> listaExportaQtde = new List<PRC_EXPORTA_QTDE>();
            listaExportaQtde = new ACESSO_PRC_EXPORTA_QTDE().Seleciona(dir, OBRA_ID, Convert.ToInt32(cbxVersao.SelectedItem));

            foreach (PRC_EXPORTA_QTDE RegExportaQtde in listaExportaQtde)
            {
                if (RegExportaQtde.item == "02.01.03" || RegExportaQtde.item == "02.01.03.010") //Condição só para teste - Remover posteriormente
                {
                    string strServicoDesc = "";
                    RegHistorico = new Historico_Exporta_Qtde();
                    RegHistorico.ITEM = RegExportaQtde.item;
                    RegHistorico.TIPO = RegExportaQtde.tipo_servico;
                    RegHistorico.COMPLEMENTO = RegExportaQtde.codigo;
                    RegHistorico.SERVICO_ID = RegExportaQtde.servico;

                    if (RegExportaQtde.tipo_servico == 0)
                        strServicoDesc = RegExportaQtde.descricao;
                    else
                        if (RegExportaQtde.tipo_servico == 2)
                        strServicoDesc = " " + RegExportaQtde.descricao;
                    else
                            if (RegExportaQtde.tipo_servico == 3)
                        strServicoDesc = "  " + RegExportaQtde.descricao;

                    RegHistorico.SERVICO = strServicoDesc;
                    RegHistorico.UNID = RegExportaQtde.unid;
                    RegHistorico.QTDE_ANTERIOR = RegExportaQtde.qtde_anterior;
                    RegHistorico.QTDE_ATUAL = RegExportaQtde.qtde;
                    RegHistorico.DIFERENCA = RegExportaQtde.diferenca;
                    RegHistorico.DESVINCULADO_ANTERIOR = RegExportaQtde.desvinculado_anterior;
                    RegHistorico.DESVINCULADO_ATUAL = "N";
                    RegHistorico.CHAVE_ERP = RegExportaQtde.chave_erp;
                    RegHistorico.EXCLUIDO = RegExportaQtde.excluido;
                    RegHistorico.NIVEL = RegExportaQtde.nivel;
                    RegHistorico.ITEM_NOVO = RegExportaQtde.item_novo;
                    RegHistorico.INSUMO_INSTALACAO = RegExportaQtde.insumo_instalacao;
                    listaHistorico.Add(RegHistorico);
                }
            }
            grdExportaQtde.DataSource = listaHistorico;
            OrganizaColunasGrdExportaQtde();
        }

        private void grdExportaQtde_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdExportaQtde.RowCount > 0)
            {
                if (Convert.ToString(grdExportaQtde.Rows[e.RowIndex].Cells["INSUMO_INSTALACAO"].Value) == "S")
                {
                    List<Hist_Exporta_Qtde_Insumo> listaInsumo = new List<Hist_Exporta_Qtde_Insumo>();

                    string complemento = Convert.ToString(grdExportaQtde.Rows[e.RowIndex].Cells["COMPLEMENTO"].Value);
                    listaInsumo = new Acesso_Historico_Exporta_Qtde().ListarInsumos(Application.StartupPath + "\\", complemento);
                    grdInsumos.DataSource = listaInsumo;

                    OrganizaColunasGrdInsumo();
                }
                else
                {
                    grdInsumos.DataSource = new List<Hist_Exporta_Qtde_Insumo>();
                }
            }
        }

        private void OrganizaColunasGrdInsumo()
        {
            //Ocultar colunas
            grdInsumos.Columns["HIST_EXPORTA_QTDE_INSUMO_ID"].Visible = false;
            grdInsumos.Columns["HISTORICO_EXPORTA_QTDE_ID"].Visible = false;
            grdInsumos.Columns["COMPLEMENTO"].Visible = false;

            //Definir título das colunas
            grdInsumos.Columns["INSUMO_ID"].HeaderText = "Insumo";
            grdInsumos.Columns["INSUMO"].HeaderText = "Descrição";

            //Definir colunas que podem ser editadas
            grdInsumos.Columns["INSUMO_ID"].ReadOnly = true;
            grdInsumos.Columns["INSUMO"].ReadOnly = true;

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdInsumos.Columns["INSUMO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdInsumos.Columns["INSUMO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void grdExportaQtde_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdExportaQtde.RowCount; i++)
            {
                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                if (grdExportaQtde.Rows[i].Cells["EXCLUIDO"].Value.ToString() == "S")
                {
                    comboBoxCell.Items.Add("Excluir planejamento");
                }
                else
                {
                    if (grdExportaQtde.Rows[i].Cells["ITEM_NOVO"].Value.ToString() == "S")
                    {
                        comboBoxCell.Items.Add("");
                    }
                    else
                    {
                        if (Convert.ToDouble(grdExportaQtde.Rows[i].Cells["QTDE_ATUAL"].Value) > Convert.ToDouble(grdExportaQtde.Rows[i].Cells["QTDE_ANTERIOR"].Value))
                        {
                            comboBoxCell.Items.Add("Replanejar por percentual");
                            comboBoxCell.Items.Add("Replanejar por quantidade");
                            comboBoxCell.Items.Add("Excluir planejamento");
                        }
                        else
                        {
                            comboBoxCell.Items.Add("Replanejar por percentual");
                            comboBoxCell.Items.Add("Excluir planejamento");
                        }
                    }
                }
                comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                grdExportaQtde.Rows[i].Cells["ACAO"] = comboBoxCell;

                if (grdExportaQtde.Rows[i].Cells["EXCLUIDO"].Value.ToString() == "S")
                {
                    grdExportaQtde.Rows[i].DefaultCellStyle.ForeColor = Color.Red;          
                }
                else
                    if (grdExportaQtde.Rows[i].Cells["DESVINCULADO_ANTERIOR"].Value.ToString() == "S")
                        grdExportaQtde.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        if (grdExportaQtde.Rows[i].Cells["ITEM_NOVO"].Value.ToString() == "N")
                            grdExportaQtde.Rows[i].DefaultCellStyle.ForeColor = Color.Green;                                           

                //verificar esse exemplo
                /*DataGridViewComboBoxCell dc = new DataGridViewComboBoxCell();

                mydgv(YourColumnIndex, YourRowIndex) = dc;

                dc.datasource = yourdatatable, or list;

                dc.valuemember = "Valuemember ColumnName";

                dc.DisplayMember = "Displaymember ColumnName";*/

                //verificar esse exemplo tb
                /*DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();     
                DataTable data = new DataTable();

                data.Columns.Add(new DataColumn("Value", typeof(string)));
                data.Columns.Add(new DataColumn("Description", typeof(string)));


                data.Rows.Add("5", "6");
                data.Rows.Add("51", "26");
                data.Rows.Add("531", "63");
                cell.DataSource = data;
                cell.ValueMember = "Value";
                cell.DisplayMember = "Description";

                cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                dataGridView1.Rows[0].Cells[0] = cell;*/                
            }            
        }

        private void OrganizaColunasGrdExportaQtde()
        {            
            //Ocultar colunas
            grdExportaQtde.Columns["HISTORICO_EXP_QTDE_ID"].Visible = false;
            grdExportaQtde.Columns["SERVICO_ID"].Visible = false;
            grdExportaQtde.Columns["CHAVE_ERP"].Visible = false;
            grdExportaQtde.Columns["VERSAO"].Visible = false;
            grdExportaQtde.Columns["NIVEL"].Visible = false;
            grdExportaQtde.Columns["DATA_CAD"].Visible = false;
            grdExportaQtde.Columns["DATA_ALT"].Visible = false;
            grdExportaQtde.Columns["CAD"].Visible = false;
            grdExportaQtde.Columns["ALT"].Visible = false;
            grdExportaQtde.Columns["ITEM_NOVO"].Visible = false;
            grdExportaQtde.Columns["INSUMO_INSTALACAO"].Visible = false;

            //Definir título das colunas
            grdExportaQtde.Columns["ITEM"].HeaderText = "Item";
            grdExportaQtde.Columns["TIPO"].HeaderText = "Tipo";
            grdExportaQtde.Columns["COMPLEMENTO"].HeaderText = "Complemento";
            grdExportaQtde.Columns["EXPORTADO"].HeaderText = "Exportado";
            grdExportaQtde.Columns["SERVICO"].HeaderText = "Serviço";
            grdExportaQtde.Columns["ACAO"].HeaderText = "Ação Planejamento";
            grdExportaQtde.Columns["UNID"].HeaderText = "Unid";
            grdExportaQtde.Columns["QTDE_ANTERIOR"].HeaderText = "Qtde Anterior";
            grdExportaQtde.Columns["QTDE_ATUAL"].HeaderText = "Qtde Atual";
            grdExportaQtde.Columns["DIFERENCA"].HeaderText = "Diferença";
            grdExportaQtde.Columns["DESVINCULADO_ANTERIOR"].HeaderText = "Desvinculado Anterior";
            grdExportaQtde.Columns["DESVINCULADO_ATUAL"].HeaderText = "Desvinculado Atual";
            grdExportaQtde.Columns["EXCLUIDO"].HeaderText = "Excluído";

            //Definir colunas que podem ser editadas
            grdExportaQtde.Columns["ITEM"].ReadOnly = true;
            grdExportaQtde.Columns["TIPO"].ReadOnly = true;
            grdExportaQtde.Columns["COMPLEMENTO"].ReadOnly = true;
            grdExportaQtde.Columns["EXPORTADO"].ReadOnly = true;
            grdExportaQtde.Columns["SERVICO_ID"].ReadOnly = true;
            grdExportaQtde.Columns["SERVICO"].ReadOnly = true;
            grdExportaQtde.Columns["UNID"].ReadOnly = true;
            grdExportaQtde.Columns["QTDE_ANTERIOR"].ReadOnly = true;
            grdExportaQtde.Columns["QTDE_ATUAL"].ReadOnly = true;
            grdExportaQtde.Columns["DIFERENCA"].ReadOnly = true;
            grdExportaQtde.Columns["DESVINCULADO_ANTERIOR"].ReadOnly = true;
            grdExportaQtde.Columns["DESVINCULADO_ATUAL"].ReadOnly = true;
            grdExportaQtde.Columns["EXCLUIDO"].ReadOnly = true;

            //Definir tamanho das colunas - Redimenionar conforme conteudo
            grdExportaQtde.Columns["ITEM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["TIPO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["COMPLEMENTO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["EXPORTADO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            grdExportaQtde.Columns["SERVICO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["SERVICO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["UNID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["ACAO"].Width = 165;
            grdExportaQtde.Columns["QTDE_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["QTDE_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["DIFERENCA"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["DESVINCULADO_ANTERIOR"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["DESVINCULADO_ATUAL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdExportaQtde.Columns["EXCLUIDO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //Formatar quantidade
            grdExportaQtde.Columns["QTDE_ANTERIOR"].DefaultCellStyle.Format = "N";
            grdExportaQtde.Columns["QTDE_ATUAL"].DefaultCellStyle.Format = "N";
            grdExportaQtde.Columns["DIFERENCA"].DefaultCellStyle.Format = "N";
        }

        private void btnConsultarHistorico_Click(object sender, EventArgs e)
        {
            frmConsultaHistoricoExpQtde frmConsultaHistirico = new frmConsultaHistoricoExpQtde();
            frmConsultaHistirico.Show();
        }

        private void btnExportaQtde_Click(object sender, EventArgs e)
        {            
            if (Convert.ToInt32(cbxVersao.SelectedItem) == ultimaVersaoHisorico)
            {
                if (grdExportaQtde.RowCount > 0)
                {
                    if (AutenticarUsuarioUau())
                    {
                        GravarHistorico();
                        PreencherComboVersao();
                        MessageBox.Show("Exportação finalizada!");
                    }
                    else
                        MessageBox.Show("Houve um erro no autenticação de usuário no UAU!");
                }
                else
                    MessageBox.Show("Não existem registros a serem exportados!");
            }
            else
            {
                MessageBox.Show("Não é possível fazer a exportação, consultando os dados com versões anteriores de histórico!");
            }
        }

        private Boolean AutenticarUsuarioUau()
        {
            var client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Autenticador/AutenticarUsuario");
            RestRequest request = new RestRequest(Method.POST);
            request = new MontarRequestApiUau().ObjetRequestApiUau(request, "");            
            ObjetoTransferencia.UsuarioUAU usuario = new ObjetoTransferencia.UsuarioUAU { Login = "root", Senha = "iupii", UsuarioUAUSite = "toctecbim" };
            request.AddJsonBody(usuario);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                tokenAuthentication = JsonConvert.DeserializeObject(response.Content).ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GravarHistorico()
        {
            Historico_Exporta_Qtde regHistorico;
            List<Obra> listObra = new List<Obra>();
            Acesso_Historico_Exporta_Qtde objNegHistorico = new Acesso_Historico_Exporta_Qtde();
            ACESSO_OBRA objNegObra = new ACESSO_OBRA();
            IRestResponse response;

            listObra = objNegObra.Listar(dir, 2);

            int versao = objNegHistorico.Gerar_Versao(dir);

            for (int i = 0; i < grdExportaQtde.RowCount; i++)
            {
                regHistorico = new Historico_Exporta_Qtde();
             
                regHistorico.ITEM = Convert.ToString(grdExportaQtde.Rows[i].Cells["ITEM"].Value);
                regHistorico.TIPO = Convert.ToInt32(grdExportaQtde.Rows[i].Cells["TIPO"].Value);
                regHistorico.COMPLEMENTO = Convert.ToString(grdExportaQtde.Rows[i].Cells["COMPLEMENTO"].Value);
                regHistorico.EXPORTADO = Convert.ToString(grdExportaQtde.Rows[i].Cells["EXPORTADO"].Value);
                regHistorico.SERVICO_ID = Convert.ToInt32(grdExportaQtde.Rows[i].Cells["SERVICO_ID"].Value);
                regHistorico.SERVICO = Convert.ToString(grdExportaQtde.Rows[i].Cells["SERVICO"].Value);
                regHistorico.UNID = Convert.ToString(grdExportaQtde.Rows[i].Cells["UNID"].Value);
                regHistorico.ACAO = Convert.ToString(grdExportaQtde.Rows[i].Cells["ACAO"].Value);
                regHistorico.QTDE_ANTERIOR = Convert.ToDouble(grdExportaQtde.Rows[i].Cells["QTDE_ANTERIOR"].Value);
                regHistorico.QTDE_ATUAL = Convert.ToDouble(grdExportaQtde.Rows[i].Cells["QTDE_ATUAL"].Value);
                regHistorico.DESVINCULADO_ANTERIOR = Convert.ToString(grdExportaQtde.Rows[i].Cells["DESVINCULADO_ANTERIOR"].Value);
                regHistorico.DESVINCULADO_ATUAL = Convert.ToString(grdExportaQtde.Rows[i].Cells["DESVINCULADO_ATUAL"].Value);
                regHistorico.CHAVE_ERP = Convert.ToString(grdExportaQtde.Rows[i].Cells["CHAVE_ERP"].Value);
                regHistorico.EXCLUIDO = Convert.ToString(grdExportaQtde.Rows[i].Cells["EXCLUIDO"].Value);
                regHistorico.VERSAO = versao;
                regHistorico.NIVEL = Convert.ToInt32(grdExportaQtde.Rows[i].Cells["NIVEL"].Value);
                regHistorico.ITEM_NOVO = Convert.ToString(grdExportaQtde.Rows[i].Cells["ITEM_NOVO"].Value);
                regHistorico.INSUMO_INSTALACAO = Convert.ToString(grdExportaQtde.Rows[i].Cells["INSUMO_INSTALACAO"].Value);
                
                if (regHistorico.TIPO == 0)
                {                    
                    ServicoOrcamento servicoOrcado = new ServicoOrcamento();
                    servicoOrcado.usuario = "root";
                    servicoOrcado.quantidade = regHistorico.QTDE_ATUAL;
                    servicoOrcado.dataInicio = DateTime.Now;
                    servicoOrcado.dataFim = DateTime.Now;
                    servicoOrcado.empresa = listObra[0].EMPRESA_ID;
                    servicoOrcado.obra = listObra[0].OBRA;
                    servicoOrcado.numOrcamento = listObra[0].SYCROBRA_ID;
                    servicoOrcado.item = regHistorico.ITEM;
                    servicoOrcado.servico = regHistorico.COMPLEMENTO; //Álvaro - Confirmar com Larsson
                    servicoOrcado.codExternoIntegracao = regHistorico.CHAVE_ERP;

                    if (regHistorico.EXCLUIDO == "S")
                    {
                        //Deverá verificar se tem planejamento e excluir planejamento também. (Metodo não disponível na API)

                        client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/ExcluirServicoOrcamento");
                        request = new RestRequest(Method.POST);                                                
                    }
                    else
                    {
                        if (regHistorico.ITEM_NOVO == "S")
                        {
                            client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/InserirServicoOrcamento");
                            request = new RestRequest(Method.POST);            
                        }
                        else
                        {
                            client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/AlterarServicoOrcamento");
                            request = new RestRequest(Method.POST);

                            //Deverá consultar se tem planejamento. 
                            //Caso tenha planejamento replanejar conforme opção selecionada na combo                            
                        }
                    }

                    request = new MontarRequestApiUau().ObjetRequestApiUau(request, tokenAuthentication);
                    request.AddJsonBody(servicoOrcado);
                    response = client.Execute(request);
                }
                else
                {
                    if (regHistorico.TIPO == 2 || regHistorico.TIPO == 3)
                    {
                        EstruturaServicoOrcamento estruturaServicoOrcado = new EstruturaServicoOrcamento();
                        estruturaServicoOrcado.tipoEstrutura = regHistorico.TIPO;
                        estruturaServicoOrcado.codigo = regHistorico.COMPLEMENTO;
                        estruturaServicoOrcado.qtde = regHistorico.QTDE_ATUAL;
                        estruturaServicoOrcado.valor = 0;
                        estruturaServicoOrcado.usuario = "root";
                        //estruturaServicoOrcado.sequencia   //Verificar com Larson
                        estruturaServicoOrcado.empresa = listObra[0].EMPRESA_ID;
                        estruturaServicoOrcado.obra = listObra[0].OBRA;
                        estruturaServicoOrcado.numOrcamento = listObra[0].SYCROBRA_ID;
                        estruturaServicoOrcado.item = regHistorico.ITEM;
                        estruturaServicoOrcado.servico = regHistorico.SERVICO;
                        estruturaServicoOrcado.codExternoIntegracao = regHistorico.CHAVE_ERP;

                        if (regHistorico.EXCLUIDO == "S")
                        {
                            //Deverá verificar se tem planejamento e excluir planejamento também. (Metodo não disponível na API)

                            client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/ExcluirEstruturaServicoDeOrcamento");
                            request = new RestRequest(Method.POST);
                        }
                        else
                        {
                            if (regHistorico.ITEM_NOVO == "S")
                            {
                                client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/InserirEstruturaServicoDeOrcamento");
                                request = new RestRequest(Method.POST);
                            }
                            else
                            {
                                client = new RestClient("http://200.178.248.104:90/UAUApi_Integracao/api/v1.0/Orcamento/AtualizarEstruturaServicoDeOrcamento");
                                request = new RestRequest(Method.POST);

                                //Deverá consultar se tem planejamento. 
                                //Caso tenha planejamento replanejar conforme opção selecionada na combo                            
                            }
                        }

                        request = new MontarRequestApiUau().ObjetRequestApiUau(request, tokenAuthentication);
                        request.AddJsonBody(estruturaServicoOrcado);
                        response = client.Execute(request);                        
                    }
                }
                               
                regHistorico.HISTORICO_EXP_QTDE_ID = objNegHistorico.Inserir(dir, regHistorico);

                if (regHistorico.INSUMO_INSTALACAO == "S")
                {
                    List<Hist_Exporta_Qtde_Insumo> listaInsumo = new List<Hist_Exporta_Qtde_Insumo>();

                    string complemento = Convert.ToString(grdExportaQtde.Rows[i].Cells["COMPLEMENTO"].Value);
                    listaInsumo = new Acesso_Historico_Exporta_Qtde().ListarInsumos(Application.StartupPath + "\\", complemento);
                    foreach (Hist_Exporta_Qtde_Insumo insumo in listaInsumo)
                    {
                        //Implementar envio para ERP através do webservice (Metodo não disponível na API)

                        insumo.HISTORICO_EXPORTA_QTDE_ID = regHistorico.HISTORICO_EXP_QTDE_ID;
                        insumo.HIST_EXPORTA_QTDE_INSUMO_ID = new Acesso_Hist_Exporta_Qtde_Insumo().Inserir(Application.StartupPath + "\\", insumo);
                    }
                }
            }
        }

        private void PreencherComboVersao()
        {
            Acesso_Historico_Exporta_Qtde objNeg = new Acesso_Historico_Exporta_Qtde();
            List<Int32> listaVersao = objNeg.Buscar_Versoes(Application.StartupPath + "\\");
            if (listaVersao.Count > 0)
                ultimaVersaoHisorico = listaVersao[0];

            cbxVersao.Items.Clear();
            foreach (Int32 versao in listaVersao)
            {
                cbxVersao.Items.Add(versao);
            }
            cbxVersao.SelectedItem = ultimaVersaoHisorico;
        }

    }
}