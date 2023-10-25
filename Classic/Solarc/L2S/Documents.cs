using System.Data;
using System.Text;
using System.Web.Security;
using System.Web.UI.WebControls;

public class Documents
{
    public int DocumentId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public int ProcessId { get; set; }
    public int CreditorId { get; set; }
    public int ExecutedId { get; set; }

    public Documents()
    {
    }

    public DataTable GetAllDocuments()
    {
        return DataBase.DataTable("select DocumentId,Name from tb_Document order by Name");
    }
    public DataTable GetDocument(int theDocumentId)
    {
        DocumentId = theDocumentId;
        return DataBase.DataTable("select DocumentId,Name,Value from tb_Document where DocumentId=" + DocumentId);
    }
    public void NewDocument(int theDocumentId, string theName, string theValue)
    {
        DocumentId = theDocumentId;
        Name = theName;
        Value = theValue;
        DataBase.Deinup("exec uspNewDocument " + DocumentId + "," + "'" + Name + "','" + Value + "','" + Membership.GetUser().ProviderUserKey + "'");
    }

    public string Generate(int theDocumentId, int theProcessId, int theExecutedId, int theCreditorId, bool theBold,string theExtraText)
    {
        DocumentId = theDocumentId;
        string theContent = DataBase.Scalar("select Value from tb_Document where DocumentId=" + DocumentId);

        theContent = theExtraText.Replace("«TEXTOEXTRA»", theContent);

        StringBuilder sql = new StringBuilder();
        sql.Append("select ProcessId,NumeroInterno,TribunalNome,TribunalMorada,TribunalTlf,TribunalEmail,");
        sql.Append("TribunalComarca,TribunalCodigoProcesso,");

        sql.Append("RepresentativeId,MandatarioNome,MandatarioMorada,MandatarioTlf,MandatarioTlm,MandatarioFax,MandatarioEmail,MandatarioNif,MandatarioNumCedula,");

        sql.Append("ExecutedId,ExecutadoNome,ExecutadoMorada,ExecutadoTlf,ExecutadoTlm,ExecutadoFax,ExecutadoEmail,ExecutadoBi,ExecutadoNifNipl,ExecutadoNifs,");
        sql.Append("ExecutadoDataNascimento,");

        sql.Append("CreditorId,ExequenteNome,ExequenteMorada,ExequenteTlf,ExequenteTlm,ExequenteFax,ExequenteEmail,ExequenteBi,ExequenteNifNipl,");
        sql.Append("ExequenteDataNascimento,Value from vwDocument ");

        sql.Append(" where");
        sql.Append(" ProcessId={0} ");
        sql.Append(" and ExecutedId={1} ");
        sql.Append(" and CreditorId={2}");
        DataTable dt = DataBase.DataTable(string.Format(sql.ToString(), theProcessId, theExecutedId, theCreditorId));

        if (dt.Rows.Count > 0)
        {
            theContent = theContent.Replace("«NUMEROINTERNO»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][1].ToString() + (theBold == true ? "</b>" : string.Empty));

            theContent = theContent.Replace("«VALORACCAO»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][38].ToString() + " €" + (theBold == true ? "</b>" : string.Empty));

            theContent = theContent.Replace("«TRIBUNALNOME»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][2].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«TRIBUNALMORADA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][3].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«TRIBUNALTLF»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][4].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«TRIBUNALEMAIL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][5].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«TRIBUNALCOMARCA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][6].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«TRIBUNALCODIGOPROCESSO»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][7].ToString() + (theBold == true ? "</b>" : string.Empty));

            theContent = theContent.Replace("«MANDATARIONOME»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][9].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIOMORADA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][10].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIOTLF»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][11].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIOTLM»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][12].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIOFAX»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][13].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIOEMAIL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][14].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIONIF»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][15].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«MANDATARIONUMCEDULA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][16].ToString() + (theBold == true ? "</b>" : string.Empty));

            theContent = theContent.Replace("«EXECUTADONOME»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][18].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOMORADA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][19].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOTLF»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][20].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOTLM»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][21].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOFAX»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][22].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOEMAIL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][23].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADOBI»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][24].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADONIFNIPL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][25].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADONIFS»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][26].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXECUTADODATANASCIMENTO»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][27].ToString() + (theBold == true ? "</b>" : string.Empty));

            theContent = theContent.Replace("«EXEQUENTENOME»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][29].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTEMORADA»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][30].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTETLF»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][31].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTETLM»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][32].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTEFAX»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][33].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTEEMAIL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][34].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTEBI»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][35].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTENIFNIPL»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][36].ToString() + (theBold == true ? "</b>" : string.Empty));
            theContent = theContent.Replace("«EXEQUENTEDATANASCIMENTO»", (theBold == true ? "<b>" : string.Empty) + dt.Rows[0][37].ToString() + (theBold == true ? "</b>" : string.Empty));
        }

        return theContent;
    }
}
