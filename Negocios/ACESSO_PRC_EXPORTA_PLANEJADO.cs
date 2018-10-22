using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_PRC_EXPORTA_PLANEJADO
    {
        public List<PRC_EXPORTA_PLANEJADO> Seleciona(string dir, PRC_EXPORTA_PLANEJADO par)
        {
            List<PRC_EXPORTA_PLANEJADO> lista = new List<PRC_EXPORTA_PLANEJADO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sql.LimparParametros();
            sql.AdicionarParametros("@COD_OBR", par.cob_obr);
            //sql.AdicionarParametros("@ETIPO_PLANEJAMENTO", par.etipo_planejamento);
            
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_PLANEJADO");
            while (fb.Read())
            {
                lista.Add(new PRC_EXPORTA_PLANEJADO
                {
                    obra = Convert.ToString(fb["OBRA"]),
                    orcamento = Convert.ToInt32(fb["ORCAMENTO"]),
                    item = Convert.ToString(fb["ITEM"]),
                    servico = Convert.ToString(fb["SERVICO"]),
                    tipoqtde = Convert.ToString(fb["TIPOQTDE"]),
                    periodo = Convert.ToDateTime(fb["PERIODO"]),
                    qtde = Convert.ToDouble(fb["QTDE"]),
                    status = Convert.ToString(fb["STATUS"]),
                    sequencia = Convert.ToString(fb["SEQUENCIA"])
                });

            }
            sql.Close();
            return lista;
        }
        public List<PRC_EXPORTA_PLANEJADO> SelecionaAgrupadoPorMes(string dir, PRC_EXPORTA_PLANEJADO par)
        {
            List<PRC_EXPORTA_PLANEJADO> lista = new List<PRC_EXPORTA_PLANEJADO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sql.LimparParametros();
            sql.AdicionarParametros("@COD_OBR", par.cob_obr);
            //sql.AdicionarParametros("@ETIPO_PLANEJAMENTO", par.etipo_planejamento);

            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_PLANEJAMENTO_MES");
            while (fb.Read())
            {
                lista.Add(new PRC_EXPORTA_PLANEJADO
                {   
                    item = Convert.ToString(fb["ITEM"]),
                    codigo = Convert.ToString(fb["CODIGO"]),
                    descricao = Convert.ToString(fb["DESCRICAO"]),
                    qtde = Convert.ToDouble(fb["QTDE"]),
                    mes = Convert.ToDateTime(fb["MES"]),
                    coluna = Convert.ToString(fb["COLUNA"]),
                    qtde_mes = Convert.ToDouble(fb["QTDE_MES"])

                });
                
            }
            sql.Close();
            return lista;
        }

    }
}
