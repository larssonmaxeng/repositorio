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
        public int TEM_PCP_EXECUTADO { get; set; }
        public int TEM_PCP_PREVISTO { get; set; }
        public bool TEM_PROJECAO
        {
            get
            {
                if (TEM_PCP_EXECUTADO == 1)
                    return true;
                if (TEM_PCP_PREVISTO == 1)
                    return true;
                return false;
            }
        }
        public bool SOMENTE_PROJECAO
        {
            get
            {
                if(PESO_REALIZADO>0)
                {
                    if (TEM_PROJECAO) return false;
                    else return false;

                }
                else
                {
                    if (TEM_PROJECAO) return true;
                    else return false;
                }

            }
        }


    }

}
