using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_BLOCO
    {

        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string sqlStr;
        private string strTipo_Estado_Id;
        private string strTipo_Ativo_Id;


        public List<Bloco> Seleciona(string dir)
        {
            List<Bloco> lista = new List<Bloco>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "SELECT B.BLOCO_ID, B.BLOCO, B.OBRA_ID  FROM BLOCO B");
            while (fb.Read())
            {
                lista.Add(new Bloco
                {
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    BLOCO = fb["BLOCO"].ToString(),
                    OBRA_ID = Convert.ToInt32(fb["OBRA_ID"])
                });

            }
            sql.Close();
            return lista;
        }
        public List<Bloco> SelecionaPorMODELO_GUID(string dir, string MODELO_GUID_ID)
        {
            List<Bloco> lista = new List<Bloco>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               " SELECT B.BLOCO_ID, B.BLOCO, B.OBRA_ID  " +
                                                               " FROM BLOCO B " +
                                                               " INNER JOIN OBRA O ON B.OBRA_ID = O.OBRA_ID " +
                                                               " INNER JOIN MODELO_OBRA MO ON O.OBRA_ID = MO.OBRA_ID " +
                                                               " WHERE MO.MODELO_GUID_ID = '" + MODELO_GUID_ID + "'");
            while (fb.Read())
            {
                lista.Add(new Bloco
                {
                    BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]),
                    BLOCO = fb["BLOCO"].ToString(),
                    OBRA_ID = Convert.ToInt32(fb["OBRA_ID"])
                });

            }
            sql.Close();
            return lista;
        }
        public List<Bloco> Listar(string dir)
        {
            Bloco RegBlocoCad;
            List<Bloco> lista = new List<Bloco>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "Select B.BLOCO_ID, B.OBRA_ID, B.BLOCO, iif(B.TIPO_ESTATO_ID is null, 0, B.TIPO_ESTATO_ID) TIPO_ESTATO_ID, " +
                "iif(B.TIPO_ATIVO_ID is null, 0, B.TIPO_ATIVO_ID) TIPO_ATIVO_ID, iif(B.DATA_CAD is null, '01/01/0001', B.DATA_CAD) DATA_CAD, " +
                "iif(B.DATA_ALT is null, '01/01/0001', B.DATA_ALT) DATA_ALT, iif(B.OBS is null, '', B.OBS) OBS, coalesce(B.REPETICAO, 0) REPETICAO, B.ALT, B.CAD, " +
                "B.ORDEM, iif(B.SICRONIZADO is null, 0, B.SICRONIZADO) SICRONIZADO, iif(B.SYCRBLOCO_ID is null, 0, B.SYCRBLOCO_ID) SYCRBLOCO_ID From Bloco B ";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                RegBlocoCad = new Bloco();
                RegBlocoCad.BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]);
                RegBlocoCad.OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]);
                RegBlocoCad.BLOCO = Convert.ToString(fb["BLOCO"]);
                RegBlocoCad.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                RegBlocoCad.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                RegBlocoCad.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                RegBlocoCad.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                RegBlocoCad.OBS = Convert.ToString(fb["OBS"]);
                RegBlocoCad.REPETICAO = Convert.ToInt32(fb["REPETICAO"]);
                RegBlocoCad.ALT = Convert.ToString(fb["ALT"]);
                RegBlocoCad.CAD = Convert.ToString(fb["CAD"]);
                RegBlocoCad.ORDEM = Convert.ToInt32(fb["ORDEM"]);
                RegBlocoCad.SICRONIZADO = Convert.ToInt32(fb["SICRONIZADO"]);
                RegBlocoCad.SYCRBLOCO_ID = Convert.ToInt32(fb["SYCRBLOCO_ID"]);

                lista.Add(RegBlocoCad);
            }
            sql.Close();
            return lista;
        }

        public List<Bloco> ListarPorObra(string dir, int Obra_Id)
        {
            Bloco RegBlocoCad;
            List<Bloco> lista = new List<Bloco>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "Select B.BLOCO_ID, B.OBRA_ID, B.BLOCO, iif(B.TIPO_ESTATO_ID is null, 0, B.TIPO_ESTATO_ID) TIPO_ESTATO_ID, " +
                "iif(B.TIPO_ATIVO_ID is null, 0, B.TIPO_ATIVO_ID) TIPO_ATIVO_ID, iif(B.DATA_CAD is null, '01/01/0001', B.DATA_CAD) DATA_CAD, " +
                "iif(B.DATA_ALT is null, '01/01/0001', B.DATA_ALT) DATA_ALT, iif(B.OBS is null, '', B.OBS) OBS, coalesce(B.REPETICAO, 0) REPETICAO, B.ALT, B.CAD, " +
                "Coalesce(B.ORDEM, 0) ORDEM, iif(B.SICRONIZADO is null, 0, B.SICRONIZADO) SICRONIZADO, iif(B.SYCRBLOCO_ID is null, 0, B.SYCRBLOCO_ID) SYCRBLOCO_ID From Bloco B " +
                " Where B.OBRA_ID = " + Obra_Id.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                RegBlocoCad = new Bloco();
                RegBlocoCad.BLOCO_ID = Convert.ToInt32(fb["BLOCO_ID"]);
                RegBlocoCad.OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]);
                RegBlocoCad.BLOCO = Convert.ToString(fb["BLOCO"]);
                RegBlocoCad.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                RegBlocoCad.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                RegBlocoCad.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                RegBlocoCad.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                RegBlocoCad.OBS = Convert.ToString(fb["OBS"]);
                RegBlocoCad.REPETICAO = Convert.ToInt32(fb["REPETICAO"]);
                RegBlocoCad.ALT = Convert.ToString(fb["ALT"]);
                RegBlocoCad.CAD = Convert.ToString(fb["CAD"]);
                RegBlocoCad.ORDEM = Convert.ToInt32(fb["ORDEM"]);
                RegBlocoCad.SICRONIZADO = Convert.ToInt32(fb["SICRONIZADO"]);
                RegBlocoCad.SYCRBLOCO_ID = Convert.ToInt32(fb["SYCRBLOCO_ID"]);
                lista.Add(RegBlocoCad);
            }
            sql.Close();
            return lista;
        }

        public int Inserir(string dir, Bloco RegBlocoCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarCampos(RegBlocoCad);

            try
            {
                sqlStr = "Insert InTo Bloco (OBRA_ID, BLOCO, TIPO_ESTATO_ID, TIPO_ATIVO_ID, DATA_CAD, DATA_ALT, OBS, REPETICAO, ALT, CAD, " +
                    "ORDEM, SICRONIZADO, SYCRBLOCO_ID) " +
                    "Values (" + RegBlocoCad.OBRA_ID.ToString() + ", '" + RegBlocoCad.BLOCO + "', " +
                    strTipo_Estado_Id + ", " + strTipo_Ativo_Id + ", '" + RegBlocoCad.DATA_CAD.ToString("MM/dd/yyyy") + "', '" +
                    RegBlocoCad.DATA_ALT.ToString("MM/dd/yyyy") + "', '" + RegBlocoCad.OBS + "', " + RegBlocoCad.REPETICAO.ToString() + ", '" + RegBlocoCad.ALT + "', '" +
                    RegBlocoCad.CAD + "', " + RegBlocoCad.ORDEM.ToString() + ", " + RegBlocoCad.SICRONIZADO.ToString() + ", " + RegBlocoCad.SYCRBLOCO_ID.ToString() +
                    ") returning BLOCO_ID";

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarManipulacao(System.Data.CommandType.Text, sqlStr);
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

        public Boolean Atualizar(string dir, Bloco RegBlocoCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarCampos(RegBlocoCad);

            try
            {
                sqlStr = "Update Bloco As B Set B.OBRA_ID = " + RegBlocoCad.OBRA_ID.ToString() + "," +
                    "B.BLOCO = '" + RegBlocoCad.BLOCO + "'," +
                    "B.TIPO_ESTATO_ID = " + strTipo_Estado_Id + ", " +
                    "B.TIPO_ATIVO_ID = " + strTipo_Ativo_Id + ", " +
                    "B.DATA_CAD = '" + RegBlocoCad.DATA_CAD.ToString("MM/dd/yyyy") + "', " +
                    "B.DATA_ALT = '" + RegBlocoCad.DATA_ALT.ToString("MM/dd/yyyy") + "', " +
                    "B.OBS = '" + RegBlocoCad.OBS.Trim() + "', " +
                    "B.REPETICAO = " + RegBlocoCad.REPETICAO.ToString() + ", " +
                    "B.ALT = '" + RegBlocoCad.ALT + "', " +
                    "B.CAD = '" + RegBlocoCad.CAD + "', " +
                    "B.ORDEM = " + RegBlocoCad.ORDEM.ToString() + "," +
                    "B.SICRONIZADO = " + RegBlocoCad.SICRONIZADO.ToString() + "," +
                    "B.SYCRBLOCO_ID = " + RegBlocoCad.SYCRBLOCO_ID.ToString() +
                    " Where B.BLOCO_ID = " + RegBlocoCad.BLOCO_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, sqlStr);
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

        private void ValidarCampos(Bloco RegBlocoCad)
        {

            if (RegBlocoCad.TIPO_ATIVO_ID == 0)
                strTipo_Ativo_Id = "null";
            else
                strTipo_Ativo_Id = RegBlocoCad.TIPO_ATIVO_ID.ToString();

            if (RegBlocoCad.TIPO_ESTATO_ID == 0)
                strTipo_Estado_Id = "null";
            else
                strTipo_Estado_Id = RegBlocoCad.TIPO_ESTATO_ID.ToString();
        }

        public Boolean Deletar(string dir, Bloco RegBlocoCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Delete From Bloco Where Bloco_Id = " + RegBlocoCad.BLOCO_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, sqlStr);
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
