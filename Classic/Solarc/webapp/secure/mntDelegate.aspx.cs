using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;
using System.Text;

namespace Solarc.webapp.secure
{
    public partial class mntDelegate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtAddress.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtPhone.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtFax.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtEmail.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");

            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = "20";
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);
                FillGrid();
            }
        }

        protected void lkbInsert_Click(object sender, EventArgs e)
        {
            InsertUpdate(0);
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            InsertUpdate(int.Parse(gvResult.SelectedDataKey.Value.ToString()));

            gvResult.SelectedIndex = -1;
            gvResult.Enabled = true;
            lkbInsert.Visible = true;
            lkbSearch.Visible = true;
            lkbSave.Visible = false;
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                Delegate d = new Delegate();
                gvResult.DataSource = d.GetDelegate(int.Parse(lkbPrev.CommandArgument), int.Parse(lkbNext.CommandArgument));
                string[] key = new string[] { "DelegateId" };
                gvResult.DataKeyNames = key;
                gvResult.DataBind();

                lkbPrev.Enabled = false;
                lkbNext.Enabled = false;
                if (gvResult.Rows.Count > 20) lkbNext.Enabled = true;
                if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        private void InsertUpdate(int theValue)
        {
            Delegate d = new Delegate();
            d.Name = txtName.Text;
            d.Address = txtAddress.Text;
            d.Phone = txtPhone.Text;
            d.Fax = txtFax.Text;
            d.Email = txtEmail.Text;

            d.Save(theValue);

            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;

            FillGrid();
        }
        protected void lkbPrev_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) - 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - 20).ToString();
            FillGrid();
        }
        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) + 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + 20).ToString();
            FillGrid();
        }
        protected void gvExecuted_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvResult.Enabled = false;
            lkbInsert.Visible = false;
            lkbSearch.Visible = false;
            lkbSave.Visible = true;

            string aux = string.Empty;

            aux = gvResult.Rows[gvResult.SelectedIndex].Cells[1].Text;
            txtName.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvResult.Rows[gvResult.SelectedIndex].Cells[2].Text;
            txtAddress.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvResult.Rows[gvResult.SelectedIndex].Cells[3].Text;
            txtPhone.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvResult.Rows[gvResult.SelectedIndex].Cells[4].Text;
            txtFax.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvResult.Rows[gvResult.SelectedIndex].Cells[5].Text;
            txtEmail.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
        }
    }
}
