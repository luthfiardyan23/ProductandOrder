using System;
using System.Collections.Generic;

#nullable disable

namespace ProductQLDotnet6.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
