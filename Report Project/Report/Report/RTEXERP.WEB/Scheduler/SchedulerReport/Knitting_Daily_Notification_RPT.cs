using RTEXERP.Common.Constants;
using RTEXERP.Contracts.Common;
using SSRSReport.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Scheduler.SchedulerReport
{
    public class Knitting_Daily_Notification_RPT
    {
        public async Task<string> StoreReport(string stdDate, string enddate)
        {
            try
            {
                string reportName = "Knitting_Daily_Notification";
                //string ReportFileName = "Aop_Cost_Summary" + DateTime.Now.ToString("ddMMMyyyhhMMss")+".pdf";
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                //parameters.Add("stdate", DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy"));
                //parameters.Add("enddate", DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy"));
                parameters.Add("DateFrom", stdDate);
                parameters.Add("DateTo", enddate);


                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;

                string languageCode = "en-us";
                byte[] reportContent = await new CallSSRSReport().RenderReport(reportName, parameters, languageCode, "MHTML", connectionString);
                var ContentType = "";
                //  Stream stream = new MemoryStream(reportContent);
                var mainPath = Path.Combine(SchedulerReportPath.ReportPath);
                if (!Directory.Exists(mainPath))
                {
                    Directory.CreateDirectory(mainPath);
                    //path  = @"C:\Report\" + ReportFileName;
                }
                var filePath = mainPath + @"\" + reportName + ".mht";
                ContentType = "application/pdf";
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                await fs.WriteAsync(reportContent, 0, reportContent.Length);
                fs.Close();
                return filePath;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> SendASEmailBody(string stdDate, string enddate)
        {
            try
            {
                string reportName = "Knitting_Daily_Notification";
                //string ReportFileName = "Aop_Cost_Summary" + DateTime.Now.ToString("ddMMMyyyhhMMss")+".pdf";
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                //parameters.Add("stdate", DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy"));
                //parameters.Add("enddate", DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy"));
                parameters.Add("DateFrom", stdDate);
                parameters.Add("DateTo", enddate);


                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;

                string languageCode = "en-us";
                byte[] reportContent = await new CallSSRSReport().RenderReport(reportName, parameters, languageCode, "MHTML", connectionString);
                var ContentType = "";
                //  Stream stream = new MemoryStream(reportContent);
                var mainPath = Path.Combine(SchedulerReportPath.ReportPath);
                if (File.Exists(Path.Combine(mainPath, reportName + ".mht")))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(mainPath, reportName + ".mht"));

                }
                if (!Directory.Exists(mainPath))
                {
                    Directory.CreateDirectory(mainPath);
                    //path  = @"C:\Report\" + ReportFileName;
                }
                var filePath = mainPath + @"\" + reportName + ".mht";

                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                await fs.WriteAsync(reportContent, 0, reportContent.Length);
                fs.Close();
                return filePath;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
