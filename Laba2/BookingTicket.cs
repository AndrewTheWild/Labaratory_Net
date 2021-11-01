using System;
using System.Collections.Generic;

#nullable disable

namespace Laba2
{
    public partial class BookingTicket
    {
        public int Id { get; set; }
        public int PassegerId { get; set; }

        public virtual Passeger Passeger { get; set; }
    }
}
