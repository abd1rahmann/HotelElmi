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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Ta bort en bokning");
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
                        Console.ReadLine();

                        Console.Clear();
                        var rec = new Reception();
                        rec.ReceptionMenu();

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
