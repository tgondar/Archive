using System;
using System.Web.Security;
using System.Text;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Solarc.webapp.secure
{
    public partial class Representative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = "20";

                if (Request.QueryString["value"] != null)
                    txtInternalNumber.Text = Request.QueryString["value"];
                FillSearch();

                Parameter p = new Parameter();
                if (p.GetValue(7) == "0")
                {
                    gvResult.Columns[5].Visible = false;
                    return;
                }
            }
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillSearch();
        }
        private void FillSearch()
        {
            try
            {
                StringBuilder sb = new StringBuilder("");

                sb.Append("'" + txtInternalNumber.Text + "',");
                sb.Append("'" + txtProcessNumber.Text + "',");
                sb.Append("'" + txtCreditor.Text + "',");
                sb.Append("'" + txtExecuted.Text + "'");

                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]))
                    gvResult.DataSource = DataBase.DataReader("exec uspSearchRepresentative " + sb.ToString() + ",'" + Membership.GetUser().ProviderUserKey + "'," + lkbPrev.CommandArgument + "," + lkbNext.CommandArgument);
                else
                    gvResult.DataSource = DataBase.DataReader("exec uspSearchClient " + sb.ToString() + ",'" + Membership.GetUser().ProviderUserKey + "'," + lkbPrev.CommandArgument + "," + lkbNext.CommandArgument);
                gvResult.DataBind();

                lkbPrev.Enabled = false;
                lkbNext.Enabled = false;
                if (gvResult.Rows.Count > 20) lkbNext.Enabled = true;
                if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        protected void lkbPrev_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) - 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - 20).ToString();

            FillSearch();
        }
        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) + 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + 20).ToString();

            FillSearch();
        }
    }
}
