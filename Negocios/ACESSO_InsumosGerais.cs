using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoSQLServer;
using ObjetoTransferencia;


namespace Negocios
{
    class ACESSO_InsumosGeral
    {
        public List<InsumosGeral> Seleciona()
        {
            List<InsumosGeral> lista = new List<InsumosGeral>();
            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando = 
                new System.Data.SqlClient.SqlCommand("select  * from insumosGerais", sql.sqlConnection);
            System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
            while (fb.Read())
            {
                lista.Add(new InsumosGeral
                {
                    Cod_ins = fb[nameof(InsumosGeral.Cod_ins)].ToString(),
                    Descr_ins = fb[nameof(InsumosGeral.Descr_ins)].ToString()
                });
            }
            sql.Close();
            return lista;
        }
        public string ObterCodInsumo(InsumosGeral insumosGeral)
        {
            InsumosGeral ins = new InsumosGeral();
            ins = Seleciona(insumosGeral.Descr_ins);
            if (ins!=null)
            {
                return ins.Cod_ins;
            }
            else
            {
                int codigo = GetProximoRegistro();
                insumosGeral.Cod_ins = codigo.ToString();
                if(Inserir(insumosGeral))
                {
                    return codigo.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public InsumosGeral Seleciona(string descr_ins)
        {
            InsumosGeral insumoGeral = new InsumosGeral();

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("select  * from InsumosGeral where Descr_ins = '" + descr_ins+"'", sql.sqlConnection);
            System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
            while (fb.Read())
            {
                insumoGeral.Cod_ins = fb[nameof(InsumosGeral.Cod_ins)].ToString();
                insumoGeral.Descr_ins = fb[nameof(InsumosGeral.Descr_ins)].ToString();
                sql.Close();
                return insumoGeral;

            }
            sql.Close();
            return null;
        }
        public bool Inserir(InsumosGeral insumoGeral)
        {

            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("insert into InsumosGeral (Cod_ins,Descr_ins,Conf_ins,QuemCad_ins,AtInat_ins,Tvenc_ins," +
                " Compra_ins,Antec_ins,Util_ins,Est_ins," +
                        "  TPagto_ins, Categ_ins, G1G2_ins, Cap_ins, Encargo_ins, Tcompra_ins, NTVenc_ins, Tipo_ins, NCompra_ins, DtVenc_ins," +
                         " UsrAlt_ins, Patrimonio_Ins, PorServ_Ins, CapAplic_Ins, IndUtilizacaoBem_ins, CapEstorno_ins, ControlaPrecoMeta_Ins," +
                        "  ItemManutPat_Ins, CapTransacaoFin_ins) " +

                        "  values('" + insumoGeral.Cod_ins + "', '" + insumoGeral.Descr_ins + "', 0, 'ROOT', 0, 'V0001', 1, 1, 1, 1, 0, '010000P', 1, 1, 0, 'V0001', 1, 3, 1, 1, 'ROOT', 0, 0.000000, 1, 0, 1, 0, 0, 1)", sql.sqlConnection);

            try
            {
                comando.ExecuteNonQuery();

                sql.Close();
                InserirUnidade(insumoGeral.Cod_ins, insumoGeral._unid);
                return true;

            }
            catch
            {
                sql.Close();
                return false;

            }
        }
        public bool InserirUnidade(string Cod_ins, string unid)
        {
            SQLServer sql = new SQLServer();
            sql.Open();
            System.Data.SqlClient.SqlCommand comando =
                new System.Data.SqlClient.SqlCommand("insert into UnidInsumoGeral( CodIns_UnIns, CodUn_UnIns, Padrao_UnIns, DataCad_UnIns, UsrCad_UnIns  ) VALUES (" +
                                                                                                                             "'"+Cod_ins+"', '"+unid+ "', 1, CURRENT_TIMESTAMP, 'ROOT')",   sql.sqlConnection);

            try
            {
                comando.ExecuteNonQuery();
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
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand("select COALESCE( MAX( CAST(cod_ins as integer)),0)  contador  from InsumosGeral  WHERE ISNUMERIC(cod_ins)=1 ", sql.sqlConnection);
            int valor = 0;
            try
            {
                System.Data.SqlClient.SqlDataReader fb = comando.ExecuteReader();
                while (fb.Read())
                {
                   valor =  Convert.ToInt32(fb["contador"])+1;

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
