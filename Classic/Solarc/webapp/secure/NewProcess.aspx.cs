using System;
using System.Web.UI;

namespace Solarc.webapp.secure
{
    public partial class NewProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
        }

        protected void imgBtAdd_Click(object sender, ImageClickEventArgs e)
        {
            string code;
            try
            {
                ProcessBLL pBLL = new ProcessBLL();
                code = pBLL.ValidadeCode(txtInternalCode.Text);
                if (code.Length > 0)
                {
                    string[] codeF = code.Split('/');
                    int p = pBLL.AddProcess(codeF[0], int.Parse(codeF[1]), int.Parse(codeF[2]), codeF.Length > 3 ? codeF[3] : string.Empty, txtProcessNumber.Text);

                    Response.Redirect("Process.aspx?pr=" + p, true);
                }
                else
                    lblMsg.Text = "Formato do Numero Interno incorrecto.";

            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro: " + ex.Message;
            }
        }
    }
}
