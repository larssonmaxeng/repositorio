using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_PROJECAO_PSA

    {
        private int fPSA_ID;
        private double fPERCENT_PROJECAO;
        private DateTime fDIA;
        private string fINFORMACAO;

        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }

        public double PERCENT_PROJECAO
        {
            get { return fPERCENT_PROJECAO; }
            set { fPERCENT_PROJECAO = value; }
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
