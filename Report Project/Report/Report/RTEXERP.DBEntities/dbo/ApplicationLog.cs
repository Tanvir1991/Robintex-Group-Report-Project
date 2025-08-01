using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class ApplicationLog
    {
        public long ApplicationLogId { get; set; }
        public string ActionUrl { get; set; }
        public DateTime? LogDate { get; set; }
        public string ClientIp { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RequestUser { get; set; }
        public string RequestDetail { get; set; }
        public string QueryStringParams { get; set; }
        public string ErrorDetail { get; set; }
        public string UserAgent { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string HttpMethod { get; set; }
        public string SessionId { get; set; }
        public string OrganizationId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
