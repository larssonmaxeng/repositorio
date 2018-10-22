using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_SERVICO
    {
        public List<Servico> Inserir(string dir, Servico servico)
        {
            List<Servico> lista = new List<Servico>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
           
            
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbTransaction t = sql.FbConexao.BeginTransaction();
            sql.t = t;
            sql.ExecutarSemRetorno(System.Data.CommandType.Text,
                "  update or insert  into servico(servico, unid, complemento) values ('" +
                servico.DescServico + "'," 
                +"'"+servico.Unid + "','" +
                servico.Complemento + "')  matching (complemento) ");

            t.Commit();       
            sql.Close();
            sql.Dipose();
            return lista;
        }

        public IDictionary<string, Servico> SelecionaPorDicionario(string dir)
        {
            IDictionary<string, Servico> lista = new Dictionary<string, Servico>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT s.servico_id, " +
                                                               "       s.servico, " +
                                                               "       s.unid, " +
                                                               "       s.etapa_id, " +
                                                               "       e.etapa, " +
                                                               "       COALESCE(s.COMPLEMENTO,'')  COMPLEMENTO," +
                                                               "    COALESCE(s.ELEMENTO,'')  ELEMENTO " +
                                                               "  FROM servico s " +
                                                               " inner join etapa e on s.etapa_id = e.etapa_id " +
                                                               " where complemento is not null");
            while (fb.Read())
            {
                lista.Add(fb["COMPLEMENTO"].ToString(),
                    new Servico
                    {
                        Complemento = fb["COMPLEMENTO"].ToString(),
                        DescServico = fb["SERVICO"].ToString(),
                        ServicoId = Convert.ToInt32(fb["SERVICO_ID"]),
                        Elemento = fb["ELEMENTO"].ToString(),
                        Unid = fb["UNID"].ToString(),
                        Etapa = new ETAPA
                        {
                            ETAPA_ID = Convert.ToInt32(fb["ETAPA_ID"]),
                            ETAPA_DESCRICAO = fb["ETAPA"].ToString()
                        }
                        
                    });
            }
            sql.Close();
            sql.Dipose();
            return lista;
        }
        public List<Servico> Seleciona(string dir)
        {
            
            List<Servico> lista = new List<Servico>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT servico_id, " +
                                                               "       servico, " +
                                                               "       unid, " +
                                                               "       COALESCE(COMPLEMENTO,'') COMPLEMENTO, " +
                                                               "        COALESCE(ELEMENTO,'') ELEMENTO " +
                                                               "  FROM servico");
            while (fb.Read())
            {
                lista.Add(new Servico
                {
                    ServicoId = Convert.ToInt32(fb["SERVICO_ID"]),
                    DescServico = fb["SERVICO"].ToString(),
                    Unid = fb["UNID"].ToString(),
                    Complemento = fb["COMPLEMENTO"].ToString(),
                    Elemento = fb["ELEMENTO"].ToString()
                });

            }
            sql.Close();
            sql.Dipose();
            return lista;
        }

        public Servico SelecionaPorServico(string dir, int servicoId)
        {
            Servico servico = new Servico();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT servico_id, servico, unid  FROM servico "+ 
                                                                   " where servico_id = "+ servicoId.ToString());
            while (fb.Read())
            {



                servico.Unid =  fb["UNID"].ToString();

                sql.Close();
                sql.Dipose();
                return servico;

            }
            return null;
        }

        public int SelecionaPorComplemento(string dir, string complemento, ref string strServico)
        {
            int servicoId;
            
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT servico_id, servico, complemento  FROM servico " +
                                                                   " where complemento = '" + complemento + "'");
            while (fb.Read())
            {
                servicoId = Convert.ToInt32(fb["SERVICO_ID"]);
                strServico = fb["SERVICO"].ToString();
                sql.Close();
                sql.Dipose();
                return servicoId;
            }
            return 0;
        }

        public int InserirServico(string dir, Servico servico)
        {
            string strSql;
            object obj;
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);

            try
            {                               
                sql.t = sql.FbConexao.BeginTransaction();

                strSql = " insert  into servico(servico, unid, complemento, elemento) values ('" +
                    servico.DescServico + "'," + "'" + servico.Unid + "','" + servico.Complemento + "','" + servico.Elemento + "') returning servico_id";

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

        public Boolean AtualizarServico(string dir, Servico servico)
        {
            string strSql;
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);

            try
            {
                sql.t = sql.FbConexao.BeginTransaction();                

                strSql = "Update servico Set servico = '" + servico.DescServico + "', " +
                    "unid = '" + servico.Unid + "', " +
                    "complemento = '" + servico.Complemento + "', " +
                    "elemento = '" + servico.Elemento + "'" +
                    " Where SERVICO_ID = " + servico.ServicoId;

                sql.ExecutarSemRetorno(System.Data.CommandType.Text, strSql);

                sql.t.Commit();
                sql.Close();
                sql.Dipose();

                return true;
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return false;
            }
        }

        public Boolean ExcluirServico(string dir, Servico servico)
        {
            string strSql;
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);

            try
            {
                sql.t = sql.FbConexao.BeginTransaction();

                strSql = "Delete From servico Where servico_id = " + servico.ServicoId;

                sql.ExecutarSemRetorno(System.Data.CommandType.Text, strSql);

                sql.t.Commit();
                sql.Close();
                sql.Dipose();

                return true;
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return false;
            }
        }
    }
    
}
