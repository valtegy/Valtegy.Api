using System;

namespace Valtegy.Domain.DTOs
{
    public class AuthenticateDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Token { get; set; }

        public AuthenticateDTO(Entities.Users user, string token)
        {
            FirstName = user.FirstName;
            MiddleName = user.MiddleName;
            LastName1 = user.LastName1;
            LastName2 = user.LastName2;
            Username = user.UserName;
            PhoneNumber = user.PhoneNumber;
            EmailConfirmed = user.EmailConfirmed;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            Token = token;
        }
    }
}
