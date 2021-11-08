using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace financeiroVoce.DataLayer
{
    public class Conexao
    {
        protected DbConnection conexao;
        //private DbProviderFactory factory;

        protected virtual bool Connect()
        {
            try
            {
                //Pega a Connection String do Arquivo de configuração
                string connStr = Convert.ToString(ConfigurationManager.AppSettings["connStr"]);
                conexao = new OleDbConnection(connStr);
                //factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                conexao.Open();
            }
            catch (Exception ex)
            {
                //Grava o Erro no arquivo de Log
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return false;
            }
            return true;
        }

        //protected DbParameter CreateParameter()
        //{
        //    return factory.CreateParameter();
        //}

        protected virtual void Disconnect()
        {
            try
            {
                conexao.Close();
            }
            catch
            {
            }
        }
    }
}
