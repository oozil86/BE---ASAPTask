namespace ASAP.Domain.Model.Client
{
    public class EditClientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public Guid Reference { get; set; }
    }
}
