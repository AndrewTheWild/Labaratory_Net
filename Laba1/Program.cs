using System;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlService = new SqlService();

            sqlService.InitConnection("", "", "BookingTickets");
            sqlService.PrintTable("Passeger");
            sqlService.PrintBookingTickets();
           // sqlService.InsertTable();
            sqlService.PrintTable("Train");
            //sqlService.DeleteData("Train");
          //  sqlService.PrintTable("Train");
        }
    }
}
