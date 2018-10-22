using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_DADOS_EM_MASSA
    {
        public ResultadoAcesso InserirEmMassa(string dir, List<string> sb)
        {

            ResultadoAcesso resultadoAcesso = new ResultadoAcesso();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FbTransaction t = sql.FbConexao.BeginTransaction();
            sql.t = t;
            
            foreach (string item in sb)
            {
                try
                {
                    sql.ExecutarDireto(System.Data.CommandType.Text, item);
                }
                catch (Exception e)
                {
                    ItemResultado itemResultado = new ItemResultado();
                    itemResultado.IDdoElemento = sb.IndexOf(item);
                    itemResultado.ErroDoElemento = e.Message + "|"+item;
                    resultadoAcesso.ResultadoPorItem.Add(itemResultado);
                }

            }
            
                    

               

            t.Commit();
            sql.Close();
            return resultadoAcesso;
        }
        public bool DeletarDadosEmMassa(string dir, int transacao)
        {
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FbTransaction t = sql.FbConexao.BeginTransaction();
            sql.t = t;



            sql.ExecutarDireto(System.Data.CommandType.Text,
              "delete from dados_em_massa d where d.transacao = "+transacao.ToString());

            t.Commit();
            sql.Close();
            return true;
        }
    }
}

