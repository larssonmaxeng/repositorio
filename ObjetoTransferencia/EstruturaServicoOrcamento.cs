using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class EstruturaServicoOrcamento
    {
        public int tipoEstrutura { get; set; }
        public string codigo { get; set; }
        public double qtde { get; set; }
        public double valor { get; set; }
        public string usuario { get; set; }
        public string sequencia { get; set; }
        public int empresa { get; set; }
        public string obra { get; set; }
        public int numOrcamento { get; set; }
        public string item { get; set; }
        public string servico { get; set; }
        public string codExternoIntegracao { get; set; }      
    }
}
