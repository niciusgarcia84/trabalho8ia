<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumoAPagar.aspx.cs" Inherits="financeiroVoce.ResumoAPagar" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resumo de Contas Pagas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div style="width: 900px;">
                <center>
                    <table border="0">
                        <tr>
                            <td width="200px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="500px" align="center">
                                <h1>
                                    Resumo de Contas Pagas</h1>
                            </td>
                            <td width="300px">
                                <a id="A2" href="Default.aspx">Menu Principal</a>
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
                <br />
                <h2>1234 Você</h2>
                <br />
                <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="12pt"
                    OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Centro de Custo" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCentro" runat="server" Width="300px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValorParcela" runat="server" Width="150px"></asp:Label>
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
                <br />
                <p style="color:Red;">
                Total Pago R$<asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <hr />
                <h2>Particular</h2>
                <br />
                <asp:GridView ID="grdContasParticular" runat="server" AutoGenerateColumns="False"
                    Font-Size="12pt" OnRowDataBound="grdContasParticular_RowDataBound" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Centro de Custo" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCentro" runat="server" Width="300px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValorParcela" runat="server" Width="150px"></asp:Label>
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
                <p style="color:Red;">
                Total Pago R$
                <asp:Label ID="lblTotalParticular" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <br />
                <h2>Total Pago no período R$
                <asp:Label ID="lblGeral" runat="server" ForeColor="Red"></asp:Label></h2>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
