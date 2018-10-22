using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
   public class ACESSO_PLAN_SERVICO_AMO_OFFILINE
    {
        public List<PLAN_SERVICO_AMO_OFFLINE> Seleciona(string dir)
        {
            List<PLAN_SERVICO_AMO_OFFLINE> lista = new List<PLAN_SERVICO_AMO_OFFLINE>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "TO-DO");
            while (fb.Read())
            {
                lista.Add(new PLAN_SERVICO_AMO_OFFLINE
                {
                    AMBIENTE_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    SERVICO_ID = 0,// fb["BLOCO"].ToString(),
                    PLAN_SERVICO_AMO_OFFLINE_ID =0// Convert.ToInt32(fb["OBRA_ID"])
                });

            }
            sql.Close();
            return lista;
        }
    }
}
