using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{   public class ACESSO_MEDICAO_BLOCO
    {
        public List<MEDICAO_BLOCO> Selecionar(string dir)
        {
            List<MEDICAO_BLOCO> lista = new List<MEDICAO_BLOCO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                                " select medicao_bloco_id, " +
                                                      "  bloco_id," +
                                                     "   elevacao " +
                                               "  from medicao_bloco ");


            while (fb.Read())
            {
                lista.Add(    new MEDICAO_BLOCO
                    {

                        MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]),
                        BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                        ELEVACAO = Convert.ToDouble(fb["ELEVACAO"])

                    });
            }
            sql.Close();
            sql.Dipose();
            return lista;

        }

        public IDictionary<string, ObjetoTransferencia.MEDICAO_BLOCO> SelecionaPorDicionario(string dir, string MODELO_GUID_ID)
        {
            IDictionary<string, MEDICAO_BLOCO> lista = new Dictionary<string, MEDICAO_BLOCO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                                " select medicao_bloco_id, " +
                                                      "  bloco_id," +
                                                     "   elevacao, medicao " +
                                               "  from sel_medicao_bloco_guid( '" + MODELO_GUID_ID + "')");
                                                      
       
            while (fb.Read())
            {
                lista.Add(fb["BLOCO_ID"].ToString() + "|" + Math.Round(Convert.ToDouble(fb["ELEVACAO"]), 3)+ "|" +fb["MEDICAO"].ToString(),
                    new MEDICAO_BLOCO
                    {

                        MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]),
                        BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                        ELEVACAO = Convert.ToDouble(fb["ELEVACAO"]),
                        MEDICAO = fb["MEDICAO"].ToString()

                    });
            }
            sql.Close();
            sql.Dipose();
            return lista;

        }
    }
}
