using  AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Uppdatera bokning");
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
                        foreach (var booking in _dbContext.Booking)
                        {
                            Console.WriteLine("\n==========================================");
                            Console.WriteLine($"Id: {booking.BookingId}");
                            Console.WriteLine($"Incheckning: {booking.CheckInDate}");
                            Console.WriteLine($"Utcheckning: {booking.CheckOutDate}");
                            Console.WriteLine("============================================\n");

                        }


                        Console.WriteLine("Välj Id på den bokningen som du vill uppdatera");
                        int bookingId = 0;

                        while (!int.TryParse(Console.ReadLine(), out bookingId))
                        {
                            Console.WriteLine("Inmatningen är ogiltig. Vänligen ange ett nummer");
                        }
                        var bookingToUpdate = _dbContext.Booking.FirstOrDefault(b => b.BookingId == bookingId);

                        if (bookingToUpdate == null)
                        {
                            Console.WriteLine("obefintlig bokning! Välj en befintlig bokning.");

                        }

                        Console.WriteLine("Ange nya incheckningsdatum (yyyy-MM-dd): ");
                        string checkInDateString = Console.ReadLine();
                        DateTime bookingCheckInDateToUpdate = DateTime.ParseExact(checkInDateString, "yyyy-MM-dd", null);

                        Console.WriteLine("Ange nya utcheckningsdatum (yyyy-MM-dd): ");
                        string checkOutDateString = Console.ReadLine();
                        DateTime bookingCheckOutDateToUpdate = DateTime.ParseExact(checkOutDateString, "yyyy-MM-dd", null);

                        if (string.IsNullOrWhiteSpace(checkInDateString) || string.IsNullOrWhiteSpace(checkOutDateString))
                        {
                            Console.WriteLine("Ogiltigt, försök igen. Alla fält måste fyllas i.");
                        }

                        bookingToUpdate.CheckInDate = bookingCheckInDateToUpdate;
                        bookingToUpdate.CheckOutDate = bookingCheckOutDateToUpdate;

                        _dbContext.SaveChanges();

                        Console.WriteLine("Uppdateringen är genomförd!");
                        Console.ReadLine();

                        break;

                    case "0":

                        Console.Clear();
                        var reception = new Reception();
                        reception.ReceptionMenu();
                        break;

                    default:
                        Console.WriteLine("Fel inmatning!");
                        break;
                }
            }
        }
    }
}
