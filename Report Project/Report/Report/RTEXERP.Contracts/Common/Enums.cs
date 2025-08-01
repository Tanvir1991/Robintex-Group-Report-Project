using System.ComponentModel;

namespace RTEXERP.Contracts.Common
{

    public enum enum_ServerType
    {
        [Description("192.173.163.8")]
        AOPConnectionString=1,
        CMSConnectionString=2,
        EmbroConnectionString=3,
        EMSConnectionString=4,
        FiniteSchedulerConnectionString=5,
        MaterialsManagementConnectionString=6,
        MaxcoConnectionString=7,
        [Description("192.173.163.190")]
        Own=8,
        HRMSConnectionString=9
    }
    public enum SecurityLevelId
    {
        Read = 0,
        Create = 1,
        Edit = 2,
        Delete = 3,
        Approve = 4,
        SuperAdmin = 5
    }
    /// <summary>
    /// A=New Entry,
    /// E =DB Exist No Change,
    /// U = DB Exist And Change,
    /// D = Delete
    /// </summary>
    public enum enum_AddOrUpdateOrDelete
    {
        [Description("New Entry")]
        A,
        [Description("DB Exist No Change")]
        E,
        [Description("DB Exist And Change")]
        U,
        [Description("Delete")]
        D
    }

    public enum enum_UnitCategory
    {
        Measurement,
        Weight,
        Count,
        Time,
        Temprtature
    }
    public enum enum_StyleStatus
    {
        StyleCreated = 0,
        ModelCreated = 1,
        //Edit = 2,
        //Delete = 3,
        //Approve = 4,
        OrderCreated = 5
    }
}
