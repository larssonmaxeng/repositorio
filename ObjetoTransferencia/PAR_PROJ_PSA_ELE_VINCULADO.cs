using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_PCP_PSA_ELE_VINCULADO
    {

            private int fPSA_ID;
            private double fQTDE_PCP_GLOBAL;
            private DateTime fDIA;
            private string fINFORMACAO;

            public int PSA_ID
            {
                get { return fPSA_ID; }
                set { fPSA_ID = value; }
            }

            public double QTDE_PCP_GLOBAL
            {
                get { return fQTDE_PCP_GLOBAL; }
                set { fQTDE_PCP_GLOBAL = value; }
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
    public class PAR_META_PSA_ELE_VINCULADO
    {

        private int fPSA_ID;
        private double fQTDE_META_GLOBAL;
        private DateTime fDIA;
        private string fINFORMACAO;

        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }

        public double QTDE_META_GLOBAL
        {
            get { return fQTDE_META_GLOBAL; }
            set { fQTDE_META_GLOBAL = value; }
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
}
