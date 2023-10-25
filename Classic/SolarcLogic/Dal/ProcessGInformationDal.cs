using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcEntities;

namespace SolarcLogic.Dal
{
    internal class ProcessGInformationDal
    {
        db_solarcDevelopEntities1 db = new db_solarcDevelopEntities1();

        public IQueryable<ProcessGInformationEntity> GetAllInformation()
        {
            return from pgi in db.tb_ProcessGInformation
                   select new ProcessGInformationEntity()
                   {
                       CreateDate = pgi.CreateDate,
                       CreateUser = pgi.CreateUser,
                       Information = pgi.Information,
                       InformationId = pgi.InformationId,
                       ProcessGId = pgi.ProcessGId
                   };
        }

        public void AddInformation(ProcessGInformationEntity pgie)
        {
            tb_ProcessGInformation pgi = new tb_ProcessGInformation();
            var t = db.tb_ProcessGInformation.Where(p => p.ProcessGId == pgie.ProcessGId);
            int id = 1;

            if (t.Count() > 0) id = t.Max(_pgi => _pgi.InformationId) + 1;

            pgi.ProcessGId = pgie.ProcessGId;
            pgi.CreateDate = DateTime.Now;
            pgi.CreateUser = pgie.CreateUser;
            pgi.Information = pgie.Information;
            pgi.InformationId = id;

            db.tb_ProcessGInformation.Add(pgi);
            db.SaveChanges();
        }

        public string DeleteInformation(int processGId,int informationId)
        {
            tb_ProcessGInformation pi = db.tb_ProcessGInformation.Single(p => p.ProcessGId == processGId && p.InformationId == informationId);
            string oldInfo = pi.Information;

            db.tb_ProcessGInformation.Remove(pi);
            db.SaveChanges();

            return oldInfo;
        }
    }
}
