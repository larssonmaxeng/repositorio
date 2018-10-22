using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class LISTA_PRC_SUBIDOS
    {
        public List<PAR_PRC_SUBIDOS> tabelaSubidos = new List<PAR_PRC_SUBIDOS>();
    }
    public class PAR_PRC_SUBIDOS
    {
        public int PSA_ID { get; set; }
        public int TIPO { get; set; }

        public int EGRUPO_PLAN_SERVICO_ID { get; set; }
        public string EGRUPOS { get; set; }
        public int ETRANSACAO { get; set; }
    }
 

}
