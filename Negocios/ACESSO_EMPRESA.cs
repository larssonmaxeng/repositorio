using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_EMPRESA
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string sqlStr;


        public List<Empresa> Listar(string dir, int empresaId)
        {
            Empresa RegEmpresa;
            List<Empresa> lista = new List<Empresa>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "Select E.EMPRESA_ID, E.EMPRESA, iif(E.TIPO_ESTATO_ID is null, 0, E.TIPO_ESTATO_ID) TIPO_ESTATO_ID, " +
                "iif(E.TIPO_ATIVO_ID is null, 0, E.TIPO_ATIVO_ID) TIPO_ATIVO_ID, iif(E.DATA_CAD is null, '01/01/0001', E.DATA_CAD) DATA_CAD, " +
                "iif(E.DATA_ALT is null, '01/01/0001', E.DATA_ALT) DATA_ALT, E.ALT, E.CAD, " +
                "iif(E.SICRONIZADO is null, 0, E.SICRONIZADO) SICRONIZADO, iif(E.SYCREMPRESA_ID is null, 0, E.SYCREMPRESA_ID) SYCREMPRESA_ID From Empresa E ";

            if (empresaId != 0)
                sqlStr += "Where E.Empresa_Id = " + empresaId.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                RegEmpresa = new Empresa();

                RegEmpresa.EMPRESA_ID = Convert.ToInt32(fb["EMPRESA_ID"]);
                RegEmpresa.EMPRESA = Convert.ToString(fb["EMPRESA"]);
                RegEmpresa.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                RegEmpresa.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                RegEmpresa.ALT = Convert.ToString(fb["ALT"]);
                RegEmpresa.CAD = Convert.ToString(fb["CAD"]);
                RegEmpresa.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                RegEmpresa.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                RegEmpresa.SICRONIZADO = Convert.ToInt32(fb["SICRONIZADO"]);
                RegEmpresa.SYCREMPRESA_ID = Convert.ToInt32(fb["SYCREMPRESA_ID"]);
                lista.Add(RegEmpresa);
            }
            sql.Close();
            return lista;
        }
    }
}
