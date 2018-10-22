using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
  public  class CategoriaFamiliaTipoRevit
    {
        [Parametro(false, true, false,"Categoria", 150, "")]
        public string CATEGORIA { get; set; }

        [Parametro(false, true, false, "Categoria ID", 100, "")]
        public string CATEGORIA_ID { get; set; }

        [Parametro(false, true, false, "Família", 150, "")]
        public string FAMILIA { get; set; }

        [Parametro(false, true, false, "Família ID", 150, "")]
        public string FAMILIA_ID { get; set; }


        [Parametro(false, true, false, "Tipo", 150, "")]
        public string TIPO_FAMILIA { get; set; }

        [Parametro(false, true, false, "Tipo ID", 150, "")]
        public string TIPO_FAMILIA_ID { get; set; }

        [Parametro(false, true, false, "Tipo ID", 150, "")]
        public bool VINCULADO { get; set; }

        [Parametro(false, true, false, "Tipo ID", 150, "")]
        public bool VINCULADO_NOME_DIFERENTE { get; set; }


        [Parametro(false, true, false, "Tipo ID", 150, "")]
        public string ERRO { get; set; }
    }
    
}
