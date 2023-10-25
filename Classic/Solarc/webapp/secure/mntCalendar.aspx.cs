using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using SolarcLogic;

namespace Solarc.webapp.secure
{
    public partial class mntCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["it"] != null)
                    cmbItems.SelectedValue = Request.QueryString["it"];

                FillGrid(0, 0, 0);
            }
        }

        private void FillGrid(int day, int month, int year)
        {
            CalendarLogic cl = new CalendarLogic();
            gvResult.DataSource = cl.GetCalendarSchedules(day, month, year, int.Parse(cmbItems.SelectedValue));
            gvResult.DataKeyNames = new string[] { "CalendarId", "Checked" };
            gvResult.DataBind();
        }

        protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lkb = (LinkButton)e.Row.Cells[0].FindControl("lkbChecked");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lkb = (LinkButton)e.Row.FindControl("lkbChecked");
                if (gvResult.DataKeys[e.Row.RowIndex][1].ToString() == "True")
                {
                    lkb.ForeColor = Color.Green;
                    lkb.Text = "Activo";
                }
                else
                {
                    lkb.ForeColor = Color.Red;
                    lkb.Text = "Inactivo";
                }
            }
        }
        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToLower().Equals("checked"))
            {
                CalendarLogic cl = new CalendarLogic();
                cl.SetChecked(int.Parse(gvResult.DataKeys[index][0].ToString()));

                FillGrid(0, 0, 0);
            }
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid(0, 0, 0);
        }
    }
}
