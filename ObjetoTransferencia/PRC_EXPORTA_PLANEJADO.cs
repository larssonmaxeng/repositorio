using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_EXPORTA_PLANEJADO
    {
        public string cob_obr { get; set; }// varchar(6),
        public int etipo_planejamento { get; set; }// integer)
        public string obra { get; set; }// varchar(5),
        public int orcamento { get; set; }// integer,
        public string item { get; set; }// varchar(50),
        public string codigo { get; set; }// varchar(10),

        public string servico { get; set; }// varchar(10),
        public string descricao { get; set; }//  varchar(250),
        public string tipoqtde { get; set; }//  char (1),
        public DateTime periodo { get; set; }// date,
        public double qtde { get; set; }// double precision,
        public double qtde_mes { get; set; }// double precision,
        public DateTime mes { get; set; }
        public string coluna { get; set; }// varchar(100),

        public string status { get; set; }// varchar(100),
        public string sequencia { get; set; }// varchar(250)
    }
}
