using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Security;

namespace Solarc.webapp.secure
{
    public partial class WebUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarPanelCalendar();
                Calendar1.SelectedDate = new DateTime();
                if (TextBox2.Text.Length == 0)
                    TextBox2_CalendarExtender.SelectedDate = DateTime.Now;
                //if (TextBox2.Text.Length == 0)
                //    
                //else
                //    Calendar1.SelectedDate = TextBox2_CalendarExtender.SelectedDate.Value;

            }
            //string strSql = string.Format("select Subject, Date from Calendar_tb_Event where 
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                DataTable dt = DataBase.DataTable((string.Format("select Date, EventID from Calendar_tb_Event where CONVERT(varchar(10),Date, 105) = '{0}' AND (CreateUserID='{1}' OR isPublic=1)",
                    e.Day.Date.ToString("dd-MM-yyyy"), Membership.GetUser().ProviderUserKey.ToString())));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (DataBase.DataTable(string.Format("exec uspCalendarIsRead {0}, '{1}'", dt.Rows[i][1].ToString(), Membership.GetUser().ProviderUserKey)).Rows[0][0].ToString() == "0")
                    {
                        e.Cell.BackColor = Color.Tomato;
                        break;
                    }
                    if (e.Cell.BackColor != Color.Tomato)
                        e.Cell.BackColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarPanelViewEvents(0, 0);
                TextBox2_CalendarExtender.SelectedDate = Calendar1.SelectedDate;

            }
            catch (Exception ex)
            {
                string lalal = ex.Message;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //DateTime data = new DateTime(Int32.Parse(DropDownListYear.SelectedValue), Int32.Parse(DropDownListMonth.SelectedValue), Int32.Parse(DropDownListDay.SelectedValue),
            //                        Int32.Parse(DropDownListHour.SelectedValue), Int32.Parse(DropDownListMinute.SelectedValue), 0);

            DateTime data = DateTime.Parse(tbDateEvent.Text);
            data = data.Add(new TimeSpan(int.Parse(DropDownListHour.SelectedValue), int.Parse(DropDownListMinute.SelectedValue), 0));
            if (Button3.CommandArgument == "1")
            {

                //0Date, 1Subject, 2Description, 3Alert, 4isPublic, 5CreateUserID
                string strSQL = string.Format("exec uspCalendarInsert '{0}', '{1}', '{2}', {3}, {4}, '{5}' ",
                    data.ToString("yyyy-MM-dd HH:mm:ss"), TextBoxSubject.Text, TextBoxDescription.Text, CheckBoxAlert.Checked ? 1 : 0,
                    CheckBoxPublic.Checked ? 1 : 0, Membership.GetUser().ProviderUserKey.ToString());


                DataBase.Deinup(strSQL);

                MostrarPanelCalendar();

            }
            else if (Button3.CommandArgument == "0")
            {

                //set 0Date=@Date,1Subject=@Subject,2Description=@Description,3Alert=@Alert, 4AlterUserId=@UserID,isPublic=@isPublic
                string strSql = string.Format("exec uspCalendarUpdate {0},'{1}', '{2}', '{3}', {4}, {5}, '{6}'", Session["id"],
                    data.ToString("yyyy-MM-dd HH:mm:ss"), TextBoxSubject.Text, TextBoxDescription.Text, CheckBoxAlert.Checked ? 1 : 0,
                    CheckBoxPublic.Checked ? 1 : 0, Membership.GetUser().ProviderUserKey);
                DataBase.Deinup(strSql);
                MostrarPanelCalendar();

            }
            else
            {
                LabelErrorLog.Text = "Nao é possivel marcar Calendar_tb_Event para datas anteriores a actual";
            }
        }
        private void MostrarPanelCalendar()
        {
            PanelCalendar.Visible = true;
            PanelInsert.Visible = false;
            PanelViewEvents.Visible = false;
            Calendar1.SelectedDate = new DateTime();
            ButtonMenuCalendar.Enabled = false;
            ButtonMenuInsert.Enabled = true;
            ButtonMenuList.Enabled = true;
        }
        private void MostrarPanelInsert()
        {
            LabelIsEditing.Text = "";
            PanelCalendar.Visible = false;
            PanelInsert.Visible = true;
            PanelViewEvents.Visible = false;

            ButtonMenuCalendar.Enabled = true;
            ButtonMenuInsert.Enabled = false;
            ButtonMenuList.Enabled = true;
            LabelErrorLog.Text = "";
            TextBoxSubject.Text = "";
            TextBoxDescription.Text = "";
            CheckBoxAlert.Enabled = true;
            CheckBoxPublic.Enabled = true;
        }

        private void EditItem(int theEventId)
        {
            MostrarPanelInsert();
            DataBase.Deinup(string.Format("exec uspCalendarMarkAsRead {0}, '{1}'", theEventId, Membership.GetUser().ProviderUserKey));

            DataTable dt = DataBase.DataTable("select * from calendar_tb_Event where EventID =" + theEventId);

            DateTime temp = DateTime.Parse(dt.Rows[0][1].ToString());

            tbDateEvent_CalendarExtender.SelectedDate = temp;
            DropDownListHour.SelectedValue = string.Format("{0:00}", temp.Hour);
            DropDownListMinute.SelectedValue = string.Format("{0:00}", temp.Minute);
            TextBoxSubject.Text = dt.Rows[0][2].ToString();
            TextBoxDescription.Text = dt.Rows[0][3].ToString();


            CheckBoxPublic.Checked = (int.Parse(dt.Rows[0]["isPublic"].ToString()) == 1) ? true : false;
            CheckBoxAlert.Checked = (int.Parse(dt.Rows[0]["Alert"].ToString()) == 1) ? true : false;

            if (dt.Rows[0]["CreateUserID"].ToString() == Membership.GetUser().ProviderUserKey.ToString())
            {
                CheckBoxPublic.Enabled = true;
            }
            else
                CheckBoxPublic.Enabled = false;

            CheckBoxAlert.Enabled = true;
            ButtonMenuCalendar.Enabled = true;
            ButtonMenuInsert.Enabled = false;
            ButtonMenuList.Enabled = true;
        }
        private void MostrarPanelViewEvents(int numDias, int numPag)
        {
            PanelCalendar.Visible = false;
            PanelInsert.Visible = false;
            PanelViewEvents.Visible = true;

            int numItems = int.Parse(DataBase.DataTable(string.Format("exec uspCalendarHowManyDayEvents '{0}', '{1}', {2}, {3}",
                Calendar1.SelectedDate.ToString("yyyy-MM-dd"), Membership.GetUser().ProviderUserKey, 0, numDias)).Rows[0][0].ToString());

            numItems /= 4;
            DropDownList1.Items.Clear();
            for (int i = 0; i <= numItems; i++)
                DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));

            DropDownList1.SelectedIndex = numPag;

            if (numDias == 0)
                GridView1.DataSource = ReturnDayEvents(Calendar1.SelectedDate, numPag);// GridView1.PageIndex);
            else
                GridView1.DataSource = ReturnDayEvents(Calendar1.SelectedDate, numDias, numPag);// GridView1.PageIndex);

            string[] key = new string[] { "EventId" };
            GridView1.DataKeyNames = key;

            GridView1.DataBind();
            ButtonMenuCalendar.Enabled = true;
            ButtonMenuInsert.Enabled = true;
            ButtonMenuList.Enabled = false;

            TextBox2_CalendarExtender.SelectedDate = Calendar1.SelectedDate;

        }

        private void MostrarPanelViewEventsLast(int last, int month)
        {
            PanelCalendar.Visible = false;
            PanelInsert.Visible = false;
            PanelViewEvents.Visible = true;

            if (last == 1)
                GridView1.DataSource = DataBase.DataTable(string.Format("select top 3 (CONVERT(char(10), date, 110) + ' ' + CONVERT(char(5),date, 108)) as Data, Subject, EventID, CAST(ctb.Alert as bit) as Alert " +
        "from Calendar_tb_Event ctb	where MONTH(date) < {0} and (CreateUserID='{1}' OR isPublic=1) order by Date desc", month, Membership.GetUser().ProviderUserKey));
            else
                GridView1.DataSource = DataBase.DataTable(string.Format("select top 3 (CONVERT(char(10), date, 110) + ' ' + CONVERT(char(5),date, 108)) as Data, Subject, EventID, CAST( ctb.Alert as bit) as Alert " +
        "from Calendar_tb_Event ctb	where MONTH(date) > {0} and (CreateUserID='{1}' OR isPublic=1) order by Date desc", month, Membership.GetUser().ProviderUserKey));

            string[] key = new string[] { "EventId" };
            GridView1.DataKeyNames = key;

            GridView1.DataBind();
            ButtonMenuCalendar.Enabled = true;
            ButtonMenuInsert.Enabled = true;
            ButtonMenuList.Enabled = false;
        }


        private DataTable ReturnDayEvents(DateTime vData, int numPag)
        {
            DataTable dt = DataBase.DataTable(string.Format("exec uspCalendarReturnDateEventsPaging '{0}', '{1}', {2}, {3}",
                vData.ToString("dd-MM-yyyy"), Membership.GetUser().ProviderUserKey, 4 * numPag + 1, 4 * numPag + 5));
            return dt;
        }

        private DataTable ReturnDayEvents(DateTime vData, int vNumDias, int numPag)
        {
            return DataBase.DataTable(string.Format("exec uspCalendarReturnEventsDaysPaging '{0}', '{1}', '{2}', {3}, {4}",
                vData.ToString("yyyy-MM-dd"), vNumDias, Membership.GetUser().ProviderUserKey, 4 * numPag + 1, 4 * numPag + 5));
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("ev"))
            {
                Button3.CommandArgument = "0";
                int index = Convert.ToInt32(e.CommandArgument);
                Session["id"] = GridView1.DataKeys[index].Value.ToString();
                EditItem(int.Parse(GridView1.DataKeys[index].Value.ToString()));
            }
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button AddP = (Button)e.Row.Cells[2].FindControl("ButtonEditEvent");
                AddP.CommandArgument = e.Row.RowIndex.ToString();

                if (DataBase.DataTable(string.Format("exec uspCalendarIsRead {0}, '{1}'", GridView1.DataKeys[e.Row.RowIndex].Value.ToString(), Membership.GetUser().ProviderUserKey)).Rows[0][0].ToString() == "0")
                {
                    e.Row.BackColor = Color.Beige;
                }

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = new DateTime();
            MostrarPanelCalendar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button3.CommandArgument = "1";
            LabelIsEditing.Visible = false;

            DropDownListHour.Enabled = true;
            DropDownListMinute.Enabled = true;
            TextBoxDescription.Text = "";
            CheckBoxAlert.Checked = true;
            MostrarPanelInsert();

            tbDateEvent_CalendarExtender.SelectedDate = TextBox2_CalendarExtender.SelectedDate.Value;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                int numDias = 0;
                try
                {
                    numDias = Int32.Parse(TextBox1.Text);
                    MostrarPanelViewEvents(numDias, 0);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    TextBox1.Text = "[Introduzir um numero aqui]";
                }
            }
        }

        protected void ButtonMenuCalendar_Click(object sender, EventArgs e)
        {
            MostrarPanelCalendar();
        }
        protected void ButtonMenuList_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Today;
            MostrarPanelViewEvents(0, 0);
        }
        protected void ButtonMenuInsert_Click(object sender, EventArgs e)
        {
            MostrarPanelInsert();
            tbDateEvent_CalendarExtender.SelectedDate = TextBox2_CalendarExtender.SelectedDate;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarPanelViewEvents(TextBox1.Text.Length != 0 ? int.Parse(TextBox1.Text) : 0, DropDownList1.SelectedIndex);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MostrarPanelViewEventsLast(1, TextBox2_CalendarExtender.SelectedDate.Value.Month);
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MostrarPanelViewEventsLast(0, TextBox2_CalendarExtender.SelectedDate.Value.Month);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Parse(TextBox2.Text);
            MostrarPanelViewEvents(0, 0);
        }
    }
}
