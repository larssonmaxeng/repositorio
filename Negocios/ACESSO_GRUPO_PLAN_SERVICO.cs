using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_GRUPO_PLAN_SERVICO
    {
        /*public void DeletarGrupoInutilizados(string dir)
        {


            IDictionary<string, GRUPO_PLAN_SERVICO> listaGrupoExistente = new Dictionary<string, GRUPO_PLAN_SERVICO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;

            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();

           try
            {
                sql.ExecutarSemRetorno(System.Data.CommandType.Text,
                                                        "        delete from grupo_plan_servico gps where gps.grupo_plan_servico_id not in ( " +
                                                                  "      select " +
                                                                   "     distinct samo.grupo_plan_servico_id " +
                                                                   "      from servico_amo samo )  " +
                                                                     "    and gps.grupo_plan_servico_id not in (select distinct qms.grupo_id from qtde_mapa_servico qms)");


                sql.t.Commit();
                sql.Close();
                sql.Dipose();
            }
            catch
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
            }

        }*/

        public  List<GRUPO_PLAN_SERVICO> Selecionar (string dir)
        {
            List<GRUPO_PLAN_SERVICO> grupos = new List<GRUPO_PLAN_SERVICO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;

            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();


         
            FbDataReader fb =sql.ExecutarConsultaLista(CommandType.Text, "select distinct av.grupo_plan_servico_id, " +
                                                           "    GPS.GRUPO " +
                                                          " from arvore_avanco_fisico av " +
                                                          "  inner " +
                                                         " join grupo_plan_servico GPS on av.grupo_plan_servico_id = GPS.grupo_plan_servico_id ");

            while (fb.Read())
            {
                grupos.Add(new GRUPO_PLAN_SERVICO
                {
                    GRUPO_PLAN_SERVICO_ID = Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]),
                    GRUPO = Convert.ToString(fb["GRUPO"])
                });
            }
            return grupos;

        }

        public int SelecionaPorObraeServico(int obraId, int servicoId, string dir)
        {

            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;

            sql.Ativo(true);
            


            FbDataReader fb = sql.ExecutarConsultaLista(CommandType.Text,
                "select irgg.grupo_plan_servico_id " +
"  from serv_item_resumo_geral sirg " +
"   inner  join item_resumo_geral_grupo irgg on sirg.item_resumo_geral_grupo_id = irgg.item_resumo_geral_grupo_id " +

" inner  join grupo_plan_servico gps on irgg.grupo_plan_servico_id = gps.grupo_plan_servico_id " +
"   where sirg.servico_id = " + servicoId.ToString() +
"    and gps.obra_id = " + obraId);

            while (fb.Read())
            {
                int i = Convert.ToInt32(fb[0]);
                sql.Close();
                sql.Dipose();
                return i;
            }
            sql.Close();
            sql.Dipose();
            return -1;
           
        }


        /*public IDictionary<string, GRUPO_PLAN_SERVICO> SelecionaPorDicionario(string dir, string MODELO_GUID_ID, 
                                                                              List<ETAPA> etapaRequeridas)
        {
           IDictionary<string, GRUPO_PLAN_SERVICO> listaGrupoExistente = new Dictionary<string, GRUPO_PLAN_SERVICO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                        "        select gps.grupo_plan_servico_id, "+
                                                        "          gps.grupo "+
                                                        "   from grupo_plan_servico gps "+
                                                        "     inner join obra o on gps.obra_id = o.obra_id "+
                                                        "     inner join modelo_obra mo on o.obra_id = mo.obra_id " +
                                                        "     where mo.modelo_guid_id = '" + MODELO_GUID_ID + "'");

            while (fb.Read())
            {
                listaGrupoExistente.Add(fb["GRUPO"].ToString(),
                    new GRUPO_PLAN_SERVICO
                    {

                        GRUPO_PLAN_SERVICO_ID= Convert.ToInt32(fb["GRUPO_PLAN_SERVICO_ID"]),
                        GRUPO = fb["GRUPO"].ToString()
                    });
            }
            sql.Close();

            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            foreach (ETAPA item in etapaRequeridas)
            {
                GRUPO_PLAN_SERVICO gps = new GRUPO_PLAN_SERVICO();
                if(!listaGrupoExistente.TryGetValue(item.ETAPA_DESCRICAO, out gps))
                {
                    gps = new GRUPO_PLAN_SERVICO();
                    int id = 0;

                   object o =  sql.ExecutarManipulacao(System.Data.CommandType.Text,
                                            " SELECT grupo_plan_servico_ID FROM PRC_INSERIR_GRUPO_PLAN_SERVICO('" + item.ETAPA_DESCRICAO + "', '" + MODELO_GUID_ID + "')");
                    if(int.TryParse(o.ToString(), out id))
                    {
                        gps.GRUPO_PLAN_SERVICO_ID = id;
                        gps.GRUPO = item.ETAPA_DESCRICAO;
                        listaGrupoExistente.Add(item.ETAPA_DESCRICAO, gps);
                    }
                }
            }

            sql.t.Commit();
            sql.Close();
            sql.Dipose();

            return listaGrupoExistente;

        }*/
    }
}
