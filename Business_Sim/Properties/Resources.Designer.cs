﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business_Sim.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Business_Sim.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to IIIII-BUYING-&amp;-SELLING--------------------------------------------------IIIII
        ///I///I                                                                   I///I
        ///I\\\I---BUYING----------------------------------------------------------I\\\I
        ///I///I                                                                   I///I
        ///I\\\I When buying buildings you will first be asked for the type you    I\\\I
        ///I///I want to purchase. Different building types have different income, I///I
        ///I\\\I outcome, buying price and upgrad [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BuildingBuySellHelp {
            get {
                return ResourceManager.GetString("BuildingBuySellHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
        ///I\\\I ______                                                                             I\\\I
        ///I///I |     \              _____               _____  ______    ______                   I///I
        ///I\\\I |      |  |      |  /        | |\     | |      /         /                         I\\\I
        ///I///I |     /   |      | |         | | \    | |     |         /                          I///I
        ///I\\\I |======   |      |  \_____ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TitleMenu {
            get {
                return ResourceManager.GetString("TitleMenu", resourceCulture);
            }
        }
    }
}
