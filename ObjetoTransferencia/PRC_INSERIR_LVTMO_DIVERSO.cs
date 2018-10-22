using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_INSERIR_LVTMO_DIVERSO
    {
        private int fSERVICO_ID;
        private int fFORMULA_ID;
        private int fMEDICAO_BLOCO_ID;

        private double fD1;
        private double fD2;
        private double fD3;
        private double fD4;
        private double fD5;
        private double fD6;




        private string fDESCRICAO;
        private string fELEMENTO;
        private string fOBS;
        private int fINSERIR_NO_AVANCO;
        private int fGRUPO_PLAN_SERVICO_AMO_ID;

        
        private int fSPLAN_SERVICO_AMO_ID;


        public int SPLAN_SERVICO_AMO_ID
        {
            get { return fSPLAN_SERVICO_AMO_ID; }
           
        }

        public int SERVICO_ID
        {
            get { return fSERVICO_ID; }
            set { fSERVICO_ID = value; }
        }
        public int FORMULA_ID
        {
            get { return fFORMULA_ID; }
            set { fFORMULA_ID = value; }
        }
        public int MEDICAO_BLOCO_ID
        {
            get { return fMEDICAO_BLOCO_ID; }
            set { fMEDICAO_BLOCO_ID = value; }
        }
        public double D1
        {
            get { return fD1; }
            set { fD1 = value; }
        }

        public double D3
        {
            get { return fD3; }
            set { fD3 = value; }
        }
        public double D2
        {
            get { return fD2; }
            set { fD2 = value; }
        }


        public double D4
        {
            get { return fD4; }
            set { fD4 = value; }
        }


        public double D5
        {
            get { return fD5; }
            set { fD5 = value; }
        }


        public double D6
        {
            get { return fD6; }
            set { fD6 = value; }
        }
      
        public string DESCRICAO
        {
            get { return fDESCRICAO; }
            set { fDESCRICAO = value; }
        }
        public string ELEMENTO
        {
            get { return fELEMENTO; }
            set { fELEMENTO = value; }
        }
        public string OBS
        {
            get { return fOBS; }
            set { fOBS = value; }
        }
        public int INSERIR_NO_AVANCO
        {
            get { return fINSERIR_NO_AVANCO; }
            set { fINSERIR_NO_AVANCO = value; }
        }
        public int GRUPO_PLAN_SERVICO_AMO_ID
        {
            get { return fGRUPO_PLAN_SERVICO_AMO_ID; }
            set { fGRUPO_PLAN_SERVICO_AMO_ID = value; }
        }



    }
}
