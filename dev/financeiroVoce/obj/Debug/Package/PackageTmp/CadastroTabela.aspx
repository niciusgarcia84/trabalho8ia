<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTabela.aspx.cs"
    Inherits="financeiroVoce.CadastroTabela" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tabela de Preços - Instituto Você</title>
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
                                            <h1>Tabela de Valores e Retornos</h1>
                                        </td>
                                        <td>
                                            <a id="A1" href="CadastroTipoTreinamento.aspx">Cadastro de Tipos</a> - 
                                            <asp:LinkButton ID="lnkExcluir" runat="server" OnClick="exibirExcluir" Text="Excluir"></asp:LinkButton>
                                            - <a id="A1" href="CadastroTreinamentos.aspx">Voltar</a>
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
                                <h2>Treinamentos Cadastrados</h2>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Ano" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAno" runat="server" Text='<%# Eval("Ano") %>' Width="80"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descrição" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="220"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDTabela" Value='<%# Eval("IDTabela") %>' runat="server" />
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
                                            <asp:DropDownList ID="ddlTipo" runat="server" Width="200">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdnIDTabelaAlterar" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ano
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAno" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento à vista
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtV1" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 6x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtV2" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 8x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtV3" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtV4" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno cheque à vista
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtR1" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno cheque 6x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtR2" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno cheque 8x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtR3" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno cheque 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtR4" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno cheque acima 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtR5" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno à vista
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRo1" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno 6x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRo2" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno 8x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRo3" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRo4" runat="server" Width="200" Text="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Retorno acima 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRo5" runat="server" Width="200" Text="0" />
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
