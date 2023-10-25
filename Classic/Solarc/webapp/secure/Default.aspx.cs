using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Security;
using L2S;
using SolarcLogic;
using SolarcEntities;
using System.Collections.Generic;
using System.Drawing;
using System.Web;

namespace Solarc.webapp.secure
{
    public partial class Default : System.Web.UI.Page
    {
        //List<CalendarEntity> lCal = new List<CalendarEntity>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Representative.aspx", false);

                //lblProcessPayment.Text = ProcessPayment();

                //CalendarLogic cl = new CalendarLogic();
                //lCal = cl.GetSchedules(0, DateTime.Now.Month, DateTime.Now.Year).ToList();
            }
        }

        //private string ProcessPayment()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    BdDataClassesDataContext dc = new BdDataClassesDataContext();

        //    var query = from p in dc.tb_Processes
        //                join pg in dc.tb_ProcessPayments on p.ProcessId equals pg.ProcessId
        //                where pg.Status == 0 && DateTime.Now > pg.PaymentDate
        //                orderby pg.PaymentDate
        //                select new { p.ProcessId, p.Code, p.Number, p.Year, p.Initials, p.ProcessNumber, pg.PaymentDate };

        //    sb.Append("<div style=\"float:left; overflow: auto; width:300px; height:200px; border:1px solid #000000;\" class=\"BackInformation\"  >");
        //    sb.Append("<b>Processos Executivos:</b><br/>");
        //    sb.Append("Processos com pagamentos expirados e não pagos:<br/>");
        //    sb.Append("<ul>");
        //    foreach (var q in query)
        //        sb.Append(string.Format("<li><a href=\"Process.aspx?val=" + Guid.NewGuid() + "&pr={6}&secureAlt=" + Guid.NewGuid() + "\" target=\"_self\">{0}/{1}/{2}{3} - {4} ({5})</a></li>", q.Code, q.Number, q.Year, (q.Initials.Length > 0 ? "/" + q.Initials : string.Empty), q.ProcessNumber, Math.Floor(DateTime.Now.Subtract(q.PaymentDate).TotalDays), q.ProcessId));
        //    if (query.Count() == 0) sb.Append("<li>0</li>");
        //    sb.Append("</ul>");


        //    query = from p in dc.tb_Processes
        //            join pg in dc.tb_ProcessPayments on p.ProcessId equals pg.ProcessId
        //            where pg.Status == 0 && pg.PaymentDate > DateTime.Now && (pg.PaymentDate - DateTime.Now).TotalDays <= 15
        //            orderby pg.PaymentDate
        //            select new { p.ProcessId, p.Code, p.Number, p.Year, p.Initials, p.ProcessNumber, pg.PaymentDate };

        //    sb.Append("<br/>Processos com pagamentos que expiram dentro de 15 dias:<br/>");
        //    sb.Append("<ul>");
        //    foreach (var q in query)
        //        sb.Append(string.Format("<li><a href=\"Process.aspx?val=" + Guid.NewGuid() + "&pr={6}&secureAlt=" + Guid.NewGuid() + "\" target=\"_self\">{0}/{1}/{2}{3} - {4} ({5})</a></li>", q.Code, q.Number, q.Year, (q.Initials.Length > 0 ? "/" + q.Initials : string.Empty), q.ProcessNumber, Math.Floor(q.PaymentDate.Subtract(DateTime.Now).TotalDays), q.ProcessId));

        //    if (query.Count() == 0) sb.Append("<li>0</li>");
        //    sb.Append("</ul>");
        //    sb.Append("</div>");

        //    return sb.ToString();
        //}
    }
}
