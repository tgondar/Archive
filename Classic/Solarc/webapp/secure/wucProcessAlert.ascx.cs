using System;
using System.Data;
using System.Text;
using System.Web.Security;

namespace Solarc.webapp.secure
{
    public partial class wucProcessAlert : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lblProcessAlert.Text = Alert();
        }

        private string Alert()
        {
            StringBuilder sb = new StringBuilder();
            int localizationId = 0;
            UserSettingBLL usBLL = new UserSettingBLL();

            /*
            VwProcessBLL vpBLL = new VwProcessBLL();
            DataTable dt = usBLL.GetUserSettingByUserId(new Guid(Membership.GetUser().ProviderUserKey.ToString()));
             */
            DataTable dt = DataBase.DataTable("select UserId,Theme,SearchResult,LocalizationId from tb_UserSetting where UserId='" + Membership.GetUser().ProviderUserKey + "'");

            if (dt.Rows.Count == 1) localizationId = int.Parse(dt.Rows[0]["LocalizationId"].ToString());

            //0dt = vpBLL.GetViewProcessByLocalization(localizationId);
            string t = "SELECT top 30 ProcessId,InternalNumber, Court, ProcessNumber, Number, Year, AlterDate, LocalizationId, Alert, Localization, DATEDIFF(dd, AlterDate, GETDATE()) as ND FROM vwProcess WHERE ";
            if (localizationId == 0 || localizationId == 1)
                t += " (Localization !='arquivo' and Localization !='findo')";
            else
                t += " (LocalizationId = " + localizationId + ")";
            t += " AND (DATEDIFF(dd, AlterDate, GETDATE()) >= Alert) group by ProcessId,InternalNumber, Court, ProcessNumber, Number, Year, AlterDate, LocalizationId, Alert, Localization ORDER BY DATEDIFF(dd, AlterDate, GETDATE()) DESC";

            dt = DataBase.DataTable(t);

            sb.Append("<ul>");
            if (dt.Rows.Count > 0)
            {
                sb.Append(dt.Rows.Count + " Processos que não alterados pelo Grupo (expiraram limite definido):<br/>");
                foreach (DataRow dR in dt.Rows)
                    sb.Append(string.Format("<li>Num. Int.: <b>{0}</b> - Num. Trib.: <b>{1}</b> - <span style=\"color:red;\">({2})</span></li>", dR["InternalNumber"], dR["ProcessNumber"], dR["ND"]));
            }
            else
                sb.Append("Não tem processos para rever, que tenham expirado o prazo (numero dias)!");
            sb.Append("</ul></div>");

            return sb.ToString();
        }
    }
}
