<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="financeiroVoce._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Financeiro - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divEditarPerfil" runat="server" visible="false">
            <div id="fundo">
                &nbsp;
            </div>
            <div id="internoHome">
                <div id="divPerfil" runat="server">
                    <h2>Editar Perfil</h2>
                    <p style="color: Black; font-size: larger;">
                        Preencha o campo abaixo para alterar a senha de acesso ao sistema.
                    </p>
                    <table>
                        <tr>
                            <td>nova senha
                            </td>
                            <td>
                                <asp:TextBox ID="txtNovaSenha" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>repetir nova senha
                            </td>
                            <td>
                                <asp:TextBox ID="txtNovaSenha2" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="150px">&nbsp;
                            </td>
                            <td align="right" width="180px">
                                <asp:ImageButton ID="btnSalvarEditar" runat="server" OnClick="btnSalvarEditar_Click"
                                    ImageUrl="~/images/ok.png" />
                                <asp:ImageButton ID="brnFecharOrca" runat="server" OnClick="brnFechaEditar_OnClick"
                                    ImageUrl="~/images/cancelar.png" />
                            </td>
                        </tr>
                    </table>
                    <div id="divAdm" runat="server" visible="false">
                        <asp:ImageButton ID="imgMenu2" runat="server" ImageUrl="~/images/menu.jpg" PostBackUrl="~/admin.aspx" />
                        clique aqui para editar os demais usuários.
                    </div>
                </div>
            </div>
        </div>
        <div style="margin: 0px auto; padding: 15px; width: 900px; text-align: center; font-size: 16pt;">
            <center>
                <div id="validar" runat="server">
                    <img src="./images/logo.png" alt="logo" />
                    <br />
                    <br />
                    <table border="0" width="300px">
                        <tr>
                            <td>Usuário
                            </td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server" MaxLength="49" Width="240px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Senha
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" runat="server" MaxLength="49" TextMode="Password" Width="240px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="btnOk" runat="server" Text="Entrar" OnClick="btnOk_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div runat="server" id="cadastros">
                    <div id="divUsuario" runat="server">
                        <table width="100%">
                            <tr>
                                <td width="10%">
                                    <asp:ImageButton ID="imgMenu" runat="server" ImageUrl="~/images/menu.jpg" PostBackUrl="~/admContas.aspx"
                                        Visible="false" />
                                </td>
                                <td align="right">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="30%" align="right">Seja bem-vindo
                                <asp:Label runat="server" ID="lblUsuario"></asp:Label>.
                                <asp:HiddenField ID="hdnId" runat="server" />
                                </td>
                                <td width="10%">
                                    <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/images/editar.jpg" OnClick="imgEditar_OnClick" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkSair" runat="server" Text="Sair" OnClick="lnkSair_OnClick"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <table border="0">
                        <tr>
                            <td width="250px" style="border-right-color: Gray; border-right-style: dotted; border-left-color: Gray; border-left-style: dotted;"
                                valign="top" align="center">
                                <h1>Cadastros</h1>
                                <br />
                                <asp:LinkButton ID="lnkTreinandos" runat="server" PostBackUrl="~/CadastroTreinandos.aspx"
                                    Text="Treinandos"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkTreinamentos" runat="server" PostBackUrl="~/CadastroTreinamentos.aspx"
                                    Text="Treinamentos"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="LnkEquipes" runat="server" PostBackUrl="~/CadastroEquipes.aspx"
                                    Text="Equipes"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkFornecedores" runat="server" PostBackUrl="~/CadastroFornecedores.aspx"
                                    Text="Fornecedores"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkProdutos" runat="server" PostBackUrl="~/EstoqueGerenciar.aspx"
                                    Text="Produtos"></asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton ID="lnkClassificacaoFinanceira" runat="server" PostBackUrl="~/CadastroClassificacaoFinanceira.aspx"
                                    Text="Classificações Financeiras"></asp:LinkButton>
                                <br />
                                <br />
                            </td>
                            <td width="260px" valign="top" style="border-right-color: Gray; border-right-style: dotted;"
                                align="center">
                                <div runat="server" id="Div1">
                                    <h1>Financeiro</h1>
                                    <br />
                                    <asp:LinkButton ID="lnkContasAPagar" runat="server" PostBackUrl="~/ContasAPagar.aspx"
                                        Text="Contas a Pagar"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/ContasPagas.aspx"
                                        Text="Contas Pagas"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ContasAReceber.aspx"
                                        Text="Contas a Receber"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/ContasRecebidas.aspx"
                                        Text="Contas Recebidas"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/ChequesDevolvidos.aspx"
                                        Text="Cheques Devolvidos"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="~/localizarCheque.aspx"
                                        Text="Localizar Cheques"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton18" runat="server" PostBackUrl="~/Planilhas.aspx"
                                        Text="Planilhas"></asp:LinkButton>
                                    <br />
                                    <br />
                                </div>
                            </td>
                            <td width="250px" valign="top" style="border-right-color: Gray; border-right-style: dotted;"
                                align="center">
                                <div runat="server" id="Div2">
                                    <h1>Estoque</h1>
                                    <br />
                                    <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/Estoque.aspx" Text="Estoque"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/Compras.aspx" Text="Compras"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="~/ComprasFinalizadas.aspx"
                                        Text="Histórico de Compras"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/Saidas.aspx" Text="Saídas"></asp:LinkButton>
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="~/SaidasKit.aspx" Text="Saídas por kits"></asp:LinkButton>
                                    <br />
                                    <br />
                                </div>
                            </td>
                            <td width="500px" valign="top" align="center" style="border-right-color: Gray; border-right-style: dotted;">
                                <div runat="server" id="relatorios">
                                    <h1>Relatórios</h1>
                                    <br />
                                    <table>
                                        <tr>
                                            <td width="249px" valign="top" align="center" style="border-right-color: Gray; border-right-style: dotted;">
                                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/contaspagasresumo.aspx"
                                                    Text="Resumo Contas Pagas"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton14" runat="server" PostBackUrl="~/ResumoPagasTerceiros.aspx"
                                                    Text="Resumo Contas Pagas Cheques de terceiros"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/ResumoAReceber.aspx"
                                                    Text="Resumo Contas Recebidas"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton15" runat="server" PostBackUrl="~/resumoFinanceiro.aspx"
                                                    Text="Resumo Faturamento"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td width="249px" valign="top" align="center">
                                                <asp:LinkButton ID="lnkRelTreinamento" runat="server" PostBackUrl="~/RelTreinamento.aspx"
                                                    Text="Treinamento"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/ChequesPorTreinamentos.aspx"
                                                    Text="Cheques por Treinamento"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="lnkRelComissaoNovo" runat="server" PostBackUrl="~/relComissaoNovo.aspx"
                                                    Text="Comissões"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton17" runat="server" PostBackUrl="~/resumoVendas.aspx"
                                                    Text="Resumo Vendas"></asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="~/RelVendas.aspx" Text="Vendas" Visible="false"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </div>
    </form>
</body>
</html>
