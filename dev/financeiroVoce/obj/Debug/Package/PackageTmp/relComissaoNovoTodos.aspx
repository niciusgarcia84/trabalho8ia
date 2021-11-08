<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relComissaoNovoTodos.aspx.cs"
    Inherits="financeiroVoce.relComissaoNovoTodos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório do Treinamento - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <center>
                <table border="0" width="100%">
                    <tr>
                        <td width="300px">
                            <img src="./images/logo.png" alt="logo" />
                        </td>
                        <td width="700px" align="center">
                            <h1>
                                Comissões</h1>
                        </td>
                        <td>
                            <a id="A2" href="relComissaoNovo.aspx">Voltar</a> - <a id="A1" href="Default.aspx">Menu
                                Principal</a>
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
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="150"></asp:Label>
                                <asp:HiddenField ID="hdnTreinamento" runat="server" Value='<%# Eval("Descricao") %>' />
                                <asp:HiddenField ID="hdnMais" runat="server" Value='<%# Eval("maisAutorizado") %>' />
                                <asp:HiddenField ID="hdnInvest" runat="server" Value='<%# Eval("Invest") %>' />
                                <asp:HiddenField ID="hdnCarta" runat="server" Value='<%# Eval("carta") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor Treinamento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValorInvestimento" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Pagto" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPagto" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Desconto Autorizado" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDesconto" Width="100" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dt Treinamento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDataTreinamento" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblMaiorForma" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dt Maior Pagamento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblMaiorData" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dias" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDias" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comissão" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblComissao" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descontar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDescontar" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Pagar" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Equipe") %>'></asp:Label>
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
                <br />
                <h1>
                    Treinandos sem lançamentos no financeiro</h1>
                <asp:GridView ID="grdSem" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdSem_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="400"></asp:Label>
                                <asp:HiddenField ID="hdnAusente" runat="server" Value='<%# Eval("ausente") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <br />
                <br />
                <asp:HiddenField ID="hdnTotal1" runat="server" />
                <asp:HiddenField ID="hdnDataTreinamento" runat="server" />
                <asp:Label ID="lblTotalTreinandosSem" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label><br />
                <br />
                <asp:Label ID="lblTotalGeral" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
