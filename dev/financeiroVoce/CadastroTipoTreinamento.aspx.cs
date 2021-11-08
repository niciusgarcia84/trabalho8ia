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
    public partial class CadastroTipoTreinamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("dm")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                CarregarGrid();
            }
        }
        private void CarregarGrid()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.carregarTiposTreinamentos();
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
            if (txtDescricao.Text != "" && txtNome.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.novoTipoTreinamento(txtDescricao.Text.ToString(), txtNome.Text.ToString());
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
            txtDescricao.Text = "";
            txtNome.Text = "";
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            ImageButton btnAlterar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnAlterar.NamingContainer;
            HiddenField hdnIDTabela = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnIDTabela");
            Label lblDescricao = (Label)grdEquipes.Rows[gvrow.RowIndex].FindControl("lblDescricao");
            HiddenField hdnNome = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnNome");
            hdnIDTabelaAlterar.Value = hdnIDTabela.Value;
            txtDescricao.Text = lblDescricao.Text;
            txtNome.Text = hdnNome.Value.ToString();

            btnAtualizar.Visible = true;
            btnCancelar.Visible = true;
            btnInserir.Visible = false;
            lblTitulo.Text = "Editar";
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "" && txtNome.Text != "")
            {
                CadastrosDL cadDL = new CadastrosDL();
                cadDL.AtualizarTipoTreinamento(Convert.ToInt32(hdnIDTabelaAlterar.Value), txtDescricao.Text.ToString(), txtNome.Text.ToString());
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
            cadDL.removerTipoTreinamento(Convert.ToInt32(hdnIDTabelaAlterar.Value));
            limparCampos();
            CarregarGrid();
        }
        protected void exibirExcluir(object sender, EventArgs e)
        {
            if (lblTitulo.Text == "Editar") btnOcultar.Visible = true;
        }
    }
}