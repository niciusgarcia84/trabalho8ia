<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="montarDiamond.aspx.cs"
    Inherits="financeiroVoce.montarDiamond" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Montar equipe de Diamonds - Instituto PNL</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function exibirPop()
        {
            document.getElementById('divFundo').style.display = 'block';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div id="divFundo" class="divFundo">
                <h2 style="color:White;">Aguarde alguns segundos que os grupos estão sendo montados.</h2>
            </div>
            <center>
                <table border="0" width="100%" id="inicio">
                    <tr>
                        <td width="300px">
                            <img src="./images/logo.png" alt="logo" />
                        </td>
                        <td width="700px" align="center">
                            <h1>
                                Montar equipes</h1>
                            Próximos treinamentos
                            <asp:DropDownList ID="ddlTreinamento" runat="server" Width="155" />
                            <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="Carregar" OnClick="btnFiltrarTreinamento_Click" />
                        </td>
                        <td align="center">
                            <a id="A1" href="Default.aspx">Menu Principal</a>
                        </td>
                    </tr>
                </table>
            </center>
            <div id="divResumo" runat="server" visible="false">
                <hr />
                Informe a quantidade de grupos que deseja (máximo 10)
                <asp:TextBox runat="server" ID="txtQtdeGrupos" Width="50"></asp:TextBox>
                <asp:Button ID="btnSeparar" runat="server" Text="Salvar e gerar grupos" OnClick="btnSeparar_Click" OnClientClick="javascript:exibirPop();" />
                <hr />
                <h1>
                    Resumo do treinamento</h1>
                Total de treinandos
                <asp:Label ID="lblTotalTreinandos" runat="server" ForeColor="Red"></asp:Label>
                <table>
                    <tr valign="top">
                        <td>
                            <h2>
                                Arquétipos</h2>
                            <table border="1">
                                <tr>
                                    <td>
                                        Administrador
                                    </td>
                                    <td width="70">
                                        <asp:Label ID="lblA1" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Articulador
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA2" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Artista
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA3" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ator
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA4" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Cientista
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA5" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Cuidador
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA6" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Educador
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA7" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Empreendredor
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA8" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Encantador
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA9" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Executor
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA10" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Idealista
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA11" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Líder
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA12" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mestre
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA13" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Regulador
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA14" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tutor
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA15" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Visionário
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA16" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <h2>
                                Subtipos</h2>
                            <table border="1">
                                <tr>
                                    <td>
                                        Cérebro
                                    </td>
                                    <td width="70">
                                        <asp:Label ID="lblTotalA" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Coração
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalB" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Aberto
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalC" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fechado
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalD" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Projeções
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalE" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fatos
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalF" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Geral
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalG" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Detalhes
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalH" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <hr />
                <table>
                    <tr>
                        <td>
                            <h1>
                                <asp:Label ID="lblTreinamento" runat="server"></asp:Label></h1>
                        </td>
                        <td>
                            <asp:Button ID="btnOrdenar" runat="server" Text="ordenar" OnClick="btnOrdenar_Click" />
                            <span style="font-size: small;"><i>Obs.: trabalhar com exceções de 1 a 3 =)</i></span>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="10pt" OnRowDataBound="grdTreinandos_RowDataBound"
                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                            <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Equipe") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cérebro" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblA" runat="server" Text='<%# Eval("Cerebro") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Coração" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblB" runat="server" Text='<%# Eval("Coracao") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aberto" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblC" runat="server" Text='<%# Eval("Aberto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fechado" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblD" runat="server" Text='<%# Eval("Fechado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Projeções" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblE" runat="server" Text='<%# Eval("Projecoes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fatos" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblF" runat="server" Text='<%# Eval("Fatos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Geral" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblG" runat="server" Text='<%# Eval("Geral") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Detalhes" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblH" runat="server" Text='<%# Eval("Detalhes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Restrição" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="txtExcessao" runat="server" Text='<%# Eval("Excecao") %>' Width="80px"></asp:TextBox>
                            <asp:ImageButton ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" ImageUrl="~/images/salvar.jpg" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:Label ID="lblOrdem" runat="server" ForeColor="White"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
