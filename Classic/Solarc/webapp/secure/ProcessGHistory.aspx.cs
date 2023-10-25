using SolarcLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class ProcessGHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSearch.Text = string.Empty;
            if (!Roles.IsUserInRole("Administrator"))
            {
                btSearch.Visible = false;
                gvResult.Visible = false;

                lblSearch.Text = "Nao tem acesso a esta informação";
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            ProcessGHistoryLogic pghl = new ProcessGHistoryLogic();

            DateTime sDate = new DateTime(), eDate = new DateTime();

            DateTime.TryParse(txtEndDate.Text, out eDate);
            DateTime.TryParse(txtStartDate.Text, out sDate);

            sDate = DateTime.Parse(sDate.ToString("dd-MM-yyyy"));
            eDate = DateTime.Parse(eDate.ToString("dd-MM-yyyy") + " 23:59:59");

            gvResult.DataSource = pghl.GetPRocessGHistory(txtProcess.Text.Trim(), sDate, eDate);
            gvResult.DataKeyNames = new string[] { "Id" };
            gvResult.DataBind();

            lblSearch.Text = "Pesquisou por: ";
            if (txtProcess.Text.Trim().Length > 0) lblSearch.Text += "Referencia Interna <strong>" + txtProcess.Text.Trim() + "</strong>";
            if (sDate != new DateTime()) lblSearch.Text += "   Datas: <strong>" + sDate.ToString("dd-MM-yyyy HH:mm") + "/" + eDate.ToString("dd-MM-yyyy HH:mm") + "</strong>";
        }

        protected void gvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProcessGHistoryLogic phl = new ProcessGHistoryLogic();
            phl.DeleteHistory(int.Parse(e.Keys[0].ToString()));

        }
    }
}
