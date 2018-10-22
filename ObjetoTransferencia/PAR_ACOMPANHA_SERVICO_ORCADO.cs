using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO
    {
        public int empresa { get; set; }

        public string obra { get; set; }

        public string servico { get; set; }

        public string item { get; set; }

        public int orcamento { get; set; }

        public string periodo { get; set; }

        public double quantidade { get; set; }

        public string usuarioLogado { get; set; }

        public string sequencia { get; set; }

        public int EOBRA_ID { get; set; }
        public DateTime EINICIO { get; set; }
        public DateTime EFIM { get; set; }
        public int AvancadoNoUAU { get; set; }
        public int AvancadoNoTocBIM{ get; set; }
        public DateTime diaRealizado { get; set; }
        public int SERVICO_ID { get; set; }
        public int MEDICAO_BLOCO_ID { get; set; }
        public int EXPORTAR_PARA_PLANEJAMENTO { get; set; }
        public string produto { get; set; }
        public string contrato { get; set; }
        
    }
   
}
