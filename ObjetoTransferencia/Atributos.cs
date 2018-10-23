using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ObjetoTransferencia
{

    public class ParametroBasico
    {
        public int TIPO_DE_ACAO { get; set; }
        public bool TIPO_ATIVO_ID { get; set; }
        public bool TIPO_ESTATO_ID { get; set; }

    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ParametroAttribute : Attribute
    {
        public bool PrimaryKey { get; set; }
        public bool Update { get; set; }
        public bool Where { get; set; }
        public string NomeCampo { get; set; }
        public int LarguraCampo { get; set; }
        public string FormatoCampo { get; set; }



        public ParametroAttribute(bool primaryKey, 
                                    bool update, 
                                    bool where, 
                                    string nomeCampo,
                                    int larguraCampo,
                                    string formatoCampo)
        {
            PrimaryKey = primaryKey;
            Where = where;
            Update = update;
            NomeCampo = nomeCampo;
            LarguraCampo = larguraCampo;
            FormatoCampo = formatoCampo;
        }
    }

}
