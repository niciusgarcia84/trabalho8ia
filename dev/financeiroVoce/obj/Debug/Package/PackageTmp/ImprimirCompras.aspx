<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirCompras.aspx.cs"
    Inherits="financeiroVoce.ImprimirCompras" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compras - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <table border="0">
                <tr>
                    <td colspan="3">
                        <center>
                            <table border="0">
                                <tr>
                                    <td width="200px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="500px">
                                        <h1>
                                            Compra</h1>
                                    </td>
                                    <td>
                                        <a id="A1" href="Default.aspx">Menu Principal</a>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </td>
                </tr>
            </table>
            <hr />
            <div id="divCompras" runat="server">
                <asp:GridView ID="grdCompras" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdCompras_RowDataBound" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Fornecedor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFornecedor" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <h2>
                Dados da compra</h2>
            <table>
                <tr>
                    <td width="150px">
                        <b>Fornecedor</b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblFornecedor" runat="server" Width="360"></asp:Label>
                        <asp:HiddenField ID="hdnIDCompra" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Observações</b>
                    </td>
                    <td align="left">
                        <asp:Label ID="txtObsCompra" runat="server" Width="360" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Data Entrega</b>
                    </td>
                    <td align="left">
                        <asp:Label ID="txtDtEntregaCompra" runat="server" Width="100" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Total</b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTotalCompra" runat="server" Width="100" />
                    </td>
                </tr>
            </table>
            <hr />
            <div>
                <h2>
                    Itens na compra</h2>
                <asp:GridView ID="grdItemCompra" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdItemCompra_RowDataBound" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Produto">
                            <ItemTemplate>
                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' Width="180px"></asp:Label>
                                <asp:HiddenField ID="hdnIDItemCompra" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantidade" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantidade" runat="server" Text='<%# Eval("Qtde") %>' Width="70"></asp:Label>
                                <asp:HiddenField ID="hdnQtdeEstoque" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unitário" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblUnitario" runat="server" Width="70"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Width="70"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
            <hr />
            <div>
                <h2>
                    <asp:Label ID="lblResultadoFinanceiro" runat="server"></asp:Label></h2>
                <h2>
                    Parcelamento</h2>
                <asp:GridView ID="grdFinanceiro" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdFinanceiro_RowDataBound" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Forma Pagto">
                            <ItemTemplate>
                                <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                                <asp:HiddenField ID="hdnIDParcela" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Obs">
                            <ItemTemplate>
                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="300"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="txtVencimento" runat="server" Width="70"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="txtValorParcela" runat="server" Width="60"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <h2>
                    Cheques de Terceiros</h2>
                <asp:GridView ID="grdFinanceiroCheques" runat="server" AutoGenerateColumns="False"
                    Font-Size="10pt" OnRowDataBound="grdFinanceiroCheques_RowDataBound" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVencimento" runat="server" Width="70"></asp:Label>
                                <asp:HiddenField ID="hdnIDCheque" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responsável">
                            <ItemTemplate>
                                <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Banco">
                            <ItemTemplate>
                                <asp:Label ID="lblBanco" runat="server" Text='<%# Eval("cqBanco") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agência">
                            <ItemTemplate>
                                <asp:Label ID="lblAg" runat="server" Text='<%# Eval("cqAgencia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Conta">
                            <ItemTemplate>
                                <asp:Label ID="lblCC" runat="server" Text='<%# Eval("cqCC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Número">
                            <ItemTemplate>
                                <asp:Label ID="lblNumero" runat="server" Text='<%# Eval("cqNumero") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValor" runat="server" Width="60"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
