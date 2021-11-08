using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace financeiroVoce.DataLayer
{
    public class PagarDL : Conexao
    {
        private DataSet ds = new DataSet();

        public DataTable ListarComprasPendentes()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabCompras.IDCompra, TabCompras.IDFornecedor, TabFornecedor.nmFornecedor, TabCompras.dtCompra, TabCompras.dtEntrega, TabCompras.Obs, TabCompras.Particular " +
                "FROM TabCompras INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE TabCompras.Recebido = No " +
                "ORDER BY TabCompras.dtCompra ";

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
        public DataTable ListarComprasFinalizadas()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabCompras.IDCompra, TabCompras.IDFornecedor, TabFornecedor.nmFornecedor, TabCompras.dtCompra, TabCompras.dtEntrega, TabCompras.Obs " +
                    "FROM TabCompras INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                    "WHERE TabCompras.Recebido = Yes " +
                    "ORDER BY TabCompras.dtCompra ";

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
        public DataTable ListarComprasFinalizadasPorPeriodo(DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabCompras.IDCompra, TabCompras.IDFornecedor, TabFornecedor.nmFornecedor, TabCompras.dtCompra, TabCompras.dtEntrega, TabCompras.Obs, TabCompras.Particular " +
                    "FROM TabCompras INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                    "WHERE TabCompras.dtCompra>=#" + inicio.AddDays(-1).ToString("MM/dd/yyyy") + "# And TabCompras.dtCompra<=#" + fim.AddDays(1).ToString("MM/dd/yyyy") + "# AND TabCompras.Recebido=Yes " +
                    "ORDER BY TabCompras.dtEntrega DESC ";

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
        public DataTable ListarComprasFinalizadasPorFornecedor(Int32 idfornecedor, DateTime inicio, DateTime fim)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabCompras.IDCompra, TabCompras.IDFornecedor, TabFornecedor.nmFornecedor, TabCompras.dtCompra, TabCompras.dtEntrega, TabCompras.Obs, TabCompras.Particular " +
                "FROM TabCompras INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE TabCompras.IDFornecedor=" + idfornecedor.ToString() + " AND TabCompras.dtCompra>=#" + inicio.AddDays(-1).ToString("MM/dd/yyyy") + "# And TabCompras.dtCompra<=#" + fim.AddDays(1).ToString("MM/dd/yyyy") + "# AND TabCompras.Recebido=Yes " +
                //"WHERE TabCompras.Recebido = Yes AND TabCompras.IDFornecedor=" + idfornecedor.ToString() + " " +
                "ORDER BY TabCompras.dtEntrega DESC ";

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
        public DataTable ListarCompra(Int32 idcompra)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT TabCompras.IDCompra, TabCompras.IDFornecedor, TabFornecedor.nmFornecedor, TabCompras.dtCompra, TabCompras.dtEntrega, TabCompras.Obs, TabCompras.totalCompra " +
                "FROM TabCompras INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE TabCompras.IDCompra = " + idcompra.ToString();

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
        public DataTable ListarIDCompra(DateTime dtcompra)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT IDCompra " +
                "FROM TabCompras " +
                "WHERE dtCompra = #" + dtcompra.ToString() + "#" +
                "ORDER BY TabCompras.dtCompra ";

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
        public DataTable ListarFornecedoresDrop()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor " +
                    "FROM TabFornecedor " +
                    "WHERE TabFornecedor.excluir = No " +
                    "ORDER BY TabFornecedor.nmFornecedor";

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
        public DataTable ListarFornecedores()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor, TabFornecedor.telefoneFornecedor, TabFornecedor.emailFornecedor, TabFornecedor.item, TabFornecedor.contato, TabFornecedor.obs " +
                    "FROM TabFornecedor " +
                    "ORDER BY TabFornecedor.nmFornecedor";

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
        public DataTable ListarFornecedoresPlanilhas()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor " +
                    "FROM TabFornecedor WHERE TabFornecedor.Planilha=Yes " +
                    "ORDER BY TabFornecedor.nmFornecedor";

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
        public DataTable ListarFornecedoresCentroCusto()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor, TabFornecedor.telefoneFornecedor, TabFornecedor.emailFornecedor, TabFornecedor.item, TabFornecedor.contato, TabFornecedor.obs " +
                    "FROM TabFornecedor " +
                    "WHERE TabFornecedor.CentroCusto=Yes " +
                    "ORDER BY TabFornecedor.nmFornecedor ";

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
        public DataTable ListarFornecedor(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT * " +
                "FROM TabFornecedor " +
                "WHERE IDFornecedor = " + id.ToString() +
                " ORDER BY TabFornecedor.nmFornecedor";

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
        public DataTable ListarClassificacaoFinanceira()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto " +
                    "FROM TabProdutos " +
                    "WHERE(((TabProdutos.classFinanceira) = Yes) AND((TabProdutos.excluir) = No)) " +
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
        public DataTable ListarProdutosPorFornecedores(Int32 id, DateTime dtinicio, DateTime dtfim)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.nmProduto, Sum(TabItemCompra.Qtde) AS SomaDeQtde, Max(TabItemCompra.valorUnitario) AS MaxUnitario " +
                    "FROM(TabCompras INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto " +
                    "WHERE TabCompras.dtCompra >=#" + dtinicio.Date.ToString("MM/dd/yyyy") + "# And TabCompras.dtCompra <=#" + dtfim.Date.ToString("MM / dd / yyyy") + "# " +
                    "GROUP BY TabProdutos.nmProduto, TabCompras.IDFornecedor " +
                    "HAVING TabCompras.IDFornecedor=" + id.ToString() + " " +
                    "ORDER BY TabProdutos.nmProduto;";

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
        public DataTable ListarProdutos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT * " +
                "FROM TabProdutos " +
                "WHERE TabProdutos.excluir=No " +
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
        public DataTable ListarProdutosPorFornecedor(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabProdutos.IDProduto, TabProdutos.IDFornecedor, TabProdutos.nmProduto, TabProdutos.qtdeProduto, TabProdutos.obsProduto, TabProdutos.gerenciar, TabProdutos.excluir " +
                        "FROM TabProdutos " +
                        "WHERE TabProdutos.IDFornecedor=" + id.ToString() + " AND TabProdutos.excluir=No " +
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
        public DataTable ListarTodosProdutos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                        "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor, TabProdutos_1.IDProduto as idclassificacao, TabProdutos_1.nmProduto as Classificacao, TabProdutos.qtdeProduto, TabProdutos.obsProduto, TabProdutos.gerenciar, TabProdutos.excluir, TabProdutos.classFinanceira, TabProdutos.valoruni " +
                        "FROM(TabProdutos INNER JOIN TabFornecedor ON TabProdutos.IDFornecedor = TabFornecedor.IDFornecedor) LEFT JOIN TabProdutos AS TabProdutos_1 ON TabProdutos.IDClassFinanceira = TabProdutos_1.IDProduto " +
                        "WHERE(((TabProdutos.excluir) = No) AND((TabProdutos.classFinanceira) = No)) " +
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
        public DataTable ListarProdutosExcluidos()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                        "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabFornecedor.IDFornecedor, TabFornecedor.nmFornecedor, TabProdutos.qtdeProduto, TabProdutos.obsProduto, TabProdutos.excluir " +
                        "FROM TabProdutos INNER JOIN TabFornecedor ON TabProdutos.IDFornecedor = TabFornecedor.IDFornecedor " +
                        "WHERE(((TabProdutos.excluir) = Yes)) " +
                        "ORDER BY TabProdutos.nmProduto ";

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
        public DataTable ListarProduto(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                "SELECT * " +
                "FROM TabProdutos " +
                "WHERE IDProduto = " + id.ToString();

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
        public DataTable ListarProdutosEstoque()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabProdutos.qtdeProduto  " +
                    "FROM TabProdutos  " +
                    "WHERE TabProdutos.gerenciar=Yes AND TabProdutos.excluir=No  " +
                    "ORDER BY TabProdutos.nmProduto ";

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
        public DataTable ListarProdutosClassificacaoFinanceira()
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabProdutos.qtdeProduto, TabProdutos.obsProduto,  TabProdutos.excluir, TabProdutos.classFinanceira " +
                    "FROM TabProdutos  " +
                    "WHERE TabProdutos.classFinanceira=Yes AND TabProdutos.Excluir = No  " +
                    "ORDER BY TabProdutos.nmProduto ";

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
        public DataTable CarregarProduto(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabProdutos.qtdeProduto  " +
                    "FROM TabProdutos  " +
                    "WHERE TabProdutos.IDProduto=" + id;

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
        public DataTable ListarItensCompras(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabItemCompra.IDItemCompra, TabProdutos.nmProduto, TabItemCompra.Qtde, TabItemCompra.valorUnitario, [Qtde]*[valorUnitario] AS TotalItem, TabProdutos.qtdeProduto " +
                "FROM TabItemCompra INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto " +
                "WHERE (((TabItemCompra.IDCompra)=" + id.ToString() + "))";
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
        public DataTable ListarComprasProduto(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabCompras.dtEntrega, TabItemCompra.Qtde, TabFornecedor.nmFornecedor " +
                "FROM (TabItemCompra INNER JOIN TabCompras ON TabItemCompra.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE TabItemCompra.IDProduto=" + id + " " +
                "ORDER BY TabCompras.dtEntrega";

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
        public DataTable ListarParcelasCompra(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabContasAPagar.IDContasPagar, TabCentroCusto.CentroCusto, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.dtVencimento, TabContasAPagar.valorLancamento, TabContasAPagar.pago " +
                    "FROM TabContasAPagar INNER JOIN TabCentroCusto ON TabContasAPagar.IDCentro = TabCentroCusto.IDCentro " +
                    "WHERE (TabContasAPagar.IDCompra=" + id.ToString() + ")";
                //"SELECT IDContasPagar, FormaPagto, Obs, dtVencimento, valorLancamento, pago " +
                //"FROM TabContasAPagar " +
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
        public DataTable ListarContasAPagar(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, TabContasAPagar.dtVencimento, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco " +
                "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE (((TabContasAPagar.dtVencimento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# AND (TabContasAPagar.dtVencimento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabContasAPagar.pago)=No) AND ((TabContasAPagar.oculto)=No)) " +
                "ORDER BY TabContasAPagar.dtVencimento ";

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
        public DataTable ListarContasAPagarBancoFormaTipo(DateTime datamin, DateTime datamax, String banco, String forma, String tipo, String fornecedor, String classFiscal, string centro)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, First(TabProdutos.nmProduto) AS PrimeiroDenmProduto, TabCompras.dtEntrega, TabContasAPagar.dtVencimento, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco, TabContasAPagar.IDCentro " +
                        "FROM (((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto " +
                        "GROUP BY TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, TabCompras.dtEntrega, TabContasAPagar.dtVencimento, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco, TabContasAPagar.IDCentro, TabContasAPagar.pago, TabContasAPagar.oculto, TabCompras.Particular " +
                        "HAVING TabContasAPagar.dtVencimento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtVencimento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# ";

                if (classFiscal.ToString().Length > 0) sqlAccess += " AND First(TabProdutos.nmProduto) Like '%" + classFiscal.ToString() + "%' ";
                sqlAccess += "AND TabContasAPagar.pago=No AND TabContasAPagar.oculto=No ";
                if (banco != "todos") sqlAccess += "AND TabContasAPagar.Banco='" + banco.ToString() + "' ";
                if (forma != "todos") sqlAccess += "AND TabContasAPagar.FormaPagto = '" + forma.ToString() + "' ";
                if (centro != "0") sqlAccess += "AND TabContasAPagar.IDCentro = " + centro.ToString() + " ";
                if (tipo != "todos") sqlAccess += "AND TabCompras.Particular=" + tipo.ToString() + " ";
                if (fornecedor.ToString().Length > 0) sqlAccess += "AND TabFornecedor.nmFornecedor LIKE '%" + fornecedor.ToString() + "%' ";
                sqlAccess += "ORDER BY TabContasAPagar.dtVencimento ";

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
        public DataTable ListarContasPagas(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, TabContasAPagar.dtVencimento, TabContasAPagar.valorLancamento, TabContasAPagar.dtPagamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco  " +
                "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                "WHERE (((TabContasAPagar.dtPagamento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabContasAPagar.dtPagamento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabContasAPagar.pago)=Yes) AND ((TabContasAPagar.oculto)=No)) " +
                "ORDER BY TabContasAPagar.dtPagamento";

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
        public void atualizarClassificacoes()
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos SET TabProdutos.IDClassFinanceira = [TabProdutos].[IDProduto] " +
                                   "WHERE TabProdutos.IDClassFinanceira Is Null AND TabProdutos.classFinanceira = Yes ";

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
        public DataTable ListarContasPagasResumo(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabContasAPagar.IDContasPagar, First(TabProdutos.nmProduto) AS classificacao, TabContasAPagar.IDCentro, TabContasAPagar.valorLancamento " +
                    "FROM((((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto) LEFT JOIN TabProdutos AS TabProdutos_1 ON TabProdutos.IDClassFinanceira = TabProdutos_1.IDProduto " +
                    "GROUP BY TabContasAPagar.IDContasPagar, TabContasAPagar.IDCentro, TabContasAPagar.valorLancamento, TabContasAPagar.dtPagamento, TabContasAPagar.pago, TabContasAPagar.oculto " +
                    //"HAVING(((TabContasAPagar.dtPagamento) >=#9/1/2017# And (TabContasAPagar.dtPagamento)<=#9/30/2017#) AND ((TabContasAPagar.pago)=Yes) AND ((TabContasAPagar.oculto)=No))
                    "HAVING TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No " +
                    "ORDER BY First(TabProdutos.nmProduto), TabContasAPagar.dtPagamento ";

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
        public DataTable ListarContasPagasPorCentro(Int32 centro)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT tempContasPagas.classificacao, Sum(tempContasPagas.valorLancamento) AS SomaDevalorLancamento FROM tempContasPagas " +
                    "GROUP BY tempContasPagas.classificacao, tempContasPagas.IDCentro " +
                    "HAVING tempContasPagas.IDCentro = " + centro.ToString() + " " +
                    "ORDER BY tempContasPagas.classificacao; ";
                //"SELECT TabProdutos_1.nmProduto AS classificacao, Sum(TabContasAPagar.valorLancamento) AS SomaDevalorLancamento " +
                //"FROM(((((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto) LEFT JOIN TabCentroCusto ON TabContasAPagar.IDCentro = TabCentroCusto.IDCentro) LEFT JOIN TabProdutos AS TabProdutos_1 ON TabProdutos.IDClassFinanceira = TabProdutos_1.IDProduto " +
                //"GROUP BY TabProdutos_1.nmProduto, TabContasAPagar.dtPagamento, TabContasAPagar.IDCentro, TabContasAPagar.pago, TabContasAPagar.oculto " +
                //"HAVING TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.IDCentro=" + centro.ToString() + " AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No " +
                //"ORDER BY TabProdutos_1.nmProduto ";

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
        public DataTable ListarContasPagasFormaBancoTipo(DateTime datamin, DateTime datamax, String banco, String forma, String fornecedor, String classFiscal, string centro)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, First(TabProdutos.nmProduto) AS classificacao, TabCentroCusto.CentroCusto, TabCompras.dtEntrega, TabContasAPagar.dtVencimento, TabContasAPagar.dtPagamento, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco, TabContasAPagar.IDCentro " +
                        "FROM(((((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto) LEFT JOIN TabCentroCusto ON TabContasAPagar.IDCentro = TabCentroCusto.IDCentro) LEFT JOIN TabProdutos AS TabProdutos_1 ON TabProdutos.IDClassFinanceira = TabProdutos_1.IDProduto " +
                        "GROUP BY TabContasAPagar.IDContasPagar, TabFornecedor.nmFornecedor, TabCentroCusto.CentroCusto, TabCompras.dtEntrega, TabContasAPagar.dtVencimento, TabContasAPagar.dtPagamento, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.Obs, TabContasAPagar.Banco, TabContasAPagar.IDCentro, TabContasAPagar.pago, TabContasAPagar.oculto, TabCompras.Particular " +
                        "HAVING TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# ";
                sqlAccess += "AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No ";
                if (banco != "todos") sqlAccess += "AND TabContasAPagar.Banco='" + banco.ToString() + "' ";
                if (forma != "todos") sqlAccess += "AND TabContasAPagar.FormaPagto = '" + forma.ToString() + "' ";
                if (centro != "0")
                {
                    if (centro == "5") sqlAccess += "AND TabContasAPagar.IDCentro <> 2 ";
                    else sqlAccess += "AND TabContasAPagar.IDCentro = " + centro.ToString() + " ";
                }
                if (classFiscal.ToString().Length > 0) sqlAccess += " AND TabProdutos_1.nmProduto Like '%" + classFiscal.ToString() + "%' ";
                if (fornecedor.ToString().Length > 0) sqlAccess += "AND TabFornecedor.nmFornecedor LIKE '%" + fornecedor.ToString() + "%' ";
                sqlAccess += "ORDER BY TabContasAPagar.dtPagamento ";

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
        public DataTable ListarContasPagasResumo(DateTime datamin, DateTime datamax, Boolean particular)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabFornecedor.nmFornecedor, Sum(TabContasAPagar.valorLancamento) AS SomaDevalorLancamento " +
                        "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                        "WHERE (((TabContasAPagar.FormaPagto)<>'Cheques Terceiros') AND ((TabCompras.Particular)=" + particular.ToString() + ") AND ((TabContasAPagar.pago)=Yes) AND ((TabContasAPagar.oculto)=No) AND ((TabContasAPagar.dtPagamento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabContasAPagar.dtPagamento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#)) " +
                        "GROUP BY TabFornecedor.nmFornecedor " +
                        "ORDER BY TabFornecedor.nmFornecedor ";
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
        public DataTable ListarContasPagasComTerceirosResumo(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT TabFornecedor.nmFornecedor, Sum(TabContasAPagar.valorLancamento) AS SomaDevalorLancamento " +
                        "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor " +
                        "WHERE TabContasAPagar.FormaPagto='Cheques Terceiros' AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No AND TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# " +
                        "GROUP BY TabFornecedor.nmFornecedor " +
                        "ORDER BY TabFornecedor.nmFornecedor ";
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
        public DataTable ListarContasPagasComTerceirosDetalhado(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                //"SELECT TabContasAPagar.dtPagamento, TabFornecedor.nmFornecedor, TabProdutos.nmProduto, TabCompras.Obs, TabContasAPagar.valorLancamento " +
                //"FROM (((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto " +
                //"WHERE (((TabContasAPagar.dtPagamento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabContasAPagar.dtPagamento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabContasAPagar.FormaPagto)='Cheques Terceiros') AND ((TabContasAPagar.pago)=Yes) AND ((TabContasAPagar.oculto)=No)) " +
                //"ORDER BY TabContasAPagar.dtPagamento, TabFornecedor.nmFornecedor";
                    "SELECT TabContasAPagar.dtPagamento, TabFornecedor.nmFornecedor, First(TabProdutos.nmProduto) AS nmProduto, TabCompras.Obs, TabContasAPagar.valorLancamento " +
                    "FROM (((TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN TabFornecedor ON TabCompras.IDFornecedor = TabFornecedor.IDFornecedor) INNER JOIN TabItemCompra ON TabCompras.IDCompra = TabItemCompra.IDCompra) INNER JOIN TabProdutos ON TabItemCompra.IDProduto = TabProdutos.IDProduto " +
                    "GROUP BY TabContasAPagar.dtPagamento, TabFornecedor.nmFornecedor, TabCompras.Obs, TabContasAPagar.valorLancamento, TabContasAPagar.FormaPagto, TabContasAPagar.pago, TabContasAPagar.oculto " +
                    "HAVING (((TabContasAPagar.dtPagamento)>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And (TabContasAPagar.dtPagamento)<=#" + datamax.Date.ToString("MM/dd/yyyy") + "#) AND ((TabContasAPagar.FormaPagto)='Cheques Terceiros') AND ((TabContasAPagar.pago)=Yes) AND ((TabContasAPagar.oculto)=No)) " +
                    "ORDER BY TabContasAPagar.dtPagamento, TabFornecedor.nmFornecedor";
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
        public DataTable ListarChequesTerceirosPagoContasMes(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                        "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN tabPagtos ON TabCompras.IDCompra = tabPagtos.IDCompra " +
                        "WHERE tabPagtos.DTVencimento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.FormaPagto='Cheques Terceiros' AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No";
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
        public DataTable ListarChequesTerceirosPagoContasFuturo(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                        "SELECT Sum(tabPagtos.valorParcela) AS SomaDevalorParcela " +
                        "FROM (TabContasAPagar INNER JOIN TabCompras ON TabContasAPagar.IDCompra = TabCompras.IDCompra) INNER JOIN tabPagtos ON TabCompras.IDCompra = tabPagtos.IDCompra " +
                        "WHERE tabPagtos.DTVencimento>#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.dtPagamento>=#" + datamin.Date.ToString("MM/dd/yyyy") + "# And TabContasAPagar.dtPagamento<=#" + datamax.Date.ToString("MM/dd/yyyy") + "# AND TabContasAPagar.FormaPagto='Cheques Terceiros' AND TabContasAPagar.pago=Yes AND TabContasAPagar.oculto=No";
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
        public DataTable ListarResumoPagar(DateTime datamin, DateTime datamax)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabContasAPagar.dtVencimento, Sum(TabContasAPagar.valorLancamento) AS SomaDevalorLancamento " +
                "FROM TabContasAPagar " +
                "GROUP BY TabContasAPagar.dtVencimento, TabContasAPagar.pago, TabContasAPagar.oculto " +
                "HAVING (((TabContasAPagar.dtVencimento)>=#" + datamin.Date + "# And (TabContasAPagar.dtVencimento)<=#" + datamax.Date + "#) AND ((TabContasAPagar.pago)=No) AND ((TabContasAPagar.oculto)=No)) " +
                "ORDER BY TabContasAPagar.dtVencimento";

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
        public DataTable ListarSaidas(Int32 idtreinamento)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                    "SELECT TabSaida.IDSaida, TabSaida.dtSaida, TabSaida.IDTreinamento, TabProdutos.nmProduto, TabSaida.Qtde, TabSaida.obs, TabProdutos.valoruni " +
                    "FROM TabSaida INNER JOIN TabProdutos ON TabSaida.IDProduto = TabProdutos.IDProduto " +
                    "WHERE TabSaida.IDTreinamento = " + idtreinamento + "  " +
                    "ORDER BY TabSaida.dtSaida, TabProdutos.nmProduto ";
                //"SELECT TabSaida.IDSaida, TabSaida.dtSaida, TabSaida.IDTreinamento, TabProdutos.nmProduto, TabSaida.Qtde, TabSaida.obs, Max(TabItemCompra.valorUnitario) AS MáxDevalorUnitario  " +
                //"FROM (TabSaida INNER JOIN TabProdutos ON TabSaida.IDProduto = TabProdutos.IDProduto) INNER JOIN TabItemCompra ON TabProdutos.IDProduto = TabItemCompra.IDProduto  " +
                //"GROUP BY TabSaida.IDSaida, TabSaida.dtSaida, TabSaida.IDTreinamento, TabProdutos.nmProduto, TabSaida.Qtde, TabSaida.obs " +
                //"HAVING (((TabSaida.IDTreinamento)=" + idtreinamento + ")) " +
                //"ORDER BY TabSaida.dtSaida, TabProdutos.nmProduto";

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
        public DataTable ListarSaidasEquipes(Int32 idequipe)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess =
                "SELECT TabSaida.IDEquipe, TabSaida.dtSaida, TabProdutos.nmProduto, TabSaida.Qtde, TabSaida.IDSaida, TabSaida.obs " +
                "FROM TabSaida INNER JOIN TabProdutos ON TabSaida.IDProduto = TabProdutos.IDProduto " +
                "WHERE TabSaida.IDEquipe=" + idequipe + " " +
                "ORDER BY TabSaida.dtSaida, TabProdutos.nmProduto";

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
        public DataTable ListarSaidasProduto(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "SELECT TabSaida.dtSaida, TabSaida.Qtde, TabTreinamentos.Descricao, TabEquipes.Equipe " +
                                   "FROM (TabSaida LEFT JOIN TabTreinamentos ON TabSaida.IDTreinamento = TabTreinamentos.IDTreinamento) LEFT JOIN TabEquipes ON TabSaida.IDEquipe = TabEquipes.IDEquipe " +
                                   "WHERE TabSaida.IDProduto=" + id + " AND TabSaida.Qtde >= 0 " +
                                   "ORDER BY TabSaida.dtSaida";


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
        public DataTable ListarRetornosProduto(Int32 id)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "SELECT TabSaida.dtSaida, TabSaida.Qtde, TabTreinamentos.Descricao, TabEquipes.Equipe " +
                                   "FROM (TabSaida LEFT JOIN TabTreinamentos ON TabSaida.IDTreinamento = TabTreinamentos.IDTreinamento) LEFT JOIN TabEquipes ON TabSaida.IDEquipe = TabEquipes.IDEquipe " +
                                   "WHERE TabSaida.IDProduto=" + id + " AND TabSaida.Qtde < 0 " +
                                   "ORDER BY TabSaida.dtSaida";


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
        public DataTable novaCompra(Int32 fornecedor, string Obs, DateTime dtentrega, DateTime dtcompra, Boolean particular)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "INSERT INTO TabCompras(IDFornecedor, Obs, dtEntrega, dtCompra, Particular) " +
                "VALUES (" + fornecedor.ToString() + ", '" + Obs.ToString() + "', #" + dtentrega.Date.ToString("MM/dd/yyyy") + "#, #" + dtcompra.ToString("MM/dd/yyyy HH:mm:ss") + "#, " + particular + ")";
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                sqlAccess = "SELECT TabCompras.IDCompra FROM TabCompras WHERE TabCompras.dtCompra=#" + dtcompra.ToString("MM/dd/yyyy HH:mm:ss") + "#";
                daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
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
        public DataTable novaCompraOK(Int32 fornecedor, string Obs, DateTime dtentrega, DateTime dtcompra)
        {
            if (!Connect())
                return null;
            try
            {
                DataTable retorno = new DataTable();
                string sqlAccess = "INSERT INTO TabCompras(IDFornecedor, Obs, dtEntrega, dtCompra, Recebido) " +
                "VALUES (" + fornecedor.ToString() + ", '" + Obs.ToString() + "', #" + dtentrega.Date.ToString("MM/dd/yyyy") + "#, #" + dtcompra.ToString("MM/dd/yyyy HH:mm:ss") + "#, True)";
                OleDbDataAdapter daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
                daAccess.Fill(retorno);

                sqlAccess = "SELECT TabCompras.IDCompra FROM TabCompras WHERE TabCompras.dtCompra=#" + dtcompra.ToString("MM/dd/yyyy HH:mm:ss") + "#";
                daAccess = new OleDbDataAdapter(sqlAccess, (OleDbConnection)conexao);
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
        public void novoFornecedorPlanilha(string nome)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabFornecedor (nmFornecedor, Planilha, excluir) " +
                "VALUES ('" + nome.ToString() + "', True, True) ";
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
        public void novoFornecedor(string nome, string item, string telefone, string email, string contato, string obs, Boolean centro, Boolean planilha)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tabFornecedor (nmFornecedor, item, telefoneFornecedor, emailFornecedor, contato, obs, CentroCusto, Planilha) " +
                "VALUES ('" + nome.ToString() + "', '" + item.ToString() + "', '" + telefone.ToString() + "', '" + email.ToString() + "', '" + contato.ToString() + "', '" + obs.ToString() + "', " + centro.ToString() + ", " + planilha.ToString() + ") ";
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
        public void novoProduto(string nome, string obs, Int32 idfornecedor, Int32 idclass)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabProdutos (IDFornecedor, IDClassFinanceira, nmProduto, obsProduto) " +
                "VALUES (" + idfornecedor.ToString() + ", " + idclass.ToString() + ", '" + nome.ToString() + "', '" + obs.ToString() + "')";
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
        public void novoProdutoClassificacao(string nome, string obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabProdutos (IDFornecedor, nmProduto, obsProduto, classFinanceira) " +
                "VALUES (64, '" + nome.ToString() + "', '" + obs.ToString() + "', true)";
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
        public void novoItemCompra(Int32 idcompra, Int32 idproduto, Int32 qtde, double vlUnitario)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabItemCompra (IDCompra, IDProduto, Qtde, valorUnitario) " +
                "VALUES (" + idcompra.ToString() + ", " + idproduto.ToString() + ", " + qtde.ToString() + ", " + vlUnitario.ToString().Replace(",", ".") + ")";
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
        public void novaSaida(Int32 idproduto, Int32 idtreinamento, Int32 idequipe, Int32 qtde, string obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabSaida (IDProduto, IDTreinamento, IDEquipe, Qtde, dtSaida, obs) " +
                "VALUES (" + idproduto.ToString() + ", " + idtreinamento.ToString() + ", " + idequipe.ToString() + ", " + qtde.ToString() + ", #" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#, '" + obs.ToString() + "')";
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
        public void novaParcelaFinanceiro(Int32 idcompra, Int32 idcentro, string formapagto, string obs, DateTime dtvencimento, double valorLancamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabContasAPagar (IDCompra, IDCentro, FormaPagto, Obs, dtVencimento, valorLancamento, oculto) " +
                "VALUES (" + idcompra.ToString() + ", " + idcentro.ToString() + ", '" + formapagto.ToString() + "', '" + obs.ToString() + "', #" + dtvencimento.Date.ToString("MM/dd/yyyy") + "#, " + valorLancamento.ToString().Replace(",", ".") + ", True)";
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
        public void novaParcelaFinanceiroOK(Int32 idcompra, string formapagto, Int32 centro, string obs, DateTime dtvencimento, double valorLancamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabContasAPagar (IDCompra, FormaPagto, IDCentro, Obs, dtVencimento, valorLancamento) " +
                "VALUES (" + idcompra.ToString() + ", '" + formapagto.ToString() + "', " + centro.ToString() + ", '" + obs.ToString() + "', #" + dtvencimento.Date.ToString("MM/dd/yyyy") + "#, " + valorLancamento.ToString().Replace(",", ".") + ")";
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
        public void novaParcelaFinanceiroTerceiro(Int32 idcompra, Int32 idcentro, string formapagto, DateTime dtvencimento, double valorLancamento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO TabContasAPagar (IDCompra, IDCentro, FormaPagto, dtVencimento, dtPagamento, valorLancamento, oculto, pago) " +
                "VALUES (" + idcompra.ToString() + ", " + idcentro.ToString() + ", '" + formapagto.ToString() + "', #" + dtvencimento.Date.ToString("MM/dd/yyyy") + "#, #" + dtvencimento.Date.ToString("MM/dd/yyyy") + "#, " + valorLancamento.ToString().Replace(",", ".") + ", False, True)";
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
        public void atualizarCompra(Int32 id, Int32 idfornecedor, DateTime dtentrega, string obs, Boolean particular)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabCompras Set IDFornecedor = " + idfornecedor.ToString() + ", dtEntrega = #" + dtentrega.Date.ToString("MM/dd/yyyy") + "#, Obs = '" + obs.ToString() + "', Particular = " + particular + " WHERE IDCompra = " + id;

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
        public void atualizarProdutoSemClassificacao()
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos SET TabProdutos.IDClassFinanceira = [TabProdutos].[IDProduto] WHERE(((TabProdutos.IDClassFinanceira)Is Null Or(TabProdutos.IDClassFinanceira) = 0) AND((TabProdutos.classFinanceira) = Yes))";

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
        public void alternarParticular(Int32 id, Boolean particular)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabCompras Set Particular = " + particular + " WHERE IDCompra = " + id;

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
        public void atualizarFornecedorCompra(Int32 id, Int32 idfornecedor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabCompras Set IDFornecedor = " + idfornecedor.ToString() + " WHERE IDCompra = " + id;

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
        public void atualizarFornecedor(Int32 id, string nome, string item, string telefone, string email, string contato, string obs, Boolean centro, Boolean excluir, Boolean planilha)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabFornecedor Set nmFornecedor = '" + nome.ToString() + "', item = '" + item.ToString() + "', telefoneFornecedor = '" + telefone.ToString() +
                    "', emailFornecedor = '" + email.ToString() + "', contato = '" + contato.ToString() + "', obs =  '" + obs.ToString() + "', CentroCusto=" + centro.ToString() + ", excluir=" + excluir.ToString() + ", Planilha=" + planilha.ToString() + " WHERE IDFornecedor = " + id;

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
        public void atualizarProduto(Int32 id, string nome, string obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set nmProduto = '" + nome.ToString() + "', obsProduto = '" + obs.ToString() + "' WHERE IDProduto = " + id;

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
        public void atualizarEntradaProduto(string nmproduto, Int32 qtde, double valor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set qtdeProduto = " + qtde.ToString() + ", valoruni = " + valor.ToString().Replace(",", ".") + " WHERE nmProduto = '" + nmproduto.ToString() + "'";

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
        public void atualizarSaidaProduto(string nmproduto, Int32 qtde)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos SET TabProdutos.qtdeProduto = [qtdeProduto]- " + qtde.ToString() + " WHERE nmProduto = '" + nmproduto.ToString() + "'";

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
        public void atualizarRetornoProduto(string nmproduto, Int32 qtde)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos SET TabProdutos.qtdeProduto = [qtdeProduto]+ " + qtde.ToString() + " WHERE nmProduto = '" + nmproduto.ToString() + "'";

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
        public void atualizarExibirFinanceiro(Int32 idpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set oculto = No WHERE IDContasPagar = " + idpagto.ToString();

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
        public void atualizarReceberCompra(Int32 idcompra)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabCompras Set Recebido = Yes WHERE IDCompra = " + idcompra.ToString();

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
        public void atualizarParcelaFinanceiro(Int32 idcontaspagar, DateTime dtvencimento, double valorparcela)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set dtVencimento = #" + dtvencimento.Date.ToString("MM/dd/yyyy") + "#, valorLancamento = " + valorparcela.ToString().Replace(",", ".") + " WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarPagarParcela(Int32 idcontaspagar, DateTime dtpagto, string formaPagto, double preco, string banco)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set dtPagamento = #" + dtpagto.Date.ToString("MM/dd/yyyy") + "#, pago = Yes, valorLancamento = " + preco.ToString().Replace(",", ".") + ", FormaPagto = '" + formaPagto.ToString() + "', Banco = '" + banco.ToString() + "'  WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarPagarDinheiro(Int32 idcontaspagar, DateTime dtpagto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set dtPagamento = #" + dtpagto.Date.ToString("MM/dd/yyyy") + "#, pago = Yes WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarCentroCustoParcela(Int32 idcontaspagar, Int32 idcentro)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set IDCentro = " + idcentro.ToString() + " WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarEstornarParcela(Int32 idcontaspagar)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set dtPagamento = null, pago = No WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarGerenciarProduto(Int32 id, Boolean gerenciar, Boolean excluir, Boolean classFinanceira)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set gerenciar = " + gerenciar + ", excluir = " + excluir + ", classFinanceira = " + classFinanceira + " WHERE IDProduto = " + id;

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
        public void atualizarGerenciarProdutoValor(Int32 id, Int32 qtde, double valor)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set qtdeProduto = " + qtde + ", valoruni = " + valor.ToString().Replace(",", ".") + " WHERE IDProduto = " + id;

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
        public void atualizarProdutosExcluidos(Int32 id, Boolean excluir)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set excluir = " + excluir + " WHERE IDProduto = " + id;

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
        public void removerCompra(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabCompras WHERE IDCompra = " + id.ToString();

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
        public void removerFornecedor(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabFornecedor WHERE IDFornecedor = " + id.ToString();

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
        public void removerProduto(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabProdutos WHERE IDProduto = " + id.ToString();

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
        public void removerItemCompra(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabItemCompra WHERE IDItemCompra = " + id.ToString();

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
        public void removerParcelaFinanceiro(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabContasAPagar WHERE IDContasPagar = " + id.ToString();

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
        public void atualizarParcelaFinanceiro(Int32 id, double valor, DateTime vencimento)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set dtVencimento = #" + vencimento.Date.ToString("MM/dd/yyyy") + "#, valorLancamento = " + valor + " WHERE IDContasPagar = " + id;

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
        public void removerSaida(Int32 id)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE FROM TabSaida WHERE IDSaida = " + id.ToString();

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
        public void atualizarValorParcela(Int32 idcompra, double vlDesconto)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar SET TabContasAPagar.valorLancamento = [valorLancamento]- " + vlDesconto.ToString().Replace(",", ".") + " WHERE IDCompra = " + idcompra.ToString() + " AND FormaPagto = 'Cheques Terceiros'";

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
        public DataTable ListarProdutosEstoqueFiltro(string nm)
        {
            if (!Connect())
                return null;

            try
            {
                DataTable retorno = new DataTable();

                string sqlAccess =
                    "SELECT TabProdutos.IDProduto, TabProdutos.nmProduto, TabProdutos.qtdeProduto  " +
                    "FROM TabProdutos  " +
                    "WHERE TabProdutos.gerenciar=Yes AND TabProdutos.excluir=No AND TabProdutos.nmProduto LIKE '%" + nm.ToString() + "%'  " +
                    "ORDER BY TabProdutos.nmProduto ";

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
        public void atualizarBanco(Int32 idcontaspagar, string banco, double parcela, string formaPagto, DateTime vencimento, Int32 idcentro, string obs)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabContasAPagar Set Banco = '" + banco.ToString() + "', valorLancamento = " + parcela.ToString().Replace(",", ".") + ", FormaPagto = '" + formaPagto.ToString() + "', dtVencimento = #" + vencimento.Date.ToString("MM/dd/yyyy") + "#, IDCentro = " + idcentro.ToString() + ", Obs = '" + obs.ToString() + "' WHERE IDContasPagar = " + idcontaspagar.ToString();

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
        public void atualizarFornecedorProduto(Int32 idproduto, Int32 idfornecedor, Int32 idclassificacao)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabProdutos Set IDFornecedor = " + idfornecedor.ToString() + ", IDClassFinanceira = " + idclassificacao.ToString() + " WHERE IDProduto = " + idproduto;

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
        public void atualizarItensCompras(Int32 id, Int32 qtde, double unitario)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "UPDATE TabItemCompra Set Qtde = " + qtde.ToString() + ", valorUnitario = " + unitario.ToString().Replace(",", ".") + " WHERE IDItemCompra = " + id;

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
        public void tempContasPagas(string classificacao, Int32 idcentro, double valoruni)
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "INSERT INTO tempContasPagas(classificacao, IDCentro, valorLancamento) " +
                "VALUES ('" + classificacao.ToString() + "', " + idcentro.ToString() + ", " + valoruni.ToString().Replace(",", ".") + ")";

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
        public void limparTempContasPagas()
        {
            if (!Connect())
                return;
            try
            {
                string sqlAccess = "DELETE * FROM tempContasPagas";

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
