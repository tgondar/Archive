using SolarcEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Dal
{
    public class ProcessEDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public DateTime GetIRS(int processId)
        {
            return db.tb_Process.Single(p => p.ProcessId == processId).IRS;
        }
        public void SetIRS(int processId, DateTime newDate)
        {
            var q = db.tb_Process.Single(p => p.ProcessId == processId);

            q.IRS = newDate;

            db.SaveChanges();
        }

        public IEnumerable<ProcessEClient> GetProcessClient(int processId)
        {
            return from pc in db.tb_ProcessClient
                   where pc.ProcessId == processId
                   select new ProcessEClient()
                   {
                       ClientName = pc.aspnet_Users.UserName,
                       ProcessId = pc.ProcessId,
                       UserId = pc.ClientUserId
                   };
        }
        public void AddProcessClient(string clientName, int processId)
        {
            clientName = clientName.ToLower();
            var userid = db.aspnet_Users.Single(p => p.LoweredUserName == clientName).UserId;

            tb_ProcessClient pc = new tb_ProcessClient();
            pc.flag = false;
            pc.ProcessId = processId;
            pc.ClientUserId = userid;

            db.tb_ProcessClient.Add(pc);
            db.SaveChanges();
        }
        public void DelProcessClient(string clientName, int processId)
        {
            clientName = clientName.ToLower();
            var userid = db.aspnet_Users.Single(p => p.LoweredUserName == clientName).UserId;

            var pc = db.tb_ProcessClient.Single(p => p.ClientUserId == userid && p.ProcessId == processId);

            db.tb_ProcessClient.Remove(pc);
            db.SaveChanges();
        }
    }
}
