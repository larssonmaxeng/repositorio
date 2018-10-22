using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PLAN_SERVICO_AMO
    {
            
        private int fPLAN_SERVICO_AMO_ID;
        private int fSERVICO_AMO_ID;
        private int fGRUPO_PLAN_SERVICO_ID;
        private DateTime fDIA_REALIZADO;
        private double fQTDE_REALIZADA;
        private int fFILHO;
       
        public int PLAN_SERVICO_AMO_ID
        {
            get { return fPLAN_SERVICO_AMO_ID; }
            set { fPLAN_SERVICO_AMO_ID = value; }
        }
        public int SERVICO_AMO_ID
        {
            get { return fSERVICO_AMO_ID; }
            set { fSERVICO_AMO_ID = value; }
        }
        public int GRUPO_PLAN_SERVICO_ID
        {
            get { return fGRUPO_PLAN_SERVICO_ID; }
            set { fGRUPO_PLAN_SERVICO_ID = value; }
        }
        public DateTime DIA_REALIZADO
        {
            get { return fDIA_REALIZADO; }
            set { fDIA_REALIZADO = value; }
        }

        public double QTDE_REALIZADA
        {
            get { return fQTDE_REALIZADA; }
            set { fQTDE_REALIZADA = value; }
        }
        public int FILHO
        {
            get { return fFILHO; }
            set { fFILHO = value; }
        }

  
    }
    public class PLAN_SERVICO_AMOColecao : List<PLAN_SERVICO_AMO>
    {

    }
    
}
