using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcessoBancoDados;
using System.Reflection;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;
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
       
           private string dir;
        public object parametroEntrada;
        public string Dir
        {
            get
            {
                return dir;
            }
            set
            {
                dir = value;
            }
        }
        public Acesso(string idir)
        {
            Dir = idir;
        }

        /*   public ResultadoConsulta Deletar(object objeto)
           {
               AcessoBancoDados.ResultadoConsulta rc = new ResultadoConsulta();
               AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();

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

           }*/
    }

    public static class FuncaoNegocio
    {

        public static object TrataInteger(string nomeCampo, int v, PropertyInfo propertyInfo)
        {

            if (nomeCampo == "TIPO_ATIVO_ID")
            {
                if (v == 45) return true;
                else return false;
            }else if (nomeCampo == "TIPO_ESTATO_ID")
            {
                if (v == 287) return true;
                else return false;
            } else  if(propertyInfo.PropertyType==typeof(bool))
            {
                if (v == 1) return true;
                else return false;

            }
            return v;
        }

        

        public static object PreencheCampo(FbDataReader fb, object o)
        {
            for (int i = 0; i < fb.FieldCount - 1; i++)
            {
                if (fb.GetFieldType(i) == typeof(string))
                    o.GetType().GetProperty(fb.GetName(i)).SetValue(o, fb[i].ToString().Trim());
                else if (fb.GetFieldType(i) == typeof(int))
                {
                    int v;
                    if (int.TryParse(fb[i].ToString(), out v))
                    {
                        object integerTratado = TrataInteger(fb.GetName(i), v, o.GetType().GetProperty(fb.GetName(i)));
                        o.GetType().GetProperty(fb.GetName(i)).SetValue(o, integerTratado);
                    }
                } else if (fb.GetFieldType(i) == typeof(DateTime))
                {
                    DateTime d;
                    if (DateTime.TryParse(fb[i].ToString(), out d))
                        o.GetType().GetProperty(fb.GetName(i)).SetValue(o, d);
                } else if (fb.GetFieldType(i) == typeof(bool))
                {
                    bool b;
                    if (bool.TryParse(fb[i].ToString(), out b))
                        o.GetType().GetProperty(fb.GetName(i)).SetValue(o, b);
                }
                else
                {
                    if(fb[i]!=null)
                       o.GetType().GetProperty(fb.GetName(i)).SetValue(o, fb[i]);
                }

            }
            return o;
        }
        public static void PreencheParametro(ref AcessoBancoDados.FbsqlConnection sql, List<PROCEDURE_PARAMETERS> lista, object o)
        {
            foreach (PROCEDURE_PARAMETERS item in lista)
            {
                object valor = o.GetType().GetProperty(item.PARAMETER_NAME).GetValue(o);
                if (item.PARAMETER_NAME == "TIPO_ATIVO_ID")
                {
                    bool v;
                    if (bool.TryParse(valor.ToString(), out v))
                    {
                        if (v) valor = 45;
                        else valor = 46;
                    }
                    else valor = 46;
                }
                else if (item.PARAMETER_NAME == "TIPO_ESTATO_ID")
                {
                    bool v;
                    if (bool.TryParse(valor.ToString(), out v))
                    {
                        if (v) valor = 287;
                        else valor = 271;
                    }
                    else valor = 271;
                }
                else if (valor != null)
                {
                    if (valor.GetType() == typeof(bool))
                    {
                        bool v1;
                        if (bool.TryParse(valor.ToString(), out v1))
                        {
                            if (v1) valor = 1;
                            else valor = 0;
                        }
                        else valor = 0;
                    }
                    else if (valor.GetType() == typeof(string))
                    {
                        if (string.IsNullOrEmpty(valor.ToString()))
                            valor = "";
                    }
                }
                  sql.AdicionarParametros("@" + item.PARAMETER_NAME, valor);
            }
        }
        public static PropertyInfo CampoPrimaryKey(Type tipo)
        {
            foreach (var propertyInfo in tipo.GetProperties())
            {
                foreach (PropertyInfo property in tipo.GetProperties())
                {
                    object[] attrs = property.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                        if (attr is ParametroAttribute)
                            if ((attr as ParametroAttribute) != null)
                                if ((attr as ParametroAttribute).PrimaryKey)
                                    return property;
                }
            }

            return null;
        }



    }
    public class ACESSO_PARAMETROS_PROCEDURE:Acesso
    {
        public ACESSO_PARAMETROS_PROCEDURE(string idir):base(idir)
        {

        }

        public List<PROCEDURE_PARAMETERS> Seleciona( string NOME_PROCEDURE)
        {
            List<PROCEDURE_PARAMETERS> lista = new List<PROCEDURE_PARAMETERS>();
            FbsqlConnection sql = new FbsqlConnection();
            sql.Diretorio = Dir;
            sql.Ativo(true);



            FirebirdSql.Data.FirebirdClient.FbDataReader fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                    "  select parameter_name, " +
                           "procedure_name," +
                           "parameter_number," +
                           "parameter_type " +
                    "from vw_procedure_parameters " +
                      " where  PROCEDURE_NAME = '" + NOME_PROCEDURE + "'" +
                      " and PARAMETER_TYPE = 0 " +
                       " ORDER BY  PARAMETER_NUMBER");
            while (fb.Read())
            {
                lista.Add(FuncaoNegocio.PreencheCampo(fb, new PROCEDURE_PARAMETERS()) as PROCEDURE_PARAMETERS);
            }
            sql.Close();
            return lista;
        }
    }
}