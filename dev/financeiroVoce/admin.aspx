<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="financeiroVoce.admin" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - PNL Financeiro</title>
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
                            Administrador</h1>
                    </td>
                    <td width="20%">
                        <a id="A1" href="Default.aspx">Menu Principal</a>
                    </td>
                </tr>
            </table>
            <h2>
                Inserir novo usuário</h2>
            <table>
                <tr>
                    <td>
                        Nome
                        <asp:TextBox runat="server" ID="txtNome" Width="400px" Font-Size="Larger"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="imgInserir" runat="server" ImageUrl="~/images/mais.png" OnClick="imgInserir_OnClick" />
                        <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/images/cancelar.png"
                            OnClick="imgCancelar_OnClick" />
                    </td>
                </tr>
            </table>
            <hr />
            <h2>
                Usuários cadastrados</h2>
            <asp:GridView ID="grdDetalhes" runat="server" AutoGenerateColumns="False" Font-Size="12pt"
                OnRowDataBound="grdDetalhes_RowDataBound" CellPadding="4" ForeColor="#333333"
                GridLines="None">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Usuário">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Usuario") %>' Width="150"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contas a receber" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkReceber" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contas a pagar" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkPagar" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Compras" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCompras" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estoque" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEstoque" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cobrança" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCobranca" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Admin" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAdm" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Salvar Permissões" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgSalvar" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="imgSalvar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnIDusuario" Value='<%# Eval("IDUsuario") %>' runat="server" />
                            <asp:LinkButton ID="lnkZerar" runat="server" Text="zerar senha" OnClick="lnkZerar_Click"></asp:LinkButton>
                            -
                            <asp:LinkButton ID="lnkRemover" runat="server" Text="remover acesso" OnClick="lnkRemover_Click"></asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
