using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;


namespace new_cockpit.Class
{
    public class SysUtl
    {
        public const string EFormConnection = "EFormConnection";
        public class WindowsAuth
        {
            //Header
            [DllImport("advapi32.DLL", SetLastError = true)]
            public static extern int LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out IntPtr phToken);

            [DllImport("advapi32.DLL")]
            public static extern int ImpersonateLoggedOnUser(IntPtr hToken); //handle to token for logged-on user

            [DllImport("advapi32.DLL")]
            public static extern bool RevertToSelf();

            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr hToken);

            public IntPtr admin_token = IntPtr.Zero;
            
            enum LogonProvider
            {
                LOGON32_PROVIDER_DEFAULT = 0,
                LOGON32_PROVIDER_WINNT50 = 3,
                LOGON32_PROVIDER_WINNT40 = 2,
                LOGON32_PROVIDER_WINNT35 = 1,
                LOGON32_LOGON_INTERACTIVE = 2,
                LOGON32_LOGON_NETWORK = 3,
                LOGON32_LOGON_BATCH = 4,
                LOGON32_LOGON_SERVICE = 5,
                LOGON32_LOGON_UNLOCK = 7
            }

            public string fullDisplyName = "";
            public Boolean WinAuth(String UsrNam, String PasWrd)
            {
                //String ssDomain = Environment.UserDomainName;
                String ssDomain = "SHIMANOACE";
                IntPtr phToken = IntPtr.Zero;
                //CloseHandle(admin_token);
                //RevertToSelf();
                //admin_token = IntPtr.Zero;

                int valid = LogonUser(
                    UsrNam,
                    ssDomain,
                    PasWrd,
                    (int)LogonProvider.LOGON32_LOGON_INTERACTIVE,
                    (int)LogonProvider.LOGON32_PROVIDER_DEFAULT,
                    out admin_token);

                if (valid != 0)
                {
                    int IPI = ImpersonateLoggedOnUser(admin_token);
                    try
                    {
                        fullDisplyName = UserPrincipal.Current.DisplayName;
                    }
                    catch
                    {
                        fullDisplyName = UserPrincipal.Current.DisplayName;
                    }

                    if (fullDisplyName == "")
                        return false;

                    if (IPI != 0)
                    {

                        CloseHandle(admin_token);
                        RevertToSelf();
                        admin_token = IntPtr.Zero;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }

        }
    }
}