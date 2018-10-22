using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

namespace Negocios
{
   public class ACESSO_PRC_EXPORTA_QTDE
    {
        public List<PRC_EXPORTA_QTDE> Seleciona(string dir, int OBRA_ID, int versaoHistorico)
        {
            List<PRC_EXPORTA_QTDE> lista = new List<PRC_EXPORTA_QTDE>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            Acesso_Historico_Exporta_Qtde objNeg = new Acesso_Historico_Exporta_Qtde();
            //int versaoHistorico = objNeg.Buscar_Ultima_Versao(dir);
            //sql.AdicionarParametros("@CODOBRA", OBRA_ID.ToString());
            sql.AdicionarParametros("@VERSAOHISTORICO", versaoHistorico.ToString());
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_QTDE");
            while (fb.Read())
            {
            
                
                lista.Add(new PRC_EXPORTA_QTDE
                {
                    item = Convert.ToString(fb["ITEM"]),
                    codigo = Convert.ToString(fb["CODIGO"]),
                    sequencia = Convert.ToString(fb["SEQUENCIA"]),
                    servico = Convert.ToInt32(fb["SERVICO"]),
                    descricao = Convert.ToString(fb["DESCRICAO"]),
                    qtde = Convert.ToDouble(fb["QTDE"]),
                    prod_eq = Convert.ToInt32(fb["PRODEQ"]),
                    tipo = Convert.ToString(fb["TIPO"]),
                    inicio = Convert.ToDateTime(fb["INICIO"]),
                    fim = Convert.ToDateTime(fb["FIM"]),
                    tipo_servico = Convert.ToInt32(fb["TIPOSERVICO"]),
                    excluido = Convert.ToString(fb["EXCLUIDO"]),
                    unid = fb["UNID"].ToString(),
                    qtde_anterior = Convert.ToDouble(fb["QTDE_ANTERIOR"]),
                    desvinculado_anterior = Convert.ToString(fb["DESVINCULADO_ANTERIOR"]),
                    chave_erp = Convert.ToString(fb["CHAVE_ERP"]),
                    diferenca = Convert.ToDouble(fb["DIFERENCA"]),
                    nivel = Convert.ToInt32(fb["NIVEL"]),
                    item_novo = Convert.ToString(fb["ITEM_NOVO"]),
                    insumo_instalacao = Convert.ToString(fb["INSUMO_INSTALACAO"])
                });

            }
            sql.Close();
            return lista;
        }
    }
}
