using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using SolarcLogic;
using System.Linq;

namespace Solarc.webapp.secure
{
    public partial class ProcessEPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);

                if (Request.QueryString["pep"] != null)
                    FillGrid(int.Parse(Request.QueryString["pep"].ToString()));
                else
                    FillGrid(0);

                //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
                //lblTotalInfo.Text = ppBLL.GetProcessPaymentTotalInfo().Replace(".", ",");

                ProcessPaymentLogic ppl = new ProcessPaymentLogic();
                lblTotalInfo.Text = ppl.GetProcessPaymentTotal();

                Parameter p = new Parameter();
                if (p.GetInformation(5) == "0") gvResult.Columns[11].Visible = false;
            }
        }

        private void FillGrid(int theProcessId)
        {
            //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            ProcessPaymentLogic ppl = new ProcessPaymentLogic();
            if (theProcessId > 0)
                //gvResult.DataSource = ppBLL.GetProcessPaymentByProcessId(theProcessId);
                gvResult.DataSource = ppl.GetProcessPayment(theProcessId, -1);
            else
                //gvResult.DataSource = ppBLL.GetProcessPaymentTop30();
                gvResult.DataSource = ppl.GetProcessPayment(0, -1).Take(30);

            BindGrid();
        }

        private void BindGrid()
        {
            string[] key = new string[] { "PaymentYear", "PaymentId", "ProcessId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();

            gvResult.Columns[10].Visible = false;
        }
        protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.Cells[13].FindControl("imgBtPay");
                lkb.CommandArgument = e.Row.RowIndex.ToString();

                lkb = (ImageButton)e.Row.Cells[14].FindControl("imgBtDel");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToLower().Equals("pay"))
            {
                TextBox txt = (TextBox)gvResult.Rows[index].Cells[12].FindControl("txtInvoiceNumber");
                string InvoiceNumber = txt.Text;

                txt = (TextBox)gvResult.Rows[index].Cells[12].FindControl("txtObservation");
                string Observation = txt.Text;

                int PayedValue = int.Parse(gvResult.Rows[index].Cells[10].Text) == 1 ? 0 : 1;

                //ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
                //ppBLL.UpdateProcessPaymentSetPayed(int.Parse(gvResult.DataKeys[index][0].ToString()), int.Parse(gvResult.DataKeys[index][1].ToString()), PayedValue, InvoiceNumber, Observation);
                ProcessPaymentLogic ppl = new ProcessPaymentLogic();
                ppl.UpdateProcessPayment(int.Parse(gvResult.DataKeys[index][0].ToString()), int.Parse(gvResult.DataKeys[index][1].ToString()), InvoiceNumber, Observation, new Guid(Membership.GetUser().ProviderUserKey.ToString()));
            }
            else if (e.CommandName.ToLower().Equals("del"))
            {
                int val = 1;
                if (!Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleAdmin"]))
                {
                    val = 0;
                    if (wucAppKey1.Visible == false)
                    {
                        wucAppKey1.Visible = true;
                        wucAppKey1.NewAppKey();
                    }
                    else
                        if (wucAppKey1.CheckAppKey())
                            val = 1;
                        else
                            wucAppKey1.NewAppKey();
                }

                if (val == 1)
                {
                    ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
                    ppBLL.DeleteProcessPayment(int.Parse(gvResult.DataKeys[index][0].ToString()), int.Parse(gvResult.DataKeys[index][1].ToString()));

                    if (Request.QueryString["pep"] != null)
                        Server.Transfer("ProcessEPayment.aspx?pep=" + Request.QueryString["pep"], false);
                    else
                        Server.Transfer("ProcessEPayment.aspx", false);
                }
            }
        }
        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBt = (ImageButton)e.Row.FindControl("imgBtPay");
                imgBt.ImageUrl = "../../images/webapp/icons/" + (e.Row.Cells[10].Text == "1" ? "checked.png" : "unchecked.png");
            }
        }
        protected void imgBtSearch_Click(object sender, ImageClickEventArgs e)
        {
            ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            gvResult.DataSource = ppBLL.GetProcessPaymentFiltered(txtInternalCode.Text, (txtDate.Text.Length > 0 ? DateTime.Parse(txtDate.Text) : new DateTime()), decimal.Parse(txtTotal.Text), int.Parse(cmbPaymentType.SelectedValue), "", "", "", txtInvoiceNumber.Text);
            BindGrid();
        }
    }
}
