using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace ChallengeIT.Services.Services
{
    public class Email
    {
        public static void SendEmail()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ChallengeITInfoTrack@gmail.com", "Q!W@E#R$t5");

            MailMessage mm = new MailMessage("ChallengeITInfoTrack@infotrack.com.au", "rocco.smit@infotrack.com.au", "Challenge", "You have been challenged \n\r http://localhost:57390/api/values");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}
