namespace iStepPhone.SMS
{
    public class Sender
    {
        public string Adress { get; set; }
        public string Password { get; set; }
        public Sender(string adress, string password)
        {
            Adress = adress;
            Password = password;
        }
    }
}