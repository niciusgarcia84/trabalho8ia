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
    public partial class equipesDiamonds : System.Web.UI.Page
    {
        public Color[] cores = new Color[10];

        public string treinamentoID
        {
            get
            {
                if (Request.QueryString["id"] != null)
                    return Convert.ToString(Request.QueryString["id"]);
                return "1";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            //if (!Session["IDUsuarioPermissao"].ToString().Contains("re")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                atribuirCores();
                carregarDrops();
                if (treinamentoID != "1") ddlTreinamento.SelectedValue = treinamentoID.ToString();
                carregar();
            }
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
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarProximosDiamonds();
            if (cad.Rows.Count > 0)
            {
                ddlTreinamento.DataSource = cad;
                ddlTreinamento.DataTextField = "Descricao";
                ddlTreinamento.DataValueField = "IDTreinamento";
                ddlTreinamento.DataBind();
            }
        }
        protected void btnFiltrarTreinamento_Click(object sender, EventArgs e)
        {
            carregar();
        }
        protected void carregar()
        {
            divResumo.Visible = true;
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G0", GridView1);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G0", GridView1a);
            calculaTotal("G0", GridView1);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G1", GridView2);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G1", GridView2a);
            calculaTotal("G1", GridView2);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G2", GridView3);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G2", GridView3a);
            calculaTotal("G2", GridView3);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G3", GridView4);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G3", GridView4a);
            calculaTotal("G3", GridView4);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G4", GridView5);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G4", GridView5a);
            calculaTotal("G4", GridView5);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G5", GridView6);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G5", GridView6a);
            calculaTotal("G5", GridView6);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G6", GridView7);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G6", GridView7a);
            calculaTotal("G6", GridView7);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G7", GridView8);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G7", GridView8a);
            calculaTotal("G7", GridView8);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G8", GridView9);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G8", GridView9a);
            calculaTotal("G8", GridView9);

            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G9", GridView10);
            carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G9", GridView10a);
            calculaTotal("G9", GridView10);

            carregarTreinandosSemGrupo();
            carregarCores();
        }
        protected void carregarTreinandos(Int32 a, String grupo, GridView grd)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarGruposPorTreinamento(a, grupo, false);
            if (cad.Rows.Count > 0)
            {
                grd.DataSource = cad;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        protected void carregarTotalArquetipos(Int32 a, String grupo, GridView grd)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarArquetiposPorGrupoTreinamentos(a, grupo);
            if (cad.Rows.Count > 0)
            {
                grd.DataSource = cad;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
            cad = null;
            cad = cadDL.ListarArquetiposPorSubtipoTreinamentos(a, grupo);
            if (cad.Rows.Count > 0)
            {
                switch (grupo)
                {
                    case ("G0"):
                        lblTotalA0.Text = cad.Rows[0][0].ToString();
                        lblTotalB0.Text = cad.Rows[0][1].ToString();
                        lblTotalC0.Text = cad.Rows[0][2].ToString();
                        lblTotalD0.Text = cad.Rows[0][3].ToString();
                        lblTotalE0.Text = cad.Rows[0][4].ToString();
                        lblTotalF0.Text = cad.Rows[0][5].ToString();
                        lblTotalG0.Text = cad.Rows[0][6].ToString();
                        lblTotalH0.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G1"):
                        lblTotalA1.Text = cad.Rows[0][0].ToString();
                        lblTotalB1.Text = cad.Rows[0][1].ToString();
                        lblTotalC1.Text = cad.Rows[0][2].ToString();
                        lblTotalD1.Text = cad.Rows[0][3].ToString();
                        lblTotalE1.Text = cad.Rows[0][4].ToString();
                        lblTotalF1.Text = cad.Rows[0][5].ToString();
                        lblTotalG1.Text = cad.Rows[0][6].ToString();
                        lblTotalH1.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G2"):
                        lblTotalA2.Text = cad.Rows[0][0].ToString();
                        lblTotalB2.Text = cad.Rows[0][1].ToString();
                        lblTotalC2.Text = cad.Rows[0][2].ToString();
                        lblTotalD2.Text = cad.Rows[0][3].ToString();
                        lblTotalE2.Text = cad.Rows[0][4].ToString();
                        lblTotalF2.Text = cad.Rows[0][5].ToString();
                        lblTotalG2.Text = cad.Rows[0][6].ToString();
                        lblTotalH2.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G3"):
                        lblTotalA3.Text = cad.Rows[0][0].ToString();
                        lblTotalB3.Text = cad.Rows[0][1].ToString();
                        lblTotalC3.Text = cad.Rows[0][2].ToString();
                        lblTotalD3.Text = cad.Rows[0][3].ToString();
                        lblTotalE3.Text = cad.Rows[0][4].ToString();
                        lblTotalF3.Text = cad.Rows[0][5].ToString();
                        lblTotalG3.Text = cad.Rows[0][6].ToString();
                        lblTotalH3.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G4"):
                        lblTotalA4.Text = cad.Rows[0][0].ToString();
                        lblTotalB4.Text = cad.Rows[0][1].ToString();
                        lblTotalC4.Text = cad.Rows[0][2].ToString();
                        lblTotalD4.Text = cad.Rows[0][3].ToString();
                        lblTotalE4.Text = cad.Rows[0][4].ToString();
                        lblTotalF4.Text = cad.Rows[0][5].ToString();
                        lblTotalG4.Text = cad.Rows[0][6].ToString();
                        lblTotalH4.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G5"):
                        lblTotalA5.Text = cad.Rows[0][0].ToString();
                        lblTotalB5.Text = cad.Rows[0][1].ToString();
                        lblTotalC5.Text = cad.Rows[0][2].ToString();
                        lblTotalD5.Text = cad.Rows[0][3].ToString();
                        lblTotalE5.Text = cad.Rows[0][4].ToString();
                        lblTotalF5.Text = cad.Rows[0][5].ToString();
                        lblTotalG5.Text = cad.Rows[0][6].ToString();
                        lblTotalH5.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G6"):
                        lblTotalA6.Text = cad.Rows[0][0].ToString();
                        lblTotalB6.Text = cad.Rows[0][1].ToString();
                        lblTotalC6.Text = cad.Rows[0][2].ToString();
                        lblTotalD6.Text = cad.Rows[0][3].ToString();
                        lblTotalE6.Text = cad.Rows[0][4].ToString();
                        lblTotalF6.Text = cad.Rows[0][5].ToString();
                        lblTotalG6.Text = cad.Rows[0][6].ToString();
                        lblTotalH6.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G7"):
                        lblTotalA7.Text = cad.Rows[0][0].ToString();
                        lblTotalB7.Text = cad.Rows[0][1].ToString();
                        lblTotalC7.Text = cad.Rows[0][2].ToString();
                        lblTotalD7.Text = cad.Rows[0][3].ToString();
                        lblTotalE7.Text = cad.Rows[0][4].ToString();
                        lblTotalF7.Text = cad.Rows[0][5].ToString();
                        lblTotalG7.Text = cad.Rows[0][6].ToString();
                        lblTotalH7.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G8"):
                        lblTotalA8.Text = cad.Rows[0][0].ToString();
                        lblTotalB8.Text = cad.Rows[0][1].ToString();
                        lblTotalC8.Text = cad.Rows[0][2].ToString();
                        lblTotalD8.Text = cad.Rows[0][3].ToString();
                        lblTotalE8.Text = cad.Rows[0][4].ToString();
                        lblTotalF8.Text = cad.Rows[0][5].ToString();
                        lblTotalG8.Text = cad.Rows[0][6].ToString();
                        lblTotalH8.Text = cad.Rows[0][7].ToString();
                        return;
                    case ("G9"):
                        lblTotalA9.Text = cad.Rows[0][0].ToString();
                        lblTotalB9.Text = cad.Rows[0][1].ToString();
                        lblTotalC9.Text = cad.Rows[0][2].ToString();
                        lblTotalD9.Text = cad.Rows[0][3].ToString();
                        lblTotalE9.Text = cad.Rows[0][4].ToString();
                        lblTotalF9.Text = cad.Rows[0][5].ToString();
                        lblTotalG9.Text = cad.Rows[0][6].ToString();
                        lblTotalH9.Text = cad.Rows[0][7].ToString();
                        return;
                    default:
                        return;
                }
            }
            else
            {
                switch (grupo)
                {
                    case ("G0"):
                        lblTotalA0.Text = "";
                        lblTotalB0.Text = "";
                        lblTotalC0.Text = "";
                        lblTotalD0.Text = "";
                        lblTotalE0.Text = "";
                        lblTotalF0.Text = "";
                        lblTotalG0.Text = "";
                        lblTotalH0.Text = "";
                        return;
                    case ("G1"):
                        lblTotalA1.Text = "";
                        lblTotalB1.Text = "";
                        lblTotalC1.Text = "";
                        lblTotalD1.Text = "";
                        lblTotalE1.Text = "";
                        lblTotalF1.Text = "";
                        lblTotalG1.Text = "";
                        lblTotalH1.Text = "";
                        return;
                    case ("G2"):
                        lblTotalA2.Text = "";
                        lblTotalB2.Text = "";
                        lblTotalC2.Text = "";
                        lblTotalD2.Text = "";
                        lblTotalE2.Text = "";
                        lblTotalF2.Text = "";
                        lblTotalG2.Text = "";
                        lblTotalH2.Text = "";
                        return;
                    case ("G3"):
                        lblTotalA3.Text = "";
                        lblTotalB3.Text = "";
                        lblTotalC3.Text = "";
                        lblTotalD3.Text = "";
                        lblTotalE3.Text = "";
                        lblTotalF3.Text = "";
                        lblTotalG3.Text = "";
                        lblTotalH3.Text = "";
                        return;
                    case ("G4"):
                        lblTotalA4.Text = "";
                        lblTotalB4.Text = "";
                        lblTotalC4.Text = "";
                        lblTotalD4.Text = "";
                        lblTotalE4.Text = "";
                        lblTotalF4.Text = "";
                        lblTotalG4.Text = "";
                        lblTotalH4.Text = "";
                        return;
                    case ("G5"):
                        lblTotalA5.Text = "";
                        lblTotalB5.Text = "";
                        lblTotalC5.Text = "";
                        lblTotalD5.Text = "";
                        lblTotalE5.Text = "";
                        lblTotalF5.Text = "";
                        lblTotalG5.Text = "";
                        lblTotalH5.Text = "";
                        return;
                    case ("G6"):
                        lblTotalA6.Text = "";
                        lblTotalB6.Text = "";
                        lblTotalC6.Text = "";
                        lblTotalD6.Text = "";
                        lblTotalE6.Text = "";
                        lblTotalF6.Text = "";
                        lblTotalG6.Text = "";
                        lblTotalH6.Text = "";
                        return;
                    case ("G7"):
                        lblTotalA7.Text = "";
                        lblTotalB7.Text = "";
                        lblTotalC7.Text = "";
                        lblTotalD7.Text = "";
                        lblTotalE7.Text = "";
                        lblTotalF7.Text = "";
                        lblTotalG7.Text = "";
                        lblTotalH7.Text = "";
                        return;
                    case ("G8"):
                        lblTotalA8.Text = "";
                        lblTotalB8.Text = "";
                        lblTotalC8.Text = "";
                        lblTotalD8.Text = "";
                        lblTotalE8.Text = "";
                        lblTotalF8.Text = "";
                        lblTotalG8.Text = "";
                        lblTotalH8.Text = "";
                        return;
                    case ("G9"):
                        lblTotalA9.Text = "";
                        lblTotalB9.Text = "";
                        lblTotalC9.Text = "";
                        lblTotalD9.Text = "";
                        lblTotalE9.Text = "";
                        lblTotalF9.Text = "";
                        lblTotalG9.Text = "";
                        lblTotalH9.Text = "";
                        return;
                    default:
                        return;
                }
            }
        }
        protected void calculaTotal(String grupo, GridView grd)
        {
            Int32 total = 0;
            foreach (GridViewRow item in grd.Rows)
            {
                total++;
            }
            switch (grupo)
            {
                case ("G0"):
                    lblTotalTreinandos0.Text = total.ToString();
                    return;
                case ("G1"):
                    lblTotalTreinandos1.Text = total.ToString();
                    return;
                case ("G2"):
                    lblTotalTreinandos2.Text = total.ToString();
                    return;
                case ("G3"):
                    lblTotalTreinandos3.Text = total.ToString();
                    return;
                case ("G4"):
                    lblTotalTreinandos4.Text = total.ToString();
                    return;
                case ("G5"):
                    lblTotalTreinandos5.Text = total.ToString();
                    return;
                case ("G6"):
                    lblTotalTreinandos6.Text = total.ToString();
                    return;
                case ("G7"):
                    lblTotalTreinandos7.Text = total.ToString();
                    return;
                case ("G8"):
                    lblTotalTreinandos8.Text = total.ToString();
                    return;
                case ("G9"):
                    lblTotalTreinandos9.Text = total.ToString();
                    return;
                default:
                    return;
            }
        }
        protected void carregarTreinandosSemGrupo()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinanandosPorTreinamentoSemGrupo(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
        }
        protected void carregarGrupo(String grupo)
        {
            switch (grupo)
            {
                case ("0"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G0", GridView1);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G0", GridView1a);
                    calculaTotal("G0", GridView1);
                    return;
                case ("1"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G1", GridView2);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G1", GridView2a);
                    calculaTotal("G1", GridView2);
                    return;
                case ("2"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G2", GridView3);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G2", GridView3a);
                    calculaTotal("G2", GridView3);
                    return;
                case ("3"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G3", GridView4);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G3", GridView4a);
                    calculaTotal("G3", GridView4);
                    return;
                case ("4"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G4", GridView5);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G4", GridView5a);
                    calculaTotal("G4", GridView5);
                    return;
                case ("5"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G5", GridView6);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G5", GridView6a);
                    calculaTotal("G5", GridView6);
                    return;
                case ("6"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G6", GridView7);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G6", GridView7a);
                    calculaTotal("G6", GridView7);
                    return;
                case ("7"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G7", GridView8);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G7", GridView8a);
                    calculaTotal("G7", GridView8);
                    return;
                case ("8"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G8", GridView9);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G8", GridView9a);
                    calculaTotal("G8", GridView9);
                    return;
                case ("9"):
                    carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G9", GridView10);
                    carregarTotalArquetipos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G9", GridView10a);
                    calculaTotal("G9", GridView10);
                    return;
                default:
                    return;
            }
        }
        protected void carregarCores()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarCoresPorTreinamento(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            atribuirCores();
            if (cad.Rows.Count > 0)
            {
                txtCor1.BackColor = cores[Convert.ToInt32(cad.Rows[0]["Cor"])];
                txtCor1.ForeColor = txtCor1.BackColor;
                txtCor1.Text = cad.Rows[0]["Cor"].ToString();
                txtCor2.BackColor = cores[Convert.ToInt32(cad.Rows[1]["Cor"])];
                txtCor2.ForeColor = txtCor2.BackColor;
                txtCor2.Text = cad.Rows[1]["Cor"].ToString();
                txtCor3.BackColor = cores[Convert.ToInt32(cad.Rows[2]["Cor"])];
                txtCor3.ForeColor = txtCor3.BackColor;
                txtCor3.Text = cad.Rows[2]["Cor"].ToString();
                txtCor4.BackColor = cores[Convert.ToInt32(cad.Rows[3]["Cor"])];
                txtCor4.ForeColor = txtCor4.BackColor;
                txtCor4.Text = cad.Rows[3]["Cor"].ToString();
                txtCor5.BackColor = cores[Convert.ToInt32(cad.Rows[4]["Cor"])];
                txtCor5.ForeColor = txtCor5.BackColor;
                txtCor5.Text = cad.Rows[4]["Cor"].ToString();
                txtCor6.BackColor = cores[Convert.ToInt32(cad.Rows[5]["Cor"])];
                txtCor6.ForeColor = txtCor6.BackColor;
                txtCor6.Text = cad.Rows[5]["Cor"].ToString();
                txtCor7.BackColor = cores[Convert.ToInt32(cad.Rows[6]["Cor"])];
                txtCor7.ForeColor = txtCor7.BackColor;
                txtCor7.Text = cad.Rows[6]["Cor"].ToString();
                txtCor8.BackColor = cores[Convert.ToInt32(cad.Rows[7]["Cor"])];
                txtCor8.ForeColor = txtCor8.BackColor;
                txtCor8.Text = cad.Rows[7]["Cor"].ToString();
                txtCor9.BackColor = cores[Convert.ToInt32(cad.Rows[8]["Cor"])];
                txtCor9.ForeColor = txtCor9.BackColor;
                txtCor9.Text = cad.Rows[8]["Cor"].ToString();
                txtCor10.BackColor = cores[Convert.ToInt32(cad.Rows[9]["Cor"])];
                txtCor10.ForeColor = txtCor10.BackColor;
                txtCor10.Text = cad.Rows[9]["Cor"].ToString();
            }
            else
            {
                txtCor1.BackColor = Color.White;
                txtCor1.ForeColor = txtCor1.BackColor;
                txtCor1.Text = "";
                txtCor2.BackColor = Color.White;
                txtCor2.ForeColor = txtCor2.BackColor;
                txtCor2.Text = "";
                txtCor3.BackColor = Color.White;
                txtCor3.ForeColor = txtCor3.BackColor;
                txtCor3.Text = "";
                txtCor4.BackColor = Color.White;
                txtCor4.ForeColor = txtCor4.BackColor;
                txtCor4.Text = "";
                txtCor5.BackColor = Color.White;
                txtCor5.ForeColor = txtCor5.BackColor;
                txtCor5.Text = "";
                txtCor6.BackColor = Color.White;
                txtCor6.ForeColor = txtCor6.BackColor;
                txtCor6.Text = "";
                txtCor7.BackColor = Color.White;
                txtCor7.ForeColor = txtCor7.BackColor;
                txtCor7.Text = "";
                txtCor8.BackColor = Color.White;
                txtCor8.ForeColor = txtCor8.BackColor;
                txtCor8.Text = "";
                txtCor9.BackColor = Color.White;
                txtCor9.ForeColor = txtCor9.BackColor;
                txtCor9.Text = "";
                txtCor10.BackColor = Color.White;
                txtCor10.ForeColor = txtCor10.BackColor;
                txtCor10.Text = "";
            }
        }
        protected void btnSalvarDestinos_Click(object sender, EventArgs e)
        {
            ImageButton btnSalvar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnSalvar.NamingContainer;
            GridView gdv = (GridView)gvrow.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)gdv.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            DropDownList ddlGrupo = (DropDownList)gdv.Rows[gvrow.RowIndex].FindControl("ddlGrupo");

            TreinandosDL cadDL = new TreinandosDL();
            cadDL.atualizarGupoDiamond(Convert.ToInt32(hdnIDLista.Value), ddlGrupo.SelectedValue.ToString());
            carregarGrupo(Convert.ToInt32(Convert.ToInt32(btnSalvar.ID.Substring(9, 1).ToString()) - 1).ToString());
            carregarGrupo(ddlGrupo.SelectedValue.Substring(1, 1).ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Alterado grupo do treinando!');", true);
        }
        protected void btnSalvarDestinoSem_Click(object sender, EventArgs e)
        {
            ImageButton btnSalvar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnSalvar.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)grdTreinandos.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            DropDownList ddlGrupo = (DropDownList)grdTreinandos.Rows[gvrow.RowIndex].FindControl("ddlGrupo");
            TreinandosDL cadDL = new TreinandosDL();
            Int32 grupo = Convert.ToInt32(ddlGrupo.SelectedItem.ToString()) - 1;
            cadDL.atualizarGupoDiamond(Convert.ToInt32(hdnIDLista.Value), "G" + grupo.ToString());
            carregarTreinandosSemGrupo();
            carregarGrupo(grupo.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Alterado grupo do treinando!');", true);
        }
        protected void btnCancelarMudarCor_OnClick(object sender, EventArgs e)
        {
            fundoDiamond.Visible = false;
        }
        protected void btnSalvarCorGrupo_OnClick(object sender, EventArgs e)
        {
            atribuirCores();
            TreinandosDL cadDL = new TreinandosDL();
            Int32 grupo1 = Convert.ToInt32(lblMudarEquipe1.Text) - 1;
            Int32 grupo2 = Convert.ToInt32(ddlGrupoMudar.SelectedValue);
            TextBox a = (TextBox)FindControl("txtCor" + Convert.ToInt32(grupo1 + 1).ToString());
            TextBox b = (TextBox)FindControl("txtCor" + Convert.ToInt32(grupo2 + 1).ToString());
            Int32 cor1 = Convert.ToInt32(a.Text);
            Int32 cor2 = Convert.ToInt32(b.Text);
            cadDL.atualizarCorGrupo(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), grupo1, cor2);
            cadDL.atualizarCorGrupo(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), grupo2, cor1);
            a.BackColor = cores[cor2];
            a.ForeColor = a.BackColor;
            a.Text = cor2.ToString();
            b.BackColor = cores[cor1];
            b.ForeColor = b.BackColor;
            b.Text = cor1.ToString();
            fundoDiamond.Visible = false;
        }
        protected void mudarCor_OnClick(object sender, EventArgs e)
        {
            fundoDiamond.Visible = true;
            divCor.Visible = true;
            divLider.Visible = false;
            divStatus.Visible = false;
            ImageButton btnSalvar = sender as ImageButton;
            if (btnSalvar.ID.Substring(btnSalvar.ID.Length - 1, 1) == "0") lblMudarEquipe1.Text = "10";
            else lblMudarEquipe1.Text = btnSalvar.ID.Substring(btnSalvar.ID.Length - 1, 1);
        }
        protected void mudarStatus_OnClick(object sender, EventArgs e)
        {
            fundoDiamond.Visible = true;
            divCor.Visible = false;
            divLider.Visible = false;
            divStatus.Visible = true;
            ImageButton btnSalvar = sender as ImageButton;
            if (btnSalvar.ID.Substring(3, 1) == "0") lblMudarLider.Text = "10";
            else lblMudarStatus.Text = btnSalvar.ID.Substring(3, 1);

            GridViewRow gvrow = (GridViewRow)btnSalvar.NamingContainer;
            GridView gdv = (GridView)gvrow.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)gdv.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            Label lblNome = (Label)gdv.Rows[gvrow.RowIndex].FindControl("lblNome");
            hdnIDMudarStatus.Value = hdnIDLista.Value;
            lblNomeMudarStatus.Text = lblNome.Text;

        }
        protected void btnSalvarStatus_OnClick(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            cadDL.atualizarZerarLiderViceBandeira(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G" + Convert.ToInt32(Convert.ToInt32(lblMudarStatus.Text) - 1).ToString(), Convert.ToInt32(ddlMudarStatus.SelectedValue));
            if (ddlMudarStatus.SelectedValue.ToString() == "1")
                cadDL.atualizarLider(Convert.ToInt32(hdnIDMudarStatus.Value.ToString()));
            else if (ddlMudarStatus.SelectedValue.ToString() == "2")
                cadDL.atualizarVice(Convert.ToInt32(hdnIDMudarStatus.Value.ToString()));
            else cadDL.atualizarBandeira(Convert.ToInt32(hdnIDMudarStatus.Value.ToString()));
            carregarGrupo(Convert.ToInt32(Convert.ToInt32(lblMudarStatus.Text) - 1).ToString());
            fundoDiamond.Visible = false;
        }
        protected void mudarLider_OnClick(object sender, EventArgs e)
        {
            fundoDiamond.Visible = true;
            divCor.Visible = false;
            divLider.Visible = true;
            divStatus.Visible = false;
            ImageButton btnSalvar = sender as ImageButton;
            if (btnSalvar.ID.Substring(btnSalvar.ID.Length - 1, 1) == "0") lblMudarLider.Text = "10";
            else lblMudarLider.Text = btnSalvar.ID.Substring(btnSalvar.ID.Length - 1, 1);

            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarGruposPorTreinamento(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G" + Convert.ToInt32(Convert.ToInt32(lblMudarLider.Text) - 1).ToString(), false);
            if (cad.Rows.Count > 0)
            {
                ddlLider.Visible = true;
                ddlVice.Visible = true;
                ddlBandeira.Visible = true;
                ddlLider.DataSource = cad;
                ddlLider.DataTextField = "Nome";
                ddlLider.DataValueField = "IDLista";
                ddlLider.DataBind();
                ddlVice.DataSource = cad;
                ddlVice.DataTextField = "Nome";
                ddlVice.DataValueField = "IDLista";
                ddlVice.DataBind();
                ddlBandeira.DataSource = cad;
                ddlBandeira.DataTextField = "Nome";
                ddlBandeira.DataValueField = "IDLista";
                ddlBandeira.DataBind();
            }
            else
            {
                ddlLider.Visible = false;
                ddlVice.Visible = false;
                ddlBandeira.Visible = false;
            }
        }
        protected void btnSalvarLider_OnClick(object sender, EventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            cadDL.atualizarZerarLiderTodos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G" + Convert.ToInt32(Convert.ToInt32(lblMudarLider.Text) - 1).ToString());
            cadDL.atualizarLider(Convert.ToInt32(ddlLider.SelectedValue.ToString()));
            cadDL.atualizarVice(Convert.ToInt32(ddlVice.SelectedValue.ToString()));
            cadDL.atualizarBandeira(Convert.ToInt32(ddlBandeira.SelectedValue.ToString()));
            //carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), "G" + Convert.ToInt32(Convert.ToInt32(lblMudarLider.Text) - 1).ToString(), GridView1);
            carregarGrupo(Convert.ToInt32(Convert.ToInt32(lblMudarLider.Text) - 1).ToString());
            fundoDiamond.Visible = false;
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                if (row["Status"].ToString() == "1")
                    e.Row.BackColor = Color.Yellow;
                else if (row["Status"].ToString() == "2")
                    e.Row.BackColor = Color.Aqua;
                else if (row["Status"].ToString() == "3")
                    e.Row.BackColor = Color.Lime;

                if (Convert.ToBoolean(row["experiente"])) e.Row.ForeColor = Color.Red;
            }
        }
        protected void imprimirGrupo_OnClick(object sender, EventArgs e)
        {
            ImageButton btnSalvar = sender as ImageButton;
            string _open = "window.open('ImprimirGrupoDiamond.aspx?diamond=" + ddlTreinamento.SelectedValue.ToString() + "&grupo=" + btnSalvar.ID.Substring(btnSalvar.ID.Length - 1, 1) + "', '_Blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "imprimir", _open, true);
        }
        protected void imprimirRecepcao_OnClick(object sender, EventArgs e)
        {
            string _open = "window.open('ImprimirRecepcaoDiamond.aspx?diamond=" + ddlTreinamento.SelectedValue.ToString() + "', '_Blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "imprimir", _open, true);
        }
    }
}
