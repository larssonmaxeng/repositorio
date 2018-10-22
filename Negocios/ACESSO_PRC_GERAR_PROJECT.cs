using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public  class ACESSO_ITEM_RESUMO_GERAL
    {
        public List<PAR_SERV_ITEM_RESUMO_GERAL> Seleciona(string dir)
        {
            List<PAR_SERV_ITEM_RESUMO_GERAL> lista = new List<PAR_SERV_ITEM_RESUMO_GERAL>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "   select sirg.item_resumo_geral_grupo_id, " +
                                                                 "               sirg.servico_id  " +
                                                                     "    from serv_item_resumo_geral sirg ");
            while (fb.Read())
            {
                lista.Add(new PAR_SERV_ITEM_RESUMO_GERAL
                {
                    ITEM_RESUMO_GERAL_GRUPO_ID = Convert.ToInt32(fb["ITEM_RESUMO_GERAL_GRUPO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"])
                });

            }
            sql.Close();
            sql.Dipose();

            return lista;
        }
    }
    public class ACESSO_PRC_GERAR_PROJECT
    {
        public List<PAR_GERAR_MS_PROJECT> Seleciona(string dir, int obraId)
        {
            List<PAR_GERAR_MS_PROJECT> lista = new List<PAR_GERAR_MS_PROJECT>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "  select COALESCE(descricao,'') descricao," +
                                                                "      COALESCE(predecessora,'') predecessora," +
                                                               "       COALESCE(nivel,-1) NIVEL," +
                                                                "      COALESCE(bloco_id,-1) BLOCO_ID," +
                                                               "       COALESCE(grupo_plan_servico_id,-1) grupo_plan_servico_id," +
                                                               "       COALESCE(servico_id,-1) SERVICO_ID," +
                                                              "        COALESCE(medicao_bloco_id,-1) medicao_bloco_id," +
                                                             "         bloco," +
                                                                "      id," +
                                                                "        grupo, " +
                                                                 "     servico," +
                                                                 "    medicao," +
                                                                    "  ordem_bloco," +
                                                                "      ordem_medicao_bloco," +
                                                                    "  ordem_servico," +
                                                                  "    primeira_tarefa," +
                                                                    "  ultimatarefa" +
                                                              "  from prc_gerar_project(" + obraId.ToString() + ")");
            while (fb.Read())
            {
                lista.Add(new PAR_GERAR_MS_PROJECT
                {
                    DESCRICAO = fb["DESCRICAO"].ToString(),
                    PREDECESSORA = fb["predecessora"].ToString(),
                    NIVEL = Convert.ToInt32(fb["NIVEL"]),
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    GRUPO_PLAN_SERVICO_ID = Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]),
                    MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"])
                });

            }
            sql.Close();
            return lista;
        }
    }
    public class ACESSO_PRC_GERAR_PROJECT_PAV_SERV
    {
        public List<PAR_GERAR_MS_PROJECT> Seleciona(string dir, int obraId)
        {
            List<PAR_GERAR_MS_PROJECT> lista = new List<PAR_GERAR_MS_PROJECT>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "  select COALESCE(descricao,'') descricao," +
                                                                "      COALESCE(predecessora,'') predecessora," +
                                                               "       COALESCE(nivel,-1) NIVEL," +
                                                                "      COALESCE(bloco_id,-1) BLOCO_ID," +
                                                               "       COALESCE(grupo_plan_servico_id,-1) grupo_plan_servico_id," +
                                                               "       COALESCE(servico_id,-1) SERVICO_ID," +
                                                              "        COALESCE(medicao_bloco_id,-1) medicao_bloco_id," +
                                                             "         bloco," +
                                                                "      id," +
                                                                "        grupo, " +
                                                                 "     servico," +
                                                                 "    medicao," +
                                                                    "  ordem_bloco," +
                                                                "      ordem_medicao_bloco," +
                                                                    "  ordem_servico," +
                                                                  "    primeira_tarefa," +
                                                                    "  ultimatarefa" +
                                                              "  from prc_gerar_project_pav_serv(" + obraId.ToString() + ")");
            while (fb.Read())
            {
                lista.Add(new PAR_GERAR_MS_PROJECT
                {
                    DESCRICAO = fb["DESCRICAO"].ToString(),
                    PREDECESSORA = fb["predecessora"].ToString(),
                    NIVEL = Convert.ToInt32(fb["NIVEL"]),
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    GRUPO_PLAN_SERVICO_ID = Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]),
                    MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"])
                });

            }
            sql.Close();
            return lista;
        }
    }
}
