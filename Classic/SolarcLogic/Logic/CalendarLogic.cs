using SolarcEntities;
using SolarcLogic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic
{
    public class CalendarLogic
    {
        CalendarDal cd = new CalendarDal();

        public IEnumerable<CalendarEntity> GetSchedules(int day, int month, int year,string userName)
        {
            var query = cd.GetCalendarSchedules();

            if (userName.Length > 0) query = query.Where(pp => pp.AssignedUser == userName);

            if (day > 0) query = query.Where(p => p.Date.Day == day);
            if (month > 0) query = query.Where(p => p.Date.Month == month);
            if (year > 0) query = query.Where(p => p.Date.Year == year);

            return query;
        }

        public string GetSchedules(int day, int month, int year,string userName,string observation)
        {
            StringBuilder sb = new StringBuilder();
            var query = cd.GetCalendarSchedules();

            if (observation.Length > 0) query = query.Where(pp => pp.Observation.Contains(observation));
            if (userName.Length > 0) query = query.Where(pp => pp.AssignedUser == userName);

            if (day > 0) query = query.Where(p => p.Date.Day == day);
            if (month > 0) query = query.Where(p => p.Date.Month == month);
            if (year > 0) query = query.Where(p => p.Date.Year == year);

            sb.Append("Total registos: " + query.Count());

            sb.Append("<table class=\"standard1\">");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th>Data</th><th>De</th><th>Para</th><th>Descrição</th><th>Fechado?</th><th></th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            bool alt = false;

            foreach (var t in query.ToList())
            {
                sb.Append(string.Format("<tr class=\"{0}\">", (alt == true ? "AlternatingRowStyle2" : "RowStyle2")));
                sb.Append(string.Format("<td>{0}</td>", t.Date.ToString("dd-MM-yyyy")));
                sb.Append(string.Format("<td>{0}</td>", t.CreateUser));
                sb.Append(string.Format("<td>{0}</td>", t.AssignedUser));
                sb.Append(string.Format("<td>{0}</td>", t.Observation));
                sb.Append(string.Format("<td>{0}</span></td>", t.Checked == true ? "<span style=\"color:green;\">Sim" : "<span style=\"color:red;\">Não"));
                sb.Append(string.Format("<td>" + (t.Checked == false ? "<input type=\"button\" class=\"btCalendarCheck\" onclick=\"SetChecked({0})\" />" : "") + "<input type=\"button\" class=\"btCalendarDel\" onclick=\"YesNo(); DeleteSchedule({0});\" /></td>", t.CalendarId));
                sb.Append("</tr>");

                alt = (alt == true ? false : true);
            }

            sb.Append("</tbody>");
            sb.Append("</table>");

            return sb.ToString();
        }


        public string GetDaySchedules(int day, int month, int year,string userName)
        {
            //<input type=\"button\" class=\"btCalendarCheck\" onclick=\"SetChecked({1})\" /><input type=\"button\" class=\"btCalendarDel\" onclick=\"YesNo(); DeleteSchedule({1});\" />

            var query = cd.GetCalendarSchedules();
            if (userName.Length > 0) query = query.Where(pp => pp.AssignedUser.ToLower() == userName.ToLower());

            DateTime dt = DateTime.Parse(year + "-" + month + "-" + day);

            query = query.Where(p => (p.Checked == false && p.Date <= DateTime.Now) || (p.Checked == false && (p.Date >= dt && p.Date <= dt)) || (p.Checked == true && (p.CloseDate >= dt && p.CloseDate <= dt))).OrderBy(pp => pp.Checked).ThenBy(p => p.Date);

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("<section class=\"notepad\"><div class=\"notepad-heading\"><h1>{0}-{1}-{2} <input type=\"button\" value=\"Cancelar\" onclick=\"CloseForm2()\" /><div id=\"divLoadingCalendarDetail\"><img src=\"../../images/webapp/loading.gif\" alt=\"\" /></div></h1></div>", day, month, year));
            foreach (var t in query.ToList())
            {
                if (t.Checked)
                {
                    sb.Append(string.Format("<blockquote>Para: {0}, de: {1} <span style=\"font-size:8px;\">({2} dias atraso)</span><br />", t.AssignedUser, t.CreateUser, t.CloseDate.Subtract(t.Date).Days));
                    sb.Append(string.Format("<span style=\"text-decoration:line-through; color:green;\">{0}</span> <span style=\"font-size:8px;\">({1})</span>", t.Observation, t.Date.ToString("dd-MM-yyyy")));
                    sb.Append(string.Format("  <input type=\"button\" class=\"btCalendarDel\" onclick=\"YesNo(); DeleteSchedule({0});\" /></blockquote>", t.CalendarId));
                }
                else
                {
                    sb.Append(string.Format("<blockquote>Para: {0}, de: {1} <span style=\"font-size:8px;\">({2} dias atraso)</span><br />", t.AssignedUser, t.CreateUser, DateTime.Now.Subtract(t.CloseDate).Days));
                    sb.Append(string.Format("<span style=\"color:red;\">{0}</span>", t.Observation));
                    sb.Append(string.Format("  <input type=\"button\" class=\"btCalendarCheck\" onclick=\"SetChecked({0})\" /><input type=\"button\" class=\"btCalendarDel\" onclick=\"YesNo(); DeleteSchedule({0});\" /></blockquote>", t.CalendarId));
                }
            }
            sb.Append("</section>");

            return sb.ToString();
        }

        public IEnumerable<CalendarEntity> GetCalendarSchedules(int day, int month, int year,int check)
        {
            var query = cd.GetCalendarSchedules();

            if (check > -1) query = query.Where(p => p.Checked == (check == 1 ? true : false));
            else if (check == 2)
                query = query.Where(p => p.Checked == false && p.Date <= DateTime.Now);

            if (day > 0) query = query.Where(p => p.Date.Day == day);
            if (month > 0) query = query.Where(p => p.Date.Month == month);
            if (year > 0) query = query.Where(p => p.Date.Year == year);

            return query;
        }

        public bool PastSchedules()
        {
            var query = GetSchedules(0, 0, 0,string.Empty);

            if (query.Where(p => p.Checked == false && p.Date <= DateTime.Now).Count() > 0)
                return true;
            else
                return false;
        }

        public string GetSchedule(int day, int month, int year)
        {
            StringBuilder sb = new StringBuilder();
            var q = GetSchedules(day, month, year,string.Empty);

            if (q != null)
            {
                sb.Append(string.Format("<strong>{0}/{1}/{2}</strong><br/>", day, month, year));
                foreach (var t in q.OrderBy(p => p.Date))
                    sb.Append(string.Format("<strong>{0}</strong><br/>{1}<br/>", t.Date.ToString("HH:mm"), t.Observation));
            }

            return sb.Length > 0 ? sb.ToString() : "Sem marcacao";
        }

        public void AddCalendarSchedule(DateTime date, string assigned, string observation, string userName, int repeat)
        {
            CalendarEntity ce = new CalendarEntity();
            DateTime dt = date;
            if (repeat < 2) repeat = 1;

            for (int i = 0; i < repeat; i++)
            {
                ce = new CalendarEntity();
                ce.CreateDate = DateTime.Now;
                ce.AlterDate = DateTime.Now;
                ce.AlterUser = userName;
                ce.CreateUser = userName;
                ce.Date = dt;
                ce.Observation = observation;
                ce.Checked = false;
                ce.AssignedUser = assigned;

                cd.AddCalendarSchedule(ce);

                dt = dt.AddMonths(1);
            }
        }

        public void SetChecked(int calendarId)
        {
            cd.SetChecked(calendarId);
        }

        public void DeleteSchedule(int calendarId)
        {
            db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();
            var q = db.tb_Calendar.Single(pp => pp.CalendarId == calendarId);

            db.tb_Calendar.Remove(q);
            db.SaveChanges();
        }

        public string GetCalendarAppointments(int month, int year,string userName)
        {
            StringBuilder sb = new StringBuilder();
            db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();
            var query = db.tb_Calendar.Where(p => p.CDate.Year == year && (p.CDate.Month >= month - 1 && p.CDate.Month <= month + 1));

            if (userName.Length > 0) query = query.Where(pp => pp.AssignedUser.ToLower() == userName.ToLower());

            var appointments = query.ToList();

            IEnumerable<tb_Calendar> _lc;
            int val = 0, count = 0;

            DateTime dt = DateTime.Parse(year + "-" + month + "-1");

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    dt = dt.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    dt = dt.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    dt = dt.AddDays(-6);
                    break;
                case DayOfWeek.Thursday:
                    dt = dt.AddDays(-3);
                    break;
                case DayOfWeek.Tuesday:
                    dt = dt.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    dt = dt.AddDays(-2);
                    break;
            }

            sb.Append("<div style=\" clear:both; margin: 1px; height:30px;\"><div class=\"weekDays\">Segunda-feira</div><div class=\"weekDays\">Terça-feira</div><div class=\"weekDays\">Quarta-feira</div><div class=\"weekDays\">Quinta-feira</div><div class=\"weekDays\">Sexta-feira</div><div class=\"weekDays\">Sábado</div><div class=\"weekDays\">Domingo</div></div>");
            sb.Append("<div style=\" clear:both; margin: 1px;\">");

            sb.Append("<div style=\"clear:both; height:142px;\">");

            string class1 = string.Empty, class2 = string.Empty, div1 = string.Empty;

            for (int i = 0; i < 42; i++)
            {
                _lc = appointments.Where(p => p.CDate.Day == dt.Day && p.CDate.Month == dt.Month && p.Checked == false);

                if (dt.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    class1 = "currentDay";
                    class2 = "actualMonthDayNumber";
                    div1 = "<div class=\"eventContent\">";
                }
                else if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    class1 = "weekend";
                    class2 = "weekendDayNumber";
                    div1 = "<div class=\"eventContent\">";
                }
                else
                {
                    if (dt.Month < month)
                    {
                        class1 = "previousNextMonth";
                        class2 = "previousNextMonthDayNumber";
                        div1 = "<div class=\"eventContent\" style=\" overflow:auto; height: 100px; \">";
                    }
                    else if (dt.Month == month)
                    {
                        if (_lc.Count() > 0)
                        {
                            class1 = "actualMonthSpecial";
                            class2 = "actualMonthSpecialDayNumber";
                        }
                        else
                        {
                            class1 = "actualMonth";
                            class2 = "actualMonthDayNumber";
                        }

                        div1 = "<div style=\" overflow:auto; height: 100px; font-size:10px; color:#000000; width:120px; font-weight:normal; clear:both;\">";
                    }
                    else if (dt.Month > month)
                    {
                        class1 = "previousNextMonth";
                        class2 = "previousNextMonthDayNumber";
                        div1 = "<div class=\"eventContent\" style=\" overflow:auto; height: 100px; \">";
                    }
                }

                sb.Append(string.Format("<div class=\"{0}\"><div class=\"{1}\"><div><div style=\"float:left;\" class=\"btCalendar\" onclick=\"OpenDetail('{2}','{3}','{4}')\">", class1, class2, dt.Day, dt.Month, dt.Year));
                sb.Append(dt.Day);
                sb.Append("</div>");

                count = appointments.Where(pp => pp.CloseDate == dt && pp.Checked == true).Count();
                if (count > 0) sb.Append(string.Format("<span style=\"font-size:8px;\">{0}</span>", count));

                sb.Append("<div style=\"float:right;\" onclick=\"ViewForm('" + dt.ToString("yyyy-MM-dd") + "')\" class=\"btCalendarAdd\"></div></div>");
                sb.Append(div1);
                foreach (var _c in _lc) if (_c.Checked == false) sb.Append(string.Format("- {0}<br />", _c.Observation));
                sb.Append("</div></div></div>");

                if (val > 5)
                {
                    val = 0;
                    sb.Append("</div>");
                    sb.Append("<div style=\"clear:both; height:142px;\">");
                }
                else
                    val++;

                dt = dt.AddDays(1);
            }
            sb.Append("</div></div>");

            return sb.ToString();
        }
    }
}
