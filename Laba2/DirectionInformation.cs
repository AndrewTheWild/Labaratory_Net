using System;
using System.Collections.Generic;

#nullable disable

namespace Laba2
{
    public partial class DirectionInformation
    {
        public int Id { get; set; }
        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public decimal Cost { get; set; }
        public bool SurchargeForUrgency { get; set; }
        public bool SurchargeForWagonType { get; set; }
    }
}
