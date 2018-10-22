using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_ACOMPANHA_CONTRATO
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;

        public List<PAR_ACOMPANHA_CONTRATO_UAU> EXPORTA_ACOMPANHA_CONTRATO(string dir, PAR_ACOMPANHA_CONTRATO_UAU epar)
        {
            List<PAR_ACOMPANHA_CONTRATO_UAU> lista = new List<PAR_ACOMPANHA_CONTRATO_UAU>();           

            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.input_obra_id);
            sql.AdicionarParametros("@EINICIO", epar.input_inicio);
            sql.AdicionarParametros("@EFIM", epar.input_fim);

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_ACOMPANHAR_SERVICO_CONTRATO");

            while (fb.Read())
            {
                try
                {
                    lista.Add(new PAR_ACOMPANHA_CONTRATO_UAU
                    {
                        empresa = Convert.ToInt32(fb["EMPRESA"]),
                        obra = Convert.ToString(fb["OBRA"]),
                        contratoServico = Convert.ToInt32(fb["CONTRATO_SERVICO"]),
                        itemContrato = Convert.ToInt32(fb["ITEM_CONTRATO"]),
                        servico = Convert.ToString(fb["SERVICO"]),
                        dataInicio = Convert.ToString(fb["DATA_INICIO"]),
                        dataFim = Convert.ToString(fb["DATA_FIM"]),
                        mesPl = Convert.ToString(fb["MES_PL"]),
                        quantidade = Convert.ToDouble(fb["QUANTIDADE"]),
                        porcentagemAcomp = Convert.ToDouble(fb["PORCENTAGEM_ACOMP"]),
                        observacoes = Convert.ToString(fb["OBSERVACOES"]),
                        etapa = Convert.ToString(fb["ETAPA"]),
                        codEstrutura = Convert.ToString(fb["COD_ESTRUTURA"]),
                        sequencia = Convert.ToString(fb["SEQUENCIA"]),
                        usuarioLogado = Convert.ToString(fb["USUARIO_LOGADO"]),
                        input_obra_id = epar.input_obra_id
                    }
                    );
                }
                catch
                {
                }
            }
            sql.t.Commit();
            sql.Close();
            return lista;
        }

        //Verificar com Larsson sobre procedure PRC_GRAVA_ACOMP_CONTRATO
        public List<PAR_ACOMPANHA_CONTRATO_UAU> GravaAcompanhamentoNoTocBIM(string dir, List<PAR_ACOMPANHA_CONTRATO_UAU> par)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);

            //foreach (PAR_ACOMPANHA_CONTRATO_UAU epar in par)
            //{
                try
                {
                    //if (epar.acompanhadoUau == 1)
                    //{
                        sql.t = sql.FbConexao.BeginTransaction();
                        //sql.LimparParametros();
                        //sql.AdicionarParametros("@EOBRA_ID", epar.input_obra_id);
                        //sql.AdicionarParametros("@CONTRATO_SERVICO", epar.contratoServico);
                        //sql.AdicionarParametros("@ITEM_CONTRATO", epar.itemContrato);
                        //sql.AdicionarParametros("@SERVICO", epar.servico);
                        //sql.AdicionarParametros("@DIA_REALIZADO", epar.dataInicio);
                        //sql.AdicionarParametros("@SEQUENCIA", epar.sequencia);
                        //sql.AdicionarParametros("@COD_ESTRUTURA", epar.codEstrutura);
                        sql.ExecutarSemRetorno(System.Data.CommandType.StoredProcedure, "PRC_GRAVA_ACOMP_CONTRATO");
                        sql.t.Commit();
                        //epar.acompanhadoTocBIM = 1;
                    //}
                    //else
                    //{
                    //    epar.acompanhadoTocBIM = 0;
                    //}
                }
                catch
                {
                    sql.t.Rollback();
                    //epar.acompanhadoTocBIM = 0;
                }
            //}
            sql.Close();

            return par;
        }
    }
}
