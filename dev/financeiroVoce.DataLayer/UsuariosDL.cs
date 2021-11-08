using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace financeiroVoce.DataLayer
{
    public class UsuariosDL : Conexao
    {
        private DataSet ds = new DataSet();

        public DataTable verificarSenha(string us, string se)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabUsuario.IDUsuario, TabUsuario.Usuario, TabUsuario.Senha, TabUsuario.Receber, TabUsuario.Pagar, TabUsuario.Compras, TabUsuario.Estoque, TabUsuario.Cobranca, TabUsuario.Adm " +
                "FROM TabUsuario " +
                "WHERE TabUsuario.Usuario='" + us.ToString() + "' AND TabUsuario.Senha='" + se.ToString() + "' ";

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
        public DataTable listarUsuarios()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabUsuario.IDUsuario, TabUsuario.Usuario, TabUsuario.Senha, TabUsuario.Receber, TabUsuario.Pagar, TabUsuario.Compras, TabUsuario.Estoque, TabUsuario.Cobranca, TabUsuario.Adm " +
                "FROM TabUsuario " +
                "ORDER BY TabUsuario.Usuario";

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
        public void atualizarSenha(Int32 idusuario, String senha)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "UPDATE TabUsuario SET TabUsuario.Senha = '" + senha.ToString() +
                "' WHERE TabUsuario.IDUsuario=" + idusuario.ToString();
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
        public void atualizarStatus(Int32 idusuario, Boolean receber, Boolean pagar, Boolean compras, Boolean estoque, Boolean cobranca, Boolean adm)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "UPDATE TabUsuario SET TabUsuario.Receber = " + receber + ", TabUsuario.Pagar = " + pagar + ", TabUsuario.Compras = " + compras + ", TabUsuario.Estoque = " + estoque + ", TabUsuario.Cobranca = " + cobranca + ", TabUsuario.Adm = " + adm + " WHERE TabUsuario.IDUsuario=" + idusuario.ToString();
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
        public void atualizarSenha(Int32 idusuario)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "UPDATE TabUsuario SET TabUsuario.Senha = 'alterar*' WHERE TabUsuario.IDUsuario=" + idusuario.ToString();
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
        public void atualizarAcesso(Int32 idusuario)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "UPDATE TabUsuario SET TabUsuario.Senha = 'adm#' WHERE TabUsuario.IDUsuario=" + idusuario.ToString();
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
        public void cadastrar(string nome)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "INSERT INTO TabUsuario(Usuario, Senha) " +
                "VALUES ('" + nome.ToString() + "', 'alterar*')";

                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
        public void lancarLog(string usuario, string computador, string acao)
        {
            if (!Connect())
                return;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "INSERT INTO tabLog(Hora, Usuario, Computador, Acao) VALUES (#" +
                    DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "#, '" + usuario.ToString() + "', '" + computador.ToString() + "', '" + acao.ToString() + "')";

                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                return;
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
    }
}
