using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    public class ProcessPaymentDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<ProcessPaymentEntity> GetProcessPayment()
        {
            var query = from pp in db.tb_ProcessPayment

                        join ex in db.tb_Executed on pp.ExecutedId equals ex.ExecutedId into g1
                        from ex in g1.DefaultIfEmpty()

                        join pt in db.tb_PaymentType on pp.PaymentTypeId equals pt.PaymentTypeId into g4
                        from pt in g4.DefaultIfEmpty()

                        join r in db.tb_Representative on pp.RepresentativeId equals r.RepresentativeId into g2
                        from r in g2.DefaultIfEmpty()

                        join em in db.tb_Employer on pp.EmployerId equals em.EmployerdId into g3
                        from em in g3.DefaultIfEmpty()

                        join au in db.aspnet_Users on pp.AlterUserId equals au.UserId
                        join p in db.tb_Process on pp.ProcessId equals p.ProcessId

                        select new ProcessPaymentEntity()
                        {
                            AlterDate = pp.AlterDate,
                            CreateDate = pp.CreateDate,
                            EmployerId = pp.EmployerId,
                            //Executed = ex.Name,
                            //ExecutedId = pp.ExecutedId,
                            InCome = pp.InCome,
                            InvoiceNumber = pp.InvoiceNumber,
                            Observation = pp.Observation,
                            OutCome = pp.OutCome,
                            PaymentDate = pp.PaymentDate,
                            PaymentId = pp.PaymentId,
                            PaymentTypeId = pp.PaymentTypeId,
                            PaymentYear = pp.PaymentYear,
                            ProcessId = pp.ProcessId,
                            RepresentativeId = pp.RepresentativeId,
                            RetentionValue = pp.RetentionValue,
                            Status = pp.Status,
                            Vat = pp.Vat,
                            UserName = au.UserName,
                            PaymentType = pt.Name,
                            Representative = r.Name,
                            //Employer = em.Name,

                            ////Total = (decimal)(100 + pp.Vat) * (pp.OutCome + pp.InCome) / 100 - ((pp.OutCome + pp.InCome) - (decimal)(100 - pp.RetentionValue) * (pp.OutCome + pp.InCome) / 100),

                            pCode = p.Code,
                            pInitials = p.Initials,
                            pNumber = p.Number,
                            pYear = p.Year,
                            ProcessNumber = p.ProcessNumber
                        };

            return query;
        }
        public void UpdateProcessPayment(int year, int id, string invoiceNumber, string observation, Guid userId)
        {
            tb_ProcessPayment pp = db.tb_ProcessPayment.Single(p => p.PaymentYear == year && p.PaymentId == id);

            pp.InvoiceNumber = invoiceNumber;
            pp.Observation = observation;
            pp.Status = pp.Status == 1 ? 0 : 1;
            pp.AlterDate = DateTime.Now;
            pp.AlterUserId = userId;

            db.SaveChanges();
        }

        public void AddProcessPayment(int processId, int executedId, DateTime paymentDate, decimal outCome, decimal inCome, decimal vat, decimal retentionValue, int paymentTypeId, int representativeId, int employerId, string observation,
            Guid userId, string invoiceNumber, int status)
        {

            tb_ProcessPayment pp = new tb_ProcessPayment();

            pp.AlterDate = DateTime.Now;
            pp.AlterUserId = userId;
            pp.CreateDate = DateTime.Now;
            pp.CreateUserId = userId;

            if (employerId > 0)
                pp.EmployerId = employerId;

            if (executedId > 0)
                pp.ExecutedId = executedId;

            pp.InCome = inCome;
            pp.InvoiceNumber = invoiceNumber;
            pp.Observation = observation;
            pp.OutCome = outCome;
            pp.PaymentDate = paymentDate;

            int year = DateTime.Now.Year;
            int? tid = (from _pp in db.tb_ProcessPayment
                        where _pp.PaymentYear == year
                        orderby _pp.PaymentId descending
                        select _pp.PaymentId).FirstOrDefault();

            pp.PaymentId = (tid.Value + 1);

            pp.PaymentTypeId = paymentTypeId;
            pp.PaymentYear = DateTime.Now.Year;
            pp.ProcessId = processId;

            if (representativeId > 0)
                pp.RepresentativeId = representativeId;

            pp.RetentionValue = retentionValue;
            pp.Status = status;
            pp.Vat = vat;

            db.tb_ProcessPayment.Add(pp);
            db.SaveChanges();
        }
    }
}
