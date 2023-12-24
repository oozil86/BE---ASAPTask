namespace ASAP.Domain.Services
{
    public interface IEmailService
    {
        public void SendMail(string Email);
        public void SendMails(List<string> Emails);
    }
}
