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
    public class ACESSO_NUVEM_REVISAO:Acesso
    {
        public ACESSO_NUVEM_REVISAO(string idir):base(idir)
        {

        }
        public List<NUVEM_REVISAO> Selecionar(NUVEM_REVISAO parametros)
        {
            parametroEntrada = parametros;
            List<NUVEM_REVISAO> lista = new List<NUVEM_REVISAO>();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();
            fbsqlConnection.Diretorio = Dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {


 

               FbDataReader FB = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, "   select nuvem_revisao_id, "+
                                                                            "  numero_da_revisao,"+
                                                                            "  data_da_revisao,"+
                                                                            "  comentario,"+
                                                                            "  modelo_guid_id,"+
                                                                            "  integer_value,"+
                                                                            "  tipo_estato_id,"+
                                                                             " tipo_ativo_id,"+
                                                                             " revisao  "+
                                                                     "  from nuvem_revisao "+
                                                                    "   WHERE  modelo_guid_id ='" + parametros.MODELO_GUID_ID+"'");
                string resultado;


                while(FB.Read())
                {
                    lista.Add(FuncaoNegocio.PreencheCampo(FB, new NUVEM_REVISAO()) as NUVEM_REVISAO);
                }
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();



                return lista;

            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return null;
            }
        }
        public NUVEM_REVISAO Sincronizar(NUVEM_REVISAO parametros, int acao)
        {
            NUVEM_REVISAO item = new NUVEM_REVISAO();
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


            fbsqlConnection.Diretorio = Dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            parametros.TIPO_DE_ACAO = acao;
            try
            {

                var acesso = new ACESSO_PARAMETROS_PROCEDURE(Dir);

                FuncaoNegocio.PreencheParametro(ref fbsqlConnection, acesso.Seleciona("CRUD_NUVEM_REVISAO"), parametros);

                FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.Text, "     select resultado " +
                                                    " from crud_nuvem_revisao(@nuvem_revisao_id," +
                                                   "  @numero_da_revisao," +
                                                    "  @data_da_revisao," +
                                                    "  @comentario," +
                                                   "  @modelo_guid_id," +
                                                    "  @integer_value," +
                                                    "  @tipo_estato_id," +
                                                    "  @tipo_ativo_id," +
                                                   "   @revisao," +
                                                   "   @tipo_de_acao)");
                while (fb.Read())
                {

                    //parametros =  FuncaoNegocio.PreencheCampo(fb, parametros) as NUVEM_REVISAO;
                    if (parametros.TIPO_DE_ACAO == 0)
                    {
                        FuncaoNegocio.CampoPrimaryKey(typeof(NUVEM_REVISAO)).SetValue(parametros, Convert.ToInt32(fb[0]));


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
    }
}
