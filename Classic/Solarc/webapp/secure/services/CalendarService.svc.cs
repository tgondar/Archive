using SolarcLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Solarc.webapp.secure.services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CalendarService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddAppointtment(string assigned, string date, string msg,int repeat)
        {
            CalendarLogic cl = new CalendarLogic();

            cl.AddCalendarSchedule(DateTime.Parse(date), assigned, msg, HttpContext.Current.User.Identity.Name, repeat);

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetCalendar(int month,int year,string userName)
        {
            CalendarLogic cl = new CalendarLogic();

            return cl.GetCalendarAppointments(month, year, userName);
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetSchedules(int day, int month, int year, string userName, string observation)
        {
            CalendarLogic cl = new CalendarLogic();

            return cl.GetSchedules(day, month, year, userName, observation);
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetDaySchedules(int day, int month, int year,string userName)
        {
            CalendarLogic cl = new CalendarLogic();

            return cl.GetDaySchedules(day, month, year, userName);
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string SetChecked(int calendarId)
        {
            CalendarLogic cl = new CalendarLogic();

            cl.SetChecked(calendarId);

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string DeleteSchedule(int calendarId)
        {
            CalendarLogic cl = new CalendarLogic();

            cl.DeleteSchedule(calendarId);

            return "ok";
        }
    }
}
