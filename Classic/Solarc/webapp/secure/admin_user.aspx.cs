using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Linq;

namespace Solarc.webapp.secure
{
    public partial class admin_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                if (!Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleAdmin"]))
                    Server.Transfer("Default.aspx", false);
                
                gvResult.DataSource = Membership.GetAllUsers();
                gvResult.DataBind();
            }
        }
        protected void lkbAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Parameter p = new Parameter();
                if (gvResult.Rows.Count >= int.Parse(p.GetValue(4)))
                {
                    ltMsg.Text = "Atingiu o limite de utilizadores, para adicionar mais utilizadores por favor entre em contacto com " + ConfigurationManager.AppSettings["ContactInformation"];
                    return;
                }
                if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0 && txtEmail.Text.Length > 0)
                {
                    if (txtUserName.Text == ConfigurationManager.AppSettings["MasterAccount"].ToString())
                    {
                        ltMsg.Text = "Erro: Não pode criar esse utilizador!";
                        return;
                    }
                    if (Membership.GetUser(txtUserName.Text) != null)
                    {
                        ltMsg.Text = "Erro: Nome Utilizador ja existe!";
                        return;
                    }
                    if (cmbRole.SelectedIndex == 1 && cmbRepresentative.Items.Count == 0)
                    {
                        ltMsg.Text = "Erro: Tem de seleccionar 1 mandatario";
                        return;
                    }
                    MembershipCreateStatus st;
                    Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, "aaa", "bbb", true, out st);
                    Roles.AddUserToRole(txtUserName.Text, cmbRole.SelectedItem.Value);
                    if (cmbRole.SelectedIndex == 1 && cmbRepresentative.Items.Count > 0)
                        DataBase.Deinup("update tb_Representative set alterdate=getdate(),alteruserid='" + Membership.GetUser().ProviderUserKey + "',userid='" + Membership.GetUser(txtUserName.Text).ProviderUserKey + "' where RepresentativeId=" + cmbRepresentative.SelectedValue);

                    ltMsg.Text = "Utilizador inserido com sucesso!";

                    if (cmbRole.SelectedIndex == 1 && cmbRepresentative.Items.Count > 0 && ckbRepresentative.Checked)
                    {
                        Email mail = new Email();
                        mail.Send(txtEmail.Text, string.Format(p.GetMessage(1), p.GetInformation(1), txtUserName.Text, txtPassword.Text));
                    }

                    if (cmbRepresentative.Items.Count > 0)
                        cmbRepresentative.SelectedIndex = 0;

                    lblRepresentative.Visible = false;
                    cmbRepresentative.Visible = false;
                    ckbRepresentative.Checked = false;
                    ckbRepresentative.Visible = false;

                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    cmbRole.SelectedIndex = 0;

                    gvResult.DataSource = Membership.GetAllUsers();
                    gvResult.DataBind();
                }
                else
                    ltMsg.Text = "Erro: Falta preencher algum campo!";
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
                Email mail = new Email();
                mail.SendError(ex.Message);
            }
        }
        protected void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex == 1)
            {
                lblRepresentative.Visible = true;
                cmbRepresentative.Visible = true;
                ckbRepresentative.Visible = true;
                if (cmbRepresentative.Items.Count == 0)
                {
                    cmbRepresentative.DataSource = DataBase.DataReader("select representativeid,name from tb_Representative where Userid is null order by name");
                    cmbRepresentative.DataTextField = "name";
                    cmbRepresentative.DataValueField = "representativeid";
                    cmbRepresentative.DataBind();
                }
                if (cmbRepresentative.Items.Count > 0)
                    FillRepresentativeEmail();
            }
            else
            {
                lblRepresentative.Visible = false;
                cmbRepresentative.Visible = false;
                ckbRepresentative.Visible = false;
                txtEmail.Text = string.Empty;
            }
        }

        protected void gvusers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string user = gvResult.Rows[index].Cells[0].Text;

                if (e.CommandName.ToLower().Equals("act"))
                {
                    if (Membership.GetUser(user).IsLockedOut)
                        Membership.GetUser(user).UnlockUser();
                    gvResult.DataSource = Membership.GetAllUsers();
                    gvResult.DataBind();
                }
                else if (e.CommandName.ToLower().Equals("del"))
                {
                    if (user == ConfigurationManager.AppSettings["MasterAccount"].ToString())
                    {
                        ltMsg.Text = "Erro: Não pode apagar o utilizador <b>" + user + "</b>!!";
                        return;
                    }
                    // VERIFICAR SE NAO TEM NADA DESTE USER!!
                    Roles.RemoveUserFromRoles(user, Roles.GetRolesForUser(gvResult.Rows[index].Cells[0].Text));
                    DataBase.Deinup("update tb_Representative set UserId=null where UserId='" + Membership.GetUser(user).ProviderUserKey + "'");
                    Membership.DeleteUser(user, true);

                    gvResult.Rows[index].Visible = false;
                }
                else if (e.CommandName.ToLower().Equals("newpass"))
                {
                    TextBox newpass = (TextBox)gvResult.Rows[index].Cells[7].FindControl("txtPassword");

                    if (newpass.Text == "" || newpass.Text.Length < 4)
                    {
                        ltMsg.Text = "A nova password tem de ter no minimo 4 caracteres!";
                        return;
                    }

                    MembershipProvider mp = Membership.Providers["AspNetSqlMembershipProvider_2"];
                    MembershipUser userN = mp.GetUser(user, false);

                    if (Membership.GetUser(userN.UserName).IsLockedOut)
                        Membership.GetUser(userN.UserName).UnlockUser();

                    Membership.GetUser(user).ChangePassword(userN.ResetPassword(), newpass.Text);
                    ltMsg.Text = "Password alterada com sucesso - user: " + user + " nova password: " + newpass.Text;

                    newpass.Text = string.Empty;
                }
                else if (e.CommandName.ToLower().Equals("newemail"))
                {
                    TextBox newmail = (TextBox)gvResult.Rows[index].Cells[7].FindControl("txtPassword");

                    MembershipUser usr = Membership.GetUser(user);
                    usr.Email = newmail.Text;
                    Membership.UpdateUser(usr);

                    DropDownList cmb = (DropDownList)gvResult.Rows[index].Cells[8].FindControl("cmbRole");
                    if (cmb.SelectedItem.Text == ConfigurationManager.AppSettings["RoleRepresentative"])
                        DataBase.Deinup("update tb_Representative set Email='" + newmail.Text + "' where UserId='" + Membership.GetUser(user).ProviderUserKey + "'");

                    gvResult.DataSource = Membership.GetAllUsers();
                    gvResult.DataBind();
                }
                else if (e.CommandName.ToLower().Equals("role"))
                {
                    if (user == ConfigurationManager.AppSettings["MasterAccount"].ToString())
                    {
                        ltMsg.Text = "Erro: Não pode adicionar o utilizador <b>" + user + "</b> ao grupo!!";
                        return;
                    }

                    if (Roles.GetRolesForUser(user).Length > 0)
                        Roles.RemoveUserFromRoles(user, Roles.GetRolesForUser(user));
                    DropDownList roles = (DropDownList)gvResult.Rows[index].Cells[8].FindControl("cmbRole");
                    Roles.AddUserToRole(user, roles.SelectedValue);
                }
                else if (e.CommandName.ToLower().Equals("sendaccountinformation"))
                {
                }
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        protected void gvusers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton deluser = (LinkButton)e.Row.Cells[6].FindControl("lkbdeluser");
                deluser.CommandArgument = e.Row.RowIndex.ToString();

                LinkButton actuser = (LinkButton)e.Row.Cells[6].FindControl("lkbactuser");
                actuser.CommandArgument = e.Row.RowIndex.ToString();

                LinkButton newPass = (LinkButton)e.Row.Cells[7].FindControl("lkbSetPassword");
                newPass.CommandArgument = e.Row.RowIndex.ToString();

                LinkButton newEmail = (LinkButton)e.Row.Cells[7].FindControl("lkbSetEmail");
                newEmail.CommandArgument = e.Row.RowIndex.ToString();

                LinkButton role = (LinkButton)e.Row.Cells[8].FindControl("lkbRole");
                role.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    string username = e.Row.Cells[0].Text;
                    if (username != ConfigurationManager.AppSettings["MasterAccount"].ToString())
                    {
                        DropDownList ddl = (DropDownList)e.Row.Cells[8].FindControl("cmbRole");
                        if (Roles.GetRolesForUser(username).Length > 0)
                            ddl.SelectedValue = Roles.GetRolesForUser(username).GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {
                    ltMsg.Text = "Erro: " + ex.Message;
                }
            }
        }

        protected void cmbRepresentative_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRepresentative.Items.Count > 0)
                FillRepresentativeEmail();
        }
        private void FillRepresentativeEmail()
        {
            txtEmail.Text = DataBase.Scalar("select email from tb_Representative where RepresentativeId=" + cmbRepresentative.SelectedValue);
        }

        protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResult.PageIndex = e.NewPageIndex;
            gvResult.DataSource = Membership.GetAllUsers();
            gvResult.DataBind();
        }
    }
}
