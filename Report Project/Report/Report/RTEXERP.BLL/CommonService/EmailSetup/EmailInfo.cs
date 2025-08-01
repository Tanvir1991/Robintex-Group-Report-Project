using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.CommonService.EmailSetup
{
   public class EmailInfo
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public MailSendType MailSendType  { get; set; }
    }

  public enum MailSendType
{ 
    To,CC,BC

}
}
