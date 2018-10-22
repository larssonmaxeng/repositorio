using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class Acesso_Historico_Exporta_Qtde
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string strSql;
        public enum tipoHistorico { UltimoHistorico = 1, VersoesAnteriore = 2 };

        public int Gerar_Versao(string dir)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            int VERSAO = Convert.ToInt32(sql.ExecutarManipulacao(System.Data.CommandType.Text, "select  gen_id(gen_versao_hist_exp_qtde, 1)   from rdb$database"));;
            sql.Close();
            sql.Dipose();
            return VERSAO;
        }

        public int Buscar_Ultima_Versao(string dir)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            int VERSAO = Convert.ToInt32(sql.ExecutarManipulacao(System.Data.CommandType.Text, "Select coalesce(Max(VERSAO), 0) From historico_exporta_qtde")); ;
            sql.Close();
            sql.Dipose();
            return VERSAO;            
        }

        public List<Int32> Buscar_Versoes(string dir)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            List<Int32> lista = new List<Int32>();

            strSql = "Select Versao From historico_exporta_qtde Group By Versao Order By Versao Desc";


            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {                                
                lista.Add(Convert.ToInt32(fb["VERSAO"]));
            }
            sql.Close();
            return lista;
        }

        public int Inserir(string dir, Historico_Exporta_Qtde regHistorico)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;            

            try
            {
                strSql = "INSERT INTO HISTORICO_EXPORTA_QTDE(ITEM, TIPO, COMPLEMENTO, EXPORTADO, SERVICO_ID, SERVICO, UNID, ACAO, QTDE_ANTERIOR, " +
                    "QTDE_ATUAL, DESVINCULADO_ANTERIOR, DESVINCULADO_ATUAL, CHAVE_ERP, EXCLUIDO, VERSAO, NIVEL) " +
                    "VALUES('" + regHistorico.ITEM + "', " + regHistorico.TIPO.ToString() + ", '" + regHistorico.COMPLEMENTO + "', '" + regHistorico.EXPORTADO + "', " +
                    regHistorico.SERVICO_ID.ToString() + ", '" + regHistorico.SERVICO + "', '" + regHistorico.UNID + "', '" + regHistorico.ACAO + "', " + 
                    regHistorico.QTDE_ANTERIOR.ToString().Replace(",", ".") + ", " + regHistorico.QTDE_ATUAL.ToString().Replace(",", ".") + ", '" + 
                    regHistorico.DESVINCULADO_ANTERIOR + "', '" + regHistorico.DESVINCULADO_ATUAL + "', '" + regHistorico.CHAVE_ERP + "', '" + 
                    regHistorico.EXCLUIDO + "', " + regHistorico.VERSAO.ToString() + ", " + regHistorico.NIVEL.ToString() + ") Returning HISTORICO_EXP_QTDE_ID";

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarManipulacao(System.Data.CommandType.Text, strSql);
                sql.t.Commit();
                sql.Close();
                sql.Dipose();
                return Convert.ToInt32(obj.ToString());
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return 0;
            }
        }

        public Boolean Atualizar(string dir, Historico_Exporta_Qtde regHistorico)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "Update Historico_Exporta_Qtde Set ITEM = '" + regHistorico.ITEM + "', " +
                    "TIPO = " + regHistorico.TIPO.ToString() + ", " +
                    "COMPLEMENTO = '" + regHistorico.COMPLEMENTO + "', " +
                    "EXPORTADO = '" + regHistorico.EXPORTADO + "', " +
                    "SERVICO_ID = " + regHistorico.SERVICO_ID.ToString() + ", " +
                    "SERVICO = '" + regHistorico.SERVICO + "', " +
                    "UNID = '" + regHistorico.UNID + "', " +
                    "ACAO = '" + regHistorico.ACAO + "', " +
                    "QTDE_ANTERIOR = " + regHistorico.QTDE_ANTERIOR.ToString() + ", " +
                    "QTDE_ATUAL = " + regHistorico.QTDE_ATUAL.ToString() + ", " +
                    "DESVINCULADO_ANTERIOR = '" + regHistorico.DESVINCULADO_ANTERIOR + "', " +
                    "DESVINCULADO_ATUAL = '" + regHistorico.DESVINCULADO_ATUAL + "', " +
                    "CHAVE_ERP = '" + regHistorico.CHAVE_ERP + "', " +
                    "EXCLUIDO = '" + regHistorico.EXCLUIDO + "'" +
                    " Where HISTORICO_EXP_QTDE_ID = " + regHistorico.HISTORICO_EXP_QTDE_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, strSql);
                sql.t.Commit();
                sql.Close();
                sql.Dipose();
                return true;
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return true;
            }
        }

        public Boolean Deletar(string dir, Historico_Exporta_Qtde regHistorico)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "Delete From HISTORICO_EXPORTA_QTDE Where HISTORICO_EXP_QTDE_ID = " + regHistorico.HISTORICO_EXP_QTDE_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, strSql);
                sql.t.Commit();
                sql.Close();
                sql.Dipose();
                return true;
            }
            catch (Exception e)
            {
                sql.t.Rollback();
                sql.Close();
                sql.Dipose();
                return false;
            }
        }

        public List<Historico_Exporta_Qtde> Listar(string dir, int HISTORICO_EXP_QTDE_ID, tipoHistorico historico, string CHAVE_ERP)
        {
            string strSqlWhere = null;
            Historico_Exporta_Qtde regHistorico;
            List<Historico_Exporta_Qtde> lista = new List<Historico_Exporta_Qtde>();

            //Acesso_Historico_Exporta_Qtde objNeg = new Acesso_Historico_Exporta_Qtde();
            int versaoHistorico = Buscar_Ultima_Versao(dir);

            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select HISTORICO_EXP_QTDE_ID, ITEM, TIPO, COMPLEMENTO, EXPORTADO, SERVICO_ID, SERVICO, UNID, ACAO, QTDE_ANTERIOR, QTDE_ATUAL, DESVINCULADO_ANTERIOR, " +
                "DESVINCULADO_ATUAL, CHAVE_ERP, EXCLUIDO, VERSAO, NIVEL, coalesce(DATA_CAD, '01/01/0001') DATA_CAD, coalesce(DATA_ALT, '01/01/0001') DATA_ALT, CAD, ALT " +
                "From Historico_Exporta_Qtde h";

            if (HISTORICO_EXP_QTDE_ID != 0)
                strSqlWhere = " Where HISTORICO_EXP_QTDE_ID = " + HISTORICO_EXP_QTDE_ID.ToString();

            if (historico == tipoHistorico.UltimoHistorico)
            {
                if (string.IsNullOrEmpty(strSqlWhere))
                {
                    strSqlWhere = " Where VERSAO = " + versaoHistorico.ToString();
                }
                else
                {
                    strSqlWhere = " And VERSAO = " + versaoHistorico.ToString();
                }
            }
            else
            {
                if (historico == tipoHistorico.VersoesAnteriore)
                {
                    if (string.IsNullOrEmpty(strSqlWhere))
                    {
                        strSqlWhere = " Where VERSAO <> " + versaoHistorico.ToString();
                    }
                    else
                    {
                        strSqlWhere = " And VERSAO <> " + versaoHistorico.ToString();
                    }
                }
            }

            if (string.IsNullOrEmpty(strSqlWhere))
            {
                if (!string.IsNullOrEmpty(CHAVE_ERP))
                    strSqlWhere += " Where CHAVE_ERP = '" + CHAVE_ERP + "'";

            }
            else
            {
                if (!string.IsNullOrEmpty(CHAVE_ERP))
                    strSqlWhere += " And CHAVE_ERP = '" + CHAVE_ERP + "'";

            }



            if (!string.IsNullOrEmpty(strSqlWhere))
                strSql += strSqlWhere;

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regHistorico = new Historico_Exporta_Qtde();
                regHistorico.HISTORICO_EXP_QTDE_ID = Convert.ToInt32(fb["HISTORICO_EXP_QTDE_ID"]);
                regHistorico.ITEM = Convert.ToString(fb["ITEM"]);
                regHistorico.TIPO = Convert.ToInt32(fb["TIPO"]);
                regHistorico.COMPLEMENTO = Convert.ToString(fb["COMPLEMENTO"]);
                regHistorico.EXPORTADO = Convert.ToString(fb["EXPORTADO"]);
                regHistorico.SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]);
                regHistorico.SERVICO = Convert.ToString(fb["SERVICO"]);
                regHistorico.UNID = Convert.ToString(fb["UNID"]);
                regHistorico.ACAO = Convert.ToString(fb["ACAO"]);
                regHistorico.QTDE_ANTERIOR = Convert.ToDouble(fb["QTDE_ANTERIOR"]);
                regHistorico.QTDE_ATUAL = Convert.ToDouble(fb["QTDE_ATUAL"]);

                if (regHistorico.QTDE_ATUAL - regHistorico.QTDE_ANTERIOR < 0)
                    regHistorico.DIFERENCA = (regHistorico.QTDE_ATUAL - regHistorico.QTDE_ANTERIOR) * -1;
                else
                    regHistorico.DIFERENCA = (regHistorico.QTDE_ATUAL - regHistorico.QTDE_ANTERIOR);

                regHistorico.DESVINCULADO_ANTERIOR = Convert.ToString(fb["DESVINCULADO_ANTERIOR"]);
                regHistorico.DESVINCULADO_ATUAL = Convert.ToString(fb["DESVINCULADO_ATUAL"]);
                regHistorico.CHAVE_ERP = Convert.ToString(fb["CHAVE_ERP"]);
                regHistorico.EXCLUIDO = Convert.ToString(fb["EXCLUIDO"]);
                regHistorico.VERSAO = Convert.ToInt32(fb["VERSAO"]);
                regHistorico.NIVEL = Convert.ToInt32(fb["NIVEL"]);
                regHistorico.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                regHistorico.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                regHistorico.CAD = Convert.ToString(fb["CAD"]);
                regHistorico.ALT = Convert.ToString(fb["ALT"]);

                lista.Add(regHistorico);
            }
            sql.Close();
            return lista;        
        }

        public List<Hist_Exporta_Qtde_Insumo> ListarInsumos(string dir, string Uau_Comp)
        {
            string strSqlWhere = null;
            Hist_Exporta_Qtde_Insumo regHistoricoInsumo;
            List<Hist_Exporta_Qtde_Insumo> lista = new List<Hist_Exporta_Qtde_Insumo>();
            
            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select TEQ.codigo, coalesce(i.insumo_id, '0') insumo_id, coalesce(i.insumo, '') insumo " +
                "From TPRC_EXPORTA_QTDE TEQ " +
                "Left Join servico_amo samo on teq.servico = samo.servico_id " +
                "Left Join insumob I On samo.insumo_vinculado_id = i.insumo_id " +
                " Where not insumo_id is null And samo.INSUMO_INSTALACAO = 'S' And TEQ.Nivel = 1";
                            
            if (!string.IsNullOrEmpty(Uau_Comp))
                strSqlWhere += " And teq.codigo = '" + Uau_Comp + "' ";

            if (!string.IsNullOrEmpty(strSqlWhere))
                strSql += strSqlWhere;

            strSql += "Group By TEQ.codigo, i.insumo_id, i.insumo";

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regHistoricoInsumo = new Hist_Exporta_Qtde_Insumo();
                regHistoricoInsumo.INSUMO_ID = Convert.ToInt32(fb["INSUMO_ID"]);
                regHistoricoInsumo.INSUMO = Convert.ToString(fb["INSUMO"]);
                regHistoricoInsumo.COMPLEMENTO = Convert.ToString(fb["CODIGO"]);
                lista.Add(regHistoricoInsumo);
            }
            sql.Close();
            return lista;
        }
    }
}