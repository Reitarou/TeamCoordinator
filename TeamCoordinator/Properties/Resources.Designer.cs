﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeamCoordinator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TeamCoordinator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Add {
            get {
                object obj = ResourceManager.GetObject("Add", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Файл с данным именем уже существует.
        ///Перезаписать?.
        /// </summary>
        internal static string eFileAlreadyExists {
            get {
                return ResourceManager.GetString("eFileAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не существует указанного файла.
        /// </summary>
        internal static string eNoFile {
            get {
                return ResourceManager.GetString("eNoFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Этап с заданным именем уже существует.
        /// </summary>
        internal static string eStageAlreadyExist {
            get {
                return ResourceManager.GetString("eStageAlreadyExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Команда с заданным именем уже существует.
        /// </summary>
        internal static string eTeamAlreadyExist {
            get {
                return ResourceManager.GetString("eTeamAlreadyExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Внимание!.
        /// </summary>
        internal static string mWarning {
            get {
                return ResourceManager.GetString("mWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Remove {
            get {
                object obj = ResourceManager.GetObject("Remove", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Добавить комментарий.
        /// </summary>
        internal static string sAddComment {
            get {
                return ResourceManager.GetString("sAddComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to База.
        /// </summary>
        internal static string sBase {
            get {
                return ResourceManager.GetString("sBase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Settings {
            get {
                object obj = ResourceManager.GetObject("Settings", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Выключить таймер.
        /// </summary>
        internal static string sRefreshTimerSwitchOff {
            get {
                return ResourceManager.GetString("sRefreshTimerSwitchOff", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Включить таймер.
        /// </summary>
        internal static string sRefreshTimerSwitchOn {
            get {
                return ResourceManager.GetString("sRefreshTimerSwitchOn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пройден.
        /// </summary>
        internal static string sStageComplete {
            get {
                return ResourceManager.GetString("sStageComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Этап свободен.
        /// </summary>
        internal static string sStageFree {
            get {
                return ResourceManager.GetString("sStageFree", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} - &quot;{1}&quot; ({2}).
        /// </summary>
        internal static string sStageHeader {
            get {
                return ResourceManager.GetString("sStageHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Не пройден.
        /// </summary>
        internal static string sStageIncomplete {
            get {
                return ResourceManager.GetString("sStageIncomplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пропускается.
        /// </summary>
        internal static string sStagePass {
            get {
                return ResourceManager.GetString("sStagePass", resourceCulture);
            }
        }
    }
}
