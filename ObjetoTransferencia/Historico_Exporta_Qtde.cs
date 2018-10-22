using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Historico_Exporta_Qtde
    {          
        public int HISTORICO_EXP_QTDE_ID { get; set; }
        public string ITEM { get; set; }
        public int TIPO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string EXPORTADO { get; set; }
        public int SERVICO_ID { get; set; }
        public string SERVICO { get; set; }
        public string UNID { get; set; }
        public string ACAO { get; set; }
        public double QTDE_ANTERIOR { get; set; }
        public double QTDE_ATUAL { get; set; }
        public double DIFERENCA { get; set; }
        public string DESVINCULADO_ANTERIOR { get; set; }
        public string DESVINCULADO_ATUAL { get; set; }
        public string EXCLUIDO { get; set; }
        public string CHAVE_ERP { get; set; }
        public int VERSAO { get; set; }
        public int NIVEL { get; set; }
        public DateTime DATA_CAD { get; set; }
        public DateTime DATA_ALT { get; set; }
        public string CAD { get; set; }
        public string ALT { get; set; }
        public string ITEM_NOVO { get; set; }
        public string INSUMO_INSTALACAO { get; set; }
    }
}
