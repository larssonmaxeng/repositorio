using System;

using ObjetoTransferencia;

using System.Data;



namespace Negocios
{
    public class ACESSO_INSERIR_LVTMO_DIVERSO
    {
        public string Inserir(string dir, PAR_INSERIR_LVTMO_DIVERSO parametros)
        {
            AcessoBancoDados.FbsqlConnection fbsqlConnection = new AcessoBancoDados.FbsqlConnection();


            fbsqlConnection.Diretorio = dir;
            fbsqlConnection.Ativo(true);
            fbsqlConnection.t = fbsqlConnection.FbConexao.BeginTransaction();
            try
            {


                fbsqlConnection.AdicionarParametros("@descricao", parametros.DESCRICAO);
                fbsqlConnection.AdicionarParametros("@volume", parametros.VOLUME);
                fbsqlConnection.AdicionarParametros("@area_base", parametros.AREA_BASE);
                fbsqlConnection.AdicionarParametros("@categoria", parametros.CATEGORIA);
                fbsqlConnection.AdicionarParametros("@comprimento", parametros.COMPRIMENTO);
                fbsqlConnection.AdicionarParametros("@largura", parametros.LARGURA);
                fbsqlConnection.AdicionarParametros("@ALTURA", parametros.ALTURA);
                fbsqlConnection.AdicionarParametros("@ID_BIM", parametros.ID_BIM);
                fbsqlConnection.AdicionarParametros("@KG", parametros.KG);
                fbsqlConnection.AdicionarParametros("@AREA_TOPO", parametros.AREA_TOPO);
                fbsqlConnection.AdicionarParametros("@AREA", parametros.AREA);
                fbsqlConnection.AdicionarParametros("@AREA_LATERAL", parametros.AREA_LATERAL);
                fbsqlConnection.AdicionarParametros("@PERIMETRO", parametros.PERIMETRO);
                fbsqlConnection.AdicionarParametros("@BASE", parametros.BASE);
                fbsqlConnection.AdicionarParametros("@BASE_MAIOR", parametros.BASE_MAIOR);
                fbsqlConnection.AdicionarParametros("@ALTURA_MAIOR", parametros.ALTURA_MAIOR);
                fbsqlConnection.AdicionarParametros("@DIAMETER", parametros.DIAMETER);
                fbsqlConnection.AdicionarParametros("@SYSTEM_TYPE", parametros.SYSTEM_TYPE);
                fbsqlConnection.AdicionarParametros("@UNIDADE_PRINCIPAL", parametros.UNIDADE_PRINCIPAL);
                fbsqlConnection.AdicionarParametros("@AREA_FORMA", parametros.AREA_FORMA);
                fbsqlConnection.AdicionarParametros("@AMBIENTE", parametros.AMBIENTE);
                fbsqlConnection.AdicionarParametros("@APTO", parametros.APTO);
                fbsqlConnection.AdicionarParametros("@NBR_15965", parametros.NBR_15965);
                fbsqlConnection.AdicionarParametros("@POSICAO_X", parametros.POSICAO_X);
                fbsqlConnection.AdicionarParametros("@POSICAO_Y", parametros.POSICAO_Y);
                fbsqlConnection.AdicionarParametros("@POSICAO_Z", parametros.POSICAO_Z);
                fbsqlConnection.AdicionarParametros("@EXCLUIR", parametros.EXCLUIR);
                fbsqlConnection.AdicionarParametros("@TIPO_IMPORTACAO", parametros.TIPO_IMPORTACAO);
                fbsqlConnection.AdicionarParametros("@MODELO_GUID_ID", parametros.MODELO_GUID_ID);
                fbsqlConnection.AdicionarParametros("@GRUPO_ID", parametros.GRUPO_PLAN_SERVICO_ID);
                fbsqlConnection.AdicionarParametros("@MEDICAO_BLOCO_ID", parametros.MEDICAO_BLOCO_ID);
                fbsqlConnection.AdicionarParametros("@SERVICO_ID", parametros.SERVICO_ID);
                fbsqlConnection.AdicionarParametros("@INSERIR_INSUMO", parametros.INSERIR_INSUMO);

                FirebirdSql.Data.FirebirdClient.FbDataReader fb = fbsqlConnection.ExecutarConsultaLista(CommandType.StoredProcedure, "PRC_INSERIR_LVTMO_DIVERSO");
                string resultado;
                if (fb.Read()) resultado = fb[0].ToString();
                else resultado = "Não retornou valor";
                fbsqlConnection.t.Commit();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return resultado;

            }
            catch (Exception e)
            {
                fbsqlConnection.t.Rollback();
                fbsqlConnection.Close();
                fbsqlConnection.Dipose();
                return e.Message;
            }
        }

        public Boolean ExcluirMarca(string dir, int SERVICO_AMO_ID)
        {
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            FirebirdSql.Data.FirebirdClient.FbDataReader fb;
            string sqlStr;

            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Delete From servico_amo samo Where servico_amo_id = " + SERVICO_AMO_ID.ToString();

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
