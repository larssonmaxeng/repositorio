using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_ETAPA
    {
        public List<ETAPA> SelecionaEtapaUtiizada(string dir)
        {
            List<ETAPA> lista = new List<ETAPA>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT  e.etapa_id, e.etapa, e.item " +
                                                               " from etapa e ");
            while (fb.Read())
            {
                lista.Add(new ETAPA
                {
                    ETAPA_ID = Convert.ToInt32(fb["ETAPA_ID"]),
                    ETAPA_DESCRICAO = fb["ETAPA"].ToString(),
                    ITEM = fb["ITEM"].ToString()
                });
            }
            sql.Close();
            sql.Dipose();
            return lista;
        }

        public void Inserir(string dir, ETAPA etapa)
        {

            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;


            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbTransaction t = sql.FbConexao.BeginTransaction();
            sql.t = t;

            sql.ExecutarSemRetorno(System.Data.CommandType.Text,
            " update or insert   into etapa(item, etapa) values ('" +
            etapa.ITEM + "',"
            + "'" + etapa.ETAPA_DESCRICAO+ "')  matching (item) ");

            t.Commit();
            sql.Close();
            sql.Dipose();
           
        }

        
    }
}
