<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resumoFinanceiro.aspx.cs"
    Inherits="financeiroVoce.resumoFinanceiro" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Faturamento - Instituto Você</title>
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
                        <td width="500px">
                            <h1>
                                Relatório de Faturamento</h1>
                        </td>
                        <td>
                            <a id="A1" href="Default.aspx">Menu Principal</a>
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
            <b>O relatório abaixo está entre</b>
            <asp:TextBox ID="txtDatamin" runat="server" Width="100"></asp:TextBox>
            e
            <asp:TextBox ID="txtDatamax" runat="server" Width="100"></asp:TextBox>
            <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar Data" OnClick="btnBuscar_Click" />
            <br />            
            <hr />
            <br />
            <h2>
                    Treinamentos no período</h2>
            <div id="divLista" runat="server">
                <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="14pt"
                    CellPadding="3" OnRowDataBound="grdTreinandos_RowDataBound" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Treinamento">
                            <ItemTemplate>
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Descricao") %>' Width="200"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPagto" runat="server"></asp:Label>
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
                <hr />
                <br />
                <h2>
                    Resumo por Forma de Pagto</h2>
                <asp:GridView ID="grdForma" runat="server" AutoGenerateColumns="False" Font-Size="14pt"
                    CellPadding="3" OnRowDataBound="grdForma_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Forma Pagto">
                            <ItemTemplate>
                                <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>' Width="200"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Soma" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSoma" runat="server"></asp:Label>
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
                <asp:Label ID="lblTotalValor" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                <br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
