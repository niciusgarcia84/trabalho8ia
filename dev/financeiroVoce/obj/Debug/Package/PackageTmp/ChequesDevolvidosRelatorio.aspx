<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChequesDevolvidosRelatorio.aspx.cs"
    Inherits="financeiroVoce.ChequesDevolvidosRelatorio" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheques Devolvidos - Instituto Você</title>
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
                            <td width="200px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="500px" align="center">
                                <h1>
                                    Cheques devolvidos no Período</h1>
                            </td>
                            <td width="200px" valign="middle" align="right">
                                <a id="A2" href="Default.aspx">Menu Principal</a>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <br />
                A lista abaixo está exibindo os cheques devolvidos entre
                <asp:TextBox ID="txtDatamin" runat="server" Width="70"></asp:TextBox>
                e
                <asp:TextBox ID="txtDatamax" runat="server" Width="70"></asp:TextBox>
                <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                <br />
                <br />
                <b>Lista de cheques</b> -
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField HeaderText="Devolvido em" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblData" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                                <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>' Width="120px"
                                    Font-Size="X-Small"></asp:Label>
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
                                <asp:Label ID="lblTreinamento" Text='<%# Eval("Descricao") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalhes recebimento" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblDetalhes" runat="server" Font-Size="Small" Width="300px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Destino" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlDestino" runat="server" Width="100">
                                    <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Patrícia" Value="patricia"></asp:ListItem>
                                    <asp:ListItem Text="Francine" Value="fran"></asp:ListItem>
                                    <asp:ListItem Text="Teresa" Value="teresa"></asp:ListItem>
                                    <asp:ListItem Text="Dr. Felipe" Value="drFelipe"></asp:ListItem>
                                    <asp:ListItem Text="Dra. Graça" Value="drGraca"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="btnSalvarDestino" runat="server" OnClick="btnSalvarDestino_Click"
                                    ImageUrl="~/images/salvar.jpg" />
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
