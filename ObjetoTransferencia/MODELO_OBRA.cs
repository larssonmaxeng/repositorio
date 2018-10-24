using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class MODELO_OBRA:ParametroBasico
    {
        [ParametroAttribute(true, false, true, "Código", 100, "")]
        public string   MODELO_GUID_ID { get; set; }
        public int OBRA_ID { get; set; }
        public string CAD   { get; set; }
        public DateTime DATA_CAD { get; set; }
        public string ALT { get; set; } 
        public DateTime DATA_ALT { get; set; }
        public string NOME_DO_ARQUIVO { get; set; }
        public string NOME_DO_PROJETO { get; set; }

    }
}
