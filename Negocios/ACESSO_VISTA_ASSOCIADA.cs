using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using ObjetoTransferencia;
using System.Data;

namespace Negocios
{
    public class ACESSO_VISTA_ASSOCIADA:Acesso
    {
      
       public ACESSO_VISTA_ASSOCIADA(string idir):base(idir)
        {

        }

        public List<VISTA_ASSOCIADA> Selecionar(VISTA_ASSOCIADA parametros)
        {
            parametroEntrada = parametros;
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            List<VISTA_ASSOCIADA> ilista = new List<VISTA_ASSOCIADA>();

            fbsqlConnection.Diretorio = Dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, "  select vista_associada_id, "+
                                                                                        " imagem,"+
                                                                                        " comentario,"+
                                                                                        " nuvem_revisao_id,"+
                                                                                        " tipo_ativo_id,"+
                                                                                        " tipo_estato_id,"+
                                                                                       "  integer_value "+
                                                                               "   from vista_associada  "+
                                                                                "  where nuvem_revisao_id = "+parametros.NUVEM_REVISAO_ID.ToString());
            while (fb.Read())
            { var v = new VISTA_ASSOCIADA();

                ilista.Add(FuncaoNegocio.PreencheCampo(fb, v) as VISTA_ASSOCIADA);
            }
            fbsqlConnection.t.Commit();
            fbsqlConnection.Close();
            fbsqlConnection.Dipose();
            return ilista;


        }
        public VISTA_ASSOCIADA Sincronizar(VISTA_ASSOCIADA parametros, int acao)
        {
            VISTA_ASSOCIADA item = new VISTA_ASSOCIADA();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


            fbsqlConnection.Diretorio = Dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            parametros.TIPO_DE_ACAO = acao;
            try
            {

                var acesso = new ACESSO_PARAMETROS_PROCEDURE(Dir);

                FuncaoNegocio.PreencheParametro(ref fbsqlConnection, acesso.Seleciona("CRUD_VISTA_ASSOCIADA"), parametros);

                FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, " select retorno  "+
                                                                                        "  from crud_vista_associada(@tipo_de_acao,"+
                                                                                      "  @vista_associada_id,"+
                                                                                      "  @nuvem_revisao_id,"+
                                                                                     "   @integer_value,"+
                                                                                      "  @comentario,"+
                                                                                      "  @imagem,"+
                                                                                      "  @tipo_ativo_id,"+
                                                                                      "  @tipo_estato_id)");
                while (fb.Read())
                {
                    if (parametros.TIPO_DE_ACAO == 0)
                    {
                        FuncaoNegocio.CampoPrimaryKey(typeof(VISTA_ASSOCIADA)).SetValue(parametros, Convert.ToInt32(fb[0]));


                    }
                    fbsqlConnection.t.Commit();
                    fbsqlConnection.Close();
                    fbsqlConnection.Dipose();
                    return parametros;
                }
                return null;
            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return null;
            }
        }
        public VISTA_ASSOCIADA Inserir(VISTA_ASSOCIADA parametros)
        {
            VISTA_ASSOCIADA vista = new VISTA_ASSOCIADA();
            vista = parametros;
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();

           fbsqlConnection.Diretorio = Dir;


            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {


                fbsqlConnection.AdicionarParametros("@IMAGEM", parametros.IMAGEM);

                object o = fbsqlConnection.ExecutarManipulacao(CommandType.Text,
                    "insert into vista_associada ( comentario) values (" +
                                                  "'" + parametros.COMENTARIO + "') " +
                                                  " returning vista_associada_id ");
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                vista.VISTA_ASSOCIADA_ID = Convert.ToInt32(o);
                return vista;

            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return vista;
            }
        }
        public VISTA_ASSOCIADA Atualizar(VISTA_ASSOCIADA parametros)
        {
            VISTA_ASSOCIADA vista = new VISTA_ASSOCIADA();
            vista = parametros;
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();

            fbsqlConnection.Diretorio = Dir;


            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {
                fbsqlConnection.ExecutarSemRetorno(CommandType.Text,
                    "update vista_associada "+
                        " set comentario = '" + parametros.COMENTARIO + "'"+
                        " where vista_associada_id = "+vista.VISTA_ASSOCIADA_ID.ToString());
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return vista;

            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return vista;
            }
        }
        public string InserirImagem(VISTA_ASSOCIADA parametros)
        {
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


            fbsqlConnection.Diretorio = Dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {

                
                fbsqlConnection.AdicionarParametros("@IMAGEM", parametros.IMAGEM);
             
                fbsqlConnection.ExecutarSemRetorno(CommandType.StoredProcedure, "PRC_INSERIR_VISTA_ASSOCIADA");
                string resultado;
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return "ok";

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
