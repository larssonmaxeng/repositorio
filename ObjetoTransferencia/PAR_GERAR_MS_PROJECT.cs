using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_GERAR_MS_PROJECT
    {
        public string DESCRICAO { get; set; }
        public string PREDECESSORA { get; set; }
        public int NIVEL { get; set; }
        public int BLOCO_ID { get; set; }
        public int GRUPO_PLAN_SERVICO_ID { get; set; }
        public int SERVICO_ID { get; set; }
        public int MEDICAO_BLOCO_ID { get; set; }
    }
    public class PAR_GERAR_MS_PROJECT_SERV_AVANCO : PAR_GERAR_MS_PROJECT
    {
        public DateTime TERMINO { get; set; }
        public string SITUACAO { get; set; }
    }
}
