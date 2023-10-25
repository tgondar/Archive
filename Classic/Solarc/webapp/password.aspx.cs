using System;
using System.Web.Security;
using System.Configuration;

public partial class password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lkbReset_Click(object sender, EventArgs e)
    {
        if (Membership.GetUser(txtName.Text) != null)
        {
            if (Roles.IsUserInRole(txtName.Text, ConfigurationManager.AppSettings["RoleAdmin"]))
            {
                MembershipProvider mp = Membership.Providers["AspNetSqlMembershipProvider_2"];
                MembershipUser user = mp.GetUser(txtName.Text, false);

                string nPass = Membership.GeneratePassword(10, 3);

                Email mail = new Email();
                mail.Subject = "Password Reset > " + ConfigurationManager.AppSettings["AppName"];
                mail.Send(Membership.GetUser(txtName.Text).Email, "Nova Password: " + nPass);

                Membership.GetUser(txtName.Text).ChangePassword(user.ResetPassword(), nPass);

                Server.Transfer("default.aspx");
            }
        }
    }
}
