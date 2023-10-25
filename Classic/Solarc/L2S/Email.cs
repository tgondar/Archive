using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    private string fromEmail, subject, message, credentialUser, credentialPassword, sMTP, toEmail, company;

    public string ToEmail
    {
        get { return toEmail; }
        set { toEmail = value; }
    }
    public string FromEmail
    {
        get { return fromEmail; }
        set { fromEmail = value; }
    }
    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public string CredentialUser
    {
        get { return credentialUser; }
        set { credentialUser = value; }
    }
    public string CredentialPassword
    {
        get { return credentialPassword; }
        set { credentialPassword = value; }
    }
    public string SMTP
    {
        get { return sMTP; }
        set { sMTP = value; }
    }
    public string Company
    {
        get { return company; }
        set { company = value; }
    }

	public Email()
	{
        ToEmail = ConfigurationManager.AppSettings["EmailOnError"];
        FromEmail = ConfigurationManager.AppSettings["EmailFrom"];
        Subject = ConfigurationManager.AppSettings["EmailSubject"];
        CredentialUser = ConfigurationManager.AppSettings["EmailCredentialUser"];
        CredentialPassword = ConfigurationManager.AppSettings["EmailCredentialPassword"];
        SMTP = ConfigurationManager.AppSettings["EmailSMTP"];
        Parameter p = new Parameter();
        Company = p.GetInformation(1);
	}
    public void SendError(string theMessage)
    {
        try
        {
            MailMessage mail = new MailMessage();
            Message = "Utilizador: " + Membership.GetUser().UserName + "<br/>Data: " + DateTime.Now + "<br/>Empresa: " + Company + "<p>Erro:<br>" + theMessage;

            SendEmail(mail);
        }
        catch (Exception)
        {
        }
    }
    public void Send(string theToEmail, string theMessage)
    {
        MailMessage mail = new MailMessage();

        if (!ValidMail(theToEmail)) throw new Exception("Email errado!");

        ToEmail = theToEmail;
        Message = theMessage;

        SendEmail(mail);
    }
    public void Send(string theToEmail, string theMessage, string theCC, string theBCC)
    {
        MailMessage mail = new MailMessage();

        if (!ValidMail(theToEmail)) throw new Exception("Email errado!");

        ToEmail = theToEmail;
        Message = theMessage;

        string[] cc = theCC.Split(';');
        foreach (string tCC in cc)
            if (tCC.Length > 0) mail.CC.Add(tCC);

        string[] bcc = theBCC.Split(';');
        foreach (string tBcc in bcc)
            if (tBcc.Length > 0) mail.Bcc.Add(tBcc);

        SendEmail(mail);
    }
    private void SendEmail(MailMessage mail)
    {
        mail.Subject = Subject;
        mail.From = new MailAddress(FromEmail);
        mail.To.Add(ToEmail);
        mail.Body = Message;
        mail.IsBodyHtml = true;

        SmtpClient smtp = new SmtpClient(SMTP);
        smtp.Credentials = new NetworkCredential(CredentialUser, CredentialPassword);
        smtp.Send(mail);
    }
    public bool ValidMail(string theEmail)
    {
        if (theEmail.Length > 0)
        {
            //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string strRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex re = new Regex(strRegex);

            return (re.IsMatch(theEmail) ? true : false);
        }
        else
            return false;
    }
}
