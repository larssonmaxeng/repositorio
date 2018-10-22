using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_PROJ_PSA_ELE_VINCULADO
    {

            private int fPSA_ID;
            private double fQTDE_PROJECAO_GLOBAL;
            private DateTime fDIA;
            private string fINFORMACAO;

            public int PSA_ID
            {
                get { return fPSA_ID; }
                set { fPSA_ID = value; }
            }

            public double QTDE_PROJECAO_GLOBAL
            {
                get { return fQTDE_PROJECAO_GLOBAL; }
                set { fQTDE_PROJECAO_GLOBAL = value; }
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
