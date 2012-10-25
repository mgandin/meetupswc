using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace SchedulerDotNet
{
    public class MailService
    {
        private static MailService instance;
        private const string NETWORK = "smtp.gmail.com";
        private const int PORT = 587;
        private const string FROM = "user@gmail.com";
        private const bool ENABLE_TLS = true;
        private const string ACCOUNT = "productionuser@gmail.com";
        private const string ACCOUNT_PWD = "productionpwd";

        private MailService()
        {
        }

        public static MailService GetInstance()
        {
            if (instance == null)
                instance = new MailService();
            return instance;
        }

        public void SendMail(String address, String subject, String message)
        {
            try
            {
                SmtpClient mailClient = new SmtpClient(NETWORK, PORT);
                mailClient.EnableSsl = ENABLE_TLS;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(ACCOUNT, ACCOUNT_PWD);
                mailClient.Credentials = credentials;
                MailMessage mail = new MailMessage(FROM, address, subject, message);
                mailClient.Send(mail);
            }
            catch (SmtpException smptEx)
            {
                Console.WriteLine("send failed, exception: " + smptEx);
            }
        }
    }
}
