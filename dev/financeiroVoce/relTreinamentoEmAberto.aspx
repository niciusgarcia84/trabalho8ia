<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relTreinamentoEmAberto.aspx.cs" Inherits="financeiroVoce.relTreinamentoEmAberto" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de treinandos com financeiro em aberto - Instituto PNL</title>
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
                                <h1>Financeiro em Aberto</h1>
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
                    <h1>
                        <asp:Label ID="lblTreinamento" runat="server"></asp:Label></h1>
                    <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdTreinandos_RowDataBound" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgFechado" ImageUrl="~/images/cadFechadoMini.png"
                                        Visible="false" />
                                    <asp:ImageButton runat="server" ID="imgAberto" ImageUrl="~/images/cadAbertoMini.png"
                                        Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="250"></asp:Label>
                                    <asp:HiddenField ID="hdnInvestimento" runat="server" />
                                    <asp:HiddenField ID="hdnInvest" runat="server" />
                                    <asp:HiddenField ID="hdnAusente" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-Font-Size="X-Small">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetalhePagto" runat="server" Width="200" Text='<%# Eval("DetalhePagto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPagto" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desconto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesconto" Width="100" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crédito/Obs">
                                <ItemTemplate>
                                    <asp:Label ID="lblObs" runat="server" Font-Size="Smaller" Text='<%# Eval("Credito") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblEquipe" runat="server" Width="75" Text='<%# Eval("Equipe") %>'
                                        Font-Size="Smaller"></asp:Label>
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
