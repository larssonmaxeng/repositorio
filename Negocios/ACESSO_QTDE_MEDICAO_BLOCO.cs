using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using AcessoBancoDados;

namespace Negocios
{
    public class ACESSO_QTDE_MEDICAO_BLOCO
    {
        public Boolean apenasConfirmado;
        public ACESSO_QTDE_MEDICAO_BLOCO(Boolean iapenasConfirmado)
        {
            apenasConfirmado = iapenasConfirmado;
        }

        public List<PAR_QTDE_MEDICAO_BLOCO> Seleciona(string dir)
        {
            List<PAR_QTDE_MEDICAO_BLOCO> lista = new List<PAR_QTDE_MEDICAO_BLOCO>();
            FbsqlConnection sql = new FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            string condicao = "";
            if (apenasConfirmado) condicao = "  and gps.tipo_estato_id = gen_id(CONST_CONFIRMADO_ID,0)  ";


                FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                        "  select   " +
             " PSA.grupo_plan_servico_id grupo_id,   " +
            "  SAMO.servico_id,   " +
            "  COALESCE(SUM(SAMO.unidade_principal),0) QTDE,   " +
          "    mb.bloco_id   " +
        " FROM PLAN_SERVICO_AMO PSA   " +
          " INNER JOIN SERVICO_AMO SAMO ON PSA.servico_amo_id = SAMO.servico_amo_id   " +
          " INNER JOIN MEDICAO_BLOCO MB on SAMO.medicao_bloco_id = MB.medicao_bloco_id   " +
         "  inner join grupo_plan_servico gps on psa.grupo_plan_servico_id = gps.grupo_plan_servico_id "+

          /*"     WHERE MB.bloco_id = :ebloco_id   " +*/
            "  where PSA.filho IS NULL      " +
            condicao + 
            "  GROUP BY SAMO.servico_id, PSA.grupo_plan_servico_id,  mb.bloco_id");
            while (fb.Read())
            {
                lista.Add(new PAR_QTDE_MEDICAO_BLOCO
                {
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    GRUPO_ID = Convert.ToInt32(fb["GRUPO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]),

                    QTDE = Convert.ToDouble(fb["QTDE"].ToString())
                });

            }
            sql.Close();
            return lista;
        }
    }
}
