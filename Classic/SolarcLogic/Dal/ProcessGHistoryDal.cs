using SolarcEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Dal
{
    public class ProcessGHistoryDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IQueryable<ProcessGHistoryEntity> GetProcessGHistory()
        {
            return from pg in db.tb_ProcessG
                   join pgh in db.tb_ProcessGHistory on pg.ProcessGId equals pgh.ProcessGId
                   select new ProcessGHistoryEntity()
                   {
                       AlterDate = pgh.AlterDate,
                       AlterUser = pgh.AlterUser,
                       Field = pgh.Field,
                       FromValue = pgh.FromValue,
                       Id = pgh.Id,
                       ProcessGId = pgh.ProcessGId,
                       ToValue = pgh.ToValue,
                       ProcessCode = pg.Code
                   };
        }

        public void AddHistory(ProcessGHistoryEntity pghe)
        {
            tb_ProcessGHistory ph = new tb_ProcessGHistory();

            ph.AlterDate = pghe.AlterDate;
            ph.AlterUser = pghe.AlterUser;
            ph.Field = pghe.Field;
            ph.FromValue = pghe.FromValue;
            ph.ProcessGId = pghe.ProcessGId;
            ph.ToValue = pghe.ToValue;

            db.tb_ProcessGHistory.Add(ph);
            db.SaveChanges();
        }
        public void DeleteHistory(int historyId)
        {
            var q = db.tb_ProcessGHistory.Single(p => p.Id == historyId);
            db.tb_ProcessGHistory.Remove(q);
            db.SaveChanges();
        }

        internal void AddHistoryInternal(int processGId, string field, string fromValue, string toValue, string userName)
        {
            tb_ProcessGHistory ph = new tb_ProcessGHistory();

            ph.AlterDate = DateTime.Now;
            ph.AlterUser = userName;
            ph.Field = field;
            ph.FromValue = fromValue;
            ph.ProcessGId = processGId;
            ph.ToValue = toValue;

            db.tb_ProcessGHistory.Add(ph);
            db.SaveChanges();
        }
    }
}
