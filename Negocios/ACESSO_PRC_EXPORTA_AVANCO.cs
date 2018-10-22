using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;

using FirebirdSql.Data.FirebirdClient;
namespace Negocios
{
    public class ACESSO_PRC_EXPORTA_AVANCO
    {
        public List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> EXPORTA_AVANCO(string dir, PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO epar)
        {
            List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> lista = new List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.EOBRA_ID);
            sql.AdicionarParametros("@EINICIO", epar.EINICIO);
            sql.AdicionarParametros("@EFIM", epar.EFIM);
            sql.AdicionarParametros("@EXPORTAR_PARA_PLANEJAMENTO", epar.EXPORTAR_PARA_PLANEJAMENTO);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb = 
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_AVANCO");
            while (fb.Read())
            {
                lista.Add(new PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO
                {
                    empresa = Convert.ToInt32(fb["empresa"]),
                    obra = fb["obra"].ToString(),
                    servico = fb["servico"].ToString(),
                    item = fb["item"].ToString(),
                    orcamento = Convert.ToInt32(fb["orcamento"]),
                    periodo = new DateTime(Convert.ToDateTime(fb["periodo"].ToString()).Year, Convert.ToDateTime(fb["periodo"].ToString()).Month, 1) . ToString("dd/MM/yyyy"),
                    diaRealizado = Convert.ToDateTime(fb["periodo"]),
                    quantidade = Convert.ToDouble(fb["quantidade"]),
                    usuarioLogado = fb["usuario_logado"].ToString(),
                    sequencia = fb["sequencia"].ToString(),
                    MEDICAO_BLOCO_ID = Convert.ToInt32(fb["MEDICAO_BLOCO_ID"]),
                    SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]),
                    EXPORTAR_PARA_PLANEJAMENTO = epar.EXPORTAR_PARA_PLANEJAMENTO,
                    produto = fb["PRODUTO"].ToString(),
                    contrato =fb["CONTRATO"].ToString()


                }
                );
            }
            sql.t.Commit();
            sql.Close();
            return lista;

        }
      
        public List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> ConfirmaExportaAvanco(string dir, List<PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO> par)
        {
           
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);


            foreach (PAR_ACOMPANHA_SERVICO_ORCADO_PLANEJADO epar in par)
            {
                if (epar.AvancadoNoUAU==1)
                {
                    try
                    {
                        sql.t = sql.FbConexao.BeginTransaction();
                        sql.LimparParametros();
                        sql.AdicionarParametros("@SERVICO_ID", epar.SERVICO_ID);
                        sql.AdicionarParametros("@PERIODO", epar.diaRealizado);
                        sql.AdicionarParametros("@MEDICAO_BLOCO_ID", epar.MEDICAO_BLOCO_ID);
                        sql.AdicionarParametros("@EXPORTAR_PARA_PLANEJAMENTO", epar.EXPORTAR_PARA_PLANEJAMENTO);
                        sql.ExecutarSemRetorno(System.Data.CommandType.StoredProcedure, "PRC_CONFIRMAR_EXPORTA_AVANCO");
                        sql.t.Commit();
                        epar.AvancadoNoTocBIM = 1;
                    }
                    catch (Exception e)
                    {
                        epar.AvancadoNoTocBIM = 0;
                    }
                }
                else epar.AvancadoNoTocBIM = 0;
            }
          
            sql.Close();
            return par;
        }
    }
}