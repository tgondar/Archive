using System;
using System.IO;
using System.Text;
using iTextSharp.text;

namespace Solarc.webapp.secure
{
    public partial class Document : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            uPanelDocument.Update();

            hlPdf.Text = string.Empty;

            if (!IsPostBack)
            {
                FillDocuments();
                FillSolicitor();
            }
        }
        protected void lkbGenerate_Click(object sender, EventArgs e)
        {
            pnGenerate.Visible = true;
            upGenerate.Update();
        }
        protected void lkbNew_Click(object sender, EventArgs e)
        {
            lkbAddDocument.Visible = true;
            lkbSave.Visible = false;
            pnEdit.Visible = true;
            pnDocumentName.Visible = true;
            htmlEditor.Content = string.Empty;
            txtDocumentName.Text = string.Empty;

            upGenerate.Update();
        }

        private void FillDocuments()
        {
            Documents d = new Documents();
            cmbDocument.DataSource = d.GetAllDocuments();
            cmbDocument.DataTextField = "Name";
            cmbDocument.DataValueField = "DocumentId";
            cmbDocument.DataBind();
        }
        private void FillSolicitor()
        {
            cmbSolicitor.DataSource = DataBase.DataTable("select * from vwSolicitor order by Name");
            cmbSolicitor.DataValueField = "SolicitorId";
            cmbSolicitor.DataTextField = "Name";
            cmbSolicitor.DataBind();
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            if (txtDocumentName.Text.Length == 0)
            {
                ltMsg.Text = "Nome nao pode ser vazio!";
                return;
            }
            Documents d = new Documents();
            d.NewDocument(int.Parse(cmbDocument.Items.Count > 0 ? cmbDocument.SelectedValue : "0"), txtDocumentName.Text, htmlEditor.Content.Replace("'", "''"));

            FillDocuments();
        }

        protected void lkbEdit_Click(object sender, EventArgs e)
        {
            lkbAddDocument.Visible = false;
            lkbSave.Visible = true;

            pnEdit.Visible = true;
            pnDocumentName.Visible = true;
            txtDocumentName.Text = cmbDocument.SelectedItem.Text;
            Documents d = new Documents();
            htmlEditor.Content = d.GetDocument(int.Parse(cmbDocument.SelectedItem.Value)).Rows[0]["Value"].ToString();

            upGenerate.Update();
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            if (txtInternalCode.Text.Length > 0 || txtProcessNumber.Text.Length > 0)
            {
                cmbResult.DataSource = DataBase.DataTable("exec uspSearch '" + (txtInternalCode.Text.Length > 0 ? txtInternalCode.Text : string.Empty) + "','" + (txtProcessNumber.Text.Length > 0 ? txtProcessNumber.Text : string.Empty) + "','','','','',0,'','',0,'','',0,0,1,100,1");
                cmbResult.DataTextField = "InternalNumber";
                cmbResult.DataValueField = "ProcessId";
                cmbResult.DataBind();
            }
            else
                ltMsg.Text = "Tem de escrever o numero interno ou o numero do processo no tribunal!";
        }
        protected void lkbOk_Click(object sender, EventArgs e)
        {
            if (cmbResult.Items.Count > 0)
            {
                pnExecutedCreditor.Visible = true;
                Process p = new Process(int.Parse(cmbResult.SelectedValue));
                cmbCreditor.DataSource = p.GetCreditorList();
                cmbCreditor.DataValueField = "CreditorId";
                cmbCreditor.DataTextField = "Name";
                cmbCreditor.DataBind();

                cmbExecuted.DataSource = p.GetExecutedList();
                cmbExecuted.DataValueField = "ExecutedId";
                cmbExecuted.DataTextField = "Name";
                cmbExecuted.DataBind();
            }
        }
        protected void lkbExecutedCreditor_Click(object sender, EventArgs e)
        {
            pnTexto.Visible = true;
        }

        private void CreatePDF()
        {
            try
            {
                string path = Server.MapPath("") + "\\files\\temp\\";
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo f in di.GetFiles())
                    if (f.CreationTime < DateTime.Now.AddHours(-1))
                        File.Delete(f.FullName);

                pnGenerate.Visible = false;
                lkbDownloadFile.Visible = false;

                string fileName = Guid.NewGuid().ToString().Replace("-", string.Empty);
                string toLetter = string.Empty;
                path += fileName + ".pdf";

                switch (rblToLetter.SelectedIndex)
                {
                    case 0: //Executed
                        Executed exec = new Executed(int.Parse(cmbExecuted.SelectedValue));
                        toLetter = exec.Name + "<br/>" + exec.Address;
                        break;
                    case 1: //Creditor
                        Creditor cred = new Creditor(int.Parse(cmbCreditor.SelectedValue));
                        toLetter = cred.Name + "<br/>" + cred.Address;
                        break;
                    case 2: //Representative
                        string rIdTemp = DataBase.Scalar("select RepresentativeId from tb_Process where ProcessId=" + cmbResult.SelectedValue);
                        if (rIdTemp.Length > 0)
                        {
                            int rId = int.Parse(rIdTemp);
                            ClassRepresentative r = new ClassRepresentative(rId);
                            toLetter = r.Name + "<br/>" + r.Address;
                        }
                        else
                        {
                            ltMsg.Text = "Erro: O Processo não tem um Mandatário definido.";
                            return;
                        }
                        break;
                }

                //HtmlToPdfBuilder builder = new HtmlToPdfBuilder(PageSize.A4);

                //HtmlPdfPage first = builder.AddPage();

                Documents d = new Documents();
                StringBuilder sb = new StringBuilder();

                //first.AppendHtml("<div style=\"font-size:8px;\">");

                if (ckbHeader.Checked)
                {
                    sb.Append(string.Format("<table><tr><td><img src=\"{0}\" width=\"30\" height=\"34\" />{1}<br />Agente de Execução</td><td><br />", Server.MapPath("") + "/../../images/webapp/solicitorslogo.jpg", cmbSolicitor.SelectedItem.Text));
                    sb.Append(string.Format("Exmo(a) Senhor(a)<br />{0}</td></tr><tr><td colspan=\"2\"> </td><tr></tr>", toLetter));
                    sb.Append("<tr><td colspan=\"2\" bgcolor=\"#cccccc\">LOCAL E DATA</td></tr>");
                    sb.Append(string.Format("<tr><td colspan=\"2\">PORTO, {0}</td></tr><tr><td colspan=\"2\" bgcolor=\"#cccccc\">IDENTIFICAÇÃO DO PROCESSO</td></tr>", DateTime.Now.ToString("dd-MM-yyyy")));
                    sb.Append("<tr><td colspan=\"2\">Nº do Processo: «TRIBUNALCODIGOPROCESSO»<br/>«TRIBUNALNOME»<br/>Exequente: «EXEQUENTENOME»<br/>Executado: «EXECUTADONOME»<br/>Valor Acção: «VALORACCAO»<br/>Referencia Interna: «NUMEROINTERNO»</td></tr>");
                    sb.Append("<tr><td colspan=\"2\" bgcolor=\"#cccccc\"></td></tr><tr><td colspan=\"2\">«TEXTOEXTRA»</td></tr></table>");
                }

                if (sb.Length > 0)
                    sb = sb.Replace("«TEXTOEXTRA»", "«TEXTOEXTRA»<br/>" + txtText.Text);
                else
                    sb.Append("«TEXTOEXTRA»<br/>" + txtText.Text);

                string temp = d.Generate(int.Parse(cmbDocument.SelectedValue), int.Parse(cmbResult.SelectedValue), int.Parse(cmbExecuted.SelectedValue), int.Parse(cmbCreditor.SelectedValue), ckbBold.Checked, sb.ToString());
                //first.AppendHtml(temp);

                //first.AppendHtml("</div>");

                //byte[] file = builder.RenderPdf();
                //File.WriteAllBytes(path, file);

                hlPdf.Visible = true;
                hlPdf.Text = "Download ficheiro em PDF.";
                hlPdf.Target = "_blank";
                hlPdf.NavigateUrl = "files/temp/" + fileName + ".pdf";
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
                uPanelDocument.Update();
            }
        }
        protected void lkbCreatePDF_Click(object sender, EventArgs e)
        {
            CreatePDF();

            txtInternalCode.Text = string.Empty;
            txtProcessNumber.Text = string.Empty;
            cmbResult.Items.Clear();
            cmbSolicitor.SelectedIndex = 0;
            cmbCreditor.Items.Clear();
            cmbExecuted.Items.Clear();
            ckbBold.Checked = true;
            ckbHeader.Checked = true;
            txtText.Text = string.Empty;
            pnExecutedCreditor.Visible = false;
            pnTexto.Visible = false;
        }
        protected void lkbAddDocument_Click(object sender, EventArgs e)
        {
            if (txtDocumentName.Text.Trim().Length == 0)
            {
                ltMsg.Text = "Nome nao pode ser vazio!";
                return;
            }
            Documents d = new Documents();
            d.NewDocument(0, txtDocumentName.Text.Trim(), htmlEditor.Content.Replace("'", "''"));

            FillDocuments();
        }
    }
}
