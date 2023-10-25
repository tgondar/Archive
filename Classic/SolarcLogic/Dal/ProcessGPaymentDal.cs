using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    internal class ProcessGPaymentDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IQueryable<ProcessGPaymentEntity> GetAllPayments()
        {
            return from pgp in db.tb_ProcessGPayment
                   select new ProcessGPaymentEntity()
                   {
                       AlterDate = pgp.AlterDate,
                       AlterUser = pgp.AlterUser,
                       CreateDate = pgp.CreateDate,
                       CreateUser = pgp.CreateUser,
                       Designation = pgp.Designation,
                       Income = pgp.Income,
                       PayDate = pgp.PayDate,
                       PaymentId = pgp.PaymentId,
                       ProcessGId = pgp.ProcessGId,
                       Value = pgp.Value
                   };
        }
        public void AddPayment(ProcessGPaymentEntity pgpe)
        {
            tb_ProcessGPayment pp = new tb_ProcessGPayment();

            int total = 1;
            var qqq = db.tb_ProcessGPayment.Where(p => p.ProcessGId == pgpe.ProcessGId).OrderByDescending(p => p.PaymentId).FirstOrDefault();
            if (qqq != null) total = qqq.PaymentId + 1;


            pp.AlterDate = DateTime.Now;
            pp.AlterUser = pgpe.AlterUser;
            pp.CreateDate = DateTime.Now;
            pp.CreateUser = pgpe.CreateUser;
            pp.Designation = pgpe.Designation;
            pp.Income = pgpe.Income;
            pp.PayDate = pgpe.PayDate;
            pp.PaymentId = total;
            pp.ProcessGId = pgpe.ProcessGId;
            pp.Value = pgpe.Value;

            db.tb_ProcessGPayment.Add(pp);
            db.SaveChanges();
        }

        public void DeletePayment(int processGId,int paymentId,string userName)
        {
            var q = db.tb_ProcessGPayment.Single(p => p.ProcessGId == processGId && p.PaymentId == paymentId);


            ProcessGHistoryDal pghd = new ProcessGHistoryDal();
            pghd.AddHistoryInternal(processGId, "Pagamento", "APAGOU", string.Format("{0} - {1}€ - {2}", (q.Income == true ? "Entrada" : "Saida"), q.Value, q.Designation), userName);


            db.tb_ProcessGPayment.Remove(q);
            db.SaveChanges();
        }
    }
}
