using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Obra
    {
        public int OBRA_ID { get; set; }
        public int EMPRESA_ID { get; set; }
        public string EMPRESA { get; set; }
        public string OBRA { get; set; }
        public string NOBRA { get; set; }
        public double REALIZADO { get; set; }
        public double META { get; set; }
        public double P_EXECUCAO { get; set; }
        public DateTime DATA_META { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime TERMINO { get; set; }
        public int PRAZO_DE_VENDA { get; set; }
        public int PRAZO_DE_REPASSE { get; set; }
        public DateTime DATA { get; set; }
        public DateTime DATA_CAD { get; set; }
        public DateTime DATA_ALT { get; set; }
        public string ENGENHEIRO { get; set; }
        public string NCTR { get; set; }
        public string CONSTRUTORA { get; set; }
        public string NCTC { get; set; }
        public double PRECO_OBRA { get; set; }
        public double INCC { get; set; }
        public int TIPO_ESTATO_ID { get; set; }
        public int TIPO_ATIVO_ID { get; set; }
        public string ALT { get; set; }
        public string CAD { get; set; }
        public int PLANEJAMENTO { get; set; }
        public int CONTROLE { get; set; }
        public int PRODUCAO { get; set; }
        public int GESTOR { get; set; }
        public int CLIENTE { get; set; }
        public string DADOS_DO_MAPA { get; set; }
        public string MAPA_ORIGEM { get; set; }
        public string VALOR_MAPA { get; set; }
        public string VALOR_MEDIDO { get; set; }
        public string VALOR_BRUTO_DA_MEDICAO { get; set; }
        public string SALDO_TOTAL { get; set; }
        public string PERCENT_EXECUTADO { get; set; }
        public string CAMPO_ASSINATURA_01 { get; set; }
        public string CAMPO_ASSINATURA_02 { get; set; }
        public string CAMPO_ASSINATURA_03 { get; set; }
        public string CAMPO_ASSINATURA_04 { get; set; }
        public int TERRENO_ID { get; set; }
        public int SICRONIZADO { get; set; }
        public int SYCROBRA_ID { get; set; }
    }

}
