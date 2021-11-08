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
    public partial class CadastroTreinamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                carregarDrops();
                CarregarGrid();
            }
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.carregarTiposTreinamentos();
            if (cad != null)
            {
                ddlTipo.DataSource = cad;
                ddlTipo.DataTextField = "Descricao";
                ddlTipo.DataValueField = "Nome";
                ddlTipo.DataBind();
            }
        }
        private void CarregarGrid()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamentos();
            if (cad != null)
            {
                grdEquipes.DataSource = cad;
                grdEquipes.DataBind();
            }
            btnAtualizar.Visible = false;
            btnCancelar.Visible = false;
            btnOcultar.Visible = false;
            btnInserir.Visible = true;
            lblTitulo.Text = "Inserir";
        }
        protected void grdEquipes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                HiddenField hdnIDEquipe = (HiddenField)e.Row.FindControl("hdnIDEquipe");
                if (hdnIDEquipe != null)
                {
                    hdnIDEquipe.Value = Convert.ToString(row["IDTreinamento"]);
                }
                Label lblInvestimento = (Label)e.Row.FindControl("lblTelefone");
                if (lblInvestimento != null)
                {
                    double teste = Convert.ToDouble(row["Investimento"]);
                    lblInvestimento.Text = teste.ToString("N2");
                }
                Label lblDTInicio = (Label)e.Row.FindControl("lblObs");
                if (lblDTInicio != null)
                {
                    DateTime dt = Convert.ToDateTime(row["DTInicio"]);
                    lblDTInicio.Text = dt.Date.ToString("dd/MM/yy");
                }
            }
        }
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtEquipe.Text != "" && txtObs.Text != "" && txtTelefone.Text != "" && txtInvest2.Text != "" && txtInvest3.Text != "" && txtInvest4.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.novoTreinamento(txtEquipe.Text.ToString(), Convert.ToDouble(txtTelefone.Text.ToString()), Convert.ToDateTime(txtObs.Text.ToString()), Convert.ToDouble(txtInvest2.Text.ToString()), Convert.ToDouble(txtInvest3.Text.ToString()), Convert.ToDouble(txtInvest4.Text.ToString()), Convert.ToDouble(txtVlExperiente.Text.ToString()), Convert.ToDouble(txtR1.Text.ToString()), Convert.ToDouble(txtR2.Text.ToString()), Convert.ToDouble(txtR3.Text.ToString()), Convert.ToDouble(txtR4.Text.ToString()), Convert.ToDouble(txtR5.Text.ToString()), Convert.ToDouble(txtRo1.Text.ToString()), Convert.ToDouble(txtRo2.Text.ToString()), Convert.ToDouble(txtRo3.Text.ToString()), Convert.ToDouble(txtRo4.Text.ToString()), Convert.ToDouble(txtRo5.Text.ToString()));
                limparCampos();
                CarregarGrid();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Favor preencher todos os campos!');", true);
            }
        }
        public void limparCampos()
        {
            txtObs.Text = "";
            txtEquipe.Text = "";
            txtTelefone.Text = "";
            txtInvest2.Text = "";
            txtInvest3.Text = "";
            txtInvest4.Text = "";
            txtVlExperiente.Text = "0";
            txtR1.Text = "0";
            txtR2.Text = "0";
            txtR3.Text = "0";
            txtR4.Text = "0";
            txtR5.Text = "0";
            txtRo1.Text = "0";
            txtRo2.Text = "0";
            txtRo3.Text = "0";
            txtRo4.Text = "0";
            txtRo5.Text = "0";
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            ImageButton btnAlterar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnAlterar.NamingContainer;
            HiddenField hdnIDEquipe = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnIDEquipe");
            Label lblEquipe = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblEquipe");
            Label lblTelefone = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblTelefone");
            Label lblObs = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblObs");
            hdnIDEqp.Value = hdnIDEquipe.Value;
            txtObs.Text = lblObs.Text;
            txtEquipe.Text = lblEquipe.Text;
            txtTelefone.Text = Convert.ToDouble(lblTelefone.Text).ToString("N2");
            txtVlExperiente.Text = "0";

            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinamento(Convert.ToInt32(hdnIDEquipe.Value));
            if (Convert.ToDouble(cad.Rows[0]["Investimento2"]) <= 0) txtInvest2.Text = "0"; else txtInvest2.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["Investimento2"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["Investimento3"]) <= 0) txtInvest3.Text = "0"; else txtInvest3.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["Investimento3"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["Investimento4"]) <= 0) txtInvest4.Text = "0"; else txtInvest4.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["Investimento4"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["r1"]) <= 0) txtR1.Text = "0"; else txtR1.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["r1"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["r2"]) <= 0) txtR2.Text = "0"; else txtR2.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["r2"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["r3"]) <= 0) txtR3.Text = "0"; else txtR3.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["r3"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["r4"]) <= 0) txtR4.Text = "0"; else txtR4.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["r4"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["r5"]) <= 0) txtR5.Text = "0"; else txtR5.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["r5"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["ro1"]) <= 0) txtRo1.Text = "0"; else txtRo1.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro1"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["ro2"]) <= 0) txtRo2.Text = "0"; else txtRo2.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro2"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["ro3"]) <= 0) txtRo3.Text = "0"; else txtRo3.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro3"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["ro4"]) <= 0) txtRo4.Text = "0"; else txtRo4.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro4"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["ro5"]) <= 0) txtRo5.Text = "0"; else txtRo5.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro5"])).ToString("N2");

            btnAtualizar.Visible = true;
            btnCancelar.Visible = true;
            btnInserir.Visible = false;
            lblTitulo.Text = "Editar";
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtEquipe.Text != "" && txtInvest2.Text != "" && txtInvest3.Text != "" && txtInvest4.Text != "" && txtTelefone.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.atualizarTreinamento(Convert.ToInt32(hdnIDEqp.Value), txtEquipe.Text.ToString(), Convert.ToDouble(txtTelefone.Text.ToString()),
                        Convert.ToDateTime(txtObs.Text.ToString()), Convert.ToDouble(txtInvest2.Text.ToString()), Convert.ToDouble(txtInvest3.Text.ToString()),
                        Convert.ToDouble(txtInvest4.Text.ToString()), Convert.ToDouble(txtVlExperiente.Text.ToString()), Convert.ToDouble(txtR1.Text.ToString()),
                        Convert.ToDouble(txtR2.Text.ToString()), Convert.ToDouble(txtR3.Text.ToString()), Convert.ToDouble(txtR4.Text.ToString()),
                        Convert.ToDouble(txtR5.Text.ToString()), Convert.ToDouble(txtRo1.Text.ToString()),
                        Convert.ToDouble(txtRo2.Text.ToString()), Convert.ToDouble(txtRo3.Text.ToString()), Convert.ToDouble(txtRo4.Text.ToString()),
                        Convert.ToDouble(txtRo5.Text.ToString()));
                limparCampos();
                CarregarGrid();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Favor preencher todos os campos!');", true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            CarregarGrid();
        }
        protected void btnOcultar_Click(object sender, EventArgs e)
        {
            CadastrosDL cadDL = new CadastrosDL();
            cadDL.ocultarTreinamento(Convert.ToInt32(hdnIDEqp.Value));
            limparCampos();
            CarregarGrid();
        }
        protected void exibirExcluir(object sender, EventArgs e)
        {
            if (lblTitulo.Text == "Editar") btnOcultar.Visible = true;
        }
        protected void lnkCarregarValores_OnClick(object sender, EventArgs e)
        {
            if (txtObs.Text.Length <= 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Informe a data do treinamento com dia/mês/ano!');", true);
                return;
            }
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.carregarTabela(Convert.ToDateTime(txtObs.Text).Date.Year, ddlTipo.SelectedValue.ToString());
            if (cad.Rows.Count > 0)
            {
                if (Convert.ToDouble(cad.Rows[0]["v1"]) <= 0) txtTelefone.Text = "0"; else txtTelefone.Text = Convert.ToDouble(cad.Rows[0]["v1"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["v2"]) <= 0) txtInvest2.Text = "0"; else txtInvest2.Text = Convert.ToDouble(cad.Rows[0]["v2"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["v3"]) <= 0) txtInvest3.Text = "0"; else txtInvest3.Text = Convert.ToDouble(cad.Rows[0]["v3"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["v4"]) <= 0) txtInvest4.Text = "0"; else txtInvest4.Text = Convert.ToDouble(cad.Rows[0]["v4"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["r1"]) <= 0) txtR1.Text = "0"; else txtR1.Text = Convert.ToDouble(cad.Rows[0]["r1"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["r2"]) <= 0) txtR2.Text = "0"; else txtR2.Text = Convert.ToDouble(cad.Rows[0]["r2"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["r3"]) <= 0) txtR3.Text = "0"; else txtR3.Text = Convert.ToDouble(cad.Rows[0]["r3"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["r4"]) <= 0) txtR4.Text = "0"; else txtR4.Text = Convert.ToDouble(cad.Rows[0]["r4"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["r5"]) <= 0) txtR5.Text = "0"; else txtR5.Text = Convert.ToDouble(cad.Rows[0]["r5"]).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["ro1"]) <= 0) txtRo1.Text = "0"; else txtRo1.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro1"])).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["ro2"]) <= 0) txtRo2.Text = "0"; else txtRo2.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro2"])).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["ro3"]) <= 0) txtRo3.Text = "0"; else txtRo3.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro3"])).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["ro4"]) <= 0) txtRo4.Text = "0"; else txtRo4.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro4"])).ToString("N2");
                if (Convert.ToDouble(cad.Rows[0]["ro5"]) <= 0) txtRo5.Text = "0"; else txtRo5.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["ro5"])).ToString("N2");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Tabela para " + Convert.ToDateTime(txtObs.Text).Date.Year.ToString() + " não preenchida!');", true);
            }
        }
    }
}
