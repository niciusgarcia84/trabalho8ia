<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroFornecedores.aspx.cs"
    Inherits="financeiroVoce.CadastroFornecedores" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fornecedores - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function topo() {
            document.getElementById('inicio').focus();
            scroll(0,0);
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
                                    <td width="200px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="500px" align="center">
                                        <h1>
                                            Cadastro de Fornecedores</h1>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkExcluir" runat="server" OnClick="exibirExcluir" Text="Excluir"></asp:LinkButton>
                                        - <a id="A1" href="Default.aspx">Menu Principal</a>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                    </td>
                </tr>
                <tr valign="top">
                    <td width="600px" style="border-right-style: dotted; border-right-color: Gray;">
                        <div>
                            <h2>
                                Fornecedores cadastrados</h2>
                            <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Equipe">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>' Width="200"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem" runat="server" Text='<%# Eval("item") %>' Width="150"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Telefone" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("telefoneFornecedor") %>'
                                                Width="100"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alterar">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDFornecedor" runat="server" />
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
                    <td style="padding-left: 10px;">
                        <div id="divCadastrar" runat="server">
                            <h2>
                                <b>
                                    <asp:Label ID="lblTitulo" runat="server" Text="Inserir" /></b></h2>
                            <table>
                                <tr>
                                    <td>
                                        Fornecedor
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFornecedor" runat="server" Width="300" />
                                        <asp:HiddenField ID="hdnIDForn" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Item
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtItem" runat="server" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Telefone
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtTelefone" runat="server" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        E-mail
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contato
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtContato" runat="server" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Informações
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtObs" runat="server" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Centro de Custo
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkCentro" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Planilha
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkPlanilha" runat="server" /> Permitir utilizar planilha?
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Excluir
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkExcluir" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="btnInserir" runat="server" OnClick="btnInserir_Click" ImageUrl="~/images/ok.png" />
                                        <asp:ImageButton ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" ImageUrl="~/images/ok.png"
                                            Visible="false" />
                                        <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/cancelar.png"
                                            Visible="false" />
                                        <asp:ImageButton ID="btnOcultar" runat="server" OnClick="btnOcultar_Click" ImageUrl="~/images/excluir.png"
                                            Visible="false" />
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <asp:LinkButton ID="lnkCarregar" runat="server" Text="clique aqui para visualizar o histórico de produtos."
                                OnClick="lnkCarregar_OnClick" Visible="false"></asp:LinkButton>
                            <div id="divHistorico" runat="server" visible="false">
                                <h2>
                                    Histórico de produtos comprados por data</h2>
                                Início <asp:TextBox ID="txtDTInicio" runat="server" Width="80px"></asp:TextBox>
                                Fim <asp:TextBox ID="txtDTFim" runat="server" Width="80px"></asp:TextBox>
                                <asp:LinkButton ID="lnkFiltrar" runat="server" OnClick="lnkFiltrar_OnClick" Text="Filtrar"></asp:LinkButton><br /><br />
                                <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdProdutos_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Produto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Maior Valor Pago" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValor" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qtde Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtde" runat="server"></asp:Label>
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
