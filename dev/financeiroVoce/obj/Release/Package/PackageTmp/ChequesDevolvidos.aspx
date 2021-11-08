<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChequesDevolvidos.aspx.cs"
    Inherits="financeiroVoce.ChequesDevolvidos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheques Devolvidos - Instituto Você</title>
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
            <div id="divEditarPerfil" runat="server" visible="false">
                <div id="fundo">
                    &nbsp;</div>
                <div id="internoCobranca">
                    <div id="divRelatorios" runat="server" visible="false">
                        <h2>
                            Relatórios</h2>
                        <p>
                            <asp:LinkButton ID="lnkRelatorioDevolvidos" runat="server" Text="Cheque Devolvidos por período"
                                OnClick="lnkRelatorioDevolvidos_OnClick"></asp:LinkButton></p>
                        <p>
                            <asp:LinkButton ID="lnkRelatorioRecuperados" runat="server" Text="Cheque Recuperados por período (Comissão de Cobrança)"
                                OnClick="lnkRelatorioRecuperados_OnClick"></asp:LinkButton></p>
                        <p>
                            <asp:LinkButton ID="lnkRelatorioInteracoes" runat="server" Text="Interações por período"
                                OnClick="lnkRelatorioInteracoes_OnClick"></asp:LinkButton></p>
                        <br />
                    </div>
                    <div id="divRecuperar" runat="server" visible="false">
                        <h2>
                            Cheque Recuperado</h2>
                        <table>
                            <tr>
                                <td>
                                    Responsável
                                </td>
                                <td>
                                    <asp:Label ID="lblRecResponsavel" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cheque
                                </td>
                                <td>
                                    <asp:Label ID="lblRecCheque" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vencimento
                                </td>
                                <td>
                                    <asp:Label ID="lblRecVencimento" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Valor
                                </td>
                                <td>
                                    <asp:Label ID="lblRecValor" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <h2>
                            Dados do depósito</h2>
                        <asp:HiddenField ID="hdnRecIDPagto" runat="server" />
                        <asp:HiddenField ID="hdnRecIDLista" runat="server" />
                        <table>
                            <tr>
                                <td>
                                    Data do Recebimento
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepData" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Valor
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepValor" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Titular
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepTitular" runat="server" Width="200px" MaxLength="74"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Banco
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepBanco" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="btnSalvarRecuperar" runat="server" OnClick="btnSalvarRecuperar_OnClick"
                                        ImageUrl="~/images/ok.png" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divHistorico" runat="server" visible="false">
                        <h2>
                            Histórico do Cheque</h2>
                        <table>
                            <tr>
                                <td>
                                    Responsável
                                </td>
                                <td>
                                    <asp:Label ID="lblHistoricoResponsavel" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cheque
                                </td>
                                <td>
                                    <asp:Label ID="lblHistoricoCheque" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <p>
                            Intereções realizadas com o cheque</p>
                        <asp:GridView ID="grdHistorico" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                            OnRowDataBound="grdHistorico_RowDataBound" CellPadding="4" ForeColor="#333333"
                            GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblData" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observação" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="550px" Font-Size="Small"></asp:Label>
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
                        <hr />
                        <p>
                            Insira abaixo novas informações</p>
                        <asp:HiddenField ID="hdnHistoricoIDPagto" runat="server" />
                        <asp:TextBox ID="txtHistoricoNovasObservacoes" runat="server" Width="400px" MaxLength="249"></asp:TextBox>
                        <asp:LinkButton ID="lnkInserirHistorico" runat="server" Text="Salvar" OnClick="lnkInserirHistorico_OnClick"></asp:LinkButton>
                        <br />
                        <br />
                    </div>
                    <div style="width: 100%; text-align: right;">
                        <asp:ImageButton ID="brnFecharOrca" runat="server" OnClick="brnFechaEditar_OnClick"
                            ImageUrl="~/images/cancelar.png" /></div>
                </div>
            </div>
            <div style="width: 1100px;" id="inicio">
                <center>
                    <table border="0">
                        <tr>
                            <td width="200px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="500px" align="center">
                                <h1>
                                    Cheques Devolvidos</h1>
                            </td>
                            <td width="500px" valign="middle" align="right">
                                <asp:LinkButton ID="lnkRelatorios" runat="server" Text="Relatórios" OnClick="imgMenu_OnClick"></asp:LinkButton>
                                -
                                <asp:LinkButton ID="lnkPendente" runat="server" Text="Tornar Pendente" OnClick="lnkPendente_Click"></asp:LinkButton>
                                - <a id="A2" href="Default.aspx">Menu Principal</a>
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
                <br />
                A lista abaixo está exibindo os cheques devolvidos com vencimento entre
                <asp:TextBox ID="txtDatamin" runat="server" Width="70"></asp:TextBox>
                e
                <asp:TextBox ID="txtDatamax" runat="server" Width="70"></asp:TextBox>
                <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnBuscar_Click" />
                <br />
                <br />
                <b>Lista de cheques</b> -
                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="grdContas" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                    OnRowDataBound="grdContas_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVencimento" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIDPagto" runat="server" />
                                <asp:HiddenField ID="hdnIDLista" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblValorParcela" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Treinando" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblTreinando" runat="server" Text='<%# Eval("Nome") %>' Width="120px"
                                    Font-Size="X-Small"></asp:Label>
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
                        <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblEquipe" Text='<%# Eval("Equipe") %>' runat="server" Width="120px"
                                    Font-Size="X-Small"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalhes recebimento" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDetalhes" runat="server" Font-Size="X-Small" Width="150px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnHistorico" runat="server" OnClick="btnHistorico_Click" Text="Histórico" OnClientClick="javascript:topo();" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Destino" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlDestino" runat="server" Width="100">
                                    <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Patrícia" Value="patricia"></asp:ListItem>
                                    <asp:ListItem Text="Francine" Value="fran"></asp:ListItem>
                                    <asp:ListItem Text="Teresa" Value="teresa"></asp:ListItem>
                                    <asp:ListItem Text="Dr. Felipe" Value="drFelipe"></asp:ListItem>
                                    <asp:ListItem Text="Dra. Graça" Value="drGraca"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ImageButton ID="btnSalvarDestino" runat="server" OnClick="btnSalvarDestino_Click"
                                    ImageUrl="~/images/salvar.jpg" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRecuperar" runat="server" OnClick="btnRecuperar_Click" Text="Recuperar" />
                                <asp:LinkButton ID="btnDevolver" runat="server" OnClick="btnDevolver_Click" Text="Devolver"
                                    Visible="false" />
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
