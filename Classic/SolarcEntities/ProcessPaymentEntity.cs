using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcEntities
{
    public class ProcessPaymentEntity
    {
        public int PaymentYear { get; set; }
        public int PaymentId { get; set; }
        public int ProcessId { get; set; }
        public int? ExecutedId { get; set; }
        public decimal OutCome { get; set; }
        public decimal InCome { get; set; }
        public decimal Vat { get; set; }
        public decimal RetentionValue { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? EmployerId { get; set; }
        public int Status { get; set; }
        public string InvoiceNumber { get; set; }
        public string Observation { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime AlterDate { get; set; }
        public Guid AlterUserId { get; set; }

        public string Executed { get; set; }
        public decimal Total { get; set; }
        public string Date { get; set; }
        public string UserName { get; set; }
        public string PaymentType { get; set; }
        public string PaymentFor { get; set; }
        public string Representative { get; set; }
        public string Employer { get; set; }

        public string InternalNumber { get; set; }
        public string pCode { get; set; }
        public int pNumber { get; set; }
        public int pYear { get; set; }
        public string pInitials { get; set; }
        public string ProcessNumber { get; set; }
    }
}
