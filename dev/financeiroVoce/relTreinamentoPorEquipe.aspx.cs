using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using financeiroVoce.DataLayer;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Net.Mail;
using System.Net;


namespace financeiroVoce
{
    public partial class relTreinamentoPorEquipe : System.Web.UI.Page
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
            cad = cadDL.ListarEquipesPorTreinamento(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
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
            hdnEmail.Value = "";
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), ddlTreinamento.SelectedItem.ToString());
            if (ddlEquipe.SelectedItem.ToString() == "Todos") divEmail.Visible = false;
            else divEmail.Visible = true;
        }
        protected void carregarTreinandos(Int32 a, string b)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            if (ddlEquipe.SelectedValue == "Todos") cad = cadDL.ListarTreinanandosPorTreinamento(a);
            else cad = cadDL.ListarTreinanandosPorTreinamentoEEquipe(a, Convert.ToInt32(ddlEquipe.SelectedValue));
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

                hdnEmail.Value = Convert.ToString(row["Email"]);

                if (ddlEquipe.SelectedItem.ToString() == "Todos")
                {
                    Label lblEquipe = (Label)e.Row.FindControl("lblEquipe");
                    lblEquipe.Text = Convert.ToString(row["Equipe"]);
                }

                HiddenField hdnInvestimento = (HiddenField)e.Row.FindControl("hdnInvestimento");
                hdnInvestimento.Value = Convert.ToString(row["Investimento"]);

                Label lblNome = (Label)e.Row.FindControl("lblNome");
                lblNome.Text = Convert.ToString(row["Nome"]);

                double totalpagto = Convert.ToDouble(row["TotalPagto"]);
                totalpagto = totalpagto + Convert.ToDouble(row["Desconto"]);
                if (totalpagto >= Convert.ToDouble(hdnInvestimento.Value))
                {
                    e.Row.BackColor = Color.LightSteelBlue;
                    lblNome.BackColor = Color.LightSteelBlue;
                }
                else if (totalpagto == 0)
                {
                    e.Row.BackColor = Color.Yellow;
                    lblNome.BackColor = Color.Yellow;
                }
                else if (totalpagto > 0)
                {
                    e.Row.BackColor = Color.Red;
                    e.Row.ForeColor = Color.White;
                    lblNome.BackColor = Color.Red;
                    lblNome.ForeColor = Color.White;
                }
                if (Convert.ToBoolean(row["experiente"]))
                {
                    e.Row.BackColor = Color.Green;
                    lblNome.BackColor = Color.Green;
                }
            }
        }
        private void calculaTotal()
        {
            Int32 a = 0;
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                a++;
            }
            lblTotalTreinandos.Text = "Treinandos " + a.ToString();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            hdnEmail.Value = hdnEmail.Value.ToString() + ";teresa@1234voce.com.br;alessandraramiro@1234voce.com.br;admsp@1234voce.com.br";
            String corpo = "<h2>" + lblTreinamento.Text.ToString() + "</h2><table>";
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                Label lblnome = (Label)item.FindControl("lblNome");
                corpo += "<tr><td style=\"background-color:" + lblnome.BackColor.Name + "\">" + lblnome.Text.ToString() + "</td></tr>";
            }
            corpo += "</table><br><i>Obs.: Favor Responder Esse e-mail para todos!</i>";
            if (SendingEmail(" - Confirmação de treinandos", hdnEmail.Value.ToString(), corpo.ToString())) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Enviado!');", true);
        }
        public bool SendingEmail(string assunto, string para, string corpo)
        {
            try
            {
                string de = Convert.ToString(ConfigurationManager.AppSettings["EnvioEmailChaveDe"]);
                string smtpEndereco = Convert.ToString(ConfigurationManager.AppSettings["EnvioEmailChaveSmtpEndereco"]);
                string login = Convert.ToString(ConfigurationManager.AppSettings["EnvioEmailChaveLogin"]);
                string senha = Convert.ToString(ConfigurationManager.AppSettings["EnvioEmailChaveSenha"]);
                bool autentica = Convert.ToBoolean(ConfigurationManager.AppSettings["EnvioEmailChaveAutentica"]);

                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress(de);
                if (para.Length > 2)
                {
                    string[] vetorPara = para.Split(';');

                    for (int i = 0; i < vetorPara.Length; i++)
                    {
                        if (vetorPara[i].Length > 0)
                            mail.To.Add(vetorPara[i]);
                    }
                }
                mail.Priority = System.Net.Mail.MailPriority.Normal;
                mail.IsBodyHtml = true;
                mail.Subject = ddlEquipe.SelectedItem.Text.ToString() + assunto;
                mail.Body = corpo;
                mail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpEndereco);
                if (autentica)
                {
                    smtp.Credentials = new NetworkCredential(login, senha);
                }
                smtp.Send(mail);
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}