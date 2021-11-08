<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContasAPagar.aspx.cs" Inherits="financeiroVoce.ContasAPagar" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <div style="width: 1000px;">
                    <center>
                        <table border="0">
                            <tr>
                                <td width="200px">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="500px" align="center">
                                    <h1>Contas a Pagar</h1>
                                </td>
                                <td width="300px">
                                    <a id="A2" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <br />
                    Vencimento entre
                <asp:TextBox ID="txtDatamin" runat="server" Width="80"></asp:TextBox>
                    e
                <asp:TextBox ID="txtDatamax" runat="server" Width="80"></asp:TextBox>
                    <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFiltro" runat="server" Text="Visualizar Filtros" OnClick="btnFiltro_Click" />
                    - 
                    <asp:Button ID="btnNovo" runat="server" Text="Novo Lançamento" OnClick="btnNovo_Click" />
                    <div runat="server" id="divNovo" visible="false">
                        <hr />
                        <br />
                        <b>Novo Pagamento</b>
                        <table>
                            <tr>
                                <td>Fornecedor</td>
                                <td>Classificação Financeira</td>
                                <td>Centro Custo</td>
                                <td>Obs</td>
                                <td>Vencimento</td>
                                <td>Valor</td>
                                <td>Repetir</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlFornecedor" runat="server" Width="200" /></td>
                                <td>
                                    <asp:DropDownList ID="ddlClassificacao" runat="server" Width="200" /></td>
                                <td>
                                    <asp:DropDownList ID="ddlCentro" runat="server" Width="100">
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                    </asp:DropDownList></td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtObs" Width="100px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtVencimento" Width="100px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtValor" Width="100px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtRepetir" Width="50px" Text="1"></asp:TextBox></td>
                                <td>
                                    <asp:ImageButton ID="btnInserirNovo" runat="server" OnClick="btnInserirNovo_Click"
                                        ImageUrl="~/images/ok.png" /><asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnNovo_Click"
                                            ImageUrl="~/images/cancelar.png" /></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <div runat="server" id="divFiltros" visible="false">
                        <hr />
                        <table>
                            <tr>
                                <td>Fornecedor</td>
                                <td width="200px">
                                    <asp:TextBox runat="server" ID="txtFornecedorPesquisa" Width="146px"></asp:TextBox></td>
                                <td>Classificação Financeira</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtClassFinanceira" Width="146px"></asp:TextBox>
                                    <asp:Button ID="btnFiltroLimpar" runat="server" Text="Limpar Filtros" OnClick="btnFiltroLimpar_Click" /></td>
                            </tr>
                            <tr>
                                <td>Origem</td>
                                <td>
                                    <asp:DropDownList ID="ddlOrigem" runat="server" Width="150">
                                        <asp:ListItem Text="Todos" Value="todos"></asp:ListItem>
                                        <asp:ListItem Text="1234" Value="no"></asp:ListItem>
                                        <asp:ListItem Text="Particular" Value="yes"></asp:ListItem>
                                    </asp:DropDownList></td>
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
                                <td>Centro Custo</td>
                                <td>
                                    <asp:DropDownList ID="ddlCentroFiltro" runat="server" Width="150">
                                        <asp:ListItem Text="todos" Value="todos"></asp:ListItem>
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <hr />
                    <b>Lista de pagamento</b> -
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Data Compra">
                                <ItemTemplate>
                                    <asp:Label ID="lblDataCompra" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fornecedor">
                                <ItemTemplate>
                                    <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class. Financeira / Produto">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("PrimeiroDenmProduto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="150"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtVencimento" runat="server" Width="70px"></asp:TextBox>
                                    <asp:HiddenField ID="hdnIDContasPagar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlFormaView" runat="server" Width="90">
                                        <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                        <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                                        <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                                        <asp:ListItem Text="Transferência" Value="Transferência"></asp:ListItem>
                                        <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="lblValorParcela" runat="server" Width="70"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlBanco" runat="server" Width="80">
                                        <asp:ListItem Text=" " Value=" "></asp:ListItem>
                                        <asp:ListItem Text="Itaú" Value="Itaú"></asp:ListItem>
                                        <asp:ListItem Text="Bradesco" Value="Bradesco"></asp:ListItem>
                                        <asp:ListItem Text="Vila Maria Bradesco" Value="BradescoVM"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlCentro" runat="server" Width="80">
                                        <asp:ListItem Text=" " Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" ImageUrl="~/images/salvar.jpg" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor Pago" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValorPago" runat="server" Width="90px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Pagamento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtPagto" runat="server" Width="110px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnPagar" runat="server" OnClick="btnPagar_Click" Text="pagar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="excluir" Visible="false" />
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
                    <hr />
                    <br />
                    <asp:LinkButton ID="lnkResumoBanco" runat="server" Text="clique para exibir/ocultar o resumo por banco"
                        OnClick="lnkResumoBanco_OnClick"></asp:LinkButton>
                    <div id="divResumoBanco" runat="server" visible="false">
                        <table border="0" style="border: solid 1px gray;">
                            <tr>
                                <td width="200px">
                                    <b>Banco</b>
                                </td>
                                <td>
                                    <b>Total</b>
                                </td>
                            </tr>
                            <tr>
                                <td>Itaú
                                </td>
                                <td>R$
                                <asp:Label ID="lblItau" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Bradesco
                                </td>
                                <td>R$
                                <asp:Label ID="lblBardesco" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Bradesco Vila Maria
                                </td>
                                <td>R$
                                <asp:Label ID="lblBradescoVilaMaria" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
