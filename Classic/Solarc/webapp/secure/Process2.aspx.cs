﻿using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class Process2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMsg.Text = string.Empty;
            if (!IsPostBack)
            {
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);

                if (Request.QueryString["pr"] != null)
                {
                    cmbLocalization.DataSource = DataBase.DataTable("select Name,LocalizationId from tb_Localization order by Name");
                    cmbLocalization.DataTextField = "Name";
                    cmbLocalization.DataValueField = "LocalizationId";
                    cmbLocalization.DataBind();
                    cmbLocalization.Items.Insert(0, new ListItem("Seleccione", "0"));

                    // MODO VISUALIZA!
                    Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
                    lblInternalNumber.Text = p.InternalCode;
                    lblProcessNumber.Text = p.ProcessNumber;
                    lblEnforcement.Text = p.Enforcement;
                    lblValue.Text = string.Format("{0:0.00}", p.Value) + " €";
                    lblExesAe.Text = string.Format("{0:0.00}", p.ExesAe) + " €";
                    lblExecutionType.Text = p.ExecutionType;

                    lblAlterInfo.Text = p.AlterUserDate;

                    //  ### Tribunal
                    //Court c = new Court(int.Parse(Request.QueryString["pr"].ToString()));
                    lblCourt.Text = p.GetCourt().ToString();
                    imgBtCourtEditInfo.CommandArgument = p.CourtValue.Name;

                    lblCreditor.Text = p.GetCreditor().ToString();
                    lblExecuted.Text = p.GetExecuted().ToString();

                    lblRepresentative.Text = p.GetRepresentative().ToString();
                    lblObservation.Text = p.Observation;
                    lblLocalization.Text = cmbLocalization.Items.FindByValue(p.LocalizationId.ToString()).Text;
                    //lblLocalization.Text = p.Localization;
                    lblLocalizationDetail.Text = p.LocalizationDetail;

                    lblProvisionRequest1.Text = (p.Pr.ProvisionRequest1.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionRequest1.ToString("dd-MM-yyyy") : "-";
                    lblProvisionRequest2.Text = (p.Pr.ProvisionRequest2.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionRequest2.ToString("dd-MM-yyyy") : "-";
                    lblProvisionRequest3.Text = (p.Pr.ProvisionRequest3.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionRequest3.ToString("dd-MM-yyyy") : "-";

                    lblProvisionReinforcement1.Text = (p.Pr.ProvisionReinforcement1.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionReinforcement1.ToString("dd-MM-yyyy") : "-";
                    lblProvisionReinforcement2.Text = (p.Pr.ProvisionReinforcement2.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionReinforcement2.ToString("dd-MM-yyyy") : "-";
                    lblProvisionReinforcement3.Text = (p.Pr.ProvisionReinforcement3.ToString("dd-MM-yyyy") != "01-01-1900") ? p.Pr.ProvisionReinforcement3.ToString("dd-MM-yyyy") : "-";

                    //  ### ATTACHMENT
                    DataSet ds = DataBase.DataSet("select te.ExecutedId,te.Name from tb_Executed te left join tb_ProcessExecuted tpe on te.ExecutedId=tpe.ExecutedId where tpe.ProcessId=" + Request.QueryString["pr"].ToString() + " order by te.Name");
                    cmbAttachment.DataSource = ds;
                    cmbAttachment.DataTextField = "Name";
                    cmbAttachment.DataValueField = "ExecutedId";
                    cmbAttachment.DataBind();

                    //  ### EMPLOYER
                    cmbEmployerExecuted.DataSource = ds;
                    cmbEmployerExecuted.DataTextField = "Name";
                    cmbEmployerExecuted.DataValueField = "ExecutedId";
                    cmbEmployerExecuted.DataBind();

                    //  ### SEARCH
                    FillSearch();
                    cmbSearchExecuted.DataSource = ds;
                    cmbSearchExecuted.DataTextField = "Name";
                    cmbSearchExecuted.DataValueField = "ExecutedId";
                    cmbSearchExecuted.DataBind();

                    lblEmployer.Text = p.GetExecutedEmployer().ToString();

                    FillGridAttachment();

                    Parameter param = new Parameter();
                    if (param.GetValue(1) == "1")
                        pRepresentativeInformation.Visible = true;
                }
            }
            /*
            if (Request.QueryString["pr"] != null)
            {
                int ProcessID = int.Parse(Request.QueryString["pr"]);

                wucProcessFiles1.ProcessId = ProcessID;
                wucProcessDetails1.ProcessId = ProcessID;
                if (pRepresentativeInformation.Visible == true)
                {
                    wucRepresentativeInformation1.ProcessId = ProcessID;
                    wucRepresentativeInformation1.InternalNumber = lblInternalNumber.Text;
                    wucRepresentativeInformation1.ProcessNumber = lblProcessNumber.Text;

                    wucPEPayment1.ProcessId = ProcessID;
                }
            }
         
             */
        }

        //  ### COURT
        protected void imgBtCourtCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtCourtInsert.Visible = true;
            imgBtCourtEditInfo.Visible = true;
            imgBtCourtProcessInsert.Visible = true;
            txtCourtName.Enabled = true;
            panCourtEditInfo.Visible = false;
        }
        protected void imgBtCourtEditSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //  actualiza/insere campos tribunal
            DataBase.Deinup("exec uspCourtUpdate '" + txtCourtName.Text + "','" + txtCourtAddress.Text + "','" + txtCourtPhone.Text + "','" + txtCourtFax.Text + "','" + txtCourtEmail.Text + "','" + txtCourtJudicialDistrict.Text + "','" + Membership.GetUser().ProviderUserKey + "',0");
            Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));

            if (txtCourtSection.Text.Length > 0)
                p.SetSection(txtCourtSection.Text, int.Parse(Request.QueryString["pr"].ToString()));

            String ecn = System.Environment.MachineName;
            string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

            p.SetAlterUser(Request.QueryString["pr"].ToString(), pcInfo);

            lblCourt.Text = p.GetCourt().ToString();

            imgBtCourtInsert.Visible = true;
            imgBtCourtEditInfo.Visible = true;
            imgBtCourtProcessInsert.Visible = true;
            txtCourtName.Enabled = true;
            panCourtEditInfo.Visible = false;
        }
        protected void imgBtCourtInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtCourtName.Text.Replace("'", string.Empty).Length > 0)
            {
                txtCourtAddress.Text = string.Empty;
                txtCourtPhone.Text = string.Empty;
                txtCourtFax.Text = string.Empty;
                txtCourtEmail.Text = string.Empty;
                txtCourtSection.Text = string.Empty;

                imgBtCourtInsert.Visible = false;
                imgBtCourtEditInfo.Visible = false;
                imgBtCourtProcessInsert.Visible = false;
                txtCourtName.Enabled = false;
                panCourtEditInfo.Visible = true;
            }
        }
        protected void imgBtCourtProcessInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtCourtName.Text.Replace("'", string.Empty).Length > 0)
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process p = new Process();
                p.SetCourt(txtCourtName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()));
                p.SetAlterUser(Request.QueryString["pr"].ToString(), pcInfo);

                imgBtCourtEditInfo.CommandArgument = txtCourtName.Text.Replace("'", string.Empty);
            }
        }
        protected void imgBtCourtEditInfo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtCourtName.Text.Length > 0)
            {

                txtCourtAddress.Text = string.Empty;
                txtCourtPhone.Text = string.Empty;
                txtCourtFax.Text = string.Empty;
                txtCourtEmail.Text = string.Empty;
                txtCourtSection.Text = string.Empty;

                //carrega dados do tribunal
                DataSet ds = DataBase.DataSet("select tc.address,tc.phone,tc.fax,tc.email,ts.Name as section,tc.name from tb_Court tc left join tb_Process tp on tc.CourtId=tp.CourtId left join tb_Section ts on tp.SectionId=ts.SectionId where tc.Name='" + txtCourtName.Text + "' and tp.processid=" + Request.QueryString["pr"].ToString());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtCourtName.Enabled = false;
                    txtCourtName.Text = ds.Tables[0].Rows[0][5].ToString();

                    txtCourtAddress.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtCourtPhone.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtCourtFax.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtCourtEmail.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtCourtSection.Text = ds.Tables[0].Rows[0][4].ToString();
                    ds.Clear();

                    imgBtCourtInsert.Visible = false;
                    imgBtCourtEditInfo.Visible = false;
                    imgBtCourtProcessInsert.Visible = false;
                    txtCourtName.Enabled = false;
                    panCourtEditInfo.Visible = true;
                }
            }
            else
                ltMsg.Text = "Erro: Tem de escrever o nome de um tribunal primeiro.";
        }

        //  ### CREDITOR
        protected void cmbCreditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCreditor.Items.Count > 0)
                txtCreditorName.Text = cmbCreditor.SelectedItem.Text;
        }
        protected void imgBtCreditorDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (cmbCreditor.Items.Count > 0)
            {
                Process p = new Process();
                p.DeleteCreditor(int.Parse(cmbCreditor.SelectedValue), int.Parse(Request.QueryString["pr"].ToString()));
            }
        }

        protected void imgBtCreditorInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtCreditorName.Text.Length > 0)
            {
                imgBtCreditorEditInfo.Visible = false;
                imgBtCreditorInsert.Visible = false;
                imgBtCreditorProcessInsert.Visible = false;
                panCreditorEditInfo.Visible = true;
                txtCreditorName.Enabled = false;
            }
        }
        protected void imgBtCreditorProcessInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtCreditorName.Text.Replace("'", string.Empty).Length > 0)
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process p = new Process();
                p.SetCreditor(txtCreditorName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()), pcInfo);
                //lblCreditor.Text = p.GetCreditor().ToString();
            }
        }
        protected void imgBtCreditorEditInfo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtCreditorAddress.Text = string.Empty;
            txtCreditorPhone.Text = string.Empty;
            txtCreditorFax.Text = string.Empty;
            txtCreditorEmail.Text = string.Empty;
            txtCreditorIdentityCard.Text = string.Empty;
            txtCreditorNifNipl.Text = string.Empty;
            txtCreditorNifs.Text = string.Empty;
            txtCreditorBornDate.Text = string.Empty;

            DataSet ds = DataBase.DataSet("select address,phone,fax,email,IdentityCard,NifNipl,Nifs,BornDate from tb_Creditor where name='" + txtCreditorName.Text.Replace("'", string.Empty) + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtCreditorAddress.Text = ds.Tables[0].Rows[0][0].ToString();
                txtCreditorPhone.Text = ds.Tables[0].Rows[0][1].ToString();
                txtCreditorFax.Text = ds.Tables[0].Rows[0][2].ToString();
                txtCreditorEmail.Text = ds.Tables[0].Rows[0][3].ToString();

                txtCreditorIdentityCard.Text = ds.Tables[0].Rows[0][4].ToString();
                txtCreditorNifNipl.Text = ds.Tables[0].Rows[0][5].ToString();
                txtCreditorNifs.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCreditorBornDate.Text = ds.Tables[0].Rows[0][7].ToString();
            }
            imgBtCreditorEditInfo.Visible = false;
            imgBtCreditorInsert.Visible = false;
            imgBtCreditorProcessInsert.Visible = false;
            panCreditorEditInfo.Visible = true;
            txtCreditorName.Enabled = false;
        }

        protected void imgBtCreditorEditSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            //      I/O
            // recarrega Creditor
            DataBase.Deinup("exec uspCreditorUpdate '" + txtCreditorName.Text + "','" + txtCreditorAddress.Text + "','" + txtCreditorPhone.Text + "','" + txtCreditorMPhone.Text + "','" + txtCreditorFax.Text + "','" + txtCreditorEmail.Text + "','" + Membership.GetUser().ProviderUserKey +
                "','" + txtCreditorIdentityCard.Text + "','" + txtCreditorNifNipl.Text + "','" + txtCreditorNifs.Text + "','" + DateTime.Parse(txtCreditorBornDate.Text.Length > 0 ? txtCreditorBornDate.Text : "01-01-1900").ToString("yyyy-MM-dd") + "',0");
            Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
            lblCreditor.Text = p.GetCreditor().ToString();

            imgBtCreditorEditInfo.Visible = true;
            imgBtCreditorInsert.Visible = true;
            imgBtCreditorProcessInsert.Visible = true;
            panCreditorEditInfo.Visible = false;
            txtCreditorName.Enabled = true;
        }
        protected void imgBtCreditorCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtCreditorEditInfo.Visible = true;
            imgBtCreditorInsert.Visible = true;
            imgBtCreditorProcessInsert.Visible = true;
            panCreditorEditInfo.Visible = false;
            txtCreditorName.Enabled = true;
        }

        //  ### REPRESENTATIVE
        protected void imgBtRepresentativeCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtRepresentativeInsert.Visible = true;
            imgBtRepresentativeEditInfo.Visible = true;
            imgBtRepresentativeProcessInsert.Visible = true;
            panRepresentativeEditInfo.Visible = false;
            txtRepresentativeName.Enabled = true;
        }
        protected void imgBtRepresentativeEditSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("exec uspRepresentativeUpdate '" + txtRepresentativeName.Text + "','" + txtRepresentativeAddress.Text + "','" + txtRepresentativePhone.Text + "','" + txtRepresentativeFax.Text + "','" + txtRepresentativeEmail.Text + "','" + Membership.GetUser().ProviderUserKey + "'");
            Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
            lblCreditor.Text = p.GetRepresentative().ToString();

            imgBtRepresentativeInsert.Visible = true;
            imgBtRepresentativeEditInfo.Visible = true;
            imgBtRepresentativeProcessInsert.Visible = true;
            panRepresentativeEditInfo.Visible = false;
            txtRepresentativeName.Enabled = true;
        }
        protected void imgBtRepresentativeInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtRepresentativeName.Text.Length > 0)
            {
                imgBtRepresentativeInsert.Visible = false;
                imgBtRepresentativeEditInfo.Visible = false;
                imgBtRepresentativeProcessInsert.Visible = false;
                panRepresentativeEditInfo.Visible = true;
                txtRepresentativeName.Enabled = false;
            }
        }
        protected void imgBtRepresentativeProcessInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtRepresentativeName.Text.Replace("'", string.Empty).Length > 0)
            {
                Process p = new Process();
                p.SetRepresentative(txtRepresentativeName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()));
            }
        }
        protected void imgBtRepresentativeEditInfo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtRepresentativeAddress.Text = string.Empty;
            txtRepresentativePhone.Text = string.Empty;
            txtRepresentativeFax.Text = string.Empty;
            txtRepresentativeEmail.Text = string.Empty;

            DataSet ds = DataBase.DataSet("select address,phone,fax,email from tb_Representative where name='" + txtRepresentativeName.Text.Replace("'", string.Empty) + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtRepresentativeAddress.Text = ds.Tables[0].Rows[0][0].ToString();
                txtRepresentativePhone.Text = ds.Tables[0].Rows[0][1].ToString();
                txtRepresentativeFax.Text = ds.Tables[0].Rows[0][2].ToString();
                txtRepresentativeEmail.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            imgBtRepresentativeInsert.Visible = false;
            imgBtRepresentativeEditInfo.Visible = false;
            imgBtRepresentativeProcessInsert.Visible = false;
            panRepresentativeEditInfo.Visible = true;
            txtRepresentativeName.Enabled = false;
        }


        //  ### EXECUTED
        protected void cmbExecuted_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExecuted.Items.Count > 0)
                txtExecutedName.Text = cmbExecuted.SelectedItem.Text;
        }
        protected void imgBtExecutedDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (cmbExecuted.Items.Count > 0)
            {
                Process p = new Process();
                p.DeleteExecuted(int.Parse(cmbExecuted.SelectedValue), int.Parse(Request.QueryString["pr"].ToString()));
            }
        }
        protected void imgBtExecutedCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtExecutedEdit.Visible = true;
            imgBtExecutedInsert.Visible = true;
            imgBtExecutedProcessInsert.Visible = true;
            imgBtExecutedExtraAddress.Visible = true;

            panExecutedEditInfo.Visible = false;
            txtExecutedName.Enabled = true;
        }
        protected void imgBtExecutedEditSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("exec uspExecutedUpdate '" + txtExecutedName.Text + "','" + txtExecutedAddress.Text + "','" + txtExecutedPhone.Text + "','','" +
                txtExecutedFax.Text + "','" + txtExecutedEmail.Text + "','" + Membership.GetUser().ProviderUserKey +
                "','" + txtExecutedIdentityCard.Text + "','" + txtExecutedNifNipl.Text + "','" + txtExecutedNifs.Text + "','" + DateTime.Parse(txtExecutedBornDate.Text.Length > 0 ? txtExecutedBornDate.Text : "01-01-1900").ToString("yyyy-MM-dd") + "',0");
            Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
            lblExecuted.Text = p.GetExecuted().ToString();

            imgBtExecutedEdit.Visible = true;
            imgBtExecutedInsert.Visible = true;
            imgBtExecutedProcessInsert.Visible = true;
            imgBtExecutedExtraAddress.Visible = true;

            panExecutedEditInfo.Visible = false;
            txtExecutedName.Enabled = true;
        }
        protected void imgBtExecutedEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtExecutedAddress.Text = string.Empty;
            txtExecutedEmail.Text = string.Empty;
            txtExecutedFax.Text = string.Empty;
            txtExecutedPhone.Text = string.Empty;

            DataSet ds = DataBase.DataSet("select address,phone,fax,email,IdentityCard,NifNipl,Nifs,BornDate from tb_Executed where name='" + txtExecutedName.Text.Replace("'", string.Empty) + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtExecutedAddress.Text = ds.Tables[0].Rows[0][0].ToString();
                txtExecutedPhone.Text = ds.Tables[0].Rows[0][1].ToString();
                txtExecutedFax.Text = ds.Tables[0].Rows[0][2].ToString();
                txtExecutedEmail.Text = ds.Tables[0].Rows[0][3].ToString();

                txtExecutedIdentityCard.Text = ds.Tables[0].Rows[0][4].ToString();
                txtExecutedNifNipl.Text = ds.Tables[0].Rows[0][5].ToString();
                txtExecutedNifs.Text = ds.Tables[0].Rows[0][6].ToString();
                txtExecutedBornDate.Text = ds.Tables[0].Rows[0][7].ToString();
            }

            imgBtExecutedEdit.Visible = false;
            imgBtExecutedInsert.Visible = false;
            imgBtExecutedProcessInsert.Visible = false;
            imgBtExecutedExtraAddress.Visible = false;

            panExecutedEditInfo.Visible = true;
            txtExecutedName.Enabled = false;
        }
        protected void imgBtExecutedProcessInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            String ecn = System.Environment.MachineName;
            string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

            Process p = new Process();
            p.SetExecuted(txtExecutedName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()), pcInfo);
            //lblExecuted.Text = p.GetExecuted).ToString();
        }
        protected void imgBtExecutedInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtExecutedName.Text.Length > 0)
            {
                imgBtExecutedEdit.Visible = false;
                imgBtExecutedInsert.Visible = false;
                imgBtExecutedProcessInsert.Visible = false;
                imgBtExecutedExtraAddress.Visible = false;
                panExecutedEditInfo.Visible = true;
                txtExecutedName.Enabled = false;
            }
        }
        protected void imgBtExecutedExtraAddress_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (cmbExecuted.Items.Count > 0 && txtExecutedName.Text.Replace("'", string.Empty).Length > 0)
                DataBase.Deinup("exec uspProcessExtraAddress '" + txtExecutedName.Text.Replace("'", string.Empty) + "'," + cmbExecuted.SelectedValue + "," + Request.QueryString["pr"].ToString());
        }


        //  ### EMPLOYER
        protected void imgBtEmployerInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (cmbEmployerExecuted.Items.Count > 0)
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
                p.SetEmployer(txtEmployerName.Text, int.Parse(cmbEmployerExecuted.SelectedValue), int.Parse(Request.QueryString["pr"].ToString()), pcInfo);
                lblEmployer.Text = p.GetExecutedEmployer().ToString();
            }
        }
        protected void imgBtEmployerEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtEmployerAddress.Text = string.Empty;
            txtEmployerEmail.Text = string.Empty;
            txtEmployerFax.Text = string.Empty;
            txtEmployerPhone.Text = string.Empty;

            DataSet ds = DataBase.DataSet("select address,phone,fax,email from tb_Employer where name='" + txtEmployerName.Text.Replace("'", string.Empty) + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtEmployerAddress.Text = ds.Tables[0].Rows[0][0].ToString();
                txtEmployerPhone.Text = ds.Tables[0].Rows[0][1].ToString();
                txtEmployerFax.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmployerEmail.Text = ds.Tables[0].Rows[0][3].ToString();
            }

            imgBtEmployerInsert.Visible = false;
            imgBtEmployerEdit.Visible = false;

            panEmployerEdit.Visible = true;
            txtEmployerName.Enabled = false;
            cmbEmployerExecuted.Enabled = false;
        }
        protected void imgBtEmployerCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtEmployerInsert.Visible = true;
            imgBtEmployerEdit.Visible = true;

            panEmployerEdit.Visible = false;
            txtEmployerName.Enabled = true;
            cmbEmployerExecuted.Enabled = true;
        }
        protected void imgBtEmployerSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("exec uspEmployerUpdate '" + txtEmployerName.Text + "','" + txtEmployerAddress.Text + "','" + txtEmployerPhone.Text + "','" + txtEmployerFax.Text + "','" + txtEmployerEmail.Text + "','" + Membership.GetUser().ProviderUserKey + "'");
            Process p = new Process(int.Parse(Request.QueryString["pr"].ToString()));
            //lblEmployer.Text = "";

            imgBtEmployerInsert.Visible = true;
            imgBtEmployerEdit.Visible = true;

            panEmployerEdit.Visible = false;
            txtEmployerName.Enabled = true;
            cmbEmployerExecuted.Enabled = true;
        }


        //  ### -------------------------------------------------------------
        protected void imgBtSaveProcessIdentification_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            String ecn = System.Environment.MachineName;
            string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

            Process p = new Process();
            if (txtEnforcement.Text.Length > 0)
            {
                p.SetEnforcement(txtEnforcement.Text, int.Parse(Request.QueryString["pr"].ToString()));
                lblEnforcement.Text = txtEnforcement.Text;
            }

            if (txtCourtName.Text.Length > 0)
                p.SetCourt(txtCourtName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()));

            if (txtRepresentativeName.Text.Length > 0)
                p.SetRepresentative(txtRepresentativeName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()));

            if (txtProcessNumber.Text != lblProcessNumber.Text && txtProcessNumber.Text.Replace("'", string.Empty).Length > 0)
                p.SetProcessNumber(txtProcessNumber.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()));

            if (txtValue.Text != lblValue.Text.Substring(0, lblValue.Text.Length - 1).Trim())
            {
                p.SetValue(double.Parse(txtValue.Text.Replace('.', ',')), int.Parse(Request.QueryString["pr"].ToString()));
                lblValue.Text = txtValue.Text;
            }
            if (txtExesAe.Text != lblExesAe.Text.Substring(0, lblExesAe.Text.Length - 1).Trim())
            {
                p.SetExesAe(double.Parse(txtExesAe.Text), int.Parse(Request.QueryString["pr"].ToString()));
                lblExesAe.Text = txtExesAe.Text;
            }

            if (cmbLocalization.SelectedItem.Text != lblLocalization.Text)
                p.SetLocalization(int.Parse(cmbLocalization.SelectedValue), int.Parse(Request.QueryString["pr"].ToString()));

            if (txtValueToRecover.Text != lblValueToRecover.Text)
                p.SetValueToRecover(int.Parse(Request.QueryString["pr"].ToString()), double.Parse(lblValueToRecover.Text), pcInfo);

            if (txtLocalizationDetail.Text != lblLocalizationDetail.Text)
                p.SetLocalizationDetail(txtLocalizationDetail.Text, int.Parse(Request.QueryString["pr"].ToString()));

            if (cmbExecutionType.SelectedItem.Text != lblExecutionType.Text)
                p.SetExecutionType(cmbExecutionType.SelectedItem.Text, int.Parse(Request.QueryString["pr"].ToString()));

            DateTime dt;
            ProvisionRequest pr = new ProvisionRequest();
            if (DateTime.TryParse(txtProvisionRequest1.Text, out dt)) pr.ProvisionRequest1 = dt;
            if (DateTime.TryParse(txtProvisionRequest2.Text, out dt)) pr.ProvisionRequest2 = dt;
            if (DateTime.TryParse(txtProvisionRequest3.Text, out dt)) pr.ProvisionRequest3 = dt;

            if (DateTime.TryParse(txtProvisionReinforcement1.Text, out dt)) pr.ProvisionReinforcement1 = dt;
            if (DateTime.TryParse(txtProvisionReinforcement2.Text, out dt)) pr.ProvisionReinforcement2 = dt;
            if (DateTime.TryParse(txtProvisionReinforcement3.Text, out dt)) pr.ProvisionReinforcement3 = dt;

            p.SetProvisionRequest(int.Parse(Request.QueryString["pr"].ToString()), pr);

            panProcessNumberEdit.Visible = false;
            panEnforcement.Visible = false;
            panCourtEdit.Visible = false;
            panCreditorEdit.Visible = false;
            panExecutedEdit.Visible = false;
            panExesAeEdit.Visible = false;
            panRepresentativeEdit.Visible = false;
            panValueEdit.Visible = false;
            pExecutionType.Visible = false;

            imgBtSaveProcessIdentification.Visible = false;
            imgBtEditProcessIdentification.Visible = true;
            panLocalization.Visible = false;

            p.SetAlterUser(Request.QueryString["pr"].ToString(), pcInfo);

            Response.Redirect("process.aspx?pr=" + Request.QueryString["pr"].ToString(), true);
        }
        protected void imgBtEditProcessIdentification_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            panProcessNumberEdit.Visible = true;
            panEnforcement.Visible = true;
            panCourtEdit.Visible = true;
            panCreditorEdit.Visible = true;
            panExecutedEdit.Visible = true;
            panExesAeEdit.Visible = true;
            panRepresentativeEdit.Visible = true;
            panValueEdit.Visible = true;
            pExecutionType.Visible = true;
            pnProvisionRequestEdit.Visible = true;
            panValueToRecoverEdit.Visible = true;

            imgBtSaveProcessIdentification.Visible = true;
            imgBtEditProcessIdentification.Visible = false;
            panLocalization.Visible = true;

            //  ### SET FIELDS
            txtProcessNumber.Text = lblProcessNumber.Text;
            txtCourtName.Text = imgBtCourtEditInfo.CommandArgument;

            if (lblLocalization.Text.Length > 0)
                cmbLocalization.SelectedValue = cmbLocalization.Items.FindByText(lblLocalization.Text).Value;

            txtLocalizationDetail.Text = lblLocalizationDetail.Text;
            txtValueToRecover.Text = lblValueToRecover.Text;

            if (lblEnforcement.Text.Length > 0)
                txtEnforcement.Text = lblEnforcement.Text;
            if (lblValue.Text.Length > 2)
                txtValue.Text = lblValue.Text.Substring(0, lblValue.Text.Length - 2);
            if (lblExesAe.Text.Length > 2)
                txtExesAe.Text = lblExesAe.Text.Substring(0, lblExesAe.Text.Length - 2);
            if (lblExecutionType.Text.Length > 2)
            {
                for (int i = 0; i < cmbExecutionType.Items.Count; i++)
                    if (cmbExecutionType.Items[i].Text == lblExecutionType.Text)
                        cmbExecutionType.SelectedIndex = i;
            }

            DataSet ds = DataBase.DataSet("select te.ExecutedId,te.Name from tb_Executed te left join tb_ProcessExecuted tpe on te.ExecutedId=tpe.ExecutedId where tpe.ProcessId=" + Request.QueryString["pr"].ToString() + " order by te.Name");
            cmbExecuted.DataSource = ds;
            cmbExecuted.DataTextField = "Name";
            cmbExecuted.DataValueField = "ExecutedId";
            cmbExecuted.DataBind();

            if (cmbExecuted.Items.Count > 0)
                txtExecutedName.Text = cmbExecuted.SelectedItem.Text;

            cmbCreditor.DataSource = DataBase.DataReader("select te.CreditorId,te.Name from tb_Creditor te left join tb_ProcessCreditor tpe on te.CreditorId=tpe.CreditorId where tpe.ProcessId=" + Request.QueryString["pr"].ToString() + " order by te.Name");
            cmbCreditor.DataTextField = "Name";
            cmbCreditor.DataValueField = "CreditorId";
            cmbCreditor.DataBind();

            if (cmbCreditor.Items.Count > 0)
                txtCreditorName.Text = cmbCreditor.SelectedItem.Text;

            if (lblProvisionRequest1.Text != "-") txtProvisionRequest1.Text = lblProvisionRequest1.Text;
            if (lblProvisionRequest2.Text != "-") txtProvisionRequest2.Text = lblProvisionRequest2.Text;
            if (lblProvisionRequest3.Text != "-") txtProvisionRequest3.Text = lblProvisionRequest3.Text;

            if (lblProvisionReinforcement1.Text != "-") txtProvisionReinforcement1.Text = lblProvisionReinforcement1.Text;
            if (lblProvisionReinforcement2.Text != "-") txtProvisionReinforcement2.Text = lblProvisionReinforcement2.Text;
            if (lblProvisionReinforcement3.Text != "-") txtProvisionReinforcement3.Text = lblProvisionReinforcement3.Text;
        }

        protected void imgBtChangeInternalNumber_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            txtInternalNumber.Text = lblInternalNumber.Text;
            txtInternalNumber.Visible = true;
            lblInternalNumber.Visible = false;
            imgBtChangeInternalNumber.Visible = false;
            imgBtSaveInternalNumber.Visible = true;
        }
        protected void imgBtSaveInternalNumber_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                txtInternalNumber.Visible = false;
                lblInternalNumber.Visible = true;
                imgBtChangeInternalNumber.Visible = true;
                imgBtSaveInternalNumber.Visible = false;
                Process p = new Process();
                p.SetInternalNumber(txtInternalNumber.Text, int.Parse(Request.QueryString["pr"].ToString()), pcInfo);

                Server.Transfer("Process.aspx?pr=" + Request.QueryString["pr"].ToString(), false);
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
                Email mail = new Email();
                mail.SendError(ex.Message);
            }
        }
        protected void imgBtEditProcessObservation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            imgBtEditProcessObservation.Visible = false;
            imgBtSaveProcessObservation.Visible = true;
            txtObservation.Visible = true;

            txtObservation.Text = lblObservation.Text;
        }
        protected void imgBtSaveProcessObservation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Request.QueryString["pr"].Length > 0)
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                DataBase.Deinup("update tb_Process set Observation='" + txtObservation.Text.Replace("'", string.Empty) + "' where ProcessId=" + Request.QueryString["pr"]);
                lblObservation.Text = txtObservation.Text.Replace("'", string.Empty);
                imgBtEditProcessObservation.Visible = true;
                imgBtSaveProcessObservation.Visible = false;
                txtObservation.Visible = false;
                Process p = new Process();
                p.SetAlterUser(Request.QueryString["pr"], pcInfo);
            }
        }

        //  ### ATTACHMENT
        private void FillGridAttachment()
        {
            gvResultAttachment.DataSource = DataBase.DataReader("select AttachmentId,ExecutedId,value,ExecutedName,AttachmentName from vwProcessAttachment where ProcessId=" + Request.QueryString["pr"] + " order by 4,5");
            string[] key = new string[] { "AttachmentId", "ExecutedId", "Value" };
            gvResultAttachment.DataKeyNames = key;
            gvResultAttachment.DataBind();
        }
        protected void gvResultAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToLower().Equals("delete"))
            {
                DataBase.Deinup("delete from tb_ProcessAttachment where AttachmentId=" + gvResultAttachment.DataKeys[index][0] + " and ProcessId=" + Request.QueryString["pr"] + " and ExecutedId=" + gvResultAttachment.DataKeys[index][1]);
            }
            else if (e.CommandName.ToLower().Equals("check"))
            {
                DataBase.Deinup("update tb_ProcessAttachment set Value=" + (gvResultAttachment.DataKeys[index][2].ToString() == "1" ? "0" : "1") + " where AttachmentId=" + gvResultAttachment.DataKeys[index][0] + " and ProcessId=" + Request.QueryString["pr"] + " and ExecutedId=" + gvResultAttachment.DataKeys[index][1]);
            }
            Server.Transfer("Process.aspx?pr=" + Request.QueryString["pr"]);
        }
        protected void gvResultAttachment_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.Cells[2].FindControl("imgBtCheck");
                lkb.CommandArgument = e.Row.RowIndex.ToString();

                lkb = (ImageButton)e.Row.Cells[3].FindControl("imgBtDelete");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResultAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBt = (ImageButton)e.Row.FindControl("imgBtCheck");
                if (gvResultAttachment.DataKeys[e.Row.RowIndex][2].ToString() == "1")
                    imgBt.ImageUrl = "~/images/webapp/icons/checked.png";
                else
                    imgBt.ImageUrl = "~/images/webapp/icons/unchecked.png";
            }
        }
        protected void imgBtAttachmentAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (cmbAttachment.Items.Count > 0)
            {
                DataBase.Deinup("exec uspProcessAttachment '" + txtAttachment.Text.Replace("'", string.Empty) + "'," + cmbAttachment.SelectedValue + "," + Request.QueryString["pr"].ToString());
                FillGridAttachment();
            }
        }
        protected void imgBtAttachmentInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (txtAttachment.Text.Replace("'", string.Empty).Length > 0)
                DataBase.Deinup("exec uspAttachment '" + txtAttachment.Text.Replace("'", string.Empty) + "','" + Membership.GetUser().ProviderUserKey + "'");
        }

        //  ### SEARCH
        private void FillSearch()
        {
            gvResultSearch.DataSource = DataBase.DataReader("select * from vwProcessSearch where ProcessId=" + Request.QueryString["pr"]);
            string[] key = new string[] { "SearchId", "ExecutedId", "Value" };
            gvResultSearch.DataKeyNames = key;
            gvResultSearch.DataBind();
        }
        protected void imgBtSearchInsert_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DateTime dt = new DateTime();
            if (txtSearchDate.Text.Length > 0 && !DateTime.TryParse(txtSearchDate.Text, out dt))
            {
                ltMsg.Text = "Erro: A data que inseriu nas buscas, esta num formato incorrecto.";
                return;
            }
            if (cmbSearchExecuted.Items.Count > 0 && txtSearchName.Text.Replace("'", string.Empty).Length > 0)
            {
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process p = new Process();
                p.SetSearch(txtSearchName.Text.Replace("'", string.Empty), int.Parse(Request.QueryString["pr"].ToString()), int.Parse(cmbSearchExecuted.SelectedValue), dt, txtSearchObservation.Text, pcInfo);
                FillSearch();
            }
        }

        protected void gvResultSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBt = (ImageButton)e.Row.FindControl("imgBtCheck");
                if (gvResultSearch.DataKeys[e.Row.RowIndex][2].ToString() == "1")
                    imgBt.ImageUrl = "~/images/webapp/icons/checked.png";
                else
                    imgBt.ImageUrl = "~/images/webapp/icons/unchecked.png";
            }
        }
        protected void gvResultSearch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.Cells[4].FindControl("imgBtCheck");
                lkb.CommandArgument = e.Row.RowIndex.ToString();

                lkb = (ImageButton)e.Row.Cells[5].FindControl("imgBtDelete");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResultSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.ToLower().Equals("delete"))
            {
                DataBase.Deinup("delete from tb_ProcessSearch where SearchId=" + gvResultSearch.DataKeys[index][0] + " and ProcessId=" + Request.QueryString["pr"] + " and ExecutedId=" + gvResultSearch.DataKeys[index][1]);
            }
            else if (e.CommandName.ToLower().Equals("check"))
            {
                if (gvResultSearch.DataKeys[index][2].ToString() == "1")
                    DataBase.Deinup("update tb_ProcessSearch set Value=0 where SearchId=" + gvResultSearch.DataKeys[index][0] + " and ProcessId=" + Request.QueryString["pr"] + " and ExecutedId=" + gvResultSearch.DataKeys[index][1]);
                else
                    DataBase.Deinup("update tb_ProcessSearch set Value=1 where SearchId=" + gvResultSearch.DataKeys[index][0] + " and ProcessId=" + Request.QueryString["pr"] + " and ExecutedId=" + gvResultSearch.DataKeys[index][1]);
            }
            Server.Transfer("Process.aspx?pr=" + Request.QueryString["pr"]);
        }

        protected void imgBtSaveDetails_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            wucProcessDetails1.SaveDetails();
        }







        protected void lkbInsertNewProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.InternalCode = txtInternalNumber.Text;
                p.ProcessNumber = txtProcessNumber.Text;

                // validar se o processo ja existe!!
                string val = p.Insert();
                Response.Redirect("process.aspx?pr=" + val);
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }

    }
}
