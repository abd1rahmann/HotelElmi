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
            foreach (var booking in _dbContext.Booking)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine($"Bokning : { booking.CheckInDate} till {booking.CheckOutDate}");
                Console.WriteLine("============================================================");
            }

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new BookingMenu();
                backTo.BookingMenuChoice();
            }
            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
