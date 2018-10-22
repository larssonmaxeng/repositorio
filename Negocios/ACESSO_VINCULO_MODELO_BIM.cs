using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using AcessoBancoDados;

namespace Negocios
{
    public class ACESSO_VINCULO_MODELO_BIM
    {
        private AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
        private FirebirdSql.Data.FirebirdClient.FbDataReader fb;
        private string sqlStr;

        public List<VINCULO_MODELO_BIM> Seleciona(string dir, string modeloGUID)
        {
            List<VINCULO_MODELO_BIM> lista = new List<VINCULO_MODELO_BIM>();
            AcessoBancoDados.FbsqlConnection sql = new AcessoBancoDados.FbsqlConnection();
            sql.Diretorio = dir;
            sql.Ativo(true);
            FirebirdSql.Data.FirebirdClient.FbDataReader fb =
                sql.ExecutarConsultaLista(System.Data.CommandType.Text,
                                                               "select mb.vinculo_modelo_bim_id, "+
                                                                 "     mb.servico_id," +
                                                                 "     mb.modelo_guid_id," +
                                                                  "    mb.categoria_id," +
                                                                 "     mb.familia_id," +
                                                                 "     mb.tipo_familia_id," +
                                                                 "     mb.familia," +
                                                                 "     mb.categoria," +
                                                                 "     mb.tipo_familia" +
                                                              " from vinculo_modelo_bim mb "+
                                                              " where modelo_guid_id = '"+modeloGUID+"'"
                                                              );
            while (fb.Read())
            {
                 lista.Add(new VINCULO_MODELO_BIM
                 {
                     CATEGORIA = fb["CATEGORIA"].ToString(),
                     CATEGORIA_ID   = fb["CATEGORIA_ID"].ToString(),
                     FAMILIA    = fb["FAMILIA"].ToString(),
                     FAMILIA_ID= fb["FAMILIA_ID"].ToString(),
                     MODELO_GUID_ID= fb["MODELO_GUID_ID"].ToString(),
                     SERVICO_ID= Convert.ToInt32(fb["SERVICO_ID"]),
                     TIPO_FAMILIA= fb["TIPO_FAMILIA"].ToString(),
                     TIPO_FAMILIA_ID= Convert.ToInt32(fb["TIPO_FAMILIA_ID"]),
                     VINCULO_MODELO_BIM_ID= Convert.ToInt32(fb["VINCULO_MODELO_BIM_ID"]),
                 });

            }
            sql.Close();
            return lista;
        }

        public List<VINCULO_MODELO_BIM> ListarVinculo(string dir, int obraId, string modeloGuidId, string categoriaId, string familiaId, int tipoFamiliaId, int servicoId)
        {
            VINCULO_MODELO_BIM RegVinculo;
            List<VINCULO_MODELO_BIM> ListaVin = new List<VINCULO_MODELO_BIM>();
            sql.Diretorio = dir;
            sql.Ativo(true);

            sqlStr = "Select Vmb.FAMILIA_ID, Vmb.TIPO_FAMILIA, Vmb.VINCULO_MODELO_BIM_ID, Vmb.SERVICO_ID, Vmb.MODELO_GUID_ID, Vmb.CATEGORIA_ID, Vmb.TIPO_FAMILIA_ID, Vmb.FAMILIA, " +
                "Vmb.CATEGORIA,  Vmb.ELEMENTO, Ser.SERVICO, Ser.COMPLEMENTO " +
                "From VINCULO_MODELO_BIM As Vmb " +
                "Left Join modelo_obra As Mo On Mo.MODELO_GUID_ID = Vmb.MODELO_GUID_ID " +
                "Left Join SERVICO As Ser On Ser.SERVICO_ID = Vmb.SERVICO_ID " +
                "Where Mo.Obra_Id = " + obraId.ToString() +
                " And Vmb.MODELO_GUID_ID = '" + modeloGuidId + "'";

            if (categoriaId.Trim() != "")
                sqlStr += " And CATEGORIA_ID = '" + categoriaId + "' ";

            if (familiaId.Trim() != "")
                sqlStr += " And FAMILIA_ID = '" + familiaId + "' ";

            if (tipoFamiliaId != 0)
                sqlStr += " And TIPO_FAMILIA_ID = " + tipoFamiliaId.ToString();

            if (servicoId != 0)
                sqlStr += " And Vmb.SERVICO_ID = " + servicoId.ToString();

            fb = sql.ExecutarConsultaLista(System.Data.CommandType.Text, sqlStr);

            while (fb.Read())
            {
                RegVinculo = new VINCULO_MODELO_BIM();
                RegVinculo.VINCULO_MODELO_BIM_ID = Convert.ToInt32(fb["VINCULO_MODELO_BIM_ID"]);
                RegVinculo.SERVICO_ID = Convert.ToInt32(fb["SERVICO_ID"]);
                RegVinculo.MODELO_GUID_ID = fb["MODELO_GUID_ID"].ToString();
                RegVinculo.CATEGORIA = fb["CATEGORIA"].ToString();
                RegVinculo.CATEGORIA_ID = fb["CATEGORIA_ID"].ToString();
                RegVinculo.FAMILIA = fb["FAMILIA"].ToString();
                RegVinculo.FAMILIA_ID = fb["FAMILIA_ID"].ToString();
                RegVinculo.TIPO_FAMILIA = fb["TIPO_FAMILIA"].ToString();
                RegVinculo.TIPO_FAMILIA_ID = Convert.ToInt32(fb["TIPO_FAMILIA_ID"]);
                RegVinculo.ELEMENTO = fb["ELEMENTO"].ToString();
                RegVinculo.SERVICO = fb["SERVICO"].ToString();
                RegVinculo.COMPLEMENTO = fb["COMPLEMENTO"].ToString();
                ListaVin.Add(RegVinculo);
                
            }

            sql.Close();

            return ListaVin;
        }

        public Boolean Inserir(string dir, VINCULO_MODELO_BIM RegVincModBim)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Insert InTo VINCULO_MODELO_BIM (SERVICO_ID, MODELO_GUID_ID, CATEGORIA_ID, FAMILIA_ID, " +
                    " TIPO_FAMILIA_ID, FAMILIA, CATEGORIA, TIPO_FAMILIA, ELEMENTO) " +
                    "Values (" + RegVincModBim.SERVICO_ID.ToString() + ", '" + RegVincModBim.MODELO_GUID_ID + "', '" +
                    RegVincModBim.CATEGORIA_ID + "', '" + RegVincModBim.FAMILIA_ID + "', " + RegVincModBim.TIPO_FAMILIA_ID.ToString() + ", '" + RegVincModBim.FAMILIA + "', '" + 
                    RegVincModBim.CATEGORIA + "', '" + RegVincModBim.TIPO_FAMILIA + "', '" + RegVincModBim.ELEMENTO + "')";

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

        public Boolean Atualizar(string dir, VINCULO_MODELO_BIM RegVincModBim)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Update VINCULO_MODELO_BIM Set SERVICO_ID = " + RegVincModBim.SERVICO_ID.ToString() + "," +
                    "MODELO_GUID_ID = '" + RegVincModBim.MODELO_GUID_ID + "'," +
                    "CATEGORIA_ID = '" + RegVincModBim.CATEGORIA_ID + "', " +
                    "FAMILIA_ID = '" + RegVincModBim.FAMILIA_ID + "', " +
                    "TIPO_FAMILIA_ID = " + RegVincModBim.TIPO_FAMILIA_ID.ToString() + ", " +
                    "FAMILIA = '" + RegVincModBim.FAMILIA + "', " +
                    "CATEGORIA = '" + RegVincModBim.CATEGORIA + "', " +
                    "TIPO_FAMILIA = '" + RegVincModBim.TIPO_FAMILIA + "', " +
                    "ELEMENTO = '" + RegVincModBim.ELEMENTO + "'" +
                    " Where VINCULO_MODELO_BIM_ID = " + RegVincModBim.VINCULO_MODELO_BIM_ID.ToString();

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

        public Boolean Deletar(string dir, VINCULO_MODELO_BIM RegVincModBim)
        {
            sql.Diretorio = dir;
            sql.Ativo(true);
            Object obj;

            try
            {
                sqlStr = "Delete From VINCULO_MODELO_BIM Where VINCULO_MODELO_BIM_ID = " + RegVincModBim.VINCULO_MODELO_BIM_ID.ToString();

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

        public List<CategoriaFamiliaTipoRevit> VerificarAlteracaoNome(string dir, string modeloGuidId, List<CategoriaFamiliaTipoRevit> listaRevit)
        {
            List<VINCULO_MODELO_BIM> listaVniculo = new List<VINCULO_MODELO_BIM>();
            List<CategoriaFamiliaTipoRevit> listaRevitAux = new List<CategoriaFamiliaTipoRevit>();

            foreach (CategoriaFamiliaTipoRevit regRevit in listaRevit)
            {
                if (regRevit.CATEGORIA_ID != null && regRevit.FAMILIA_ID != null && regRevit.TIPO_FAMILIA_ID != null)
                {
                    listaVniculo = ListarVinculo(dir, 2, modeloGuidId, regRevit.CATEGORIA_ID, regRevit.FAMILIA_ID, Convert.ToInt32(regRevit.TIPO_FAMILIA_ID), 0);
                    if (listaVniculo.Count > 0)
                    {
                        regRevit.VINCULADO = true;
                        foreach (VINCULO_MODELO_BIM regVinculo in listaVniculo)
                        {
                            regRevit.VINCULADO_NOME_DIFERENTE = false;
                            if (regRevit.TIPO_FAMILIA != regVinculo.TIPO_FAMILIA)
                            {
                                regRevit.VINCULADO_NOME_DIFERENTE = true;
                                break;
                            }
                        }
                    }
                }
                listaRevitAux.Add(regRevit);
            }
            return listaRevitAux;
        }
    }
}
