using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_FILTRA_AVANCADOS
    {
        public int EGRUPO_ID { get; set; }
        public DateTime EINICIO { get; set; }
        public DateTime ETERMINO { get; set; }
        public double ELIMITE_AVANCO { get; set; }

        public void Clear()
        {
            int? EGRUPO_ID = null;
            DateTime? EINICIO = null;
            DateTime? ETERMINO = null;
            double? ELIMITE_AVANCO = null;
        }
    }
}
