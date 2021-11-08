<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTreinamentos.aspx.cs"
    Inherits="financeiroVoce.CadastroTreinamentos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Treinamentos - Instituto PNL</title>
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
                                        <td width="500px" align="center">
                                            <h1>Cadastro de Treinamentos</h1>
                                        </td>
                                        <td>
                                            <a id="A2" href="CadastroTabela.aspx">Tabela de Valores</a> - 
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
                                <h2>Treinamentos Cadastrados</h2>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Descricao" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Descricao") %>' Width="200"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Investimento" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTelefone" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDEquipe" runat="server" />
                                                <asp:HiddenField ID="hdnExperiente" runat="server" Value='<%# Eval("vlExperiente") %>' />
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
                                        <td>Descricao
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEquipe" runat="server" Width="200" />
                                            <asp:HiddenField ID="hdnIDEqp" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Data Treinamento
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObs" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento à vista
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTelefone" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 6x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInvest2" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 8x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInvest3" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento 10x
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInvest4" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--Diamond Experiente--%>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtVlExperiente" runat="server" Width="200" Text="0" Visible="false" />
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
                                <hr />
                                <p>
                                    <b>Carregar Valores</b>
                                </p>
                                Selecione o tipo do treinamento
                            <asp:DropDownList ID="ddlTipo" runat="server" Width="200">
                            </asp:DropDownList>
                                , confirme se a ANO do treinamento foi preenchido corretamente e
                            <asp:LinkButton ID="lnkCarregarValores" runat="server" OnClick="lnkCarregarValores_OnClick"
                                Text="clique aqui para carregar os valores cadastrados."></asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
