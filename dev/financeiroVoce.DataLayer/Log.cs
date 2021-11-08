using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace financeiroVoce.DataLayer
{
    class Log
    {
        public static void GravarLog(string log)
        {
            try
            {
                string endLog = Convert.ToString(ConfigurationManager.AppSettings["enderecoLog"]);
                TextWriter tw = File.AppendText(endLog);
                tw.WriteLine(string.Format("\n--- {0}\t{1}", DateTime.Now, log));
                tw.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
