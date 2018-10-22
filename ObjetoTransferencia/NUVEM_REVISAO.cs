using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class NUVEM_REVISAO:ParametroBasico
    {
        private string revisao;

        public string REVISAO
        {
            get;set;
        }
        public string NUMERO_DA_REVISAO { get; set; }
        public DateTime DATA_DA_REVISAO { get; set; }
        public string COMENTARIO { get; set; }
        [ParametroAttribute(true, false, true, "Código", 100,"")]
        public int NUVEM_REVISAO_ID { get; set; }
        public string MODELO_GUID_ID { get; set; }
        public int INTEGER_VALUE { get; set; }      

        
    }
    public class VISTA_ASSOCIADA:ParametroBasico
    {
        [ParametroAttribute(true, false, true, "Código", 100, "")]
        public int VISTA_ASSOCIADA_ID { get; set; }//
        public int? NUVEM_REVISAO_ID { get; set; }//
        public int INTEGER_VALUE { get; set; }//
        public string COMENTARIO { get; set; }//
        public byte[] IMAGEM { get; set; }//


    }
}
