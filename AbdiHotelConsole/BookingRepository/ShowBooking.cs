using  AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class ShowBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public ShowBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayBooking() 
        {
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Se betalda bokningar");
            Console.WriteLine("\t2. Se obetalda bokningar");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");

            bool run = true;
            while (run)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var paidBookings = _dbContext.Booking.Where(b => b.IsPaid == true).ToList();
                        foreach (var booking in paidBookings)
                        {
                            Console.WriteLine("==================================================================================");
                            Console.WriteLine($"Bokning ID {booking.BookingId} : {booking.CheckInDate} till {booking.CheckOutDate}");
                            Console.WriteLine("==================================================================================");
                        }
                        break;

                        case "2":
                        var unPaidBookings = _dbContext.Booking.Where(b => b.IsPaid == false).ToList();
                        foreach(var booking in unPaidBookings)
                        {
                            Console.WriteLine("===================================================================================");
                            Console.WriteLine($"Bokning ID {booking.BookingId} : {booking.CheckInDate} till {booking.CheckOutDate}");
                            Console.WriteLine("===================================================================================");
                        }
                        break;

                    case "0":
                        Console.Clear();
                        var reception = new Reception();
                        reception.ReceptionMenu();
                        break;
                }
            }
        }
    }
}
