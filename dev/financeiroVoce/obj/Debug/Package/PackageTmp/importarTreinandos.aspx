<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importarTreinandos.aspx.cs"
    Inherits="financeiroVoce.importarTreinandos" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Importar treinandos - Instituto Você</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/Theme1/style.css" />

    <script language="javascript" type="text/javascript">
        function exibirPop() {
            document.getElementById('divFundo').style.display = 'block';
        }
        function exibirSalvar() {
            document.getElementById('divSalvar').style.display = 'block';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table border="0">
            <tr>
                <td colspan="2">
                    <center>
                        <table border="0">
                            <tr>
                                <td width="200px">
                                    <img src="./images/logo.png" alt="logo" />
                                </td>
                                <td width="900px" align="center">
                                    <b>Importar Treinandos</b><br />
                                    Selecione o treinamento
                                <asp:DropDownList ID="ddlTreinamento" runat="server" Width="155" />
                                    <br />
                                    Selecione o Excel
                                <asp:FileUpload ID="FileUploadControl" runat="server" />
                                    <asp:Button ID="btnFiltrarTreinamento" runat="server" Text="clique para importar"
                                        OnClick="btnFiltrarTreinamento_Click" OnClientClick="javascript:exibirPop();" />
                                </td>
                                <td>
                                    <a id="A1" href="Default.aspx">Menu Principal</a>
                                </td>
                            </tr>
                        </table>
                    </center>
                    <hr />
                </td>
            </tr>
        </table>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>
                <div id="divFundo" class="divFundo">
                    <h2 style="color: White;">Importando...</h2>
                </div>
                <div id="divSalvar" class="divFundo">
                    <h2 style="color: White;">Salvando...</h2>
                </div>
                <table border="0">
                    <tr valign="top">
                        <td width="520px" style="border-right-style: dotted; border-right-color: Gray;">
                            <div>
                                <h2>Treinandos Cadastrados</h2>
                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
                                -
                            <asp:LinkButton ID="lnkComparar" runat="server" Text="Comparar Listas" OnClick="lnkComparar_OnClick"
                                Visible="false"></asp:LinkButton><br />
                                <asp:GridView ID="grdEquipes" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Width="250"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEquipe" runat="server" Text='<%# Eval("Equipe") %>' Width="100"
                                                    Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlTreinamentoNovo" runat="server" Width="100" Visible="false" />
                                                <asp:ImageButton ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" Visible="false"
                                                    ImageUrl="~/images/atualizar.jpg" />
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
                            <h2>Treinandos Importados</h2>
                            <asp:Label ID="lblTotalExcel" runat="server" ForeColor="Red"></asp:Label>
                            -
                        <asp:LinkButton ID="lnkSalvar" runat="server" Text="Salvar treinandos!" OnClick="lnkSalvar_OnClick"
                            OnClientClick="javascript:exibirSalvar();" Visible="false"></asp:LinkButton><br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10pt"
                                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnIDTreinandoImportado" runat="server" Value="0" />
                                            <asp:Label ID="lblNomeImportado" runat="server" Width="400"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Equipe" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlEquipe" runat="server" Width="150" />
                                            <asp:HiddenField ID="hdnIDEquipe" runat="server" Value="0" />
                                            <asp:Label ID="lblConsultor" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Crachá" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCracha" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblArquetipo" runat="server"></asp:Label>
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
                        </td>
                    </tr>
                </table>
                <hr />
                <span style="color: Red;">Procedimentos para importação do app do instituto:<br />
                    1) Exporte do app sempre a Listagem Completa com indicador IV (mesmo que não seja
                o Diamond);
                <br />
                    2) Salve na área de trabalho (não precisa mudar o nome);<br />
                    3) Abra o arquivo exportado no Excel<br />
                    4) Arrume o arquivo excluindo linhas em branco e muito cuidado com o caractere " ' " (apóstrofo) caso tenha algum nome, favor remover e clique na opção Salvar Como;
                <br />
                    Obs.: Atenção na hora de salvar para selecionar o Tipo 'Pasta de Trabalho do Excel 97-2003
                (*.xls)" e salvar na pasta Z:\treinamentos;<br />
                    5) Depois de salvo, selecione o Treinamento na parte superior da página e;<br />
                    Obs2.: Este procedimento funciona "melhor" no navegador Mozilla  Firefox (raposa)<br />
                    6) Selecione o arquivo do Excel salvo na pasta Z:\treinamentos. </span>
                <asp:Label runat="server" ID="lblResultado" ForeColor="Red"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
