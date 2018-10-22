using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class ServicoOrcamento
    {
        public string usuario { get; set; }
        public double quantidade { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int empresa { get; set; }
        public string obra { get; set; }
        public int numOrcamento { get; set; }
        public string item { get; set; }
        public string servico { get; set; }
        public string codExternoIntegracao { get; set; }
    }
}
