<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estoque.aspx.cs" Inherits="financeiroVoce.Estoque" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Estoque - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div style="width: 900px;">
                <center>
                    <table border="0">
                        <tr>
                            <td width="200px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="500px" align="center">
                                <h1>
                                    Estoque</h1>
                            </td>
                            <td width="400px">
                                <a href="EstoqueGerenciar.aspx">Gerenciar Produtos</a> - <a id="A2" href="Default.aspx">
                                    Menu Principal</a>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <b>Quantidades em Estoque</b>
                    <br />
                    <br />
                    Filtre a lista de produtos por palavra digitando ao lado
                    <asp:TextBox ID="nmFiltro" runat="server" Width="100px"></asp:TextBox>
                    <asp:LinkButton ID="lnkFiltro" runat="server" Text="Filtrar" OnClick="lnkFiltro_OnClick"></asp:LinkButton>
                    -
                    <asp:LinkButton ID="lnkFiltroLimpar" runat="server" Text="Limpar" OnClick="lnkFiltroLimpar_OnClick"></asp:LinkButton>
                    <br />
                    <br />
                    <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduto" runat="server" Width="300px" Text='<%# Eval("nmProduto") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnIDProduto" runat="server" Value='<%# Eval("IDProduto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qtde" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantidade" runat="server" Width="100px" Text='<%# Eval("qtdeProduto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkImprimir" runat="server" Text="histórico" OnClick="lnkImprimir_OnClick"></asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
