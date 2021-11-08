<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroClassificacaoFinanceira.aspx.cs" Inherits="financeiroVoce.CadastroClassificacaoFinanceira" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Classificações Financeiras - Instituto Você</title>
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
                <div style="width: 1100px;">
                    <center>
                        <table border="0" id="inicio">
                            <tr>
                                <td width="200px">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="500px" align="center">
                                    <h1>Cadastro de Classificação Financeira</h1>
                                </td>
                                <td width="400px">
                                    <asp:LinkButton ID="lnkNovoProduto" runat="server" OnClick="exibirNovoProduto" Text="Adicionar - "></asp:LinkButton>
                                    <a href="CadastroProdutosExcluidos.aspx">Excluídos</a> - <a id="A2" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                        <div id="divNovo" runat="server" visible="false">
                            <h2>
                                <b>
                                    <asp:Label ID="lblTituloProduto" runat="server" Text="Novo Produto" /></b></h2>
                            <table>
                                <tr>
                                    <td>Descrição
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtnmProduto" runat="server" Width="300" />
                                        <asp:HiddenField ID="hdnEditar" runat="server" />
                                    </td>
                                    <td rowspan="3">
                                        <asp:ImageButton ID="btnNovoProduto" runat="server" OnClick="btnInserirProduto_Click"
                                            ImageUrl="~/images/ok.png" />
                                        <asp:ImageButton ID="ImageButton5" runat="server" OnClick="btnCancelarProduto_Click"
                                            ImageUrl="~/images/cancelar.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Observações
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtobsProduto" runat="server" Width="300" />
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </div>
                        <div id="divCadastro" runat="server" visible="true">
                            <br />
                            <asp:GridView ID="grdCadastro" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                OnRowDataBound="grdCadastro_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduto" runat="server" Width="300px" Text='<%# Eval("nmProduto") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnIDProduto" runat="server" Value='<%# Eval("IDProduto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblObs" runat="server" Text='<%# Eval("obsProduto") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterarProduto_Click"
                                                ImageUrl="~/images/alterar.jpg" OnClientClick="javascript:topo();" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Excluir" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkExcluir" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class. Financeira" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkClassFinanceira" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Salvar Opções" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnSalvar" runat="server" OnClick="btnSalvarOpcoes_Click"
                                                ImageUrl="~/images/salvar.jpg" />
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
