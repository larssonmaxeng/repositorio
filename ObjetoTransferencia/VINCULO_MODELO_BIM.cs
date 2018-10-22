using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class VINCULO_MODELO_BIM
    {
        public int VINCULO_MODELO_BIM_ID { get; set; }
        public int SERVICO_ID { get; set; }
        public string MODELO_GUID_ID { get; set; }
        public string CATEGORIA_ID { get; set; }
        public string CATEGORIA { get; set; }
        public string FAMILIA_ID { get; set; }
        public string FAMILIA { get; set; }
        public int TIPO_FAMILIA_ID { get; set; }
        public string TIPO_FAMILIA { get; set; }
        public string ELEMENTO { get; set; }
        //os campos abaixo dever ser buscados na tabela de serviço
        public string SERVICO { get; set; }
        public string COMPLEMENTO { get; set; }
    }
}
