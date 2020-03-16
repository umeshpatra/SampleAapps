sing Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace SendMail
{
    class Program
    {
        //static string smtpAddress = "smtp.gmail.com";
        //static int portNumber = 587;
        //static bool enableSSL = true;
        //static string emailFromAddress = "x@gmail.com"; //Sender Email Address  
        //static string password = "x"; //Sender Password  
        //static string emailToAddress = "x@gmail.com"; //Receiver Email Address  
        //static string subject = "Hello";
        //static string body = "Hello, This is Email sending test using gmail.";
        static void Main(string[] args)
        {
            try
            {
               var localpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var filepath = Path.Join(localpath, "settings.json");
                EmailSetting emailSetting = null;
                using (StreamReader file = File.OpenText(filepath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    emailSetting = (EmailSetting)serializer.Deserialize(file, typeof(EmailSetting));
                }

                SendEmail(emailSetting);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SendEmail(EmailSetting emailSetting)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailSetting.emailFromAddress);
                mail.To.Add(emailSetting.emailToAddress);
                mail.Subject = emailSetting.subject;
                mail.Body = emailSetting.body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(emailSetting.smtpAddress, 
                    int.Parse(emailSetting.portNumber)))
                {
                    smtp.Credentials = new NetworkCredential(emailSetting.emailFromAddress, emailSetting.password);
                    smtp.EnableSsl = bool.Parse(emailSetting.enableSSL);
                    smtp.Send(mail);
                }
            }
        }
    }
}
