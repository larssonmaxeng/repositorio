using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.Client;
using System.Data;
using AcessoBancoDados;

namespace Negocios
{
    public class ACESSO_ITEM_RESUMO_GERAL_GRUPO
    {
        public List<PAR_ITEM_RESUMO_GERAL_GRUPO> Seleciona(string dir)
        {
            List<PAR_ITEM_RESUMO_GERAL_GRUPO> lista = new List<PAR_ITEM_RESUMO_GERAL_GRUPO>();
            FbsqlConnection sql = new FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "   select item_resumo_geral_grupo_id, " +
                                                                   "    item_resumo_geral_grupo " +
                                                              "  from item_resumo_geral_grupo ");
            while (fb.Read())
            {
                lista.Add(new PAR_ITEM_RESUMO_GERAL_GRUPO
                {
                    ITEM_RESUMO_GERAL_GRUPO_ID = Convert.ToInt32(fb["ITEM_RESUMO_GERAL_GRUPO_ID"]),

                    ITEM_RESUMO_GERAL_GRUPO = fb["ITEM_RESUMO_GERAL_GRUPO"].ToString()
                });

            }

            return lista;
        }
    }
    public class ACESSO_SERVICO_AMO
    {

        public bool Desvincular(string dir, string MODELO_GUID_ID, int integer_value)
        {
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            fbsqlConnection.LimparParametros();
            try
            {
                fbsqlConnection.ExecutarSemRetorno(CommandType.Text, "delete from servico_amo samo  WHERE SAMO.MODELO_GUID_ID =  '" + MODELO_GUID_ID + "' and " +
                                                                                                        " SAMO.INTEGER_VALUE  = " + integer_value.ToString());
                fbsqlConnection.t.Commit();
                fbsqlConnection.Dipose();
                return true;
            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                return false;
            }
        }

        public List<SERVICO_AMO> Selecionar(string dir, string MODELO_GUID_ID)
        {
            List<SERVICO_AMO> lista1 = new List<SERVICO_AMO>();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            fbsqlConnection.LimparParametros();


            try
            {
                FirebirdSql.Data.FirebirdClient.FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text,
                    "  select DISTINCT samo.MODELO_GUID_ID, samo.ID_BIM, samo.servico_amo_id  from servico_amo samo  WHERE SAMO.MODELO_GUID_ID =  '" + MODELO_GUID_ID + "'");
                while (fb.Read())
                {
                    lista1.Add(new SERVICO_AMO
                    {
                        ID_BIM = fb["ID_BIM"].ToString(),
                        SERVICO_AMO_ID = Convert.ToInt32(fb["SERVICO_AMO_ID"])
                    });
                }
                return lista1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Deletar(string dir, SERVICO_AMO samo)
        {
            List<SERVICO_AMO> lista = new List<SERVICO_AMO>();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            fbsqlConnection.LimparParametros();


            try
            {
                fbsqlConnection.ExecutarSemRetorno(CommandType.Text, " delete from servico_amo samo where samo.servico_amo_id = " + samo.SERVICO_AMO_ID.ToString());
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return true;
            }
            catch
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();

                return false;
            }

        }
    }


    public class ACESSO_PLAN_SERVICO_AMO
    {
        public List<PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO> Deletar(string dir, PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO item)
        {
            List<PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO> lista = new List<PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO>();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            fbsqlConnection.LimparParametros();

            fbsqlConnection.AdicionarParametros("@TRANSACAO", item.TRANSACAO);
            fbsqlConnection.AdicionarParametros("@DIA", item.DIA);
            try
            {
                FirebirdSql.Data.FirebirdClient.FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text,
                    "select   " +
                    " coalesce(RESULTADO,'') RESULTADO,   coalesce(PERCENT_EXECUTADO,0) PERCENT_EXECUTADO," +
                    " coalesce(TEM_PROJECAO,0) TEM_PROJECAO,   coalesce(SOMENTE_PROJECAO,0) SOMENTE_PROJECAO, COALESCE(ID_BIM, 0) ID_BIM " +

                    "  from PRC_ELIMINAR_AVANCO_PSA_NOVO(@TRANSACAO, @DIA)");
                while (fb.Read())
                {
                    lista.Add(new PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO
                    {

                        RESULTADO = fb["RESULTADO"].ToString(),
                        PERCENT_EXECUTADO = Convert.ToDouble(fb["PERCENT_EXECUTADO"]),
                        //TEM_PROJECAO = Convert.ToInt32(fb["TEM_PROJECAO"]),
                        //SOMENTE_PROJECAO = Convert.ToInt32(fb["SOMENTE_PROJECAO"]),
                        ID_BIM = Convert.ToInt32(fb["ID_BIM"])
                    });


                }
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return lista;
            }
            catch (Exception e)
            {

                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                // List<PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO> listaErro = new List<PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO>();
                // listaErro.Add(new PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO { RESULTADO = e.Message})
                return null;
            }
        }               
    }
}