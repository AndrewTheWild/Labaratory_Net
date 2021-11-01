using System;
using System.Linq;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        { 
            using (BookingTicketsContext db = new BookingTicketsContext())
            { 
                var passegers = db.Passegers.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var passeger in passegers)
                {
                    Console.WriteLine($"{passeger.Name} {passeger.LastName} {passeger.Patronymic} {passeger.HomeAddress}");
                }

                var trains = db.Trains.ToList();
                Console.WriteLine("Список объектов:");
                foreach (var train in trains)
                {
                    Console.WriteLine($"{train.NumberTrain}: {train.Type}");
                }
            }
        }
    }
}
