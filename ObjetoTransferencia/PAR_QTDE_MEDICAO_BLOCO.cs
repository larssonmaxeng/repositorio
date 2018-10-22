using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_QTDE_MEDICAO_BLOCO
    {
        public int BLOCO_ID { get; set; }
        public int MEDICAO_BLOCO_ID { get; set; }
        public int GRUPO_ID { get; set; }
        public int SERVICO_ID { get; set; }
        public double QTDE { get; set; }

    }
    public class PAR_QTDE_MEDICAO_BLOCO_AMBIENTE : PAR_QTDE_MEDICAO_BLOCO
    {
        public int AMBIENTE_ID { get; set; }

    }
}
