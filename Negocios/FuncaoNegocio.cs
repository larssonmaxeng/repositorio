using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados;
using System.Reflection;
namespace Negocios
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AtualizacaoAttribute : Attribute
    {
        public bool PrimaryKey { get; set; }
        public bool Update { get; set; }
        public bool Where { get; set; }

        public AtualizacaoAttribute(bool primaryKey, bool update, bool where)
        {
            PrimaryKey = primaryKey;
            Where = where;
            Update = update;
        }
    }
    public class Acesso
    {
  
        public Type Tipo { get; set; }
        public Acesso(Type tipo)
        {
            Tipo = tipo;
        }
        public ResultadoConsulta Deletar(object objeto)
        {
            AcessoBancoDados.ResultadoConsulta rc = new ResultadoConsulta();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = FuncaoNegocio.ENDERECO ;// dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            try
            {
                object o = sql.ExecutarManipulacao(System.Data.CommandType.Text,
                                                                         "delete from " +
                                                                         objeto.GetType().Name
                                                                         + "  where "
                                                                         + FuncaoNegocio.CampoPrimaryKey(objeto.GetType()).Name + " = " +
                                                                         FuncaoNegocio.CampoPrimaryKey(objeto.GetType()).GetValue(objeto).ToString());
                rc.resultado = true;
                return rc;
            }
            catch
            {
                rc.resultado = false;
                return rc;
            }

        }
    }

    public static class FuncaoNegocio
    {
       public static string ENDERECO = @"D:\progran\28- NBR15575\";

        public static PropertyInfo CampoPrimaryKey(Type tipo)
        {
            foreach (var propertyInfo in tipo.GetProperties())
            {
                foreach (PropertyInfo property in tipo.GetProperties())
                {
                    object[] attrs = property.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                        if (attr is AtualizacaoAttribute)
                            if ((attr as AtualizacaoAttribute) != null)
                                if ((attr as AtualizacaoAttribute).PrimaryKey)
                                    return property;

                }
            }

            return null;
        }



    }
}