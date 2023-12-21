using System;
using System.Collections.Generic;

namespace RetailApp.Data.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Order> Orders { get; set; }
    }
}
