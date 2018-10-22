using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public  class PAR_PRC_ELIMINAR_AVANCO_PSA_NOVO
    {
        public int ID_BIM { get; set; }
        public int TRANSACAO { get; set; }
        public DateTime DIA { get; set; }
        public double PERCENT_EXECUTADO { get; set; }
        public string RESULTADO { get; set; }
        public int TEM_PROJECAO { get; set; }
        public int   SOMENTE_PROJECAO { get; set; }
    }
}
