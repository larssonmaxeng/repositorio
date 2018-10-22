using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_QTDE_MAPA_SERVICO
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string sqlStr;

        public double BuscarPeso(string dir, string complemento, int marca)
        {
            double peso = 0;
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "SELECT Distinct Q.PESO " +
                "FROM SERVICO_AMO SAMO " +
                "INNER JOIN SERVICO S ON SAMO.SERVICO_ID = S.SERVICO_ID " +
                "INNER JOIN qtde_mapa_servico Q on Q.SERVICO_ID = SAMO.SERVICO_ID And SAMO.GRUPO_PLAN_SERVICO_ID = Q.GRUPO_ID " +
                "WHERE S.COMPLEMENTO = '" + complemento + "' AND " +
                "SAMO.SERVICO_AMO_ID = " + marca.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                peso = Convert.ToInt32(fb["PESO"]);                
            }
            sql.Close();
            return peso;
        }

        public List<Qtde_Mapa_Servico> BuscarComposicoesEPesoPorGrupo(string dir, string strUauComp)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Qtde_Mapa_Servico reg;
            List<Qtde_Mapa_Servico> lista = new List<Qtde_Mapa_Servico>();
            string strIn = "";

            sqlStr = "SELECT s.COMPLEMENTO, qms.QTDE_MAPA_SERVICO_ID, qms.GRUPO_ID, s.SERVICO_ID, " +
                "qms.peso / sum(qms.peso) over (partition BY QMS.grupo_id) PESO " +
                "from qtde_mapa_servico qms " +
                "inner join servico s on qms.servico_id = s.servico_id " +
                " where s.complemento in (";

            foreach (string strComp in strUauComp.Split(';'))
            {
                if (strComp == "")
                    break;

                if (strIn == "")
                    strIn = "'" + strComp + "'";
                else
                    strIn += ", '" + strComp + "'";
            }

            sqlStr += strIn + ")";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                reg = new Qtde_Mapa_Servico();
                reg.QTDE_MAPA_SERVICO_ID = Convert.ToInt32(fb["QTDE_MAPA_SERVICO_ID"]);
                reg.GRUPO_ID = Convert.ToInt32(fb["GRUPO_ID"]);
                reg.SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]);
                reg.COMPLEMENTO = fb["COMPLEMENTO"].ToString();

                double peso;
                if (fb["PESO"].ToString() == "")
                    peso = 0;
                else
                    peso = Convert.ToDouble(fb["PESO"]);

                reg.PESO = peso;
                lista.Add(reg);
            }

            sql.Close();
            return lista;
        }
    }
}
