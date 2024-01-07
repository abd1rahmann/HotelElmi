using  AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class UpdateBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update()
        {
            Console.WriteLine("Uppdatera en bokning");
            Console.WriteLine("=====================");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new BookingMenu();
                backTo.BookingMenuChoice();
            }

            foreach (var booking in _dbContext.Booking)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine($"Id: {booking.BookingId}");
                Console.WriteLine($"Incheckning: {booking.CheckInDate}");
                Console.WriteLine($"Utcheckning: {booking.CheckOutDate}");
                Console.WriteLine("============================================\n");

            }
            

            Console.WriteLine("Välj Id på den bokningen som du vill uppdatera");
            int bookingIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var bookingToUpdate = _dbContext.Booking.First(b => b.BookingId == bookingIdToUpdate);

            if (bookingIdToUpdate == null)
            {
                Console.WriteLine("obefintlig bokning! Välj en befintlig bokning.");
                
            }

            Console.WriteLine("Ange nya incheckningsdatum (yyyy-MM-dd): ");
            string checkInDateString = Console.ReadLine();
            DateTime bookingCheckInDateToUpdate = DateTime.ParseExact(checkInDateString, "yyyy-MM-dd", null);

            Console.WriteLine("Ange nya utcheckningsdatum (yyyy-MM-dd): ");
            string checkOutDateString = Console.ReadLine();
            DateTime bookingCheckOutDateToUpdate = DateTime.ParseExact(checkOutDateString, "yyyy-MM-dd", null);

            bookingToUpdate.CheckInDate = bookingCheckInDateToUpdate;
            bookingToUpdate.CheckOutDate = bookingCheckOutDateToUpdate;
            
            _dbContext.SaveChanges();

            Console.WriteLine("Uppdateringen är genomförd!");
            Console.ReadLine();
            

            Console.Clear();
            
            
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }

}
