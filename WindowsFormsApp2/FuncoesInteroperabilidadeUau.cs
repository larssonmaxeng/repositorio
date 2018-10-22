using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;



namespace WindowsFormsApp2
{
    static public class  FuncoesInteroperabilidadeUau
    {
       /* static public WindowsFormsApp2.WSContratoUAU.Acompanhamento GetAcompanhamento(string contrato, int empresa, string obra,
            List<PAR_BUSCAR_CONTRATOS_UAU> lista )
        {
            WindowsFormsApp2.WSContratoUAU.Acompanhamento r = new WindowsFormsApp2.WSContratoUAU.Acompanhamento();
        
            return r;
        }
        static public WindowsFormsApp2.WSContratoUAU.CasaDecimal GetCasaDecimal(string contrato, int empresa, string obra,
            List<PAR_BUSCAR_CONTRATOS_UAU> lista)
        {
            WindowsFormsApp2.WSContratoUAU.CasaDecimal casaDecimal = new WindowsFormsApp2.WSContratoUAU.CasaDecimal();
            return casaDecimal;
        }
        static public WindowsFormsApp2.WSContratoUAU.CasaDecimal GetCasaDecimalGeral(string contrato, int empresa, string obra,
            List<PAR_BUSCAR_CONTRATOS_UAU> lista)
        {
            WindowsFormsApp2.WSContratoUAU.CasaDecimal casaDecimal = new WindowsFormsApp2.WSContratoUAU.CasaDecimal();
            return casaDecimal;
        }*/
      /*  static public PAR_ACOMPAHAR_CONTRATO_UAU GerarParametro(PAR_ACOMPANHA_CONTRATO_TOCBIM par, List<ObjetoTransferencia.PAR_BUSCAR_CONTRATOS_UAU> lista)
        {
            PAR_ACOMPAHAR_CONTRATO_UAU ipar = new PAR_ACOMPAHAR_CONTRATO_UAU();
            



            return ipar;

        }
       static public Boolean  AcompanharContrato(PAR_ACOMPAHAR_CONTRATO_UAU ipar, wsAcompUAU.wsAcompanhamentosServicosSoapClient c )
        {
            try
            {

                c.AcompanharServicoContrato(ipar.empresa,
                                            ipar.obra,
                                            ipar.contratoServico,
                                            ipar.itemContrato,
                                            ipar.servico,
                                            ipar.dataInicio,
                                            ipar.dataFim,
                                            ipar.mesPl,
                                            ipar.quantidade,
                                            ipar.porcentagemAcomp,
                                            ipar.observacoes,
                                            ipar.etapa,
                                            ipar.codEstrutura,
                                            ipar.sequencia,
                                            ipar.usuarioLogado);
                return true;
            }
            catch
            {
                return false;
            }
        }
        static public Boolean ExcluiAcompanharContrato(PAR_ACOMPAHAR_CONTRATO_UAU ipar, wsAcompUAU.wsAcompanhamentosServicosSoapClient c)
        {
            try
            {
               /* c.ExcluirAcompanhamento(ipar.Acompanhamento,
                                                         ipar.obra,
                                                         ipar.mesPl,
                                                         ipar.indice,
                                                         ipar.empresaAtiva,
                                                         ipar.usuarioLogado);
                return true;
            }
            catch
            {
                return false;
            }
        }*/
    }
}
