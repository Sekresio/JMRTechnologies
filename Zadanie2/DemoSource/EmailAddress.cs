namespace Zadanie2.DemoSource
{
    public class EmailAddress
    {
        public EmailAddress(string email, string emailType)
        {
            Email = email;
            EmailType = emailType;
        }

        public string Email { get; set; }
        public string EmailType { get; set; }
    }
}