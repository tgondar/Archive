using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls;
using L2S;

namespace Solarc.webapp.secure
{
    public partial class processearch : System.Web.UI.Page
    {
        private int NDays { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = String.Empty;

            txtCourt.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtCreditor.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtExecuted.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtInternalNumber.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtProcessNumber.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtRepresentative.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtNDays.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtInternalNumber.Focus();

            if (!IsPostBack)
            {
                FillUsers();
                FillGroup();

                lkbSearch.CommandArgument = "||||||||0|||0|0";

                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);

                lkbPrevious.CommandArgument = "1";
                lkbNext.CommandArgument = ConfigurationManager.AppSettings["Paging"];

                int tempNdays = 0;
                if (Request.QueryString["value"] != null)
                {
                    //txtInternalNumber.Text = Request.QueryString["value"];
                    lkbSearch.CommandArgument = Request.QueryString["value"] + "||||||||0|||0|0";
                    FillSearch(1);
                }
                else if (Request.QueryString["nday"] != null && int.TryParse(Request.QueryString["nday"], out tempNdays))
                {
                    txtNDays.Text = int.Parse(Request.QueryString["nday"]).ToString();
                    FillSearch(1);
                }
                else
                    FillSearch(0);
            }
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            DateTime dt1, dt2;
            if (txtDate1.Text.Length > 0)
            {
                if (!DateTime.TryParse(txtDate1.Text, out dt1))
                {
                    lblSearch.Text = "Erro: Data1 valor incorrecto.";
                    return;
                }
                if (!DateTime.TryParse(txtDate2.Text, out dt2))
                {
                    lblSearch.Text = "Erro: Data2 valor incorrecto.";
                    return;
                }
            }

            lkbSearch.CommandArgument = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", txtInternalNumber.Text, txtProcessNumber.Text, txtCourt.Text, txtCreditor.Text, txtRepresentative.Text, txtExecuted.Text, txtLocalization.Text, cmbUser.SelectedValue, int.Parse(cmbGroup.SelectedValue), txtDate1.Text, txtDate2.Text, txtProvision.Text.Replace(",", "."), txtPendingInvoicePayment.Text.Replace(",", "."));

            lblInfoReg.Text = string.Empty;
            FillSearch(1);

            StringBuilder sb = new StringBuilder();
            lblSearch.Text = "<br/>";

            if (txtInternalNumber.Text.Length > 0)
                sb.Append(string.Format(" Numero Interno: <b>{0}</b>", txtInternalNumber.Text));
            if (txtProcessNumber.Text.Length > 0)
                sb.Append(string.Format(" Numero Processo: <b>{0}</b>", txtProcessNumber.Text));
            if (txtCourt.Text.Length > 0)
                sb.Append(string.Format(" Tribunal: <b>{0}</b>", txtCourt.Text));
            if (txtCreditor.Text.Length > 0)
                sb.Append(string.Format(" Exequente: <b>{0}</b>", txtCreditor.Text));
            if (txtRepresentative.Text.Length > 0)
                sb.Append(string.Format(" Mandatário: <b>{0}</b>", txtRepresentative.Text));
            if (txtExecuted.Text.Length > 0)
                sb.Append(string.Format(" Executado: <b>{0}</b>", txtExecuted.Text));
            if (txtNDays.Text != "0")
                sb.Append(string.Format(" N.Dias: <b>{0}</b>", txtNDays.Text));
            if (cmbGroup.SelectedIndex > 0)
                sb.Append(string.Format(" Grupo: <b>{0}</b>", cmbGroup.SelectedItem.Text));
            if (txtLocalization.Text.Length > 0)
                sb.Append(string.Format(" Loc.: <b>{0}</b>", txtLocalization.Text));
            if (cmbUser.SelectedValue.Length > 0)
                sb.Append(string.Format(" Utilizador.: <b>{0}</b>", cmbUser.SelectedValue));
            if (txtDate1.Text.Length > 0)
                sb.Append(string.Format(" Data1: <b>{0}</b>", txtDate1.Text));
            if (txtDate2.Text.Length > 0)
                sb.Append(string.Format(" Data2: <b>{0}</b>", txtDate2.Text));

            if (txtProvision.Text != "0")
                sb.Append(string.Format(" Provisão: <b>{0}</b>", txtProvision.Text));
            if (txtPendingInvoicePayment.Text != "0")
                sb.Append(string.Format(" Ag.Pag.Fac.: <b>{0}</b>", txtPendingInvoicePayment.Text));

            lblSearch.Text += sb.ToString();

            txtCourt.Text = string.Empty;
            txtCreditor.Text = string.Empty;
            txtExecuted.Text = string.Empty;
            txtInternalNumber.Text = string.Empty;
            txtProcessNumber.Text = string.Empty;
            txtRepresentative.Text = string.Empty;
            txtLocalization.Text = string.Empty;
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("process.aspx?pr=" + gvResult.SelectedValue, true);
        }

        private void FillSearch(int thePostBack)
        {
            try
            {
                List<string> t = new List<string>();

                string[] field = lkbSearch.CommandArgument.Split('|');

                t.Add("'" + field[0] + "',");
                t.Add("'" + field[1] + "',");
                t.Add("'" + field[2] + "',");
                t.Add("'" + field[3] + "',");
                t.Add("'" + field[4] + "',");
                t.Add("'" + field[5] + "',");
                t.Add(txtNDays.Text + ",");
                t.Add("'" + field[6] + "',");
                t.Add("'" + field[7] + "',");
                t.Add(field[8] + ",");
                t.Add("'" + field[9] + "',");
                t.Add("'" + field[10] + "',");

                t.Add(field[11] + ",");
                t.Add(field[12] + ",");

                t.Add(lkbPrevious.CommandArgument + ",");
                t.Add((int.Parse(lkbNext.CommandArgument) + 1).ToString());

                gvResult.DataSource = DataBase.DataReader("exec uspSearch " + string.Join("", t.ToArray()) + "," + thePostBack);
                string[] key = new string[] { "ProcessId" };
                gvResult.DataKeyNames = key;
                gvResult.DataBind();
                Columns();

                if (gvResult.Rows.Count == 1)
                    if (Session["UserSetting"] != null && Session["UserSetting"].ToString().Split('|').GetValue(1).ToString() == "1")
                        Server.Transfer("Process.aspx?pr=" + gvResult.DataKeys[0][0], false);

                if (lblInfoReg.Text.Length == 0 && lkbPrevious.CommandArgument == "1")
                    lblInfoReg.Text = "Total Registos: <b>" + DataBase.Scalar("exec uspSearchCount " + string.Join("", t.ToArray())) + "</b>";

                lkbPrevious.Visible = true;
                lkbNext.Visible = true;

                if (gvResult.Rows.Count <= int.Parse(ConfigurationManager.AppSettings["Paging"]))
                    lkbNext.Visible = false;
                if (lkbPrevious.CommandArgument == "1")
                    lkbPrevious.Visible = false;
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        private void FillUsers()
        {
            DataTable dt = DataBase.DataTable("select au.UserName,au.UserId from aspnet_Users au left join aspnet_UsersInRoles uir on au.UserId=uir.UserId left join aspnet_roles ar on uir.RoleId=ar.RoleId where ar.RoleName='Administrator' or ar.RoleName='User' order by au.UserName");
            foreach (DataRow dr in dt.Rows)
                cmbUser.Items.Add(new ListItem(dr["UserName"].ToString(), dr["UserName"].ToString()));
            cmbUser.Items.Insert(0, new ListItem("Seleccione", ""));
        }
        private void FillGroup()
        {
            DataTable dt = DataBase.DataTable("select Name,LocalizationId from tb_Localization order by Name");
            foreach (DataRow dr in dt.Rows)
                cmbGroup.Items.Add(new ListItem(dr["Name"].ToString(), dr["LocalizationId"].ToString()));
            cmbGroup.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        private void Columns()
        {
            Parameter p = new Parameter();
            string[] param = p.GetInformation(2).Split('|');
            for (int i = 0; i < param.Length; i++)
                gvResult.Columns[i + 1].Visible = (param[i] == "1" ? true : false);
        }

        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrevious.CommandArgument = (int.Parse(lkbPrevious.CommandArgument) + int.Parse(ConfigurationManager.AppSettings["Paging"])).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + int.Parse(ConfigurationManager.AppSettings["Paging"])).ToString();
            FillSearch(1);
        }
        protected void lkbPrevious_Click(object sender, EventArgs e)
        {
            if (lkbPrevious.CommandArgument != "1")
            {
                lkbPrevious.CommandArgument = (int.Parse(lkbPrevious.CommandArgument) - int.Parse(ConfigurationManager.AppSettings["Paging"])).ToString();
                lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - int.Parse(ConfigurationManager.AppSettings["Paging"])).ToString();
                FillSearch(1);
            }
        }
    }
}
