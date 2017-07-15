using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Nemiro.OAuth;
using System.Text;
using System.Threading.Tasks;

namespace iStepPhone.SMS
{
    public class SMS
    {
        Sender sender;
        Recipient recipient;
        /// <summary>
        /// Send SMS via gmail.com. You shoud write down body in console.
        /// </summary>
        /// <returns>Work report</returns>
        public string Send()
        {
            MailAddress From = new MailAddress(sender.Adress);
            MailAddress To = new MailAddress(recipient.Adress);
            Console.Write("Please write the body: ");
            MailMessage message = new MailMessage(From, To)
            {
                Body = Console.ReadLine()
            };
            SmtpClient client = new SmtpClient("aspmx.l.google.com", 25)
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
        /// <summary>
        /// Send SMS via gmail.com. 
        /// </summary>
        /// <param name="body">Main text</param>
        /// <returns>Work report</returns>
        public string Send(string body)
        {
            MailAddress From = new MailAddress(sender.Adress);
            MailAddress To = new MailAddress(recipient.Adress);
            MailMessage message = new MailMessage(From, To)
            {
                Body = body
            };
            SmtpClient client = new SmtpClient("aspmx.l.google.com", 25)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SenderAdress">Sender adress. Example: sender@gmail.com</param>
        /// <param name="SenderPassword">Sender password. Example: 12345678</param>
        /// <param name="RecipientAdress">Recipient adress. Example: recipient@gmail.com</param>
        public SMS(string SenderAdress, string SenderPassword, string RecipientAdress)
        {
            sender = new Sender(SenderAdress, SenderPassword);
            recipient = new Recipient(RecipientAdress);
        }
    }

}
