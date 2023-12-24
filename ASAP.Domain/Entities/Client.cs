using ASAP.Domain.Contracts;
using System.Runtime.CompilerServices;

namespace ASAP.Domain.Entities
{
    public class Client : AggregateRoot<long>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public long PhoneNumber { get; private set; }



        public static Client Create(string firstName, string lastName, string email, long phoneNumber)
       => new() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber };

        public Client Edit(string firstName, string lastName, string email, long phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            return this;
        }

    }
}
