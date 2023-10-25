using System;
using System.Web.Security;

namespace Solarc.webapp.secure
{
    public partial class mntRepresentative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = "20";

                FillGrid();
            }
        }
        protected void lkbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string cc = CheckEmail(txtCarbonCopy.Text);

                DataBase.Deinup("exec uspRepresentativeUpdateMnt 0,'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtNif.Text + "','" + cc + "','" + Membership.GetUser().ProviderUserKey + "','" + txtLawyerNumber.Text.Trim() + "'");
                Server.Transfer("mntRepresentative.aspx", false);
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }

        private string CheckEmail(string theEmails)
        {
            Email mail = new Email();
            string aux, ccFinal = string.Empty;
            string[] Email = theEmails.Split(';');

            for (int i = 0; i < Email.Length; i++)
            {
                aux = Email[i].Trim();
                if (aux.Length > 0)
                {
                    if (!mail.ValidMail(aux))
                        throw new Exception(string.Format("Pretende adicionar um email errado: <b>{0}</b>", aux));
                    ccFinal += aux + ";";
                }
            }
            return ccFinal;
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvResult.SelectedIndex;
            string aux = string.Empty;

            aux = gvResult.Rows[index].Cells[1].Text;
            txtName.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[2].Text;
            txtLawyerNumber.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[3].Text;
            txtAddress.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[4].Text;
            txtPhone.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[5].Text;
            txtFax.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[6].Text;
            txtEmail.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[7].Text;
            txtNif.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[8].Text;
            txtCarbonCopy.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[index].Cells[9].Text;

            gvResult.Enabled = false;
            lkbInsert.Visible = false;
            lkbSearch.Visible = false;
            lkbSave.Visible = true;
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                string cc = CheckEmail(txtCarbonCopy.Text);

                DataBase.Deinup("exec uspRepresentativeUpdateMnt " + gvResult.DataKeys[gvResult.SelectedIndex][0] + ",'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtNif.Text + "','" + cc + "','" + Membership.GetUser().ProviderUserKey + "','" + txtLawyerNumber.Text + "'");
                Server.Transfer("mntRepresentative.aspx", false);
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void lkbPrev_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) - 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - 20).ToString();
            FillGrid();
        }
        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) + 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + 20).ToString();
            FillGrid();
        }
        private void FillGrid()
        {
            gvResult.DataSource = DataBase.DataTable("exec uspRepresentative '" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtNif.Text + "','" + txtCarbonCopy.Text + "'," + lkbPrev.CommandArgument + "," + (int.Parse(lkbNext.CommandArgument) + 1) + ",'" + Membership.GetUser().ProviderUserKey + "'");
            string[] key = new string[] { "RepresentativeId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();

            lkbPrev.Enabled = false;
            lkbNext.Enabled = false;
            if (gvResult.Rows.Count > 20) lkbNext.Enabled = true;
            if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;
        }
    }
}
