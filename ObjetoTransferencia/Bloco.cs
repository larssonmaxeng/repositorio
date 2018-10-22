using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*using System.Runtime.InteropServices;*/
namespace ObjetoTransferencia
{



  /*  [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IBloco))]
    [Guid("E895DFA6-9E45-4503-B13F-0C65635EF1EA")]*/

    public class Bloco//:IBloco
    {
        public int BLOCO_ID { get; set; }
        public int OBRA_ID { get; set; }
        public string BLOCO { get; set; }
        public int TIPO_ESTATO_ID { get; set; }
        public int TIPO_ATIVO_ID { get; set; }
        public DateTime DATA_CAD { get; set; }
        public DateTime DATA_ALT { get; set; }
        public string OBS { get; set; }
        public int REPETICAO { get; set; }
        public string ALT { get; set; }
        public string CAD { get; set; }
        public int ORDEM { get; set; }
        public int SICRONIZADO { get; set; }
        public int SYCRBLOCO_ID { get; set; }
        public int bolinha(int i)
        {
            return 0;
        }
    }
  /*  [ComVisible(true)]
    [Guid("5D0580D8-0C58-4B41-AFF2-2DB605E5C30C")]
    public interface IBloco
    {
        int bolinha(int i);
        string BLOCO { get; set; }
    }*/
}
