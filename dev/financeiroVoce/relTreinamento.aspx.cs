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
    public partial class relTreinamento : System.Web.UI.Page
    {
        public double creditoFinal = 0;
        public double creditoFinalMesmo = 0;
        public double descontos = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                divLista.Visible = false;
                carregarDrops();
            }
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarUltimosTreinamentos();
            if (cad != null)
            {
                ddlTreinamento.DataSource = cad;
                ddlTreinamento.DataTextField = "Descricao";
                ddlTreinamento.DataValueField = "IDTreinamento";
                ddlTreinamento.DataBind();
            }
        }
        protected void lnkVoltar_OnClick(object sender, EventArgs e)
        {
            divLabel.Visible = false;
            divMenuOpcoes.Visible = true;
            divAntigos.Visible = false;
        }
        protected void lnkAntigos_OnClick(object sender, EventArgs e)
        {
            divAntigos.Visible = true;
            divLabel.Visible = true;
            divMenuOpcoes.Visible = false;
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentos();
            if (cad != null)
            {
                grdTreinamentos.DataSource = cad;
                grdTreinamentos.DataBind();
            }
        }
        protected void lnkTreinamento_OnClick(object sender, EventArgs e)
        {
            LinkButton btnAlterar = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btnAlterar.NamingContainer;
            HiddenField hdnIDTreinamento = (HiddenField)grdTreinamentos.Rows[gvrow.RowIndex].FindControl("hdnIDTreinamento");
            LinkButton lnkTreinamento = (LinkButton)grdTreinamentos.Rows[gvrow.RowIndex].FindControl("lnkTreinamento");
            carregarTreinandos(Convert.ToInt32(hdnIDTreinamento.Value), lnkTreinamento.Text.ToString());
            divAntigos.Visible = false;
        }
        protected void btnFiltrarTreinamento_Click(object sender, EventArgs e)
        {
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), ddlTreinamento.SelectedItem.ToString());
        }
        protected void carregarTreinandos(Int32 a, string b)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinanandosPorTreinamento(a);
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
            calculaTotal();
            carregarTotal();
            divLista.Visible = true;
            lblTreinamento.Text = "Treinamento " + b.ToString();
            hdnTreinamento.Value = a.ToString();
            divMenuOpcoes.Visible = false;
            divLabel.Visible = true;
        }
        protected void grdTreinandos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                HiddenField hdnInvestimento = (HiddenField)e.Row.FindControl("hdnInvestimento");
                hdnInvestimento.Value = Convert.ToString(row["Investimento"]);

                Label lblTotalPagto = (Label)e.Row.FindControl("lblTotalPagto");
                double totalpagto = Convert.ToDouble(row["TotalPagto"]);
                lblTotalPagto.Text = "R$" + totalpagto.ToString("N2");

                Label lblDesconto = (Label)e.Row.FindControl("lblDesconto");
                lblDesconto.Text = "R$" + Convert.ToDouble(row["Desconto"]).ToString("N2");
                descontos = descontos + Convert.ToDouble(row["Desconto"]);

                totalpagto = totalpagto + Convert.ToDouble(row["Desconto"]);
                if (totalpagto >= Convert.ToDouble(hdnInvestimento.Value))
                    e.Row.BackColor = Color.LightSteelBlue;
                else if (totalpagto == 0)
                    e.Row.BackColor = Color.Yellow;
                else if (totalpagto > 0)
                {
                    e.Row.BackColor = Color.Red;
                    e.Row.ForeColor = Color.White;
                }
                HiddenField hdnInvest = (HiddenField)e.Row.FindControl("hdnInvest");
                hdnInvest.Value = Convert.ToString(row["Invest"]);
                if (Convert.ToBoolean(row["Invest"]))
                    e.Row.BackColor = Color.Orange;

                if (Convert.ToBoolean(row["experiente"]))
                    e.Row.BackColor = Color.Green;

                if (Convert.ToBoolean(row["carta"])) e.Row.BackColor = Color.Cyan;

                HiddenField hdnAusente = (HiddenField)e.Row.FindControl("hdnAusente");
                hdnAusente.Value = Convert.ToString(row["ausente"]);
                if (Convert.ToBoolean(row["ausente"]))
                {
                    e.Row.BackColor = Color.Purple;
                    e.Row.ForeColor = Color.White;
                }

                ImageButton imgAberto = (ImageButton)e.Row.FindControl("imgAberto");
                ImageButton imgFechado = (ImageButton)e.Row.FindControl("imgFechado");
                if (Convert.ToBoolean(row["edicao"])) imgAberto.Visible = true;
                else if (Convert.ToBoolean(row["bloqueado"])) imgFechado.Visible = true;
            }
        }
        private void calculaTotal()
        {
            Int32 a = 0;
            Int32 b = 0;
            Int32 i = 0;
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                HiddenField hdnAusente = (HiddenField)item.FindControl("hdnAusente");
                if (Convert.ToBoolean(hdnAusente.Value))
                    b++;
                else
                    a++;

                HiddenField hdnInvest = (HiddenField)item.FindControl("hdnInvest");
                if (Convert.ToBoolean(hdnInvest.Value))
                    i++;
            }
            lblTotalTreinandos.Text = "Participantes " + a.ToString() + ", ausentes " + b.ToString() + " e total de treinandos = " + (a + b).ToString();
            lblInvest.Text = "Total de Investimentos = " + i.ToString();
        }
        public void carregarTotal()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarSomaFormaPagto(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            if (cad != null)
            {
                grdForma.DataSource = cad;
                grdForma.DataBind();
            }
            calculaValorTotal();
        }
        protected void grdForma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                Label lblForma = (Label)e.Row.FindControl("lblForma");
                Label lblSoma = (Label)e.Row.FindControl("lblSoma");
                double totalpagto = Convert.ToDouble(row["SomaDevalorParcela"]);
                lblSoma.Text = "R$" + totalpagto.ToString("N2");
                if (lblForma.Text == "CréditoMesmo" || lblForma.Text == "CréditoMesmoCheque")
                {
                    creditoFinalMesmo += totalpagto;
                    lblSoma.Text = "";
                    lblForma.Text = "";
                    e.Row.Height = 0;
                }
            }
        }
        private void calculaValorTotal()
        {
            double t = 0;
            foreach (GridViewRow item in grdForma.Rows)
            {
                Label lblValorParcela = (Label)item.FindControl("lblSoma");
                if (lblValorParcela.Text != "") t = t + Convert.ToDouble(lblValorParcela.Text.ToString().Replace("R$", ""));
            }
            lblTotalValor.Text = "Total de financeiro no treinamento R$ " + t.ToString("N2");
            lblTotalCredito.Text = "Total de crédito do mesmo treinamento R$ " + creditoFinalMesmo.ToString("N2");
            lblTotalDescontos.Text = "Total de descontos e pagamentos de outros treinandos R$" + descontos.ToString("N2");
            lblTotalReceber.Text = "Total a receber no treinamento R$ " + (t - descontos + creditoFinalMesmo).ToString("N2");
        }
        protected void lnkDetalhes_OnClick(object sender, EventArgs e)
        {
            string _open = "window.open('DetalhesFinanceirosTreinamento.aspx?treinamento=" + hdnTreinamento.Value.ToString() + "', '_Blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "imprimir", _open, true);
        }
    }
}
