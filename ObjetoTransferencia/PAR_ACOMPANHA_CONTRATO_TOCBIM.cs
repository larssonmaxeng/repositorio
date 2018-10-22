using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjetoTransferencia
{
    public class PAR_ACOMPANHA_CONTRATO_TOCBIM
    {
        public string  EMPRESAERP { get; set; }
        public string OBRERP { get; set; }
        public string CONTRATOERP { get; set; }
        public string CONTRATADOERP { get; set; }
    }

    public class PAR_ACOMPANHA_CONTRATO_TOCBIM_UAU: PAR_ACOMPANHA_CONTRATO_TOCBIM
    {
        public string EMPRESAERP { get; set; }
        public string OBRERP { get; set; }
        public string CONTRATOERP { get; set; }
        public string CONTRATADOERP { get; set; }
    }    

    public class PAR_ACOMPANHA_CONTRATO_UAU
    {
        public int empresa { get; set; }
        public string obra { get; set; }
        public int contratoServico { get; set; }
        public int itemContrato { get; set; }
        public string servico { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public string mesPl { get; set; }
        public double quantidade { get; set; }
        public double porcentagemAcomp { get; set; }
        public string observacoes { get; set; }
        public string etapa { get; set; }
        public string codEstrutura { get; set; }
        public string sequencia { get; set; }
        public string usuarioLogado { get; set; }

        public int input_obra_id { get; set; }
        public DateTime input_inicio { get; set; }
        public DateTime input_fim { get; set; }
        public int acompanhadoUau { get; set; }
        public int acompanhadoTocBIM { get; set; }
        public DateTime dia_realizado { get; set; }

        public string acompanhamentoContrato { get; set; }
        public string medicao { get; set; }
    }

    public class MedicaoContrato
    {
        public string MEDICAO_ERP { get; set; }
        public int CONTRATO_ERP_ID { get; set; }
        public string CONTRATO_ERP { get; set; }
        public int FORNECEDOR_ID { get; set; }
        public string FORNECEDOR { get; set; }
    }

    public class AcompanhaContrato
    {
        public string COMPLEMENTO { get; set; }
        public string ITEM { get; set; }
        public DateTime DATA_INICIO { get; set; }
        public double QTDE_REALIZADA { get; set; }
        public int SERVICO_ID { get; set; }
        public int CONTRATO_ERP_ID { get; set; }
        public int ITEM_CONTRATO_ERP_ID { get; set; }
        public string ACOMPANHAMENTO_CONTRATO { get; set; }
        public string MEDICAO_ERP { get; set; }
        public int SERVICO_AMO_ID { get; set; }
        public int PLAN_SERVICO_AMO_ID { get; set; }
    }

    public class ArvorePorServico : TreeNode
    {
        public int medicaoId { get; set; }
        public string medicao { get; set; }
        public int servicoId { get; set; }
        public string servico { get; set; }
        public int blocoId { get; set; }
        public string bloco { get; set; }
        public int grupoId { get; set; }
        public string grupo { get; set; }
        public int medicaoBlocoId { get; set; }
        public int nivel { get; set; }
        public int critico { get; set; }
        public string complemento { get; set; }

        public ArvorePorServico(string text)
        {
            this.Text = text;
        }
    }

    public class AssociacaoPsa
    {
        public string complemento { get; set; }
        public string servico { get; set; }
        public DateTime diaRealizado { get; set; }
        public string acompanhamentoContrato { get; set; }
        public string medicaoErp { get; set; }
        public int contratoErpId { get; set; }
        public int itemContratoErpId { get; set; }
        public string item { get; set; }
        public string sequencia { get; set; }
        public int servicoId { get; set; }        
        public int blocoId { get; set; }
        public string bloco { get; set; }
        public int medicaoBlocoId { get; set; }
        public string medicao { get; set; }        
        public double qtdeRealizada { get; set; }
        public string etapa { get; set; }        
        public int servicoAmoId { get; set; }
        public int planServicoAmoId { get; set; }
    }

    public class ContratoAssociacao
    {
        public int contratoErpId { get; set; }
        public int itemContratoErpId { get; set; }
        public int fornecedorId { get; set; }
        public string fornecedor { get; set; }
    }
}
