using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PAR_INSERIR_LVTMO_DIVERSO
    {
        public PAR_INSERIR_LVTMO_DIVERSO()
        {
            Empilhada = false;
        }
        public bool Empilhada { get; set; }
        public string uau_comp;
        public double PESO_PRODUTIVIDADE { get; set; }
        public string INSUMO_VINCULADO;
        public double CONSUMO_INSUMO_VINCULADO;
        public double PSA_ID { get; set; }
        public double AREA { get; set; }
        public double AREA_LATERAL { get; set; }
        public double AREA_TOPO { get; set; }
        public double AREA_BASE { get; set; }
        public double VOLUME { get; set; }
        public double COMPRIMENTO { get; set; }
        public double LARGURA { get; set; }
        public double ALTURA { get; set; }
        public double KG { get; set; }
        public double PERIMETRO { get; set; }
        public double BASE { get; set; }
        public double BASE_MAIOR { get; set; }
        public double ALTURA_MAIOR { get; set; }
        public string DESCRICAO { get; set; }
        public int ID_BIM { get; set; }

        public string CATEGORIA { get; set; }
        public double UNIDADE_PRINCIPAL { get; set; }
        public double DIAMETER { get; set; }
        public string SYSTEM_TYPE { get; set; }
        public double AREA_FORMA { get; set; }
        public string AMBIENTE { get; set; }
        public string APTO { get; set; }
        public string ERRO { get; set; }
        public string NBR_15965 { get; set; }
        public double POSICAO_X { get; set; }
        public double POSICAO_Y { get; set; }
        public double POSICAO_Z { get; set; }
        public int ELEMENTID { get; set; }
        public int EXCLUIR { get; set; }
        public int TIPO_IMPORTACAO { get; set; }
        public int SERVICO_AMO_ID { get; set; }
        public int MEDICAO_BLOCO_ID { get; set; }
        public int SERVICO_ID { get; set; }
        public int GRUPO_PLAN_SERVICO_ID { get; set; }
        public string MODELO_GUID_ID { get; set; }
        public string INSERIR_INSUMO { get; set; }        

        public void Clear()
        {

            double? AREA =  null;
            double? AREA_FORMA = null;
            double? POSICAO_Z = null;
            double? POSICAO_X = null;
            double? POSICAO_Y = null;

            double? AREA_BASE = null;
            double? AREA_LATERAL = null;
            double? AREA_TOPO = null;
            double? VOLUME = null;
            double? COMPRIMENTO = null;
            double? LARGURA = null;
            double? ALTURA = null;
            double? KG = null;
            double? PERIMETRO = null;
            double? BASE = null;
            double? ELEVACAO = null;
            double? BASE_MAIOR = null;
            double? ALTURA_MAIOR = null;
            int? SERVICO_AMO_ID = null;

            int? SERVICO_ID = null;
            int? EXCLUIR = null;
            int? ELEMENTID = null;
            int? BLOCO_ID = null;
            int? MEDICAO_BLOCO_ID = null;
            int? PSA_ID = null;
            int? TIPO_IMPORTACAO = null;
            DESCRICAO = null;
            int? ID_BIM = null;
            AMBIENTE = null;
            APTO = null;
            CATEGORIA = null;
            NBR_15965 = null;
            double? UNIDADE_PRINCIPAL = null;
            double? DIAMETER = null;
            SYSTEM_TYPE = null;
            INSERIR_INSUMO = null;
        }
    }
    public class PAR_PRC_PREENCHE_META_SQL
    {
        public int EGRUPO_ID { get; set; }
        public int ESERVICO_ID { get; set; }
        public int EBLOCO_ID { get; set; }
        public int EMEDICAO_BLOCO_ID { get; set; }
        public int ETIPO { get; set; }
        public double EQTDE { get; set; }
        public int ECRITICA { get; set; }

        public DateTime EINICIO { get; set; }
        public DateTime ETERMINO { get; set; }
    }
    public class PAR_DELETAR_CRONOGRAMA
    {
        public int EMEDICAO_BLOCO_ID { get; set; }
        public int ESERVICO_ID { get; set; }
        public int ETIPO { get; set; }
    }
}
