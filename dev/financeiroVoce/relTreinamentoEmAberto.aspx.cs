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
    public partial class relTreinamentoEmAberto : System.Web.UI.Page
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
        protected void btnSelecionarTreinamento_Click(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarEquipesPorTreinamentoEmAberto(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            if (cad != null)
            {
                ddlEquipe.DataSource = cad;
                ddlEquipe.DataTextField = "Equipe";
                ddlEquipe.DataValueField = "IDEquipe";
                ddlEquipe.DataBind();
            }
            ddlEquipe.Items.Add("Todos");
            ddlEquipe.SelectedValue = "Todos";
        }
        protected void btnFiltrarTreinamento_Click(object sender, EventArgs e)
        {
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), ddlTreinamento.SelectedItem.ToString());
        }
        protected void carregarTreinandos(Int32 a, string b)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            if (ddlEquipe.SelectedValue == "Todos") cad = cadDL.ListarTreinanandosPorTreinamentoEmAberto(a);
            else cad = cadDL.ListarTreinanandosPorTreinamentoEEquipeEmAberto(a, Convert.ToInt32(ddlEquipe.SelectedValue));
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
            calculaTotal();
            divLista.Visible = true;
            lblTreinamento.Text = "Treinamento " + b.ToString();
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

                if (Convert.ToBoolean(row["experiente"]))
                    e.Row.BackColor = Color.Green;

                ImageButton imgAberto = (ImageButton)e.Row.FindControl("imgAberto");
                ImageButton imgFechado = (ImageButton)e.Row.FindControl("imgFechado");
                if (Convert.ToBoolean(row["edicao"])) imgAberto.Visible = true;
                else if (Convert.ToBoolean(row["bloqueado"])) imgFechado.Visible = true;
            }
        }
        private void calculaTotal()
        {
            Int32 a = 0;
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                a++;
            }
            lblTotalTreinandos.Text = "Treinandos em aberto " + a.ToString();
        }
    }
}
