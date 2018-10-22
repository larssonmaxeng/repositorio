using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Empresa
    {
        public int EMPRESA_ID { get; set; }
        public string EMPRESA { get; set; }
        public DateTime DATA_CAD { get; set; }
        public DateTime DATA_ALT { get; set; }
        public string ALT { get; set; }
        public string CAD { get; set; }
        public int TIPO_ESTATO_ID { get; set; }
        public int TIPO_ATIVO_ID { get; set; }
        public int SICRONIZADO { get; set; }
        public int SYCREMPRESA_ID { get; set; }
    }

}
