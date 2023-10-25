using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class wucUserSettings : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                FillThemes();
                FillSettings();
                FillLocalization();
            }
        }

        private void FillThemes()
        {
            Parameter p = new Parameter();
            string[] theme = p.GetInformation(3).Split('|');
            if (theme.Length > 0)
            {
                string[] item;
                for (int i = 0; i < theme.Length; i++)
                {
                    item = theme[i].Split('-');
                    cmbTheme.Items.Add(new ListItem(item[0], item[1]));
                }
            }
        }
        private void FillSettings()
        {
            string[] sett;
            if (Session["UserSetting"] == null)
                sett = DataBase.Scalar("exec uspUserSettingGet '" + Membership.GetUser().ProviderUserKey + "'").Split('|');
            else
                sett = Session["UserSetting"].ToString().Split('|');

            if (sett.Length > 1)
            {
                cmbTheme.SelectedValue = sett[0];
                cmbSearchResult.SelectedValue = sett[1];
            }
        }
        private void FillLocalization()
        {
            LocalizationBLL lBLL = new LocalizationBLL();
            cmbLocalization.DataSource = lBLL.GetLocalization();
            cmbLocalization.DataTextField = "Name";
            cmbLocalization.DataValueField = "LocalizationId";
            cmbLocalization.DataBind();
        }
        protected void imgBtSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("exec uspUserSettingSave '" + Membership.GetUser().ProviderUserKey + "','" + cmbTheme.SelectedValue + "'," + cmbSearchResult.SelectedValue + "," + cmbLocalization.SelectedValue);
            Session["UserSetting"] = cmbTheme.SelectedValue + "|" + cmbSearchResult.SelectedValue;

            ltMsg.Text = "Alterações Gravadas com sucesso! " + DateTime.Now + "<br/>";
        }
    }
}
