using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using AcessoBancoDados;
using System.Data;
using wf = System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{

    public class Plan_servico_amoNegocio
    {

       public FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


        public Plan_servico_amoNegocio()
        {
        }
        public string PRC_INSERIR_PLANEJAMENTO(PAR_INSERIR_PLANEJAMENTO parametros)
        {

            try
            {
                fbsqlConnection.LimparParametros();

                fbsqlConnection.AdicionarParametros("@EGRUPO_ID", parametros.EGRUPO_ID);
                fbsqlConnection.AdicionarParametros("@ESERVICO_ID", parametros.ESERVICO_ID);
                fbsqlConnection.AdicionarParametros("@EBLOCO_ID", parametros.EBLOCO_ID);
                fbsqlConnection.AdicionarParametros("@EMEDICAO_BLOCO_ID", parametros.EMEDICAO_BLOCO_ID);
                fbsqlConnection.AdicionarParametros("@ENIVEL", parametros.ENIVEL);
                fbsqlConnection.AdicionarParametros("@ETIPO", parametros.ETIPO);
                fbsqlConnection.AdicionarParametros("@EIGUALA_ANTERIOR", parametros.EIGUALA_ANTERIOR);
                fbsqlConnection.AdicionarParametros("@ETRANSACAO", parametros.ETRANSACAO);
                fbsqlConnection.AdicionarParametros("@EDATA_LIMITE", parametros.EDATA_LIMITE);
                fbsqlConnection.AdicionarParametros("@EDELETAR_ANTERIOR", parametros.EDELETAR_ANTERIOR);

                fbsqlConnection.AdicionarParametros("@ECRITICA", parametros.ECRITICA);

                fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
                FbDataReader fb=  fbsqlConnection.ExecutarConsultaLista(CommandType.Text, "select total_projeto_servico " +
                                                           " from prc_inserir_planejamento(@egrupo_id," +
                                                          "  @eservico_id," +
                                                          "  @ebloco_id," +
                                                           " @emedicao_bloco_id," +
                                                          "  @enivel," +
                                                           " @etipo," +
                                                           " @eiguala_anterior," +
                                                          "  @etransacao," +
                                                           " @edata_limite," +
                                                           " @EDELETAR_ANTERIOR, 1, @ECRITICA)");
                while(fb.Read())
                {

                }
                fbsqlConnection.t.Commit();
                return "ok";
            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                return e.Message;
            }
            


        }
        public void PRC_INSERIR_MES_PLAN(PAR_INSERIR_MES_PLAN parametros)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@TRANSACAO", parametros.TRANSACAO);
            fbsqlConnection.AdicionarParametros("@INICIO", parametros.INICIO);
            fbsqlConnection.AdicionarParametros("@TERMINO", parametros.TERMICO);
            fbsqlConnection.AdicionarParametros("@PERCENT", parametros.PERCENT);
            fbsqlConnection.ExecutarSemRetorno(CommandType.Text, "insert into tela_mes_planejamento (" +
                                                                                                  "      transacao," +
                                                                                                "        inicio," +
                                                                                                "        termino," +
                                                                                               "         percent)" +
                                                                           " values( " +
                                                                          "  @transacao," +
                                                                          "  @inicio," +
                                                                          "  @termino," +
                                                                          "  @percent)");

        }
        public Plan_servico_amoNegocio(string dir)
        {

            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
        }
        public void AtivarPorCaminho(string Caminho)
        {
            fbsqlConnection.AtivoPorCaminho(Caminho);
        }



        public string Inserir(PAR_PLAN_SERVICO_AMO plan_servico_amo)
        {
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", plan_servico_amo.PLAN_SERVICO_AMO_ID);
                fbsqlConnection.AdicionarParametros("@SERVICO_AMO_ID", plan_servico_amo.SERVICO_AMO_ID);

                return plan_servico_amo.PLAN_SERVICO_AMO_ID.ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }



        public string SEL_UNIDADE_SERVICO(int servicoId)
        {


            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@SERVICO_ID", servicoId);
            //MessageBox.Show(fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "SEL_UNIDADE_SERVICO").ToString());
            try
            {
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "SEL_UNIDADE_SERVICO").ToString();
            }
            catch (Exception e)
            {
                wf.MessageBox.Show(e.Message);
                return e.Message;
            }



        }
        

        public DataTable SelecionarPavimento(string bloco_id)
        {


            fbsqlConnection.LimparParametros();
            try
            {
                return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select mb.medicao_bloco_id, mb.elevacao  from medicao_bloco mb where mb.bloco_id = " + bloco_id);
            }
            catch (Exception e)
            {
                wf.MessageBox.Show(e.Message);
                return null;
            }



        }


        public string DELETAR_CRONOGRAMA(PAR_DELETAR_CRONOGRAMA parametros)
        {

            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@EMEDICAO_BLOCO_ID", parametros.EMEDICAO_BLOCO_ID);
                fbsqlConnection.AdicionarParametros("@ESERVICO_ID", parametros.ESERVICO_ID);
                fbsqlConnection.AdicionarParametros("@ETIPO", parametros.ETIPO);
                fbsqlConnection.ExecutarSemRetorno(CommandType.Text, "delete from  plan_servico_amo psa " +
                                                                             " where psa.servico_amo_id in (select samo.servico_amo_id " +
                                                                                                                    " from servico_amo samo " +
                                                                                                                  "  where samo.medicao_bloco_id = @EMEDICAO_BLOCO_ID " +
                                                                                                                    "  and samo.servico_id = @ESERVICO_ID) " +
                                                                                  "    and psa.tipo = @ETIPO");
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
        public string PRC_PRC_PREENCHE_META_SQL(PAR_PRC_PREENCHE_META_SQL parametros)
        {

            try
            {
                fbsqlConnection.LimparParametros();

                fbsqlConnection.AdicionarParametros("@EGRUPO_ID", parametros.EGRUPO_ID);
                fbsqlConnection.AdicionarParametros("@ESERVICO_ID", parametros.ESERVICO_ID);
                fbsqlConnection.AdicionarParametros("@EBLOCO_ID", parametros.EBLOCO_ID);
                fbsqlConnection.AdicionarParametros("@EMEDICAO_BLOCO_ID", parametros.EMEDICAO_BLOCO_ID);
                fbsqlConnection.AdicionarParametros("@ETIPO", parametros.ETIPO);
                fbsqlConnection.AdicionarParametros("@EQTDE", parametros.EQTDE);
                fbsqlConnection.AdicionarParametros("@EINICIO", parametros.EINICIO);
                fbsqlConnection.AdicionarParametros("@ETERMINO", parametros.ETERMINO);
                fbsqlConnection.AdicionarParametros("@ECRITICA", parametros.ECRITICA);
                fbsqlConnection.ExecutarSemRetorno(CommandType.Text, "execute procedure prc_preenche_meta_sql (@egrupo_id, "
                                        + " @eservico_id,"
                                        + " @ebloco_id,"
                                        + " @emedicao_bloco_id,"
                                        + " @etipo,"
                                        + " @eqtde,"
                                        + " @einicio,"
                                        + " @etermino,"
                                        + " @ecritica)");
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }


        public DataTable PRC_EXECUTAR_DIRETO(string comandoSql)
        {
            DataTable interno = new DataTable();
            try
            {
                fbsqlConnection.LimparParametros();

                return fbsqlConnection.ExecutarConsulta(CommandType.Text, comandoSql);
            }
            catch (Exception e)
            {
                interno.Columns.Add("Resultado", typeof(string));
                interno.Rows.Add(interno.NewRow()["Resultado"] = e.Message);
                return interno;
            }
          


        }
        public void PRC_EXECUTAR_DIRETO_SEM_RETORNO(string comandoSql)
        {
           
                fbsqlConnection.LimparParametros();

               fbsqlConnection.ExecutarSemRetorno(CommandType.Text, comandoSql);
          
        }
        /* public DataTable PRC_SEL_DADOS_PSA_ID(PAR_SEL_DADOS_PSA_ID parametros)
         {
             fbsqlConnection.LimparParametros();
             fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
             return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from PRC_SEL_DADOS_PSA_ID(@PSA_ID)");

         }*/
        public DataTable PRC_VERIFICAR_DADOS_PSA_ID(PAR_VERIFICAR_DADOS_PSA_ID parametros)
        {

            fbsqlConnection.LimparParametros();
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "SELECT PSA.plan_servico_amo_id, SAMO.id_bim, SAMO.servico_id  " +
                                                                                                               "   FROM PLAN_SERVICO_AMO PSA  " +
                                                                                                                "   INNER JOIN SERVICO_AMO SAMO ON PSA.servico_amo_id = SAMO.servico_amo_id  " +
                                                                                                               "    INNER JOIN medicao_bloco MB ON SAMO.medicao_bloco_id = MB.medicao_bloco_id  " +
                                                                                                               "    INNER JOIN BLOCO B ON MB.bloco_id = B.bloco_id  " +
                                                                                                              "     WHERE B.obra_id =" + parametros.OBRA_ID.ToString() +
                                                                                                              "     AND PSA.filho IS null");

        }

        public DataTable SEL_MESES_DATA(PAR_SEL_MESES_DATA parametros)
        {

            fbsqlConnection.LimparParametros();
            // fbsqlConnection.AdicionarParametros("@ID_BIM", parametros.ID_BIM);
            // fbsqlConnection.AdicionarParametros("@SERVICO_ID", parametros.SERVICO_ID);
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from PRC_VERIFICAR_DADOS_PSA_ID(@ID_BIM, @SERVICO_ID)");

        }
        public DataTable GET_PROJETO_MEDICAO_BLOCO(PAR_GET_PROJETO_MEDICAO_BLOCO parametros)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@ESERVICO_ID", parametros.ESERVICO_ID);
            fbsqlConnection.AdicionarParametros("@EMEDICAO_BLOCO_ID", parametros.EMEDICAO_BLOCO_ID);
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from GET_PROJETO_MEDICAO_BLOCO (@ESERVICO_ID, @EMEDICAO_BLOCO_ID)");

        }


        public DataTable GET_TOTAL_MEDICAO_BLOCO(PAR_SEL_MESES_DATA parametros)
        {

            fbsqlConnection.LimparParametros();
            //fbsqlConnection.AdicionarParametros("@ID_BIM", parametros.ID_BIM);
            //fbsqlConnection.AdicionarParametros("@SERVICO_ID", parametros.SERVICO_ID);
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from PRC_VERIFICAR_DADOS_PSA_ID(@ID_BIM, @SERVICO_ID)");

        }


        public string PRC_FECHAR_PCP(PAR_FECHAR_PCP parametros)
        {
            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@ENOVO_TERMINO", parametros.ENOVO_TERMINO);
            fbsqlConnection.AdicionarParametros("@EPSA_ID", parametros.EPSA_ID);
            fbsqlConnection.AdicionarParametros("@EPERCENT", parametros.EPERCENT);
            return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_FECHAR_PCP").ToString();
        }
        public DataTable PRC_EXCLUIR_CAUSA(PAR_EXCLUIR_CAUSA parametros)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@CAUSA_CRITERIO_ID", parametros.CAUSA_CRITERIO_ID);
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from PRC_EXCLUIR_CAUSA(@CAUSA_CRITERIO_ID)");

        }

    

        public DataTable PRC_INCLUIR_CAUSA(PAR_INCLUIR_CAUSA parametros)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@CRITERIO_PLAN_SERVICO_AMO_ID", parametros.CRITERIO_PLAN_SERVICO_AMO_ID);
            fbsqlConnection.AdicionarParametros("@DESCRICAO_CAUSA", parametros.DESCRICAO_CAUSA);
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, "select * from PRC_INCLUIR_CAUSA(@CRITERIO_PLAN_SERVICO_AMO_ID, @DESCRICAO_CAUSA)");

        }
        public object PRC_ATUALIZAR_LEVEL(PAR_ATUALIZAR_LEVEL parametros)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", parametros.BIM_ID);
            fbsqlConnection.AdicionarParametros("@DESCRICAO", parametros.MEDICAO);
            fbsqlConnection.AdicionarParametros("@SERVICO_ID", parametros.BLOCO_ID);
            fbsqlConnection.AdicionarParametros("@ELEVACAO", parametros.ELEVACAO);
            return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_ATUALIZAR_LEVEL").ToString();







        }


        public string prc_DELETAR_PSA(PAR_DELETAR_PSA parametros)
        {


            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
            try
            {
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_DELETAR_PSA").ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string PRC_PCP_PSA(PAR_PCP_PSA parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@PERCENT_PCP", parametros.PERCENT_PCP);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_PCP_PSA").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message + "\n " + parametros.PSA_ID + "\n " +
                                                parametros.INFORMACAO + "\n " +
                                                parametros.PERCENT_PCP + "\n ";

            }

        }
        public string PRC_PCP_PSA_PROGRAMADO(PAR_PCP_PSA parametros, Boolean transacaoAutomatica)
        {
            try
            {

                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@PERCENT_PCP", parametros.PERCENT_PCP);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_PCP_PSA_PROGRAMADO").ToString();
            }
            catch (Exception exception)
            {

                return exception.Message + "\n " + parametros.PSA_ID + "\n " +
                                                parametros.INFORMACAO + "\n " +
                                                parametros.PERCENT_PCP + "\n ";

            }

        }
        public string PRC_LOOKAHEAD(PAR_PROJECAO_PSA_POR_DIA parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {

                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@PERCENT_META", parametros.PERCENT_META);
                fbsqlConnection.AdicionarParametros("@INICIO", parametros.INICIO);
                fbsqlConnection.AdicionarParametros("@TERMINO", parametros.TERMINO);
                fbsqlConnection.AdicionarParametros("@CRITERIO", 1);

                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_PROJECAO_PSA_POR_DIA").ToString();
            }
            catch (Exception exception)
            {
                return exception.Message;

            }

        }

        public DataTable PRC_AVANCAR_PSA(PAR_AVANCA_PSA parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@PERCENT_AVANCO", parametros.PERCENT_AVANCO);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                fbsqlConnection.AdicionarParametros("@QTDE_REAL", parametros.QTDE_REAL);
                return fbsqlConnection.ExecutarConsulta(CommandType.StoredProcedure, "PRC_AVANCAR_PSA");
            }
            catch (Exception exception)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Resultado", typeof(string));
                DataRow dr = dt.NewRow();
                dr[0] = exception.Message;
                dt.Rows.Add(dr);
                return dt;

            }

        }
        public DataTable PRC_INSERIR_CAUSA_EM_MASSA(PAR_PRC_INCUIR_CAUSA_EM_MASSA parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@CAUSA", parametros.CAUSA);
                fbsqlConnection.AdicionarParametros("@PSAID", parametros.PSAID);

                return fbsqlConnection.ExecutarConsulta(CommandType.StoredProcedure, "PRC_INSERIR_CAUSA_EM_MASSA");
            }
            catch (Exception exception)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Resultado", typeof(string));
                DataRow dr = dt.NewRow();
                dr[0] = exception.Message;
                dt.Rows.Add(dr);
                return dt;

            }

        }

        public DataTable GET_SITUACAO_ELEMENTO(PAR_VERIFICAR_EXECUCAO parametros)
        {
            DataTable dt;
            try
            { fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSAID", parametros.PSAID);
                fbsqlConnection.AdicionarParametros("@LIMITE", parametros.LIMITE);
                fbsqlConnection.AdicionarParametros("@SIMULAR_AVANCO", parametros.SIMULAR_AVANCO);
                fbsqlConnection.AdicionarParametros("@PERCENT_SIMULAR_AVANCO", parametros.PERCENT_SIMULAR_AVANCO);
                return fbsqlConnection.ExecutarConsulta(CommandType.Text, "SELECT * FROM GET_SITUACAO_ELEMENTO(@PSAID, @LIMITE,@SIMULAR_AVANCO, @PERCENT_SIMULAR_AVANCO)");
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public void SELECIONAR(ref ObjetoTransferencia.AMBIENTES ambientes)
        {

            fbsqlConnection.LimparParametros();
          //  fbsqlConnection.AdicionarParametros("@FILTRO", 0);
            FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text,
                "SELECT AMBIENTE_ID,  AMBIENTE,  AMBIENTE_ID_BIM  FROM  AMBIENTE");
            while (fb.Read())
            {
                ambientes.ambientes.Add(new PAR_INSERIR_AMBIENTE
                {
                    AMBIENTE_ID = Convert.ToInt32(fb["AMBIENTE_ID"]),
                    AMBIENTE = fb["AMBIENTE"].ToString(),
                    AMBIENTE_ID_BIM = Convert.ToInt32(fb["AMBIENTE_ID_BIM"])
                });
            }
        }
        public DataTable GET_SITUACAO_ELEMENTO1(PAR_VERIFICAR_EXECUCAO parametros)
        {
            DataTable dt;
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSAID", parametros.PSAID);
                fbsqlConnection.AdicionarParametros("@LIMITE", parametros.LIMITE);
                return fbsqlConnection.ExecutarConsulta(CommandType.Text, "SELECT * FROM GET_SITUACAO_ELEMENTO1(@PSAID, @LIMITE)");
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public  List<PAR_PRC_SUB_GRAFICO>  PRC_SUB_GRAFICO1(PAR_PRC_SUB_GRAFICO parametros)
        {
            List<PAR_PRC_SUB_GRAFICO> lista = new List<PAR_PRC_SUB_GRAFICO>();
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@ETRANSACAO", parametros.ETRANSACAO);
                fbsqlConnection.AdicionarParametros("@EMODELO_GUID_ID", parametros.EMODELO_GUID_ID);
                fbsqlConnection.AdicionarParametros("@EDATA_AVALIACAO", parametros.EDATA_AVALIACAO);
                //fbsqlConnection.AdicionarParametros("@ETERMINO", parametros.ETERMINO);
                //fbsqlConnection.AdicionarParametros("@TRANSACAO", parametros.ETRANSACAO);
                /*FbDataReader fb =  fbsqlConnection.ExecutarConsultaLista(CommandType.Text, "select plan_servico_amo_id, " +
                                                                                                "   unidade_principal, " +
                                                                                                "   realizado, " +
                                                                                            "    situacao, " +
                                                                                                "   projecao, " +
                                                                                                "   inicio, " +
                                                                                            "    termino, " +
                                                                                                "    meta, " +
                                                                                            "    percent_realizado, " +
                                                                                            "    somente_projecao, " +
                                                                                                "   tem_projecao, " +
                                                                                                "   coalesce(critica,0) critica , BIM_ID "+
                                                                                                " from prc_sub_grafico(@eservico_id,     @egrupo_plan_servico_id, @edata_avaliacao, @etermino, @transacao)");
               */
                FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, 
                    "select INTEGER_VALUE, "+
                    " COALESCE(PESO_REALIZADO,0) PESO_REALIZADO, "+
                    " INICIO, "+
                    " TERMINO  "+
                    "  from PRC_SUB_GRAFICO_NOVO(@etransacao, @emodelo_guid_id, @edata_avaliacao)");

                while (fb.Read())
                {
                     PAR_PRC_SUB_GRAFICO P = new PAR_PRC_SUB_GRAFICO();
                    
                    
                    if (fb["INTEGER_VALUE"] != null)
                        P.INTEGER_VALUE = Convert.ToInt32(fb["INTEGER_VALUE"]);
                    if (fb["PESO_REALIZADO"] != null)
                        P.PESO_REALIZADO= Convert.ToDouble(fb["PESO_REALIZADO"]);
                    if (P.PESO_REALIZADO > 0)
                    {
                        P.INICIO = Convert.ToDateTime(fb["INICIO"]);
                        P.TERMINO = Convert.ToDateTime(fb["TERMINO"]);
                    }
                    lista.Add(P);
                    
                }
                return lista;

            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public DataTable PRC_FILTRA_AVANCADOS(PAR_FILTRA_AVANCADOS parametros)
        {
            DataTable dt;
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@EGRUPO_ID", parametros.EGRUPO_ID);
                fbsqlConnection.AdicionarParametros("@EINICIO", parametros.EINICIO);
                fbsqlConnection.AdicionarParametros("@ETERMINO", parametros.ETERMINO);
                fbsqlConnection.AdicionarParametros("@ELIMITE_AVANCO", parametros.ELIMITE_AVANCO);

                return fbsqlConnection.ExecutarConsulta(CommandType.Text, "    select dia, " +
                                                                          "       plan_servico_amo_id " +
                                                                          " from prc_filtra_avancados(@egrupo_id," +
                                                                          "  @einicio," +
                                                                          "  @etermino," +
                                                                          "  @elimite_avanco)");
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public void PRC_SUBIDOS(PAR_PRC_SUBIDOS parametros, ref ObjetoTransferencia.LISTA_PRC_SUBIDOS tabelaSubidos)
        {

            fbsqlConnection.LimparParametros();
            fbsqlConnection.AdicionarParametros("@ETRANSACAO", parametros.ETRANSACAO);
            FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, 
                "SELECT  *  FROM  PRC_SUBIDOS(@ETRANSACAO)");
            while (fb.Read())
            {
                if (fb["PSA_ID"] != null)
                {
                    tabelaSubidos.tabelaSubidos.Add(new PAR_PRC_SUBIDOS
                    {
                        PSA_ID = Convert.ToInt32(fb["PSA_ID"]),
                        TIPO = Convert.ToInt32(fb["TIPO"])
                    });
                }

            }
        }

        public List<CAUSA_PCP>  SEL_CAUSA_PCP()
        {
            List<CAUSA_PCP> lista = new List<CAUSA_PCP>();

            fbsqlConnection.LimparParametros();
            FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text,
                "select causa_pcp_id, "+
                                       "causa," +
                                       "controlavel," +
                                       "tipo_ativo_id," +
                                       "tipo_estato_id," +
                                       "cad," +
                                       "data_cad," +
                                       "alt," +
                                       "data_alt" +
                       "         from causa_pcp");
            
            while (fb.Read())
            {
                lista.Add(new CAUSA_PCP
                {
                    CAUSA_PCP_ID = Convert.ToInt32(fb[0]),
                    CAUSA = fb[1].ToString(),
                    CONTROLAVEL = Convert.ToInt32( fb[2])

                });
            }
            return lista;
        }


        public string prc_SEMANA_PCP(PAR_SEMANA_PCP parametros)
        {
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@EDIA", parametros.DIA);
                fbsqlConnection.AdicionarParametros("@EPSA_ID", 0);               
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "SEMANA_PCP").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message ;
            }

        }

        public string PRC_AVANCAR_PSA_ELE_VINCULADO_ (PAR_AVANCA_PSA parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@QTDE_AVANCO", parametros.QTDE_AVANCO);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_AVANCAR_PSA_ELE_VINCULADO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;
               

            }

        }

        public string PRC_PCP_PSA_ELE_VINCULADO_(PAR_PCP_PSA_ELE_VINCULADO parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@QTDE_PCP_GLOBAL", parametros.QTDE_PCP_GLOBAL);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_PCP_PSA_ELE_VINCULADO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }
        public string PRC_INSERIR_AMBIENTE(PAR_UPDATE_AMBIENTE parametros)
        {
            try
            {   fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@AMBIENTE_ID_BIM", parametros.AMBIENTE_ID_BIM);
                fbsqlConnection.AdicionarParametros("@AREA", parametros.AREA);

                fbsqlConnection.AdicionarParametros("@NIVEL", parametros.NIVEL);
                fbsqlConnection.AdicionarParametros("@NOME", parametros.NOME);
                fbsqlConnection.AdicionarParametros("@BLOCO_ID", parametros.BLOCO_ID);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_INSERIR_AMBIENTE").ToString();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string PRC_META_PSA_ELE_VINCULADO_(PAR_META_PSA_ELE_VINCULADO parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@QTDE_META_GLOBAL", parametros.QTDE_META_GLOBAL);
                fbsqlConnection.AdicionarParametros("@DIA", parametros.DIA);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_META_PSA_ELE_VINCULADO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }


      

        public string PRC_ALTERA_SERVICO_AMO (int plan_servico_amo_id, int servico_novo_id, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", plan_servico_amo_id);
                fbsqlConnection.AdicionarParametros("@SERVICO_NOVO_ID", servico_novo_id);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_ALTERA_SERVICO_AMO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }

        public string prc_DEFERIR_AVANCO_PROJECAO(PAR_DEFERIR_AVANCO_PROJECAO parametros )
        {
            try
            {

                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                fbsqlConnection.AdicionarParametros("@TIPO", parametros.TIPO);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_DEFERIR_AVANCO_PROJECAO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }

        public string prc_TEM_PROJECAO(PAR_TEM_PROJECAO parametros)
        {
            try
            {

                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros.PSA_ID);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_TEM_PROJECAO").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }


        public string PRC_ALTERA_UM_PSA(int plan_servico_amo_id, int medicao_bloco_id, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", plan_servico_amo_id);
                fbsqlConnection.AdicionarParametros("@MEDICAO_BLOCO_ID", medicao_bloco_id);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_ALTERA_UM_PSA").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;


            }

        }

        public string PRC_EXCLUIR_PSA_COM_FILHOS(PAR_PLAN_SERVICO_AMO parametros, Boolean transacaoAutomatica)
        {
            try
            {
                if (transacaoAutomatica)
                { 
                
                }
                else
                {
                    //  transacaoPRC_AVANCAR_PSA = fbsqlConnection.FbConexao.BeginTransaction();
                }
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PSA_ID", parametros);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "PRC_EXCLUIR_PSA_COM_FILHOS").ToString();


            }
            catch (Exception exception)
            {
                return exception.Message;
            
            }

        }
        public string Alterar(PAR_PLAN_SERVICO_AMO plan_servico_amo)
        {
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@SERVICO_AMO_ID", plan_servico_amo.SERVICO_AMO_ID);
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", plan_servico_amo.PLAN_SERVICO_AMO_ID);
                return fbsqlConnection.ExecutarManipulacao(CommandType.StoredProcedure, "UP_PLAN_SERVICO_AMO").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string Excluir(PAR_PLAN_SERVICO_AMO plan_servico_amo)
        {
            try
            {
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", plan_servico_amo.PLAN_SERVICO_AMO_ID);
                return fbsqlConnection.ExecutarManipulacao(CommandType.Text, "DELETE FROM PLAN_SERVICO_AMO WHERE PLAN_SERVICO_AMO_ID = @PLAN_SERVICO_AMO_ID").ToString();

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public PLAN_SERVICO_AMOColecao ConsultarPorId(int PLAN_SERVICO_AMO_ID)
        {
            try
            {
                PLAN_SERVICO_AMOColecao plan_servico_amocolecao = new PLAN_SERVICO_AMOColecao();
                fbsqlConnection.LimparParametros();
                fbsqlConnection.AdicionarParametros("@PLAN_SERVICO_AMO_ID", PLAN_SERVICO_AMO_ID);
                DataTable dataTablePLAN_SERVICO_AMO = fbsqlConnection.ExecutarConsulta(CommandType.StoredProcedure, "sel_plan_servico_amo_id");
                foreach (DataRow linha in dataTablePLAN_SERVICO_AMO.Rows)
                {
                    PAR_PLAN_SERVICO_AMO plan_servico_amo = new PAR_PLAN_SERVICO_AMO();
                    plan_servico_amo.PLAN_SERVICO_AMO_ID = Convert.ToInt32(linha["PLAN_SERVICO_AMO_ID"]);
                    plan_servico_amo.SERVICO_AMO_ID = Convert.ToInt32(linha["SERVICO_AMO_ID"]);
                    plan_servico_amo.GRUPO_PLAN_SERVICO_ID = Convert.ToInt32(linha["GRUPO_PLAN_SERVICO_ID"]);
                    plan_servico_amocolecao.Add(plan_servico_amo);                   
                }
                return plan_servico_amocolecao;
            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possível localizar o elemento:"+exception.Message);
            }
        }      
    }
}
