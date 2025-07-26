using DevExpress.XtraReports.UI;

namespace SGPMAPI.Interfaces
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["TestReport"] = () => new TestReport()
        };
    }
}
