using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_INSERIR_PLANEJAMENTO
    {
        public int EGRUPO_ID { get; set; }
        public int ESERVICO_ID { get; set; }
        public int EBLOCO_ID { get; set; }
        public int EMEDICAO_BLOCO_ID { get; set; }
        public int ENIVEL { get; set; }
        public int ETIPO { get; set; }
        public int EIGUALA_ANTERIOR { get; set; }
        public int ETRANSACAO { get; set; }
        public DateTime EDATA_LIMITE { get; set; }
        public int EDELETAR_ANTERIOR { get; set; }
        public int ECRITICA { get; set; }

    }
}
