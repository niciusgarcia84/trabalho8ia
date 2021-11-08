<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComprasFinalizadas.aspx.cs"
    Inherits="financeiroVoce.ComprasFinalizadas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compras Finalizadas - Instituto Você</title>
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
            <table border="0">
                <tr>
                    <td colspan="3">
                        <center>
                            <table border="0" id="inicio">
                                <tr>
                                    <td width="400px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="600px">
                                        <h1>
                                            Histórico de Compras</h1>
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
                    <td style="border-right-style: dotted; border-right-color: Gray; width: 500px;">
                        <h2>
                            Lista de Compras</h2>
                        <table>
                            <tr>
                                <td>
                                    Fornecedores
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFornecedor" runat="server" Width="319" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Data inicial
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInicio" runat="server" Width="80px"></asp:TextBox>
                                    e data final
                                    <asp:TextBox ID="txtFinal" runat="server" Width="80px"></asp:TextBox>
                                    <asp:Button ID="Atualizar" runat="server" Text="Filtrar" OnClick="Atualizar_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <div id="divListaCompras" runat="server">
                            <asp:GridView ID="grdCompras" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                OnRowDataBound="grdCompras_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Fornecedor" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFornecedor" runat="server" Text='<%# Eval("nmFornecedor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Compra" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDtEntrega" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblObs" runat="server" Width="200"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Detalhes">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDCompra" runat="server" />
                                            <asp:HiddenField ID="hdnIDFornecedor" runat="server" />
                                            <asp:HiddenField ID="hdnParticular" runat="server" Value='<%# Eval("Particular") %>' />
                                            <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterarCompra_Click"
                                                ImageUrl="~/images/alterar.jpg" OnClientClick="javascript:topo();" />
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
                        <div id="divCadastrar" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td width="450px">
                                        <h2>
                                            <b>
                                                <asp:Label ID="lblTituloCompra" runat="server" Text="Inserir nova compra" /></b></h2>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnExcluirCompra" runat="server" OnClick="btnExcliurCompra_Click"
                                            ImageUrl="~/images/excluir.png" Visible="false" />
                                        <asp:ImageButton ID="btnCancelarCompra" runat="server" OnClick="btnCancelarCompra_Click"
                                            ImageUrl="~/images/cancelar.png" Visible="false" />
                                        <asp:ImageButton ID="ImageButton8" runat="server" OnClick="btnImprimir_Click" ImageUrl="~/images/imprimir.png" />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td valign="middle">
                                        Fornecedor
                                    </td>
                                    <td align="left" valign="middle">
                                        <asp:Label ID="lblFornecedorAlteracao" runat="server"></asp:Label>
                                        <asp:ImageButton ID="btnAlterarFornecedor" runat="server" OnClick="btnAlterarFornecedor_Click"
                                            ImageUrl="~/images/alterar.jpg" />
                                        <asp:DropDownList ID="ddlFornecedores" runat="server" Width="200" Visible="false" />
                                        <asp:ImageButton ID="btnSalvarFornecedor" runat="server" OnClick="btnSalvarFornecedor_Click"
                                            ImageUrl="~/images/atualizar.jpg" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Observações
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="txtObsCompra" runat="server" Width="200"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Particular
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblParticular" runat="server"></asp:Label>
                                        -
                                        <asp:LinkButton ID="lnkAlterarParticular" runat="server" Font-Size="Smaller" Text="clique aqui para alternar"
                                            OnClick="lnkAlterarParticular_OnClick"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Data Entrega
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="txtDtEntregaCompra" runat="server" Width="100"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Total
                                    </td>
                                    <td align="left">
                                        <asp:HiddenField ID="hdnIDCompraAlteracao" runat="server" />
                                        <asp:HiddenField ID="hdnDtCompra" runat="server" />
                                        <asp:Label ID="lblTotalCompra" runat="server" Width="100" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lblResultadoCompra" runat="server" ForeColor="Red"></asp:Label>
                            <asp:DropDownList ID="ddlCompraID" runat="server" Visible="false">
                            </asp:DropDownList>
                            <div id="divItemCompra" runat="server" visible="false">
                                <h2>
                                    Itens na compra</h2>
                                <asp:GridView ID="grdItemCompra" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdItemCompra_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Produto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' Width="180px"></asp:Label>
                                                <asp:HiddenField ID="hdnIDItemCompra" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantidade" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblQuantidade" runat="server" Text='<%# Eval("Qtde") %>' Width="70"></asp:TextBox>
                                                <asp:HiddenField ID="hdnQtdeEstoque" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unitário" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lblUnitario" runat="server" Width="70"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Width="70"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkAlterarValor" runat="server" ImageUrl="~/images/salvar.jpg"
                                                    OnClick="lnkAlterarValor_OnClick" />
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
                            <hr />
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <h2>
                                                Parcelamento</h2>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label runat="server" ID="lblDuplicado" Text="clique no botão ao lado caso a forma de pagto esteja duplicada"
                                                Font-Size="Smaller"></asp:Label>
                                            <asp:ImageButton ID="btnAtualizarFinanceiro" runat="server" OnClick="btnAtualizarFinanceiro_Click"
                                                ImageUrl="~/images/atualizar.jpg" />
                                        </td>
                                    </tr>
                                </table>
                                <h2>
                                    Total pago R$
                                    <asp:Label ID="lblResultadoFinanceiro" runat="server"></asp:Label></h2>
                                <asp:GridView ID="grdFinanceiro" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdFinanceiro_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Forma Pagto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnIDParcela" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Centro Custo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCentro" runat="server" Text='<%# Eval("CentroCusto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="200"></asp:Label>
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
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkAlterarPagto" runat="server" ImageUrl="~/images/salvar.jpg"
                                                    OnClick="lnkAlterarPagto_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkRemoverPagto" runat="server" OnClick="lnkRemoverPagto_OnClick"
                                                    Text="remover" Visible="false"></asp:LinkButton>
                                                <asp:Label ID="lblPago" runat="server" Visible="false" Text="Pago" ForeColor="Red"></asp:Label>
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
                                            <h2>
                                                Cheques de Terceiros</h2>
                                        </td>
                                        <td width="280px">
                                            - Soma R$
                                            <asp:Label ID="lblTotalCheques" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdFinanceiroCheques" runat="server" AutoGenerateColumns="False"
                                    Font-Size="10pt" OnRowDataBound="grdFinanceiroCheques_RowDataBound" CellPadding="4"
                                    ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Responsável">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Banco">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBanco" runat="server" Text='<%# Eval("cqBanco") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agência">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAg" runat="server" Text='<%# Eval("cqAgencia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Conta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCC" runat="server" Text='<%# Eval("cqCC") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Número">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumero" runat="server" Text='<%# Eval("cqNumero") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDCheque" runat="server" />
                                                <asp:HiddenField ID="hdnIDTreinando" runat="server" />
                                                <asp:LinkButton ID="lnkEstornar" runat="server" OnClick="lnkEstornar_OnClick" Text="estornar"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDevolver" runat="server" OnClick="btnDevolver_Click" Text="&nbsp;&nbsp;devolver"></asp:LinkButton>
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
                                <br />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
