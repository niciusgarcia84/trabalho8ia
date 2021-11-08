<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admContas.aspx.cs" Inherits="financeiroVoce.admContas" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Contas - Você Financeiro</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <table border="0" width="60%">
                <tr>
                    <td width="20%">
                        <asp:ImageButton ID="imgMenu" runat="server" ImageUrl="~/images/logo.png" />
                    </td>
                    <td width="260px" align="center">
                        <h1>
                            Administrador - Contas</h1>
                    </td>
                    <td width="20%">
                        <a id="A1" href="Default.aspx">Menu Principal</a>
                    </td>
                </tr>
            </table>
            <hr />
            <br />
            <asp:Label ID="lblSaldo" runat="server" ForeColor="Red"></asp:Label><span style="font-size:small;"> (somando todos os créditos e subtraindo todos os débitos.)</span>
            <br /><br />
            <hr />
            <h2>
                Contas Cadastradas no período</h2>
            Filtre as contas informando a data inicial
            <asp:TextBox ID="txtDtInicial" runat="server" Width="80px"></asp:TextBox>
            e data final
            <asp:TextBox ID="txtDtFinal" runat="server" Width="80px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnAtualizarData" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" /><br /><br />
            <asp:GridView ID="grdDetalhes" runat="server" AutoGenerateColumns="False" Font-Size="12pt"
                OnRowDataBound="grdDetalhes_RowDataBound" CellPadding="4" ForeColor="#333333"
                GridLines="None">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Data" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblData" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição">
                        <ItemTemplate>
                            <asp:Label ID="lblDescrição" runat="server" Text='<%# Eval("Descricao") %>' Width="400"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMenos" runat="server" Visible="false" Text="(-) "></asp:Label>
                            <asp:HiddenField ID="hdnStatus" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblValor" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ControlStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnContas" runat="server" Value='<%# Eval("IDAdmContas") %>' />
                            <asp:LinkButton ID="lnkRemover" runat="server" Text="remover conta" OnClick="lnkRemover_Click"></asp:LinkButton>
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
            <asp:Label ID="lblCreditos" runat="server" ForeColor="Blue" Font-Size="Larger"></asp:Label>,<asp:Label
                ID="lblDebitos" runat="server" ForeColor="Red" Font-Size="Larger"></asp:Label><asp:Label
                    ID="lblTotal" runat="server" ForeColor="Green" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            <hr />
            <table>
                <tr>
                    <td width="200px">
                        <h2>
                            Inserir nova conta</h2>
                    </td>
                    <td>
                        <asp:ImageButton ID="imgMais" runat="server" ImageUrl="~/images/mais.png" OnClick="imgAdicionar_OnClick" />
                    </td>
                </tr>
            </table>
            <div id="divAdd" runat="server" visible="false">
                <table>
                    <tr>
                        <td colspan="3">
                            Descrição
                            <asp:TextBox runat="server" ID="txtDescricao" Width="300px" MaxLength="149"></asp:TextBox>
                        </td>
                        <td rowspan="2" width="150px" align="right">
                            <asp:ImageButton ID="imgInserir" runat="server" ImageUrl="~/images/mais.png" OnClick="imgInserir_OnClick" />
                            <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/images/cancelar.png"
                                OnClick="imgCancelar_OnClick" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data
                            <asp:TextBox runat="server" ID="txtData" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            Valor
                            <asp:TextBox runat="server" ID="txtValor" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbStatus" runat="server">
                                <asp:ListItem Text="Débito" Value="Debito" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Crédito" Value="Credito"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
