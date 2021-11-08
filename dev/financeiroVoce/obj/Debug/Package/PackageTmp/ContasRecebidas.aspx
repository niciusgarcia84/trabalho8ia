<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContasRecebidas.aspx.cs"
    Inherits="financeiroVoce.ContasRecebidas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contas Recebidas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div style="width: 1200px;">
                <center>
                    <table border="0">
                        <tr>
                            <td width="200px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="800px" align="center">
                                <h1>
                                    Contas Recebidas</h1>
                            </td>
                            <td width="350px">
                                <a id="A2" href="Default.aspx">Menu Principal</a>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <br />
                A lista abaixo está exibindo os recebimentos entre
                <asp:TextBox ID="txtDatamin" runat="server" Width="70"></asp:TextBox>
                e
                <asp:TextBox ID="txtDatamax" runat="server" Width="70"></asp:TextBox>
                e status
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Text="Todos" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Terceiros" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Todos" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Boleto" Value="Boleto"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Cheque" Value="Cheque"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Cartão" Value="Cartão"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Depósito" Value="Depósito"></asp:ListItem>
                    <asp:ListItem Text="Recebidos - Dinheiro" Value="Dinheiro"></asp:ListItem>
                </asp:DropDownList>
                -
                <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
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
                        <asp:TemplateField HeaderText="Recebimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblRecebimento" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIDPagto" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="status" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Font-Size="X-Small"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Forma">
                            <ItemTemplate>
                                <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Banco / Fornecedor" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Label ID="lblBanco" Text='<%# Eval("Banco") %>' runat="server" Width="80px"
                                    Font-Size="X-Small"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Treinando" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>' Width="120px"
                                    Font-Size="X-Small"></asp:Label>
                                <asp:HiddenField ID="hdnIDTreinando" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responsavel" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>' Width="120px"
                                    Font-Size="X-Small"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Treinamento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTreinamento" Text='<%# Eval("Descricao") %>' runat="server" Width="120px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalhes recebimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDetalhes" runat="server" Font-Size="X-Small" Width="150px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEstornar" runat="server" OnClick="btnEstornar_Click" Text="estornar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDevolver" runat="server" OnClick="btnDevolver_Click" Text="&nbsp;&nbsp;devolver"
                                    Visible="false" />
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
