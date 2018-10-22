using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class ItemResultado
    {
        public int IDdoElemento { get; set; }
        public string ErroDoElemento { get; set; }
    }
    public class ResultadoAcesso
    {
        public Boolean Resultado { get; set; }
        public string MensagemErro { get; set; }
        public List<ItemResultado> ResultadoPorItem = new List<ItemResultado>();
       
    }
}
