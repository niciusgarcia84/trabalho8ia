<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relVendas.aspx.cs" Inherits="financeiroVoce.relVendas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Vendas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function topo() {
            document.getElementById('inicio').focus();
            scroll(0,0);
        }
    </script>

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
                        <td width="600px">
                            <h1>
                                <asp:Label ID="lblTitulo" runat="server" Text="Relatório de Vendas"></asp:Label></h1>
                        </td>
                        <td>
                            <a id="A1" href="Default.aspx">Menu Principal</a>
                        </td>
                    </tr>
                </table>
            </center>
            <hr />
            <div id="divLista" runat="server">
                <h1>
                    <asp:Label ID="lblTreinamento" runat="server"></asp:Label></h1>
                <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    CellPadding="3" OnRowDataBound="grdTreinandos_RowDataBound" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Treinamento">
                            <ItemTemplate>
                                <asp:Label ID="lblTreinamento" runat="server" Text='<%# Eval("Descricao") %>' Width="180"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="350"></asp:Label>
                                <asp:HiddenField ID="hdnInvestimento" runat="server" />
                                <asp:HiddenField ID="hdnInvest" runat="server" />
                                <asp:HiddenField ID="hdnAusente" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-Font-Size="Small">
                            <ItemTemplate>
                                <asp:Label ID="lblDetalhePagto" runat="server" Width="300" Text='<%# Eval("DetalhePagto") %>'></asp:Label>
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
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <br />
                <asp:Label ID="lblTotalTreinandos" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <h2>
                    Resumo Financeiro</h2>
                <asp:GridView ID="grdForma" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    CellPadding="3" OnRowDataBound="grdForma_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Forma Pagto">
                            <ItemTemplate>
                                <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>' Width="150"></asp:Label>
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
                <asp:Label ID="lblInvest" runat="server" ForeColor="Orange"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblTotalCredito" runat="server" ForeColor="Blue"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
