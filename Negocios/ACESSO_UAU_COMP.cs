using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoSQLServer;
using ObjetoTransferencia;

namespace Negocios
{
   public class ACESSO_COMPOSICOES
    {
        public List<Composicoes> Seleciona()
        {
            List<Composicoes> lista = new List<Composicoes>();
            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("select  * from composicoes     ", sql.sqlConnection);
            System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
            while (fb.Read())
            {
                lista.Add(new Composicoes
                {
                    Cod_comp = fb[nameof(Composicoes.Cod_comp)].ToString(),
                    Descr_comp = fb[nameof(Composicoes.Descr_comp)].ToString(),
                    Unid_comp = fb[nameof(Composicoes.Unid_comp)].ToString(),
                });
            }
            sql.Close();
            return lista;
        }
        public Composicoes Seleciona(string Descr_comp)
        {
            Composicoes composicoes = new Composicoes();

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("select  * from Composicoes where Descr_comp = '" + Descr_comp + "'", sql.sqlConnection);
            System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
            while (fb.Read())
            {
                composicoes.Cod_comp = fb[nameof(Composicoes.Cod_comp)].ToString();
                composicoes.Descr_comp = fb[nameof(Composicoes.Descr_comp)].ToString();
                sql.Close();
                return composicoes;

            }
            sql.Close();
            return null;
        }
        public string ObterCodComp(Composicoes composicoes)
        {
            Composicoes comp = new Composicoes();
            comp = Seleciona(composicoes.Descr_comp);
            if (comp != null)
            {
                return comp.Cod_comp;
            }
            else
            {
                int codigo = GetProximoRegistro();
                composicoes.Cod_comp = codigo.ToString();
                if (Inserir(composicoes))
                {
                    return codigo.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public bool Inserir(Composicoes composicoes)
        {

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("insert into Composicoes(Cod_comp,Descr_comp,Unid_comp,Prod_comp,Obrig_comp,Acab_comp,Custo_comp,Status_comp,UsrCad_comp,CivilPes_comp,AtInat_comp,Categ_comp) "+
                                                      " values('"+composicoes.Cod_comp+"', '"+composicoes.Descr_comp+"', '"+ composicoes.Unid_comp+ "', 1.000000, 0, 0, 'D', 0, 'ROOT', 0, 1,NULL)", sql.sqlConnection);

            try
            {
                comando.ExecuteNonQuery();
                InsumosGeral insumosGeral = new InsumosGeral();
                insumosGeral.Descr_ins = composicoes.Descr_comp;
                insumosGeral._unid = composicoes.Unid_comp;
                insumosGeral.Cod_ins = new ACESSO_InsumosGeral().ObterCodInsumo(insumosGeral);
                CompInsGeral compins = new CompInsGeral();
                compins.Comp_cins = composicoes.Cod_comp;
                compins.Unid_cins = composicoes.Unid_comp;
                compins.Ins_cins = insumosGeral.Cod_ins;

                new ACESSO_CompInsGeral().Inserir(compins);
               
                sql.Close();
                return true;

            }
            catch
            {
                sql.Close();
                return false;

            }
        }
        public int GetProximoRegistro()
        {

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("select  coalesce( MAX( CAST(Cod_comp as integer)),0)  contador  from Composicoes where ISNUMERIC(Cod_comp) = 1", sql.sqlConnection);
            int valor = 0;
            try
            {
                System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
                while (fb.Read())
                {
                    valor = Convert.ToInt32(fb["contador"]) + 1;

                    sql.Close();
                    return valor;
                }

                sql.Close();
                return -1;
            }
            catch
            {
                sql.Close();
                return -1;

            }
        }
    }
}
