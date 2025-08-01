using FluentScheduler;
using RTEXERP.BLL.CommonService.EmailSetup;
using RTEXERP.WEB.Scheduler.SchedulerReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Scheduler.SchedulerProcess.SchedulerJobs
{
    public class Knitting_Daily_Notification_JOB : IJob
    {


        private IEmailSenderCS _emailSender;


        public Knitting_Daily_Notification_JOB(IEmailSenderCS _emailSender)
        {
            this._emailSender = _emailSender;

        }

        public void Execute()
        {
            //string path = @"C:\Report\fileWrite\MyTest.txt";
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello");
            //        sw.WriteLine("And");
            //        sw.WriteLine("Welcome");
            //        sw.Close();
            //    }
            //}
            //else
            //{
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello");
            //        sw.WriteLine("And");
            //        sw.WriteLine("Welcome"+DateTime.Now.ToString());
            //        sw.Close();
            //    }
            //}

            ExecuteAsync().Wait();
        }

        private async Task ExecuteAsync()
        {
            var generateReport = new Knitting_Daily_Notification_RPT();
            string path = "";
            StringBuilder mailBody = new StringBuilder();
            string stdate = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            string endDate = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            string subject = $"Daily Production Report (Knitting Department) for {stdate} TO {endDate}";
            path = await generateReport.SendASEmailBody(stdate, endDate);
            List<EmailInfo> senderList = new List<EmailInfo>();

            senderList.Add(new EmailInfo { EmailAddress = "nipu@robintexbd.com", Name = "nipu", MailSendType = MailSendType.To });
            //senderList.Add(new EmailInfo { EmailAddress = "habib@robintexbd.com", Name = "Habib", MailSendType = MailSendType.CC });
            senderList.Add(new EmailInfo { EmailAddress = "akbar@comptexbd.com", Name = "Akbar", MailSendType = MailSendType.CC });
            //senderList.Add(new EmailInfo { EmailAddress = "dilip@robintexbd.com", Name = "Delip", MailSendType = MailSendType.CC });
            // senderList.Add(new EmailInfo { EmailAddress = "jobayershoaib@gmail.com", Name = "Jobs", MailSendType = MailSendType.To });
            //senderList.Add(new EmailInfo { EmailAddress = "aliakbar.a05@gmail.com", Name = "Akbar", MailSendType = MailSendType.CC });
            //  mailBody.Append("Dear Sir,<br />");
            mailBody.AppendFormat("Please find the Daily Production Report (Knitting Department). This is for your kind information.<br /><br />");
            // mailBody.Append("AOP Cost Summery Details. <img src=cid:Report>");



            if (path != "")
            {
                await _emailSender.SendEmailAsyncAttachmentInBody(senderList, subject, mailBody.ToString(), true, path);
            }
            else
            {
                await _emailSender.SendEmailAsyncAttachmentInBody(senderList, subject, mailBody.ToString(), false, "");
            }

            //   await TestSchedule();
        }
    }
}
