using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;


namespace Negocios
{  //
    public class ACESSO_GERAR_MS_PROJECT_AMBIENTE
    {
        public List<PAR_GERAR_MS_PROJECT_AMBIENTE> Seleciona(string dir)
        {
            List<PAR_GERAR_MS_PROJECT_AMBIENTE> lista = new List<PAR_GERAR_MS_PROJECT_AMBIENTE>();
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
                                                              "        COALESCE(ambiente_id,-1) ambiente_id," +



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
                                                              "  from prc_gerar_project_AMBIENTE");
            while (fb.Read())
            {
                lista.Add(new PAR_GERAR_MS_PROJECT_AMBIENTE
                {
                    DESCRICAO = fb["DESCRICAO"].ToString(),
                    PREDECESSORA = fb["predecessora"].ToString(),
                    NIVEL = Convert.ToInt32(fb["NIVEL"]),
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    GRUPO_PLAN_SERVICO_ID = Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]),
                    MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]),
                    AMBIENTE_ID = Convert.ToInt32(fb["AMBIENTE_ID"])
                });

            }
            sql.Close();
            
            return lista;
        }
    }
}
