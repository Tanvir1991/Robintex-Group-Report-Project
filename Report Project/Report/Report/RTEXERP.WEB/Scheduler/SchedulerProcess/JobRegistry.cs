using FluentScheduler;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using RTEXERP.BLL.CommonService.EmailSetup;
using RTEXERP.Common;
using RTEXERP.WEB.Scheduler.SchedulerProcess.SchedulerJobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RTEXERP.WEB.Scheduler.SchedulerProcess
{
    public class JobRegistry : Registry
    {

        public JobRegistry(IEmailSenderCS emailSender)
        {
            //Schedule<EmailJob>().ToRunEvery(1).Days();
            //  Schedule<AOPCostSummeryJob>().ToRunEvery(0).Days().At(10, 00);
            //      Schedule<AOPCostSummeryJob>().ToRunNow().AndEvery(1).Days().At(9, 45);
            //Schedule<AOPCostSummeryJob>().ToRunEvery(0).Days().At(10, 10);

            // new 
            int Aophour = StaticConfigs.GetConfig("AopReportHour") == null ? 9 : Convert.ToInt32(StaticConfigs.GetConfig("AopReportHour"));
            int AopMin = StaticConfigs.GetConfig("AopReportMinute") == null ? 13 : Convert.ToInt32(StaticConfigs.GetConfig("AopReportMinute"));
            // Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<AOPCostSummeryJob>()).ToRunNow().AndEvery(1).Days().At(09, 56);   
            //Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<AOPCostSummeryJob>()).ToRunEvery(1).Days().At(Aophour, AopMin);
            Schedule(new AOPCostSummeryJob(emailSender)).ToRunEvery(1).Days().At(Aophour,AopMin); // Running
            //Schedule(new AOPCostSummeryJob(emailSender)).ToRunEvery(3).Minutes(); // Test
          //  Schedule(new Knitting_Daily_Notification_JOB(emailSender)).ToRunEvery(1).Days().At(9, 48); // Running
           // Schedule(new Knitting_Daily_Notification_JOB(emailSender)).ToRunEvery(3).Minutes();
            //Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<AOPCostSummeryJob>()).ToRunEvery(1).Days().At(11, 7);
            //Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<AOPCostSummeryJob>()).ToRunEvery(1).Days().At(11, 9);
            //Schedule<AOPCostSummeryJob>().ToRunEvery(0).Weeks().On(DayOfWeek.Thursday).At(16, 09);

            //Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<AOPCostSummeryJob>()).ToRunNow().AndEvery(1).Minutes();

        }



    }

   


}
