<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planilhas.aspx.cs" Inherits="financeiroVoce.Planilhas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Planilhas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function topo() {
            document.getElementById('inicio').focus();
            scroll(0, 0);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table border="0" id="inicio">
                    <tr>
                        <td colspan="2">
                            <center>
                            <table border="0">
                                <tr>
                                    <td>
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="800px" align="center">
                                        <h1>
                                            Planilhas</h1>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkExcluir" runat="server" OnClick="exibirExcluir" Text="Excluir"></asp:LinkButton>
                                        - <a id="A1" href="Default.aspx">Menu Principal</a>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        </td>
                    </tr>
                </table>
                <hr />
                <table>
                    <tr>
                        <td style="vertical-align: middle; width:700px;"><b>Nova conta</b>
                            <asp:TextBox ID="txtFornecedor" runat="server" Width="200" />
                            <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/excluirpq.png" />
                            <asp:ImageButton ID="btnInserir" runat="server" OnClick="btnInserir_Click" ImageUrl="~/images/maispq.png" /></td>
                        <td>
                            <asp:Label ID="lblPlanilha" runat="server" ForeColor="Red" Font-Bold="true" Width="500px"></asp:Label>
                            <asp:HiddenField ID="hdnPlanilha" runat="server" />
                            <asp:ImageButton ID="btnCancelar2" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/cancelar.png" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr valign="top">
                        <td width="500px" style="border-right-style: dotted; border-right-color: Gray;">
                            <div>
                                <hr />
                                <h2>Contas Cadastradas</h2>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Planilha">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>' Width="400"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDFornecedor" runat="server" Value='<%# Eval("IDFornecedor") %>' />
                                                <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" ImageUrl="~/images/alterar.jpg"
                                                    OnClientClick="javascript:topo();" />
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
                        </td>
                        <td style="padding-left: 10px; width: 400px; border-right-style: dotted; border-right-color: Gray;">
                            <h2>Saídas</h2>
                            <div id="divSaidas" runat="server" visible="false">
                                <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdProdutos_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Produto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor Unitário" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValor" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblData" runat="server"></asp:Label>
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
                        </td>
                        <td style="padding-left: 10px; width: 400px; border-right-style: dotted; border-right-color: Gray;">
                            <h2>Entradas</h2>
                            <div id="divEntradas" runat="server" visible="false">
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
