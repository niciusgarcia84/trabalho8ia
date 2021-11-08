<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesFinanceirosTreinamento.aspx.cs" Inherits="financeiroVoce.DetalhesFinanceirosTreinamento" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Detalhes Financeiros do Treinamento</title>
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
                                            Recebimentos detalhados</h1>
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
                <div>
                    <h2>Recebimentos Detalhados</h2>
                    Filtre por forma de pagamento
                    <asp:DropDownList ID="ddlFormaPagto" runat="server" Width="170">
                        <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                        <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                        <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                        <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                        <asp:ListItem Text="Crédito" Value="Crédito"></asp:ListItem>
                        <asp:ListItem Text="Crédito Cheque" Value="CréditoCheque"></asp:ListItem>
                        <asp:ListItem Text="Crédito mesmo treinamento" Value="CréditoMesmo"></asp:ListItem>
                        <asp:ListItem Text="Crédito mesmo Cheque" Value="CréditoMesmoCheque"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton ID="lnkSelecionarFormaPagto" runat="server" Text="Filtrar" OnClick="lnkSelecionarFormaPagto_OnClick"></asp:LinkButton>
                    <br />
                    <hr />
                    <asp:GridView ID="grdItemCompra" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        OnRowDataBound="grdItemCompra_RowDataBound" CellPadding="4" ForeColor="#333333"
                        GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Treinando">
                                <ItemTemplate>
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVencimento" runat="server" Width="70"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblValor" runat="server" Width="70"></asp:Label>
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
                    <asp:Label ID="lblTotalValor2" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
                <hr />
                <div runat="server" id="divResumo">
                    <h2>Resumo Financeiro</h2>
                    <asp:GridView ID="grdForma" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdForma_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Forma Pagto">
                                <ItemTemplate>
                                    <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Soma" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoma" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <br />
                    <asp:Label ID="lblTotalValor" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
                <hr />
                <div>
                    <h2>Descontos e/ou pagamamento de outros treinandos juntos</h2>
                    <asp:GridView ID="grdDescontos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdDescontos_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desconto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoma" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Obs">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="150" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Créditos">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblCredito" runat="server" Text='<%# Eval("Credito") %>' Width="550" TextMode="MultiLine" Height="60"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <br /><br />
                    <asp:Label ID="lblTotalDescontos" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
