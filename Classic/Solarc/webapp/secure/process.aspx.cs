using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class process : System.Web.UI.Page
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
            if (Request.QueryString["pr"] != null)
            {
                int ProcessID = int.Parse(Request.QueryString["pr"]);

                wucProcessFiles1.ProcessId = ProcessID;
                ProcessId = ProcessID;
                FillPDetail();

                if (pRepresentativeInformation.Visible == true)
                {
                    FillGridRepresentative();

                    //wucRepresentativeInformation1.ProcessId = ProcessID;
                    //wucRepresentativeInformation1.InternalNumber = lblInternalNumber.Text;
                    //wucRepresentativeInformation1.ProcessNumber = lblProcessNumber.Text;

                    //wucPEPayment1.ProcessId = ProcessID;
                }
            }
        }

        #region REPRESENTATIVE
        private void FillGridRepresentative()
        {
            gvRepresentativeInformation.DataSource = DataBase.DataReader("select * from vwRepresentativeInformation where ProcessId=" + ProcessId + " order by Date desc");
            string[] key = new string[] { "ProcessId", "RepresentativeId", "Date" };
            gvRepresentativeInformation.DataKeyNames = key;
            gvRepresentativeInformation.DataBind();
        }

        protected void gvRepresentativeInformation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataBase.Deinup("delete from tb_ProcessRepresentativeInformation where ProcessId=" + gvRepresentativeInformation.DataKeys[e.RowIndex][0] + " and RepresentativeId=" + gvRepresentativeInformation.DataKeys[e.RowIndex][1] + " and convert(varchar(30),Date,20)='" + DateTime.Parse(gvRepresentativeInformation.DataKeys[e.RowIndex][2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            FillGridRepresentative();
        }

        protected void gvRepresentativeInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRepresentativeInformation.Text = gvRepresentativeInformation.Rows[gvRepresentativeInformation.SelectedIndex].Cells[2].Text;
            gvRepresentativeInformation.Enabled = false;
            imgBtInsertRepresentativeInformation.Visible = false;
            ckbNotifyRepresentative.Visible = false;
            imgBtSaveRepresentativeInformation.Visible = true;
        }
        protected void imgBtSaveRepresentativeInformation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            DataBase.Deinup("update tb_ProcessRepresentativeInformation set Information='" +
                txtRepresentativeInformation.Text.Replace("'", string.Empty) + "' where ProcessId=" + ProcessId + " and RepresentativeId=" + gvRepresentativeInformation.DataKeys[gvRepresentativeInformation.SelectedIndex][1] + " and convert(varchar(30),Date,20)='" + DateTime.Parse(gvRepresentativeInformation.DataKeys[gvRepresentativeInformation.SelectedIndex][2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");

            gvRepresentativeInformation.Enabled = true;
            imgBtInsertRepresentativeInformation.Visible = true;
            ckbNotifyRepresentative.Visible = true;
            imgBtSaveRepresentativeInformation.Visible = false;

            gvRepresentativeInformation.SelectedIndex = -1;
            FillGridRepresentative();
            txtRepresentativeInformation.Text = string.Empty;

            String ecn = System.Environment.MachineName;
            string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

            Process pro = new Process();
            pro.SetAlterUser(ProcessId.ToString(), pcInfo);
        }
        protected void imgBtInsertRepresentativeInformation_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                string msg = "Nova informacao adicionada ao processo: Num. Int. " + lblInternalNumber.Text + " / Num. Trib. " + lblProcessNumber.Text;
                int MPhone = 0;

                DataBase.Deinup("exec uspRepresentativeInformationAdd " + ProcessId + ",'" + txtRepresentativeInformation.Text.Replace("'", string.Empty) + "','" + Membership.GetUser().UserName + "'");
                if (ckbNotifyRepresentative.Checked)
                {
                    Email mail = new Email();
                    Parameter p = new Parameter();
                    mail.Subject = msg;
                    DataTable dt = DataBase.DataTable("select Email,CarbonCopy,MPhone from vwProcessRepresentative where ProcessId=" + ProcessId);

                    MPhone = int.Parse(dt.Rows[0][3].ToString());
                    mail.Send(dt.Rows[0][0].ToString(), string.Format(p.GetMessage(2), txtRepresentativeInformation.Text, Membership.GetUser().UserName), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                }

                //if (MPhone > 0 && ConfigurationManager.AppSettings["SendSMS"].ToString() == "1")
                //{
                //    /*
                //    //envia sms

                //    //Our postvars
                //    byte[] buffer = Encoding.ASCII.GetBytes("user=sp&password=o12a71hg3j9jlk8if6&to=" + MPhone + "&text=" + msg);
                //    //Initialization, we use localhost, change if applicable
                //    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://dev.msglab.com/sp/sendmsg.php");

                //    //Our method is post, otherwise the buffer (postvars) would be useless
                //    WebReq.Method = "POST";

                //    //We use form contentType, for the postvars.
                //    WebReq.ContentType = "application/x-www-form-urlencoded";

                //    //The length of the buffer (postvars) is used as contentlength.
                //    WebReq.ContentLength = buffer.Length;

                //    //We open a stream for writing the postvars
                //    Stream PostData = WebReq.GetRequestStream();

                //    //Now we write, and afterwards, we close. Closing is always important!
                //    PostData.Write(buffer, 0, buffer.Length);
                //    PostData.Close();

                //    //Get the response handle, we have no true response yet!
                //    HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                //     */


                //    com.professionalsms.www.MyWebService01 MyServices = new com.professionalsms.www.MyWebService01();
                //    MyServices.Url = "http://www.professionalsms.com/mywebservices/mywebservice01.asmx";

                //    string MyUserName = "gondar";
                //    string MyPassword = "123456";
                //    string MySender = "TekSMS";
                //    string MyMobilePhone = "351" + MPhone;
                //    string MyMessage = msg;

                //    bool MyIsScheduledEnabled = false;
                //    string MyIsScheduledDateTime = "";
                //    bool MyIsLimitedDateTimeEnabled = false;
                //    string MyIsLimitedDateTime = "";
                //    string MyReportEmail = "";
                //    string MyReference = "";
                //    bool MyUseLongReturn = false;

                //    string MyResult = MyServices.SendSMS(MyUserName,
                //                    MyPassword,
                //                    MySender,
                //                    MyMobilePhone,
                //                    MyMessage,
                //                    MyIsScheduledEnabled,
                //                    MyIsScheduledDateTime,
                //                    MyIsLimitedDateTimeEnabled,
                //                    MyIsLimitedDateTime,
                //                    MyReportEmail,
                //                    MyReference,
                //                    MyUseLongReturn);

                //    lblMsg.Text = MyResult == "0" ? "SMS enviada com sucesso!" : "";
                //}

                FillGridRepresentative();
                txtRepresentativeInformation.Text = string.Empty;

                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

                Process pro = new Process();
                pro.SetAlterUser(ProcessId.ToString(), pcInfo);
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro: " + ex.Message;
            }
        }

        #endregion

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
                p.SetValueToRecover(int.Parse(Request.QueryString["pr"].ToString()), double.Parse(txtValueToRecover.Text), pcInfo);

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
                DataBase.Deinup("update tb_Process set Observation='" + txtObservation.Text.Replace("'", string.Empty) + "' where ProcessId=" + Request.QueryString["pr"]);
                lblObservation.Text = txtObservation.Text.Replace("'", string.Empty);
                imgBtEditProcessObservation.Visible = true;
                imgBtSaveProcessObservation.Visible = false;
                txtObservation.Visible = false;
                Process p = new Process();
                String ecn = System.Environment.MachineName;
                string pcInfo = Request.ServerVariables["REMOTE_HOST"] + " - " + Request.ServerVariables["REMOTE_ADDR"] + " - " + ecn;

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
            SaveDetails();
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


        #region ProcessDetail

        private void FillPDetail()
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


        #endregion

    }
}
