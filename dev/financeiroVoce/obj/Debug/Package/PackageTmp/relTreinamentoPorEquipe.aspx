<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relTreinamentoPorEquipe.aspx.cs" Inherits="financeiroVoce.relTreinamentoPorEquipe" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Relatório de treinandos por Equipe - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <center>
                    <table border="0" width="100%" id="inicio">
                        <tr>
                            <td width="300px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="500px" align="center">
                                <h1>Treinandos por Equipe</h1>
                                <div id="divMenuOpcoes" runat="server" style="text-align: center;">
                                    Últimos 20 treinamentos
                                <asp:DropDownList ID="ddlTreinamento" runat="server" Width="155" />
                                    <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="Carregar" OnClick="btnSelecionarTreinamento_Click" />
                                    <br />
                                    Selecione a equipe
                                    <asp:DropDownList ID="ddlEquipe" runat="server" Width="155" />
                                    <asp:Button ID="Button1" runat="server" Text="Carregar" OnClick="btnFiltrarTreinamento_Click" />
                                </div>
                            </td>
                            <td>
                                <a id="A1" href="Default.aspx">Menu Principal</a>
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <div id="divLista" runat="server" visible="false">
                    <table>
                        <tr>
                            <td width="400px">
                                <h1>
                                    <asp:Label ID="lblTreinamento" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <div id="divEmail" runat="server">
                                    <asp:ImageButton ID="imgEmail" runat="server" ImageUrl="~/images/email.png" OnClick="btnImprimir_Click" />
                                    <asp:LinkButton ID="lnkEnviar" runat="server" Text="Enviar e-mails" OnClick="btnImprimir_Click"></asp:LinkButton>
                                    <asp:HiddenField ID="hdnEmail" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>

                    <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdTreinandos_RowDataBound" BackColor="White"
                        BorderColor="#FFFFFF" BorderStyle="None" BorderWidth="0px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:Label ID="lblNome" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnInvestimento" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblEquipe" runat="server" Font-Size="Smaller"></asp:Label>
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
                    <asp:Label ID="lblTotalTreinandos" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
