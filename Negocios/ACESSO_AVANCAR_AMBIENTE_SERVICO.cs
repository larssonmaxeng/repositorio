using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
namespace Negocios
{
  public  class ACESSO_AVANCAR_AMBIENTE_SERVICO
    {
        public AVANCAR_AMBIENTE_SERVICO Inserir(string dir, AVANCAR_AMBIENTE_SERVICO par)
        {
            AVANCAR_AMBIENTE_SERVICO av = new AVANCAR_AMBIENTE_SERVICO();
            av = par;
            List<Bloco> lista = new List<Bloco>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
           FirebirdSql.Data.FirebirdClient.FbTransaction t = sql.FbConexao.BeginTransaction();
            sql.t = t;
            /*sql.AdicionarParametros("@EOBRA_ID", par.ambiente_id);
            sql.AdicionarParametros("@EINICIO", par.ambiente_id);
            sql.AdicionarParametros("@EFIM", par.ambiente_id);
            */
            object o =  sql.ExecutarDireto(System.Data.CommandType.Text, "insert into obra( obra, empresa_id ) values ('wdwqdw1',1)");
            string retorno = "sdsa";// sql.ExecutarManipulacao(System.Data.CommandType.StoredProcedure, "PRC_AVANCAR_AMBIENTE_SERVICO").ToString();
            sql.t.Commit();

            sql.Close();
            sql.Dipose();
            return av;
        }
    }
}
