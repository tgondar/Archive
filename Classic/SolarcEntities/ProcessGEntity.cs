using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessGEntity
    {
        public int ProcessGId { get; set; }
        public string Code { get; set; }
        public int EntityId { get; set; }
        public bool Closed { get; set; }
        public string Reference { get; set; }
        public string Observation { get; set; }
        public string Localization { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime AlterDate { get; set; }
        public string AlterUser { get; set; }
        public DateTime DateAlert { get; set; }

        public string EntityName { get; set; }
        public string AlterDateString { get; set; }
        public string DateAlertString { get; set; }
        public IEnumerable<ProcessGPaymentEntity> Payments { get; set; }
    }
}
