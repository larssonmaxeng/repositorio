using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Servico
    {
        
        public int ServicoId { get; set; }
        public string DescServico { get; set; }
        public string Unid { get; set; }
        public string Complemento { get; set; }
        public string Elemento { get; set; }
        public ETAPA Etapa { get; set; }
    }
}
