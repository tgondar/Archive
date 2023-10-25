using SolarcEntities;
using SolarcLogic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Logic
{
    public class ProcessGHistoryLogic
    {
        ProcessGHistoryDal pghd = new ProcessGHistoryDal();

        public IEnumerable<ProcessGHistoryEntity> GetPRocessGHistory(string processCode, DateTime startDate, DateTime endDate)
        {
            var q = pghd.GetProcessGHistory();

            if (processCode.Length > 0) q = q.Where(p => p.ProcessCode.Contains(processCode));
            if (startDate != new DateTime()) q = q.Where(p => p.AlterDate >= startDate && p.AlterDate <= endDate);

            return q;
        }

        public void AddHistory(int processGId, string field, string fromValue, string toValue, string userName)
        {
            ProcessGHistoryEntity pghe = new ProcessGHistoryEntity();

            pghe.AlterDate = DateTime.Now;
            pghe.AlterUser = userName;
            pghe.Field = field;
            pghe.FromValue = fromValue;
            pghe.ProcessGId = processGId;
            pghe.ToValue = toValue;

            pghd.AddHistory(pghe);
        }

        public void DeleteHistory(int historyId)
        {
            pghd.DeleteHistory(historyId);
        }
    }
}
