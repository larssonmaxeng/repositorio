using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_SEMANA_PCP
    {

        private DateTime fDIA;

        public DateTime DIA
        {
            get { return fDIA; }
            set { fDIA = value; }
        }
    }
    public class PAR_SEL_MESES_DATA
    {
        public DateTime INICIO { get; set; }
        public DateTime TERMINO { get; set; }

    }

    public class PAR_GET_PROJETO_MEDICAO_BLOCO
    {
        public int ESERVICO_ID { get; set; }
        public int EMEDICAO_BLOCO_ID { get; set; }

    }
}
