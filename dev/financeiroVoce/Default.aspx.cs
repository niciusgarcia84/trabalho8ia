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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogado"] == null)
            {
                cadastros.Visible = false;
                validar.Visible = true;
            }
            else
            {
                cadastros.Visible = true;
                validar.Visible = false;
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Informe um usuário e senha!');", true);
                return;
            }

            UsuariosDL usuarioDL = new UsuariosDL();
            DataTable usu = new DataTable();
            usu = usuarioDL.verificarSenha(txtUser.Text, txtPass.Text);

            if (usu != null && usu.Rows.Count > 0)
            {
                Session["UsuarioLogado"] = txtUser.Text;
                Session["IDUsuarioLogado"] = usu.Rows[0]["IDUsuario"].ToString();
                if (Convert.ToBoolean(usu.Rows[0]["Receber"])) Session["IDUsuarioPermissao"] += "re";
                if (Convert.ToBoolean(usu.Rows[0]["Pagar"])) Session["IDUsuarioPermissao"] += "pg";
                if (Convert.ToBoolean(usu.Rows[0]["Compras"])) Session["IDUsuarioPermissao"] += "co";
                if (Convert.ToBoolean(usu.Rows[0]["Estoque"])) Session["IDUsuarioPermissao"] += "st";
                if (Convert.ToBoolean(usu.Rows[0]["Cobranca"])) Session["IDUsuarioPermissao"] += "ba";
                if (Convert.ToBoolean(usu.Rows[0]["Adm"]))
                {
                    Session["IDUsuarioPermissao"] += "dm";
                    usuarioDL.lancarLog(txtUser.Text, System.Environment.MachineName, "Logado");
                }
                cadastros.Visible = true;
                validar.Visible = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Digite um usuário e/ou senha válidos!');", true);
            }
        }
        protected void lnkSair_OnClick(object sender, EventArgs e)
        {
            Session["UsuarioLogado"] = null;
            Session["IDUsuarioLogado"] = null;
            Session["IDUsuarioPermissao"] = null;
            string _open = "window.open('Default.aspx', '_self');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sair", _open, true);
        }
    }
}