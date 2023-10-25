using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    public class ProcessGDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IEnumerable<ProcessGEntity> GetProcessG()
        {
            return from pg in db.tb_ProcessG
                   join en in db.tb_Entity on pg.EntityId equals en.EntityId
                   join pgp in
                       (
                           from pgp in db.tb_ProcessGPayment
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
                           }
                           ) on pg.ProcessGId equals pgp.ProcessGId into paym
                   select new ProcessGEntity()
                   {
                       Payments = paym,
                       AlterDate = pg.AlterDate,
                       AlterUser = pg.AlterUser,
                       Closed = pg.Closed,
                       Code = pg.Code,
                       CreateDate = pg.CreateDate,
                       CreateUser = pg.CreateUser,
                       EntityId = pg.EntityId,
                       EntityName = en.Name,
                       Localization = pg.Localization,
                       Observation = pg.Observation,
                       ProcessGId = pg.ProcessGId,
                       Reference = pg.Reference,
                       DateAlert = pg.DateAlert
                   };
        }

        public void AddProcessG(ProcessGEntity pge)
        {
            tb_ProcessG pg = new tb_ProcessG();

            pg.Code = pge.Code;
            pg.EntityId = pge.EntityId;
            pg.Closed = false;
            pg.Reference = pge.Reference;
            pg.Observation = pge.Observation;
            pg.Localization = pge.Localization;
            pg.CreateDate = DateTime.Now;
            pg.CreateUser = pge.CreateUser;
            pg.AlterDate = DateTime.Now;
            pg.AlterUser = pge.AlterUser;
            pg.DateAlert = pge.DateAlert;

            db.tb_ProcessG.Add(pg);
            db.SaveChanges();

            ProcessGHistoryDal pghd = new ProcessGHistoryDal();
            pghd.AddHistoryInternal(pg.ProcessGId, "NovoProcesso", "", string.Format("Ref. Interna: {0}, Cliente: {1}, Ref. Cliente: {2}, Obs: {3}, Localizacao: {4}",
                pge.Code, pge.EntityName, pge.Reference, pge.Observation, pge.Localization), pge.AlterUser);
        }

        public void SaveProcessG(ProcessGEntity pge)
        {
            tb_ProcessG pg = db.tb_ProcessG.Single(p => p.ProcessGId == pge.ProcessGId);

            ProcessGHistoryDal pghd = new ProcessGHistoryDal();

            if (pg.Code != pge.Code && pge.Code.Length > 0)
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Ref. Interna", pg.Code, pge.Code, pge.AlterUser);
                pg.Code = pge.Code;
            }
            if (pg.DateAlert != pge.DateAlert && pge.DateAlert != new DateTime())
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Data Alerta", pg.DateAlert.ToString("dd-MM-yyyy"), pge.DateAlert.ToString("dd-MM-yyyy"), pge.AlterUser);
                pg.DateAlert = pge.DateAlert;
            }
            if (pg.EntityId != pge.EntityId && pge.EntityId > 0)
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Cliente", "", pge.EntityName, pge.AlterUser);
                pg.EntityId = pge.EntityId;
            }
            if (pg.Reference != pge.Reference && pge.Reference.Length > 0)
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Ref. Cliente", pg.Reference, pge.Reference, pge.AlterUser);
                pg.Reference = pge.Reference;
            }
            if (pg.Observation != pge.Observation && pge.Observation.Length > 0)
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Observacao", pg.Observation, pge.Observation, pge.AlterUser);
                pg.Observation = pge.Observation;
            }
            if (pg.Localization != pge.Localization && pge.Localization.Length > 0)
            {
                pghd.AddHistoryInternal(pge.ProcessGId, "Localizacao", pg.Localization, pge.Localization, pge.AlterUser);
                pg.Localization = pge.Localization;
            }

            pg.AlterDate = DateTime.Now;
            pg.AlterUser = pge.AlterUser;

            db.SaveChanges();
        }

        public string DeleteProcess(int processId)
        {
            string msg;
            try
            {
                var q = db.tb_ProcessG.Single(p => p.ProcessGId == processId);
                db.tb_ProcessG.Remove(q);
                db.SaveChanges();

                msg = "ok";
            }
            catch (Exception ex)
            {
                msg = "ERRO: Processo tem relaçoes com Pagamentos, Informações ou Historico, apague relaçoes primeiro.";
            }

            return msg;
        }
    }
}
