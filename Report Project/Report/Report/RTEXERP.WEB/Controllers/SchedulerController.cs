using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.BLL.CommonService.EmailSetup;
using RTEXERP.WEB.Scheduler.SchedulerProcess.SchedulerJobs;

namespace RTEXERP.WEB.Controllers
{
    public class SchedulerController : Controller
    {
      public readonly  IEmailSenderCS _emailSender;
        public SchedulerController(IEmailSenderCS _emailSender)
        {
            this._emailSender = _emailSender;
        }
        public IActionResult Index()
        {
            Knitting_Daily_Notification_JOB job = new Knitting_Daily_Notification_JOB(_emailSender);
            job.Execute();
            return Content("Done"+DateTime.Now.ToLongDateString());
        }
    }
}