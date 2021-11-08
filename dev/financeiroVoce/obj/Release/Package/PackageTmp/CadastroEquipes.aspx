<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEquipes.aspx.cs"
    Inherits="financeiroVoce.CadastroEquipes" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Equipes - Instituto Você</title>
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
                    <td colspan="2">
                        <center>
                            <table border="0">
                                <tr>
                                    <td width="200px">
                                        <img src="./images/logo.png" alt="logo" />
                                    </td>
                                    <td width="500px">
                                        <h1>
                                            Cadastro de Equipes</h1>
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
                    <td width="600px" style="border-right-style: dotted; border-right-color: Gray;">
                        <div>
                            <h2>
                                Equipes Cadastradas</h2>
                            <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                OnRowDataBound="grdEquipes_RowDataBound" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Equipe") %>' Width="200"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Telefone" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelefone" runat="server" Text='<%# Eval("Telefone") %>' Width="100"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E-mail" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Obs" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblObs" runat="server" Text='<%# Eval("Obs") %>' Width="150"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inativo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkInativo" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alterar">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDEquipe" runat="server" />
                                            <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" ImageUrl="~/images/alterar.jpg" OnClientClick="javascript:topo();" />
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
                            <h2>
                                <b>
                                    <asp:Label ID="lblTitulo" runat="server" Text="Inserir" /></b></h2>
                            <table>
                                <tr>
                                    <td>
                                        Equipe
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEquipe" runat="server" Width="200" />
                                        <asp:HiddenField ID="hdnIDEqp" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Telefone
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtTelefone" runat="server" Width="200" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        E-mail
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="200" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Observações
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtObs" runat="server" Width="200" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Inativo
                                    </td>
                                    <td align="left">
                                        <asp:CheckBox ID="chkStatus" runat="server" Checked="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
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
