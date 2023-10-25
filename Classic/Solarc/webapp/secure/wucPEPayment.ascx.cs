using System;
using System.Web.UI.WebControls;
using SolarcLogic;
using System.Web.Security;

namespace Solarc.webapp.secure
{
    public partial class wucPEPayment : System.Web.UI.UserControl
    {
        public int ProcessId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
            if (!IsPostBack)
            {
                FillValues();
                FillGrid();
                txtPaymentDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                Parameter p = new Parameter();
                txtVat.Text = p.GetInformation(4);
                txtRetain.Text = p.GetInformation(5);

                if (txtRetain.Text == "0")
                {
                    txtRetain.Visible = false;
                    lblRetain.Visible = false;
                }
            }
        }

        private void FillValues()
        {
            //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            //string[] v = ppBLL.GetProcessPaymentInfo(ProcessId).ToString().Replace(".", ",").Split('|');
            ProcessPaymentLogic ppl = new ProcessPaymentLogic();
            string[] v = ppl.GetProcessPayments(ProcessId).Split('|');

            if (v.Length > 3)
            {
                lblPayed.Text = v[0];
                lblNotPayed.Text = v[1];
                lblTotal.Text = v[2];
                lblProvision.Text = v[3];
            }

            hlPayment.NavigateUrl = "ProcessEPayment.aspx?UserId=" + Guid.NewGuid() + "&ApplicattionSecurity=" + Guid.NewGuid() + "&pep=" + ProcessId;
        }
        private void FillGrid()
        {
            //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            //gvResult.DataSource = ppBLL.GetProcessPaymentNotPayedByProcessId(ProcessId);

            ProcessPaymentLogic ppl = new ProcessPaymentLogic();
            gvResult.DataSource = ppl.GetProcessPayment(ProcessId, 0);
            string[] key = new string[] { "PaymentYear", "PaymentId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();
        }

        protected void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPaymentType.SelectedValue)
            {
                case "1"://Mandatario
                    cmb2.Visible = false;

                    ProcessBLL pBLL = new ProcessBLL();
                    cmb3.DataSource = pBLL.GetProcessById(ProcessId);
                    cmb3.DataTextField = "RepresentativeName";
                    cmb3.DataValueField = "RepresentativeId";
                    cmb3.DataBind();
                    break;
                case "2":
                case "3"://Ent. Patronal
                    cmb2.Visible = true;

                    ProcessEmployerBLL peBLL = new ProcessEmployerBLL();
                    cmb2.DataSource = peBLL.GetProcessEmployerByProcessId(ProcessId);
                    cmb2.DataTextField = "EmployerName";
                    cmb2.DataValueField = "EmployerId";
                    cmb2.DataBind();

                    FillCmb3();
                    break;
                case "8":
                    cmb2.Items.Clear();

                    cmb2.Items.Add(new ListItem("Exequente", "1"));
                    cmb2.Items.Add(new ListItem("Executado", "2"));
                    cmb2.Items.Add(new ListItem("Ag. Execução", "3"));
                    cmb2.Items.Add(new ListItem("Outro", "4"));
                    break;
                default:
                    cmb2.Visible = false;

                    ProcessExecutedBLL pexBLL = new ProcessExecutedBLL();
                    cmb3.DataSource = pexBLL.GetProcessExecutedByProcessId(ProcessId);
                    cmb3.DataTextField = "ExecutedName";
                    cmb3.DataValueField = "ExecutedId";
                    cmb3.DataBind();
                    break;
            }
        }
        protected void cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentType.SelectedValue == "8")
            {
            }
            else
                FillCmb3();
        }

        private void FillCmb3()
        {
            if (cmb2.Items.Count > 0 && (cmbPaymentType.SelectedValue == "2" || cmbPaymentType.SelectedValue == "3"))
            {
                ProcessEmployerBLL peBLL = new ProcessEmployerBLL();
                cmb3.DataSource = peBLL.GetProcessEmployerByEmployerId(int.Parse(cmb2.SelectedValue));
                cmb3.DataTextField = "ExecutedName";
                cmb3.DataValueField = "ExecutedId";
                cmb3.DataBind();
            }
            else
                cmb3.Items.Clear();
        }
        protected void lkbAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                int ExecutedId = 0, RepresentativeId = 0, EmployerId = 0;

                if (cmbPaymentType.SelectedValue == "1")
                    RepresentativeId = int.Parse(cmb3.SelectedValue);
                else if (cmbPaymentType.SelectedValue == "2" || cmbPaymentType.SelectedValue == "3")
                {
                    EmployerId = int.Parse(cmb2.SelectedValue);
                    ExecutedId = int.Parse(cmb3.SelectedValue);
                }
                else
                    ExecutedId = int.Parse(cmb3.SelectedValue);

                ProcessPaymentLogic ppl = new ProcessPaymentLogic();
                ppl.AddProcessPayment(ProcessId, ExecutedId, DateTime.Parse(txtPaymentDate.Text), decimal.Parse(txtOutCome.Text), decimal.Parse(txtInCome.Text), decimal.Parse(txtVat.Text), decimal.Parse(txtRetain.Text), int.Parse(cmbPaymentType.SelectedValue), RepresentativeId, EmployerId, txtObservation.Text, new Guid(Membership.GetUser().ProviderUserKey.ToString()), string.Empty, 0);

                lblInfo.Text = "Pagamento adicionado com sucesso!";
                FillGrid();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Erro: " + ex.Message;
            }
        }

        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)gvResult.Rows[gvResult.SelectedIndex].Cells[4].FindControl("txtInvoiceNumber");
            string InvoiceNumber = txt.Text;

            txt = (TextBox)gvResult.Rows[gvResult.SelectedIndex].Cells[5].FindControl("txtObservation");
            string Observation = txt.Text;

            //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            //ppBLL.UpdateProcessPaymentSetPayed(int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][0].ToString()), int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][1].ToString()), 1, InvoiceNumber, Observation);
            ProcessPaymentLogic ppl = new ProcessPaymentLogic();
            ppl.UpdateProcessPayment(int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][0].ToString()), int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][1].ToString()), InvoiceNumber, Observation, new Guid(Membership.GetUser().ProviderUserKey.ToString()));

            gvResult.SelectedIndex = -1;
            FillGrid();
        }
        protected void lkbAddMonths_Click(object sender, EventArgs e)
        {
            int nMonths;
            if (!int.TryParse(txtMonths.Text, out nMonths))
            {
                lblInfo.Text = "O número de mensalidades que inseriu, não está correcto.";
            }
            else
            {
                int ExecutedId = 0, RepresentativeId = 0, EmployerId = 0;
                DateTime dateM = DateTime.Parse(txtPaymentDate.Text);
                //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
                ProcessPaymentLogic ppl = new ProcessPaymentLogic();

                for (int i = 0; i < nMonths; i++)
                {
                    try
                    {
                        if (cmbPaymentType.SelectedValue == "1")
                            RepresentativeId = int.Parse(cmb3.SelectedValue);
                        else if (cmbPaymentType.SelectedValue == "2" || cmbPaymentType.SelectedValue == "3")
                        {
                            EmployerId = int.Parse(cmb2.SelectedValue);
                            ExecutedId = int.Parse(cmb3.SelectedValue);
                        }
                        else
                            ExecutedId = int.Parse(cmb3.SelectedValue);

                        ppl.AddProcessPayment(ProcessId, ExecutedId, dateM.AddMonths(i), decimal.Parse(txtOutCome.Text), decimal.Parse(txtInCome.Text), decimal.Parse(txtVat.Text), decimal.Parse(txtRetain.Text), int.Parse(cmbPaymentType.SelectedValue), RepresentativeId, EmployerId, txtObservation.Text, new Guid(Membership.GetUser().ProviderUserKey.ToString()), string.Empty, 0);
                    }
                    catch (Exception ex)
                    {
                        lblInfo.Text = "Erro: " + ex.Message;
                    }
                }
                FillGrid();
                lblInfo.Text = "Pagamento adicionado com sucesso!";
            }
        }
    }
}
