﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text1")]
        public string BLOCO_ID {
            get {
                return ((string)(this["BLOCO_ID"]));
            }
            set {
                this["BLOCO_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text2")]
        public string GRUPO_PLAN_SERVICO_ID {
            get {
                return ((string)(this["GRUPO_PLAN_SERVICO_ID"]));
            }
            set {
                this["GRUPO_PLAN_SERVICO_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text3")]
        public string SERVICO_ID {
            get {
                return ((string)(this["SERVICO_ID"]));
            }
            set {
                this["SERVICO_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text4")]
        public string MEDICAO_BLOCO_ID {
            get {
                return ((string)(this["MEDICAO_BLOCO_ID"]));
            }
            set {
                this["MEDICAO_BLOCO_ID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text5")]
        public string texto5 {
            get {
                return ((string)(this["texto5"]));
            }
            set {
                this["texto5"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Text6")]
        public string texto6 {
            get {
                return ((string)(this["texto6"]));
            }
            set {
                this["texto6"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://200.178.248.104:86/PortalUauTestesQualidade/Webservices/wsAcompanhamentosS" +
            "ervicos.asmx?op=AcompanharServicoOrcado")]
        public string endereco {
            get {
                return ((string)(this["endereco"]));
            }
            set {
                this["endereco"] = value;
            }
        }
    }
}