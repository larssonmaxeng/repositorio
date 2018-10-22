using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PLAN_SERVICO_AMO_OFFLINE
    {
        public int PLAN_SERVICO_AMO_OFFLINE_ID { get; set; }
        public int SERVICO_ID { get; set; }
        public int MEDICAO_BLOCO_ID { get; set; }
        public int AREA_ID { get; set; }
        public int AMBIENTE_ID { get; set; }
        public int GRUPO_ID { get; set; }
        public double PERCENT_EXECUTADO_ANTERIOR { get; set; }
        public double PERCENT_EXECUTADO_ATUAL { get; set; }
        
    }
}
