using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class Acesso_Hist_Exporta_Qtde_Insumo
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string strSql;

        public int Inserir(string dir, Hist_Exporta_Qtde_Insumo regHistoricoInsumo)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "INSERT INTO HIST_EXPORTA_QTDE_INSUMO(HISTORICO_EXPORTA_QTDE_ID, INSUMO_ID, INSUMO) " +
                    "VALUES(" + regHistoricoInsumo.HISTORICO_EXPORTA_QTDE_ID.ToString() + ", " + regHistoricoInsumo.INSUMO_ID.ToString() + ", '" + 
                    regHistoricoInsumo.INSUMO + "' ) Returning HIST_EXPORTA_QTDE_INSUMO_ID";

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarManipulacao(System.Data.CommandType.Text, strSql);
                sql.t.Commit();
                sql.Close();
                sql.Dipose();
                return Convert.ToInt32(obj.ToString());
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return 0;
            }
        }

        public List<Hist_Exporta_Qtde_Insumo> Listar(string dir, int HISTORICO_EXPORTA_QTDE_ID)
        {
            string strSqlWhere = null;
            Hist_Exporta_Qtde_Insumo regHistoricoInsumo;
            List<Hist_Exporta_Qtde_Insumo> lista = new List<Hist_Exporta_Qtde_Insumo>();

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select HIST_EXPORTA_QTDE_INSUMO_ID, HISTORICO_EXPORTA_QTDE_ID, INSUMO_ID, INSUMO, coalesce(DATA_CAD, '01/01/0001') DATA_CAD, coalesce(DATA_ALT, '01/01/0001') DATA_ALT, CAD, ALT  " +
                "From HIST_EXPORTA_QTDE_INSUMO ";

            if (HISTORICO_EXPORTA_QTDE_ID != 0)
                strSqlWhere += "Where HISTORICO_EXPORTA_QTDE_ID = " + HISTORICO_EXPORTA_QTDE_ID.ToString();

            if (!string.IsNullOrEmpty(strSqlWhere))
                strSql += strSqlWhere;


            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regHistoricoInsumo = new Hist_Exporta_Qtde_Insumo();
                regHistoricoInsumo.HIST_EXPORTA_QTDE_INSUMO_ID = Convert.ToInt32(fb["HIST_EXPORTA_QTDE_INSUMO_ID"]);
                regHistoricoInsumo.HISTORICO_EXPORTA_QTDE_ID = Convert.ToInt32(fb["HISTORICO_EXPORTA_QTDE_ID"]);
                regHistoricoInsumo.INSUMO_ID = Convert.ToInt32(fb["INSUMO_ID"]);
                regHistoricoInsumo.INSUMO = Convert.ToString(fb["INSUMO"]);
                
                lista.Add(regHistoricoInsumo);
            }
            sql.Close();
            return lista;
        }
    }
}
