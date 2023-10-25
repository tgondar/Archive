using SolarcEntities;
using SolarcLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Solarc.webapp.secure.services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProcessEService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetIRS(int processId)
        {
            ProcessELogic pel = new ProcessELogic();

            return pel.GetIRS(processId).ToString("dd-MM-yyyy");
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string SetIRS(int processId, string newDate)
        {
            ProcessELogic pel = new ProcessELogic();

            pel.SetIRS(processId, DateTime.Parse(newDate));

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<ProcessEClient> GetProcessClient(int processId)
        {
            ProcessELogic pel = new ProcessELogic();
            return pel.GetProcessClient(processId).ToList();
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddProcessClient(string clientName, int processId)
        {
            ProcessELogic pel = new ProcessELogic();
            pel.AddProcessClient(clientName, processId);

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string DelProcessClient(string clientName, int processId)
        {
            ProcessELogic pel = new ProcessELogic();
            pel.DelProcessClient(clientName, processId);

            return "ok";
        }
    }
}
