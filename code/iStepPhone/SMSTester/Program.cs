using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStepPhone.SMS;

namespace SMSTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipient recipient = new Recipient("pc16v1@gmail.com");
            Sender sender = new Sender("pc16v1@gmail.com", "pc16v1pc16v1");
            Sms sms = new Sms(recipient, sender);
            sms.Send("test text");
        }
    }
}
