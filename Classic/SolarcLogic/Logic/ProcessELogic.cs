using SolarcEntities;
using SolarcLogic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarcLogic.Logic
{
    public class ProcessELogic
    {
        ProcessEDal ped = new ProcessEDal();

        public DateTime GetIRS(int processId)
        {
            return ped.GetIRS(processId);
        }
        public void SetIRS(int processId, DateTime newDate)
        {
            ped.SetIRS(processId, newDate);
        }
        public IEnumerable<ProcessEClient> GetProcessClient(int processId)
        {
            return ped.GetProcessClient(processId);
        }
        public void AddProcessClient(string clientName, int processId)
        {
            ped.AddProcessClient(clientName, processId);
        }
        public void DelProcessClient(string clientName, int processId)
        {
            ped.DelProcessClient(clientName, processId);
        }
    }
}
