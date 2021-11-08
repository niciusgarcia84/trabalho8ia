using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using financeiroVoce.DataLayer;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.IO;

namespace financeiroVoce
{
    public partial class importarTreinandos : System.Web.UI.Page
    {
        public String caminho;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["IDUsuarioPermissao"] == null) Response.Redirect("Default.aspx");
            //if (!Session["IDUsuarioPermissao"].ToString().Contains("ad")) Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                carregarDrops();
            }
        }
        private void carregarDrops()
        {
            CadastrosDL cadDL = new CadastrosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarProximosTreinamentos();
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
            //caminho = "C:\\treinamentos\\" + FileUploadControl.FileName;
            if (FileUploadControl.HasFile)
            {
                FileUploadControl.SaveAs(@"C:\bdtemp\importarTEMP.jpg");
                FiltrarTreinamento();
                CarregarExcel();
            }
            else ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Desculpe-nos');", true);
        }
        protected void FiltrarTreinamento()
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            cad = cadDL.ListarTreinanandosPorTreinamento(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()));
            if (cad != null)
            {
                grdEquipes.DataSource = cad;
                grdEquipes.DataBind();
            }
            calculaTotal();
        }
        private void calculaTotal()
        {
            Int32 a = 0;
            foreach (GridViewRow item in grdEquipes.Rows) { a++; }
            lblTotal.Text = "Total cadastrados " + a.ToString();
        }
        private void CarregarExcel()
        {
            //sem nome de coluna
            //string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"", caminho);
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"", @"C:\bdtemp\importarTEMP.jpg");
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //Cria o objeto dataset para receber o conteúdo do arquivo Excel
                DataSet output = new DataSet();
                foreach (DataRow row in dt.Rows)
                {
                    // obtem o noma da planilha corrente
                    string sheet = row["TABLE_NAME"].ToString();
                    // obtem todos as linhas da planilha corrente
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;
                    // copia os dados da planilha para o datatable
                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
                GridView1.DataSource = output.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Excel não localizado!');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('" + ex.ToString() + "');", true);
            }
            conn.Close();
            calculaTotalExcel();
        }
        private void calculaTotalExcel()
        {
            Int32 a = 0;
            foreach (GridViewRow item in GridView1.Rows) { a++; }
            lblTotalExcel.Text = "Total importados " + a.ToString();
            lnkComparar.Visible = true;
            lnkSalvar.Visible = true;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TreinandosDL cadDL = new TreinandosDL();
            DataTable cad = new DataTable();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;

                Label lblNome = (Label)e.Row.FindControl("lblNomeImportado");
                //lblNome.Text = Convert.ToString(row[0]);
                lblNome.Text = row["Nome"].ToString();
                if (ddlTreinamento.SelectedItem.ToString().Contains("DIA"))
                {
                    Label lblArquetipo = (Label)e.Row.FindControl("lblArquetipo");
                    //lblArquetipo.Text = Convert.ToString(row[2]);
                    lblArquetipo.Text = Convert.ToString(row["Indicador"]);

                    Label lblCracha = (Label)e.Row.FindControl("lblCracha");
                    lblCracha.Text = row["Cracha"].ToString();
                }
                cad = cadDL.ListarTreinanandoPorTreinamento(Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), row["Nome"].ToString());
                if (cad.Rows.Count <= 0)
                {
                    cad = null;
                    CadastrosDL eDL = new CadastrosDL();
                    //cad = eDL.ListarEquipe(row[1].ToString());
                    cad = eDL.ListarEquipe(row["Consutor"].ToString());
                    if (cad.Rows.Count > 0)
                    {
                        Label lblConsultor = (Label)e.Row.FindControl("lblConsultor");
                        lblConsultor.Text = Convert.ToString(cad.Rows[0]["Equipe"]);
                        HiddenField hdnIDEquipe = (HiddenField)e.Row.FindControl("hdnIDEquipe");
                        hdnIDEquipe.Value = Convert.ToString(cad.Rows[0]["IDEquipe"]);
                        DropDownList ddlEquipe = (DropDownList)e.Row.FindControl("ddlEquipe");
                        ddlEquipe.Visible = false;
                    }
                    else
                    {
                        cad = null;
                        cad = eDL.ListarEquipes();
                        DropDownList ddlEquipe = (DropDownList)e.Row.FindControl("ddlEquipe");
                        ddlEquipe.DataSource = cad;
                        ddlEquipe.DataTextField = "Equipe";
                        ddlEquipe.DataValueField = "IDEquipe";
                        ddlEquipe.DataBind();
                        Label lblConsultor = (Label)e.Row.FindControl("lblConsultor");
                        //lblConsultor.Text = Convert.ToString(row[1]);
                        lblConsultor.Text = Convert.ToString(row["Consutor"]);
                    }
                }
                else
                {
                    Label lblConsultor = (Label)e.Row.FindControl("lblConsultor");
                    lblConsultor.Text = "já cadastrado";
                    e.Row.ForeColor = Color.Red;
                    DropDownList ddlEquipe = (DropDownList)e.Row.FindControl("ddlEquipe");
                    ddlEquipe.Visible = false;
                }
            }
        }
        protected void lnkSalvar_OnClick(object sender, EventArgs e)
        {
            foreach (GridViewRow item2 in GridView1.Rows)
            {
                TreinandosDL treiDL = new TreinandosDL();
                HiddenField hdnIDTreinandoImportado = (HiddenField)item2.FindControl("hdnIDTreinandoImportado");
                Label lblConsultor = (Label)item2.FindControl("lblConsultor");
                Label lblArquetipo = (Label)item2.FindControl("lblArquetipo");
                Label lblCracha = (Label)item2.FindControl("lblCracha");
                Label lblNomeImportado = (Label)item2.FindControl("lblNomeImportado");
                DataTable cad = new DataTable();
                if (lblNomeImportado.Text != "")
                {
                    cad = treiDL.procurarTreinandoPorNome(lblNomeImportado.Text.ToString());
                    if (cad.Rows.Count <= 0)
                    {
                        cad = null;
                        cad = treiDL.novoTreinandoRetornoID(lblNomeImportado.Text.ToString(), "");
                    }
                    hdnIDTreinandoImportado.Value = cad.Rows[0]["IDTreinando"].ToString();

                    if (lblConsultor.Text != "já cadastrado")
                    {
                        HiddenField hdnIDEquipe = (HiddenField)item2.FindControl("hdnIDEquipe");
                        if (hdnIDEquipe.Value == "0")
                        {
                            DropDownList ddlEquipe = (DropDownList)item2.FindControl("ddlEquipe");
                            treiDL.inserirTreinamentosPorTreinando(Convert.ToInt32(cad.Rows[0]["IDTreinando"]), Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), Convert.ToInt32(ddlEquipe.SelectedValue.ToString()));
                        }
                        else treiDL.inserirTreinamentosPorTreinando(Convert.ToInt32(cad.Rows[0]["IDTreinando"]), Convert.ToInt32(ddlTreinamento.SelectedValue.ToString()), Convert.ToInt32(hdnIDEquipe.Value.ToString()));
                    }
                    if (ddlTreinamento.SelectedItem.ToString().Contains("DIA"))
                    {
                        treiDL.atualizarArquetipo(Convert.ToInt32(hdnIDTreinandoImportado.Value), lblArquetipo.Text, lblCracha.Text);
                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Salvo!');", true);
            FiltrarTreinamento();
            comparar();
        }
        protected void lnkComparar_OnClick(object sender, EventArgs e)
        {
            comparar();
        }
        protected void comparar()
        {
            foreach (GridViewRow item in grdEquipes.Rows)
            {
                Label lblNome = (Label)item.FindControl("lblNome");
                foreach (GridViewRow item2 in GridView1.Rows)
                {
                    Label lblNomeImportado = (Label)item2.FindControl("lblNomeImportado");
                    if (lblNome.Text.ToUpper() == lblNomeImportado.Text.ToUpper())
                    {
                        item.BackColor = Color.Yellow;
                        break;
                    }
                }
                if (item.BackColor != Color.Yellow)
                {
                    DropDownList ddlTreinamentoNovo = (DropDownList)item.FindControl("ddlTreinamentoNovo");
                    ImageButton btnAlterar = (ImageButton)item.FindControl("btnAlterar");
                    btnAlterar.Visible = true;
                    ddlTreinamentoNovo.Visible = true;

                    CadastrosDL cadDL = new CadastrosDL();
                    DataTable cad = new DataTable();
                    cad = cadDL.ListarProximosTreinamentos();
                    if (cad != null)
                    {
                        ddlTreinamentoNovo.DataSource = cad;
                        ddlTreinamentoNovo.DataTextField = "Descricao";
                        ddlTreinamentoNovo.DataValueField = "IDTreinamento";
                        ddlTreinamentoNovo.DataBind();
                    }
                }
            }
        }
        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            ImageButton btnAlterar = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btnAlterar.NamingContainer;
            HiddenField hdnIDLista = (HiddenField)grdEquipes.Rows[gvrow.RowIndex].FindControl("hdnIDLista");
            DropDownList ddlTreinamentoNovo = (DropDownList)grdEquipes.Rows[gvrow.RowIndex].FindControl("ddlTreinamentoNovo");

            TreinandosDL treiDL = new TreinandosDL();
            treiDL.atualizarTreinamentoTreinando(Convert.ToInt32(hdnIDLista.Value), Convert.ToInt32(ddlTreinamentoNovo.SelectedValue.ToString()));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alerta", "alert('Salvo!');", true);
            FiltrarTreinamento();
            comparar();
        }
    }
}
