using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class Acesso_Contrato_ERP
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string strSql;
        private string strTipo_Estado_Id;
        private string strTipo_Ativo_Id;

        public List<Contrato_ERP> Listar(string dir, int contrato_Erp_Id)
        {
            Contrato_ERP regControtoERP;
            List<Contrato_ERP> lista = new List<Contrato_ERP>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select CONTRATO_ERP_ID, CONTRATO_ERP, Coalesce(FORNECEDOR_ID, 0) FORNECEDOR_ID, Coalesce(TIPO_ATIVO_ID, 0) TIPO_ATIVO_ID, " +
                "Coalesce(TIPO_ESTATO_ID, 0) TIPO_ESTATO_ID, Coalesce(CAD, '') CAD, DATA_CAD, Coalesce(ALT, '') ALT, DATA_ALT " +
                "From Contrato_Erp ";

            if (contrato_Erp_Id != 0)
                strSql += "Where CONTRATO_ERP_ID = " + contrato_Erp_Id.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regControtoERP = new Contrato_ERP();

                regControtoERP.CONTRATO_ERP_ID = Convert.ToInt32(fb["CONTRATO_ERP_ID"]);
                regControtoERP.CONTRATO_ERP = Convert.ToString(fb["CONTRATO_ERP"]);
                regControtoERP.FORNECEDOR_ID = Convert.ToInt32(fb["FORNECEDOR_ID"]);
                regControtoERP.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                regControtoERP.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                regControtoERP.CAD = Convert.ToString(fb["CAD"]);
                regControtoERP.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                regControtoERP.ALT = Convert.ToString(fb["ALT"]);
                regControtoERP.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);                
                lista.Add(regControtoERP);
            }
            sql.Close();
            return lista;
        }

        public int Inserir(string dir, Contrato_ERP regControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarCampos(regControtoERP);

            try
            {
                strSql = "Insert InTo Contrato_Erp (CONTRATO_ERP, FORNECEDOR_ID, TIPO_ATIVO_ID, TIPO_ESTATO_ID) " +
                    "Values ('" + regControtoERP.CONTRATO_ERP + "', " + regControtoERP.FORNECEDOR_ID.ToString() + ", " + strTipo_Ativo_Id + ", " + strTipo_Estado_Id + 
                    ") returning CONTRATO_ERP_ID";

                sql.t = sql.FbConexao.BeginTransaction();
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

        public Boolean Atualizar(string dir, Contrato_ERP regControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarCampos(regControtoERP);

            try
            {
                strSql = "Update Contrato_Erp Set CONTRATO_ERP = '" + regControtoERP.CONTRATO_ERP + "', " +
                    "FORNECEDOR_ID = " + regControtoERP.FORNECEDOR_ID.ToString() + ", " +
                    "B.TIPO_ESTATO_ID = " + strTipo_Estado_Id + ", " +
                    "B.TIPO_ATIVO_ID = " + strTipo_Ativo_Id +
                    " Where CONTRATO_ERP_ID = " + regControtoERP.CONTRATO_ERP_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, strSql);
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

        public Boolean Deletar(string dir, Contrato_ERP regControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "Delete From Contrato_Erp Where CONTRATO_ERP_ID = " + regControtoERP.CONTRATO_ERP_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, strSql);
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

        private void ValidarCampos(Contrato_ERP regControtoERP)
        {

            if (regControtoERP.TIPO_ATIVO_ID == 0)
                strTipo_Ativo_Id = "null";
            else
                strTipo_Ativo_Id = regControtoERP.TIPO_ATIVO_ID.ToString();

            if (regControtoERP.TIPO_ESTATO_ID == 0)
                strTipo_Estado_Id = "null";
            else
                strTipo_Estado_Id = regControtoERP.TIPO_ESTATO_ID.ToString();
        }
    }
}
