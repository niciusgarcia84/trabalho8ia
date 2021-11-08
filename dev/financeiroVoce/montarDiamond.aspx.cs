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
    public partial class montarDiamond : System.Web.UI.Page
    {
        public Int32 numArquetipo = 0;
        public int[,] grupo = new int[28, 10];

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
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), false);
            lblOrdem.Text = "0";
            divResumo.Visible = true;
            carregarTotal(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            calculaTotal();
            lblTreinamento.Text = "Treinamento " + ddlTreinamento.SelectedItem.ToString();
        }
        protected void carregarTreinandos(Int32 a, Boolean ordem)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinanandosPorTreinamentoArquetipos(a, ordem);
            if (cad != null)
            {
                grdTreinandos.DataSource = cad;
                grdTreinandos.DataBind();
            }
        }
        protected void grdTreinandos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                if (Convert.ToBoolean(row["experiente"])) e.Row.ForeColor = Color.Red;
            }
        }
        protected void btnOrdenar_Click(object sender, EventArgs e)
        {
            carregarTreinandos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), true);
            lblOrdem.Text = "1";
        }
        private void calculaTotal()
        {
            Int32 total = 0;
            Int32 totalCerebro = 0;
            Int32 totalCoracao = 0;
            Int32 totalAberto = 0;
            Int32 totalFechado = 0;
            Int32 totalProjecoes = 0;
            Int32 totalFatos = 0;
            Int32 totalGeral = 0;
            Int32 totalDetalhes = 0;

            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                total++;
                Label lblA = (Label)item.FindControl("lblA");
                Label lblB = (Label)item.FindControl("lblB");
                Label lblC = (Label)item.FindControl("lblC");
                Label lblD = (Label)item.FindControl("lblD");
                Label lblE = (Label)item.FindControl("lblE");
                Label lblF = (Label)item.FindControl("lblF");
                Label lblG = (Label)item.FindControl("lblG");
                Label lblH = (Label)item.FindControl("lblH");

                totalCerebro += Convert.ToInt32(lblA.Text);
                totalCoracao += Convert.ToInt32(lblB.Text);
                totalAberto += Convert.ToInt32(lblC.Text);
                totalFechado += Convert.ToInt32(lblD.Text);
                totalProjecoes += Convert.ToInt32(lblE.Text);
                totalFatos += Convert.ToInt32(lblF.Text);
                totalGeral += Convert.ToInt32(lblG.Text);
                totalDetalhes += Convert.ToInt32(lblH.Text);
            }
            lblTotalA.Text = totalCerebro.ToString();
            lblTotalB.Text = totalCoracao.ToString();
            lblTotalC.Text = totalAberto.ToString();
            lblTotalD.Text = totalFechado.ToString();
            lblTotalE.Text = totalProjecoes.ToString();
            lblTotalF.Text = totalFatos.ToString();
            lblTotalG.Text = totalGeral.ToString();
            lblTotalH.Text = totalDetalhes.ToString();

            lblTotalTreinandos.Text = total.ToString();
            txtQtdeGrupos.Text = (total / 12).ToString();
        }
        public void carregarTotal(Int32 a)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarArquetiposPorTreinamentos(a);
            Int32 i = 0;
            while (i < cad.Rows.Count)
            {
                switch (cad.Rows[i]["Arquetipo"].ToString())
                {
                    case ("ADMINISTRADOR"):
                        lblA1.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("ARTICULADOR"):
                        lblA2.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("ARTISTA"):
                        lblA3.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("ATOR"):
                        lblA4.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("CIENTISTA"):
                        lblA5.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("CUIDADOR"):
                        lblA6.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("EDUCADOR"):
                        lblA7.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("EMPREENDEDOR"):
                        lblA8.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("ENCANTADOR"):
                        lblA9.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("EXECUTOR"):
                        lblA10.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("IDEALISTA"):
                        lblA11.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("LÍDER"):
                        lblA12.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("MESTRE"):
                        lblA13.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("REGULADOR"):
                        lblA14.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("TUTOR"):
                        lblA15.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    case ("VISIONÁRIO"):
                        lblA16.Text = cad.Rows[i]["Soma"].ToString();
                        break;
                    default:
                        break;
                }
                i++;
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.verificarDataDiamonds(Convert.ToInt32(ddlTreinamento.SelectedValue));
            if (Convert.ToDateTime(cad.Rows[0]["DTInicio"].ToString()) < DateTime.Now.AddDays(-4))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Este Diamond já foi realizado e não pode ser alterado!');", true);
                return;
            }
            ImageButton btnSalvar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnSalvar.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)grdTreinandos.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            TextBox txtExcessao = (TextBox)grdTreinandos.Rows[gvrow.RowIndex].FindControl("txtExcessao");
            TreinandosDL treiDL = new TreinandosDL();
            if (txtExcessao.Text == "") txtExcessao.Text = "0";
            treiDL.atualizarExcecao(Convert.ToInt32(hdnIDLista.Value), Convert.ToInt32(txtExcessao.Text));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Salvo a exceção!');", true);
        }
        protected void btnSeparar_Click(object sender, EventArgs e)
        {
            //se já foi realizado não pode ser alterado
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.verificarDataDiamonds(Convert.ToInt32(ddlTreinamento.SelectedValue));
            if (Convert.ToDateTime(cad.Rows[0]["DTInicio"].ToString()) < DateTime.Now.AddDays(-4))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Este Diamond já foi realizado e não pode ser alterado!');", true);
                return;
            }

            //gerar a média por arquétipo e subtipo
            lblA1.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA1.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA2.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA2.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA3.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA3.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA4.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA4.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA5.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA5.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA6.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA6.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA7.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA7.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA8.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA8.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA9.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA9.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA10.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA10.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA11.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA11.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA12.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA12.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA13.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA13.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA14.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA14.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA15.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA15.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblA16.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblA16.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalA.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalA.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalB.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalB.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalC.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalC.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalD.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalD.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalE.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalE.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalF.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalF.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalG.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalG.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalH.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalH.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();
            lblTotalTreinandos.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(lblTotalTreinandos.Text) / Convert.ToDouble(txtQtdeGrupos.Text))).ToString();

            //zerar grupos anteriores
            TreinandosDL treiDL = new TreinandosDL();
            treiDL.atualizarZerarGrupos(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));

            //variáveis de cálculo
            Int32 i = 0;
            Boolean gravou = false;
            Int32 seguranca = 0;
            //Int32 experiente = 0;

            //começar a comparar e separar
            foreach (GridViewRow item in grdTreinandos.Rows)
            {
                gravou = false;
                seguranca = 0;
                numArquetipo = 0;
                TextBox txtExcessao = (TextBox)item.FindControl("txtExcessao");
                if (txtExcessao.Text == "") txtExcessao.Text = "30";
                if (txtExcessao.Text == "0") txtExcessao.Text = "30";
                ////teste de não cair experiente tudo junto
                ////if (item.ForeColor == Color.Red)
                ////{
                ////    if (experiente < Convert.ToInt32(txtQtdeGrupos.Text))
                ////    {
                ////        txtExcessao.Text = "31";
                ////        experiente++;
                ////    }
                ////    else
                ////    {
                ////        txtExcessao.Text = "32";
                ////        experiente++;
                ////    }
                ////}

                Label lblArquetipo = (Label)item.FindControl("lblArquetipo");
                Label lblA = (Label)item.FindControl("lblA");
                Label lblB = (Label)item.FindControl("lblB");
                Label lblC = (Label)item.FindControl("lblC");
                Label lblD = (Label)item.FindControl("lblD");
                Label lblE = (Label)item.FindControl("lblE");
                Label lblF = (Label)item.FindControl("lblF");
                Label lblG = (Label)item.FindControl("lblG");
                Label lblH = (Label)item.FindControl("lblH");
                HiddenField hdnIDLista = (HiddenField)item.FindControl("hdnIDLista");

                do
                {
                    if (Convert.ToInt32(grupo[27, i]) <= Convert.ToInt32(lblTotalTreinandos.Text))
                    {
                        if ((Convert.ToInt32(grupo[24, i]) != Convert.ToInt32(txtExcessao.Text)) && (Convert.ToInt32(grupo[25, i]) != Convert.ToInt32(txtExcessao.Text)) && (Convert.ToInt32(grupo[26, i]) != Convert.ToInt32(txtExcessao.Text)))
                        {
                            if (verificarArquetipo(i, lblArquetipo.Text.ToString()))
                            {
                                if (verificarSub(i, Convert.ToInt32(lblA.Text), Convert.ToInt32(lblB.Text), Convert.ToInt32(lblC.Text), Convert.ToInt32(lblD.Text), Convert.ToInt32(lblE.Text), Convert.ToInt32(lblF.Text), Convert.ToInt32(lblG.Text), Convert.ToInt32(lblH.Text)))
                                {
                                    //adicionando ao grupo
                                    grupo[numArquetipo, i]++;
                                    grupo[16, i] += Convert.ToInt32(lblA.Text);
                                    grupo[17, i] += Convert.ToInt32(lblB.Text);
                                    grupo[18, i] += Convert.ToInt32(lblC.Text);
                                    grupo[19, i] += Convert.ToInt32(lblD.Text);
                                    grupo[20, i] += Convert.ToInt32(lblE.Text);
                                    grupo[21, i] += Convert.ToInt32(lblF.Text);
                                    grupo[22, i] += Convert.ToInt32(lblG.Text);
                                    grupo[23, i] += Convert.ToInt32(lblH.Text);
                                    //adicionar exceções
                                    if (Convert.ToInt32(txtExcessao.Text) > 0 && txtExcessao.Text != "30")
                                    {
                                        if (grupo[24, i] == 0) grupo[24, i] = Convert.ToInt32(txtExcessao.Text);
                                        else if (grupo[25, i] == 0) grupo[25, i] = Convert.ToInt32(txtExcessao.Text);
                                        else grupo[26, i] = Convert.ToInt32(txtExcessao.Text);
                                    }
                                    //salvar no banco o grupo
                                    treiDL.atualizarGupoDiamond(Convert.ToInt32(hdnIDLista.Value), "G" + i.ToString());
                                    gravou = true;
                                }
                            }
                        }
                    }
                    i++;
                    if (i >= Convert.ToInt32(txtQtdeGrupos.Text))
                    {
                        i = 0;
                        seguranca++;
                    }
                }
                while (!gravou && seguranca <= 1);
            }
            //remover caso já tenha tenho na tabela
            treiDL.removerCorGrupo(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            //salvar cores de grupos
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 0, 0);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 1, 1);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 2, 2);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 3, 3);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 4, 4);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 5, 5);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 6, 6);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 7, 7);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 8, 8);
            treiDL.salvarCorGupoDiamond(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), 9, 9);

            string _open = "window.open('equipesDiamonds.aspx?id=" + ddlTreinamento.SelectedValue.ToString() + "', '_Blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Equipes", _open, true);
        }
        public Boolean verificarSub(Int32 numGrupo, Int32 a, Int32 b, Int32 c, Int32 d, Int32 e, Int32 f, Int32 g, Int32 h)
        {
            if (((Convert.ToInt32(grupo[16, numGrupo]) + a) <= Convert.ToInt32(lblTotalA.Text)) && ((Convert.ToInt32(grupo[17, numGrupo]) + b) <= Convert.ToInt32(lblTotalB.Text)) && ((Convert.ToInt32(grupo[18, numGrupo]) + c) <= Convert.ToInt32(lblTotalC.Text)) &&
                ((Convert.ToInt32(grupo[19, numGrupo]) + d) <= Convert.ToInt32(lblTotalD.Text)) && ((Convert.ToInt32(grupo[20, numGrupo]) + e) <= Convert.ToInt32(lblTotalE.Text)) && ((Convert.ToInt32(grupo[21, numGrupo]) + f) <= Convert.ToInt32(lblTotalF.Text)) &&
                ((Convert.ToInt32(grupo[22, numGrupo]) + g) <= Convert.ToInt32(lblTotalG.Text)) && ((Convert.ToInt32(grupo[23, numGrupo]) + h) <= Convert.ToInt32(lblTotalH.Text)))
                return true;
            else return false;
        }
        public Boolean verificarArquetipo(Int32 numGrupo, string arquetipo)
        {
            switch (arquetipo)
            {
                case ("ADMINISTRADOR"):
                    if ((Convert.ToInt32(grupo[0, numGrupo]) + 1) <= Convert.ToInt32(lblA1.Text))
                    { numArquetipo = 0; return true; }
                    else return false;
                case ("ARTICULADOR"):
                    if ((Convert.ToInt32(grupo[1, numGrupo]) + 1) <= Convert.ToInt32(lblA2.Text)) { numArquetipo = 1; return true; }
                    else return false;
                case ("ARTISTA"):
                    if ((Convert.ToInt32(grupo[2, numGrupo]) + 1) <= Convert.ToInt32(lblA3.Text)) { numArquetipo = 2; return true; }
                    else return false;
                case ("ATOR"):
                    if ((Convert.ToInt32(grupo[3, numGrupo]) + 1) <= Convert.ToInt32(lblA4.Text)) { numArquetipo = 3; return true; }
                    else return false;
                case ("CIENTISTA"):
                    if ((Convert.ToInt32(grupo[4, numGrupo]) + 1) <= Convert.ToInt32(lblA5.Text)) { numArquetipo = 4; return true; }
                    else return false;
                case ("CUIDADOR"):
                    if ((Convert.ToInt32(grupo[5, numGrupo]) + 1) <= Convert.ToInt32(lblA6.Text)) { numArquetipo = 5; return true; }
                    else return false;
                case ("EDUCADOR"):
                    if ((Convert.ToInt32(grupo[6, numGrupo]) + 1) <= Convert.ToInt32(lblA7.Text)) { numArquetipo = 6; return true; }
                    else return false;
                case ("EMPREENDEDOR"):
                    if ((Convert.ToInt32(grupo[7, numGrupo]) + 1) <= Convert.ToInt32(lblA8.Text)) { numArquetipo = 7; return true; }
                    else return false;
                case ("ENCANTADOR"):
                    if ((Convert.ToInt32(grupo[8, numGrupo]) + 1) <= Convert.ToInt32(lblA9.Text)) { numArquetipo = 8; return true; }
                    else return false;
                case ("EXECUTOR"):
                    if ((Convert.ToInt32(grupo[9, numGrupo]) + 1) <= Convert.ToInt32(lblA10.Text)) { numArquetipo = 9; return true; }
                    else return false;
                case ("IDEALISTA"):
                    if ((Convert.ToInt32(grupo[10, numGrupo]) + 1) <= Convert.ToInt32(lblA11.Text)) { numArquetipo = 10; return true; }
                    else return false;
                case ("LÍDER"):
                    if ((Convert.ToInt32(grupo[11, numGrupo]) + 1) <= Convert.ToInt32(lblA12.Text)) { numArquetipo = 11; return true; }
                    else return false;
                case ("MESTRE"):
                    if ((Convert.ToInt32(grupo[12, numGrupo]) + 1) <= Convert.ToInt32(lblA13.Text)) { numArquetipo = 12; return true; }
                    else return false;
                case ("REGULADOR"):
                    if ((Convert.ToInt32(grupo[13, numGrupo]) + 1) <= Convert.ToInt32(lblA14.Text)) { numArquetipo = 13; return true; }
                    else return false;
                case ("TUTOR"):
                    if ((Convert.ToInt32(grupo[14, numGrupo]) + 1) <= Convert.ToInt32(lblA15.Text)) { numArquetipo = 14; return true; }
                    else return false;
                case ("VISIONÁRIO"):
                    if ((Convert.ToInt32(grupo[15, numGrupo]) + 1) <= Convert.ToInt32(lblA16.Text)) { numArquetipo = 15; return true; }
                    else return false;
                default:
                    {
                        numArquetipo = 0;
                        return false;
                    }
            }
        }
    }
}
