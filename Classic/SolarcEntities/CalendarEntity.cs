using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class CalendarEntity
    {
        public int CalendarId { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public bool Checked { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime AlterDate { get; set; }
        public string AlterUser { get; set; }
        public string AssignedUser { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
