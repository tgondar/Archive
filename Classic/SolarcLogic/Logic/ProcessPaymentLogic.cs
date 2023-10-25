using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;
using SolarcLogic.Dal;

namespace SolarcLogic
{
    public class ProcessPaymentLogic
    {
        ProcessPaymentDal ppd = new ProcessPaymentDal();

        public IEnumerable<ProcessPaymentEntity> GetProcessPayment(int processId,int status)
        {
            var query = ppd.GetProcessPayment();

            if (processId > 0) query = query.Where(p => p.ProcessId == processId);
            if (status > -1) query = query.Where(p => p.Status == status);

            List<ProcessPaymentEntity> lPP = new List<ProcessPaymentEntity>();
            ProcessPaymentEntity ppe = new ProcessPaymentEntity();

            foreach (var q in query)
            {
                ppe = new ProcessPaymentEntity();

                ppe.AlterDate = q.AlterDate;
                ppe.AlterUserId = q.AlterUserId;
                ppe.CreateDate = q.CreateDate;
                ppe.CreateUserId = q.CreateUserId;
                ppe.EmployerId = q.EmployerId;
                ppe.Executed = q.Executed;
                ppe.ExecutedId = q.ExecutedId;
                ppe.InCome = q.InCome;
                ppe.InvoiceNumber = q.InvoiceNumber;
                ppe.Observation = q.Observation;
                ppe.OutCome = q.OutCome;
                //ppe.PaymentDate = q.PaymentDate.ToString("dd-MM-yyyy");
                ppe.Date = q.PaymentDate.ToString("dd-MM-yyyy");
                ppe.PaymentId = q.PaymentId;
                ppe.PaymentTypeId = q.PaymentTypeId;
                ppe.PaymentYear = q.PaymentYear;
                ppe.ProcessId = q.ProcessId;
                ppe.RepresentativeId = q.RepresentativeId;
                ppe.RetentionValue = q.RetentionValue;
                ppe.Status = q.Status;
                ppe.Vat = q.Vat;
                ppe.UserName = q.UserName;
                ppe.PaymentType = q.PaymentType;
                ppe.InternalNumber = q.pCode + "/" + q.pNumber + "/" + q.pYear + (q.pInitials.Length > 0 ? "/" + q.pInitials : string.Empty);
                ppe.ProcessNumber = q.ProcessNumber;

                switch (ppe.PaymentTypeId)
                {
                    case 1:
                        ppe.PaymentFor = q.Representative;
                        break;
                    case 2:
                    case 3:
                        ppe.PaymentFor = q.Employer + " / " + q.Executed;
                        break;
                    default:
                        ppe.PaymentFor = q.Executed;
                        break;
                }

                ppe.Total = (decimal)(100 + ppe.Vat) * (ppe.OutCome + ppe.InCome) / 100 - ((ppe.OutCome + ppe.InCome) - (decimal)(100 - ppe.RetentionValue) * (ppe.OutCome + ppe.InCome) / 100);

                lPP.Add(ppe);
            }

            return lPP;
        }
        public string GetProcessPaymentTotal()
        {
            var query = ppd.GetProcessPayment();
            string output = string.Empty;

            output += "<b>Total Recebido:</b> " + string.Format("{0:0.00} €", query.Where(p => p.Status == 1 && p.PaymentTypeId != 1).Sum(p => p.Total));
            output += "&nbsp;<b>Total em Falta:</b> " + string.Format("{0:0.00} €", query.Where(p => p.Status == 0 && p.PaymentTypeId != 1).Sum(p => p.Total));
            output += "&nbsp;<b>Total:</b> " + string.Format("{0:0.00} €", query.Where(p => p.PaymentTypeId != 1).Sum(p => p.Total));
            output += "&nbsp;<b>Total Provisão:</b> " + string.Format("{0:0.00} €", query.Where(p => p.PaymentTypeId == 1).Sum(p => p.Total));

            return output;
        }
        public string GetProcessPayments(int processId)
        {
            //List<ProcessPaymentEntity> query = ppd.GetProcessPayment().Where(p => p.ProcessId == processId).ToList();
            List<ProcessPaymentEntity> query = GetProcessPayment(processId, -1).ToList();
           string output = string.Empty;

            if (query.Where(p => p.Status == 1 && p.PaymentTypeId != 1).Count() > 0)
                output += string.Format("{0:0.00} €", query.Where(p => p.Status == 1 && p.PaymentTypeId != 1).Sum(p => p.Total)) + "|";
            else
                output += "0|";

            output += string.Format("{0:0.00} €", query.Where(p => p.Status == 0 && p.PaymentTypeId != 1).Sum(p => p.Total)) + "|";
            output += string.Format("{0:0.00} €", query.Where(p => p.PaymentTypeId != 1).Sum(p => p.Total)) + "|";
            output += string.Format("{0:0.00} €", query.Where(p => p.PaymentTypeId == 1).Sum(p => p.Total));

            return output;
        }
        public void UpdateProcessPayment(int year, int id, string invoiceNumber, string observation, Guid userId)
        {
            ppd.UpdateProcessPayment(year, id, invoiceNumber, observation, userId);
        }

        public void AddProcessPayment(int processId, int executedId, DateTime paymentDate, decimal outCome, decimal inCome, decimal vat, decimal retentionValue, int paymentTypeId, int representativeId, int employerId, string observation,
    Guid userId, string invoiceNumber, int status)
        {
            ppd.AddProcessPayment(processId, executedId, paymentDate, outCome, inCome, vat, retentionValue, paymentTypeId, representativeId, employerId, observation, userId, invoiceNumber, status);
        }
    }
}
