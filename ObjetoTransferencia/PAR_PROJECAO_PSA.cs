using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_PCP_PSA

    {
        private int fPSA_ID;
        private double fPERCENT_PCP;
        private DateTime fDIA;
        private string fINFORMACAO;

        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }

        public double PERCENT_PCP
        {
            get { return fPERCENT_PCP; }
            set { fPERCENT_PCP = value; }
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
      
    }
    public class PAR_PROJECAO_PSA_POR_DIA

    {
        private int fPSA_ID;
        private double fPERCENT_META;
        private DateTime fINICIO;
  
       
        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }

        public double PERCENT_META
        {
            get { return fPERCENT_META; }
            set { fPERCENT_META = value; }
        }
        public DateTime INICIO
        {
            get { return fINICIO; }
            set { fINICIO = value; }
        }
        public DateTime TERMINO
        {
            get; set;
        }
     

    }
}
