using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using SolarcLogic.Logic;
using System.Web;

namespace Solarc.webapp.secure.services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EntityService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetEntities(string term)
        {
            EntityLogic el = new EntityLogic();

            var q = el.GetEntities(term).Select(p => p.Name);

            return q;
        }
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetCreditor(string term)
        {
            CreditorLogic el = new CreditorLogic();

            var q = el.GetCreditor(term);

            return q;
        }
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetExecuted(string term)
        {
            ExecutedLogic el = new ExecutedLogic();

            var q = el.GetExecuted(term);

            return q;
        }
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetRepresentative(string term)
        {
            RepresentativeLogic el = new RepresentativeLogic();

            var q = el.GetRepresentative(term);

            return q;
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddEntity(string code, string name, string identityCard, string hPhone, string mPhone, string contactName, string fax, string email, string taxNumber, string address, string postalCode, string observation)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (name.Trim().Length > 0)
                {
                    EntityLogic el = new EntityLogic();
                    el.SaveEntity(0, code, name, identityCard, hPhone, mPhone, contactName, fax, email, taxNumber, address, postalCode, observation, HttpContext.Current.User.Identity.Name, true);

                    return "ok";
                }
                else
                    return "erro";
            }
            else
                return "erro";
        }
    }
}
