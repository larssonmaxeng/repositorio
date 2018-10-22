using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
    public class ACESSO_OBRA
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string sqlStr;
        private string strEmpresa_Id;
        private string strTerreno_Id;
        private string strPlanejamento;
        private string strControle;
        private string strProducao;
        private string strGestor;
        private string strCliente;
        private string strTipo_Estado_Id;
        private string strTipo_Ativo_Id;
        public List<Obra> Seleciona(string dir)
        {
            List<Obra> lista = new List<Obra>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =    sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "select o.obra_id,"+
                                                                 "  o.empresa_id,"+
                                                                 "  o.obra,"+
                                                                 "  o.nobra,"+
                                                                 "  o.sycrobra_id  "+
                                                                 " from obra o");
            while (fb.Read())
            {
                lista.Add(new Obra
                {
                    OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]),
                    OBRA = fb["OBRA"].ToString(),
                    NOBRA = fb["NOBRA"].ToString(),
                    EMPRESA_ID = Convert.ToInt32(fb["EMPRESA_ID"])
                });

            }
            sql.Close();
            return lista;
        }
        public List<Obra> Listar(string dir, int obraId)
        {
            Obra RegObraCad;
            List<Obra> lista = new List<Obra>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "Select O.OBRA_ID, O.EMPRESA_ID, E.EMPRESA, O.OBRA, O.NOBRA, Coalesce(O.REALIZADO, 0) REALIZADO, iif(O.META is null, 0,  O.META) Meta, " +
                "iif(O.P_EXECUCAO is null, 0, O.P_EXECUCAO) P_EXECUCAO, iif(O.DATA_META is null, '01/01/0001', O.DATA_META) DATA_META, " +
                "iif(O.INICIO is null, '01/01/0001', O.INICIO) INICIO, iif(O.TERMINO is null, '01/01/0001', O.TERMINO) TERMINO, " +
                "iif(O.PRAZO_DE_VENDA is null, 0, O.PRAZO_DE_VENDA) PRAZO_DE_VENDA, " +
                "iif(O.PRAZO_DE_REPASSE is null, 0, O.PRAZO_DE_REPASSE) PRAZO_DE_REPASSE, iif(O.DATA is null, '01/01/0001', O.DATA) DATA, " +
                "O.DATA_CAD, Coalesce(O.DATA_ALT, '01/01/0001') DATA_ALT, iif(O.ENGENHEIRO is null, '', O.ENGENHEIRO) ENGENHEIRO, iif(O.NCTR is null, '', O.NCTR) NCTR, " +
                "iif(O.CONSTRUTORA is null, '', O.CONSTRUTORA) CONSTRUTORA, iif(O.NCTC is null, '', O.NCTC) NCTC, " +
                "iif(O.PRECO_OBRA is null, 0, O.PRECO_OBRA) PRECO_OBRA, iif(O.INCC is null, 0, O.INCC) INCC, " +
                "iif(O.TIPO_ESTATO_ID is null, 0,  O.TIPO_ESTATO_ID) TIPO_ESTATO_ID, iif(O.TIPO_ATIVO_ID is null, 0,  O.TIPO_ATIVO_ID) TIPO_ATIVO_ID, " +
                "O.ALT, O.CAD, iif(O.PLANEJAMENTO is null, 0, O.PLANEJAMENTO) PLANEJAMENTO, iif(O.CONTROLE is null, 0, O.CONTROLE) CONTROLE, " +
                "iif(O.PRODUCAO is null, 0, O.PRODUCAO) PRODUCAO, iif(O.GESTOR is null, 0, O.GESTOR) GESTOR, " +
                "iif(O.CLIENTE is null, 0, O.CLIENTE) CLIENTE, O.DADOS_DO_MAPA, iif(O.MAPA_ORIGEM is null, '', O.MAPA_ORIGEM) MAPA_ORIGEM, " +
                "iif(O.VALOR_MAPA is null, '', O.VALOR_MAPA) VALOR_MAPA, iif(O.VALOR_MEDIDO is null, '', O.VALOR_MEDIDO) VALOR_MEDIDO, " +
                "iif(O.VALOR_BRUTO_DA_MEDICAO is null, '', O.VALOR_BRUTO_DA_MEDICAO) VALOR_BRUTO_DA_MEDICAO, " +
                "iif(O.SALDO_TOTAL is null, '', O.SALDO_TOTAL) SALDO_TOTAL, iif(O.PERCENT_EXECUTADO is null, '', O.PERCENT_EXECUTADO) PERCENT_EXECUTADO, " +
                "iif(O.CAMPO_ASSINATURA_01 is null, '', O.CAMPO_ASSINATURA_01) CAMPO_ASSINATURA_01, " +
                "iif(O.CAMPO_ASSINATURA_02 is null, '', O.CAMPO_ASSINATURA_02) CAMPO_ASSINATURA_02, " +
                "iif(O.CAMPO_ASSINATURA_03 is null, '', O.CAMPO_ASSINATURA_03) CAMPO_ASSINATURA_03, " +
                "iif(O.CAMPO_ASSINATURA_04 is null, '', O.CAMPO_ASSINATURA_04) CAMPO_ASSINATURA_04, " +
                "iif(O.TERRENO_ID is null, 0, O.TERRENO_ID) TERRENO_ID, iif(O.SICRONIZADO is null, 0, O.SICRONIZADO) SICRONIZADO, Coalesce(O.SYCROBRA_ID, 0) SYCROBRA_ID " +
                "From Obra O " +
                "Left Join Empresa E On O.EMPRESA_ID = E.EMPRESA_ID ";

            if (obraId != 0)
            {
                sqlStr += " Where O.OBRA_ID = " + obraId.ToString();
            }

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                RegObraCad = new Obra();

                RegObraCad.OBRA_ID = Convert.ToInt32(fb["OBRA_ID"]);
                RegObraCad.EMPRESA_ID = Convert.ToInt32(fb["EMPRESA_ID"]);
                RegObraCad.EMPRESA = Convert.ToString(fb["EMPRESA"]);
                RegObraCad.OBRA = Convert.ToString(fb["OBRA"]);
                RegObraCad.NOBRA = Convert.ToString(fb["NOBRA"]);
                RegObraCad.REALIZADO = Convert.ToDouble(fb["REALIZADO"]);
                RegObraCad.META = Convert.ToDouble(fb["META"]);
                RegObraCad.P_EXECUCAO = Convert.ToDouble(fb["P_EXECUCAO"]);
                RegObraCad.DATA_META = Convert.ToDateTime(fb["DATA_META"]);
                RegObraCad.INICIO = Convert.ToDateTime(fb["INICIO"]);
                RegObraCad.TERMINO = Convert.ToDateTime(fb["TERMINO"]);
                RegObraCad.PRAZO_DE_VENDA = Convert.ToInt32(fb["PRAZO_DE_VENDA"]);
                RegObraCad.PRAZO_DE_REPASSE = Convert.ToInt32(fb["PRAZO_DE_REPASSE"]);
                RegObraCad.DATA = Convert.ToDateTime(fb["DATA"]);
                RegObraCad.DATA_CAD = Convert.ToDateTime(fb["DATA_CAD"]);
                RegObraCad.DATA_ALT = Convert.ToDateTime(fb["DATA_ALT"]);
                RegObraCad.ENGENHEIRO = Convert.ToString(fb["ENGENHEIRO"]);
                RegObraCad.NCTR = Convert.ToString(fb["NCTR"]);
                RegObraCad.CONSTRUTORA = Convert.ToString(fb["CONSTRUTORA"]);
                RegObraCad.NCTC = Convert.ToString(fb["NCTC"]);
                RegObraCad.PRECO_OBRA = Convert.ToDouble(fb["PRECO_OBRA"]);
                RegObraCad.INCC = Convert.ToDouble(fb["INCC"]);
                RegObraCad.TIPO_ESTATO_ID = Convert.ToInt32(fb["TIPO_ESTATO_ID"]);
                RegObraCad.TIPO_ATIVO_ID = Convert.ToInt32(fb["TIPO_ATIVO_ID"]);
                RegObraCad.ALT = Convert.ToString(fb["ALT"]);
                RegObraCad.CAD = Convert.ToString(fb["CAD"]);
                RegObraCad.PLANEJAMENTO = Convert.ToInt32(fb["PLANEJAMENTO"]);
                RegObraCad.CONTROLE = Convert.ToInt32(fb["CONTROLE"]);
                RegObraCad.PRODUCAO = Convert.ToInt32(fb["PRODUCAO"]);
                RegObraCad.GESTOR = Convert.ToInt32(fb["GESTOR"]);
                RegObraCad.CLIENTE = Convert.ToInt32(fb["CLIENTE"]);
                RegObraCad.DADOS_DO_MAPA = Convert.ToString(fb["DADOS_DO_MAPA"]);
                RegObraCad.MAPA_ORIGEM = Convert.ToString(fb["MAPA_ORIGEM"]);
                RegObraCad.VALOR_MAPA = Convert.ToString(fb["VALOR_MAPA"]);
                RegObraCad.VALOR_MEDIDO = Convert.ToString(fb["VALOR_MEDIDO"]);
                RegObraCad.VALOR_BRUTO_DA_MEDICAO = Convert.ToString(fb["VALOR_BRUTO_DA_MEDICAO"]);
                RegObraCad.SALDO_TOTAL = Convert.ToString(fb["SALDO_TOTAL"]);
                RegObraCad.PERCENT_EXECUTADO = Convert.ToString(fb["PERCENT_EXECUTADO"]);
                RegObraCad.CAMPO_ASSINATURA_01 = Convert.ToString(fb["CAMPO_ASSINATURA_01"]);
                RegObraCad.CAMPO_ASSINATURA_02 = Convert.ToString(fb["CAMPO_ASSINATURA_02"]);
                RegObraCad.CAMPO_ASSINATURA_03 = Convert.ToString(fb["CAMPO_ASSINATURA_03"]);
                RegObraCad.CAMPO_ASSINATURA_04 = Convert.ToString(fb["CAMPO_ASSINATURA_04"]);
                RegObraCad.TERRENO_ID = Convert.ToInt32(fb["TERRENO_ID"]);
                RegObraCad.SICRONIZADO = Convert.ToInt32(fb["SICRONIZADO"]);
                RegObraCad.SYCROBRA_ID = Convert.ToInt32(fb["SYCROBRA_ID"]);
                lista.Add(RegObraCad);
            }
            sql.Close();
            return lista;
        }

        public int Inserir(string dir, Obra RegObraCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarChaveEstrangeira(RegObraCad);

            try
            {
                sqlStr = "Insert InTo Obra (EMPRESA_ID," +
                                             " OBRA, " +
                                             "NOBRA, " +
                                             "REALIZADO, " +
                                             "META, " +
                                             "P_EXECUCAO, " +
                                             "DATA_META, INICIO, TERMINO, PRAZO_DE_VENDA, " +
                    "PRAZO_DE_REPASSE, DATA, DATA_CAD, DATA_ALT, ENGENHEIRO, NCTR, CONSTRUTORA, NCTC, PRECO_OBRA, INCC, TIPO_ESTATO_ID, " +
                    "TIPO_ATIVO_ID, ALT, CAD, PLANEJAMENTO, CONTROLE, PRODUCAO, GESTOR, CLIENTE, DADOS_DO_MAPA, MAPA_ORIGEM, VALOR_MAPA, " +
                    "VALOR_MEDIDO, VALOR_BRUTO_DA_MEDICAO, SALDO_TOTAL, PERCENT_EXECUTADO, CAMPO_ASSINATURA_01, CAMPO_ASSINATURA_02, CAMPO_ASSINATURA_03, " +
                    "CAMPO_ASSINATURA_04, TERRENO_ID, SICRONIZADO, SYCROBRA_ID) " +
                    "Values (" + strEmpresa_Id + ", '" + RegObraCad.OBRA + "', '" + RegObraCad.NOBRA + "', " +
                    RegObraCad.REALIZADO.ToString() + ", " + RegObraCad.META.ToString() + ", " + RegObraCad.P_EXECUCAO.ToString() + ", '" + RegObraCad.DATA_META.ToString("MM/dd/yyyy") + "', '" +
                    RegObraCad.INICIO.ToString("MM/dd/yyyy") + "', '" + RegObraCad.TERMINO.ToString("MM/dd/yyyy") + "', " + RegObraCad.PRAZO_DE_VENDA.ToString() + ", " +
                    RegObraCad.PRAZO_DE_REPASSE.ToString() + ", '" + RegObraCad.DATA.ToString("MM/dd/yyyy") + "', '" + RegObraCad.DATA_CAD.ToString("MM/dd/yyyy") + "', '" +
                    RegObraCad.DATA_ALT.ToString("MM/dd/yyyy") + "', '" + RegObraCad.ENGENHEIRO + "', '" + RegObraCad.NCTR + "', '" + RegObraCad.CONSTRUTORA + "', '" +
                    RegObraCad.NCTC + "', " + RegObraCad.PRECO_OBRA.ToString() + ", " + RegObraCad.INCC.ToString() + ", " + strTipo_Estado_Id + ", " +
                    strTipo_Ativo_Id + ", '" + RegObraCad.ALT + "', '" + RegObraCad.CAD + "', " + strPlanejamento + ", " +
                    strControle + ", " + strProducao + ", " + strGestor + ", " + strCliente + ", '" +
                    RegObraCad.DADOS_DO_MAPA + "', '" + RegObraCad.MAPA_ORIGEM + "', '" + RegObraCad.VALOR_MAPA + "', '" + RegObraCad.VALOR_MEDIDO + "', '" +
                    RegObraCad.VALOR_BRUTO_DA_MEDICAO + "', '" + RegObraCad.SALDO_TOTAL + "', '" + RegObraCad.PERCENT_EXECUTADO + "', '" + RegObraCad.CAMPO_ASSINATURA_01 + "', '" +
                    RegObraCad.CAMPO_ASSINATURA_02 + "', '" + RegObraCad.CAMPO_ASSINATURA_03 + "', '" + RegObraCad.CAMPO_ASSINATURA_04 + "', " +
                    strTerreno_Id + ", " + RegObraCad.SICRONIZADO.ToString() + ", " + RegObraCad.SYCROBRA_ID.ToString() + ") returning OBRA_ID";

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarManipulacao(System.Data.CommandType.Text, sqlStr);
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

        private void ValidarChaveEstrangeira(Obra RegObraCad)
        {
            if (RegObraCad.EMPRESA_ID == 0)
                strEmpresa_Id = "null";
            else
                strEmpresa_Id = RegObraCad.EMPRESA_ID.ToString();

            if (RegObraCad.TERRENO_ID == 0)
                strTerreno_Id = "null";
            else
                strTerreno_Id = RegObraCad.TERRENO_ID.ToString();

            if (RegObraCad.PLANEJAMENTO == 0)
                strPlanejamento = "null";
            else
                strPlanejamento = RegObraCad.PLANEJAMENTO.ToString();

            if (RegObraCad.CONTROLE == 0)
                strControle = "null";
            else
                strControle = RegObraCad.CONTROLE.ToString();

            if (RegObraCad.PRODUCAO == 0)
                strProducao = "null";
            else
                strProducao = RegObraCad.PRODUCAO.ToString();

            if (RegObraCad.GESTOR == 0)
                strGestor = "null";
            else
                strGestor = RegObraCad.GESTOR.ToString();

            if (RegObraCad.CLIENTE == 0)
                strCliente = "null";
            else
                strCliente = RegObraCad.CLIENTE.ToString();

            if (RegObraCad.TIPO_ATIVO_ID == 0)
                strTipo_Ativo_Id = "null";
            else
                strTipo_Ativo_Id = RegObraCad.TIPO_ATIVO_ID.ToString();

            if (RegObraCad.TIPO_ESTATO_ID == 0)
                strTipo_Estado_Id = "null";
            else
                strTipo_Estado_Id = RegObraCad.TIPO_ESTATO_ID.ToString();
        }


        public Boolean Atualizar(string dir, Obra RegObraCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            ValidarChaveEstrangeira(RegObraCad);

            try
            {
                sqlStr = "Update Obra Set EMPRESA_ID = " + strEmpresa_Id + ", " +
                    "OBRA = '" + RegObraCad.OBRA + "'," +
                    "NOBRA = '" + RegObraCad.NOBRA + "', " +
                    "REALIZADO = " + RegObraCad.REALIZADO.ToString() + ", " +
                    "META = " + RegObraCad.META.ToString() + ", " +
                    "P_EXECUCAO = " + RegObraCad.P_EXECUCAO.ToString() + ", " +
                    "DATA_META = '" + RegObraCad.DATA_META.ToString("MM/dd/yyyy") + "', " +
                    "INICIO = '" + RegObraCad.INICIO.ToString("MM/dd/yyyy") + "', " +
                    "TERMINO = '" + RegObraCad.TERMINO.ToString("MM/dd/yyyy") + "', " +
                    "PRAZO_DE_VENDA = " + RegObraCad.PRAZO_DE_VENDA.ToString() + ", " +
                    "PRAZO_DE_REPASSE = " + RegObraCad.PRAZO_DE_REPASSE.ToString() + ", " +
                    "DATA = '" + RegObraCad.DATA.ToString("MM/dd/yyyy") + "', " +
                    "DATA_CAD = '" + RegObraCad.DATA_CAD.ToString("MM/dd/yyyy") + "', " +
                    "DATA_ALT = '" + RegObraCad.DATA_ALT.ToString("MM/dd/yyyy") + "', " +
                    "ENGENHEIRO = '" + RegObraCad.ENGENHEIRO + "', " +
                    "NCTR = '" + RegObraCad.NCTR + "', " +
                    "CONSTRUTORA = '" + RegObraCad.CONSTRUTORA + "', " +
                    "NCTC = '" + RegObraCad.NCTC + "', " +
                    "PRECO_OBRA = " + RegObraCad.PRECO_OBRA.ToString() + ", " +
                    "INCC = " + RegObraCad.INCC.ToString() + ", " +
                    "TIPO_ESTATO_ID = " + strTipo_Estado_Id + ", " +
                    "TIPO_ATIVO_ID = " + strTipo_Ativo_Id + ", " +
                    "ALT = '" + RegObraCad.ALT + "', " +
                    "CAD = '" + RegObraCad.CAD + "', " +
                    "PLANEJAMENTO = " + strPlanejamento + ", " +
                    "CONTROLE = " + strControle + ", " +
                    "PRODUCAO = " + strProducao + ", " +
                    "GESTOR = " + strGestor + ", " +
                    "CLIENTE = " + strCliente + ", " +
                    "DADOS_DO_MAPA = '" + RegObraCad.DADOS_DO_MAPA + "', " +
                    "MAPA_ORIGEM = '" + RegObraCad.MAPA_ORIGEM + "', " +
                    "VALOR_MAPA = '" + RegObraCad.VALOR_MAPA + "', " +
                    "VALOR_MEDIDO = '" + RegObraCad.VALOR_MEDIDO + "', " +
                    "VALOR_BRUTO_DA_MEDICAO = '" + RegObraCad.VALOR_BRUTO_DA_MEDICAO + "', " +
                    "SALDO_TOTAL = '" + RegObraCad.SALDO_TOTAL + "', " +
                    "PERCENT_EXECUTADO = '" + RegObraCad.PERCENT_EXECUTADO + "', " +
                    "CAMPO_ASSINATURA_01 = '" + RegObraCad.CAMPO_ASSINATURA_01 + "', " +
                    "CAMPO_ASSINATURA_02 = '" + RegObraCad.CAMPO_ASSINATURA_02 + "', " +
                    "CAMPO_ASSINATURA_03 = '" + RegObraCad.CAMPO_ASSINATURA_03 + "', " +
                    "CAMPO_ASSINATURA_04 = '" + RegObraCad.CAMPO_ASSINATURA_04 + "', " +
                    "TERRENO_ID = " + strTerreno_Id + ", " +
                    "SICRONIZADO = " + RegObraCad.SICRONIZADO.ToString() + ", " +
                    "SYCROBRA_ID = " + RegObraCad.SYCROBRA_ID.ToString() +
                    " Where OBRA_ID = " + RegObraCad.OBRA_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, sqlStr);
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

        public Boolean Deletar(string dir, Obra RegObraCad)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Delete From Obra Where Obra_Id = " + RegObraCad.OBRA_ID.ToString();

                sql.t = sql.FbConexao.BeginTransaction();
                obj = sql.ExecutarDireto(System.Data.CommandType.Text, sqlStr);
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
