<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTipoTreinamento.aspx.cs" Inherits="financeiroVoce.CadastroTipoTreinamento" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Tipos de treinamentos - Instituto PNL</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td colspan="2">
                            <center>
                            <table border="0">
                                <tr>
                                    <td width="200px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="500px">
                                        <h1>
                                            Cadastro de Tipos de treinamentos</h1>
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
                        <td width="400px" style="border-right-style: dotted; border-right-color: Gray;">
                            <div>
                                <h2>Tipos Cadastrados</h2>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Descrição" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("Descricao") %>' Width="220"></asp:Label>
                                                <asp:HiddenField ID="hdnNome" Value='<%# Eval("Nome") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDTabela" Value='<%# Eval("IDTipo") %>' runat="server" />
                                                <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" ImageUrl="~/images/alterar.jpg" />
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
                                        <td>Descrição
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDescricao" runat="server" Width="200" />
                                            <asp:HiddenField ID="hdnIDTabelaAlterar" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nome
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNome" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
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
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
