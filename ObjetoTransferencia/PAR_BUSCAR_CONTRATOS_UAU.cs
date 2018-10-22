using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public  class PAR_BUSCAR_CONTRATOS_UAU
    {
        public Int16 Empresa_cont { get; set; }
        public Int32 Cod_cont { get; set; }
        public String Obra_cont { get; set; }
        public Int32 CodPes_cont { get; set; }
        public String Objeto_cont { get; set; }
        public DateTime DtCriacao_cont { get; set; }
        public DateTime DtInicio_cont { get; set; }
        public DateTime DtFim_cont { get; set; }
        public String Quem_cont { get; set; }
        public Byte Situacao_cont { get; set; }
        public String Tipo_Cont { get; set; }
        public String Estagio_Cont { get; set; }
        public String Obs_cont { get; set; }
        public Byte Status_cont { get; set; }
        public String CondPag_cont { get; set; }
        public String EndPag_cont { get; set; }
        public String CondEnt_cont { get; set; }
        public Byte TipoPgto_cont { get; set; }
        public Byte TipoEndPag_cont { get; set; }
        public Byte Anexos_Cont { get; set; }
        public Byte controle_cont { get; set; }
        public Byte TipoCont_cont { get; set; }
        public Int32 EmpPaga_cont { get; set; }
        public Int32 EmpFatura_cont { get; set; }
        public Int16 TipoServMat_Cont { get; set; }
        public Byte CasaDecQtde_Cont { get; set; }
        public Byte CasaDecPreco_Cont { get; set; }
        public String MotivoAlter_cont { get; set; }
        public Int32 CarenciaBloqueioPrazo_cont { get; set; }
        public Int16 Banco_cont { get; set; }
        public String Conta_cont { get; set; }
        public String CategMovFin_cont { get; set; }
        public Boolean ContratoAtual_cont { get; set; }

    }
}
