using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;


namespace financeiroVoce.DataLayer
{
    public class AdminDL : Conexao
    {
        private DataSet ds = new DataSet();
        
        public DataTable ListarContasPorPeriodo(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabAdmContas.IDAdmContas, TabAdmContas.Descricao, TabAdmContas.Preco, TabAdmContas.Data, TabAdmContas.Credito " +
                    "FROM TabAdmContas " +
                    "WHERE (((TabAdmContas.Data)>=#" + inicio.ToString("MM/dd/yyyy") + "# And (TabAdmContas.Data)<=#" + fim.ToString("MM/dd/yyyy") + "#)) " +
                    "ORDER BY TabAdmContas.Data ";

                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);

                daAccess.Fill(retorno);

                return retorno;
            }
            catch (Exception ex)
            {
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public void novaConta(string descricao, double preco, DateTime dt, string credito)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabAdmContas (Descricao, Preco, Data, Credito) " +
                    "VALUES ('" + descricao.ToString() + "', " + preco.ToString().Replace(",", ".") + ", #" + dt.Date.ToString("MM/dd/yyyy") + "#, ";
                if (credito == "Credito") sqlAccess += "True "; else sqlAccess += "False ";
                sqlAccess += ") ";
                OleDbCommand cmdAccess = new OleDbCommand(sqlAccess, (OleDbConnection)conexao);
                cmdAccess.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return;
            }
            finally
            {
                Disconnect();
            }
        }
        public void removerConta(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabAdmContas WHERE IDAdmContas = " + id.ToString();

                OleDbCommand cmdAccess = new OleDbCommand(sqlAccess, (OleDbConnection)conexao);
                cmdAccess.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable TotalCredito()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT Sum(TabAdmContas.Preco) AS Credito " +
                    "FROM TabAdmContas " +
                    "GROUP BY TabAdmContas.Credito " +
                    "HAVING (((TabAdmContas.Credito)=Yes))";

                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);

                daAccess.Fill(retorno);

                return retorno;
            }
            catch (Exception ex)
            {
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable TotalDebito()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT Sum(TabAdmContas.Preco) AS Debito " +
                    "FROM TabAdmContas " +
                    "GROUP BY TabAdmContas.Credito " +
                    "HAVING (((TabAdmContas.Credito)=No))";

                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);

                daAccess.Fill(retorno);

                return retorno;
            }
            catch (Exception ex)
            {
                Log.GravarLog(string.Concat("ERRO: ", ex.Message, " stacktrace: ", ex.StackTrace));
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
