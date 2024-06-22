using System;
using System.Collections.Generic;

namespace BadMintonData.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public Guid BookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CourtId { get; set; }
        public Guid SlotId { get; set; }
        public string PaymentType { get; set; } = null!;
        public DateTime BookingDate { get; set; }
        public bool PaymentStatus { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Court Court { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual CourtSlot Slot { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
