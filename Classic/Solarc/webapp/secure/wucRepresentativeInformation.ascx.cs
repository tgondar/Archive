using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class wucRepresentativeInformation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGridRepresentative();
        }

        public string InternalNumber { get; set; }
        public string ProcessNumber { get; set; }
        public int ProcessId { get; set; }

        //  ### Representative
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
                string msg = "Nova informacao adicionada ao processo: Num. Int. " + InternalNumber + " / Num. Trib. " + ProcessNumber;
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
    }
}
