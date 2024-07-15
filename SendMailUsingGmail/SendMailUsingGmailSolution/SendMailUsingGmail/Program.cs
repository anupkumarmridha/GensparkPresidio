using System.Net.Mail;
using System.Net;

namespace SendMailUsingGmail
{
    internal class Program
    {
        static void SendEmail()
        {
            string senderEmail = "anupkumarmridha.tech@gmail.com";
            string senderPassword = ""; // Use app password if 2FA is enabled

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add("anupkumarmridha.net@gmail.com");
            mail.Subject = "Subject of the Email";
            mail.Body = "Body of the Email";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SendEmail();
        }
    }
}
