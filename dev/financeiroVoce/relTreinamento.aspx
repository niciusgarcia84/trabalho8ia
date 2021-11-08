<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relTreinamento.aspx.cs"
    Inherits="financeiroVoce.relTreinamento" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório do Treinamento - Instituto PNL</title>
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
                <center>
                    <table border="0" width="100%" id="inicio">
                        <tr>
                            <td width="300px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="700px" align="center">
                                <h1>Relatório do Treinamento</h1>
                                <div id="divMenuOpcoes" runat="server">
                                    Últimos 20 treinamentos
                                <asp:DropDownList ID="ddlTreinamento" runat="server" Width="155" />
                                    <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="Carregar" OnClick="btnFiltrarTreinamento_Click" />
                                    <br />
                                    <br />
                                    <asp:LinkButton ID="lnkAntigos" runat="server" Text="Clique aqui para carregar todos os treinamentos"
                                        OnClick="lnkAntigos_OnClick"></asp:LinkButton>
                                </div>
                                <div id="divLabel" runat="server" visible="false">
                                    <asp:LinkButton ID="lnkVoltar" runat="server" Text="Clique aqui para exibir outros treinamentos"
                                        OnClick="lnkVoltar_OnClick"></asp:LinkButton>
                                </div>
                            </td>
                            <td align="center">
                                <a id="A2" href="relTreinamentoEmAberto.aspx">Financeiro em aberto</a> - 
                            <a id="A1" href="Default.aspx">Menu Principal</a><br />
                                <a id="A4" href="equipesDiamonds.aspx">Exibir / </a>
                                <a id="A3" href="montarDiamond.aspx">Montar equipe Diamond</a><br />
                                <a id="A2" href="relTreinamentoPorEquipe.aspx">Relatório por Equipe</a>
                            </td>
                        </tr>
                    </table>
                </center>
                <div id="divAntigos" runat="server" visible="false">
                    <hr />
                    <asp:GridView ID="grdTreinamentos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Treinamento">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTreinamento" runat="server" OnClick="lnkTreinamento_OnClick"
                                        OnClientClick="javascript:topo();" Text='<%# Eval("Descricao") %>'></asp:LinkButton>
                                    <asp:HiddenField ID="hdnIDTreinamento" Value='<%# Eval("IDTreinamento") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
                <hr />
                <div id="divLista" runat="server" visible="false">
                    <h1>
                        <asp:Label ID="lblTreinamento" runat="server"></asp:Label><asp:HiddenField ID="hdnTreinamento" runat="server" /></h1>
                    <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdTreinandos_RowDataBound" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgFechado" ImageUrl="~/images/cadFechadoMini.png"
                                        Visible="false" />
                                    <asp:ImageButton runat="server" ID="imgAberto" ImageUrl="~/images/cadAbertoMini.png"
                                        Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="150"></asp:Label>
                                    <asp:HiddenField ID="hdnInvestimento" runat="server" />
                                    <asp:HiddenField ID="hdnInvest" runat="server" />
                                    <asp:HiddenField ID="hdnAusente" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma Pagto" ItemStyle-Font-Size="X-Small">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetalhePagto" runat="server" Width="200" Text='<%# Eval("DetalhePagto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Investimento" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPagto" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Desconto" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesconto" Width="100" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crédito/Obs">
                                <ItemTemplate>
                                    <asp:Label ID="lblObs" runat="server" Font-Size="Smaller" Text='<%# Eval("Credito") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblEquipe" runat="server" Width="75" Text='<%# Eval("Equipe") %>'
                                        Font-Size="Smaller"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
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
                    <h2>Resumo Financeiro</h2>
                    <asp:LinkButton ID="lnkDetalhes" runat="server" OnClick="lnkDetalhes_OnClick" Text="Clique para ver detalhes" Font-Size="Small"></asp:LinkButton>
                    <asp:GridView ID="grdForma" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                        CellPadding="3" OnRowDataBound="grdForma_RowDataBound" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Forma Pagto">
                                <ItemTemplate>
                                    <asp:Label ID="lblForma" runat="server" Text='<%# Eval("FormaPagto") %>' Width="150"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Soma" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSoma" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <br /><br />
                    <asp:Label ID="lblInvest" runat="server" ForeColor="Orange"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblTotalValor" runat="server" ForeColor="Green"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblTotalCredito" runat="server" ForeColor="Blue"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblTotalDescontos" runat="server" ForeColor="Gray"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblTotalReceber" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </div>
                <hr />
            <table>
                <tr>
                    <td>Legenda</td>
                    <td style="color: white; background-color: purple;">Ausente</td>
                    <td style="color: white; background-color: orange;">Investimento</td>
                    <td style="color: white; background-color: green;">Experiente</td>
                    <td style="color: black; background-color: yellow;">Sem financeiro</td>
                    <td style="color: white; background-color: red;">financeiro parcial</td>
                    <td style="color: black; background-color: cyan;">sem carta de autorização</td>
                </tr>
            </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
