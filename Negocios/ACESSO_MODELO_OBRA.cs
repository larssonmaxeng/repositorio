using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_MODELO_OBRA
    {
        public List<MODELO_OBRA> Seleciona(string dir)
        {
            List<MODELO_OBRA> lista = new List<MODELO_OBRA>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT B.BLOCO_ID, B.BLOCO, B.OBRA_ID  FROM BLOCO B");
            while (fb.Read())
            {
               /* lista.Add(new Bloco
                {
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    BLOCO = fb["BLOCO"].ToString(),
                    OBRA_ID = Convert.ToInt32(fb["OBRA_ID"])
                });*/

            }
            sql.Close();
            return lista;
        }
        public MODELO_OBRA Inserir(string dir,MODELO_OBRA imodeloObra)
        {
            List<MODELO_OBRA> lista = new List<MODELO_OBRA>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into modelo_obra (modelo_guid_id,");
            sb.Append(" obra_id) ");
            sb.Append("values ('"+imodeloObra.MODELO_GUID_ID+"', ");
            sb.Append(imodeloObra.OBRA_ID+")");
            sql.t = sql.FbConexao.BeginTransaction();
            try
            {
                sql.ExecutarSemRetorno(System.Data.CommandType.Text,
                                                                   sb.ToString());
                sql.t.Commit();
                sql.Close();
                return imodeloObra;
            }
            catch
            {
                sql.t.Rollback();
                return null;
            }
               
        }
    }
}
