using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for Process
/// </summary>
public class Process
{
    private int processId,localization;
    private string iCcode, iCnumber, iCyear, iCinitials, processNumber, classification, section, observation, enforcement, alterUserDate , localizationDetail, executionType;
    private double value, exesAe;
    private Court courtValue = new Court();
    private List<Creditor> creditorList;
    private List<Executed> executedList;
    private List<string> executedExtraAddresses;
    private ClassRepresentative representativeValue = new ClassRepresentative();
    private ProvisionRequest pr = new ProvisionRequest();

    public string InternalCode
    {
        get 
        {
            return string.Format("{0}/{1:0000}/{2}{3}", iCcode, decimal.Parse(iCnumber), iCyear, iCinitials != null ? (iCinitials.Length > 0 ? "/" + iCinitials : string.Empty) : "");
        }
        set
        {
            string[] pn = value.Split('/');
            if (pn.Length >= 3)
            {
                if (pn[0].Length <= 10)
                    iCcode = pn[0].ToUpper();
                else
                    throw new Exception("Codigo - Maximo 10 Caracteres");
                iCnumber = pn[1];
                iCyear = pn[2];
                if (pn.Length > 3)
                    if (pn[3].Length <= 3)
                        iCinitials = pn[3].ToUpper();
            }
            else
                throw new Exception("Numero Interno - Formato errado [Cod/Num/Ano/Iniciais]");
        }
    }
    public string ProcessNumber
    {
        get { return processNumber; }
        set
        {
            if (value.Trim().Length > 0)
                processNumber = value.Trim();
            else
                processNumber = string.Empty;
                //throw new Exception("Número do Processo - Valor Incorrecto");
        }
    }
    public string Classification
    {
        get { return classification; }
        set { classification = value; }
    }
    public string Section
    {
        get { return section; }
        set { section = value; }
    }
    public int LocalizationId
    {
        get { return localization; }
        set { localization = value; }
    }
    public string LocalizationDetail
    {
        get { return localizationDetail; }
        set { localizationDetail = value; }
    }
    public string Enforcement
    {
        get { return enforcement; }
        set { enforcement = value; }
    }
    public double Value
    {
        get { return value; }
        set { this.value = value; }
    }
    public double ExesAe
    {
        get { return exesAe; }
        set { exesAe = value; }
    }
    public string Observation
    {
        get { return observation; }
        set { observation = value; }
    }
    public string AlterUserDate
    {
        get { return alterUserDate; }
        set { alterUserDate = value; }
    }
    public string ExecutionType
    {
        get { return executionType; }
        set { executionType = value; }
    }

    public Court CourtValue
    {
        get { return courtValue; }
        set { courtValue = value; }
    }
    public List<Creditor> CreditorList
    {
        get { return creditorList; }
        set { creditorList = value; }
    }
    public List<Executed> ExecutedList
    {
        get { return executedList; }
        set { executedList = value; }
    }
    public List<string> ExecutedExtraAddresses
    {
        get { return executedExtraAddresses; }
        set { executedExtraAddresses = value; }
    }
    public ClassRepresentative RepresentativeValue
    {
        get { return representativeValue; }
        set { representativeValue = value; }
    }
    public ProvisionRequest Pr
    {
        get { return pr; }
        set { pr = value; }
    }

    public Process()
    {
        // construtor para novos processos
    }
    public Process(int theProcessId)
    {
        processId = theProcessId;
        //construtor para processos ja existentes
        DataSet ds = DataBase.DataSet("select * from vwProcessInfo where processid=" + theProcessId + "; " +
            "select * from vwProcessCourt where processid=" + theProcessId + "; " +
            "select * from vwProcessCreditor where processid=" + theProcessId + " order by name; " +
            "select * from vwProcessExecuted where processid=" + theProcessId + " order by name; " +
            "select * from vwProcessRepresentative where processid=" + theProcessId + " order by name; " +
            "select date,address from tb_ExecutedAddresses  where processid=" + theProcessId + " order by date;" +
            "select convert(nvarchar(15),ProvisionRequest1,105),convert(nvarchar(15),ProvisionRequest2,105),convert(nvarchar(15),ProvisionRequest3,105),convert(nvarchar(15),ProvisionReinforcement1,105),convert(nvarchar(15),ProvisionReinforcement2,105),convert(nvarchar(15),ProvisionReinforcement3,105) from tb_ProvisionRequest where ProcessId=" + theProcessId);

        //informacao Processo
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            InternalCode = ds.Tables[0].Rows[0][1].ToString();
            ProcessNumber = ds.Tables[0].Rows[0][2].ToString();
            Observation = ds.Tables[0].Rows[0][3].ToString();
            ExesAe = double.Parse(ds.Tables[0].Rows[0][4].ToString());
            Value = double.Parse(ds.Tables[0].Rows[0][5].ToString());
            Classification = ds.Tables[0].Rows[0][6].ToString();
            Section = ds.Tables[0].Rows[0][7].ToString();
            Enforcement = ds.Tables[0].Rows[0][8].ToString();

            if (ds.Tables[0].Rows[0]["LocalizationId"].ToString().Length > 0)
                LocalizationId = int.Parse(ds.Tables[0].Rows[0]["LocalizationId"].ToString());
            else
                LocalizationId = 0;

            localizationDetail = ds.Tables[0].Rows[0][17].ToString();
            ExecutionType = ds.Tables[0].Rows[0][16].ToString();

            //alteruserdate
            AlterUserDate = string.Format("<tr><td class=\"textProcessColumns\">{0}</td><td class=\"textProcessFields\">{1}</td></tr> <tr><td class=\"textProcessColumns\">{2}</td><td class=\"textProcessFields\">{3}</td></tr> <tr><td class=\"textProcessColumns\">{4}</td><td class=\"textProcessFields\">{5}</td></tr>", ds.Tables[0].Rows[0][9].ToString(), ds.Tables[0].Rows[0][10].ToString(), ds.Tables[0].Rows[0][11].ToString(), ds.Tables[0].Rows[0][12].ToString(), ds.Tables[0].Rows[0][13].ToString(), ds.Tables[0].Rows[0][14].ToString());
        }

        //  ### COURT
        if (ds != null && ds.Tables[1].Rows.Count > 0)
        {
            CourtValue.Name = ds.Tables[1].Rows[0][2].ToString();
            CourtValue.Address = ds.Tables[1].Rows[0][3].ToString();
            CourtValue.Phone = ds.Tables[1].Rows[0][4].ToString();
            courtValue.Fax = ds.Tables[1].Rows[0][5].ToString();
            courtValue.Email = ds.Tables[1].Rows[0][6].ToString();
            courtValue.JudicialDistrict = ds.Tables[1].Rows[0][7].ToString();
        }

        //  ### CREDITOR
        if (ds != null && ds.Tables[2].Rows.Count > 0)
        {
            CreditorList = new List<Creditor>(ds.Tables[2].Rows.Count);
            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                CreditorList.Add(new Creditor(ds.Tables[2].Rows[i][2].ToString(), ds.Tables[2].Rows[i][3].ToString(), ds.Tables[2].Rows[i][4].ToString(), ds.Tables[2].Rows[i][5].ToString(), ds.Tables[2].Rows[i][6].ToString(), ds.Tables[2].Rows[i][7].ToString(), ds.Tables[2].Rows[i][8].ToString(), ds.Tables[2].Rows[i][9].ToString(), ds.Tables[2].Rows[i][10].ToString(), DateTime.Parse(ds.Tables[2].Rows[i][11].ToString().Length > 0 ? ds.Tables[2].Rows[i][11].ToString() : "01-01-1900")));
        }
        else
            CreditorList = new List<Creditor>(0);


        //  ### EXECUTED
        if (ds != null && ds.Tables[3].Rows.Count > 0)
        {
            ExecutedList = new List<Executed>(ds.Tables[3].Rows.Count);
            for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                ExecutedList.Add(new Executed(ds.Tables[3].Rows[i][2].ToString(), ds.Tables[3].Rows[i][3].ToString(), ds.Tables[3].Rows[i][4].ToString(), ds.Tables[3].Rows[i][5].ToString(), ds.Tables[3].Rows[i][6].ToString(), ds.Tables[3].Rows[i][7].ToString(), ds.Tables[3].Rows[i][8].ToString(), ds.Tables[3].Rows[i][9].ToString(), ds.Tables[3].Rows[i][10].ToString(), DateTime.Parse(ds.Tables[3].Rows[i][11].ToString().Length > 0 ? ds.Tables[3].Rows[i][11].ToString() : "01-01-1900")));
        }
        else
            ExecutedList = new List<Executed>(0);

        //  ### REPRESENTATIVE
        if (ds != null && ds.Tables[4].Rows.Count > 0)
        {
            RepresentativeValue.Name = ds.Tables[4].Rows[0][2].ToString();
            RepresentativeValue.Address = ds.Tables[4].Rows[0][3].ToString();
            RepresentativeValue.Phone = ds.Tables[4].Rows[0][4].ToString();
            RepresentativeValue.Fax = ds.Tables[4].Rows[0][5].ToString();
        }

        //  ### Executed Extra Addresses!
        if (ds != null && ds.Tables[5].Rows.Count > 0)
        {
            ExecutedExtraAddresses = new List<string>(ds.Tables[5].Rows.Count);
            for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
                ExecutedExtraAddresses.Add(ds.Tables[5].Rows[i][0] + " - " + ds.Tables[5].Rows[i][1]);
        }
        else
            ExecutedExtraAddresses = new List<string>(0);

        
        //  ### PROVISION REQUEST - Pr
        if (ds != null && ds.Tables[6].Rows.Count > 0)
        {
            if (ds.Tables[6].Rows[0][0].ToString().Length > 0)
                Pr.ProvisionRequest1 = DateTime.Parse(ds.Tables[6].Rows[0][0].ToString());
            if (ds.Tables[6].Rows[0][1].ToString().Length > 0)
                Pr.ProvisionRequest2 = DateTime.Parse(ds.Tables[6].Rows[0][1].ToString());
            if (ds.Tables[6].Rows[0][2].ToString().Length > 0)
                Pr.ProvisionRequest3 = DateTime.Parse(ds.Tables[6].Rows[0][2].ToString());

            if (ds.Tables[6].Rows[0][3].ToString().Length > 0)
                Pr.ProvisionReinforcement1 = DateTime.Parse(ds.Tables[6].Rows[0][3].ToString());
            if (ds.Tables[6].Rows[0][4].ToString().Length > 0)
                Pr.ProvisionReinforcement2 = DateTime.Parse(ds.Tables[6].Rows[0][4].ToString());
            if (ds.Tables[6].Rows[0][5].ToString().Length > 0)
                Pr.ProvisionReinforcement3 = DateTime.Parse(ds.Tables[6].Rows[0][5].ToString());
        }
        else
            Pr = new ProvisionRequest();
    }

    public void Save()
    {
        // grava registo base de dados
    }
    public string Insert()
    {
        //
        return DataBase.Scalar("exec uspProcessInsert '" + iCcode + "'," + iCnumber + ",'" + iCyear + "','" + iCinitials + "','" + ProcessNumber + "','" + Membership.GetUser().ProviderUserKey + "'");
    }

    //  ### FIELD RETURN
    public StringBuilder GetCourt()
    {
        StringBuilder sb = new StringBuilder("");
        if (CourtValue.Name.Length > 0)
            sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", CourtValue.Name));
        if (Section.Length > 0)
            sb.Append("Secção: " + Section + "<br/>");
        if (CourtValue.Address.Length > 0)
            sb.Append(CourtValue.Address + "<br/>");
        if (CourtValue.Phone.Length > 0)
            sb.Append("Tlf.: " + CourtValue.Phone + "<br/>");
        if (CourtValue.Fax.Length > 0)
            sb.Append("Fax: " + CourtValue.Fax + "<br/>");
        if (CourtValue.Email.Length > 0)
            sb.Append("Email: " + CourtValue.Email + "<br/>");
        if (CourtValue.JudicialDistrict.Length > 0)
            sb.Append("Distrito Judicial: " + CourtValue.JudicialDistrict + "<br/>");

        return sb;
    }
    public StringBuilder GetCreditor()
    {
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < CreditorList.Count; i++)
        {
            sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", CreditorList[i].Name));
            if (CreditorList[i].Address.Length > 0)
                sb.Append(CreditorList[i].Address + "<br/>");
            if (CreditorList[i].Phone.Length > 0)
                sb.Append("Tlf.: " + CreditorList[i].Phone + "<br/>");
            if (CreditorList[i].MPhone.Length > 0)
                sb.Append("Tlm.: " + CreditorList[i].MPhone + "<br/>");
            if (CreditorList[i].Fax.Length > 0)
                sb.Append("Fax: " + CreditorList[i].Fax + "<br/>");
            if (CreditorList[i].Email.Length > 0)
                sb.Append(CreditorList[i].Email + "<br/>");

            if (CreditorList[i].IdentityCard.Length > 0)
                sb.Append("BI: " + CreditorList[i].IdentityCard + "<br/>");
            if (CreditorList[i].NifNipl.Length > 0)
                sb.Append("NIF/NIPC: " + CreditorList[i].NifNipl + "<br/>");
            if (CreditorList[i].Nifs.Length > 0)
                sb.Append("NISS: " + CreditorList[i].Nifs + "<br/>");
            if (CreditorList[i].BornDate.Year > 1900)
                sb.Append("Data Nasc. " + CreditorList[i].BornDate.ToString("dd-MM-yyyy") + " - " + (DateTime.Now.Year - CreditorList[i].BornDate.Year) + " Anos<br/>");
            sb.Append("<br/>");
        }
        return sb.Length == 0 ? new StringBuilder("-") : sb;
    }
    public StringBuilder GetExecuted()
    {
        StringBuilder sb = new StringBuilder("");
        for (int i = 0; i < ExecutedList.Count; i++)
        {
            sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", ExecutedList[i].Name));
            if (ExecutedList[i].Address.Length > 0)
                sb.Append(ExecutedList[i].Address + "<br/>");
            if (ExecutedList[i].Phone.Length > 0)
                sb.Append("Tlf.: " + ExecutedList[i].Phone + "<br/>");
            if (ExecutedList[i].MPhone.Length > 0)
                sb.Append("Tlm.: " + ExecutedList[i].MPhone + "<br/>");
            if (ExecutedList[i].Fax.Length > 0)
                sb.Append("Fax: " + ExecutedList[i].Fax + "<br/>");
            if (ExecutedList[i].Email.Length > 0)
                sb.Append(ExecutedList[i].Email + "<br/>");

            if (ExecutedList[i].IdentityCard.Length > 0)
                sb.Append("BI: " + ExecutedList[i].IdentityCard + "<br/>");
            if (ExecutedList[i].NifNipl.Length > 0)
                sb.Append("NIF/NIPC: " + ExecutedList[i].NifNipl + "<br/>");
            if (ExecutedList[i].Nifs.Length > 0)
                sb.Append("NISS: " + ExecutedList[i].Nifs + "<br/>");
            if (ExecutedList[i].BornDate.Year > 1900)
                sb.Append("Data Nasc. " + ExecutedList[i].BornDate.ToString("dd-MM-yyyy") + " - " + (DateTime.Now.Year - ExecutedList[i].BornDate.Year) + " Anos<br/>");
            sb.Append("<br/>");
        }
        if (ExecutedList.Count > 0 && ExecutedExtraAddresses.Count > 0)
            for (int i = 0; i < ExecutedExtraAddresses.Count; i++)
                sb.Append("<br/>" + ExecutedExtraAddresses[i]);
        return sb.Length == 0 ? new StringBuilder("-") : sb;
    }
    public StringBuilder GetExecutedEmployer()
    {
        StringBuilder sb = new StringBuilder("");
        DataSet ds;
        for (int i = 0; i < ExecutedList.Count; i++)
        {
            sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", ExecutedList[i].Name));
            ds = DataBase.DataSet("select * from vwProcessEmployer where processid=" + processId + " and ExecutedName='" + ExecutedList[i].Name + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", ds.Tables[0].Rows[0][1]));
                if (ds.Tables[0].Rows[0][2].ToString().Length > 0)
                    sb.Append(ds.Tables[0].Rows[0][2] + "<br/>");

                if (ds.Tables[0].Rows[0][3].ToString().Length > 0)
                    sb.Append("Tlf.: " + ds.Tables[0].Rows[0][3] + "<br/>");

                if (ds.Tables[0].Rows[0][4].ToString().Length > 0)
                    sb.Append("Fax: " + ds.Tables[0].Rows[0][4] + "<br/>");

                if (ds.Tables[0].Rows[0][5].ToString().Length > 0)
                    sb.Append(ds.Tables[0].Rows[0][5] + "<br/>");
                sb.Append("<br/>");
            }
        }
        return sb.Length == 0 ? new StringBuilder("-") : sb;
    }
    public StringBuilder GetRepresentative()
    {
        StringBuilder sb = new StringBuilder("");
        if (RepresentativeValue.Name.Length > 0)
            sb.Append(string.Format("<span class=\"procSpecField\">{0}</span><br/>", RepresentativeValue.Name));
        if (RepresentativeValue.Address.Length > 0)
            sb.Append(RepresentativeValue.Address + "<br/>");
        if (RepresentativeValue.Phone.Length > 0)
            sb.Append("Tlf.: " + RepresentativeValue.Phone + "<br/>");
        if (RepresentativeValue.Fax.Length > 0)
            sb.Append("Fax: " + RepresentativeValue.Fax + "<br/>");
        if (RepresentativeValue.Email.Length > 0)
            sb.Append(RepresentativeValue.Email + "<br/>");

        return sb.Length == 0 ? new StringBuilder("-") : sb;
    }
    public StringBuilder GetSearch()
    {
        //ESTOU A FAZER ISTO!
        return new StringBuilder("");
    }
    public DataTable GetCreditorList()
    {
        return DataBase.DataTable("select CreditorId,Name from vwProcessCreditor where processid=" + processId + " order by name");
    }
    public DataTable GetExecutedList()
    {
        return DataBase.DataTable("select ExecutedId,Name from vwProcessExecuted where processid=" + processId + " order by name");
    }

    //  ### FIELDS associated to the process!
    public void SetCourt(string theCourtName,int theProcessId)
    {
        DataBase.Deinup("exec uspProcessCourt '" + theCourtName + "'," + theProcessId);
    }
    public void SetSection(string theSectionName,int theProcessId)
    {
        DataBase.Deinup("exec uspProcessSection '" + theSectionName + "'," + theProcessId);
    }
    public void SetCreditor(string theCreditorName, int theProcessId,string pcInfo)
    {
        DataBase.Deinup("exec uspProcessCreditor '" + theCreditorName + "'," + theProcessId);
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetExecuted(string theExecutedName, int theProcessId, string pcInfo)
    {
        DataBase.Deinup("exec uspProcessExecuted '" + theExecutedName + "'," + theProcessId);
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetRepresentative(string theRepresentativeName, int theProcessId)
    {
        DataBase.Deinup("exec uspProcessRepresentative '" + theRepresentativeName + "'," + theProcessId);
    }
    public void SetProcessNumber(string theProcessNumber,int theProcessId)
    {
        DataBase.Deinup("update tb_process set ProcessNumber='" + theProcessNumber + "' where ProcessId=" + theProcessId);
    }
    public void SetLocalization(int theLocalizationId, int theProcessId)
    {
        if (theLocalizationId == 0)
            DataBase.Deinup("update tb_process set LocalizationId=NULL where ProcessId=" + theProcessId);
        else
        {
            LocalizationId = theLocalizationId;
            DataBase.Deinup("update tb_process set LocalizationId='" + LocalizationId + "' where ProcessId=" + theProcessId);
        }
    }
    public void SetLocalizationDetail(string theLocalizationDetail,int theProcessId)
    {
        localizationDetail = theLocalizationDetail;
        DataBase.Deinup("update tb_process set LocalizationDetail='" + localizationDetail + "' where ProcessId=" + theProcessId);
    }
    public void SetExecutionType(string theExecutionType,int theProcessId)
    {
        ExecutionType = theExecutionType;
        DataBase.Deinup("exec uspProcessExecutionType '" + ExecutionType + "'," + theProcessId);
    }
    public void SetInternalNumber(string theInternalCode,int theProcessId,string pcInfo)
    {
        InternalCode = theInternalCode;
        string[] val=InternalCode.Split('/');
        DataBase.Deinup("update tb_process set Code='" + val[0] + "',Number='" + val[1] + "',Year='" + val[2] + "',Initials='" + (val.Length > 3 ? val[3] : string.Empty) + "' where ProcessId=" + theProcessId);
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetValue(double theValue,int theProcessId)
    {
        DataBase.Deinup("update tb_process set Value=" + theValue.ToString().Replace(",", ".") + " where ProcessId=" + theProcessId);
    }
    public void SetEnforcement(string theValue,int theProcessId)
    {
        DataBase.Deinup("update tb_process set Enforcement='" + theValue.ToString().Replace("'", string.Empty) + "' where ProcessId=" + theProcessId);
    }
    public void SetExesAe(double theExesAe,int theProcessId)
    {
        DataBase.Deinup("update tb_process set ExesAe=" + theExesAe.ToString().Replace(",", ".") + " where ProcessId=" + theProcessId);
    }
    public void SetProvision(int theProcessId,int theExecutedId,DateTime theDate,double theValue,string pcInfo)
    {
        DataBase.Deinup("exec uspProcessProvision " + theProcessId + "," + theExecutedId + ",'" + theDate.ToString("MM-dd-yyyy") + "'," + theValue);
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetEmployer(string theEmployerName, int theExecutedId, int theProcessId,string pcInfo)
    {
        DataBase.Deinup("exec uspProcessEmployer '" + theEmployerName + "'," + theExecutedId + "," + theProcessId);
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetSearch(string theSearchName,int theProcessId,int theExecutedId,DateTime theDate,string theObservation,string pcInfo)
    {
        DataBase.Deinup("exec uspProcessSearch '" + theSearchName + "'," + theProcessId + "," + theExecutedId + ",'" + theDate.ToString("MM-dd-yyyy HH:mm:ss") + "','" + theObservation + "','" + Membership.GetUser().ProviderUserKey + "'");
        SetAlterUser(theProcessId.ToString(),pcInfo);
    }
    public void SetValueToRecover(int theProcessId, double theValue,string pcInfo)
    {
        DataBase.Deinup("update tb_process set ValueToRecover=" + theValue.ToString().Replace(",", ".") + " where ProcessId=" + theProcessId);
        SetAlterUser(theProcessId.ToString(), pcInfo);
    }
   
    public void SetAlterUser(string theProcessId,string pcInfo)
    {
        DataBase.Deinup("update tb_Process set AlterDate2=AlterDate1, AlterDate1=AlterDate, AlterDate=GETDATE(),AlterPCInfo2=AlterPCInfo1,AlterPCInfo1=AlterPCInfo,AlterPCInfo='" + pcInfo + "',AlterUserId2=AlterUserId1, AlterUserId1=AlterUserId, AlterUserId='" + Membership.GetUser().ProviderUserKey + "' where ProcessId=" + theProcessId);
    }
    public void SetProvisionRequest(int theProcessId, ProvisionRequest thePr)
    {
        StringBuilder sb = new StringBuilder();
        DataBase.Deinup("if(select count(*) from tb_ProvisionRequest where ProcessId=" + theProcessId + ")=0 insert into tb_ProvisionRequest (ProcessId) values (" + theProcessId + ")");

        if (thePr.ProvisionRequest1.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append("ProvisionRequest1='" + thePr.ProvisionRequest1.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append("ProvisionRequest1=null");

        if (thePr.ProvisionRequest2.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append(",ProvisionRequest2='" + thePr.ProvisionRequest2.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append(",ProvisionRequest2=null");

        if (thePr.ProvisionRequest3.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append(",ProvisionRequest3='" + thePr.ProvisionRequest3.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append(",ProvisionRequest3=null");

        if (thePr.ProvisionReinforcement1.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append(",ProvisionReinforcement1='" + thePr.ProvisionReinforcement1.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append(",ProvisionReinforcement1=null");

        if (thePr.ProvisionReinforcement2.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append(",ProvisionReinforcement2='" + thePr.ProvisionReinforcement2.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append(",ProvisionReinforcement2=null");

        if (thePr.ProvisionReinforcement3.ToString("MM-dd-yyyy") != "01-01-1900")
            sb.Append(",ProvisionReinforcement3='" + thePr.ProvisionReinforcement3.ToString("MM-dd-yyyy") + "'");
        else
            sb.Append(",ProvisionReinforcement3=null");

        DataBase.Deinup("update tb_ProvisionRequest set " + sb.ToString() + " where ProcessId=" + theProcessId);
    }

    //  ### DELETE field
    public void DeleteCreditor(int theCreditorId, int theProcessId)
    {
        DataBase.Deinup("exec uspProcessDeleteCreditor " + theCreditorId + "," + theProcessId);
    }
    public void DeleteExecuted(int theExecutedId, int theProcessId)
    {
        DataBase.Deinup("exec uspProcessDeleteExecuted " + theExecutedId + "," + theProcessId);
    }
}
