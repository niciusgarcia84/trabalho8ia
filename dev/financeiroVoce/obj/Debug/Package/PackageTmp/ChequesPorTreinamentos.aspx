<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChequesPorTreinamentos.aspx.cs"
    Inherits="financeiroVoce.ChequesPorTreinamentos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheques por Treinamentos - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <div style="width: 1100px;">
                    <center>
                        <table border="0">
                            <tr>
                                <td width="300px" align="left">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="500px" align="center">
                                    <h1>Recebimentos por Treinamentos</h1>
                                </td>
                                <td width="300px" align="right">
                                    <a id="A2" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <br />
                    <div id="divTreinamentos" runat="server">
                        Filtre os pagamento por treinamento selecionando ao lado
                    <asp:DropDownList ID="ddlTreinamento" runat="server" Width="180">
                    </asp:DropDownList>,
                        <asp:CheckBox ID="chkCheque" runat="server" Checked="true" />
                        exibir somente cheques
                    e ordene por
                    <asp:DropDownList ID="ddlOrdena" runat="server" Width="100">
                        <asp:ListItem Text="Treinando" Value="tabTreinando.Nome, tabPagtos.DTVencimento"></asp:ListItem>
                        <asp:ListItem Text="Vencimento" Value="tabPagtos.DTVencimento"></asp:ListItem>
                    </asp:DropDownList>
                        <asp:Button ID="btnSelecionar" runat="server" Text="Selecionar" OnClick="btnSelecionar_Click" />
                    </div>
                    <br />
                    <br />
                    <b>Lista de recebimentos</b> -
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnIDPagto" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Treinando" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>' Font-Size="X-Small"></asp:Label>
                                    <asp:HiddenField ID="hdnIDTreinando" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Responsavel" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>' Font-Size="X-Small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblEquipe" Text='<%# Eval("Equipe") %>' runat="server" Font-Size="X-Small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FormaPagto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormaPagto" Text='<%# Eval("FormaPagto") %>' runat="server" Font-Size="X-Small"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detalhes recebimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetalhes" runat="server" Font-Size="X-Small" Width="220px"></asp:Label>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
