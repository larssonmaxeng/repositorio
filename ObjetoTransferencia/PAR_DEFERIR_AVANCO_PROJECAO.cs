using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_DEFERIR_AVANCO_PROJECAO
    {
        private int fPSA_ID;
        private int fTIPO;
        private string fINFORMACAO;

        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
        }
        public int TIPO
        {
            get { return fTIPO; }
            set { fTIPO = value; }
        }
        public string INFORMACAO
        {
            get { return fINFORMACAO; }
            set { fINFORMACAO = value; }
        }


    }
}
