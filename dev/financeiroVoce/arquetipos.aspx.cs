using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using financeiroVoce.DataLayer;
using System.Data;

namespace financeiroVoce
{
    public partial class arquetipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                carregarDrops();
            }
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarProximosDiamonds();
            if (cad != null)
            {
                ddlTreinamento.DataSource = cad;
                ddlTreinamento.DataTextField = "Descricao";
                ddlTreinamento.DataValueField = "IDTreinamento";
                ddlTreinamento.DataBind();
            }
        }
        protected void btnFiltrarTreinamento_Click(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinanandosArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.verificarDataDiamonds(Convert.ToInt32(ddlTreinamento.SelectedValue));
            if (Convert.ToDateTime(cad.Rows[0]["DTInicio"].ToString()) < DateTime.Now.AddDays(-4))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Este treinamento já foi realizado e não pode ser alterado!');", true);
                return;
            }

            ImageButton btnSalvar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnSalvar.NamingContainer;
            HiddenField hdnIDTreinando = (HiddenField)grdTreinandos.Rows[gvrow.RowIndex].FindControl("hdnIDTreinando");
            TextBox txtArquetipo = (TextBox)grdTreinandos.Rows[gvrow.RowIndex].FindControl("txtArquetipo");
            TextBox txtCracha = (TextBox)grdTreinandos.Rows[gvrow.RowIndex].FindControl("txtCracha");
            TreinandosDL treiDL = new TreinandosDL();
            treiDL.atualizarArquetipo(Convert.ToInt32(hdnIDTreinando.Value), txtArquetipo.Text.ToString(), txtCracha.Text.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Alterado Arquétipo!');", true);
        }
    }
}