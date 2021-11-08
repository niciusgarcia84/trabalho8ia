<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="localizarCheque.aspx.cs"
    Inherits="financeiroVoce.localizarCheque" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Localizar Cheques - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <table border="0">
                <tr>
                    <td colspan="4">
                        <center>
                            <table border="0">
                                <tr>
                                    <td width="200px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="500px">
                                        <h1>
                                            Localizar Cheque</h1>
                                    </td>
                                    <td>
                                        <a id="A1" href="Default.aspx">Menu Principal</a>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <hr />
                    </td>
                </tr>
                <tr valign="top">
                    <td style="padding-right: 10px;">
                        <br />
                        <table>
                            <tr>
                                <td>
                                    Informe uma parte do nome do RESPONSÁVEL
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNmResponsavel" runat="server" Width="150"></asp:TextBox>
                                    <asp:Button ID="btnFiltrar" runat="server" Text="buscar" OnClick="btnFiltrar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>ou </b>Informe uma parte do nome do TREINANDO
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNmTreinando" runat="server" Width="150"></asp:TextBox>
                                    <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="buscar" OnClick="btnFiltrarTreinamento_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <h2>
                            <asp:Label ID="lblTituloSelecionado" runat="server"></asp:Label></h2>
                        <br />
                        <br />
                        <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                            OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Responsavel" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>' Width="120px"
                                            Font-Size="X-Small"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Treinando" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>' Width="120px"
                                            Font-Size="X-Small"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                                        <asp:HiddenField ID="hdnIDPagto" runat="server" />
                                        <asp:HiddenField ID="hdnIDTreinando" runat="server" />
                                        <asp:HiddenField ID="hdnIDCompra" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data Recebimento" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecebido" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Treinamento" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTreinamento" Text='<%# Eval("Descricao") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEquipe" Text='<%# Eval("Equipe") %>' runat="server" Width="120px"
                                            Font-Size="X-Small"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalhes cheque" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetalhes" runat="server" Font-Size="X-Small" Width="150px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Destino" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDestino" runat="server" Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDevolver" runat="server" Visible="false" OnClick="btnDevolver_Click"
                                            Text="&nbsp;&nbsp;devolver"></asp:LinkButton>
                                        <asp:LinkButton ID="btnPendente" runat="server" Visible="false" OnClick="btnPendente_Click"
                                            Text="&nbsp;tornar pendente"></asp:LinkButton>
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
