using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_AVANCA_PSA
    {

 
        private int fPSA_ID;
        private double fPERCENT_AVANCO;
        private double fQtdeAvanco;
        private DateTime fDIA;
        private string fINFORMACAO;



        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }
        public double PERCENT_AVANCO
        {
            get { return fPERCENT_AVANCO; }
            set { fPERCENT_AVANCO = value; }
        }
        public double QTDE_AVANCO
        {
            get { return fQtdeAvanco; }
            set { fQtdeAvanco = value; }
        }
        public DateTime DIA
        {
            get { return fDIA; }
            set { fDIA = value; }
        }
        public string INFORMACAO
        {
            get { return fINFORMACAO; }
            set { fINFORMACAO = value; }
        }
        public double QTDE_REAL { get; set; }
    }

    public class PAR_PRC_INCUIR_CAUSA_EM_MASSA
    {
        public int PSAID {get;set;}
        public string CAUSA { get; set; }
    }
}

