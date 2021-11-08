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
    public partial class imprimirGrupoDiamond : System.Web.UI.Page
    {
        public Color[] cores = new Color[10];
        public String[] nmCores = new String[10];
        public Color corPadrao = new Color();
        public string nmCorPadrao;
        public Int32 numero = 0;

        public string diamondID
        {
            get
            {
                if (Request.QueryString["diamond"] != null)
                    return Convert.ToString(Request.QueryString["diamond"]);
                return "0";
            }
        }
        public string grupoID
        {
            get
            {
                if (Request.QueryString["grupo"] != null)
                    return Convert.ToString(Convert.ToInt32(Request.QueryString["grupo"]) - 1);
                return "0";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregarCor();
                CarregarGrid();
            }
        }
        private void CarregarGrid()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarGruposPorTreinamento(Convert.ToInt32(diamondID), "G" + grupoID.ToString(), true);
            if (cad.Rows.Count > 0)
            {
                grdParticipantes.DataSource = cad;
                grdParticipantes.DataBind();
            }
            cad = null;
            cad = cadDL.nomeTreinamento(Convert.ToInt32(diamondID));
            lblTreinamento.Text = cad.Rows[0]["Descricao"].ToString();
        }
        private void carregarCor()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarCorGrupoPorTreinamento(Convert.ToInt32(diamondID), Convert.ToInt32(grupoID));
            atribuirCores();
            corPadrao = cores[Convert.ToInt32(cad.Rows[0]["Cor"])];
            nmCorPadrao = nmCores[Convert.ToInt32(cad.Rows[0]["Cor"])];
            lblCor.Text = nmCores[Convert.ToInt32(cad.Rows[0]["Cor"])];
            lblCor.ForeColor = cores[Convert.ToInt32(cad.Rows[0]["Cor"])];
        }
        private void atribuirCores()
        {
            cores[0] = Color.Blue;
            cores[1] = Color.Red;
            cores[2] = Color.Yellow;
            cores[3] = Color.Black;
            cores[4] = Color.Purple;
            cores[5] = Color.Orange;
            cores[6] = Color.Pink;
            cores[7] = Color.Gold;
            cores[8] = Color.White;
            cores[9] = Color.Green;

            nmCores[0] = "Azul";
            nmCores[1] = "Vermelho";
            nmCores[2] = "Amarelo";
            nmCores[3] = "Preto";
            nmCores[4] = "Roxo";
            nmCores[5] = "Laranja";
            nmCores[6] = "Rosa";
            nmCores[7] = "Ouro";
            nmCores[8] = "Branco";
            nmCores[9] = "Verde";
        }
        protected void grdParticipantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

                Label lblCor = (Label)e.Row.FindControl("lblCor");
                lblCor.BackColor = corPadrao;
                lblCor.Text = nmCorPadrao.ToString();
                if (nmCorPadrao.ToString() == "Amarelo") lblCor.ForeColor = Color.Black;

                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (row["Status"].ToString() == "1") lblStatus.Text = "Líder";
                else if (row["Status"].ToString() == "2") lblStatus.Text = "Vice-Líder";
                else if (row["Status"].ToString() == "3") lblStatus.Text = "Bandeira";

                if (row["experiente"].ToString() == "True") lblStatus.Text += "  EXP.";

                Label lblNumero = (Label)e.Row.FindControl("lblNumero");
                numero++;
                lblNumero.Text = numero.ToString();
            }
        }
    }
}
