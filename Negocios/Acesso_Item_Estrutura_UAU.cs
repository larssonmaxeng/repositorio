using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class Acesso_Item_Estrutura_UAU
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string strSql;

        public List<Item_Estrutura_UAU> Listar(string dir, int Item_Estrutura_Uau_Id)
        {
            Item_Estrutura_UAU regItemControtoERP;
            List<Item_Estrutura_UAU> lista = new List<Item_Estrutura_UAU>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            strSql = "Select ITEM_ESTRUTURA_UAU_ID, OBRA_ID, Coalesce(CONTRATO_ERP_ID, 0) CONTRATO_ERP_ID, Coalesce(TIPO_EO, '') TIPO_EO, Coalesce(ITEM_EO, '') ITEM_EO, " +
                "Coalesce(SERV_EO, '') SERV_EO, Coalesce(SEQUENCIA_EO, '') SEQUENCIA_EO, Coalesce(CODITEM_EO, '') CODITEM_EO, Coalesce(DESC_CGER, '') DESC_CGER, " +
                "Coalesce(QTDE_EO, '') QTDE_EO, Coalesce(VALOR_EO, '') VALOR_EO, Coalesce(DINI_EO, '') DINI_EO, Coalesce(DFIM_EO, '') DFIM_EO, " +
                "Coalesce(OBRA_EO, '') OBRA_EO, Coalesce(NUMORCA_EO, '') NUMORCA_EO, Coalesce(SERVICO_ID, 0) SERVICO_ID, Coalesce(MEDICAO_BLOCO_ID, 0) MEDICAO_BLOCO_ID, " +
                "Coalesce(TIPO, 0) TIPO, Coalesce(CAD, '') CAD, DATA_CAD, Coalesce(ALT, '') ALT, DATA_ALT " +
                "From item_estrutura_uau ";

            if (Item_Estrutura_Uau_Id != 0)
                strSql += "Where ITEM_ESTRUTURA_UAU_ID = " + Item_Estrutura_Uau_Id.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, strSql);

            while (fb.Read())
            {
                regItemControtoERP = new Item_Estrutura_UAU();

                regItemControtoERP.ITEM_ESTRUTURA_UAU_ID = Convert.ToInt32(fb["ITEM_ESTRUTURA_UAU_ID"]);
                regItemControtoERP.CONTRATO_ERP_ID = Convert.ToInt32(fb["CONTRATO_ERP_ID"]);
                regItemControtoERP.TIPO_EO = Convert.ToString(fb["TIPO_EO"]);
                regItemControtoERP.ITEM_EO = Convert.ToString(fb["ITEM_EO"]);
                regItemControtoERP.SERV_EO = Convert.ToString(fb["SERV_EO"]);
                regItemControtoERP.SEQUENCIA_EO = Convert.ToString(fb["SEQUENCIA_EO"]);
                regItemControtoERP.CODITEM_EO = Convert.ToString(fb["CODITEM_EO"]);
                regItemControtoERP.DESC_CGER = Convert.ToString(fb["DESC_CGER"]);
                regItemControtoERP.QTDE_EO = Convert.ToString(fb["QTDE_EO"]);
                regItemControtoERP.VALOR_EO = Convert.ToString(fb["VALOR_EO"]);
                regItemControtoERP.DINI_EO = Convert.ToString(fb["DINI_EO"]);
                regItemControtoERP.DFIM_EO = Convert.ToString(fb["DFIM_EO"]);
                regItemControtoERP.OBRA_EO = Convert.ToString(fb["OBRA_EO"]);
                regItemControtoERP.NUMORCA_EO = Convert.ToString(fb["NUMORCA_EO"]);
                regItemControtoERP.SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]);
                regItemControtoERP.MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]);
                regItemControtoERP.TIPO = Convert.ToInt32(fb["TIPO"]);
                regItemControtoERP.CAD = Convert.ToString(fb["CAD"]);
                regItemControtoERP.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                regItemControtoERP.ALT = Convert.ToString(fb["ALT"]);
                regItemControtoERP.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);

                lista.Add(regItemControtoERP);
            }
            sql.Close();
            return lista;
        }

        public int Inserir(string dir, Item_Estrutura_UAU regItemControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "Insert into Item_Estrutura_Uau(OBRA_ID, CONTRATO_ERP_ID, TIPO_EO, ITEM_EO, SERV_EO, SEQUENCIA_EO, CODITEM_EO, DESC_CGER, QTDE_EO, VALOR_EO, " +
                    "DINI_EO, DFIM_EO, OBRA_EO, NUMORCA_EO, SERVICO_ID, MEDICAO_BLOCO_ID, TIPO) " +
                    "Values(" + regItemControtoERP.OBRA_ID.ToString() + ", " + regItemControtoERP.CONTRATO_ERP_ID.ToString() + ", '" + regItemControtoERP.TIPO_EO + "', '" +
                    regItemControtoERP.ITEM_EO + "', '" + regItemControtoERP.SERV_EO + "', '" + regItemControtoERP.SEQUENCIA_EO + "', '" + regItemControtoERP.CODITEM_EO + "', '" +
                    regItemControtoERP.DESC_CGER + "', '" + regItemControtoERP.QTDE_EO + "', '" + regItemControtoERP.VALOR_EO + "', '" + regItemControtoERP.DINI_EO + "', '" +
                    regItemControtoERP.DFIM_EO + "', '" + regItemControtoERP.OBRA_EO + "', '" + regItemControtoERP.NUMORCA_EO + "', " +
                    regItemControtoERP.SERVICO_ID.ToString() + ", " + regItemControtoERP.MEDICAO_BLOCO_ID.ToString() + ", " + regItemControtoERP.TIPO.ToString() +
                    ") returning ITEM_ESTRUTURA_UAU_ID ";                

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

        public Boolean Atualizar(string dir, Item_Estrutura_UAU regItemControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;            

            try
            {
                strSql = "Update Item_Estrutura_Uau Set OBRA_ID = " + regItemControtoERP.OBRA_ID + ", " +
                    "CONTRATO_ERP_ID = " + regItemControtoERP.CONTRATO_ERP_ID + ", " +
                    "TIPO_EO = '" + regItemControtoERP.TIPO_EO + "', " +
                    "ITEM_EO = '" + regItemControtoERP.ITEM_EO + "', " +
                    "SERV_EO = '" + regItemControtoERP.SERV_EO + "', " +
                    "SEQUENCIA_EO = '" + regItemControtoERP.SEQUENCIA_EO + "', " +
                    "CODITEM_EO = '" + regItemControtoERP.CODITEM_EO + "', " +
                    "DESC_CGER = '" + regItemControtoERP.DESC_CGER + "', " +
                    "QTDE_EO = '" + regItemControtoERP.QTDE_EO + "', " +
                    "VALOR_EO = '" + regItemControtoERP.VALOR_EO + "', " +
                    "DINI_EO = '" + regItemControtoERP.DINI_EO + "', " +
                    "DFIM_EO = '" + regItemControtoERP.DFIM_EO + "', " +
                    "OBRA_EO = '" + regItemControtoERP.OBRA_EO + "', " +
                    "NUMORCA_EO = '" + regItemControtoERP.NUMORCA_EO + "', " +
                    "SERVICO_ID = " + regItemControtoERP.SERVICO_ID.ToString() + ", " +
                    "MEDICAO_BLOCO_ID = " + regItemControtoERP.MEDICAO_BLOCO_ID.ToString() + ", " +
                    "TIPO = " + regItemControtoERP.TIPO.ToString() +
                    " Where ITEM_ESTRUTURA_UAU_ID = " + regItemControtoERP.ITEM_ESTRUTURA_UAU_ID.ToString();

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

        public Boolean Deletar(string dir, Item_Estrutura_UAU regItemControtoERP)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                strSql = "Delete From Item_Estrutura_Uau Where ITEM_ESTRUTURA_UAU_ID = " + regItemControtoERP.ITEM_ESTRUTURA_UAU_ID.ToString();

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

    }
}
