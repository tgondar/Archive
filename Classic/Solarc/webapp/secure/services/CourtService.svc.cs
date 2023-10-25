using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using SolarcEntities;
using SolarcLogic.Logic;

namespace Solarc.webapp.secure.services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CourtService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetAutocomplete(string term)
        {
            CourtLogic cl = new CourtLogic();

            var q = cl.GetAutocomplete(term);

            return q.Select(p => p.Name);
        }
    }
}
