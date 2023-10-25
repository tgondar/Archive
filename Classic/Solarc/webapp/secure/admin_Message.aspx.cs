using System;
using System.Text;

namespace Solarc.webapp.secure
{
    public partial class admin_Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();

                StringBuilder sb = new StringBuilder();
                sb.Append("<b>Mensagens Iniciais:</b><br/>");
                sb.Append("1 - Foi criado um utilizador para aceder a aplicação web {0}, o seu nome de utilizador é {1} e a sua password é {2} quando entrar a 1ª vez na aplicação, por favor altere a sua password.<br/>");
                sb.Append("2 - Foi adicionada a seguinte informação: {0}, pelo utilizador: {1}.<br/>");
                lblMessages.Text = sb.ToString();
            }
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            lkbSave.Enabled = true;
            txtValue.Text = gvResult.Rows[gvResult.SelectedIndex].Cells[2].Text;
            gvResult.Enabled = false;
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                lkbSave.Enabled = false;
                gvResult.Enabled = true;

                Parameter p = new Parameter();
                p.SaveMessage(gvResult.SelectedIndex, txtValue.Text);

                txtValue.Text = string.Empty;
                gvResult.SelectedIndex = -1;
                FillGrid();
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: nao são permitido uso de caracteres especiais (exemplo: <>\\/«»\"#$%&/()=), altere a valor pf.<br/>" + ex.Message;
            }
        }
        private void FillGrid()
        {
            Parameter p = new Parameter();
            gvResult.DataSource = p.GetAllMessages();
            gvResult.DataBind();
        }
    }
}
