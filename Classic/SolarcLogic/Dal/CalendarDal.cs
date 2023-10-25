using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    public class CalendarDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<CalendarEntity> GetCalendarSchedules()
        {
            return from c in db.tb_Calendar
                   select new CalendarEntity()
                   {
                       AlterDate = c.AlterDate,
                       AlterUser = c.AlterUser,
                       CalendarId = c.CalendarId,
                       Checked = c.Checked,
                       CreateDate = c.CreateDate,
                       CreateUser = c.CreateUser,
                       Date = c.CDate,
                       Observation = c.Observation,
                       AssignedUser = c.AssignedUser,
                       CloseDate = c.CloseDate
                   };
        }

        public void AddCalendarSchedule(CalendarEntity ce)
        {
            tb_Calendar c = new tb_Calendar();

            c.AlterDate = ce.AlterDate;
            c.AlterUser = ce.AlterUser;
            c.CDate = ce.Date;
            c.Checked = ce.Checked;
            c.CreateDate = ce.CreateDate;
            c.CreateUser = ce.CreateUser;
            c.Observation = ce.Observation;
            c.AssignedUser = ce.AssignedUser;
            c.CloseDate = ce.Date;

            db.tb_Calendar.Add(c);
            db.SaveChanges();
        }

        public void SetChecked(int calendarId)
        {
            tb_Calendar c = db.tb_Calendar.Single(p => p.CalendarId == calendarId);
            c.Checked = (c.Checked == true ? false : true);
            c.CloseDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            db.SaveChanges();
        }
    }
}
