using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Reflection;
using ObjetoTransferencia;

namespace Negocios
{
    /*public class Modelo
    {
        [Atualizacao(false, true, false)]
        public int MODELO_ID { get; set; }
        public int OBRA_ID { get; set; }
        public string MODELO_GUID { get; set; }
        public string MODELO_NOME { get; set; }
    }*/
    public class AcessoModelo:Acesso
    {

        public AcessoModelo(Type tipo) :base(tipo)
        {

            
        }
        /*public List<Modelo> Seleciona()
        {
            List<Modelo> lista = new List<Modelo>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = FuncaoNegocio.ENDERECO;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "select modelo_id, "+
                                                                                     "  obra_id,"+
                                                                                     "  modelo_guid,"+
                                                                                     "  modelo_nome "+
                                                                              "  from modelo_obra");

            while (fb.Read())
            {
                lista.Add(new Modelo
                { 
                    MODELO_GUID =fb["MODELO_GUID"].ToString(),
                    MODELO_NOME = fb["MODELO_NOME"].ToString(),
                    MODELO_ID = Convert.ToInt32(fb["MODELO_ID"]),
                    OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]),
                });

            }
            sql.Close();
            return lista;

        }*/

        public List<MODELO_OBRA> ListarModeloObra(string dir, int obraId, string modeloGuidId)
        {
            MODELO_OBRA regModeloObra;
            List<MODELO_OBRA> listaModeloObra = new List<MODELO_OBRA>();
            FirebirdSql.Data.FirebirdClient.FbDataReader fb;
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            string strSql;
            string strWhere = "";

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select MODELO_GUID_ID, OBRA_ID, COALESCE(CAD, '') CAD, COALESCE(DATA_CAD, '01/01/0001') DATA_CAD, COALESCE(ALT, '') ALT, " +
                "COALESCE(DATA_ALT, '01/01/0001') DATA_ALT, TIPO_ESTATO_ID, TIPO_ATIVO_ID " +
                "From Modelo_Obra ";

            if (obraId != 0)
                strWhere = "Where OBRA_ID = " + obraId.ToString() + " ";

            if (modeloGuidId != "")
                if (strWhere == "")
                    strWhere = "Where MODELO_GUID_ID = '" + modeloGuidId + "'";
                else
                    strWhere = "And MODELO_GUID_ID = '" + modeloGuidId + "'";

            strSql += strWhere;


            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regModeloObra = new MODELO_OBRA();
                regModeloObra.MODELO_GUID_ID = fb["MODELO_GUID_ID"].ToString();
                regModeloObra.OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]);
                regModeloObra.CAD = fb["CAD"].ToString();
                regModeloObra.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                regModeloObra.ALT = fb["ALT"].ToString();
                regModeloObra.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                regModeloObra.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                regModeloObra.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                listaModeloObra.Add(regModeloObra);
            }

            sql.Close();

            return listaModeloObra;
        }

        public void Inserir(string dir, MODELO_OBRA mb)
        {
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            
            try
            {
                sql.t = sql.FbConexao.BeginTransaction();
                sql.ExecutarSemRetorno(System.Data.CommandType.Text,
                                                                   "   insert into modelo_obra(  MODELO_GUID_ID, obra_id) " +
                                                                                      "  values( '" + mb.MODELO_GUID_ID.ToString() + "', " + mb.OBRA_ID.ToString() + ")");

                sql.t.Commit();
                sql.Close();
                sql.Dipose();
            }
            catch (Exception e)
            {
                sql.t.Rollback();
            }

        }

       /* public ResultadoConsulta Atualizar(Modelo mb)
        {

        return null;

        }*/

    }
}
