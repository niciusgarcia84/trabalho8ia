<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroTreinandos.aspx.cs"
    Inherits="financeiroVoce.CadastroTreinandos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Treinandos - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function topo() {
            document.getElementById('inicio').focus();
            scroll(0, 0);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table border="0" id="inicio">
                    <tr>
                        <td colspan="4">
                            <center>
                                <table border="0">
                                    <tr>
                                        <td width="200px">
                                            <img src="./images/logo.png" alt="logo" />
                                        </td>
                                        <td width="500px" align="center">
                                            <h1>Cadastro de Treinando</h1>
                                        </td>
                                        <td align="right">
                                            <a id="A2" href="relBloqueio.aspx">Relatórios</a> - <a id="A4" href="importarTreinandos.aspx">Importar</a> - <a id="A5" href="arquetipos.aspx">Arquétipos</a>
                                            <br />
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
                        <td style="border-right-style: dotted; border-right-color: Gray; padding-right: 10px;">
                            <div id="divFiltro" runat="server">
                                <br />
                                <table>
                                    <tr>
                                        <td>Informe uma parte do nome para localizar
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNmPesquisa" runat="server" Width="125"></asp:TextBox>
                                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="limparNome_OnClick" ImageUrl="~/images/excluirpq.png" />
                                            <asp:Button ID="btnFiltrar" runat="server" Text="buscar" OnClick="btnFiltrar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>ou </b>selecione um treinamento &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="lnkCarregarMaisInicio" runat="server" OnClick="lnkCarregarMaisInicio_OnClick"
                                            ImageUrl="~/images/maispq.png" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTreinamentoInicio" runat="server" Width="155" />
                                            <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="buscar" OnClick="btnFiltrarTreinamento_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divLista" runat="server" visible="false">
                                <h2>1 - Treinandos Cadastrados</h2>
                                <asp:LinkButton ID="lnkVoltar" runat="server" Text="Clique aqui para digitar outro nome ou selecionar outro treinamento"
                                    OnClick="lnkVoltar_Click"></asp:LinkButton><br />
                                <br />
                                <h2>
                                    <asp:Label ID="lblTituloSelecionado" runat="server" ForeColor="Teal"></asp:Label></h2>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="400"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgFechado" ImageUrl="~/images/cadFechadoMini.png"
                                                    Visible="false" />
                                                <asp:ImageButton runat="server" ID="imgAberto" ImageUrl="~/images/cadAbertoMini.png"
                                                    Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDEquipe" runat="server" />
                                                <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" ImageUrl="~/images/alterar.jpg"
                                                    OnClientClick="javascript:topo();" />
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
                                <asp:HiddenField ID="hdnFiltro" runat="server" />
                            </div>
                        </td>
                        <td style="padding-left: 10px; padding-right: 10px;">
                            <div id="divCadastrar" runat="server">
                                <h2>
                                    <b>
                                        <asp:Label ID="lblTitulo" runat="server" Text="2 - Inserir" /></b></h2>
                                <table>
                                    <tr>
                                        <td>Nome
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNome" runat="server" Width="300" />
                                            <asp:HiddenField ID="hdnIDEqp" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size:smaller;">Saldo Credor /<br />Observações
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObs" runat="server" Width="300" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="btnInserir" runat="server" OnClick="btnInserir_Click" ImageUrl="~/images/ok.png" />
                                            <asp:ImageButton ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" ImageUrl="~/images/ok.png"
                                                Visible="false" />
                                            <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/cancelar.png"
                                                Visible="false" />
                                            <asp:ImageButton ID="btnOcultar" runat="server" OnClick="btnOcultar_Click" ImageUrl="~/images/excluir.png"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label runat="server" ID="lblResultado" ForeColor="Red"></asp:Label>
                            </div>
                            <div id="divEdicao" runat="server" visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Lista de treinamentos</h2>
                                        </td>
                                        <td>-
                                        <asp:LinkButton ID="lnkNovoTreinamento" runat="server" OnClick="novoTreinamento_Click"
                                            Text="Novo"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdLista" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdLista_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Treinamento" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTreinamento" runat="server" Text='<%# Eval("Descricao") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Equipe") %>' Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Pago" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalhes">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" />
                                                <asp:HiddenField ID="hdnDesconto" runat="server" />
                                                <asp:HiddenField ID="hdnTotal" runat="server" />
                                                <asp:HiddenField ID="hdnIDEquipe" runat="server" />
                                                <asp:HiddenField ID="hdnEquipeAtivo" runat="server" />
                                                <asp:HiddenField ID="hdnObsLista" runat="server" />
                                                <asp:HiddenField ID="hdnNF" runat="server" />
                                                <asp:HiddenField ID="hdnMais" runat="server" />
                                                <asp:HiddenField ID="hdnAusente" runat="server" />
                                                <asp:HiddenField ID="hdnInvestimento" runat="server" />
                                                <asp:HiddenField ID="hdnDtInicial" runat="server" />
                                                <asp:HiddenField ID="hdnBloqueado" runat="server" />
                                                <asp:HiddenField ID="hdnEdicao" runat="server" />
                                                <asp:HiddenField ID="hdnCredito" runat="server" />
                                                <asp:HiddenField ID="hdnExperiente" runat="server" />
                                                <asp:HiddenField ID="hdnCarta" runat="server" />
                                                <asp:LinkButton ID="lnkDetalharPagto" runat="server" OnClick="detalharPagto_Click"
                                                    Text="Visualizar"></asp:LinkButton>
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
                                <div id="divNovoTreinamento" runat="server" visible="false">
                                    <br />
                                    <br />
                                    <h2>Cadastre-o em um novo treinamento</h2>
                                    <table>
                                        <tr>
                                            <td>Treinamento
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTreinamento" runat="server" Width="260" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:LinkButton ID="lnkCarregarMais" runat="server" Text="Clique aqui para carregar mais treinamentos"
                                                    OnClick="lnkCarregarMais_OnClick" ForeColor="Green"></asp:LinkButton>
                                                <asp:Label ID="lnkAviso" runat="server" Text="carregado." ForeColor="Red" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Equipe
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlEquipe" runat="server" Width="260" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="imgInserirLista" runat="server" OnClick="btnInserirLista_Click"
                                                    ImageUrl="~/images/ok.png" />
                                                <asp:ImageButton ID="imgCancelarLista" runat="server" OnClick="novoTreinamentoCancelar_Click"
                                                    ImageUrl="~/images/cancelar.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td id="coluna4" runat="server">
                            <div id="divDetalhePagto" runat="server" visible="false">
                                <table border="0" width="100%">
                                    <tr>
                                        <td width="150px">
                                            <h2>3 - Treinamento</h2>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblDetalheTreinamento" runat="server" />
                                            <asp:HiddenField ID="hdnIDListaDetalhe" runat="server" />
                                        </td>
                                        <td rowspan="2">
                                            <asp:Image ID="imgCadAberto" runat="server" ImageUrl="~/images/cadAberto.jpg" Visible="false" />
                                            <asp:Image ID="imgCadFechado" runat="server" ImageUrl="~/images/cadFechado.jpg" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">alterar treinamento</td>
                                        <td>
                                            <asp:DropDownList ID="ddlTreinamentoAlterar" runat="server" Width="200" /><asp:ImageButton ID="ImageButton5" runat="server" OnClick="alterarTreinamento_OnClick"
                                                ImageUrl="~/images/atualizar.jpg" /></td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h2>Detalhes do Pagamento</h2>
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lnkBloquearTreinamento" runat="server" OnClick="lnkBloquearTreinamento_OnClick"
                                                Text="Clique aqui para bloquear o treinando!" ForeColor="Red"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>Equipe
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlEquipe2" runat="server" Width="405" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nota Fiscal
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNF" runat="server" Width="370" />
                                            <asp:ImageButton ID="imgSalvarNota" runat="server" OnClick="btnSalvarNota_Click"
                                                ImageUrl="~/images/salvar.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Pagante
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObsLista" runat="server" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Desconto Autorizado
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDesconto" runat="server" Width="400" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>+ de 271 dias autorizado
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkMais" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Experiente (Diamond)
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkExperiente" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Sem carta de autorização
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkCarta" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ausente
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkAusente" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Investimento
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkInvestimento" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Total Pago
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="txtTotalPagto" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><b>Crédito / Observações</b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCredito" runat="server" Width="400" MaxLength="149"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Forma de Pagamento</h2>
                                        </td>
                                        <td>-
                                        <asp:LinkButton ID="lnkNovoPagto" runat="server" OnClick="novoPagto_Click" Text="Novo"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <div style="margin-left: 75px;">
                                                <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnAtualizarTreinamento_Click"
                                                    ImageUrl="~/images/ok.png" />
                                                <asp:ImageButton ID="ImageButton3" runat="server" OnClick="btnCancelarTreinamento_Click"
                                                    ImageUrl="~/images/cancelar.png" />
                                                <asp:ImageButton ID="imgOcultarTreinamento" runat="server" OnClick="btnOcultarTreinamento_Click"
                                                    ImageUrl="~/images/excluir.png" Visible="false" />
                                                <asp:HiddenField ID="hdnTreinamentoDtInicial" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblResultadoTreinamento" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblTotalParcelas" runat="server" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="grdDetalhes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdDetalhes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="DT Pagto" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDTPagto" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Forma" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTotalValor" runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDTPara" runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cheque / Doc" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Responsavel" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponsavel" runat="server" Text='<%# Eval("Responsavel") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalhes">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDPagtos" runat="server" />
                                                <asp:LinkButton ID="lnkDetalharPagto" runat="server" Text="Visualizar" OnClick="visualizarParcela_Click"></asp:LinkButton>
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
                                <asp:Label ID="lblDetalhePagto" runat="server" ForeColor="Gray"></asp:Label>
                            </div>
                        </td>
                        <td style="border-left-style: dotted; border-left-color: Gray; padding-left: 10px;">
                            <div id="divNovoPagto" runat="server" visible="false">
                                <h2>
                                    <asp:Label ID="lblTituloPagto" runat="server" Text="4 - Nova Parcela"></asp:Label></h2>
                                <table>
                                    <tr>
                                        <td>Data Pagto
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDTPagto" runat="server" Width="200" />
                                            <asp:HiddenField ID="hdnIDParcela" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Forma Pagto
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFormaPagto" runat="server" Width="170">
                                                <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                                                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                                                <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                                                <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                                                <asp:ListItem Text="Crédito" Value="Crédito"></asp:ListItem>
                                                <asp:ListItem Text="Crédito Cheque" Value="CréditoCheque"></asp:ListItem>
                                                <asp:ListItem Text="Crédito mesmo treinamento" Value="CréditoMesmo"></asp:ListItem>
                                                <asp:ListItem Text="Crédito mesmo Cheque" Value="CréditoMesmoCheque"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="lnkSelecionarFormaPagto" runat="server" Text="OK" OnClick="SelecionarFormaPagto_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Valor da Parcela
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtValorParcela" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Vencimento
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDTVencimento" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Titular
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtResponsavel" runat="server" Width="190" />
                                            <asp:ImageButton ID="ImageButton4" runat="server" OnClick="limparResponsavel_OnClick"
                                                ImageUrl="~/images/excluirpq.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Banco creditado
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtctBanco" runat="server" Width="200" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRepetirXVezes" runat="server" Text="Qtde Parcelas"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtQtdeRepetir" runat="server" Width="200" Text="1" />
                                        </td>
                                    </tr>
                                </table>
                                <div id="divCredito" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <b>Dados do Crédito</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Origem
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtOrigem" runat="server" Width="150" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divBoleto" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <b>Dados do Boleto</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Número
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNumBoleto" runat="server" Width="150" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sacado
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSacadoBoleto" runat="server" Width="150" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divCartao" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <b>Dados do Cartão de Crédito</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Número
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtctNumero" runat="server" Width="150" Text="****" /><asp:LinkButton
                                                    ID="lnkTestarCartao" runat="server" OnClick="testarNumeroCartao" Text="Testar"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkVisa_OnClick" Text="Visa" Font-Size="Small"></asp:LinkButton>
                                                -
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnkMastercard_OnClick" Text="Mastercard" Font-Size="Small"></asp:LinkButton>
                                                -
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnkAmex_OnClick" Text="Amex" Font-Size="Small"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Bandeira
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtctBandeira" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>NSU/DOC
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtctValidade" runat="server" Width="150" /><asp:LinkButton ID="LinkButton1"
                                                    runat="server" OnClick="testarNumeroNSU" Text="Testar"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtctSeguranca" runat="server" Width="200" Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divCheque" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <b>Dados do Cheque</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Banco
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcqBanco" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Agência
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcqAgencia" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Conta Corrente
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcqCC" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Número
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcqNumero" runat="server" Width="200" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divBotoesPagamentos" runat="server" style="float: right;" visible="false">
                                    <asp:ImageButton ID="btnInserirDetalhes" runat="server" OnClick="btnInserirDetalhes_Click"
                                        ImageUrl="~/images/ok.png" />
                                    <asp:ImageButton ID="btnAtualizarDetalhes" runat="server" OnClick="btnAtualizarDetalhes_Click"
                                        ImageUrl="~/images/ok.png" Visible="false" />
                                    <asp:ImageButton ID="btnCancelarDetalhes" runat="server" OnClick="btnCancelarDetalhes_Click"
                                        ImageUrl="~/images/cancelar.png" Visible="true" />
                                    <asp:ImageButton ID="btnOcultarDetalhes" runat="server" OnClick="btnOcultarDetalhes_Click"
                                        ImageUrl="~/images/excluir.png" Visible="false" />
                                </div>
                                <br />
                                <asp:Label ID="lblAvisoDetalhes" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                                <asp:GridView ID="grdPagto" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdPagto_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    Visible="false">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="teste" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblteste" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <div id="testeCartao" runat="server" visible="false">
                                    <asp:Label ID="lbl" runat="server" Text="Caso o cartão ou NSU/DOC já conste no financeiro, abaixo será exibido o nome do treinando."
                                        ForeColor="Red"></asp:Label>
                                    <asp:GridView ID="grdTeste" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                        CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Treinando com o mesmo cartão" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
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
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
