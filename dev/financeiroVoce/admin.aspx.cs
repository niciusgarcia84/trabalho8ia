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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["IDUsuarioPermissao"].ToString().Contains("dm")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                carregarUsuarios();
            }
        }
        protected void carregarUsuarios()
        {
            UsuariosDL usuario = new UsuariosDL();
            DataTable cad = new DataTable();
            cad = usuario.listarUsuarios();
            if (cad != null)
            {
                grdDetalhes.DataSource = cad;
                grdDetalhes.DataBind();
            }
        }
        protected void grdDetalhes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

                CheckBox chkReceber = (CheckBox)e.Row.FindControl("chkReceber");
                chkReceber.Checked = (Convert.ToBoolean(row["Receber"]));
                CheckBox chkPagar = (CheckBox)e.Row.FindControl("chkPagar");
                chkPagar.Checked = (Convert.ToBoolean(row["Pagar"]));
                CheckBox chkCompras = (CheckBox)e.Row.FindControl("chkCompras");
                chkCompras.Checked = (Convert.ToBoolean(row["Compras"]));
                CheckBox chkEstoque = (CheckBox)e.Row.FindControl("chkEstoque");
                chkEstoque.Checked = (Convert.ToBoolean(row["Estoque"]));
                CheckBox chkCobranca = (CheckBox)e.Row.FindControl("chkCobranca");
                chkCobranca.Checked = (Convert.ToBoolean(row["Cobranca"]));
                CheckBox chkAdm = (CheckBox)e.Row.FindControl("chkAdm");
                chkAdm.Checked = (Convert.ToBoolean(row["Adm"]));
            }
        }
        protected void imgInserir_OnClick(object sender, EventArgs e)
        {
            UsuariosDL usuario = new UsuariosDL();
            usuario.cadastrar(txtNome.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Usuário cadastrado!');", true);
            txtNome.Text = "";
            carregarUsuarios();
        }
        protected void imgCancelar_OnClick(object sender, EventArgs e)
        {
            txtNome.Text = "";
        }
        protected void imgSalvar_Click(object sender, EventArgs e)
        {
            ImageButton imgSalvar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)imgSalvar.NamingContainer;
            HiddenField hdnIDusuario = (HiddenField)grdDetalhes.Rows[gvrow.RowIndex].FindControl("hdnIDusuario");
            CheckBox chkReceber = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkReceber");
            CheckBox chkPagar = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkPagar");
            CheckBox chkCompras = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkCompras");
            CheckBox chkEstoque = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkEstoque");
            CheckBox chkCobranca = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkCobranca");
            CheckBox chkAdm = (CheckBox)grdDetalhes.Rows[gvrow.RowIndex].FindControl("chkAdm");

            UsuariosDL usuario = new UsuariosDL();
            usuario.atualizarStatus(Convert.ToInt32(hdnIDusuario.Value), chkReceber.Checked, chkPagar.Checked, chkCompras.Checked, chkEstoque.Checked, chkCobranca.Checked, chkAdm.Checked);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Permissões alteradas!');", true);
        }
        protected void lnkZerar_Click(object sender, EventArgs e)
        {
            LinkButton lnkZerar = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)lnkZerar.NamingContainer;
            HiddenField hdnIDusuario = (HiddenField)grdDetalhes.Rows[gvrow.RowIndex].FindControl("hdnIDusuario");

            UsuariosDL usuario = new UsuariosDL();
            usuario.atualizarSenha(Convert.ToInt32(hdnIDusuario.Value));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('senha alterada para alterar*');", true);
        }
        protected void lnkRemover_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemover = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)lnkRemover.NamingContainer;
            HiddenField hdnIDusuario = (HiddenField)grdDetalhes.Rows[gvrow.RowIndex].FindControl("hdnIDusuario");

            UsuariosDL usuario = new UsuariosDL();
            usuario.atualizarAcesso(Convert.ToInt32(hdnIDusuario.Value));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('senha alterada para adm#');", true);
        }
    }
}
