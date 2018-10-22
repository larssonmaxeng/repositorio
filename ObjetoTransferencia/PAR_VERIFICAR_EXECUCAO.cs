using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_VERIFICAR_EXECUCAO
    {
        public int PSAID { get; set; }
        public DateTime LIMITE { get; set; }
        public int SIMULAR_AVANCO { get; set; }
        public double PERCENT_SIMULAR_AVANCO { get; set; }

        public void Clear()
        {
            int? PSAID = null;
            int? SIMULAR_AVANCO = null;
            double? PERCENT_SIMULAR_AVANCO = null;
            DateTime? LIMITE = null;
        }

    }
    public class PAR_PRC_SUB_GRAFICO
    {
        public int ETRANSACAO { get; set; }
        public string EMODELO_GUID_ID { get; set; }
        public DateTime EDATA_AVALIACAO { get; set; }
        public int INTEGER_VALUE { get; set; }
        public double PESO_REALIZADO { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime TERMINO { get; set; }

    }

}
