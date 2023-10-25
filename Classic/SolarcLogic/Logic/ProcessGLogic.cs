using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;
using SolarcEntities;

namespace SolarcLogic.Logic
{
    public class ProcessGLogic
    {
        ProcessGDal pdal = new ProcessGDal();

        private IEnumerable<ProcessGEntity> GetProcessG()
        {
            return pdal.GetProcessG();
        }

        public IEnumerable<ProcessGEntity> GetProcessG(string entity, string code, string reference)
        {
            var q = pdal.GetProcessG();

            entity = entity.ToUpper();
            code = code.ToUpper();
            reference = reference.ToUpper();

            if (entity.Length > 0) q = q.Where(p => p.EntityName.ToUpper().Contains(entity));
            if (code.Length > 0) q = q.Where(p => p.Code.ToUpper().Contains(code));
            if (reference.Length > 0) q = q.Where(p => p.Reference.ToUpper().Contains(reference));

            return q;
        }
        public ProcessGEntity GetProcessG(int processGId)
        {
            return pdal.GetProcessG().Single(p => p.ProcessGId == processGId);
        }

        public void AddProcessG(string code, string entityName, string reference, string observation, string localization, string user,DateTime dateAlert)
        {
            ProcessGEntity pge = new ProcessGEntity();
            EntityEnt ee = new EntityLogic().GetEntity(entityName);

            pge.Code = code;
            pge.EntityId = ee.EntityId;
            pge.Reference = reference;
            pge.Observation = observation;
            pge.Localization = localization;
            pge.CreateUser = user;
            pge.AlterUser = user;
            pge.EntityName = entityName;

            if (dateAlert == new DateTime())
                pge.DateAlert = DateTime.Parse(DateTime.Now.AddMonths(3).ToString("dd-MM-yyyy"));
            else
                pge.DateAlert = dateAlert;

            pdal.AddProcessG(pge);
        }
        public void SaveProcessG(int processGId, string code, string entityName, string reference, string observation, string localization, string user,DateTime dateAlert)
        {
            ProcessGEntity pge = new ProcessGEntity();
            pge.ProcessGId = processGId;

            if (entityName.Length > 0)
            {
                EntityEnt ee = new EntityLogic().GetEntity(entityName);
                pge.EntityId = ee.EntityId;
                pge.EntityName = entityName;
            }

            pge.Code = code;
            pge.Reference = reference;
            pge.Observation = observation;
            pge.Localization = localization;
            pge.AlterUser = user;
            pge.DateAlert = dateAlert;

            pdal.SaveProcessG(pge);
        }

        public string DeleteProcess(int processId)
        {
            return pdal.DeleteProcess(processId);
        }
    }
}
