<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="equipesDiamonds.aspx.cs"
    Inherits="financeiroVoce.equipesDiamonds" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Equipes de Diamonds - Instituto Você</title>
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
                <div id="fundoDiamond" runat="server" visible="false">
                    <div id="divCor" class="internoDiamond" runat="server" visible="false">
                        <center>
                            <h2>Torcar cor do grupo
                            <asp:Label ID="lblMudarEquipe1" runat="server"></asp:Label></h2>
                            com a cor do grupo
                        <asp:DropDownList ID="ddlGrupoMudar" runat="server" Width="120px">
                            <asp:ListItem Text="Grupo 1" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Grupo 2" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Grupo 3" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Grupo 4" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Grupo 5" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Grupo 6" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Grupo 7" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Grupo 8" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Grupo 9" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Grupo 10" Value="9"></asp:ListItem>
                        </asp:DropDownList>
                        </center>
                        <br />
                        <br />
                        <div style="margin-left: 180px;">
                            <asp:ImageButton ID="btnSalvarCorGrupo" runat="server" ImageUrl="~/images/ok.png"
                                OnClick="btnSalvarCorGrupo_OnClick" />
                            <asp:ImageButton ID="btnCancelarMudarCor" runat="server" ImageUrl="~/images/cancelar.png"
                                OnClick="btnCancelarMudarCor_OnClick" />
                        </div>
                    </div>
                    <div id="divLider" class="internoDiamond" runat="server" visible="false">
                        <center>
                            <h2>Selecione o Líder, Vice Líder e Bandeira do Grupo
                            <asp:Label ID="lblMudarLider" runat="server"></asp:Label></h2>
                            <br />
                            <table>
                                <tr>
                                    <td>Líder
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlLider" runat="server" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Vice Líder
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlVice" runat="server" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bandeira
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBandeira" runat="server" Width="220px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <br />
                        <br />
                        <div style="margin-left: 180px;">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/ok.png" OnClick="btnSalvarLider_OnClick" />
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/cancelar.png"
                                OnClick="btnCancelarMudarCor_OnClick" />
                        </div>
                    </div>
                    <div id="divStatus" class="internoDiamond" runat="server" visible="false">
                        <center>
                            <h2>Selecione a função do treinando (Líder, Vice Líder ou Bandeira) do Grupo
                            <asp:Label ID="lblMudarStatus" runat="server"></asp:Label></h2>
                            <br />
                            <table>
                                <tr>
                                    <td>Treinando
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnIDMudarStatus" runat="server" />
                                        <asp:Label ID="lblNomeMudarStatus" runat="server" Font-Size="Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Status
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMudarStatus" runat="server" Width="220px">
                                            <asp:ListItem Text="Líder" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Vice-Líder" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Bandeira" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </center>
                        <br />
                        <br />
                        <div style="margin-left: 180px;">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/ok.png" OnClick="btnSalvarStatus_OnClick" />
                            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/cancelar.png"
                                OnClick="btnCancelarMudarCor_OnClick" />
                        </div>
                    </div>
                </div>
                <center>
                    <table border="0" width="100%" id="inicio">
                        <tr>
                            <td width="300px">
                                <img src="./images/logo.png" alt="logo" />
                            </td>
                            <td width="700px" align="center">
                                <h1>Equipes de Diamonds</h1>
                                Próximos Diamonds
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
                    <h1>Grupos -
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/imprimir3.png"
                        OnClick="imprimirRecepcao_OnClick" /><span style="font-size: medium;">Lista da Recepção</span></h1>
                    <table border="1">
                        <tr valign="top">
                            <td width="100px" align="center">
                                <h2>Grupo 1
                                <asp:ImageButton ID="btnImprimir1" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor1" runat="server" Width="150px" BackColor="Blue"></asp:TextBox><asp:ImageButton
                                    ID="btnMudarCor1" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn1MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar1" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos0" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider1" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="100px" align="center">
                                <h2>Grupo 2
                                <asp:ImageButton ID="btnImprimir2" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor2" runat="server" Width="150px" BackColor="Blue"></asp:TextBox><asp:ImageButton
                                    ID="btnMudarCor2" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn2MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar2" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos1" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider2" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="100px" align="center">
                                <h2>Grupo 3
                                <asp:ImageButton ID="btnImprimir3" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor3" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor3" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn3MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar3" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos2" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider3" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="100px" align="center">
                                <h2>Grupo 4
                                <asp:ImageButton ID="btnImprimir4" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor4" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor4" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn4MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar4" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos3" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider4" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200px" align="center">
                                <h2>Grupo 5
                                <asp:ImageButton ID="btnImprimir5" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor5" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor5" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn5MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar5" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos4" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider5" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200px" align="center">
                                <h2>Grupo 6
                                <asp:ImageButton ID="btnImprimir6" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor6" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor6" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn6MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar6" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos5" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider6" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200px" align="center">
                                <h2>Grupo 7
                                <asp:ImageButton ID="btnImprimir7" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor7" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor7" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn7MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar7" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos6" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider7" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200px" align="center">
                                <h2>Grupo 8
                                <asp:ImageButton ID="btnImprimir8" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor8" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor8" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn8MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar8" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos7" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider8" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200px" align="center">
                                <h2>Grupo 9
                                <asp:ImageButton ID="btnImprimir9" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor9" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor9" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn9MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar9" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos8" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider9" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                            <td width="200" align="center">
                                <h2>Grupo 10
                                <asp:ImageButton ID="btnImprimir0" runat="server" ImageUrl="~/images/imprimir3.png"
                                    OnClick="imprimirGrupo_OnClick" /></h2>
                                <asp:TextBox ID="txtCor10" runat="server" Width="150px" BackColor="Blue"></asp:TextBox>
                                <asp:ImageButton ID="btnMudarCor10" runat="server" ImageUrl="~/images/atualizar.jpg"
                                    OnClick="mudarCor_OnClick" />
                                <br />
                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    OnRowDataBound="GridView_RowDataBound" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                    BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>' Font-Size="XX-Small"></asp:Label>
                                                <asp:ImageButton ID="btn010MudarStatus" runat="server" ImageUrl="~/images/atualizar.jpg" OnClick="mudarStatus_OnClick" OnClientClick="javascript:topo();" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Arquétipo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExcecao" runat="server" Text='<%# Eval("Excecao") %>' Font-Size="XX-Small"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                                    <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                                    <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                                    <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                                    <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                                    <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSalvar0" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinos_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                                Total de Treinandos
                            <asp:Label ID="lblTotalTreinandos9" runat="server"></asp:Label>
                                <br />
                                <span style="background-color: Yellow; font-size: smaller;">Líder,</span><span style="background-color: Aqua; font-size: smaller;"> Vice Líder,</span><span style="background-color: Lime; font-size: smaller;">
                                    Bandeira</span><asp:ImageButton ID="btnMudarLider10" runat="server" ImageUrl="~/images/atualizar.jpg"
                                        OnClick="mudarLider_OnClick" OnClientClick="javascript:topo();" />
                            </td>
                        </tr>
                        <tr valign="top" align="center">
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView1a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView2a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView3a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView4a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView5a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView6a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView7a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView8a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView9a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                            <td>
                                <h2>Resumo Arquétipos</h2>
                                <asp:GridView ID="GridView10a" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Arquétipo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblArquetipo" runat="server" Text='<%# Eval("Arquetipo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoma" runat="server" Text='<%# Eval("Soma") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr valign="top" align="center">
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH0" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH1" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH2" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH3" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH4" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH5" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH6" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH7" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH8" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <h2>Resumo SubTipo</h2>
                                <table border="1">
                                    <tr>
                                        <td>Cérebro
                                        </td>
                                        <td width="70">
                                            <asp:Label ID="lblTotalA9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Coração
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalB9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Aberto
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalC9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fechado
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalD9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Projeções
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalE9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fatos
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalF9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Geral
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalG9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Detalhes
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotalH9" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <h2>Treinandos sem grupos</h2>
                    <asp:GridView ID="grdTreinandos" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nome">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnIDLista" runat="server" Value='<%# Eval("IDLista") %>' />
                                    <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                                </ItemTemplate>
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
                            <asp:TemplateField HeaderText="Exceção" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblExcessao" runat="server" Text='<%# Eval("Excecao") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Alterar" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlGrupo" runat="server" Width="30px">
                                        <asp:ListItem Text="1" Value="G0"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="G1"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="G2"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="G3"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="G4"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="G5"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="G6"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="G7"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="G8"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="G9"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/images/salvar.jpg" OnClick="btnSalvarDestinoSem_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
