﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources.Areas.Identity.Pages.Account {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LoginWith2fa {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoginWith2fa() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Resources.Areas.Identity.Pages.Account.LoginWith2fa", typeof(LoginWith2fa).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string TwoFactorAuthentication {
            get {
                return ResourceManager.GetString("TwoFactorAuthentication", resourceCulture);
            }
        }
        
        public static string LoginIsProtected {
            get {
                return ResourceManager.GetString("LoginIsProtected", resourceCulture);
            }
        }
        
        public static string LogIn {
            get {
                return ResourceManager.GetString("LogIn", resourceCulture);
            }
        }
        
        public static string DontHaveAccessToYourAuthenticatorDevice {
            get {
                return ResourceManager.GetString("DontHaveAccessToYourAuthenticatorDevice", resourceCulture);
            }
        }
        
        public static string LogInWithRecoveryCode {
            get {
                return ResourceManager.GetString("LogInWithRecoveryCode", resourceCulture);
            }
        }
        
        public static string AuthenticatorCode {
            get {
                return ResourceManager.GetString("AuthenticatorCode", resourceCulture);
            }
        }
        
        public static string RememberThisMachine {
            get {
                return ResourceManager.GetString("RememberThisMachine", resourceCulture);
            }
        }
    }
}
