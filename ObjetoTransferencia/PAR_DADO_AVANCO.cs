using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_DADO_AVANCO
    {
        public string ID_BIM { get; set; }
        public int SERVICO_ID { get; set; }
        public int GRUPO_ID { get; set; }
        public void Clear()
        {
            int? SERVICO_ID = null;
            int? GRUPO_ID = null;
            ID_BIM = null;
        }
    }
}
