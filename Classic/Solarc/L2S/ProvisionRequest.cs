using System;
using System.Text;

/// <summary>
/// Summary description for ProvisionRequest
/// </summary>
public class ProvisionRequest
{
    private DateTime dTemp = DateTime.Parse("01-01-1900");

    public DateTime ProvisionRequest1
    {
        get;
        set;
    }
    public DateTime ProvisionRequest2
    {
        get;
        set;
    }
    public DateTime ProvisionRequest3
    {
        get;
        set;
    }

    public DateTime ProvisionReinforcement1
    { get; set; }
    public DateTime ProvisionReinforcement2
    { get; set; }
    public DateTime ProvisionReinforcement3
    { get; set; }

    public ProvisionRequest()
    {
        ProvisionRequest1 = dTemp;
        ProvisionRequest2 = dTemp;
        ProvisionRequest3 = dTemp;

        ProvisionReinforcement1 = dTemp;
        ProvisionReinforcement2 = dTemp;
        ProvisionReinforcement3 = dTemp;
    }
}
