using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_BIM_4D_BLOCONOVO
    {
        public void DefinirDatas(string dir, int SERVICO_ID, int GRUPO_ID, DateTime DTP_DATA_IFEC,
                                              DateTime DTP_DATA_PMP, int BLOCO_ID, int ACENDENTE)
        {

            string comando = "        select COALESCE(plan_servico_amo_id,0) plan_servico_amo_id, " +
          " COALESCE(unidade_principal,0) unidade_principal, " +
          " COALESCE(realizado,0) REALIZADO, " +
          " COALESCE(situacao,'') SITUACAO, " +
          " COALESCE(projecao,0) PROJECAO," +
           "COALESCE(inicio, '01/01/2000') INICIO," +
           "COALESCE(termino,'01/01/2000') TERMINO" +
          " from prc_bim_4d_bloconovo(" + SERVICO_ID.ToString() + "," +
                                                     GRUPO_ID.ToString() + "," +
                                                     "'" + DTP_DATA_IFEC.ToString("MM/dd/yyyy") + "'" + " ," +
                                                     "'" + DTP_DATA_PMP.ToString("MM/dd/yyyy") + "'" + " ," +
                                                     BLOCO_ID.ToString() + "," +
                                                     ACENDENTE.ToString() + ")  WHERE SITUACAO <> 'NAO INICIADO'";


            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
           
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, comando);
            
            while (fb.Read())
                {

            }
            sql.t.Commit();
            sql.Close();

        }
    }
}
