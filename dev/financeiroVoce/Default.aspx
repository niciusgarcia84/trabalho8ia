<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="financeiroVoce._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Financeiro - Instituto PNL</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0px auto; padding: 15px; width: 900px; text-align: center; font-size: 16pt;">
            <center>
                <div id="validar" runat="server">
                    <img src="./images/logo.png" alt="logo" />
                    <br />
                    <br />
                    <table border="0" width="300px">
                        <tr>
                            <td>Usuário
                            </td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server" MaxLength="49" Width="240px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Senha
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" runat="server" MaxLength="49" TextMode="Password" Width="240px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="btnOk" runat="server" Text="Entrar" OnClick="btnOk_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div runat="server" id="cadastros">
                    <div id="divUsuario" runat="server">
                        <table>
                            <tr>
                                <td width="400px">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="100px">
                                    <asp:LinkButton ID="lnkSair" runat="server" Text="Sair" OnClick="lnkSair_OnClick"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <table border="0">
                        <tr>
                            <td width="250px" style="border-right-color: Gray; border-right-style: dotted; border-left-color: Gray; border-left-style: dotted;"
                                valign="top" align="center">
                                <h1>Cadastros</h1>
                                <br />
                                <asp:LinkButton ID="lnkTreinandos" runat="server" PostBackUrl="~/CadastroTreinandos.aspx"
                                    Text="Treinandos"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkTreinamentos" runat="server" PostBackUrl="~/CadastroTreinamentos.aspx"
                                    Text="Treinamentos"></asp:LinkButton>
                                <br />
                                <br />
                            </td>
                            <td width="250px" valign="top" align="center" style="border-right-color: Gray; border-right-style: dotted;">
                                <div runat="server" id="relatorios">
                                    <h1>Relatórios</h1>
                                    <br />
                                    <asp:LinkButton ID="lnkRelTreinamento" runat="server" PostBackUrl="~/montarDiamond.aspx"
                                        Text="Montar Equipes I.A."></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/equipesDiamonds.aspx"
                                        Text="Exibir Equipes"></asp:LinkButton>
                                    <br />
                                    <br />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </div>
    </form>
</body>
</html>
