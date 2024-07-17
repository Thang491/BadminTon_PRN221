using System;
using System.Collections.Generic;

namespace BadMintonData.Models
{
    public partial class CourtSlot
    {
        public CourtSlot()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Bookings = new HashSet<Booking>();
        }

        public Guid SlotId { get; set; }
        public Guid CourtId { get; set; }
        public DateTime SlotStartTime { get; set; } 
        public DateTime SlotEndTime { get; set; } 
        public bool Status { get; set; }
        public string SlotPrice { get; set; } = null!;

        public virtual Court Court { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
