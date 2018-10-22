using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjetoTransferencia;
using Negocios;

namespace WindowsFormsApp2
{
    public class ACESSO_ITENS_CONTRATO_UAU
    {
        /*public List<PAR_ACOMPANHA_CONTRATO_UAU> EXPORTA_ACOMP_CONTRATO(string dir, PAR_ACOMPANHA_CONTRATO_UAU epar)
        {
    /*        List<PAR_ACOMPANHA_CONTRATO_UAU> lista = new List<PAR_ACOMPANHA_CONTRATO_UAU>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            sql.t = sql.FbConexao.BeginTransaction();
            sql.AdicionarParametros("@EOBRA_ID", epar.input_obra_id);
            sql.AdicionarParametros("@EINICIO", epar.input_inicio);
            sql.AdicionarParametros("@EFIM", epar.input_fim);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.StoredProcedure, "PRC_EXPORTA_AVANCO");
            while (fb.Read())
            {
                lista.Add(new PAR_ACOMPANHA_CONTRATO_UAU
                {
                    empresa = Convert.ToInt32(fb["empresa"]),
                    obra = Convert.ToString(fb["empresa"]),
                    contratoServico = Convert.ToInt32(fb["empresa"]),
                    itemContrato = Convert.ToInt32(fb["empresa"]),
                    servico = Convert.ToString(fb["empresa"]),
                    dataInicio = Convert.ToString(fb["empresa"]),
                    dataFim = Convert.ToString(fb["empresa"]),
                    mesPl = Convert.ToString(fb["empresa"]),
                    quantidade = Convert.ToDouble(fb["empresa"]),
                    porcentagemAcomp = Convert.ToDouble(fb["empresa"]),
                    observacoes = Convert.ToString(fb["empresa"]),
                    etapa = Convert.ToString(fb["empresa"]),
                    codEstrutura = Convert.ToString(fb["empresa"]),
                    sequencia = Convert.ToString(fb["empresa"]),
                    usuarioLogado = Convert.ToString(fb["empresa"]),

                }
                );
            }
            sql.t.Commit();
            sql.Close();
            return lista;
            
        */
    }
}
