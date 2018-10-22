using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_VERIFICAR_EXECUCAO
    {
        private int fmark;
        private int fresultado;

        public int MARK
        {
            get {return fmark; }
            set {fmark = value; }
        }
        public int RESULTADO
        {
            get { return fresultado; }
            set { fresultado = value; }
        }
    }
}
