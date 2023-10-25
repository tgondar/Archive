using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarcLogic.Dal;
using SolarcEntities;

namespace SolarcLogic.Logic
{
    public class ProcessGInformationLogic
    {
        ProcessGInformationDal pdal = new ProcessGInformationDal();

        public IEnumerable<ProcessGInformationEntity> GetInformationForProcess(int processGId)
        {
            var q = pdal.GetAllInformation().Where(p => p.ProcessGId == processGId);

            return q;
        }

        public void AddInformation(int processGId,string information,string userName)
        {
            ProcessGInformationEntity pg = new ProcessGInformationEntity();

            pg.CreateUser = userName;
            pg.Information = information;
            pg.ProcessGId = processGId;

            pdal.AddInformation(pg);
        }

        public string DeleteInformation(int processGId, int informationId)
        {
            return pdal.DeleteInformation(processGId, informationId);
        }
    }
}
