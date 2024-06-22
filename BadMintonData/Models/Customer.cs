using System;
using System.Collections.Generic;

namespace BadMintonData.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid CustomerId { get; set; }
        public bool Gender { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; }
        public bool IsActive { get; set; }
        public string CCCD { get; set; }
        public DateTime Dob { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
