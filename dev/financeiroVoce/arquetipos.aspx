<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="arquetipos.aspx.cs" Inherits="financeiroVoce.arquetipos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alterar arquétipos dos Treinamentos - Instituto PNL</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />
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
                            <h1>
                                Alterar arquétipos dos próximos Treinamentos</h1>
                            Selecione o treinamento
                            <asp:DropDownList ID="ddlTreinamento" runat="server" Width="155" />
                            <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="Carregar" OnClick="btnFiltrarTreinamento_Click" />
                        </td>
                        <td align="center">
                            <a id="A1" href="Default.aspx">Menu Principal</a>
                        </td>
                    </tr>
                </table>
            </center>
                <br />
                <hr />
                <br />
                <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="12pt"
                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnIDTreinando" runat="server" Value='<%# Eval("IDTreinando") %>' />
                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="500px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Crachá">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCracha" runat="server" Text='<%# Eval("Cracha") %>' Width="200px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox ID="txtArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Width="200px"></asp:TextBox>
                                <asp:ImageButton ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" ImageUrl="~/images/salvar.jpg" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
