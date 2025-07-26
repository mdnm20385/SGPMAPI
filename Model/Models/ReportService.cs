using System.Reflection;
using System.Text;
using Model.Models.SJM;
using Model.Reports;

namespace Model.Models
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(string reportName, string reportType,string path="");
    }


}
