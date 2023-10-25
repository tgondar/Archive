using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessGPaymentEntity
    {
        public int ProcessGId { get; set; }
        public int PaymentId { get; set; }
        public string Designation { get; set; }
        public decimal Value { get; set; }
        public bool Income { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime AlterDate { get; set; }
        public string AlterUser { get; set; }
    }
}
