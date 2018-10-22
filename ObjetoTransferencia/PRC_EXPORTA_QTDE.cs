using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class PRC_EXPORTA_QTDE
    {
        public string item { get; set; }// varchar(250),
        public string codigo { get; set; }//varchar(250),
        public string sequencia { get; set; }// varchar(250),
        public int servico { get; set; }//integer
        public string descricao { get; set; } //varchar(250),
        public double qtde { get; set; } //double precision,
        public int prod_eq { get; set; } //integer,
        public string tipo { get; set; }//varchar(10),
        public DateTime inicio { get; set; }//date,
        public DateTime fim { get; set; }//date,
        public int tipo_servico { get; set; }//integer,
        public string obra { get; set; }//varchar(250),
        public string empresa { get; set; }//integer,
        public int orcamento { get; set; }//integer
        public string excluido { get; set; }//string,
        public string unid { get; set; }//string,
        public double qtde_anterior { get; set; } //double precision,
        public string desvinculado_anterior { get; set; }//string,
        public string chave_erp { get; set; }//string, 
        public double diferenca { get; set; } //double precision,
        public int nivel { get; set; }//integer
        public string item_novo { get; set; }//string, 
        public string insumo_instalacao { get; set; }//string, 
    }
}
