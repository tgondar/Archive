using System;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Management;

namespace Solarc.webapp.secure
{
    public partial class mp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Parameter param = new Parameter();
                //  CSS
                if (Session["UserSetting"] == null)
                {
                    ltInfo.Text = "A sua sessão expirou, significa que esteve com a aplicação aberta sem a usar, por motivos de segurança, tem de fazer login novamente.<br/ ><h1><a href=\"javascript:_click('" + loginstatus.ClientID + "');\"clique aqui</a></h1>";
                    return;
                }

                lblCSS.Text = string.Format("<link href=\"../../includes/mainApp{0}.css\" rel=\"stylesheet\" type=\"text/css\" />", Session["UserSetting"].ToString().Split('|').GetValue(0));

                ltInfo.Text = "Bem vindo/a <a Class=\"textLink\" href=\"mntUserSettings.aspx\"><b>" + Membership.GetUser().UserName + "</b></a> > Ultimo login: <b>" + Session["LastLoginDate"] + "</b>";
                if ((Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente")) && param.GetValue(1) == "1")
                    lblRepresentative.Text = "<li><a href=\"Representative.aspx\" rel=\"\"><span>Mandatários</span></a></li>";
                else
                {
                    //ultimos pocessos alterados pelo user
                    DataSet ds = DataBase.DataSet("select top 3 InternalNumber,ProcessId from vwProcess where UserName='" + Membership.GetUser().UserName + "' group by InternalNumber,ProcessId,AlterDate order by AlterDate desc");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string temp = string.Empty;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            temp += string.Format("<a class=\"textLinkLastProcess\" href=\"process.aspx?pr={1}\" target=\"_self\"> " + (i + 1) + ". {0}</a> ", ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1]);
                        ltInfo.Text += " -> Ultimas consultas: " + temp;
                    }
                }

                lblLogin.Text = string.Format("<a href=\"#\" onclick=\"javascript:_click('{0}');\"><span>Terminar Sessão</span></a>", loginstatus.ClientID);
                if (!(Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente")))
                {
                    lblMenu.Text = "<li><a href=\"#\" rel=\"admin\"><span>Administração</span></a></li>";
                    lblMenu.Text += "<li><a href=\"#\" rel=\"mant\"><span>Manutenção</span></a></li>";
                    lblMenu.Text += "<li><a href=\"#\" rel=\"proc\"><span>Processos</span></a></li>";
                    lblMenu.Text += "<li><a href=\"#\" rel=\"pay\"><span>Pagamentos</span></a></li>";
                    lblMenu.Text += "<li><a href=\"Document.aspx\"><span>Minutas</span></a></li>";
                }
            }
        }
        protected void txtInternalNumber_TextChanged(object sender, EventArgs e)
        {
            //enviar querystring com o valor da pesquisa
            if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                Server.Transfer("Representative.aspx?value=" + txtInternalNumber.Text, false);
            else
                Server.Transfer("processearch.aspx?value=" + txtInternalNumber.Text, false);
        }
    }
}
