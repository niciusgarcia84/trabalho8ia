using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using financeiroVoce.DataLayer;
using System.Data;
using System.Drawing;


namespace financeiroVoce
{
    public partial class CadastroTreinandos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re") && !Session["IDUsuarioPermissao"].ToString().Contains("pg")) Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                divFiltro.Visible = true;
                divLista.Visible = false;
                divCadastrar.Visible = true;
                carregarDrops();
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
            hdnFiltro.Value = "nome";
            lblTituloSelecionado.Text = "Exibindo nome que contenham - " + txtNmPesquisa.Text;
        }
        protected void btnFiltrarTreinamento_Click(object sender, EventArgs e)
        {
            CarregarGridTreinamento();
            hdnFiltro.Value = "treinamento";
            lblTituloSelecionado.Text = "Exibindo treinandos do treinamento - " + ddlTreinamentoInicio.SelectedItem.ToString();
        }
        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            limparTela();
            lblTituloSelecionado.Text = "";
            divFiltro.Visible = true;
            divLista.Visible = false;
            divCadastrar.Visible = true;
            divNovoTreinamento.Visible = false;
            divEdicao.Visible = false;
        }
        private void CarregarGrid()
        {
            if (txtNmPesquisa.Text.Length <= 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Informe pelo menos 4 letras!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinandoPorNome(txtNmPesquisa.Text.ToString());
            if (cad != null)
            {
                grdEquipes.DataSource = cad;
                grdEquipes.DataBind();
            }
            iniciar();
        }
        private void CarregarGridTreinamento()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentosPorTreinamento(Convert.ToInt32(ddlTreinamentoInicio.SelectedValue.ToString()));
            if (cad != null)
            {
                grdEquipes.DataSource = cad;
                grdEquipes.DataBind();
            }
            iniciar();
        }
        public void iniciar()
        {
            divFiltro.Visible = false;
            divLista.Visible = true;
            divCadastrar.Visible = true;
            btnAtualizar.Visible = false;
            btnCancelar.Visible = false;
            btnOcultar.Visible = false;
            imgOcultarTreinamento.Visible = false;
            btnOcultarDetalhes.Visible = false;
            imgOcultarTreinamento.Visible = false;
            btnInserir.Visible = true;
            lblTitulo.Text = "2 - Inserir";
            lblResultado.Text = "";
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarEquipes();
            if (cad != null)
            {
                ddlEquipe.DataSource = cad;
                ddlEquipe.DataTextField = "Equipe";
                ddlEquipe.DataValueField = "IDEquipe";
                ddlEquipe.DataBind();

                ddlEquipe2.DataSource = cad;
                ddlEquipe2.DataTextField = "Equipe";
                ddlEquipe2.DataValueField = "IDEquipe";
                ddlEquipe2.DataBind();
            }
            cad = null;
            cad = cadDL.ListarUltimosTreinamentos();
            if (cad != null)
            {
                ddlTreinamento.DataSource = cad;
                ddlTreinamento.DataTextField = "Descricao";
                ddlTreinamento.DataValueField = "IDTreinamento";
                ddlTreinamento.DataBind();

                ddlTreinamentoInicio.DataSource = cad;
                ddlTreinamentoInicio.DataTextField = "Descricao";
                ddlTreinamentoInicio.DataValueField = "IDTreinamento";
                ddlTreinamentoInicio.DataBind();

                ddlTreinamentoAlterar.DataSource = cad;
                ddlTreinamentoAlterar.DataTextField = "Descricao";
                ddlTreinamentoAlterar.DataValueField = "IDTreinamento";
                ddlTreinamentoAlterar.DataBind();
            }
        }

        protected void lnkCarregarMais_OnClick(object sender, EventArgs e)
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentos();
            if (cad != null)
            {
                ddlTreinamento.DataSource = cad;
                ddlTreinamento.DataTextField = "Descricao";
                ddlTreinamento.DataValueField = "IDTreinamento";
                ddlTreinamento.DataBind();
            }
            lnkCarregarMais.Visible = false;
            lnkAviso.Visible = true;
        }
        protected void lnkCarregarMaisInicio_OnClick(object sender, EventArgs e)
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentos();
            if (cad != null)
            {
                ddlTreinamentoInicio.DataSource = cad;
                ddlTreinamentoInicio.DataTextField = "Descricao";
                ddlTreinamentoInicio.DataValueField = "IDTreinamento";
                ddlTreinamentoInicio.DataBind();
            }
            lnkCarregarMaisInicio.Visible = false;
        }
        protected void grdEquipes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

                HiddenField hdnIDEquipe = (HiddenField)e.Row.FindControl("hdnIDEquipe");
                if (hdnIDEquipe != null) hdnIDEquipe.Value = Convert.ToString(row["IDTreinando"]);

                ImageButton imgAberto = (ImageButton)e.Row.FindControl("imgAberto");
                ImageButton imgFechado = (ImageButton)e.Row.FindControl("imgFechado");
                if (Convert.ToBoolean(row["edicao"])) imgAberto.Visible = true;
                else if (Convert.ToBoolean(row["bloqueado"])) imgFechado.Visible = true;
            }
        }
        protected void grdLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                HiddenField hdnIDLista = (HiddenField)e.Row.FindControl("hdnIDLista");
                HiddenField hdnDesconto = (HiddenField)e.Row.FindControl("hdnDesconto");
                HiddenField hdnTotal = (HiddenField)e.Row.FindControl("hdnTotal");
                HiddenField hdnNF = (HiddenField)e.Row.FindControl("hdnNF");
                HiddenField hdnObsLista = (HiddenField)e.Row.FindControl("hdnObsLista");
                HiddenField hdnIDEquipe = (HiddenField)e.Row.FindControl("hdnIDEquipe");
                HiddenField hdnEquipeAtivo = (HiddenField)e.Row.FindControl("hdnEquipeAtivo");
                HiddenField hdnMais = (HiddenField)e.Row.FindControl("hdnMais");
                HiddenField hdnAusente = (HiddenField)e.Row.FindControl("hdnAusente");
                HiddenField hdnInvestimento = (HiddenField)e.Row.FindControl("hdnInvestimento");
                HiddenField hdnDtInicial = (HiddenField)e.Row.FindControl("hdnDtInicial");
                HiddenField hdnBloqueado = (HiddenField)e.Row.FindControl("hdnBloqueado");
                HiddenField hdnEdicao = (HiddenField)e.Row.FindControl("hdnEdicao");
                HiddenField hdnCredito = (HiddenField)e.Row.FindControl("hdnCredito");
                HiddenField hdnCarta = (HiddenField)e.Row.FindControl("hdnCarta");
                HiddenField hdnExperiente = (HiddenField)e.Row.FindControl("hdnExperiente");

                hdnIDLista.Value = Convert.ToString(row["IDLista"]);
                hdnDesconto.Value = Convert.ToString(row["Desconto"]);
                hdnTotal.Value = Convert.ToString(row["TotalPagto"]);
                hdnNF.Value = Convert.ToString(row["Nota"]);
                hdnObsLista.Value = Convert.ToString(row["Obs"]);
                hdnIDEquipe.Value = Convert.ToString(row["IDEquipe"]);
                hdnEquipeAtivo.Value = Convert.ToString(row["Ocultar"]);
                hdnMais.Value = Convert.ToString(row["maisAutorizado"]);
                hdnAusente.Value = Convert.ToString(row["ausente"]);
                hdnInvestimento.Value = Convert.ToString(row["Invest"]);
                hdnDtInicial.Value = Convert.ToString(row["DTInicio"]);
                hdnBloqueado.Value = Convert.ToString(row["bloqueado"]);
                hdnEdicao.Value = Convert.ToString(row["edicao"]);
                hdnCredito.Value = Convert.ToString(row["Credito"]);
                hdnCarta.Value = Convert.ToString(row["carta"]);
                hdnExperiente.Value = Convert.ToString(row["experiente"]);

                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                if (lblTotal != null)
                {
                    double teste = Convert.ToDouble(row["TotalPagto"]);
                    lblTotal.Text = teste.ToString("N2");
                }
            }
        }
        protected void grdDetalhes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                HiddenField hdnIDPagtos = (HiddenField)e.Row.FindControl("hdnIDPagtos");
                if (hdnIDPagtos != null)
                {
                    hdnIDPagtos.Value = Convert.ToString(row["IDPagto"]);
                }
                Label lblDTPagto = (Label)e.Row.FindControl("lblDTPagto");
                if (lblDTPagto != null)
                {
                    DateTime dt = Convert.ToDateTime(row["DTPagto"]);
                    lblDTPagto.Text = dt.Date.ToString("dd/MM/yy");
                }
                TextBox txtTotalValor = (TextBox)e.Row.FindControl("txtTotalValor");
                if (txtTotalValor != null)
                {
                    double teste = Convert.ToDouble(row["valorParcela"]);
                    txtTotalValor.Text = teste.ToString("N2");
                }
                TextBox txtDTPara = (TextBox)e.Row.FindControl("txtDTPara");
                if (txtDTPara != null)
                {
                    DateTime dt = Convert.ToDateTime(row["DTVencimento"]);
                    txtDTPara.Text = dt.Date.ToString("dd/MM/yy");
                }
                Label lblDocumento = (Label)e.Row.FindControl("lblDocumento");
                if ((row["cqNumero"]).ToString() != "0") lblDocumento.Text = (row["cqNumero"]).ToString() + " ";
                if ((row["ctValidade"]).ToString() != "0") lblDocumento.Text += (row["ctValidade"]).ToString();

                Boolean visualizado = Convert.ToBoolean(row["visualizado"]);
                if (!visualizado) e.Row.BackColor = Color.Yellow;
            }
        }
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            if (txtNome.Text != "")
            {
                TreinandosDL cadDL = new TreinandosDL();
                DataTable cad = new DataTable();
                cad = cadDL.procurarTreinandoPorNome(txtNome.Text.ToString());
                if (cad.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Nome já cadastrado, utilize o campo ao lado para procurar!');", true);
                    txtNmPesquisa.Text = txtNome.Text;
                    hdnFiltro.Value = "nome";
                    limparTela();
                }
                else
                {
                    cadDL.novoTreinando(txtNome.Text.ToString(), Convert.ToString(txtObs.Text.ToString()));
                    cad = cadDL.procurarTreinandoPorNome(txtNome.Text.ToString());
                    hdnIDEqp.Value = cad.Rows[0]["IDTreinando"].ToString();
                    btnAtualizar.Visible = true;
                    btnCancelar.Visible = true;
                    btnInserir.Visible = false;
                    carregarGridLista(Convert.ToInt32(hdnIDEqp.Value));
                    divEdicao.Visible = true;
                    lblResultado.Text = "";
                    lblTitulo.Text = "2 - Editar";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Cadastrado!!!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Favor preencher todos os campos!!');", true);
            }
        }
        protected void btnInserirLista_Click(object sender, EventArgs e)
        {
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            cadDL.inserirTreinamentosPorTreinando(Convert.ToInt32(hdnIDEqp.Value), Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), Convert.ToInt32(ddlEquipe.SelectedValue.ToString()));
            carregarGridLista(Convert.ToInt32(hdnIDEqp.Value));
            divNovoTreinamento.Visible = false;
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            ImageButton btnAlterar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnAlterar.NamingContainer;
            HiddenField hdnIDEquipe = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnIDEquipe");
            Label lblNome = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblNome");
            Label lblObs = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblObs");
            hdnIDEqp.Value = hdnIDEquipe.Value;
            txtObs.Text = lblObs.Text;
            txtNome.Text = lblNome.Text;
            btnAtualizar.Visible = true;
            btnCancelar.Visible = true;
            btnInserir.Visible = false;
            carregarGridLista(Convert.ToInt32(hdnIDEqp.Value));
            lblTitulo.Text = "2 - Editar";
            divEdicao.Visible = true;
            lblResultado.Text = "";
        }
        public void carregarGridLista(Int32 id)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentosPorTreinando(Convert.ToInt32(id.ToString()));
            if (cad != null)
            {
                grdLista.DataSource = cad;
                grdLista.DataBind();
            }
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            if (txtNome.Text != "")
            {
                TreinandosDL cadDL = new TreinandosDL();
                cadDL.atualizarTreinando(Convert.ToInt32(hdnIDEqp.Value), txtNome.Text.ToString(), Convert.ToString(txtObs.Text.ToString()));
                limparTela();
            }
            else
            {
                lblResultado.Text = "Favor preencher todos os campos!";
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limparTela();
            coluna4.Style.Remove("border-left-style");
            coluna4.Style.Remove("border-left-color");
            coluna4.Style.Remove("padding-left");
        }
        public void limparTela()
        {
            txtObs.Text = "";
            txtNome.Text = "";
            divNovoTreinamento.Visible = false;
            divEdicao.Visible = false;
            divDetalhePagto.Visible = false;
            divNovoPagto.Visible = false;
            txtQtdeRepetir.Visible = true;
            lblRepetirXVezes.Visible = true;
            coluna4.Style.Remove("border-left-style");
            coluna4.Style.Remove("border-left-color");
            coluna4.Style.Remove("padding-left");

            if (hdnFiltro.Value == "nome")
                CarregarGrid();
            else
                CarregarGridTreinamento();
        }
        public void novoTreinamento_Click(object sender, EventArgs e)
        {
            divNovoTreinamento.Visible = true;
        }
        public void novoTreinamentoCancelar_Click(object sender, EventArgs e)
        {
            divNovoTreinamento.Visible = false;
        }
        public void novoPagto_Click(object sender, EventArgs e)
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            limparDadosPagto();
            divNovoPagto.Visible = true;
            lblTituloPagto.Text = "4 - Nova parcela";
            divCartao.Visible = false;
            divCheque.Visible = false;
            btnInserirDetalhes.Visible = true;
            btnAtualizarDetalhes.Visible = false;
            lblRepetirXVezes.Visible = true;
            txtQtdeRepetir.Visible = true;
            txtDTPagto.Text = DateTime.Today.ToString("dd/MM/yy");
            txtDTVencimento.Text = DateTime.Today.AddDays(30).ToString("dd/MM/yy");
        }
        public void SelecionarFormaPagto_Click(object sender, EventArgs e)
        {
            txtctNumero.Text = "";
            txtctBandeira.Text = "";
            txtcqBanco.Text = "";
            txtcqAgencia.Text = "";
            txtcqCC.Text = "";
            txtcqNumero.Text = "";
            txtNumBoleto.Text = "";
            txtSacadoBoleto.Text = "";
            txtOrigem.Text = "";
            txtDTVencimento.Text = Convert.ToDateTime(txtDTPagto.Text).AddDays(30).ToString("dd/MM/yy");
            txtResponsavel.Text = txtNome.Text;
            txtctNumero.Text = "****";
            txtQtdeRepetir.Text = "1";

            divCartao.Visible = false;
            divCheque.Visible = false;
            divCredito.Visible = false;
            divBoleto.Visible = false;
            divBotoesPagamentos.Visible = true;

            if (ddlFormaPagto.SelectedValue == "Cartão")
                divCartao.Visible = true;
            else if (ddlFormaPagto.SelectedValue == "Cheque")
                divCheque.Visible = true;
            else if (ddlFormaPagto.SelectedValue == "Crédito" || ddlFormaPagto.SelectedValue == "CréditoMesmo" || ddlFormaPagto.SelectedValue == "CréditoMesmoCheque" || ddlFormaPagto.SelectedValue == "CréditoCheque")
                divCredito.Visible = true;
            else if (ddlFormaPagto.SelectedValue == "Boleto")
                divBoleto.Visible = true;
            else
            {
                txtDTVencimento.Text = txtDTPagto.Text;
            }
        }
        protected void detalharPagto_Click(object sender, EventArgs e)
        {
            LinkButton btnDetalhe = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btnDetalhe.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            HiddenField hdnDesconto = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnDesconto");
            HiddenField hdnTotal = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnTotal");
            HiddenField hdnNF = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnNF");
            HiddenField hdnObsLista = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnObsLista");
            HiddenField hdnIDEquipe = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnIDEquipe");
            HiddenField hdnEquipeAtivo = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnEquipeAtivo");
            HiddenField hdnMais = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnMais");
            HiddenField hdnAusente = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnAusente");
            HiddenField hdnInvestimento = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnInvestimento");
            HiddenField hdnDtInicial = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnDtInicial");
            Label lblTreinamento = (Label)grdLista.Rows[gvrow.RowIndex].FindControl("lblTreinamento");
            Label lblEquipe = (Label)grdLista.Rows[gvrow.RowIndex].FindControl("lblEquipe");
            HiddenField hdnBloqueado = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnBloqueado");
            HiddenField hdnEdicao = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnEdicao");
            HiddenField hdnCredito = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnCredito");
            HiddenField hdnCarta = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnCarta");
            HiddenField hdnExperiente = (HiddenField)grdLista.Rows[gvrow.RowIndex].FindControl("hdnExperiente");

            hdnIDListaDetalhe.Value = hdnIDLista.Value;
            lblDetalheTreinamento.Text = lblTreinamento.Text;
            double teste = Convert.ToDouble(hdnDesconto.Value);
            txtDesconto.Text = teste.ToString("N2");
            double teste2 = Convert.ToDouble(hdnTotal.Value);
            txtTotalPagto.Text = teste2.ToString("N2");
            txtCredito.Text = hdnCredito.Value;
            txtNF.Text = hdnNF.Value.ToString();
            chkMais.Checked = Convert.ToBoolean(hdnMais.Value);
            chkInvestimento.Checked = Convert.ToBoolean(hdnInvestimento.Value);
            chkAusente.Checked = Convert.ToBoolean(hdnAusente.Value);
            chkExperiente.Checked = Convert.ToBoolean(hdnExperiente.Value);
            chkCarta.Checked = Convert.ToBoolean(hdnCarta.Value);

            //permissões
            if (Convert.ToBoolean(hdnEdicao.Value))
            {
                imgCadAberto.Visible = true;
                imgCadFechado.Visible = false;
                lnkBloquearTreinamento.Text = "Clique aqui para bloquear o treinando novamente!";
            }
            else if (Convert.ToBoolean(hdnBloqueado.Value))
            {
                imgCadFechado.Visible = true;
                imgCadAberto.Visible = false;
                lnkBloquearTreinamento.Text = "Clique aqui para liberar o treinando para edição!";
            }
            else
            {
                imgCadFechado.Visible = false;
                imgCadAberto.Visible = false;
                lnkBloquearTreinamento.Text = "Clique aqui para bloquear o treinando!";
            }

            txtObsLista.Text = hdnObsLista.Value.ToString();
            hdnTreinamentoDtInicial.Value = hdnDtInicial.Value;
            carregarLista(Convert.ToInt32(hdnIDLista.Value));
            coluna4.Style.Add("border-left-style", "dotted");
            coluna4.Style.Add("border-left-color", "Gray");
            coluna4.Style.Add("padding-left", "10px");

            if (Convert.ToBoolean(hdnEquipeAtivo.Value)) ddlEquipe2.Items.Insert(0, new ListItem(lblEquipe.Text.ToString(), hdnIDEquipe.Value.ToString()));
            ddlEquipe2.SelectedValue = hdnIDEquipe.Value;

            lblResultadoTreinamento.Text = "";
            divDetalhePagto.Visible = true;
            divFiltro.Visible = false;
            divLista.Visible = false;

            btnInserir.Visible = false;
            btnAtualizar.Visible = false;
        }
        public void carregarLista(Int32 id)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarPagtos(Convert.ToInt32(id.ToString()));
            if (cad != null)
            {
                grdDetalhes.DataSource = cad;
                grdDetalhes.DataBind();
            }
            calculaPagto();
        }
        private void calculaPagto()
        {
            int total = 0;
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            double g = 0;
            double h = 0;
            //double i = 0;

            foreach (GridViewRow item in grdDetalhes.Rows)
            {
                TextBox txtTotalValor = (TextBox)item.FindControl("txtTotalValor");
                Label lblForma = (Label)item.FindControl("lblForma");

                if (lblForma.Text == "Cheque")
                    b = b + Convert.ToDouble(txtTotalValor.Text.ToString());
                else if (lblForma.Text == "Cartão")
                    c = c + Convert.ToDouble(txtTotalValor.Text.ToString());
                else if (lblForma.Text == "Depósito")
                    d = d + Convert.ToDouble(txtTotalValor.Text.ToString());
                else if (lblForma.Text == "Boleto")
                    f = f + Convert.ToDouble(txtTotalValor.Text.ToString());
                else if (lblForma.Text == "Crédito" || lblForma.Text == "CréditoCheque")
                    g = g + Convert.ToDouble(txtTotalValor.Text.ToString());
                else if (lblForma.Text == "Dinheiro")
                    e = e + Convert.ToDouble(txtTotalValor.Text.ToString());
                else
                    h = h + Convert.ToDouble(txtTotalValor.Text.ToString());

                a = a + Convert.ToDouble(txtTotalValor.Text.ToString());
                total++;
            }
            lblTotalParcelas.Text = "Total de Parcelas " + total.ToString();
            txtTotalPagto.Text = a.ToString("N2");
            lblDetalhePagto.Text = "";
            if (b > 0)
                lblDetalhePagto.Text = "cheque R$" + b.ToString("N2");
            if (c > 0)
                lblDetalhePagto.Text += " - cartão R$" + c.ToString("N2");
            if (d > 0)
                lblDetalhePagto.Text += " - depósito R$" + d.ToString("N2");
            if (e > 0)
                lblDetalhePagto.Text += " - dinheiro R$" + e.ToString("N2");
            if (f > 0)
                lblDetalhePagto.Text += " - boleto R$" + f.ToString("N2");
            if (g > 0)
                lblDetalhePagto.Text += " - crédito R$" + g.ToString("N2");
            if (h > 0)
                lblDetalhePagto.Text += " - crédito no mesmo treinamento R$" + h.ToString("N2");
        }
        protected void lnkBloquearTreinamento_OnClick(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            UsuariosDL usuario = new UsuariosDL();
            if (lnkBloquearTreinamento.Text.Contains("liberar"))
            {
                if (Session["IDUsuarioPermissao"].ToString().Contains("repg"))
                {
                    cadDL.editarTreinando(Convert.ToInt32(hdnIDListaDetalhe.Value));
                    usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Liberou para edição o treinando " + txtNome.Text + " no treinamento " + lblDetalheTreinamento.Text);
                    imgCadAberto.Visible = true;
                    imgCadFechado.Visible = false;
                    lnkBloquearTreinamento.Text = "Clique aqui para bloquear o treinando novamente!";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                    return;
                }
            }
            else if (lnkBloquearTreinamento.Text.Contains("novamente"))
            {
                if (Session["IDUsuarioPermissao"].ToString().Contains("re"))
                {
                    cadDL.bloquearEdicaoTreinando(Convert.ToInt32(hdnIDListaDetalhe.Value));
                    usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Bloqueou a edição do treinando " + txtNome.Text + " no treinamento " + lblDetalheTreinamento.Text);
                    imgCadFechado.Visible = true;
                    imgCadAberto.Visible = false;
                    lnkBloquearTreinamento.Text = "Clique aqui para liberar o treinando para edição!";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                    return;
                }
            }
            else
            {
                if (Session["IDUsuarioPermissao"].ToString().Contains("re"))
                {
                    cadDL.bloquearTreinando(Convert.ToInt32(hdnIDListaDetalhe.Value));
                    usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Bloqueou o treinando " + txtNome.Text + " no treinamento " + lblDetalheTreinamento.Text);
                    imgCadFechado.Visible = true;
                    imgCadAberto.Visible = false;
                    lnkBloquearTreinamento.Text = "Clique aqui para liberar o treinando para edição!";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                    return;
                }
            }
        }
        public Boolean verificarPermissao()
        {
            Boolean passou = false;
            if (Session["IDUsuarioPermissao"].ToString().Contains("dm")) passou = true;
            else
            {
                if (imgCadFechado.Visible && Session["IDUsuarioPermissao"].ToString().Contains("dm")) passou = true;
                if (imgCadAberto.Visible && Session["IDUsuarioPermissao"].ToString().Contains("pg")) passou = true;
                if (!imgCadFechado.Visible && imgCadAberto.Visible && Session["IDUsuarioPermissao"].ToString().Contains("re")) passou = true;
                if (!imgCadFechado.Visible && !imgCadAberto.Visible && Session["IDUsuarioPermissao"].ToString().Contains("re")) passou = true;
            }
            return passou;
        }
        protected void btnAtualizarTreinamento_Click(object sender, EventArgs e)
        {
            atualizarTreinamento();
        }
        public void atualizarTreinamento()
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            if (txtCredito.Text.Length >= 254)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Favor resumir as informações no campo crédito!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            foreach (GridViewRow item in grdDetalhes.Rows)
            {
                HiddenField hdnIDPagtos = (HiddenField)item.FindControl("hdnIDPagtos");
                TextBox txtDTPara = (TextBox)item.FindControl("txtDTPara");
                TextBox txtTotalValor = (TextBox)item.FindControl("txtTotalValor");
                cadDL.atualizarDataParaPagto(Convert.ToInt32(hdnIDPagtos.Value), Convert.ToDateTime(txtDTPara.Text), Convert.ToDouble(txtTotalValor.Text.ToString()));
            }
            lblResultadoTreinamento.Text = "Atualizado";
            carregarLista(Convert.ToInt32(hdnIDListaDetalhe.Value));
            cadDL.atualizarTreinandoValor(Convert.ToInt32(hdnIDListaDetalhe.Value), Convert.ToInt32(ddlEquipe2.SelectedValue), Convert.ToString(txtNF.Text.ToString()), Convert.ToDouble(txtTotalPagto.Text.ToString()), Convert.ToDouble(txtDesconto.Text.ToString()), Convert.ToString(txtObsLista.Text.ToString()), lblDetalhePagto.Text.ToString(), chkMais.Checked, chkInvestimento.Checked, chkAusente.Checked, chkExperiente.Checked, chkCarta.Checked, txtCredito.Text.ToString());
            //hdnTreinamentoDtInicial.Value = "";
            btnOcultar.Visible = false;
            imgOcultarTreinamento.Visible = false;
            btnOcultarDetalhes.Visible = false;
            carregarGridLista(Convert.ToInt32(hdnIDEqp.Value));
        }
        protected void btnCancelarTreinamento_Click(object sender, EventArgs e)
        {
            lblDetalheTreinamento.Text = "";
            txtDesconto.Text = "";
            txtTotalPagto.Text = "";
            txtCredito.Text = "";
            lblDetalhePagto.Text = "";
            txtNF.Text = "";
            hdnTreinamentoDtInicial.Value = "";
            btnOcultar.Visible = false;
            imgOcultarTreinamento.Visible = false;
            btnOcultarDetalhes.Visible = false;
            chkMais.Checked = false;
            chkAusente.Checked = false;
            chkCarta.Checked = false;
            chkExperiente.Checked = false;
            chkInvestimento.Checked = false;
            lnkBloquearTreinamento.Text = "Clique aqui para bloquear o treinando!";
            imgCadAberto.Visible = false;
            imgCadFechado.Visible = false;
            txtObsLista.Text = "";
            coluna4.Style.Remove("border-left-style");
            coluna4.Style.Remove("border-left-color");
            coluna4.Style.Remove("padding-left");
            divDetalhePagto.Visible = false;
            divLista.Visible = true;
            btnAtualizar.Visible = true;
        }
        protected void visualizarParcela_Click(object sender, EventArgs e)
        {
            LinkButton lnkDetalharPagto = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)lnkDetalharPagto.NamingContainer;
            HiddenField hdnIDPagtos = (HiddenField)grdDetalhes.Rows[gvrow.RowIndex].FindControl("hdnIDPagtos");
            grdPagto.Visible = true;
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarPagto(Convert.ToInt32(hdnIDPagtos.Value.ToString()));
            if (cad != null)
            {
                grdPagto.DataSource = cad;
                grdPagto.DataBind();
            }
            divNovoPagto.Visible = true;
            divBotoesPagamentos.Visible = true;
            btnInserirDetalhes.Visible = false;
            btnAtualizarDetalhes.Visible = true;
            lblTituloPagto.Text = "4 - Editar Parcela";
            grdPagto.Visible = false;
            cadDL.VisualizarPagto(Convert.ToInt32(hdnIDPagtos.Value.ToString()));
            carregarLista(Convert.ToInt32(hdnIDListaDetalhe.Value));
        }
        protected void grdPagto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                DateTime dt = Convert.ToDateTime(row["DTPagto"]);
                txtDTPagto.Text = dt.Date.ToString("dd/MM/yy");
                dt = Convert.ToDateTime(row["DTVencimento"]);
                txtDTVencimento.Text = dt.Date.ToString("dd/MM/yy");
                double teste = Convert.ToDouble(row["valorParcela"]);
                txtValorParcela.Text = teste.ToString("N2");
                hdnIDParcela.Value = Convert.ToString(row["IDPagto"]);
                txtctNumero.Text = Convert.ToString(row["ctNumero"]);
                txtctBandeira.Text = Convert.ToString(row["ctBandeira"]);
                txtctBanco.Text = Convert.ToString(row["ctBanco"]);
                txtcqBanco.Text = Convert.ToString(row["cqBanco"]);
                txtcqAgencia.Text = Convert.ToString(row["cqAgencia"]);
                txtcqCC.Text = Convert.ToString(row["cqCC"]);
                txtcqNumero.Text = Convert.ToString(row["cqNumero"]);
                txtResponsavel.Text = Convert.ToString(row["Responsavel"]);
                txtctSeguranca.Text = Convert.ToString(row["ctSeguranca"]);
                txtctValidade.Text = Convert.ToString(row["ctValidade"]);
                txtNumBoleto.Text = Convert.ToString(row["blNumero"]);
                txtSacadoBoleto.Text = Convert.ToString(row["blSacado"]);
                txtOrigem.Text = Convert.ToString(row["crOrigem"]);
                txtQtdeRepetir.Visible = false;
                lblRepetirXVezes.Visible = false;
                ddlFormaPagto.SelectedValue = Convert.ToString(row["FormaPagto"]);

                divCartao.Visible = false;
                divCheque.Visible = false;
                divCredito.Visible = false;
                divBoleto.Visible = false;

                if (ddlFormaPagto.SelectedValue == "Cartão")
                    divCartao.Visible = true;
                else if (ddlFormaPagto.SelectedValue == "Cheque")
                    divCheque.Visible = true;
                else if (ddlFormaPagto.SelectedValue == "Crédito" || ddlFormaPagto.SelectedValue == "CréditoMesmoCheque" || ddlFormaPagto.SelectedValue == "CréditoMesmo" || ddlFormaPagto.SelectedValue == "CréditoCheque")
                    divCredito.Visible = true;
                else if (ddlFormaPagto.SelectedValue == "Boleto")
                    divBoleto.Visible = true;
            }
        }
        protected void btnInserirDetalhes_Click(object sender, EventArgs e)
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            if (ddlFormaPagto.SelectedValue == "Cartão" && txtctValidade.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Número do DOC obrigatório!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            if (txtDTPagto.Text != "" && txtValorParcela.Text != "" && txtDTVencimento.Text != "")
            {
                Int32 x = Convert.ToInt32(txtQtdeRepetir.Text.ToString());
                DateTime dtvencimento = Convert.ToDateTime(txtDTVencimento.Text.ToString());
                Int32 numCQ = 0;
                if (ddlFormaPagto.SelectedValue == "Cheque") numCQ = Convert.ToInt32(txtcqNumero.Text);
                for (int i = 0; i < x; i++)
                {
                    if (i > 0)
                    {
                        dtvencimento = dtvencimento.Date.AddMonths(1);
                        if (ddlFormaPagto.SelectedValue == "Cheque") numCQ++;
                    }
                    if (ddlFormaPagto.SelectedValue == "Dinheiro" || ddlFormaPagto.SelectedValue == "Depósito")
                        cadDL.inserirPagtoDinheiro(Convert.ToInt32(hdnIDListaDetalhe.Value), Convert.ToDateTime(txtDTPagto.Text.ToString()), Convert.ToDouble(txtValorParcela.Text.ToString()), dtvencimento.Date, Convert.ToString(ddlFormaPagto.SelectedValue.ToString()), Convert.ToString(txtctNumero.Text.ToString()), Convert.ToString(txtctBandeira.Text.ToString()), Convert.ToString(txtctBanco.Text.ToString()), Convert.ToString(txtcqBanco.Text.ToString()), Convert.ToString(txtcqAgencia.Text.ToString()), Convert.ToString(txtcqCC.Text.ToString()), numCQ.ToString(), Convert.ToString(txtResponsavel.Text.ToString()), Convert.ToString(txtctValidade.Text.ToString()), Convert.ToString(txtctSeguranca.Text.ToString()), Convert.ToString(txtNumBoleto.Text.ToString()), Convert.ToString(txtSacadoBoleto.Text.ToString()), Convert.ToString(txtOrigem.Text.ToString()));
                    else
                        cadDL.inserirPagto(Convert.ToInt32(hdnIDListaDetalhe.Value), Convert.ToDateTime(txtDTPagto.Text.ToString()), Convert.ToDouble(txtValorParcela.Text.ToString()), dtvencimento.Date, Convert.ToString(ddlFormaPagto.SelectedValue.ToString()), Convert.ToString(txtctNumero.Text.ToString()), Convert.ToString(txtctBandeira.Text.ToString()), Convert.ToString(txtctBanco.Text.ToString()), Convert.ToString(txtcqBanco.Text.ToString()), Convert.ToString(txtcqAgencia.Text.ToString()), Convert.ToString(txtcqCC.Text.ToString()), numCQ.ToString(), Convert.ToString(txtResponsavel.Text.ToString()), Convert.ToString(txtctValidade.Text.ToString()), Convert.ToString(txtctSeguranca.Text.ToString()), Convert.ToString(txtNumBoleto.Text.ToString()), Convert.ToString(txtSacadoBoleto.Text.ToString()), Convert.ToString(txtOrigem.Text.ToString()));
                }
                carregarLista(Convert.ToInt32(hdnIDListaDetalhe.Value));
                atualizarTreinamento();
                limparDadosPagto();
            }
            else
                lblAvisoDetalhes.Text = "Favor veficar o preenchimento dos campos";
        }
        public void limparDadosPagto()
        {
            divNovoPagto.Visible = false;
            txtDTPagto.Text = "";
            txtValorParcela.Text = "";
            txtDTVencimento.Text = "";
            txtctNumero.Text = "";
            txtctBandeira.Text = "";
            txtctBanco.Text = "";
            txtcqBanco.Text = "";
            txtcqAgencia.Text = "";
            txtcqCC.Text = "";
            txtcqNumero.Text = "";
            txtctSeguranca.Text = "";
            txtctValidade.Text = "";
            txtResponsavel.Text = "";
            testeCartao.Visible = false;
            divCheque.Visible = false;
            divCartao.Visible = false;
            divBoleto.Visible = false;
            divCredito.Visible = false;
            divBotoesPagamentos.Visible = false;
        }
        protected void btnCancelarDetalhes_Click(object sender, EventArgs e)
        {
            limparDadosPagto();
        }
        protected void btnAtualizarDetalhes_Click(object sender, EventArgs e)
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            cadDL.atualizarPagto(Convert.ToInt32(hdnIDParcela.Value), Convert.ToDateTime(txtDTPagto.Text.ToString()), Convert.ToDouble(txtValorParcela.Text.ToString()), Convert.ToDateTime(txtDTVencimento.Text.ToString()), Convert.ToString(ddlFormaPagto.SelectedValue.ToString()), Convert.ToString(txtctNumero.Text.ToString()), Convert.ToString(txtctBandeira.Text.ToString()), Convert.ToString(txtctBanco.Text.ToString()), Convert.ToString(txtcqBanco.Text.ToString()), Convert.ToString(txtcqAgencia.Text.ToString()), Convert.ToString(txtcqCC.Text.ToString()), Convert.ToString(txtcqNumero.Text.ToString()), Convert.ToString(txtResponsavel.Text.ToString()), Convert.ToString(txtctValidade.Text.ToString()), Convert.ToString(txtctSeguranca.Text.ToString()), Convert.ToString(txtNumBoleto.Text.ToString()), Convert.ToString(txtSacadoBoleto.Text.ToString()), Convert.ToString(txtOrigem.Text.ToString()));
            if (ddlFormaPagto.SelectedValue == "Dinheiro" || ddlFormaPagto.SelectedValue == "Depósito") cadDL.atualizarDinheiro(Convert.ToInt32(hdnIDParcela.Value), Convert.ToDateTime(txtDTVencimento.Text.ToString()));
            carregarLista(Convert.ToInt32(hdnIDListaDetalhe.Value));
            atualizarTreinamento();
            limparDadosPagto();
        }
        protected void testarNumeroCartao(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.testarCartao(Convert.ToInt32(hdnIDListaDetalhe.Value.ToString()), txtctNumero.Text.ToString());
            if (cad.Rows.Count > 0)
            {
                grdTeste.DataSource = cad;
                grdTeste.DataBind();
                testeCartao.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Cartão não cadastrado!');", true);
            }
        }
        protected void testarNumeroNSU(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.testarNSU(Convert.ToInt32(hdnIDListaDetalhe.Value.ToString()), txtctValidade.Text.ToString());
            if (cad.Rows.Count > 0)
            {
                grdTeste.DataSource = cad;
                grdTeste.DataBind();
                testeCartao.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('NSU não cadastrado!');", true);
            }
        }
        protected void exibirExcluir(object sender, EventArgs e)
        {
            if (btnOcultar.Visible)
            {
                btnOcultar.Visible = false;
                imgOcultarTreinamento.Visible = false;
                btnOcultarDetalhes.Visible = false;
            }
            else
            {
                UsuariosDL usuario = new UsuariosDL();
                usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Clicou para habilitar excluir no treinando " + txtNome.Text + " no treinamento " + lblDetalheTreinamento.Text);

                if (grdLista.Rows.Count == 0) btnOcultar.Visible = true;
                if (!verificarPermissao())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                    return;
                }
                imgOcultarTreinamento.Visible = true;
                btnOcultarDetalhes.Visible = true;
            }
        }
        protected void btnOcultar_Click(object sender, EventArgs e)
        {
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            //remover treinando
            cadDL.ocultarTreinando(Convert.ToInt32(hdnIDEqp.Value));
            UsuariosDL usuario = new UsuariosDL();
            usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Excluiu o treinando = " + txtNome.Text);
            limparTela();
        }
        protected void btnOcultarTreinamento_Click(object sender, EventArgs e)
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            //remover parcelas
            cadDL.removerPagto(Convert.ToInt32(hdnIDListaDetalhe.Value));
            //remover pagtos
            cadDL.ocultarTreinamentoTreinando(Convert.ToInt32(hdnIDListaDetalhe.Value));
            //log
            UsuariosDL usuario = new UsuariosDL();
            usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Excluiu o treinamento " + lblDetalheTreinamento.Text + " do treinando " + txtNome.Text);

            coluna4.Style.Remove("border-left-style");
            coluna4.Style.Remove("border-left-color");
            coluna4.Style.Remove("padding-left");
            limparTela();
            limparDadosPagto();
        }
        protected void btnOcultarDetalhes_Click(object sender, EventArgs e)
        {
            if (!verificarPermissao())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
            TreinandosDL cadDL = new TreinandosDL();
            cadDL.removerPagto(Convert.ToInt32(hdnIDParcela.Value));
            carregarLista(Convert.ToInt32(hdnIDListaDetalhe.Value));
            //log
            UsuariosDL usuario = new UsuariosDL();
            usuario.lancarLog(Session["UsuarioLogado"].ToString(), System.Environment.MachineName, "Excluiu o pagamento IDPagto = " + hdnIDParcela.Value.ToString() + " no valor de R$ " + txtValorParcela.Text + " do treinando " + txtNome.Text + " no treinamento " + lblDetalheTreinamento.Text);
            //atualizar tela
            atualizarTreinamento();
            limparDadosPagto();
            imgOcultarTreinamento.Visible = false;
            btnOcultarDetalhes.Visible = false;
            imgOcultarTreinamento.Visible = false;
        }
        protected void btnSalvarNota_Click(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"].ToString().Contains("re") || Session["IDUsuarioPermissao"].ToString().Contains("dm"))
            {
                DateTime dt = Convert.ToDateTime(hdnTreinamentoDtInicial.Value);
                if ((dt.Date >= DateTime.Now.Date) || (dt.Month == DateTime.Now.Date.Month && dt.Year == DateTime.Now.Date.Year))
                {
                    TreinandosDL cadDL = new TreinandosDL();
                    cadDL.atualizarNotaFiscal(Convert.ToInt32(hdnIDListaDetalhe.Value), Convert.ToString(txtNF.Text.ToString()));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Data do treinamento anterior a este mês!');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
        }
        protected void limparNome_OnClick(object sender, EventArgs e)
        {
            txtNmPesquisa.Text = "";
        }
        protected void limparResponsavel_OnClick(object sender, EventArgs e)
        {
            txtResponsavel.Text = "";
        }
        protected void lnkVisa_OnClick(object sender, EventArgs e)
        {
            txtctBandeira.Text = "Visa";
        }
        protected void lnkMastercard_OnClick(object sender, EventArgs e)
        {
            txtctBandeira.Text = "Mastercard";
        }
        protected void lnkAmex_OnClick(object sender, EventArgs e)
        {
            txtctBandeira.Text = "Amex";
        }

        protected void alterarTreinamento_OnClick(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            if (Session["IDUsuarioPermissao"].ToString().Contains("dm") || Session["IDUsuarioPermissao"].ToString().Contains("repg"))
            {
                cadDL.alterarTreinamentoTreinando(Convert.ToInt32(hdnIDListaDetalhe.Value), Convert.ToInt32(ddlTreinamentoAlterar.SelectedValue.ToString()));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Treinamento Alterado!');", true);
                limparTela();
                coluna4.Style.Remove("border-left-style");
                coluna4.Style.Remove("border-left-color");
                coluna4.Style.Remove("padding-left");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Seu usuário não têm essa permissão!');", true);
                return;
            }
        }
    }
}