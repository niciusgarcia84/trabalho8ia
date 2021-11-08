<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContasAReceber.aspx.cs"
    Inherits="financeiroVoce.ContasAReceber" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contas a Receber - Instituto Você</title>
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
                                <td width="300px" align="left">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="400px" align="center">
                                    <h1>Contas a Receber</h1>
                                </td>
                                <td width="500px" align="right">
                                    <asp:LinkButton runat="server" ID="lnkreceber" OnClick="lnkreceber_OnClick" Text="Novo Recebimento"></asp:LinkButton> - 
                                    <a id="A2" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <br />
                    <br />
                    <div id="divNormal" runat="server">
                        A lista abaixo está exibindo os recebimentos com vencimento entre
                    <asp:TextBox ID="txtDatamin" runat="server" Width="70"></asp:TextBox>
                        e
                    <asp:TextBox ID="txtDatamax" runat="server" Width="70"></asp:TextBox>
                        e forma pagto
                    <asp:DropDownList ID="ddlFormaPagto" runat="server" Width="90">
                        <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                        <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                        <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                        <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                    </asp:DropDownList>
                        <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                        <br />
                        <br />
                        ou informe o final do cartão de crédito
                    <asp:TextBox ID="txtCartaoBuscar" runat="server" Width="100"></asp:TextBox>
                        ou o NSU/DOC
                    <asp:TextBox ID="txtCartaoBuscarDoc" runat="server" Width="100"></asp:TextBox>
                        <asp:Button ID="btnBuscarCartao" runat="server" Text="Localizar" OnClick="btnBuscarCartao_Click" />
                        <asp:Button ID="btnBuscarCartaoLimpar" runat="server" Text="Limpar" OnClick="btnBuscarCartaoLimpar_Click" />
                        <hr />
                        <div id="divNovoCartao" runat="server" visible="false">
                            <h2>Informe os dados do cartão para inserir no contas a receber</h2>
                            <table>
                                <tr>
                                    <td>Número
                                    </td>
                                    <td width="160px">
                                        <asp:TextBox ID="txtNovoNumero" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>Valor parcela (R$ Bruto)
                                    </td>
                                    <td width="110px">
                                        <asp:TextBox ID="txtNovoValor" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td>Repetir
                                    </td>
                                    <td width="60px">
                                        <asp:TextBox ID="txtNovoRepetir" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnInserirCartao" runat="server" Text="Inserir" OnClick="btnInserirCartao_Click" />
                                        <asp:Button ID="btnCancelarCartao" runat="server" Text="Cancelar" OnClick="btnCancelarCartao_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bandeira
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtnovoBandeira" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>NSU/DOC
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNovoDoc" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="right">Vencimento
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNovoVencimento" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </div>
                        <div runat="server" id="divReceber" visible="false">
                            <h2>Novo Recebimento sem treinando</h2>
                            <table>
                                <tr>
                                    <td>Entrada</td>
                                    <td>Data</td>
                                    <td>Valor</td>
                                    <td>Obs</td>
                                    <td>Forma Pagto</td>
                                    <td>Banco</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlReceberCliente" runat="server" Width="200">
                                        </asp:DropDownList><br />
                                        <asp:LinkButton ID="lnkNovoCliente" runat="server" OnClick="lnkNovoCliente_OnClick" Text="Novo"></asp:LinkButton>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtReceberData" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtReceberValor" runat="server" Width="80px"></asp:TextBox>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtReceberObs" runat="server" Width="150px" MaxLength="149"></asp:TextBox>
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddlReceberForma" runat="server" Width="120">
                                            <asp:ListItem Text="Depósito" Value="Depósito"></asp:ListItem>
                                            <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                            <asp:ListItem Text="Cartão" Value="Cartão"></asp:ListItem>
                                            <asp:ListItem Text="Boleto" Value="Boleto"></asp:ListItem>
                                            <asp:ListItem Text="Dinheiro" Value="Dinheiro"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td valign="top"><asp:TextBox ID="txtReceberBanco" runat="server" Width="100px" Text="Itaú"></asp:TextBox></td>
                                    <td valign="top">
                                        <asp:Button ID="btnReceberInserir" runat="server" Text="Inserir" OnClick="btnReceberInserir_Click" />
                                        <asp:Button ID="btnReceberCancelar" runat="server" Text="Cancelar" OnClick="btnReceberCancelar_Click" />
                                    </td>
                                </tr>
                            </table>
                            <hr />
                            <div runat="server" id="divCliente" visible="false">
                                Nome <asp:TextBox runat="server" ID="txtNovoNome" Width="200px"></asp:TextBox>
                                <asp:Button ID="btnNovoClienteInserir" runat="server" Text="Inserir" OnClick="btnNovoClienteInserir_Click" />
                                <asp:Button ID="btnNovoClienteCancelar" runat="server" Text="Cancelar" OnClick="btnNovoClienteCancelar_Click" />
                                <hr />
                            </div>
                        </div>
                    </div>
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
                            <asp:TemplateField HeaderText="Forma">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormaPagto" runat="server" Text='<%# Eval("FormaPagto") %>'></asp:Label>
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
                                    <asp:Label ID="lblTreinamento" Text='<%# Eval("Descricao") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detalhes recebimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetalhes" runat="server" Font-Size="X-Small" Width="150px"></asp:Label>
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
                            <asp:TemplateField HeaderText="Valor Líquido" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValorRecebido" runat="server" Width="80px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBanco" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data Recebimento" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDtRecebimento" runat="server" Width="50px"></asp:TextBox>
                                    <asp:LinkButton ID="btnReceber" runat="server" OnClick="btnReceber_Click" Text="receber" />
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
