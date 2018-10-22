using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Contrato_ERP
    {
        public int CONTRATO_ERP_ID { get; set; }
        public string CONTRATO_ERP { get; set; }
        public int FORNECEDOR_ID { get; set; }
        public int TIPO_ESTATO_ID { get; set; }
        public int TIPO_ATIVO_ID { get; set; }               
        public string CAD { get; set; }
        public DateTime DATA_CAD { get; set; }
        public string ALT { get; set; }
        public DateTime DATA_ALT { get; set; }
    }
}
