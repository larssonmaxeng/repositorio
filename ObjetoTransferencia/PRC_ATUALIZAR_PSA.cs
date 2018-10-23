using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
   public  class PRC_ATUALIZAR_PSA
    {
        private int fPSA_ID;

        private double fD1;
        private double fD2;
        private double fD3;
        private double fD4;
        private double fD5;
        private double fD6;
        private string fDescricao;
        private string fID_BIM;
        private double fVOLUME;
        private double fAREA_BASE;
        private string fFAMILY_TYPE;
        private double fCOMPRIMENTO;
        private double fLARGURA;
        private double fALTURA;
        private double fKG;

        public int PSA_ID
        {
            get { return fPSA_ID; }
            set { fPSA_ID = value; }
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

        public string Descricao
        {
            get { return fDescricao; }
            set { fDescricao = value; }
        }

        public string ID_BIM
        {
            get { return fID_BIM; }
            set { fID_BIM = value; }
        }
        public double VOLUME
        {
            get { return fVOLUME; }
            set { fVOLUME = value; }
        }
        public double AREA_BASE
        {
            get { return fAREA_BASE; }
            set { fAREA_BASE = value; }
        }
        public string FAMILY_TYPE
        {
            get { return fFAMILY_TYPE; }
            set { fFAMILY_TYPE = value; }
        }
        public double COMPRIMENTO
        {
            get { return fCOMPRIMENTO; }
            set { fCOMPRIMENTO = value; }
        }
        public double LARGURA
        {
            get { return fLARGURA; }
            set { fLARGURA = value; }
        }
        public double ALTURA
        {
            get { return fALTURA; }
            set { fALTURA = value; }
        }
        public double KG
        {
            get { return fKG; }
            set { fKG = value; }
        }

    }

   public class PAR_SEL_DADOS_PSA_ID
   {
       private int fPSA_ID;

       public int PSA_ID
       {
           get { return fPSA_ID; }
           set { fPSA_ID = value; }
       }




   }

}
