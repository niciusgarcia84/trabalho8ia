using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;


namespace financeiroVoce.DataLayer
{
    public class TreinandosDL : Conexao
    {
        private DataSet ds = new DataSet();

        public DataTable ListarTreinandoPorNome(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT tabTreinando.IDTreinando, tabTreinando.Nome, tabTreinando.Obs, False AS edicao, False AS bloqueado " +
                "FROM tabTreinando " +
                "WHERE tabTreinando.Nome LIKE '%" + nm.ToString() + "%'  " +
                "ORDER BY tabTreinando.Nome";

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
        public DataTable procurarTreinandoPorNome(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT tabTreinando.IDTreinando " +
                    "FROM tabTreinando " +
                    "WHERE tabTreinando.Nome = '" + nm.ToString() + "'  ";

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
        public void atualizarArquetipo(Int32 ID, string arq, string cracha)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabTreinando Set Arquetipo = '" + arq.ToString() + "', Cracha='" + cracha.ToString() + "' WHERE IDTreinando = " + ID;

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
        public void novoTreinando(string Nome, string Obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabTreinando (Nome, Obs) " +
                "VALUES ('" + Nome.ToString() + "', '" + Obs.ToString() + "')";
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
        public DataTable novoTreinandoRetornoID(string Nome, string Obs)
        {
            if (!Connect())
                return null;
            try
            {
                //antes de cadastrar verificar se já não tem cadastro...
                string sqlAccess = "INSERT INTO tabTreinando (Nome, Obs) " +
                "VALUES ('" + Nome.ToString() + "', '" + Obs.ToString() + "')";
                OleDbCommand cmdAccess = new OleDbCommand(sqlAccess, (OleDbConnection)conexao);
                cmdAccess.ExecuteNonQuery();

                DataTable retorno = new DataTable();
                sqlAccess = "SELECT tabTreinando.IDTreinando FROM tabTreinando WHERE tabTreinando.Nome='" + Nome.ToString() + "' ";
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
        public void atualizarTreinando(Int32 ID, string nome, string obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabTreinando Set Nome = '" + nome.ToString() + "', Obs = '" + obs.ToString() + "' WHERE IDTreinando = " + ID;

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
        public void atualizarTreinandoValor(Int32 idlista, Int32 idequipe, string nota, double totalpagto, double desconto, string obs, string detalhes, Boolean mais, Boolean invest, Boolean ausente, Boolean experiente, Boolean carta, string credito)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista Set IDEquipe = " + idequipe.ToString() + ", Nota = '" + nota.ToString() + "', TotalPagto = " + totalpagto.ToString().Replace(",", ".") + ", Desconto = " + desconto.ToString().Replace(",", ".") + ", Obs = '" + obs.ToString() + "', DetalhePagto = '" + detalhes.ToString() + "', maisAutorizado = " + mais + ", Invest = " + invest + ", ausente = " + ausente + ", experiente = " + experiente + ", carta = " + carta + ", Credito = '" + credito.ToString() + "'  WHERE IDLista = " + idlista;

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
        public void atualizarNotaFiscal(Int32 idlista, string nota)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista Set Nota = '" + nota.ToString() + "' WHERE IDLista = " + idlista;

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
        public void bloquearTreinando(Int32 idlista)
        {
            if (!Connect())
                return;
            try
            {
                //string sqlAccess = "UPDATE tabLista Set bloqueado=Yes WHERE IDLista = " + idlista; 
                string sqlAccess = "UPDATE tabLista Set bloqueado=Yes, dataBloqueio=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# WHERE IDLista = " + idlista;

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
        public void alterarTreinamentoTreinando(Int32 idlista, Int32 idtreinamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista Set IDTreinamento=" + idtreinamento.ToString() + " WHERE IDLista = " + idlista;

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
        public void editarTreinando(Int32 idlista)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista Set edicao=Yes WHERE IDLista = " + idlista;

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
        public void bloquearEdicaoTreinando(Int32 idlista)
        {
            if (!Connect())
                return;
            try
            {
                //string sqlAccess = "UPDATE tabLista Set edicao=No WHERE IDLista = " + idlista;
                string sqlAccess = "UPDATE tabLista Set edicao=No, dataBloqueio=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# WHERE IDLista = " + idlista;

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
        public void ocultarTreinando(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM tabTreinando WHERE IDTreinando = " + ID.ToString();

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
        public void ocultarTreinamentoTreinando(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM tabLista WHERE IDLista = " + ID.ToString();

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
        public DataTable ListarTreinamentosPorTreinando(Int32 idTreinando)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT tabLista.IDLista, tabLista.IDTreinando, tabTreinando.Nome, TabTreinamentos.Descricao, TabTreinamentos.DTInicio , TabEquipes.IDEquipe, TabEquipes.Equipe, TabEquipes.Ocultar, tabLista.Nota, tabLista.TotalPagto, tabLista.Desconto, tabLista.Obs, tabLista.maisAutorizado, tabLista.Invest, tabLista.ausente, tabLista.bloqueado , tabLista.edicao, tabLista.Credito, tabLista.carta, tabLista.experiente   " +
                "FROM ((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando " +
                "WHERE (tabLista.IDTreinando = " + idTreinando.ToString() + " )";

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
        public DataTable ListarTreinamentosPorTreinamento(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabTreinando.IDTreinando, tabTreinando.Nome, tabTreinando.obs, TabTreinamentos.IDTreinamento, tabLista.edicao, tabLista.bloqueado " +
                "FROM TabTreinamentos INNER JOIN (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento " +
                "WHERE (((TabTreinamentos.IDTreinamento)=" + idTreinamento.ToString() + "))  " +
                "ORDER BY tabTreinando.Nome";

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
        public DataTable ListarTreinanandoPorTreinamento(Int32 idTreinamento, string nome)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDTreinamento, tabLista.IDTreinando, tabTreinando.Nome FROM tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.IDTreinamento=" + idTreinamento.ToString() + " AND tabTreinando.Nome='" + nome.ToString() + "' ORDER BY tabTreinando.Nome ";

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
        public DataTable ListarTreinanandosPorTreinamento(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Nome, tabTreinando.Cracha, tabTreinando.Arquetipo, tabLista.DetalhePagto, tabLista.TotalPagto, tabLista.Desconto, tabLista.Obs, TabEquipes.Equipe, TabEquipes.Email, TabTreinamentos.Investimento, tabLista.Invest, tabLista.ausente, tabLista.bloqueado, tabLista.edicao, tabLista.experiente, tabLista.IDLista, tabLista.Grupo, tabLista.carta, tabLista.Credito  " +
                    "FROM ((tabLista INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                    "WHERE (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) " +
                    "ORDER BY tabTreinando.Nome ";

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
        public DataTable ListarTreinanandosPorTreinamentoArquetipos(Int32 idTreinamento, Boolean ordem)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDLista, tabLista.IDTreinando, tabTreinando.Nome, TabEquipes.Equipe, tabArquetipos.Arquetipo, tabArquetipos.Cerebro, tabArquetipos.Coracao, tabArquetipos.Aberto, tabArquetipos.Fechado, tabArquetipos.Projecoes, tabArquetipos.Fatos, tabArquetipos.Geral, tabArquetipos.Detalhes, tabLista.Excecao, tabLista.experiente " +
                    "FROM (tabTreinando INNER JOIN tabArquetipos ON tabTreinando.Arquetipo = tabArquetipos.Arquetipo) INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) ";
                if (ordem) sqlAccess += "ORDER BY tabTreinando.Nome ";
                else sqlAccess += "ORDER BY tabTreinando.IDTreinando ";

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
        public DataTable ListarTreinanandosArquetipos(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDLista, tabLista.IDTreinando, tabTreinando.Nome, tabTreinando.Cracha, tabTreinando.Arquetipo FROM tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.IDTreinamento =" + idTreinamento.ToString() + " ORDER BY tabTreinando.Nome; ";

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
        public DataTable ListarTreinanandosPorTreinamentoSemGrupo(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDLista, tabLista.IDTreinamento, tabLista.Grupo, tabTreinando.Nome, tabTreinando.Arquetipo, tabArquetipos.Cerebro, tabArquetipos.Coracao, tabArquetipos.Aberto, tabArquetipos.Fechado, tabArquetipos.Projecoes, tabArquetipos.Fatos, tabArquetipos.Geral, tabArquetipos.Detalhes, tabLista.Excecao " +
                    "FROM (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) INNER JOIN tabArquetipos ON tabTreinando.Arquetipo = tabArquetipos.Arquetipo " +
                    "WHERE (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ") AND ((tabLista.Grupo) Is Null)) " +
                    "ORDER BY tabTreinando.Nome ";

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
        public DataTable nomeTreinamento(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabTreinamentos.Descricao FROM TabTreinamentos WHERE TabTreinamentos.IDTreinamento=" + idTreinamento.ToString() + " ";

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
        public DataTable ListarGruposPorTreinamento(Int32 idTreinamento, String grupo, Boolean status)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDLista, tabTreinando.Nome, tabTreinando.Cracha, tabTreinando.Arquetipo, tabLista.Excecao, tabLista.experiente, tabLista.Status " +
                    "FROM tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ") AND ((tabLista.Grupo)='" + grupo.ToString() + "')) ";
                if (status) sqlAccess += "ORDER BY tabLista.Status DESC ";
                else sqlAccess += "ORDER BY tabTreinando.Nome ";

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
        public void atualizarZerarLiderViceBandeira(Int32 idtreinamento, string grupo, Int32 status)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Status = 0 WHERE tabLista.IDTreinamento=" + idtreinamento.ToString() + " AND tabLista.Grupo='" + grupo.ToString() + "' AND tabLista.Status = " + status.ToString() + " ";

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
        public void atualizarZerarLiderTodos(Int32 idtreinamento, string grupo)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Status = 0 WHERE tabLista.IDTreinamento=" + idtreinamento.ToString() + " AND tabLista.Grupo='" + grupo.ToString() + "' ";

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
        public void atualizarLider(Int32 lista)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Status = 1 WHERE tabLista.IDLista=" + lista.ToString();

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
        public void atualizarVice(Int32 lista)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Status = 2 WHERE tabLista.IDLista=" + lista.ToString();

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
        public void atualizarBandeira(Int32 lista)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Status = 3 WHERE tabLista.IDLista=" + lista.ToString();

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
        public DataTable ListarArquetiposPorTreinamentos(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Arquetipo, Count(tabTreinando.Nome) AS Soma " +
                    "FROM tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "GROUP BY tabTreinando.Arquetipo, tabLista.IDTreinamento " +
                    "HAVING (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) " +
                    "ORDER BY tabTreinando.Arquetipo ";

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
        public DataTable ListarArquetiposPorGrupoTreinamentos(Int32 idTreinamento, String grupo)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Arquetipo, Count(tabTreinando.Nome) AS Soma " +
                    "FROM tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "GROUP BY tabTreinando.Arquetipo, tabLista.IDTreinamento, tabLista.Grupo " +
                    "HAVING (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ") AND ((tabLista.Grupo)='" + grupo.ToString() + "')) " +
                    "ORDER BY tabTreinando.Arquetipo ";

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
        public DataTable ListarArquetiposPorSubtipoTreinamentos(Int32 idTreinamento, String grupo)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT Sum(tabArquetipos.Cerebro) AS SomaDeCerebro, Sum(tabArquetipos.Coracao) AS SomaDeCoracao, Sum(tabArquetipos.Aberto) AS SomaDeAberto, Sum(tabArquetipos.Fechado) AS SomaDeFechado, Sum(tabArquetipos.Projecoes) AS SomaDeProjecoes, Sum(tabArquetipos.Fatos) AS SomaDeFatos, Sum(tabArquetipos.Geral) AS SomaDeGeral, Sum(tabArquetipos.Detalhes) AS SomaDeDetalhes " +
                    "FROM (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) INNER JOIN tabArquetipos ON tabTreinando.Arquetipo = tabArquetipos.Arquetipo " +
                    "GROUP BY tabLista.IDTreinamento, tabLista.Grupo " +
                    "HAVING (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ") AND ((tabLista.Grupo)='" + grupo.ToString() + "')) ";

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
        public DataTable ListarEquipesPorTreinamentoEmAberto(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT DISTINCT tabLista.IDEquipe, TabEquipes.Equipe " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((TabTreinamentos.Investimento)>([TotalPagto]+[Desconto])) AND ((tabLista.Invest)=No) AND ((tabLista.ausente)=No) AND ((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) " +
                    "ORDER BY TabEquipes.Equipe ";

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
        public DataTable ListarEquipesPorTreinamento(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT DISTINCT tabLista.IDEquipe, TabEquipes.Equipe " +
                    "FROM tabTreinando INNER JOIN(TabTreinamentos INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.IDTreinamento = " + idTreinamento.ToString() +
                    " ORDER BY TabEquipes.Equipe";

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
        public DataTable ListarTreinanandosPorTreinamentoEmAberto(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDEquipe, TabEquipes.Equipe, tabTreinando.Nome, tabLista.DetalhePagto, tabLista.TotalPagto, tabLista.Desconto, tabLista.Obs, TabTreinamentos.Investimento, tabLista.bloqueado, tabLista.edicao, tabLista.experiente, tabLista.Credito " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((TabTreinamentos.Investimento)>([TotalPagto]+[Desconto])) AND ((tabLista.Invest)=No) AND ((tabLista.ausente)=No) AND ((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) " +
                    "ORDER BY TabEquipes.Equipe, tabTreinando.Nome;";

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
        public DataTable ListarTreinanandosPorTreinamentoEEquipeEmAberto(Int32 idTreinamento, Int32 idEquipe)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDEquipe, TabEquipes.Equipe, tabTreinando.Nome, tabLista.DetalhePagto, tabLista.TotalPagto, tabLista.Desconto, tabLista.Obs, TabTreinamentos.Investimento, tabLista.bloqueado, tabLista.edicao, tabLista.experiente, tabLista.Credito " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabLista.IDEquipe)=" + idEquipe.ToString() + ") AND ((TabTreinamentos.Investimento)>([TotalPagto]+[Desconto])) AND ((tabLista.Invest)=No) AND ((tabLista.ausente)=No) AND ((tabLista.IDTreinamento)=" + idTreinamento.ToString() + ")) " +
                    "ORDER BY TabEquipes.Equipe, tabTreinando.Nome ";

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
        public DataTable ListarTreinanandosPorTreinamentoEEquipe(Int32 idTreinamento, Int32 idEquipe)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDEquipe, TabEquipes.Equipe, TabEquipes.Email, tabTreinando.Nome, tabLista.DetalhePagto, tabLista.TotalPagto, tabLista.Desconto, tabLista.Obs, TabTreinamentos.Investimento, tabLista.bloqueado, tabLista.edicao, tabLista.experiente, tabLista.Credito " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.IDEquipe =" + idEquipe.ToString() + " AND tabLista.IDTreinamento=" + idTreinamento.ToString() + " " +
                    "ORDER BY TabEquipes.Equipe, tabTreinando.Nome ";

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
        public DataTable ListarVendas()
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabTreinamentos.Descricao, tabTreinando.Nome, tabLista.DetalhePagto, tabLista.TotalPagto, tabLista.Desconto, TabTreinamentos.Investimento, tabLista.Invest, tabLista.ausente, tabLista.bloqueado, tabLista.edicao " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN tabLista ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.bloqueado=No " +
                    "ORDER BY TabTreinamentos.Descricao, tabTreinando.Nome ";

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
        public DataTable ListarVendasPorFormaPagto()
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.FormaPagto, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela  " +
                    "FROM tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista  " +
                    "GROUP BY tabPagtos.FormaPagto, tabLista.bloqueado  " +
                    "HAVING tabLista.bloqueado=No " +
                    "ORDER BY tabPagtos.FormaPagto ";

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
        public DataTable ListarSomaFormaPagto(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDTreinamento, tabPagtos.FormaPagto, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela  " +
                    "FROM tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista   " +
                    "GROUP BY tabLista.IDTreinamento, tabPagtos.FormaPagto   " +
                    "HAVING (((tabLista.IDTreinamento)=" + idTreinamento.ToString() + "))" +
                    "ORDER BY tabPagtos.FormaPagto";

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
        public DataTable ListarTreinandosDescontos(Int32 idTreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Nome, tabLista.Desconto, tabLista.Obs, tabLista.Credito " +
                    "FROM tabTreinando INNER JOIN(TabTreinamentos INNER JOIN tabLista ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.Desconto < 0 AND tabLista.IDTreinamento = " + idTreinamento.ToString();

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
        public DataTable ListarTreinandosFormaPagto(Int32 idTreinamento, string forma)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabLista.IDTreinamento, tabTreinando.Nome, tabPagtos.FormaPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela " +
                    "FROM tabTreinando INNER JOIN(tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabLista.IDTreinamento = " + idTreinamento.ToString();
                if (forma.ToString() != "0") sqlAccess += " AND tabPagtos.FormaPagto = '" + forma.ToString() + "' ";
                sqlAccess += " ORDER BY tabPagtos.FormaPagto, tabPagtos.DTVencimento;";

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
        public DataTable faturamento(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabTreinamentos.Descricao, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                    "FROM TabTreinamentos INNER JOIN (tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento " +
                    "WHERE (((tabPagtos.FormaPagto) Not Like '%Crédito%')) " +
                    "GROUP BY TabTreinamentos.Descricao, TabTreinamentos.DTInicio " +
                    "HAVING (((TabTreinamentos.DTInicio)>=#" + inicio.ToString("MM/dd/yyyy") + "# And (TabTreinamentos.DTInicio)<=#" + fim.ToString("MM/dd/yyyy") + "#)) " +
                    "ORDER BY TabTreinamentos.DTInicio";

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
        public DataTable faturamentoFormaPagto(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.FormaPagto, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                    "FROM TabTreinamentos INNER JOIN (tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento  " +
                    "WHERE (((TabTreinamentos.DTInicio)>=#" + inicio.ToString("MM/dd/yyyy") + "# And (TabTreinamentos.DTInicio)<=#" + fim.ToString("MM/dd/yyyy") + "#))  " +
                    "GROUP BY tabPagtos.FormaPagto  " +
                    "HAVING (((tabPagtos.FormaPagto) Not Like '%Crédito%')) " +
                    "ORDER BY tabPagtos.FormaPagto";

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
        public DataTable Vendas(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabEquipes.Equipe, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                    "FROM(tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista " +
                    "WHERE(((tabPagtos.DTPagto) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTPagto)<=#" + fim.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.FormaPagto) Not Like '%rédito%')) " +
                    "GROUP BY TabEquipes.Equipe " +
                    "HAVING(((TabEquipes.Equipe)Not Like '%acerto%')) " +
                    "ORDER BY TabEquipes.Equipe; ";
                //"SELECT TabEquipes.Equipe, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                //"FROM(tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista  " +
                //"WHERE(((tabLista.dataCadastro) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabLista.dataCadastro)<=#" + fim.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.FormaPagto) Not Like '%rédito%'))  " +
                //"GROUP BY TabEquipes.Equipe  " +
                //"HAVING(((TabEquipes.Equipe)Not Like '%acerto%'))  " +
                //"ORDER BY TabEquipes.Equipe;";

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
        public DataTable vendasFormaPagto(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.FormaPagto, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                    "FROM(tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista  " +
                    //"WHERE(((TabEquipes.Equipe)Not Like '%acerto%') AND((tabLista.dataCadastro) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabLista.dataCadastro)<=#" + fim.ToString("MM/dd/yyyy") + "#))  " +
                    "WHERE(((TabEquipes.Equipe)Not Like '%acerto%') AND((tabPagtos.DTPagto) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTPagto)<=#" + fim.ToString("MM/dd/yyyy") + "#))  " +
                    "GROUP BY tabPagtos.FormaPagto  " +
                    "HAVING(((tabPagtos.FormaPagto)Not Like '%rédito%'))  " +
                    "ORDER BY tabPagtos.FormaPagto;";

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
        public DataTable vendasFormaPagtoCredito(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.FormaPagto, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                    "FROM(tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista  " +
                    //"WHERE(((TabEquipes.Equipe)Not Like '%acerto%') AND((tabLista.dataCadastro) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabLista.dataCadastro)<=#" + fim.ToString("MM/dd/yyyy") + "#))  " +
                    "WHERE(((TabEquipes.Equipe)Not Like '%acerto%') AND((tabPagtos.DTPagto) >=#" + inicio.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTPagto)<=#" + fim.ToString("MM/dd/yyyy") + "#))  " +
                    "GROUP BY tabPagtos.FormaPagto  " +
                    "HAVING(((tabPagtos.FormaPagto) Like '%rédito%'))  " +
                    "ORDER BY tabPagtos.FormaPagto;";

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
        public void inserirTreinamentosPorTreinando(Int32 treinando, Int32 treinamento, Int32 equipe)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabLista (IDTreinando, IDTreinamento, IDEquipe) " +
                "VALUES (" + treinando.ToString() + ", " + treinamento.ToString() + ", " + equipe.ToString() + ")";
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
        public DataTable ListarPagtos(Int32 idLista)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.IDLista, tabPagtos.DTPagto, tabPagtos.valorParcela, tabPagtos.DTVencimento, tabPagtos.FormaPagto, tabPagtos.Responsavel, tabPagtos.visualizado, tabPagtos.cqNumero, tabPagtos.ctValidade " +
                "FROM tabPagtos " +
                "WHERE (((tabPagtos.IDLista)=" + idLista.ToString() + "))";

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
        public DataTable ListarPagto(Int32 idPagto)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT * " +
                "FROM tabPagtos " +
                "WHERE (((tabPagtos.IDPagto)=" + idPagto.ToString() + "))";

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
        public DataTable ListarEquipeTreinamento(Int32 idtreinamento)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT DISTINCT tabLista.IDEquipe, TabEquipes.Equipe  " +
                    "FROM tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe  " +
                    "GROUP BY tabLista.IDEquipe, TabEquipes.Equipe, tabLista.IDTreinamento  " +
                    "HAVING (((tabLista.IDTreinamento)=" + idtreinamento.ToString() + ")) " +
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
        public DataTable ListarComissoes2016(Int32 idtreinamento, Int32 idequipe)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Credito, tabLista.Invest, tabLista.carta, tabLista.ausente, tabLista.experiente, tabLista.maisAutorizado, Max(tabPagtos.DTVencimento) AS MaxDTVencimento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.r1, TabTreinamentos.r2, TabTreinamentos.r3, TabTreinamentos.r4, TabTreinamentos.r5, TabTreinamentos.DTInicio, TabEquipes.Equipe, TabTreinamentos.ro1, TabTreinamentos.ro2, TabTreinamentos.ro3, TabTreinamentos.ro4, TabTreinamentos.ro5 " +
                "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                "GROUP BY TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Credito, tabLista.Invest, tabLista.carta, tabLista.ausente, tabLista.experiente, tabLista.maisAutorizado, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.r1, TabTreinamentos.r2, TabTreinamentos.r3, TabTreinamentos.r4, TabTreinamentos.r5, TabTreinamentos.DTInicio, TabEquipes.Equipe, TabTreinamentos.ro1, TabTreinamentos.ro2, TabTreinamentos.ro3, TabTreinamentos.ro4, TabTreinamentos.ro5 " +
                "HAVING (((TabTreinamentos.IDTreinamento)=" + idtreinamento.ToString() + ") AND ((TabEquipes.IDEquipe)=" + idequipe.ToString() + "))  " +
                "ORDER BY tabTreinando.Nome, Max(tabPagtos.DTVencimento) ";

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
        public DataTable ListarComissoes2016Todos(Int32 idtreinamento)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Invest, tabLista.ausente, tabLista.experiente, tabLista.carta, tabLista.maisAutorizado, Max(tabPagtos.DTVencimento) AS MaxDTVencimento, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.r1, TabTreinamentos.r2, TabTreinamentos.r3, TabTreinamentos.r4, TabTreinamentos.r5, TabTreinamentos.DTInicio, TabEquipes.Equipe " +
                "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                "GROUP BY TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Invest, tabLista.ausente, tabLista.experiente, tabLista.carta, tabLista.maisAutorizado, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.r1, TabTreinamentos.r2, TabTreinamentos.r3, TabTreinamentos.r4, TabTreinamentos.r5, TabTreinamentos.DTInicio, TabEquipes.Equipe " +
                "HAVING TabTreinamentos.IDTreinamento=" + idtreinamento.ToString() + "  " +
                "ORDER BY tabTreinando.Nome, Max(tabPagtos.DTVencimento) ";

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
        public DataTable ListarComissoes(Int32 idtreinamento, Int32 idequipe)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Invest, tabLista.ausente, tabLista.experiente, tabLista.maisAutorizado, Max(tabPagtos.DTVencimento) AS MaxDTVencimento, First(tabPagtos.FormaPagto) AS UltimoFormaPagto, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.vlExperiente, TabTreinamentos.DTInicio, TabEquipes.Equipe  " +
                "FROM tabTreinando INNER JOIN (((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON tabTreinando.IDTreinando = tabLista.IDTreinando  " +
                "GROUP BY TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.IDLista, tabTreinando.Nome, tabLista.TotalPagto, tabLista.Desconto, tabLista.Invest, tabLista.ausente, tabLista.experiente, tabLista.maisAutorizado, TabTreinamentos.Descricao, TabTreinamentos.Investimento, TabTreinamentos.Investimento2, TabTreinamentos.Investimento3, TabTreinamentos.Investimento4, TabTreinamentos.vlExperiente, TabTreinamentos.DTInicio, TabEquipes.Equipe " +
                "HAVING (((TabTreinamentos.IDTreinamento)=" + idtreinamento.ToString() + ") AND ((TabEquipes.IDEquipe)=" + idequipe.ToString() + "))  " +
                "ORDER BY tabTreinando.Nome, Max(tabPagtos.DTVencimento) ";

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
        public DataTable ListarFormaPagtoLista(Int32 idlista)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "SELECT DISTINCT tabPagtos.FormaPagto FROM tabPagtos WHERE tabPagtos.IDLista=" + idlista;

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
        public DataTable ListarComissoesSem(Int32 idtreinamento, Int32 idequipe)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.ausente, tabTreinando.Nome, Count(tabPagtos.DTVencimento) AS MaxDTVencimento  " +
                    "FROM tabTreinando INNER JOIN (((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento) LEFT JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON tabTreinando.IDTreinando = tabLista.IDTreinando  " +
                    "GROUP BY TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.ausente, tabTreinando.Nome  " +
                    "HAVING (((TabTreinamentos.IDTreinamento)=" + idtreinamento.ToString() + ") AND ((TabEquipes.IDEquipe)=" + idequipe.ToString() + ") AND ((Count(tabPagtos.DTVencimento))=0))  " +
                    "ORDER BY tabTreinando.Nome, Count(tabPagtos.DTVencimento)";

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
        public DataTable ListarComissoesSemTodos(Int32 idtreinamento)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.ausente, tabTreinando.Nome, Count(tabPagtos.DTVencimento) AS MaxDTVencimento  " +
                    "FROM tabTreinando INNER JOIN (((TabEquipes INNER JOIN tabLista ON TabEquipes.IDEquipe = tabLista.IDEquipe) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento) LEFT JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON tabTreinando.IDTreinando = tabLista.IDTreinando  " +
                    "GROUP BY TabTreinamentos.IDTreinamento, TabEquipes.IDEquipe, tabLista.ausente, tabTreinando.Nome  " +
                    "HAVING TabTreinamentos.IDTreinamento=" + idtreinamento.ToString() + " AND Count(tabPagtos.DTVencimento)=0  " +
                    "ORDER BY tabTreinando.Nome, Count(tabPagtos.DTVencimento)";

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
        public void inserirPagto(Int32 IDLista, DateTime DTPagto, double valorParcela, DateTime DTVencimento, string FormaPagto, string ctNumero, string ctBandeira, string ctBanco, string cqBanco, string cqAgencia, string cqCC, string cqNumero, string Responsavel, string ctValidade, string ctSeguranca, string blNumero, string blSacado, string crOrigem)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabPagtos (IDLista, DTPagto, valorParcela, DTVencimento, FormaPagto, ctNumero, ctBandeira, ctBanco, cqBanco, cqAgencia, cqCC, cqNumero, Responsavel, ctValidade, ctSeguranca, blNumero, blSacado, crOrigem) " +
                "VALUES (" + IDLista.ToString() + ", #" + DTPagto.Date.ToString("MM/dd/yyyy") + "#, " + valorParcela.ToString().Replace(",", ".") + " , #" + DTVencimento.Date.ToString("MM/dd/yyyy") + "#, '" + FormaPagto.ToString() + "' , '" + ctNumero.ToString() + "' , '" + ctBandeira.ToString() +
                "', '" + ctBanco.ToString() + "', '" + cqBanco.ToString() + "', '" + cqAgencia.ToString() + "', '" + cqCC.ToString() + "', '" + cqNumero.ToString() + "', '" + Responsavel.ToString() + "', '" + ctValidade.ToString() + "', '" + ctSeguranca.ToString() + "', '" + blNumero.ToString() + "', '" + blSacado.ToString() + "', '" + crOrigem.ToString() + "')";
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
        public void inserirPagtoDinheiro(Int32 IDLista, DateTime DTPagto, double valorParcela, DateTime DTVencimento, string FormaPagto, string ctNumero, string ctBandeira, string ctBanco, string cqBanco, string cqAgencia, string cqCC, string cqNumero, string Responsavel, string ctValidade, string ctSeguranca, string blNumero, string blSacado, string crOrigem)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabPagtos (IDLista, DTPagto, valorParcela, valorLiquido, DTVencimento, DTRecebimento, FormaPagto, ctNumero, ctBandeira, ctBanco, cqBanco, cqAgencia, cqCC, cqNumero, Responsavel, ctValidade, ctSeguranca, blNumero, blSacado, crOrigem, recebido, status) " +
                "VALUES (" + IDLista.ToString() + ", #" + DTPagto.Date.ToString("MM/dd/yyyy") + "#, " + valorParcela.ToString().Replace(",", ".") + " , " + valorParcela.ToString().Replace(",", ".") + " , #" + DTVencimento.Date.ToString("MM/dd/yyyy") + "#, #" + DTVencimento.Date.ToString("MM/dd/yyyy") + "#, '" + FormaPagto.ToString() + "' , '" + ctNumero.ToString() + "' , '" + ctBandeira.ToString() +
                "', '" + ctBanco.ToString() + "', '" + cqBanco.ToString() + "', '" + cqAgencia.ToString() + "', '" + cqCC.ToString() + "', '" + cqNumero.ToString() + "', '" + Responsavel.ToString() + "', '" + ctValidade.ToString() + "', '" + ctSeguranca.ToString() + "', '" + blNumero.ToString() + "', '" + blSacado.ToString() + "', '" + crOrigem.ToString() + "', Yes, 1)";
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
        public void atualizarZerarGrupos(Int32 idtreinamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Grupo = NULL, tabLista.Status=0 WHERE tabLista.IDTreinamento=" + idtreinamento.ToString();

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
        public void atualizarDinheiro(Int32 idpagto, DateTime dt)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos Set DTRecebimento = #" + dt.Date.ToString("MM/dd/yyyy") + "#, status=1, recebido=Yes WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarDataParaPagto(Int32 idpagto, DateTime txtdtpara, double txtvalorparcela)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos Set DTVencimento = #" + txtdtpara.Date.ToString("MM/dd/yyyy") + "#, valorParcela = " + txtvalorparcela.ToString().Replace(",", ".") + " WHERE IDPagto = " + idpagto.ToString();

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
        public void VisualizarPagto(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos Set visualizado = TRUE WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarPagto(Int32 IDPagto, DateTime DTPagto, double valorParcela, DateTime DTVencimento, string FormaPagto, string ctNumero, string ctBandeira, string ctBanco, string cqBanco, string cqAgencia, string cqCC, string cqNumero, string Responsavel, string ctValidade, string ctSeguranca, string blNumero, string blSacado, string crOrigem)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos Set " +
                    "DTPagto = #" + DTPagto.Date.ToString("MM/dd/yyyy") + "#, " +
                    "valorParcela = " + valorParcela.ToString().Replace(",", ".") + ", " +
                    "DTVencimento = #" + DTVencimento.Date.ToString("MM/dd/yyyy") + "#, " +
                    "FormaPagto = '" + FormaPagto.ToString() + "' , " +
                    "ctNumero = '" + ctNumero.ToString() + "', " +
                    "ctBandeira = '" + ctBandeira.ToString() + "' , " +
                    "ctBanco = '" + ctBanco.ToString() + "', " +
                    "cqBanco = '" + cqBanco.ToString() + "', " +
                    "cqAgencia = '" + cqAgencia.ToString() + "', " +
                    "cqCC = '" + cqCC.ToString() + "', " +
                    "cqNumero = '" + cqNumero.ToString() + "', " +
                    "Responsavel = '" + Responsavel.ToString() + "', " +
                    "ctValidade = '" + ctValidade.ToString() + "', " +
                    "blNumero = '" + blNumero.ToString() + "', " +
                    "blSacado = '" + blSacado.ToString() + "', " +
                    "crOrigem = '" + crOrigem.ToString() + "', " +
                    "ctSeguranca = '" + ctSeguranca.ToString() + "' " +
                    "WHERE IDPagto = " + IDPagto.ToString();

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
        public void removerPagto(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM tabPagtos WHERE IDPagto = " + idpagto.ToString();

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
        public void removerPagtos(Int32 idlista)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM tabPagtos WHERE IDLista = " + idlista.ToString();

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
        public DataTable testarCartao(Int32 idlista, string numCartao)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.ctNumero, tabPagtos.IDLista, tabTreinando.Nome " +
                    "FROM (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista " +
                    "WHERE (((tabPagtos.ctNumero)='" + numCartao.ToString() + "') AND ((tabPagtos.IDLista)<>" + idlista.ToString() + "))";

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
        public DataTable testarNSU(Int32 idlista, string nsu)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.ctValidade, tabPagtos.IDLista, tabTreinando.Nome " +
                    "FROM (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista " +
                    "WHERE (((tabPagtos.ctValidade)='" + nsu.ToString() + "') AND ((tabPagtos.IDLista)<>" + idlista.ToString() + "))";

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
        public void atualizarTreinamentoTreinando(Int32 idlista, Int32 idtreinamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.IDTreinamento=" + idtreinamento.ToString() + " WHERE tabLista.IDLista=" + idlista.ToString() + " ";

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
        public void atualizarExcecao(Int32 idlista, Int32 excecao)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Excecao=" + excecao.ToString() + " WHERE tabLista.IDLista=" + idlista.ToString() + " ";

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
        public void atualizarArquetipo(Int32 idtreinando, string arq)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabTreinando SET tabTreinando.Arquetipo='" + arq.ToString() + "' WHERE tabTreinando.IDTreinando=" + idtreinando.ToString() + " ";

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
        public void atualizarGupoDiamond(Int32 idlista, String grupo)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabLista SET tabLista.Grupo='" + grupo.ToString() + "' WHERE tabLista.IDLista=" + idlista.ToString() + " ";

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
        public DataTable ListarCorGrupoPorTreinamento(Int32 id, Int32 grupo)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabCor.Grupo, TabCor.Cor FROM TabCor " +
                "WHERE TabCor.Grupo=" + grupo.ToString() + " AND TabCor.IdTreinamento=" + id.ToString() + " " +
                "ORDER BY TabCor.Grupo ";

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
        public DataTable ListarCoresPorTreinamento(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabCor.Grupo, TabCor.Cor FROM TabCor " +
                "WHERE TabCor.IdTreinamento=" + id.ToString() + " ORDER BY TabCor.Grupo";

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
        public void atualizarCorGrupo(Int32 idtreinamento, Int32 grupo, Int32 cor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabCor SET TabCor.Cor=" + cor.ToString() + " WHERE TabCor.IdTreinamento=" + idtreinamento.ToString() + " AND TabCor.Grupo=" + grupo.ToString() + "  ";

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
        public void removerCorGrupo(Int32 ID)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabCor WHERE IdTreinamento = " + ID.ToString();

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
        public void salvarCorGupoDiamond(Int32 idTreinamento, Int32 grupo, Int32 cor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabCor (IdTreinamento, Grupo, Cor) " +
                "VALUES (" + idTreinamento.ToString() + ", " + grupo.ToString() + ", " + cor.ToString() + ")";

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
    }
}
