using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;
using SolarcLogic.Dal;

namespace SolarcLogic.Logic
{
    public class ProcessGPaymentLogic
    {
        ProcessGPaymentDal pgpl = new ProcessGPaymentDal();

        private IQueryable<ProcessGPaymentEntity> GetAllPayments()
        {
            return pgpl.GetAllPayments();
        }

        public IEnumerable<ProcessGPaymentEntity> GetPaymentsForProcess(int processGId)
        {
            var q = GetAllPayments().Where(p => p.ProcessGId == processGId);
            return q;
        }

        public void AddPayment(int processGId, string designation, decimal value, bool income, DateTime payDate, string userName)
        {
            ProcessGPaymentEntity pgpe = new ProcessGPaymentEntity();

            pgpe.ProcessGId = processGId;
            pgpe.Designation = designation;
            pgpe.Value = value;
            pgpe.Income = income;
            pgpe.PayDate = payDate;
            pgpe.AlterUser = userName;
            pgpe.CreateUser = userName;

            ProcessGPaymentDal pl = new ProcessGPaymentDal();
            pl.AddPayment(pgpe);
        }

        public void DeletePayment(int processGId, int paymentId,string userName)
        {
            pgpl.DeletePayment(processGId, paymentId, userName);
        }
    }
}
