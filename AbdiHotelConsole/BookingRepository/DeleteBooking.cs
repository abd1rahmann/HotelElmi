using  AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class DeleteBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete() 
        {
                Console.WriteLine("Ta bort en bokning");
                Console.WriteLine("=================================================================================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new BookingMenu();
                backTo.BookingMenuChoice();
            }

            Console.WriteLine("Välj Id på den bokning som du vill ta bort");

                foreach (var booking in _dbContext.Booking)
                {
                    Console.WriteLine($": {booking.BookingId}");

                }


                var bookingIdToDelete = Convert.ToInt32(Console.ReadLine());
                var bookingToDelete = _dbContext.Booking.First(b => b.BookingId == bookingIdToDelete);
                
                _dbContext.Booking.Remove(bookingToDelete);
                _dbContext.SaveChanges();
                
                Console.WriteLine("Bokningen har tagits bort");

                

                Console.Clear();
                var reception = new Reception();
                reception.ReceptionMenu();
        }
    }
}
