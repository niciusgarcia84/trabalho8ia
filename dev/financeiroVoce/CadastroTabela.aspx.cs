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
    public partial class CadastroTabela : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("dm")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                carregarDrops();
                CarregarGrid();
                txtAno.Text = DateTime.Now.Date.Year.ToString();
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
            cad = cadDL.carregarTabelas();
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
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtAno.Text != "" && txtV1.Text != "" && txtV2.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.novoTreinamentoTabela(Convert.ToInt32(txtAno.Text), ddlTipo.SelectedValue.ToString(), Convert.ToDouble(txtV1.Text.ToString()), Convert.ToDouble(txtV2.Text.ToString()), Convert.ToDouble(txtV3.Text.ToString()), Convert.ToDouble(txtV4.Text.ToString()), Convert.ToDouble(txtR1.Text.ToString()), Convert.ToDouble(txtR2.Text.ToString()), Convert.ToDouble(txtR3.Text.ToString()), Convert.ToDouble(txtR4.Text.ToString()), Convert.ToDouble(txtR5.Text.ToString()), Convert.ToDouble(txtRo1.Text.ToString()), Convert.ToDouble(txtRo2.Text.ToString()), Convert.ToDouble(txtRo3.Text.ToString()), Convert.ToDouble(txtRo4.Text.ToString()), Convert.ToDouble(txtRo5.Text.ToString()));
                limparCampos();
                CarregarGrid();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Favor preencher os campos nome, ano e valor à vista!');", true);
            }
        }
        public void limparCampos()
        {
            txtAno.Text = DateTime.Now.Date.Year.ToString();
            txtV1.Text = "0";
            txtV2.Text = "0";
            txtV3.Text = "0";
            txtV4.Text = "0";
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
            HiddenField hdnIDTabela = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnIDTabela");
            Label lblAno = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblAno");
            Label lblNome = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblNome");
            hdnIDTabelaAlterar.Value = hdnIDTabela.Value;
            txtAno.Text = lblAno.Text;
            ddlTipo.SelectedValue = lblNome.Text;

            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTabelaTreinamento(Convert.ToInt32(hdnIDTabela.Value));
            if (Convert.ToDouble(cad.Rows[0]["v1"]) <= 0) txtV1.Text = "0"; else txtV1.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["v1"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["v2"]) <= 0) txtV2.Text = "0"; else txtV2.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["v2"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["v3"]) <= 0) txtV3.Text = "0"; else txtV3.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["v3"])).ToString("N2");
            if (Convert.ToDouble(cad.Rows[0]["v4"]) <= 0) txtV4.Text = "0"; else txtV4.Text = Convert.ToDouble(Convert.ToDouble(cad.Rows[0]["v4"])).ToString("N2");
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
            if (txtAno.Text != "" && txtV1.Text != "" && txtV2.Text != "" && txtV3.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.atualizarTabela(Convert.ToInt32(hdnIDTabelaAlterar.Value), Convert.ToInt32(txtAno.Text.ToString()), ddlTipo.SelectedValue.ToString(), Convert.ToDouble(txtV1.Text.ToString()),
                        Convert.ToDouble(txtV2.Text.ToString()), Convert.ToDouble(txtV3.Text.ToString()), Convert.ToDouble(txtV4.Text.ToString()), Convert.ToDouble(txtR1.Text.ToString()),
                        Convert.ToDouble(txtR2.Text.ToString()), Convert.ToDouble(txtR3.Text.ToString()), Convert.ToDouble(txtR4.Text.ToString()), Convert.ToDouble(txtR5.Text.ToString()), Convert.ToDouble(txtRo1.Text.ToString()),
                        Convert.ToDouble(txtRo2.Text.ToString()), Convert.ToDouble(txtRo3.Text.ToString()), Convert.ToDouble(txtRo4.Text.ToString()), Convert.ToDouble(txtRo5.Text.ToString()));
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
            cadDL.removerTabela(Convert.ToInt32(hdnIDTabelaAlterar.Value));
            limparCampos();
            CarregarGrid();
        }
        protected void exibirExcluir(object sender, EventArgs e)
        {
            if (lblTitulo.Text == "Editar") btnOcultar.Visible = true;
        }
    }
}
