using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace financeiroVoce.DataLayer
{
    public class ReceberDL : Conexao
    {
        private DataSet ds = new DataSet();

        public DataTable ListarContasAReceber(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE ((tabPagtos.DTVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND tabPagtos.FormaPagto <> 'Crédito' AND (tabPagtos.status = 0 OR tabPagtos.status = 3)) " +
                "ORDER BY tabPagtos.DTVencimento ";

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
        public DataTable ListarContasAReceberFormaPagto(DateTime datamin, DateTime datamax, string formapagto)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE (((tabPagtos.DTVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.FormaPagto)='" + formapagto.ToString() + "')) AND (tabPagtos.status=0 OR tabPagtos.status=3) " +
                "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarContasAReceberPorFinalCartao(string cartao)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabPagtos.ctNumero) LIKE '%" + cartao.ToString() + "') AND ((tabPagtos.status)=0 Or (tabPagtos.status)=3)) " +
                    "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarContasAReceberPorDOCCartao(string doc)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabPagtos.ctValidade = '" + doc.ToString() + "' AND (tabPagtos.status=0 Or tabPagtos.status=3) " +
                    "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarContasAReceberCheque(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctValidade, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE (tabPagtos.DTVencimento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# AND tabPagtos.DTVencimento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND tabPagtos.FormaPagto='Cheque' AND (tabPagtos.status=0 OR tabPagtos.status=3) " +
                "ORDER BY tabPagtos.DTVencimento, tabPagtos.Responsavel";

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
        public DataTable ListarContasAReceberTreinamento(Int32 idtreinamento, string ordena)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctValidade, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE TabTreinamentos.IDTreinamento = " + idtreinamento +
                " ORDER BY " + ordena.ToString();

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
        public DataTable ListarContasAReceberTreinamentoCheques(Int32 idtreinamento, string ordena)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.IDTreinamento, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE TabTreinamentos.IDTreinamento = " + idtreinamento + " AND tabPagtos.FormaPagto='Cheque' " +
                "ORDER BY " + ordena.ToString();

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
        public DataTable ListarTreinandosBloqueados(DateTime dt)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Nome, TabTreinamentos.Descricao " +
                    "FROM TabTreinamentos INNER JOIN (tabTreinando INNER JOIN tabLista ON tabTreinando.IDTreinando = tabLista.IDTreinando) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento " +
                    "WHERE tabLista.bloqueado=Yes AND tabLista.edicao=No AND tabLista.dataBloqueio=#" + dt.Date.ToString("MM/dd/yyyy") + "# " +
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
        public DataTable ListarChequesBloqueados(DateTime dt)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Nome, TabTreinamentos.Descricao, tabPagtos.Responsavel, tabPagtos.DTVencimento, tabPagtos.cqNumero, tabPagtos.valorParcela, tabLista.dataCadastro, tabLista.dataBloqueio, tabPagtos.DTPagto " +
                    "FROM tabTreinando INNER JOIN(TabTreinamentos INNER JOIN(tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE tabPagtos.FormaPagto = 'Cheque' AND tabLista.bloqueado  = Yes  AND tabLista.edicao = No AND tabPagtos.DTPagto=#" + dt.Date.ToString("MM/dd/yyyy") + "#  " +
                    "ORDER BY tabTreinando.Nome, tabPagtos.cqNumero ";

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
        public DataTable ListarCartoesBloqueados(DateTime dt)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabTreinando.Nome, TabTreinamentos.Descricao, tabPagtos.ctNumero, Count(tabPagtos.ctBandeira) AS Parcelas, Sum(tabPagtos.valorParcela) AS TotalPagto " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "GROUP BY tabTreinando.Nome, TabTreinamentos.Descricao, tabPagtos.ctNumero, tabPagtos.FormaPagto, tabLista.bloqueado, tabPagtos.DTPagto " +
                    "HAVING tabTreinando.Nome Not Like '%acerto%' AND tabPagtos.FormaPagto='cartão' AND tabLista.bloqueado=Yes AND tabPagtos.DTPagto=#" + dt.Date.ToString("MM/dd/yyyy") + "# " +
                    "ORDER BY tabTreinando.Nome, tabPagtos.ctNumero";

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
        public DataTable ListarCartoesBloqueadosResumo(DateTime dt)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT Sum(tabPagtos.valorParcela) AS TotalPagto " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "GROUP BY tabPagtos.FormaPagto, tabLista.bloqueado, tabPagtos.DTPagto " +
                    "HAVING tabPagtos.FormaPagto='cartão' AND tabLista.bloqueado=Yes AND tabPagtos.DTPagto=#" + dt.Date.ToString("MM/dd/yyyy") + "# ";

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
        public DataTable ListarChequesAtribuidos(Int32 idcompra)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.status " +
                "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                "WHERE tabPagtos.IDCompra=" + idcompra.ToString() + " " +
                "ORDER BY tabPagtos.DTVencimento, tabPagtos.valorParcela ";

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
        public DataTable ListarResumoReceber(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.DTVencimento, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                "FROM tabPagtos " +
                "GROUP BY tabPagtos.DTVencimento " +
                "HAVING (((tabPagtos.DTVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#))" +
                "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarResumoRecebidas(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.DTRecebimento, Sum(tabPagtos.valorLiquido) AS SomaDevalorLiquido " +
                    "FROM tabPagtos " +
                    "GROUP BY tabPagtos.DTRecebimento, tabPagtos.status " +
                    "HAVING (((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.status)=1)) " +
                    "ORDER BY tabPagtos.DTRecebimento";

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
        public DataTable ListarResumoRecebidasPorForma(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.FormaPagto, Sum(tabPagtos.valorLiquido) AS SomaDevalorLiquido " +
                    "FROM tabPagtos " +
                    "WHERE tabPagtos.DTRecebimento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And tabPagtos.DTRecebimento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND tabPagtos.status=1 " +
                    "GROUP BY tabPagtos.FormaPagto";

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
        public DataTable ListarResumoRecebidasPorFormaDiario(DateTime datamin, string forma)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT Sum(tabPagtos.valorLiquido) AS SomaDevalorLiquido " +
                    "FROM tabPagtos " +
                    "GROUP BY tabPagtos.DTRecebimento, tabPagtos.FormaPagto, tabPagtos.status " +
                    "HAVING (((tabPagtos.DTRecebimento)=#" + datamin.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.FormaPagto)='" + forma.ToString() + "') AND ((tabPagtos.status)=1))";

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
        public DataTable ListarResumoReceberTipo(DateTime datamin, DateTime datamax, string tipo)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.DTVencimento, Sum(tabPagtos.valorParcela) AS SomaDevalorParcela, tabPagtos.FormaPagto " +
                "FROM tabPagtos " +
                "GROUP BY tabPagtos.DTVencimento, tabPagtos.FormaPagto " +
                "HAVING (((tabPagtos.DTVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.FormaPagto)='" + tipo.ToString() + "')) " +
                "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarContasRecebidas(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                //"SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status  " +
                //"FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                //    //"WHERE ((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND (tabPagtos.status)=1) " +
                //"WHERE ((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND (tabPagtos.status=1 OR tabPagtos.status=5)) " +
                //"ORDER BY tabPagtos.DTRecebimento ";
                DataTable retorno = new DataTable();
                
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorLiquido, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status, tabPagtos.blNumero, tabPagtos.blSacado, TabFornecedor.nmFornecedor " +
                    "FROM ((tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) LEFT JOIN TabCompras ON tabPagtos.IDCompra = TabCompras.IDCompra) LEFT JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                    "WHERE (((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# AND (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.status)=1 Or (tabPagtos.status)=5)) " +
                    "ORDER BY tabPagtos.DTRecebimento ";

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
        public DataTable ListarContasRecebidasTipo(DateTime datamin, DateTime datamax, String tipo)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    //"SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status  " +
                    //"FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorLiquido, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status, tabPagtos.blNumero, tabPagtos.blSacado, TabFornecedor.nmFornecedor " +
                        "FROM ((tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) LEFT JOIN TabCompras ON tabPagtos.IDCompra = TabCompras.IDCompra) LEFT JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                    "WHERE tabPagtos.FormaPagto='" + tipo.ToString() + "' AND tabPagtos.DTRecebimento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND tabPagtos.status=1  " +
                    //"WHERE ((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND (tabPagtos.status=" + tipo.ToString() + ")) " +
                    "ORDER BY tabPagtos.DTRecebimento ";

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
        public DataTable ListarContasRecebidasStatus(DateTime datamin, DateTime datamax, Int32 status)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    //"SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status  " +
                    //"FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.valorLiquido, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.banco, tabPagtos.status, tabPagtos.blNumero, tabPagtos.blSacado, TabFornecedor.nmFornecedor " +
                        "FROM ((tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) LEFT JOIN TabCompras ON tabPagtos.IDCompra = TabCompras.IDCompra) LEFT JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                    "WHERE ((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND (tabPagtos.status=" + status.ToString() + ")) " +
                    "ORDER BY tabPagtos.DTRecebimento ";

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
        public DataTable ListarContasDevolvidas(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.IDLista, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.DTRecebimento, tabPagtos.destino, tabPagtos.status  " +
                    "FROM (((tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista) INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabTreinando ON tabLista.IDTreinando = tabTreinando.IDTreinando) INNER JOIN TabTreinamentos ON tabLista.IDTreinamento = TabTreinamentos.IDTreinamento " +
                    "WHERE (((tabPagtos.DTVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.status)=2 Or (tabPagtos.status)=6)) " +
                    "ORDER BY tabPagtos.DTVencimento ";

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
        public DataTable ListarChequesRecuperadosDestino(DateTime datamin, DateTime datamax, string quem)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTRecebimento, tabPagtos.valorParcela, tabPagtos.valorLiquido, tabTreinando.Nome, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.destino " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.destino)='" + quem.ToString() + "') AND ((tabPagtos.status)=6)) " +
                    "ORDER BY tabPagtos.DTRecebimento";

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
        public DataTable ListarChequesRecuperados(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, tabPagtos.DTRecebimento, tabPagtos.valorParcela, tabPagtos.valorLiquido, tabTreinando.Nome, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.destino " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando " +
                    "WHERE (((tabPagtos.DTRecebimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (tabPagtos.DTRecebimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((tabPagtos.status)=6)) " +
                    "ORDER BY tabPagtos.DTRecebimento";

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
        public DataTable ListarChequesDevolvidos(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, TabHistoricoCheque.Data, TabHistoricoCheque.Obs, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabTreinando.Nome, tabPagtos.Responsavel, TabTreinamentos.Descricao, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.destino " +
                    "FROM (tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) INNER JOIN TabHistoricoCheque ON tabPagtos.IDPagto = TabHistoricoCheque.IDPagto  " +
                    "WHERE (((TabHistoricoCheque.Data)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabHistoricoCheque.Data)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabHistoricoCheque.Obs) Like 'Cheque devolvido do%'))  " +
                    "ORDER BY TabHistoricoCheque.Data ";

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
        public DataTable ListarInteracoes(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tabPagtos.IDPagto, TabHistoricoCheque.Data, TabHistoricoCheque.Obs, tabPagtos.DTVencimento, tabPagtos.valorParcela, tabTreinando.Nome, tabPagtos.Responsavel, TabTreinamentos.Descricao, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.destino  " +
                    "FROM tabTreinando INNER JOIN (TabTreinamentos INNER JOIN (tabLista INNER JOIN (tabPagtos INNER JOIN TabHistoricoCheque ON tabPagtos.IDPagto = TabHistoricoCheque.IDPagto) ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando  " +
                    "WHERE (((TabHistoricoCheque.Data)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabHistoricoCheque.Data)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabHistoricoCheque.Cobranca)=Yes))  " +
                    "ORDER BY TabHistoricoCheque.Data, tabPagtos.Responsavel ";

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
        public DataTable ListarChequePorResponsavel(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.DTRecebimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status, tabPagtos.destino, TabFornecedor.nmFornecedor, TabCompras.Obs, tabPagtos.IDCompra, tabPagtos.banco  " +
                "FROM ((tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) LEFT JOIN TabCompras ON tabPagtos.IDCompra = TabCompras.IDCompra) LEFT JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE tabPagtos.Responsavel LIKE '%" + nm.ToString() + "%' AND tabPagtos.FormaPagto = 'Cheque' " +
                "ORDER BY tabPagtos.DTVencimento";

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
        public DataTable ListarChequePorTreinando(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT tabPagtos.IDPagto, tabPagtos.DTVencimento, tabPagtos.DTRecebimento, tabPagtos.valorParcela, tabPagtos.FormaPagto, tabTreinando.Nome, tabTreinando.IDTreinando, tabPagtos.Responsavel, TabTreinamentos.Descricao, TabEquipes.Equipe, tabPagtos.ctNumero, tabPagtos.ctBandeira, tabPagtos.ctBanco, tabPagtos.ctValidade, tabPagtos.ctSeguranca, tabPagtos.cqBanco, tabPagtos.cqAgencia, tabPagtos.cqCC, tabPagtos.cqNumero, tabPagtos.blNumero, tabPagtos.blSacado, tabPagtos.status, tabPagtos.destino, TabFornecedor.nmFornecedor, TabCompras.Obs, tabPagtos.IDCompra, tabPagtos.banco " +
                "FROM ((tabTreinando INNER JOIN (TabTreinamentos INNER JOIN ((tabLista INNER JOIN TabEquipes ON tabLista.IDEquipe = TabEquipes.IDEquipe) INNER JOIN tabPagtos ON tabLista.IDLista = tabPagtos.IDLista) ON TabTreinamentos.IDTreinamento = tabLista.IDTreinamento) ON tabTreinando.IDTreinando = tabLista.IDTreinando) LEFT JOIN TabCompras ON tabPagtos.IDCompra = TabCompras.IDCompra) LEFT JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE tabTreinando.Nome LIKE '%" + nm.ToString() + "%' AND tabPagtos.FormaPagto = 'Cheque' " +
                "ORDER BY tabPagtos.DTVencimento";

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
        public void atualizarReceberParcela(Int32 idcontasreceber, DateTime dtreceber, string banco, double valor)
        {
            if (!Connect())
                return;
            try
            {
                //"UPDATE TabPagtos Set DTRecebimento = #" + dtreceber.Date.ToString("MM/dd/yyyy") + "#, status = 1, banco = '" + banco.ToString() + "' WHERE IDPagto = " + idcontasreceber.ToString();
                string sqlAccess =
                "UPDATE TabPagtos SET TabPagtos.DTRecebimento = #" + dtreceber.Date.ToString("MM/dd/yyyy") + "#,  TabPagtos.status = 1, TabPagtos.banco = '" + banco.ToString() + "', TabPagtos.valorLiquido = " + valor.ToString().Replace(",", ".") +
                "  WHERE TabPagtos.IDPagto= " + idcontasreceber.ToString();
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
        public void atualizarEstornarRecebimento(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set DTRecebimento = null, status = 0, Banco = null WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarDestino(Int32 idpagto, string destino)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set destino = '" + destino.ToString() + "' WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarStatus(Int32 idpagto, Int32 status)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set status = " + status.ToString() + " WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarDataEValoresRecebimento(Int32 idpagto, DateTime dt, double vl, double vlliquido)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set DTRecebimento=#" + dt.Date.ToString("MM/dd/yyyy") + "#, valorLiquido=" + vlliquido.ToString().Replace(",", ".") + ", valorParcela=" + vl.ToString().Replace(",", ".") + " WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarDataRecebimento(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set DTRecebimento=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarAtribuirChequeTerceiro(Int32 idpagto, DateTime dt)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set recebido=Yes, DTRecebimento=#" + dt.Date.ToString("MM/dd/yyyy") + "# WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarTendencia(Int32 idtreinando)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos INNER JOIN tabLista ON tabPagtos.IDLista = tabLista.IDLista SET tabPagtos.status = 3 " +
                "WHERE tabPagtos.status=0 AND tabLista.IDTreinando=" + idtreinando;

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
        public void atualizarAtribuirCheque(Int32 idpagto, Int32 idcompra, double valor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set status=5, IDCompra=" + idcompra.ToString() + ", valorLiquido = " + valor.ToString().Replace(",", ".") + " WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarRemoverCheque(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set status=0, IDCompra=NULL, DTRecebimento=NULL, recebido=No WHERE IDPagto = " + idpagto.ToString();

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
        public void atualizarReceberCartoes()
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE tabPagtos SET tabPagtos.DTRecebimento = [tabPagtos].[DTVencimento], tabPagtos.banco = [tabPagtos].[ctBanco], tabPagtos.status = 1 " +
                                    " WHERE tabPagtos.DTVencimento<=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# AND tabPagtos.FormaPagto='Cartão' AND tabPagtos.status=0 ";
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
        public void inserirCartao(double valorParcela, DateTime DTVencimento, string ctNumero, string ctBandeira, string ctDoc)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabPagtos (IDLista, DTPagto, valorParcela, DTVencimento, FormaPagto, ctNumero, ctBandeira, ctValidade) " +
                "VALUES (4586, #" + DateTime.Now.ToString("MM/dd/yyyy") + "#, " + valorParcela.ToString().Replace(",", ".") + " , #" + DTVencimento.Date.ToString("MM/dd/yyyy") +
                    "#, 'Cartão' , '" + ctNumero.ToString() + "' , '" + ctBandeira.ToString() + "', '" + ctDoc.ToString() + "')";

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
        public void inserirObsChequeDevolvido(Int32 idpagto, string obs, Boolean cobraca)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabHistoricoCheque (IDPagto, Data, Obs, Cobranca) " +
                "VALUES (" + idpagto.ToString() + ", #" + DateTime.Now.ToString("MM/dd/yyyy") + "#, '" + obs.ToString() + "', " + cobraca.ToString() + ")";

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
        public DataTable ListarObsChequeDevolvido(Int32 idpagto)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabHistoricoCheque.Data, TabHistoricoCheque.Obs " +
                        "FROM TabHistoricoCheque " +
                        "WHERE TabHistoricoCheque.IDPagto=" + idpagto.ToString() + "  " +
                        "ORDER BY TabHistoricoCheque.Data ";

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
        public void atualizarChequeRecuperado(Int32 idpagto, DateTime dtRecuperado, double valorRecuperado)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabPagtos Set DTRecebimento = #" + dtRecuperado.ToString("MM/dd/yyyy") + "#, valorLiquido = " + valorRecuperado.ToString().Replace(",", ".") + " WHERE IDPagto = " + idpagto.ToString();

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
