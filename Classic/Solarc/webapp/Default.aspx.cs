using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Security;

public partial class webapp_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        String ecn = System.Environment.MachineName;
        Response.Write(Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn);
        Response.Write("<br/>");

        // check processor
        Parameter param = new Parameter();
        string sProcessorID = string.Empty;
        ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
        ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
        foreach (ManagementObject oManagementObject in oCollection)
        {
            sProcessorID = (string)oManagementObject["ProcessorId"];
        }
        if (sProcessorID != param.ProcessorId)
        {
            Response.Write("<b><span style=\"color:black;\">Erro - Código de protecção!</span></b>");
            Login1.Enabled = false;
            return;
        }
        else0
        {
         */
            //Response.Write(Server.MapPath(""));
            if (Request.QueryString["error"] != null)
                lblInfo.Text = "Não tem permissão para entrar na aplicação neste momento";

            Login1.Focus();
        /*
         }
         */
    }
    protected void Login1_LoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
    {
        if (Login1.UserName == ConfigurationManager.AppSettings["MasterAccount"].ToString())
        {
            lblInfo.Text = "Erro: Não pode entrar na aplicação com essa conta!";
            return;
        }
        if (Membership.GetUser(Login1.UserName) != null)
        {
            Session["LastLoginDate"] = Membership.GetUser(Login1.UserName).LastActivityDate;
            Session["UserSetting"] = DataBase.Scalar("exec uspUserSettingGet '" + Membership.GetUser(Login1.UserName).ProviderUserKey + "'");
        }
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, ConfigurationManager.AppSettings["RoleUser"]))
        {
            //verifica se faz filtro por IP
            Parameter p = new Parameter();
            if (p.GetValue(2) != "0")
                if (p.GetValue(2) != Request.ServerVariables["remote_addr"])
                    Server.Transfer("Default.aspx?error=" + Guid.NewGuid(), false);
        }
    }
    protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
    {
        if (Membership.GetUser(Login1.UserName) != null)
        {
            if (Membership.ValidateUser(Login1.UserName, Login1.Password) && Roles.GetRolesForUser(Login1.UserName).Length > 0)
            {
                e.Authenticated = true;
                MembershipUser usr = Membership.GetUser(Login1.UserName);
                usr.LastLoginDate = DateTime.Now;
                usr.LastActivityDate = DateTime.Now;
                Membership.UpdateUser(usr);
            }
            else if (Membership.ValidateUser(ConfigurationManager.AppSettings["MasterAccount"].ToString(), Login1.Password))
                e.Authenticated = true;
            else
                e.Authenticated = false;
        }
        else
            Login1.FailureText = "Utilizador/Password Incorrectos";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //Our postvars
            byte[] buffer = Encoding.ASCII.GetBytes("user=sp&password=o12a71hg3j9jlk8if6&to=966003600&text=Foi adicionada nova entrada no processo PE/0123/2010, consulte a aplicacao pf, obrigado.");
            //Initialization, we use localhost, change if applicable
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://dev.msglab.com/sp/sendmsg.php");

            //Our method is post, otherwise the buffer (postvars) would be useless
            WebReq.Method = "POST";

            //We use form contentType, for the postvars.
            WebReq.ContentType = "application/x-www-form-urlencoded";

            //The length of the buffer (postvars) is used as contentlength.
            WebReq.ContentLength = buffer.Length;

            //We open a stream for writing the postvars
            Stream PostData = WebReq.GetRequestStream();
            
            //Now we write, and afterwards, we close. Closing is always important!
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();
            
            //Get the response handle, we have no true response yet!
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            
            //Let's show some information about the response
            Response.Write(WebResp.StatusCode + "<br/>");
            Response.Write(WebResp.Server + "<br/>");

            //Now, we read the response (the string), and output it.
            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            Response.Write(_Answer.ReadToEnd());

        }
        catch (Exception ex)
        {
            Response.Write("ERRO --> " + ex.Message);
        }
    }
}
 