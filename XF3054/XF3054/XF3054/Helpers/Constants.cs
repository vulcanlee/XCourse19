using System;
using System.Collections.Generic;
using System.Text;

namespace XF3054.Helpers
{
    public class Constants
    {
        public static readonly string APIHost = "https://lobworkshop.azurewebsites.net";
        public static readonly string InvoiceAPI = $"{APIHost}/api/Invoices";
        public static readonly string LoginServiceFilename = "LoginService.txt";
        public static readonly string DataFolder = "MyDataFolder";
    }
}
