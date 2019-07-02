using System;
using System.Collections.Generic;

namespace SolsticeAPIChallenge.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public int PerPhoneNumber { get; set; }
        public int WorkPhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
