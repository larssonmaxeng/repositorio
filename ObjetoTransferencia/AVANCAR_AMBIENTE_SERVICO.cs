using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class AVANCAR_AMBIENTE_SERVICO
    {
        public int AVANCAR_AMBIENTE_SERVICO_ID {get; set;}
        public int SERVICO_ID { get; set; }// integer;
        public DateTime DIA { get; set; }//date;
        public int GRUPO_ID { get; set; }//integer;
        public int BLOCO_ID { get; set; }//integer;
        public int AMBIENTE_ID { get; set; }//integer;
        public int MEDICAO_BLOCO_ID { get; set; }//in;eger,
        public int AREA_ID { get; set; }//integer;
        public double PERCENTUAL { get; set; }//double precisio;
        public int SINCRONIZADO { get; set; }
    }
}
