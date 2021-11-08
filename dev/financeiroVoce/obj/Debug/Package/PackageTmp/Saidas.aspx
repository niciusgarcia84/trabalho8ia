<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saidas.aspx.cs" Inherits="financeiroVoce.Saidas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Saídas - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td colspan="2">
                            <center>
                                <table border="0">
                                    <tr>
                                        <td width="200px">
                                            <img src="./images/logo.png" alt="logo" />
                                        </td>
                                        <td width="800px" align="center">
                                            <h1>Saídas do Estoque</h1>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="lnkEstornar" runat="server" Text="Retornar Produto - " OnClick="lnkEstornar_Click"></asp:LinkButton>
                                            <a id="A1" href="Default.aspx">Menu Principal</a>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <hr />
                        </td>
                    </tr>
                    <tr valign="top">
                        <td width="400px" style="border-right-style: dotted; border-right-color: Gray;">
                            <div id="divCadastrar" runat="server">
                                <h2>
                                    <b>
                                        <asp:Label ID="lblTitulo" runat="server" Text="Saída do Estoque" /></b></h2>
                                <table>
                                    <tr>
                                        <td>Produto
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlProduto" runat="server" Width="250" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Quantidade
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtQuantidade" runat="server" Width="245" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Observações
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObservacoes" runat="server" Width="245" MaxLength="199" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Treinamento
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkAtribuir" runat="server" OnClick="lnkAtribuir_Click" Text=" - Atribuir"></asp:LinkButton>
                                            <asp:DropDownList ID="ddlTreinamento" runat="server" Width="150" Visible="false" />
                                            <asp:LinkButton ID="lnkCancelar" runat="server" OnClick="lnkCancelar_Click" Text="- Não Atribuir"
                                                Visible="false"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Equipe
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkEquipe" runat="server" OnClick="lnkEquipeAtribuir_Click" Text=" - Atribuir"></asp:LinkButton>
                                            <asp:DropDownList ID="ddlEquipe" runat="server" Width="150" Visible="false" />
                                            <asp:LinkButton ID="lnkEquipeCancelar" runat="server" OnClick="lnkEquipeCancelar_Click"
                                                Text="- Não Atribuir" Visible="false"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="btnInserir" runat="server" OnClick="btnInserir_Click" ImageUrl="~/images/ok.png" />
                                            <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/cancelar.png" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <div id="divRetorno" runat="server" visible="false">
                                    <hr />
                                    <br />
                                    <h2>Retornar mercadoria para o estoque</h2>
                                    <table>
                                        <tr>
                                            <td>Produto
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlProduto2" runat="server" Width="250" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Quantidade
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtQtdeRetorno" runat="server" Width="245" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Observações
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtObsretorno" runat="server" Width="245" MaxLength="199" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Treinamento
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlTreinamentoRetorno" runat="server" Width="150" Visible="false" />
                                                <asp:LinkButton ID="lnkAtribuirRetorno" runat="server" OnClick="lnkAtribuirRetorno_Click" Text=" - Atribuir"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Equipe
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlEquipeRetorno" runat="server" Width="150" Visible="false" />
                                                <asp:LinkButton ID="lnkEquipeRetorno" runat="server" OnClick="lnkEquipeRetorno_Click" Text=" - Atribuir"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnInserirRetorno_Click"
                                                    ImageUrl="~/images/ok.png" />
                                                <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnCancelarRetorno_Click"
                                                    ImageUrl="~/images/cancelar.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                        <td style="padding-left: 10px;">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Consultar Saídas por Treinamento</h2>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTreinamento2" runat="server" Width="150" />
                                            <asp:Button ID="btnFiltrar" runat="server" Text="Exibir" OnClick="btnFiltrar_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="lblTotalTreinamento" runat="server"></asp:Label>
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipo" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtSaida" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnIDSaida" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' Width="200"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("obs") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qtde" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtde" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValor" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Devolver">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDevolver" runat="server" OnClick="btnDevolver_Click" Text="Devolver"></asp:LinkButton>
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
                                <hr />
                                <table>
                                    <tr>
                                        <td>
                                            <h2>Consultar Saídas por Equipe</h2>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEquipe2" runat="server" Width="150" />
                                            <asp:Button ID="btnFiltrarEquipe" runat="server" Text="Exibir" OnClick="btnFiltrarEquipe_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="lblTotalEquipe" runat="server"></asp:Label>
                                <asp:GridView ID="grdItensEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    OnRowDataBound="grdItensEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                    GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipo" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblData" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>' Width="200"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblObs" runat="server" Text='<%# Eval("obs") %>' Width="200"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qtde" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQtde" runat="server" Width="100"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Devolver">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDSaida" runat="server" />
                                                <asp:LinkButton ID="btnDevolver" runat="server" OnClick="btnDevolverEquipe_Click" Text="Devolver"></asp:LinkButton>
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
                    </tr>
                </table>
                <asp:Label runat="server" ID="lblResultado" ForeColor="Red"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
