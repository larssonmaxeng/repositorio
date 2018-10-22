using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using AcessoBancoDados;
using System.Data;
using System.Windows.Forms;

namespace Negocios
{
    public class GetElementoAvancadosPorPeriodo
    {
        private AcessoBancoDados.FbsqlConnection fbsqlConnection = new FbsqlConnection();

        public GetElementoAvancadosPorPeriodo(string dir)
        {

            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
        }

        public DataTable DtElementosAvancados (string consulta)
        {
            return fbsqlConnection.ExecutarConsulta(CommandType.Text, consulta);
        }
    }
}
