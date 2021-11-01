using System;
using System.Collections.Generic;

#nullable disable

namespace Laba2
{
    public partial class Passeger
    {
        public Passeger()
        {
            BookingTickets = new HashSet<BookingTicket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string HomeAddress { get; set; }

        public virtual ICollection<BookingTicket> BookingTickets { get; set; }
    }
}
