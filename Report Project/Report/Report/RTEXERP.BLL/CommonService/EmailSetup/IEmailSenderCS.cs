using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RTEXERP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.CommonService.EmailSetup
{
    public interface IEmailSenderCS
    {
        Task SendEmailAsync(List<EmailInfo> email, string subject, string htmlMessage,bool isAddAttachment, string attachmentLink);
        Task SendEmailAsyncAttachmentInBody(List<EmailInfo> email, string subject, string htmlMessage, bool isAddAttachment, string attachmentLink);
    }

    public class EmailSenderCS : IEmailSenderCS
    {
        EmailSettings _emailSettings = new EmailSettings();

        public  Task SendEmailAsync(List<EmailInfo> email, string subject, string message, bool isAddAttachment,string attachmentLink)
        {
            _emailSettings.MailPort =Convert.ToInt32(StaticConfigs.GetConfig("MailPort"));
            _emailSettings.MailServer = StaticConfigs.GetConfig("MailServer");
            _emailSettings.Password = StaticConfigs.GetConfig("Password");
            _emailSettings.Sender = StaticConfigs.GetConfig("Sender");
            _emailSettings.SenderName = StaticConfigs.GetConfig("SenderName");
             try
            {
                // Credentials
                var credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                if (isAddAttachment)
                {
                    Attachment data = new Attachment(attachmentLink, MediaTypeNames.Application.Pdf);
                    // your path may look like Server.MapPath("~/file.ABC")
                    mail.Attachments.Add(data);
                }
                foreach(var em in email)
                {
                    if (em.MailSendType==MailSendType.To)
                    {
                        mail.To.Add(new MailAddress(em.EmailAddress,em.Name));
                    }
                    else if(em.MailSendType == MailSendType.CC)
                    {
                        mail.CC.Add(new MailAddress(em.EmailAddress, em.Name));
                    }
                    else
                    {
                        mail.Bcc.Add(new MailAddress(em.EmailAddress, em.Name));
                    }
                    
                }
              

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = _emailSettings.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = _emailSettings.MailServer,
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.SendCompleted += (s, e) => {
                    //delete attached files
                      System.IO.File.Delete(attachmentLink);
                };

                // Send it...         
                client.Send(mail);

                client.Dispose();
                mail.Attachments.Dispose();
                mail.Dispose();
              
               
            
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task SendEmailAsyncAttachmentInBody(List<EmailInfo> email, string subject, string message, bool isAddAttachment, string filePath )
        {

            _emailSettings.MailPort = Convert.ToInt32(StaticConfigs.GetConfig("MailPort"));
            _emailSettings.MailServer = StaticConfigs.GetConfig("MailServer");
            _emailSettings.Password = StaticConfigs.GetConfig("Password");
            _emailSettings.Sender = StaticConfigs.GetConfig("Sender");
            _emailSettings.SenderName = StaticConfigs.GetConfig("SenderName");

            try
            {
                // Credentials
                var credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                if (isAddAttachment)
                {
                    /*
                    LinkedResource LinkedImage = new LinkedResource(attachmentLink);
                    LinkedImage.ContentId = "Report";
                    //Added the patch for Thunderbird as suggested by Jorge
                    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Tiff);
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                       message,
                         null, "text/html");

                    htmlView.LinkedResources.Add(LinkedImage);
                    mail.AlternateViews.Add(htmlView);
                    */
                    
                        // your path may look like Server.MapPath("~/file.ABC")
                        //mail.Attachments.Add(data);
                }
                foreach (var em in email)
                {
                    if (em.MailSendType == MailSendType.To)
                    {
                        mail.To.Add(new MailAddress(em.EmailAddress, em.Name));
                    }
                    else if (em.MailSendType == MailSendType.CC)
                    {
                        mail.CC.Add(new MailAddress(em.EmailAddress, em.Name));
                    }
                    else
                    {
                        mail.Bcc.Add(new MailAddress(em.EmailAddress, em.Name));
                    }

                }


                // Smtp client
                var client = new SmtpClient()
                {
                    Port = _emailSettings.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = _emailSettings.MailServer,
                    EnableSsl = true,
                    Credentials = credentials
                };

                //using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
                //{
                //    AlternateView alternate = new AlternateView((Stream)sr.BaseStream, "message/rfc822");
                //    mail.AlternateViews.Add(alternate);

                //    client.Send(mail);
                //}

                // byte[] file = File.ReadAllBytes(filePath);
                var decoded_text = new StringBuilder();
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line != "Content-Transfer-Encoding: base64") continue;

                        reader.ReadLine(); //chew up the blank line
                        while ((line = reader.ReadLine()) != String.Empty)
                            if (line != null)
                                decoded_text.Append(
                                    Encoding.UTF8.GetString(
                                        Convert.FromBase64String(line)));
                        break;
                    }
                }

                message += "</br>";
                message += decoded_text.ToString();
                message += "</br></br><span style='color:red;'><b>*** This is a software generated email, please do not reply ***</b></span>";

                mail.Body = message;//decoded_text.ToString();
                client.Send(mail);
                //using (MemoryStream memory = new MemoryStream(file))
                //{
                //    AlternateView view = new AlternateView(memory);
                //    view.ContentType = new ContentType("message/rfc822");
                //    mail.AlternateViews.Clear();
                //    mail.AlternateViews.Add(view);
                //    client.Send(mail);
                //}
                // Send it...         

                //  mail.AlternateViews.Clear();
                client.Dispose();
                //mail.Attachments.Dispose();
                mail.Dispose();



            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error != null)
            {
                var mes = "Mail sent successfully";
            }
        }
    }
}
