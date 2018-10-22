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
using System.IO;
using ms = Microsoft.Office.Interop.MSProject;

namespace WindowsFormsApp2
{
    public enum TipoDeTarefaProject
    {
        tarefaResumoDoProjeto = 0,
        tarefaBloco = 2,
        tarefaGrupo = 3,
        tarefaServico = 4,
        tarefaPavimento = 5,
        tarefaOutro = 6

    }

    public static class FuncoesMSProject
    {
        public static TipoDeTarefaProject getTipoDeTarefa(ms.Task task)
        {
            TipoDeTarefaProject _tipoDeTarefaProject = TipoDeTarefaProject.tarefaResumoDoProjeto;
            if (task == null) return TipoDeTarefaProject.tarefaOutro;
            switch (task.OutlineLevel)
            {
                case 2:
                    _tipoDeTarefaProject = TipoDeTarefaProject.tarefaBloco;
                    break;
                case 3:
                    _tipoDeTarefaProject = TipoDeTarefaProject.tarefaGrupo;
                    break;
                case 4:
                    _tipoDeTarefaProject = TipoDeTarefaProject.tarefaServico;
                    break;
                case 5:
                    _tipoDeTarefaProject = TipoDeTarefaProject.tarefaPavimento;
                    break;
            }
            return _tipoDeTarefaProject;


        }

        public static void SetarPropriedade(ms.Task t, string nomePropriedade, string valorPropriedade)
        {
            Type myType = typeof(ms.Task);

            PropertyInfo[] vetor = myType.GetProperties();
            switch (nomePropriedade)
            {
                case "Text1":
                    t.Text1 = valorPropriedade;
                    break;
                case "Text2":
                    t.Text2 = valorPropriedade;
                    break;
                case "Text3":
                    t.Text3 = valorPropriedade;
                    break;

                case "Text4":
                    t.Text4 = valorPropriedade;
                    break;

                case "Text5":
                    t.Text5 = valorPropriedade;
                    break;

                case "Text6":
                    t.Text6 = valorPropriedade;
                    break;

                case "Text7":
                    t.Text7 = valorPropriedade;
                    break;
                case "Text8":
                    t.Text8 = valorPropriedade;
                    break;

                case "Text9":
                    t.Text9 = valorPropriedade;
                    break;

                case "Text10":
                    t.Text10 = valorPropriedade;
                    break;

                case "Text11":
                    t.Text11 = valorPropriedade;
                    break;

                case "Text12":
                    t.Text12 = valorPropriedade;
                    break;
                case "Text13":
                    t.Text13 = valorPropriedade;
                    break;
                case "Text14":
                    t.Text14 = valorPropriedade;
                    break;






                default:
                    break;
            }
           
        }


        public static string ObterPropriedade(ms.Task t, string nomePropriedade)
        {
            Type myType = typeof(ms.Task);

            PropertyInfo[] vetor = myType.GetProperties();
            switch (nomePropriedade)
            {
                case "Text1":
                   return t.Text1;
                    break;
                case "Text2":
                    return t.Text2;
                    break;
                case "Text3":
                    return t.Text3;
                    break;

                case "Text4":
                    return t.Text4;
                    break;

                case "Text5":
                    return t.Text5;
                    break;

                case "Text6":
                    return t.Text6;
                    break;

                case "Text7":
                    return t.Text7;
                    break;
                case "Text8":
                    return t.Text8;
                    break;

                case "Text9":
                    return t.Text9;
                    break;

                case "Text10":
                    return t.Text10;
                    break;

                case "Text11":
                    return t.Text11;
                    break;

                case "Text12":
                    return t.Text12;
                    break;
                case "Text13":
                    return t.Text13;
                    break;
                case "Text14":
                  return  t.Text14;
                    break;






                default:
                    return null;
                    break;
            }

        }


        public static DadosTarefaProjec GetDadosTarefaProject(ms.Task tarefa)
        {
            int valor;
            DadosTarefaProjec dados = new DadosTarefaProjec();
            if (!int.TryParse(ObterPropriedade(tarefa, Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID), out valor))
                return null;
            else dados.GRUPO_ID = valor;

            if (!int.TryParse(ObterPropriedade(tarefa, Properties.Settings.Default.SERVICO_ID), out valor))
                return null;
            else dados.SERVICO_ID= valor;

            if (!int.TryParse(ObterPropriedade(tarefa, Properties.Settings.Default.MEDICAO_BLOCO_ID), out valor))
                return null;
            else dados.MEDICAO_BLOCO_ID = valor;

            if (!int.TryParse(ObterPropriedade(tarefa, Properties.Settings.Default.BLOCO_ID), out valor))
                return null;
            else dados.BLOCO_D= valor;

            return dados;

        }

        public static void InserirNivel2(PAR_GERAR_MS_PROJECT par, ms.Application App)
        {
            ms.Task t = App.ActiveProject.Tasks.Add(par.DESCRICAO);
            t.OutlineLevel = Convert.ToInt16(par.NIVEL);
            SetarPropriedade(t, Properties.Settings.Default.BLOCO_ID, par.BLOCO_ID.ToString());
           

        }
        public static void InserirNivel3(PAR_GERAR_MS_PROJECT par, ms.Application App)
        {
            ms.Task t = App.ActiveProject.Tasks.Add(par.DESCRICAO);
            t.OutlineLevel = Convert.ToInt16(par.NIVEL);


            SetarPropriedade(t, Properties.Settings.Default.BLOCO_ID, par.BLOCO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID, par.GRUPO_PLAN_SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.SERVICO_ID, par.SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.MEDICAO_BLOCO_ID, par.MEDICAO_BLOCO_ID.ToString());


        } 
        public static void InserirNivel4(PAR_GERAR_MS_PROJECT par, ms.Application App)
        {
            ms.Task t = App.ActiveProject.Tasks.Add(par.DESCRICAO);
            t.OutlineLevel = Convert.ToInt16(par.NIVEL);

            SetarPropriedade(t, Properties.Settings.Default.BLOCO_ID, par.BLOCO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID, par.GRUPO_PLAN_SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.SERVICO_ID, par.SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.MEDICAO_BLOCO_ID, par.MEDICAO_BLOCO_ID.ToString());
        }
        public static void InserirNivel5(PAR_GERAR_MS_PROJECT par, ms.Application App)
        {
            ms.Task t = App.ActiveProject.Tasks.Add(par.DESCRICAO);
            t.OutlineLevel = Convert.ToInt16(par.NIVEL);

            SetarPropriedade(t, Properties.Settings.Default.BLOCO_ID, par.BLOCO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.GRUPO_PLAN_SERVICO_ID, par.GRUPO_PLAN_SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.SERVICO_ID, par.SERVICO_ID.ToString());


            SetarPropriedade(t, Properties.Settings.Default.MEDICAO_BLOCO_ID, par.MEDICAO_BLOCO_ID.ToString());
            try
            {
                t.Predecessors = par.PREDECESSORA;
            }
            catch
            {

            }
        }
      
      
        /* public static DataTable Grupo(Plan_servico_amoNegocio manipulacao)
         {
             return manipulacao.PRC_EXECUTAR_DIRETO();
         }*/

        public static DataTable TQTDE_POR_MEDICAO_BLOCO1(Plan_servico_amoNegocio manipulacao, string OBRA_ID)
        {
            return null; // manipulacao.GET_SITUACAO_ELEMENTO(null);
        }

        public static DataRow RetornarServico(DataTable dtServico, string valor)
        {
            return dtServico.Select("SERVICO ='" + valor + "'")[0];
        }
        public static DataRow RetornarQtdeMedicaoBloco(DataTable dtTQTDE_POR_MEDICAO_BLOCO1,
                                                      string codigoMedicaoBloco,
                                                      string codigoServico)

        {
            return dtTQTDE_POR_MEDICAO_BLOCO1.Select("SERVICO_ID =" + codigoServico + " and " +
                                                     "MEDICAO_BLOCO_ID = " + codigoMedicaoBloco)[0];
        }
        public static DataRow RetornarGrupo(DataTable dtGrupo, string NomeGrupo)
        {
            return dtGrupo.Select("GRUPO = " + "'" + NomeGrupo + "'")[0];
        }
        public static DataRow RetornarMedicaoBloco(DataTable dtMedicaoBloco, string CodigoBloco, string NomeMedicao)
        {
            return dtMedicaoBloco.Select("BLOCO_ID = " + CodigoBloco + " AND " +
                                     "MEDICAO = " + "'" + NomeMedicao + "'")[0];
        }

    }

}
