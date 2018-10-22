using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_UPDATE_AMBIENTE
    {    
        public double AREA { get; set; }
        public string NOME  { get; set; }
        public string NIVEL { get; set; }
        public int BLOCO_ID { get; set; }
        public int AMBIENTE_ID_BIM { get; set; }
        public void Clear()
        {
            double? AREA = null;
            NOME = null;
            NIVEL = null;
            int? BLOCO_ID = null;
            int? AMBIENTE_ID_BIM = null;
        }
    }

}
