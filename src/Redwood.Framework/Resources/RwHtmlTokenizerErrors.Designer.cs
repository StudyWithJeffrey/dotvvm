﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Redwood.Framework.Resources {
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
    internal class RwHtmlTokenizerErrors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RwHtmlTokenizerErrors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Redwood.Framework.Resources.RwHtmlTokenizerErrors", typeof(RwHtmlTokenizerErrors).Assembly);
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
        ///   Looks up a localized string similar to The attribute value was not closed. Example: 
        ///&lt;a href=&quot;#&quot;&gt;Link&lt;/a&gt; or &lt;a href=&apos;#&apos;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string AttributeValueNotClosed {
            get {
                return ResourceManager.GetString("AttributeValueNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The format of data-binding is not valid. Example:
        ///{{value: FirstName}} or &lt;a href=&quot;{value: FirstName}&quot;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string BindingInvalidFormat {
            get {
                return ResourceManager.GetString("BindingInvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The binding must be closed by double braces. Example:
        ///&lt;a href=&quot;{value: FirstName}&quot;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string BindingNotClosed {
            get {
                return ResourceManager.GetString("BindingNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The CDATA section is not closed. Example:
        ///&lt;![CDATA[ content ]]&gt;.
        /// </summary>
        internal static string CDataNotClosed {
            get {
                return ResourceManager.GetString("CDataNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HTML comment is not closed. Example:
        ///&lt;!-- comment --&gt;.
        /// </summary>
        internal static string CommentNotClosed {
            get {
                return ResourceManager.GetString("CommentNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Directive name expected. Example: 
        ///@viewmodel Redwood.Samples.SampleViewModel, Redwood.Samples.
        /// </summary>
        internal static string DirectiveNameExpected {
            get {
                return ResourceManager.GetString("DirectiveNameExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value of the directive expected. Example: 
        ///@viewmodel Redwood.Samples.SampleViewModel, Redwood.Samples.
        /// </summary>
        internal static string DirectiveValueExpected {
            get {
                return ResourceManager.GetString("DirectiveValueExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The DOCTYPE section is not closed. Example:
        ///&lt;!DOCTYPE html&gt;.
        /// </summary>
        internal static string DoctypeNotClosed {
            get {
                return ResourceManager.GetString("DoctypeNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The binding must be closed by double braces. Example:
        ///{{value: FirstName}}.
        /// </summary>
        internal static string DoubleBraceBindingNotClosed {
            get {
                return ResourceManager.GetString("DoubleBraceBindingNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag contains invalid characters. The tag must end with &apos;&gt;&apos; or &apos;/&gt;&apos;..
        /// </summary>
        internal static string InvalidCharactersInTag {
            get {
                return ResourceManager.GetString("InvalidCharactersInTag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The attribute value expected. Example:
        ///&lt;a href=&quot;#&quot;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string MissingAttributeValue {
            get {
                return ResourceManager.GetString("MissingAttributeValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag name cannot end with the &apos;:&apos;. Example:
        ///&lt;rw:Button /&gt;.
        /// </summary>
        internal static string MissingTagName {
            get {
                return ResourceManager.GetString("MissingTagName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag name cannot start with the &apos;:&apos;. Example:
        ///&lt;rw:Button /&gt;.
        /// </summary>
        internal static string MissingTagPrefix {
            get {
                return ResourceManager.GetString("MissingTagPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag name expected after &apos;&lt;&apos; character. Example:
        ///&lt;a href=&quot;#&quot;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string TagNameExpected {
            get {
                return ResourceManager.GetString("TagNameExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The tag is not closed. Example:
        ///&lt;a href=&quot;#&quot;&gt;Link&lt;/a&gt;.
        /// </summary>
        internal static string TagNotClosed {
            get {
                return ResourceManager.GetString("TagNotClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The XML processing instruction is not closed. Example:
        ///&lt;?xml version=&quot;1.0&quot; ?&gt;.
        /// </summary>
        internal static string XmlProcessingInstructionNotClosed {
            get {
                return ResourceManager.GetString("XmlProcessingInstructionNotClosed", resourceCulture);
            }
        }
    }
}
