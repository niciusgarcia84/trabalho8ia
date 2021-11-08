<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaidasKit.aspx.cs" Inherits="financeiroVoce.SaidasKit" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kit - Instituto Você</title>
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
                                    <td width="500px">
                                        <h1>
                                            Saídas utilizando Kits</h1>
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
                    <td width="450px" style="border-right-style: dotted; border-right-color: Gray;">
                        <div>
                            <h2>
                                Kits Cadastrados</h2>
                            <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Kit" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKit" runat="server" Text='<%# Eval("Descricao") %>' Width="200"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDKit" runat="server" Value='<%# Eval("IDKit") %>' />
                                            <asp:LinkButton ID="lnkEditar" runat="server" OnClick="btnAlterar_Click" Text="Editar - "></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUtilizar" runat="server" OnClick="lnkUtilizar_OnClick" Text=" Utilizar"></asp:LinkButton>
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
                                        Descrição
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKit" runat="server" Width="200" />
                                        <asp:HiddenField ID="hdnIDKitAlteracao" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="btnInserir" runat="server" OnClick="btnInserir_Click" ImageUrl="~/images/ok.png" />
                                        <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" ImageUrl="~/images/cancelar.png"
                                            Visible="false" />
                                        <asp:ImageButton ID="btnOcultar" runat="server" OnClick="btnOcultar_Click" ImageUrl="~/images/excluir.png"
                                            Visible="false" />
                                    </td>
                                </tr>
                            </table>
                            <div id="divInserir" runat="server" visible="false">
                                <h2>
                                    Inserir novo produto no kit</h2>
                                Selecione o produto
                                <asp:DropDownList ID="ddlProduto" runat="server" />
                                <asp:LinkButton ID="lnkInserirProduto" runat="server" OnClick="lnkInserirProduto_OnClick"
                                    Text="Inserir"></asp:LinkButton>
                                <br />
                                <h2>
                                    Produtos no kit</h2>
                                <asp:GridView ID="grdProduto" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDItemKit" runat="server" Value='<%# Eval("IDItemKit") %>' />
                                                <asp:LinkButton ID="lnkExcluir" runat="server" OnClick="lnkExcluir_Click" Text="remover do kit"></asp:LinkButton>
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
                        <div id="divUtilizar" runat="server" visible="false">
                            <h2>
                                Saída no estoque</h2>
                            <p>
                                Informe abaixo a quantidade desse kit que deve ser baixada<br /> no estoque e qual o treinamento
                                que utilizou</p>
                            <h2>
                                <asp:Label ID="lblKitSair" runat="server"></asp:Label></h2>
                            <table>
                                <tr>
                                    <td>
                                        Quantidade
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuantidade" runat="server" Width="146px"></asp:TextBox>
                                    </td>
                                    <td rowspan="2">
                                        <asp:HiddenField ID="hdnIDKitSaida" runat="server" />
                                        <asp:ImageButton ID="imgSalvar" runat="server" OnClick="btnSalvar_Click" ImageUrl="~/images/ok.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Treinamento
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTreinamento" runat="server" Width="150" />
                                    </td>
                                </tr>
                            </table>
                            <h2>
                                Produtos no Kit</h2>
                            <asp:GridView ID="grdSaida" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDProduto" runat="server" Value='<%# Eval("IDProduto") %>' />
                                            <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("nmProduto") %>'></asp:Label>
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
