using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoSQLServer;
using ObjetoTransferencia;

namespace Negocios
{
   public class ACESSO_CompInsGeral
    {
        public bool Inserir(CompInsGeral compInsGeral)
        {

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("insert into CompInsGeral (Comp_cins,Ins_cins,Coef_cins,Tins_cins,Preco_cins,Compra_cins," +
                " Antec_cins,Util_cins,NCompra_cins,"+
                      "    Est_cins, TPagto_cins, IntExt_cins, G1G2_cins, Mao_cins, Encargo_cins, NTVenc_cins, DtVenc_cins, Tipo_cins," +
                     "     coefProd_cins, coefImProd_cins, DMT_cins, Unid_cins)" +

                     "     values" +
                    "       ('"+ compInsGeral.Comp_cins + "', '"+ compInsGeral.Ins_cins+ "', 1.01 , 0, 0, 0, 0, 0, 0, 0, 0, 'E', 0, 0, 0, 0, 0, 0, 0.000000, 0.000000, 0.000000, '"+compInsGeral.Unid_cins+"')"
                    , sql.sqlConnection);

            try
            {
                comando.ExecuteNonQuery();
                sql.Close();
                return true;

            }
            catch
            {
                sql.Close();
                return false;

            }
        }
    }
}
