using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

namespace Solarc.webapp.secure
{
    public partial class wucProcessDetails : System.Web.UI.UserControl
    {
        public int ProcessId
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                if (ProcessId > 0)
                {
                    FillPaymentAgreement();
                    FillProcessExtinction();
                    FillExtinctionCode();
                    FillArrangementsInPlace();
                    FillProcessState();
                    FillDBInfo();
                    FillUncollectabilityCertificate();

                    DataTable dt = DataBase.DataTable("exec uspMntValues " + ProcessId);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() != "0") cmbPaymentAgreement.SelectedValue = dt.Rows[0][0].ToString();
                        if (dt.Rows[0][1].ToString() != "0") cmbProcessExtinction.SelectedValue = dt.Rows[0][1].ToString();
                        if (dt.Rows[0][2].ToString() != "0") cmbExtinctionCode.SelectedValue = dt.Rows[0][2].ToString();
                        if (dt.Rows[0][3].ToString() != "0") cmbArrangementsInPlace.SelectedValue = dt.Rows[0][3].ToString();
                        if (dt.Rows[0][4].ToString() != "0") cmbInAttachment.SelectedValue = dt.Rows[0][4].ToString();
                        if (dt.Rows[0][5].ToString() != "0") cmbProcessState.SelectedValue = dt.Rows[0][5].ToString();
                        if (dt.Rows[0][6].ToString() != "0") cmbDBInfo.SelectedValue = dt.Rows[0][6].ToString();
                        if (dt.Rows[0][7].ToString() != "0") cmbUncollectabilityCertificate.SelectedValue = dt.Rows[0][7].ToString();

                        txtProvision.Text = dt.Rows[0][8].ToString();
                        txtProvisionReceptionDate.Text = dt.Rows[0][9].ToString().Length > 0 ? DateTime.Parse(dt.Rows[0][9].ToString()).ToString("dd-MM-yyyy") : "";
                        txtPendingInvoicePayment.Text = dt.Rows[0][10].ToString();
                        txtDiligenceLocation.Text = dt.Rows[0][11].ToString();
                        if (dt.Rows[0][12].ToString() != "0") cmbJudicialPhase.SelectedValue = dt.Rows[0][12].ToString();
                        txtPendingInvoicePaymentDate.Text = dt.Rows[0][13].ToString().Length > 0 ? DateTime.Parse(dt.Rows[0][13].ToString()).ToString("dd-MM-yyyy") : "";
                        txtCreditorReference.Text = dt.Rows[0][14].ToString();

                        txtAcceptDate.Text = dt.Rows[0][15].ToString().Length > 0 ? DateTime.Parse(dt.Rows[0][15].ToString()).ToString("dd-MM-yyyy") : "";
                        txtDuplicatesReceipt.Text = dt.Rows[0][16].ToString().Length > 0 ? DateTime.Parse(dt.Rows[0][16].ToString()).ToString("dd-MM-yyyy") : "";
                        txtJudgeObservation.Text = dt.Rows[0][17].ToString();
                        txtAlert.Text = dt.Rows[0]["Alert"].ToString();
                    }

                    FillDelegate();
                    FillGrid();
                }
            }
        }

        private void FillDelegate()
        {
            Delegate d = new Delegate();
            cmbDelegate.DataSource = d.GetAllDelegate();
            cmbDelegate.DataTextField = "Name";
            cmbDelegate.DataValueField = "DelegateId";
            cmbDelegate.DataBind();
        }
        private void FillPaymentAgreement()
        {
            cmbPaymentAgreement.DataSource = DataBase.DataTable("exec uspMntSearch 'PaymentAgreement',0,0,1");
            FillCmb(cmbPaymentAgreement);
            cmbPaymentAgreement.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillProcessExtinction()
        {
            cmbProcessExtinction.DataSource = DataBase.DataTable("exec uspMntSearch 'ProcessExtinction',0,0,1");
            FillCmb(cmbProcessExtinction);
            cmbProcessExtinction.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillExtinctionCode()
        {
            cmbExtinctionCode.DataSource = DataBase.DataTable("exec uspMntSearch 'ExtinctionCode',0,0,1");
            FillCmb(cmbExtinctionCode);
            cmbExtinctionCode.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillArrangementsInPlace()
        {
            cmbArrangementsInPlace.DataSource = DataBase.DataTable("exec uspMntSearch 'ArrangementsInPlace',0,0,1");
            FillCmb(cmbArrangementsInPlace);
            cmbArrangementsInPlace.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillProcessState()
        {
            cmbProcessState.DataSource = DataBase.DataTable("exec uspMntSearch 'ProcessState',0,0,1");
            FillCmb(cmbProcessState);
            cmbProcessState.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillDBInfo()
        {
            cmbDBInfo.DataSource = DataBase.DataTable("exec uspMntSearch 'DBInfo',0,0,1");
            FillCmb(cmbDBInfo);
            cmbDBInfo.Items.Insert(0, new ListItem("-", "0"));
        }
        private void FillUncollectabilityCertificate()
        {
            cmbUncollectabilityCertificate.DataSource = DataBase.DataTable("exec uspMntSearch 'UncollectabilityCertificate',0,0,1");
            FillCmb(cmbUncollectabilityCertificate);
            cmbUncollectabilityCertificate.Items.Insert(0, new ListItem("-", "0"));
        }

        private void FillCmb(DropDownList cmb)
        {
            try
            {
                cmb.DataTextField = "Name";
                cmb.DataValueField = "FieldId";
                cmb.DataBind();
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }

        public void SaveDetails()
        {
            try
            {
                DateTime dt = DateTime.Parse("01-01-1900"), dt2 = DateTime.Parse("01-01-1900"), dt3 = DateTime.Parse("01-01-1900"), dt4 = DateTime.Parse("01-01-1900");
                if (txtProvisionReceptionDate.Text.Length > 0 && !DateTime.TryParse(txtProvisionReceptionDate.Text, out dt))
                {
                    ltMsg.Text = "Erro: Data de recepção de Provisão em formato incorrecto";
                    return;
                }
                if (txtPendingInvoicePaymentDate.Text.Length > 0 && !DateTime.TryParse(txtPendingInvoicePaymentDate.Text, out dt2))
                {
                    ltMsg.Text = "Erro: Data de Pagamento da Factura em formato incorrecto";
                    return;
                }
                if (txtAcceptDate.Text.Length > 0 && !DateTime.TryParse(txtAcceptDate.Text, out dt3))
                {
                    ltMsg.Text = "Erro: Data Aceitação em formato incorrecto";
                    return;
                }
                if (txtDuplicatesReceipt.Text.Length > 0 && !DateTime.TryParse(txtDuplicatesReceipt.Text, out dt4))
                {
                    ltMsg.Text = "Erro: Data recepção de duplicados em formato incorrecto";
                    return;
                }

                DataBase.Deinup("exec uspMntUpdate " + ProcessId + "," +
                    cmbPaymentAgreement.SelectedValue + "," +
                    cmbProcessExtinction.SelectedValue + "," +
                    cmbExtinctionCode.SelectedValue + "," +
                    cmbArrangementsInPlace.SelectedValue + "," +
                    cmbInAttachment.SelectedValue + "," +
                    cmbProcessState.SelectedValue + "," +
                    cmbDBInfo.SelectedValue + "," +
                    cmbUncollectabilityCertificate.SelectedValue + "," +
                    (txtProvision.Text.Length > 0 ? txtProvision.Text.Replace(",", ".") : "0") + "," +
                    "'" + dt.ToString("MM-dd-yyyy") + "'," +
                    (txtPendingInvoicePayment.Text.Length > 0 ? txtPendingInvoicePayment.Text.Replace(",", ".") : "0") + ",'" +
                    txtDiligenceLocation.Text.Replace("'", string.Empty) + "'," +
                    cmbJudicialPhase.SelectedValue + "," +
                    "'" + dt2.ToString("MM-dd-yyyy") + "','" +
                    txtCreditorReference.Text.Replace("'", string.Empty) + "'," +
                    "'" + dt3.ToString("MM-dd-yyyy") + "'," +
                    "'" + dt4.ToString("MM-dd-yyyy") + "'," +
                    "'" + txtJudgeObservation.Text.Replace("'", string.Empty) + "',"
                    + (txtAlert.Text.Length == 0 ? "0" : txtAlert.Text));

                Process p = new Process();

                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                p.SetAlterUser(ProcessId.ToString(), pcInfo);

                ltMsg.Text = "Alterações Gravadas com sucesso! " + DateTime.Now;
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvResult.Enabled = false;
            txtObservation.Text = gvResult.Rows[gvResult.SelectedIndex].Cells[2].Text;
            imgBtAdd.Visible = false;
            imgBtSave.Visible = true;
        }
        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sb = new StringBuilder("");
            if (e.CommandName.ToLower().Equals("del"))
            {
                Delegate d = new Delegate();
                d.DeleteDelegate(ProcessId, int.Parse(gvResult.DataKeys[index][0].ToString()));

                FillGrid();
            }
        }

        public void FillGrid()
        {
            gvResult.DataSource = DataBase.DataTable("exec uspGetDelegateFromProcess " + ProcessId);
            string[] key = new string[] { "DelegateId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();
        }
        protected void imgBtAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ltMsg.Text = string.Empty;

            if (cmbDelegate.Items.Count > 0)
            {
                for (int i = 0; i < gvResult.Rows.Count; i++)
                {
                    if (gvResult.DataKeys[i][0].ToString() == cmbDelegate.SelectedValue)
                    {
                        ltMsg.Text = "Nao pode inserir 2 observações para o mesmo Delegado, clique em editar.";
                        UpdatePanel1.Update();
                        return;
                    }
                }
                DataBase.Deinup("exec uspDelegateProcessUpdate " + ProcessId + "," + cmbDelegate.SelectedValue + ",'" + txtObservation.Text.Replace("'", string.Empty).Replace(";", string.Empty) + "'");
                FillGrid();
                txtObservation.Text = string.Empty;

                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process p = new Process();
                p.SetAlterUser(ProcessId.ToString(), pcInfo);
                ltMsg.Text = "Alterado com sucesso " + DateTime.Now;
            }
            else
                ltMsg.Text = "Nao tem Delegados inseridos.";

            UpdatePanel1.Update();
        }
        protected void imgBtSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("exec uspDelegateProcessUpdate " + ProcessId + "," + gvResult.DataKeys[gvResult.SelectedIndex][0] + ",'" + txtObservation.Text.Replace("'", string.Empty).Replace(";", string.Empty) + "'");
            gvResult.Enabled = true;
            txtObservation.Text = string.Empty;
            imgBtAdd.Visible = true;
            imgBtSave.Visible = false;
            gvResult.SelectedIndex = -1;

            String ecn = System.Environment.MachineName;
            string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

            Process p = new Process();
            p.SetAlterUser(ProcessId.ToString(), pcInfo);
            ltMsg.Text = "Alterado com sucesso " + DateTime.Now;

            FillGrid();
        }
        protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.Cells[3].FindControl("imgBtDelete");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }
}
