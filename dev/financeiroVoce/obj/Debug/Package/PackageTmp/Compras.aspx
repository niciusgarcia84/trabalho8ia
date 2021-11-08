<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="financeiroVoce.Compras" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compras - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td colspan="3">
                            <center>
                                <table border="0">
                                    <tr>
                                        <td width="200px">
                                            <img src="./images/logo.png" alt="logo" />
                                        </td>
                                        <td width="500px">
                                            <h1>Compras</h1>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkExcluir" runat="server" OnClick="exibirExcluir" Text="Excluir"></asp:LinkButton>
                                            - <a id="A1" href="Default.aspx">Menu Principal</a>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <hr />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="border-right-style: dotted; border-right-color: Gray;">
                            <div id="divListaCompras" runat="server">
                                <h2>Compras Pendentes</h2>
                                <asp:GridView ID="grdCompras" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdCompras_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Fornecedor" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data Entrega" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtEntrega" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDCompra" runat="server" />
                                                <asp:HiddenField ID="hdnIDFornecedor" runat="server" />
                                                <asp:HiddenField ID="hdnParticular" runat="server" Value='<%# Eval("Particular") %>' />
                                                <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterarCompra_Click"
                                                    ImageUrl="~/images/alterar.jpg" />
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
                        </td>
                        <td style="padding-left: 10px;">
                            <div id="divCadastrar" runat="server">
                                <table>
                                    <tr>
                                        <td width="350px">
                                            <h2>
                                                <b>
                                                    <asp:Label ID="lblTituloCompra" runat="server" Text="Inserir nova compra" /></b></h2>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnReceber" runat="server" OnClick="receberMercadoria" Text="Forma de pagamento"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>Fornecedor
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFornecedor" runat="server" Width="350" />
                                            <asp:HiddenField ID="hdnIDCompraAlteracao" runat="server" />
                                            <asp:HiddenField ID="hdnDtCompra" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Observações
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObsCompra" runat="server" Width="350" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Data Entrega
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDtEntregaCompra" runat="server" Width="100" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Total
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTotalCompra" runat="server" Width="100" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkParticular" runat="server" Checked="false" Visible="false" />
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="btnInserirCompra" runat="server" OnClick="btnInserirCompra_Click"
                                                ImageUrl="~/images/ok.png" />
                                            <asp:ImageButton ID="btnAtualizarCompra" runat="server" OnClick="btnAtualizarCompra_Click"
                                                ImageUrl="~/images/ok.png" Visible="false" />
                                            <asp:ImageButton ID="btnCancelarCompra" runat="server" OnClick="btnCancelarCompra_Click"
                                                ImageUrl="~/images/cancelar.png" Visible="false" />
                                            <asp:ImageButton ID="btnOcultarCompra" runat="server" OnClick="btnOcultarCompra_Click"
                                                ImageUrl="~/images/excluir.png" Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblResultadoCompra" runat="server" ForeColor="Red"></asp:Label>
                                <div id="divItemCompra" runat="server" visible="false">
                                    <h2>
                                        <b>
                                            <asp:Label ID="lblTituloItemCompra" runat="server" Text="Insira um novo item na compra" /></b></h2>
                                    <table>
                                        <tr>
                                            <td>
                                                <b>Produto</b>
                                            </td>
                                            <td>Quantidade
                                            </td>
                                            <td>Valor Unitário
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlProduto" runat="server" Width="210" /><br />
                                                <asp:LinkButton ID="lnkCarregarTudo" runat="server" Text="+ produtos" OnClick="lnkCarregarTudo_OnClick"></asp:LinkButton>
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtQtdeProduto" runat="server" Width="100" />
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtValorUnitarioProduto" runat="server" Width="100" />
                                            </td>
                                            <td valign="top">
                                                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnAdicionarItemCompra_Click"
                                                    ImageUrl="~/images/mais.png" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblResultadoItemCompra" runat="server" ForeColor="Red"></asp:Label>
                                    <h2>Itens na compra</h2>
                                    <asp:GridView ID="grdItemCompra" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                        OnRowDataBound="grdItemCompra_RowDataBound" CellPadding="4" ForeColor="#333333"
                                        GridLines="None">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Produto">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' Width="180px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantidade" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQuantidade" runat="server" Text='<%# Eval("Qtde") %>' Width="70"></asp:Label>
                                                    <asp:HiddenField ID="hdnQtdeEstoque" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unitário" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnitario" runat="server" Width="70"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Width="70"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Excluir" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnIDItemCompra" runat="server" />
                                                    <asp:LinkButton ID="btnExcluirItemCompra" runat="server" OnClick="btnExcluirItemCompra_Click"
                                                        Text="Excluir" Font-Size="Smaller" />
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
                            </div>
                        </td>
                        <td style="border-left-style: dotted; border-left-color: Gray; padding-left: 10px;">
                            <div id="divFinanceiro" runat="server" visible="false">
                                <asp:Label ID="lblResultadoFinanceiro" runat="server" ForeColor="Red"></asp:Label>
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Parcelas</h2>
                                        </td>
                                        <td width="400px">- Soma R$<asp:Label ID="lblTotalParcelas" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton7" runat="server" OnClick="btnAtualizarParcelas_Click"
                                                ImageUrl="~/images/ok.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton6" runat="server" OnClick="btnCancelarParcelaFinanceiro_Click"
                                                ImageUrl="~/images/cancelar.png" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImageButton8" runat="server" OnClick="btnImprimir_Click" ImageUrl="~/images/imprimir.png" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdFinanceiro" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdFinanceiro_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Forma Pagto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Centro">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCentro" runat="server" Text='<%# Eval("CentroCusto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="150"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtVencimento" runat="server" Width="70"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValorParcela" runat="server" Width="60"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Excluir" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDParcela" runat="server" />
                                                <asp:LinkButton ID="btnExcluirParcela" runat="server" OnClick="btnExcluirParcela_Click"
                                                    Text="Excluir" Font-Size="Smaller" />
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
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Cheques</h2>
                                        </td>
                                        <td width="280px">- Soma R$
                                        <asp:Label ID="lblTotalCheques" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                Centro de custo dos cheques atribuídos 
                                    <asp:DropDownList ID="ddlCentroCheque" runat="server" Width="200">
                                        <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                <asp:GridView ID="grdFinanceiroCheques" runat="server" AutoGenerateColumns="False"
                                    Font-Size="12pt" OnRowDataBound="grdFinanceiroCheques_RowDataBound" CellPadding="4"
                                    ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Dados" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="Small">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDados" runat="server" Width="350"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVencimento" runat="server" Width="70"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValor" runat="server" Width="60"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDCheque" runat="server" />
                                                <asp:LinkButton ID="btnExcluirCheque" runat="server" OnClick="btnExcluirCheque_Click"
                                                    Text="Remover" Font-Size="Small" />
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
                                <table>
                                    <tr>
                                        <td width="250px">
                                            <h2>
                                                <b>
                                                    <asp:Label ID="lblTituloFinanceiro" runat="server" Text="Detalhes do Pagamento" /></b></h2>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkNovoParcela" runat="server" OnClick="lnkNovoParcela_Click"
                                                Text="Novo"></asp:LinkButton>
                                            -
                                        <asp:LinkButton ID="lnkChequeParcela" runat="server" OnClick="lnkChequeParcela_Click"
                                            Text="Atribuir Cheque"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divNovaParcela" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td>Forma de Pagto
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlFormaPagto" runat="server" Width="200">
                                                    <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                    <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                                                    <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                                                    <asp:ListItem Text="Transferência" Value="Transferência"></asp:ListItem>
                                                    <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Centro Custo
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlCentro" runat="server" Width="200">
                                                    <asp:ListItem Text="Administrativo" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Diretoria" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Matriz" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Operacional" Value="4"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Observações
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtObsFinanceiro" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Data de pagto
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDtVencimentoFinanceiro" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Valor do Pagto
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtValorFinanceiro" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Repetir X vezes
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtdeRepetir" runat="server" Width="200" Text="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnInserirParcelaFinanceiro_Click"
                                                    ImageUrl="~/images/mais.png" />
                                                <asp:ImageButton ID="ImageButton4" runat="server" OnClick="btnCancelarParcelaFinanceiro_Click"
                                                    ImageUrl="~/images/cancelar.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divCheque" runat="server" visible="false">
                                    <br />
                                    exibir cheques de
                                <asp:TextBox ID="txtDatamin" runat="server" Width="80" Font-Size="Small"></asp:TextBox>
                                    até
                                <asp:TextBox ID="txtDatamax" runat="server" Width="80" Font-Size="Small"></asp:TextBox>
                                    <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                                    <asp:Button ID="btnCancelarFormaPagto" runat="server" Text="Cancelar" OnClick="btnCancelarFormaPagto_Click" />
                                    <br />
                                    <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="12pt"
                                        OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnIDPagto" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cheque" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumheque" runat="server" Text='<%# Eval("cqNumero") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Responsavel" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>' Width="300px"
                                                        Font-Size="Small"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Atribuir" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAtribuir" runat="server" OnClick="btnAtribuirCheque_Click"
                                                        Text="Atribuir" />
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
                                <br />
                                <br />
                                <asp:Button ID="btnFinalizarCompra" runat="server" OnClick="btnFinalizarCompra_Click"
                                    Text="Clique aqui" /><br />
                                <span style="color: Red;">para finalizar o pedido, incluir as parcelas no contas a pagar e dar entrada no estoque dos produtos.</span>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
