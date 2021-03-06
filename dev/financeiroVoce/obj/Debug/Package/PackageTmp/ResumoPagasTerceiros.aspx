<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumoPagasTerceiros.aspx.cs"
    Inherits="financeiroVoce.ResumoPagasTerceiros" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resumo contas pagas com cheques de terceiros - Instituto Você</title>
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
                            <td width="700px" align="center">
                                <h1>
                                    Resumo de Contas Pagas com cheques de terceiros</h1>
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
                <h2>
                    Resumo por centro de custo</h2>
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
                <p style="color: Red;">
                    Total por centro de custo R$ <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <hr />
                <h2>
                    Detalhado</h2>
                <br />
                <asp:GridView ID="grdContasParticular" runat="server" AutoGenerateColumns="False"
                    Font-Size="12pt" OnRowDataBound="grdContasParticular_RowDataBound" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Pagamento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPagamento" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Centro de Custo" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblCentro" runat="server" Width="300px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblItem" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblObs" runat="server"></asp:Label>
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
                <p style="color: Red;">
                    Total detalhado R$
                    <asp:Label ID="lblTotalParticular" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <br />
                <h2>
                    Soma de cheques com vencimento no mês R$ <asp:Label ID="lblChequesMes" runat="server" ForeColor="Red"></asp:Label> 
                    e soma de cheques dos meses seguintes R$ <asp:Label ID="lblChequesFuturos" runat="server" ForeColor="Red"></asp:Label>,
                     totalizando R$ <asp:Label ID="lblChequesTotal" runat="server" ForeColor="Red"></asp:Label> 
                    </h2>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
