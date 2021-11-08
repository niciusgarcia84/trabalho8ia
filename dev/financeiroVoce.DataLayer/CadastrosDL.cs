using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace financeiroVoce.DataLayer
{
    public class CadastrosDL : Conexao
    {
        private DataSet ds = new DataSet();

        public DataTable ListarEquipes()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabEquipes.IDEquipe, TabEquipes.Equipe, TabEquipes.Telefone, TabEquipes.Obs, TabEquipes.Ocultar " +
                "FROM TabEquipes " +
                "WHERE TabEquipes.Ocultar = No " +
                "ORDER BY TabEquipes.Equipe";

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
        public DataTable ListarEquipesCadastro()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabEquipes.IDEquipe, TabEquipes.Equipe, TabEquipes.Telefone, TabEquipes.Obs, TabEquipes.Email, TabEquipes.Ocultar " +
                "FROM TabEquipes " +
                "ORDER BY TabEquipes.Equipe";

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
        public DataTable ListarEquipe(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabEquipes.IDEquipe, TabEquipes.Equipe " +
                "FROM TabEquipes ";
                if (nm.Length >= 10) sqlAccess += "WHERE TabEquipes.Equipe LIKE '" + nm.Substring(0, 10).ToString() + "%' ";
                else sqlAccess += "WHERE TabEquipes.Equipe LIKE '" + nm.ToString() + "%' ";
                sqlAccess += "ORDER BY TabEquipes.Equipe";

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
        public void novaEquipe(string Equipe, string Telefone, string Obs, string email)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabEquipes (Equipe, Telefone, Obs, Email) " +
                "VALUES ('" + Equipe.ToString() + "', '" + Telefone.ToString() + "', '" + Obs.ToString() + "', '" + email.ToString() + "')";
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
        public void atualizarEquipe(Int32 ID, string Equipe, string Telefone, string Obs, Boolean inativo, string email)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabEquipes Set Equipe = '" + Equipe.ToString() + "', Telefone = '" + Telefone.ToString() + "', Obs = '" + Obs.ToString() + "', Ocultar = " + inativo.ToString() + ", Email='" + email.ToString() + "' WHERE IDEquipe = " + ID;

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
        public void ocultarEquipe(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabEquipes Set Ocultar = Yes WHERE IDEquipe = " + ID;

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
        public DataTable ListarDestinos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabDestinos.IDDestino, TabDestinos.Descricao, TabDestinos.Obs " +
                "FROM TabDestinos " +
                "WHERE TabDestinos.Ocultar = No " +
                "ORDER BY TabDestinos.Descricao";

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
        public void novoDestino(string Descricao, string Obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabDestinos (Descricao, Obs) " +
                "VALUES ('" + Descricao.ToString() + "', '" + Obs.ToString() + "')";
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
        public void atualizarDestinos(Int32 ID, string Descricao, string Obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabDestinos Set Descricao = '" + Descricao.ToString() + "', Obs = '" + Obs.ToString() + "' WHERE IDDestino = " + ID;

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
        public void ocultarDestinos(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabDestinos Set Ocultar = Yes WHERE IDDestino = " + ID;

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
        public DataTable ListarTreinamentos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.vlExperiente " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.Ocultar = No " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarTreinamento(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.vlExperiente, TabTreinamentos.r1, TabTreinamentos.r2, TabTreinamentos.r3, TabTreinamentos.r4, TabTreinamentos.r5, TabTreinamentos.ro1, TabTreinamentos.ro2, TabTreinamentos.ro3, TabTreinamentos.ro4, TabTreinamentos.ro5  " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.IDTreinamento=" + id.ToString() + "  " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarTreinamentos2015()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TOP 40 TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.Ocultar = No AND TabTreinamentos.DTInicio < #01/20/2016# " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarUltimosTreinamentos2016()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TOP 50 TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.Ocultar = No AND TabTreinamentos.DTInicio >=#01/20/2016# " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarMaioresTreinamentos2016()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.Ocultar = No AND TabTreinamentos.DTInicio >=#01/20/2016# " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarProximosDiamonds()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao  FROM TabTreinamentos " +
                    "WHERE (((TabTreinamentos.Descricao) Like '%DIA%' ) AND ((TabTreinamentos.DTInicio)>=#" + DateTime.Now.AddDays(-280).ToString("MM/dd/yyyy") + "#)) " +
                    "ORDER BY TabTreinamentos.DTInicio ";

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
        public DataTable verificarDataDiamonds(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTreinamentos.DTInicio FROM TabTreinamentos " +
                    "WHERE TabTreinamentos.IDTreinamento=" + id.ToString();

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
        public DataTable ListarUltimosTreinamentos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TOP 30 TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.DTInicio " +
                "FROM TabTreinamentos " +
                "WHERE TabTreinamentos.Ocultar = No  " +
                "ORDER BY TabTreinamentos.DTInicio DESC";

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
        public DataTable ListarProximosTreinamentos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao FROM TabTreinamentos " +
                "WHERE TabTreinamentos.DTInicio>=#" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# ORDER BY TabTreinamentos.DTInicio DESC";

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
        public void novoTreinamento(string Descricao, double Investimento, DateTime DT, double Invest2, double Invest3, double Invest4, double Experiente, double r1, double r2, double r3, double r4, double r5, double ro1, double ro2, double ro3, double ro4, double ro5)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabTreinamentos (Descricao, Investimento, DTInicio, Investimento2, Investimento3, Investimento4, vlExperiente, r1, r2, r3, r4, r5, ro1, ro2, ro3, ro4, ro5) " +
                "VALUES ('" + Descricao.ToString() + "', " + Investimento.ToString().Replace(",", ".") + ", #" + DT.Date.ToString("MM/dd/yyyy") + "#, " + Invest2.ToString().Replace(",", ".") + ", " +
                    Invest3.ToString().Replace(",", ".") + ", " + Invest4.ToString().Replace(",", ".") + ", " + Experiente.ToString().Replace(",", ".") + ", " + r1.ToString().Replace(",", ".") +
                    ", " + r2.ToString().Replace(",", ".") + ", " + r3.ToString().Replace(",", ".") + ", " + r4.ToString().Replace(",", ".") + ", " + r5.ToString().Replace(",", ".") + ", " + ro1.ToString().Replace(",", ".") +
                    ", " + ro2.ToString().Replace(",", ".") + ", " + ro3.ToString().Replace(",", ".") + ", " + ro4.ToString().Replace(",", ".") + ", " + ro5.ToString().Replace(",", ".") + ")";
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
        public void atualizarTreinamento(Int32 ID, string Descricao, double Investimento, DateTime DT, double Invest2, double Invest3, double Invest4, double Experiente, double r1, double r2, double r3, double r4, double r5, double ro1, double ro2, double ro3, double ro4, double ro5)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabTreinamentos Set Descricao = '" + Descricao.ToString() + "', Investimento = " + Investimento.ToString().Replace(",", ".") + ", Investimento2 = " + Invest2.ToString().Replace(",", ".") + ", Investimento3 = " + Invest3.ToString().Replace(",", ".") + ", Investimento4 = " + Invest4.ToString().Replace(",", ".") + ", vlExperiente = " + Experiente.ToString().Replace(",", ".") +
                    ", r1 = " + r1.ToString().Replace(",", ".") + ", r2 = " + r2.ToString().Replace(",", ".") + ", r3 = " + r3.ToString().Replace(",", ".") + ", r4 = " + r4.ToString().Replace(",", ".") + ", r5 = " + r5.ToString().Replace(",", ".") +
                    ", ro1 = " + ro1.ToString().Replace(",", ".") + ", ro2 = " + ro2.ToString().Replace(",", ".") + ", ro3 = " + ro3.ToString().Replace(",", ".") + ", ro4 = " + ro4.ToString().Replace(",", ".") + ", ro5 = " + ro5.ToString().Replace(",", ".")
                    + ", DTInicio = #" + DT.Date.ToString("MM/dd/yyyy") + "# WHERE IDTreinamento = " + ID;

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
        public void ocultarTreinamento(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabTreinamentos Set Ocultar = Yes WHERE IDTreinamento = " + ID;

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
        public void novoTreinamentoTabela(Int32 ano, string curso, double v1, double v2, double v3, double v4, double r1, double r2, double r3, double r4, double r5, double ro1, double ro2, double ro3, double ro4, double ro5)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabTabela (Ano, Nome, v1, v2, v3, v4, v5, r1, r2, r3, r4, r5, ro1, ro2, ro3, ro4, ro5) " +
                "VALUES (" + ano.ToString() + ", '" + curso.ToString() + "', " + v1.ToString().Replace(",", ".") + ", " + v2.ToString().Replace(",", ".") + ", " +
                    v3.ToString().Replace(",", ".") + ", " + v4.ToString().Replace(",", ".") + ", " + v4.ToString().Replace(",", ".") + ", " + r1.ToString().Replace(",", ".") +
                    ", " + r2.ToString().Replace(",", ".") + ", " + r3.ToString().Replace(",", ".") + ", " + r4.ToString().Replace(",", ".") + ", " + r5.ToString().Replace(",", ".") + ", " + ro1.ToString().Replace(",", ".") +
                    ", " + ro2.ToString().Replace(",", ".") + ", " + ro3.ToString().Replace(",", ".") + ", " + ro4.ToString().Replace(",", ".") + ", " + ro5.ToString().Replace(",", ".") + ")";
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
        public void atualizarTabela(Int32 ID, Int32 ano, string nome, double v1, double v2, double v3, double v4, double r1, double r2, double r3, double r4, double r5, double ro1, double ro2, double ro3, double ro4, double ro5)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabTabela Set Ano =" + ano.ToString() + ", Nome = '" + nome.ToString() + "', v1 = " + v1.ToString().Replace(",", ".") + ", v2 = " + v2.ToString().Replace(",", ".") + ", v3 = " + v3.ToString().Replace(",", ".") + ", v4 = " + v4.ToString().Replace(",", ".") + ", v5 = " + v4.ToString().Replace(",", ".") +
                    ", r1 = " + r1.ToString().Replace(",", ".") + ", r2 = " + r2.ToString().Replace(",", ".") + ", r3 = " + r3.ToString().Replace(",", ".") + ", r4 = " + r4.ToString().Replace(",", ".") + ", r5 = " + r5.ToString().Replace(",", ".") +
                    ", ro1 = " + ro1.ToString().Replace(",", ".") + ", ro2 = " + ro2.ToString().Replace(",", ".") + ", ro3 = " + ro3.ToString().Replace(",", ".") + ", ro4 = " + ro4.ToString().Replace(",", ".") + ", ro5 = " + ro5.ToString().Replace(",", ".") +
                    " WHERE IDTabela = " + ID;

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
        public void removerTabela(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabTabela WHERE IDTabela = " + id.ToString();

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
        public DataTable carregarTiposTreinamentos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                        "SELECT TabTipoTreinamento.IDTipo, TabTipoTreinamento.Descricao, TabTipoTreinamento.Nome " +
                        "FROM TabTipoTreinamento " +
                        "ORDER BY TabTipoTreinamento.IDTipo";

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
        //tipos de treinamentos
        public void novoTipoTreinamento(string descricao, string nome)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabTipoTreinamento (Descricao, Nome) " +
                    "VALUES ('" + descricao.ToString() + "', '" + nome.ToString() + "' )";
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
        public void AtualizarTipoTreinamento(Int32 ID, string descricao, string nome)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabTipoTreinamento Set Descricao ='" + descricao.ToString() + "', Nome = '" + nome.ToString() + "' WHERE IDTipo = " + ID;

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
        public void removerTipoTreinamento(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabTipoTreinamento WHERE IDTipo = " + id.ToString();

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
        public DataTable carregarTabelas()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTabela.IDTabela, TabTabela.Ano, TabTabela.Nome, TabTabela.v1 " +
                "FROM TabTabela " +
                "ORDER BY TabTabela.Ano DESC, TabTabela.Nome DESC ";

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
        public DataTable carregarTabela(Int32 ano, string nm)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTabela.Ano, TabTabela.Nome, TabTabela.v1, TabTabela.r1, TabTabela.v2, TabTabela.r2, TabTabela.v3, TabTabela.r3, TabTabela.v4, TabTabela.r4, TabTabela.v5, TabTabela.r5, TabTabela.ro1, TabTabela.ro2, TabTabela.ro3, TabTabela.ro4, TabTabela.ro5 " +
                    "FROM TabTabela WHERE TabTabela.Ano=" + ano.ToString() + " AND TabTabela.Nome='" + nm.ToString() + "' ";

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
        public DataTable ListarTabelaTreinamento(Int32 id)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTabela.Ano, TabTabela.Nome, TabTabela.v1, TabTabela.r1, TabTabela.v2, TabTabela.r2, TabTabela.v3, TabTabela.r3, TabTabela.v4, TabTabela.r4, TabTabela.v5, TabTabela.r5, TabTabela.ro1, TabTabela.ro2, TabTabela.ro3, TabTabela.ro4, TabTabela.ro5 " +
                    " FROM TabTabela WHERE TabTabela.IDTabela=" + id.ToString() + "  ";

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
        public DataTable ListarKits()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabKit.IDKit, TabKit.Descricao " +
                "FROM TabKit " +
                "ORDER BY TabKit.Descricao";

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
        public DataTable carregarKit(string nm)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabKit.IDKit, TabKit.Descricao " +
                "FROM TabKit " +
                "WHERE TabKit.Descricao = '" + nm.ToString() + "'";

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
        public void novoKit(string descricao)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabKit (Descricao) " +
                "VALUES ('" + descricao.ToString() + "')";
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
        public void atualizarKit(Int32 ID, string descricao)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabKit Set Descricao = '" + descricao.ToString() + "' WHERE IDKit = " + ID;

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
        public void removerKit(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabKit WHERE IDKit = " + id.ToString();

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
        public DataTable ListarProdutosKits(Int32 idkit)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabProdutos.nmProduto, TabItemKit.IDItemKit, TabItemKit.IDProduto " +
                "FROM TabItemKit INNER JOIN TabProdutos ON TabItemKit.IDProduto = TabProdutos.IDProduto " +
                "WHERE TabItemKit.IDKit=" + idkit.ToString() + " " +
                "ORDER BY TabProdutos.nmProduto";

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
        public void novoProdutoKit(Int32 idkit, Int32 idproduto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabItemKit (IDKit, IDProduto) " +
                "VALUES (" + idkit.ToString() + ", " + idproduto.ToString() + ")";
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
        public void removerProdutoKit(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabItemKit WHERE IDItemKit = " + id.ToString();

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
        public DataTable ListarClientesReceberAvulso()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabTreinando.IDTreinando, tabTreinando.Nome FROM tabTreinando WHERE tabTreinando.obs = 'RECEBER' ORDER BY tabTreinando.Nome";

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
        public void novoClienteReceber(string nome)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabTreinando (Nome, obs)  VALUES ('" + nome.ToString() + "', 'RECEBER')";
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
        public DataTable novoListaReceberSimples(Int32 idtreinando)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess = "INSERT INTO tabLista (IDTreinando, IDTreinamento, IDEquipe, bloqueado, dataCadastro, dataBloqueio)  VALUES (" +
                    idtreinando.ToString() + ", 225, 22, YES, #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#, #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#)";
                OleDbCommand cmdAccess = new OleDbCommand(sqlAccess, (OleDbConnection)conexao);
                cmdAccess.ExecuteNonQuery();

                sqlAccess = "SELECT tabLista.IDLista, tabLista.IDTreinando, tabLista.IDTreinamento, tabLista.IDEquipe, tabLista.dataCadastro FROM tabLista " +
                    " WHERE tabLista.IDTreinando = " + idtreinando.ToString() + " AND tabLista.IDTreinamento = 225 AND tabLista.IDEquipe = 22 AND tabLista.dataCadastro =#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# ";
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
        public void novoPagtosReceberSimples(Int32 idlista, DateTime dt, double vl, string forma, string resp, string banco)
        {
            if (!Connect())
                return;
            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess = "INSERT INTO tabPagtos (IDLista, DTPagto, DTVencimento, DTRecebimento, valorParcela, valorLiquido, FormaPagto, Responsavel, banco, recebido, status)  VALUES (" +
                    idlista.ToString() + ", #" + dt.Date.ToString("MM/dd/yyyy") + "#, #" + dt.Date.ToString("MM/dd/yyyy") + "#, #" + dt.Date.ToString("MM/dd/yyyy") + "#, " +
                    vl.ToString().Replace(",", ".") + ", " + vl.ToString().Replace(",", ".") + ", '" + forma.ToString() + "', '" + resp.ToString() + "', '" + banco.ToString() + "', Yes, 1)";

                OleDbCommand cmdAccess = new OleDbCommand(sqlAccess, (OleDbConnection)conexao);
                cmdAccess.ExecuteNonQuery();


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
