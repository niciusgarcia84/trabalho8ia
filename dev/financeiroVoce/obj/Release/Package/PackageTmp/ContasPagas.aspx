<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContasPagas.aspx.cs" Inherits="financeiroVoce.ContasPagas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contas Pagas - Instituto Você</title>
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
                                <td width="900px" align="center">
                                    <h1>Contas Pagas</h1>
                                </td>
                                <td width="400px">
                                    <asp:LinkButton ID="lnkResumo" runat="server" OnClick="abrirResumo_OnClick" Text="Resumo"></asp:LinkButton> 
                                     - <a id="A2" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <br />
                    Pagamentos entre
                <asp:TextBox ID="txtDatamin" runat="server" Width="80"></asp:TextBox>
                    e
                <asp:TextBox ID="txtDatamax" runat="server" Width="80"></asp:TextBox>
                    <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFiltro" runat="server" Text="Visualizar Filtros" OnClick="btnFiltro_Click" />
                    <div runat="server" id="divFiltros" visible="false">
                        <hr />
                        <table>
                            <tr>
                                <td>Fornecedor</td>
                                <td width="200px">
                                    <asp:TextBox runat="server" ID="txtFornecedorPesquisa" Width="150px"></asp:TextBox></td>
                                <td>Classificação Financeira</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtClassFinanceira" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Tipo</td>
                                <td>
                                    <asp:DropDownList ID="ddlFormaFiltro" runat="server" Width="150">
                                        <asp:ListItem Text="todos" Value="todos"></asp:ListItem>
                                        <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                        <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                                        <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                                        <asp:ListItem Text="Transferência" Value="Transferência"></asp:ListItem>
                                        <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                                        <asp:ListItem Text="Cheques Terceiros" Value="Cheques Terceiros"></asp:ListItem>                                        
                                    </asp:DropDownList></td>
                                <td>Centro Custo</td>
                                <td>
                                    <asp:DropDownList ID="ddlCentroFiltro" runat="server" Width="155">
                                        <asp:ListItem Text="todos" Value="todos"></asp:ListItem>
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Contabilidade" Value="contabilidade"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Banco</td>
                                <td>
                                    <asp:DropDownList ID="ddlBancoFiltro" runat="server" Width="150">
                                        <asp:ListItem Text="todos" Value="todos"></asp:ListItem>
                                        <asp:ListItem Text="Itaú" Value="Itaú"></asp:ListItem>
                                        <asp:ListItem Text="Bradesco" Value="Bradesco"></asp:ListItem>
                                        <asp:ListItem Text="Vila Maria Bradesco" Value="BradescoVM"></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td align="right"><asp:Button ID="btnFiltroLimpar" runat="server" Text="Limpar Filtros" OnClick="btnFiltroLimpar_Click" /></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <hr />
                    <br />
                    <b>Lista de pagamento</b> -
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Data do Pagamento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtPagto" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnIDContasPagar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fornecedor">
                                <ItemTemplate>
                                    <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("PrimeiroDenmProduto") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Classificação" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblClassificacao" runat="server" Text='<%# Eval("classificacao") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro Custo" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblCentro" runat="server" Text='<%# Eval("CentroCusto") %>' Width="150"></asp:Label>
                                    <asp:DropDownList ID="ddlCentro" runat="server" Width="80" Visible="false">
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="lnkTrocar" runat="server" OnClick="lnkTrocar_Click" Text="salvar" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBanco" runat="server" Text='<%# Eval("Banco") %>' Width="100"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEstornar" runat="server" OnClick="btnEstornar_Click" Text="estornar" Visible="false" />
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
