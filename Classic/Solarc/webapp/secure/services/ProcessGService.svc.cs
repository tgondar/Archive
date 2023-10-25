using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using SolarcLogic.Logic;
using SolarcEntities;
using System.Web;
using System.Web.Security;

namespace Solarc.webapp.secure.services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProcessGService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetProcesses(string entity, string code, string reference)
        {
            ProcessGLogic pl = new ProcessGLogic();

            return translate(pl.GetProcessG(entity, code, reference));
        }
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public ProcessGEntity GetProcess(int processGId)
        {
            ProcessGLogic pl = new ProcessGLogic();

            var q = pl.GetProcessG(processGId);

            q.AlterDateString = q.AlterDate.ToString("dd-MM-yyyy HH:mm:ss");
            q.DateAlertString = q.DateAlert.ToString("dd-MM-yyyy");

            return q;
        }

        private string translate(IEnumerable<ProcessGEntity> input)
        {
            StringBuilder sb = new StringBuilder();
            bool aa = false, admin = Roles.IsUserInRole("Administrator");
            int time = 0;
            decimal total = 0;

            sb.Append("<table class=\"standard1\">");
            sb.Append("<tr>");
            sb.Append("<th>Ref. Interna</th>");
            sb.Append("<th>tempo</th>");
            sb.Append("<th>Saldo</th>");
            sb.Append("<th>Ref. Cliente</th>");
            sb.Append("<th>Entidade</th>");
            sb.Append("<th>Localizacao</th>");
            sb.Append("<th>Alteracao</th>");
            sb.Append("<th></th>");
            sb.Append("</tr>");

            if (input.Count() > 0)
            {
                foreach (var t in input.OrderByDescending(p=>p.AlterDate))
                {
                    sb.Append(string.Format("<tr class=\"{0}\">", aa ? "RowStyle2" : "AlternatingRowStyle2"));
                    sb.Append(string.Format("<td><h3><a href=\"ProcessG.aspx?pgid={0}\" style=\"color:#333333;\" >{1}</a></h3></td>", t.ProcessGId, t.Code));

                    time = t.DateAlert.Subtract(DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy"))).Days;
                    sb.Append(string.Format("<td><h4><span style=\"color:{1}\">{0}</span><h4></td>",time, time >= 0 ? "green" : "red"));

                    if (t.Payments.Count() > 0) total = t.Payments.Where(p => p.Income == true).Sum(p => p.Value) - t.Payments.Where(p => p.Income == false).Sum(p => p.Value);
                    else total = 0;

                    sb.Append(string.Format("<td><span style=\"color:{1}\">{0:f} €</span></td>", total, (total >= 0 ? "green" : "red")));
                    sb.Append(string.Format("<td>{0}</td>", t.Reference));
                    sb.Append(string.Format("<td>{0}</td>", t.EntityName));
                    sb.Append(string.Format("<td>{0}</td>", t.Localization));
                    sb.Append(string.Format("<td>{0}<br/>{1}</td>", t.AlterUser, t.AlterDate.ToString("dd-MM-yyyy HH:mm:ss")));
                    if (admin) sb.Append(string.Format("<td><img alt=\"\" src=\"../../images/webapp/icons/delete.png\" onclick=\"DeleteProcess({0})\" /></td>", t.ProcessGId));
                    else sb.Append("<td></td>");
                    sb.Append("</tr>");

                    aa = (aa == true ? false : true);
                }
            }
            else
                sb.Append("<tr><td>Sem resultados</td></tr>");

            sb.Append("</table>");

            return sb.ToString();
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddProcess(string entity, string code, string reference, string observation, string localization,string dateAlert)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                DateTime dt = new DateTime();
                DateTime.TryParse(dateAlert, out dt);

                if (entity.Trim().Length == 0) return "erro - entidade";
                if (code.Trim().Length == 0) return "erro - codigo";
                if (reference.Trim().Length == 0) return "erro - referencia";

                ProcessGLogic pl = new ProcessGLogic();
                pl.AddProcessG(code, entity, reference, observation, localization, HttpContext.Current.User.Identity.Name, dt);
            }
            else
                return "erro";

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string SaveProcess(int processgId, string entity, string code, string reference, string observation, string localization,string dateAlert)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGLogic pl = new ProcessGLogic();
                DateTime temp = new DateTime();
                DateTime.TryParse(dateAlert, out temp);

                pl.SaveProcessG(processgId, code.Trim(), entity.Trim(), reference.Trim(), observation.Trim(), localization.Trim(), HttpContext.Current.User.Identity.Name, temp);
            }
            else
                return "erro";

            return "ok";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetPayment(int processgId)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGPaymentLogic pl = new ProcessGPaymentLogic();
                return translatePayment(pl.GetPaymentsForProcess(processgId));
            }
            else
                return "erro";
        }
        private string translatePayment(IEnumerable<ProcessGPaymentEntity> input)
        {
            StringBuilder sb = new StringBuilder();
            decimal total = 0;
            bool aa = false;

            total = input.Where(p => p.Income == true).Sum(p => p.Value) - input.Where(p => p.Income == false).Sum(p => p.Value);
            sb.Append(string.Format("<p>Saldo <strong><span style=\"color:{1}\">{0:f} €<span></strong></p>", total, (total >= 0 ? "green" : "red")));

            sb.Append("<table width=\"100%\" class=\"standard1\">");
            sb.Append("<tr>");
            sb.Append("<th>Data</th>");
            sb.Append("<th>Entrada</th>");
            sb.Append("<th>Saída</th>");
            sb.Append("<th>Saldo</th>");
            sb.Append("<th>Designacao</th>");
            sb.Append("<th>Alteração</th>");
            sb.Append("<th></th>");
            sb.Append("</tr>");

            total = 0;
            if (input.Count() > 0)
            {
                foreach (var t in input.OrderBy(p=>p.PayDate))
                {
                    if (t.Income)
                        total += t.Value;
                    else
                        total -= t.Value;

                    sb.Append(string.Format("<tr class=\"{0}\">", aa ? "RowStyle2" : "AlternatingRowStyle2"));

                    sb.Append(string.Format("<td>{0}</td>", t.PayDate.ToString("dd-MM-yyyy")));
                    sb.Append(string.Format("<td style=\"color:green;\">{0:f}</td>", t.Income ? t.Value.ToString() + "€" : ""));
                    sb.Append(string.Format("<td style=\"color:red;\">{0:f}</td>", t.Income == false ? t.Value.ToString() + "€" : ""));
                    sb.Append(string.Format("<td style=\"color:{1};\">{0:f}€</td>", total, total <= 0 ? "red" : "green"));
                    sb.Append(string.Format("<td>{0}</td>", t.Designation));
                    sb.Append(string.Format("<td>{0}<br/>{1}</td>", t.AlterUser, t.AlterDate.ToString("dd-MM-yyyy HH:mm:ss")));
                    sb.Append(string.Format("<td><img alt=\"\" src=\"../../images/webapp/icons/delete.png\" onclick=\"DeletePayment({0},{1})\" /></td>", t.ProcessGId, t.PaymentId));
                    sb.Append("</tr>");

                    aa = (aa == true ? false : true);
                }
            }
            else
                sb.Append("<tr><td>Sem resultados</td></tr>");

            sb.Append("</table>");

            return sb.ToString();
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddPayment(int processGId, string designation, decimal value, bool income, string payDate)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGPaymentLogic pl = new ProcessGPaymentLogic();
                pl.AddPayment(processGId, designation, value, income, DateTime.Parse(payDate), HttpContext.Current.User.Identity.Name);

                ProcessGHistoryLogic pghl = new ProcessGHistoryLogic();
                pghl.AddHistory(processGId, "Pagamento", "NOVO", string.Format("{0} - {1}€ - {2}", (income == true ? "Entrada" : "Saida"), value, designation), HttpContext.Current.User.Identity.Name);

                return "ok";
            }
            else
                return "erro";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string DeletePayment(int processGId, int paymentId)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGPaymentLogic pl = new ProcessGPaymentLogic();
                pl.DeletePayment(processGId, paymentId, HttpContext.Current.User.Identity.Name);

                return "ok";
            }
            else
                return "erro";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string DeleteProcess(int processGId)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGLogic pl = new ProcessGLogic();
                return pl.DeleteProcess(processGId);
            }
            else
                return "erro autenticacao";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string GetInformation(int processgId)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGInformationLogic pl = new ProcessGInformationLogic();
                StringBuilder sb = new StringBuilder();
                var input = pl.GetInformationForProcess(processgId);
                bool aa = false;

                sb.Append("<table width=\"100%\" class=\"standard1\">");
                sb.Append("<tr>");
                sb.Append("<th>Utilizador</th>");
                sb.Append("<th>Informação</th>");
                sb.Append("<th>Data</th>");
                sb.Append("<th></th>");
                sb.Append("</tr>");

                if (input.Count() > 0)
                {
                    foreach (var t in input)
                    {
                        sb.Append(string.Format("<tr class=\"{0}\">", aa ? "RowStyle2" : "AlternatingRowStyle2"));

                        sb.Append(string.Format("<td nowrap=\"nowrap\">{0}</td>", t.CreateUser));
                        sb.Append(string.Format("<td width=\"100%\" align=\"left\">{0}</td>", t.Information));
                        sb.Append(string.Format("<td nowrap=\"nowrap\">{0}</td>", t.CreateDate.ToString("dd-MM-yyyy HH:mm:ss")));
                        sb.Append(string.Format("<td><img alt=\"\" src=\"../../images/webapp/icons/delete.png\" onclick=\"DeleteInformation({0})\" /></td>", t.InformationId));

                        sb.Append("</tr>");
                        aa = (aa == true ? false : true);
                    }
                }
                else
                    sb.Append("<tr><td>Sem resultados</td></tr>");

                sb.Append("</table>");

                return sb.ToString();

            }
            else
                return "erro";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string AddInformation(int processGId, string information)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGInformationLogic pl = new ProcessGInformationLogic();
                pl.AddInformation(processGId, information, HttpContext.Current.User.Identity.Name);

                ProcessGHistoryLogic pghl = new ProcessGHistoryLogic();
                pghl.AddHistory(processGId, "Informacao", "NOVO", information, HttpContext.Current.User.Identity.Name);

                return "ok";
            }
            else
                return "erro";
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string DeleteInformation(int processGId, int informationId)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ProcessGInformationLogic pl = new ProcessGInformationLogic();
                string oldInfo = string.Empty;

                oldInfo=pl.DeleteInformation(processGId, informationId);

                ProcessGHistoryLogic pghl = new ProcessGHistoryLogic();
                pghl.AddHistory(processGId, "Informacao", "APAGOU", oldInfo, HttpContext.Current.User.Identity.Name);

                return "ok";
            }
            else
                return "erro";
        }
    }
}
