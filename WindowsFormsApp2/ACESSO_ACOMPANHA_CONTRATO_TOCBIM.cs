using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using FirebirdSql.Data.FirebirdClient;

namespace Negocios
{
    public class ACESSO_ACOMPANHA_CONTRATO_UAU
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;

        public List<PAR_ACOMPANHA_CONTRATO_UAU> EXPORTA_ACOMP_CONTRATO(string dir, PAR_ACOMPANHA_CONTRATO_UAU epar)
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
        public Boolean GravaAcompanhamentoNoTocBIM(string dir, PAR_ACOMPANHA_CONTRATO_TOCBIM par)
        {
            List<PAR_ACOMPANHA_CONTRATO_TOCBIM> lista = new List<PAR_ACOMPANHA_CONTRATO_TOCBIM>();
            /*AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.EOBRA_ID);
            sql.AdicionarParametros("@EINICIO", epar.EINICIO);
            sql.AdicionarParametros("@EFIM", epar.EFIM);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_AVANCO");
            while (fb.Read())
            {
                lista.Add(new PAR_ACOMPANHA_SERVICO_ORCADO
                {
                    empresa = Convert.ToInt32(fb["empresa"]),
                    obra = fb["obra"].ToString(),
                    servico = fb["servico"].ToString(),
                    item = fb["item"].ToString(),
                    orcamento = Convert.ToInt32(fb["orcamento"]),
                    periodo = Convert.ToDateTime(fb["periodo"].ToString()).ToString("dd/MM/yyyy"),
                    quantidade = Convert.ToDouble(fb["quantidade"]),
                    usuarioLogado = fb["usuario_logado"].ToString(),
                    sequencia = fb["sequencia"].ToString()

                }
                );
            }
            sql.t.Commit();
            sql.Close();*/
            return true;
        }

        public List<PAR_ACOMPANHA_CONTRATO_UAU> GravaAcompanhamentoNoTocBIM(string dir, List<PAR_ACOMPANHA_CONTRATO_UAU> par)
        {
            string strSql;
            sql.Diretorio = dir;
            sql.Ativo(true);

            sql.t = sql.FbConexao.BeginTransaction();
            try
            {
                foreach (PAR_ACOMPANHA_CONTRATO_UAU epar in par)
                {
                    if (epar.acompanhadoUau == 1)
                    {
                        strSql = MontaUpdateTocBim(epar);
                        sql.ExecutarSemRetorno(System.Data.CommandType.Text, strSql);                                                
                        epar.acompanhadoTocBIM = 1;
                    }
                    else
                    {
                        epar.acompanhadoTocBIM = 0;
                    }                
                }
                sql.t.Commit();
            }
            catch
            {
                sql.t.Rollback();
            }
            
            sql.Close();
 
            return par;
        }

        private string MontaUpdateTocBim(PAR_ACOMPANHA_CONTRATO_UAU RegAcompContrato)
        {
            string strSql;

            strSql = "UPDATE PLAN_SERVICO_AMO PSA " +
                "SET PSA.tipo_estato_id = GEN_ID(const_confirmado_id, 0) " +
                "Where PSA.plan_servico_amo_id In( " +
                "Select PSA.plan_servico_amo_id " +
                "From plan_servico_amo psa " +
                "Inner Join servico_amo samo On psa.servico_amo_id = samo.servico_amo_id " +
                "Inner Join medicao_bloco mb On samo.medicao_bloco_id = mb.medicao_bloco_id " +
                "Inner Join medicao m On mb.medicao_id = m.medicao_id " +
                "Inner Join servico s On samo.servico_id = s.servico_id " +
                "Inner Join bloco b On mb.bloco_id = b.bloco_id " +
                "Inner Join obra o On o.obra_id = b.obra_id " +
                "Inner Join etapa e On s.etapa_id = e.etapa_id " +
                "Inner Join qtde_mapa_servico qms On psa.grupo_plan_servico_id = qms.grupo_id " +
                "                     And samo.servico_id = qms.servico_id " +
                "Inner Join item_estrutura_uau imu On imu.obra_id = b.obra_id And imu.desc_cger = m.medicao " +
                "                        And imu.item_eo = iif(s.posicao is null, e.item, iif(s.posicao < 9, e.item || '.0' || s.posicao, " +
                "                                            iif(s.posicao < 99, e.item || '.' || s.posicao, 'todo'))) " +
                "                        And imu.sequencia_eo = B.ordem || '.' || cast(MB.elevacao AS integer) " +
                "                        And imu.serv_eo = s.complemento " +
                "                        And imu.numorca_eo = o.sycrobra_id " +
                "Where psa.filho = 1 " +
                "And psa.tipo_estato_id = gen_id(const_pendente_id, 0) " +
                "And imu.obra_id = " + RegAcompContrato.input_obra_id.ToString() + " " +
                "And qms.contrato_erp = " + RegAcompContrato.contratoServico.ToString() + " " +
                "And qms.item_contrato_erp = " + RegAcompContrato.itemContrato.ToString() + " " +
                "And imu.serv_eo = '" + RegAcompContrato.servico.Trim() + "' " +
                "And psa.dia_realizado = '" + DateTime.Parse(RegAcompContrato.dataInicio).ToString("MM-dd-yyyy") + "' " +
                "And imu.sequencia_eo = '" + RegAcompContrato.sequencia.Trim() + "')";
                
            return strSql;
        }
    }
}