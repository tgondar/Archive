using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.Security;

namespace Solarc.webapp.secure
{
    public partial class wucGeneralInformation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillChartProcess();
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleAdmin"]))
                {
                    FillChartRepresentative();
                    FillUser();
                }
                else
                    Chart2.Visible = false;
            }
        }

        private void FillChartProcess()
        {
            DataSet ds = DataBase.DataSet("exec uspChartProcess '" + Membership.GetUser().UserName + "'");
            if (ds != null)
            {
                int[] yValues = { int.Parse(ds.Tables[0].Rows[0][0].ToString()), int.Parse(ds.Tables[1].Rows[0][0].ToString()), int.Parse(ds.Tables[2].Rows[0][0].ToString()), int.Parse(ds.Tables[3].Rows[0][0].ToString()) };
                string[] xValues = { "Alterações/Dia", "+ de 30 Dias", "+ de 60 Dias", "+90 Dias" };
                Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                ds.Clear();
            }
        }
        private void FillChartRepresentative()
        {
            DataTable dt = DataBase.DataTable("exec uspChartRepresentative");
            if (dt.Rows.Count > 0)
            {
                List<int> tInt = new List<int>();
                List<string> tString = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    tString.Add(dr[0].ToString());
                    tInt.Add(int.Parse(dr[1].ToString()));
                }
                Chart2.Series["Series1"].Points.DataBindXY(tString, tInt);
                Chart2.Series["Series1"].IsValueShownAsLabel = true;
            }
        }
        private void FillUser()
        {
            DataTable dt = DataBase.DataTable("exec uspChartUserUpdate");
            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder("<div style=\"text-align:left; margin:10px 0 10px 0;\"><b>Num. alterações em processos por utilizador</b><br/>");
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                    sb.Append(string.Format("{2}. {0} - {1}<br/>", dr[0], dr[1], i++));

                sb.Append("</div>");
                lblUser.Text = sb.ToString();
            }
        }
    }
}
