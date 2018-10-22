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
    public class TABELA_AMBIENTE
    {
        Plan_servico_amoNegocio _conexao;
        public TABELA_AMBIENTE(/*Plan_servico_amoNegocio conexao*/)
        {
            
        }
      /*  public void SELECIONAR(ref ObjetoTransferencia.AMBIENTES ambientes)
        {

            _conexao.fbsqlConnection.LimparParametros();
            FbDataReader fb = _conexao.fbsqlConnection.ExecutarConsultaLista(CommandType.Text,
                "SELECT  *  FROM  AMBIENTE");
            while (fb.Read())
            {
                ambientes.ambientes.Add(new PAR_INSERIR_AMBIENTE
                {
                  AMBIENTE_ID = Convert.ToInt32(fb["AMBIENTE_ID"]),
                  AMBIENTE = fb["AMBIENTE"].ToString(),
                  AMBIENTE_ID_BIM = Convert.ToInt32(fb["AMBIENTE_ID_BIM"])
                });
            }
        }*/
    }
}
