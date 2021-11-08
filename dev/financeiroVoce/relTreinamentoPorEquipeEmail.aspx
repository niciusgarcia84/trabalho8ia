<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relTreinamentoPorEquipeEmail.aspx.cs" Inherits="financeiroVoce.relTreinamentoPorEquipeEmail" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="refresh" content="10" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Relatório de treinandos por Equipe - Instituto PNL</title>
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
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <hr />
                <div id="divLista" runat="server">
                    <table>
                        <tr>
                            <td>
                                <h1>Enviando e-mails, aguarde por favor!!! <br />
                                    <asp:Label ID="lblTreinamento" runat="server"></asp:Label> - <asp:Label ID="lblEquipe" Text="0" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <div id="divEmail" runat="server" visible="false">
                                    <asp:ImageButton ID="imgEmail" runat="server" ImageUrl="~/images/email.png" OnClick="btnImprimir_Click" />
                                    <asp:LinkButton ID="lnkEnviar" runat="server" Text="Enviar e-mails" OnClick="btnImprimir_Click"></asp:LinkButton>
                                    <asp:HiddenField ID="hdnEmail" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <asp:GridView ID="grdEquipe" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdEquipe_RowDataBound" BackColor="White"
                        BorderColor="#FFFFFF" BorderStyle="None" BorderWidth="0px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:Label ID="lblEquipe" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnEquipe" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <hr />
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
