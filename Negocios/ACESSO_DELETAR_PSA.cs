using System;

using ObjetoTransferencia;

using System.Data;



namespace Negocios
{
    public class ACESSO_DELETAR_PSA
    {
        public string Deletar1(string dir, PAR_DELETAR_PSA parametros)
        {
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {
                fbsqlConnection.AdicionarParametros("@descricao", parametros.PSA_ID);  
                fbsqlConnection.ExecutarSemRetorno(CommandType.StoredProcedure, "PRC_DELETAR_PSA");
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return parametros.PSA_ID.ToString();
               
            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return e.Message;
            }

        }

    }
}
