using System;
using System.Collections.Generic;

namespace BadMintonData.Models
{
    public partial class BookingDetail
    {
        public Guid BookingDetailId { get; set; }
        public Guid BookingId { get; set; }
        public string CustomerId { get; set; } = null!;
        public Guid SlotId { get; set; }
        public string CourtId { get; set; } = null!;

        public virtual Booking Booking { get; set; } = null!;
        public virtual CourtSlot Slot { get; set; } = null!;
    }
}
