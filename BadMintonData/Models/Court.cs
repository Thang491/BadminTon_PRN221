using System;
using System.Collections.Generic;

namespace BadMintonData.Models
{
    public partial class Court
    {
        public Court()
        {
            Bookings = new HashSet<Booking>();
            CourtSlots = new HashSet<CourtSlot>();
        }

        public Guid CourtId { get; set; }
        public string CourtName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string Descrip { get; set; }
        public string OwnerName { get; set; }
        public string Seats { get; set; }
        public string BadmintonNet { get; set; }
        public string Area { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<CourtSlot> CourtSlots { get; set; }
    }
}
