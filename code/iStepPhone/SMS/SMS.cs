using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.SMS
{
    public class SMS
    {
        Sender sender;
        Recipient recipient;

        public string Send()
        {
            MailAddress From = new MailAddress(sender.Adress);
            MailAddress To = new MailAddress(recipient.Adress);
            Console.Write("Please write the body: ");
            MailMessage message = new MailMessage(From, To)
            {
                Body = Console.ReadLine()
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(sender.Adress, sender.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            try
            {
                client.Send(message);
                return "EMail was send succesfully";
            }
            catch (Exception e)
            {
                return "There is a mistake: " + e.Message;
            }
        }
        public string Send(string body)
        {
            MailAddress From = new MailAddress(sender.Adress);
            MailAddress To = new MailAddress(recipient.Adress);
            Console.Write("Please write the body: ");
            MailMessage message = new MailMessage(From, To)
            {
                Body = body
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(sender.Adress, sender.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            try
            {
                client.Send(message);
                return "EMail was send succesfully";
            }
            catch (Exception e)
            {
                return "There is a mistake: " + e.Message;
            }
        }
        public SMS(string SenderAdress, string SenderPassword, string RecipientAdress)
        {
            sender = new Sender(SenderAdress, SenderPassword);
            recipient = new Recipient(RecipientAdress);
        }
    }

}
