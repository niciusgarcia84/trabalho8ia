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
    public partial class relTreinamentoPorEquipeEmail : System.Web.UI.Page
    {
        public double creditoFinal = 0;
        public double creditoFinalMesmo = 0;
        public double descontos = 0;
        public Int32 posEquipe = 0;

        public string treinamento
        {
            get
            {
                if (Request.QueryString["treinamento"] != null)
                    return (Request.QueryString["treinamento"]).ToString();
                return "Teste";
            }
        }
        public Int32 codigo
        {
            get
            {
                if (Request.QueryString["codigo"] != null)
                    return Convert.ToInt32(Request.QueryString["codigo"]);
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            if (!Session["IDUsuarioPermissao"].ToString().Contains("re")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                lblTreinamento.Text = treinamento.ToString();
                if (posEquipe == 0) carregarDrops();
                else carregarTreinandos();
            }
        }
        private void carregarDrops()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarEquipesPorTreinamento(codigo);
            if (cad != null)
            {
                grdEquipe.DataSource = cad;
                grdEquipe.DataBind();
            }
            posEquipe = 1;
        }
        protected void carregarTreinandos()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            //cad = cadDL.ListarTreinanandosPorTreinamentoEEquipe(codigo, Convert.ToInt32(ddlEquipe.SelectedValue));
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
        }
        protected void grdEquipe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

                HiddenField hdnEquipe = (HiddenField)e.Row.FindControl("hdnEquipe");
                hdnEquipe.Value = Convert.ToString(row["IDEquipe"]);

                Label lblEquipe = (Label)e.Row.FindControl("lblEquipe");
                lblEquipe.Text = Convert.ToString(row["Equipe"]);
            }
        }
        protected void grdTreinandos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

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
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            hdnEmail.Value = hdnEmail.Value.ToString() + ";teresa@1234voce.com.br";
            String corpo = "<h2>" + lblTreinamento.Text.ToString() + "</h2><table>";
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                Label lblnome = (Label)item.FindControl("lblNome");
                corpo += "<tr><td style=\"background-color:" + lblnome.BackColor.Name + "\">" + lblnome.Text.ToString() + "</td></tr>";
            }
            corpo += "</table>";
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
                //mail.Subject = ddlEquipe.SelectedItem.Text.ToString() + assunto;
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