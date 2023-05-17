using System;

namespace Valtegy.Domain.ViewModels
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string CountryPhoneCode { get; set; }
        public string CountryCode { get; set; }
        public string LanguageCode { get; set; }
        public string CurrencyCode { get; set; }
        public int PersonType { get; set; }
        public bool IsLender { get; set; }
    }
}
