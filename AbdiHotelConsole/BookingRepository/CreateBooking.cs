using  AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class CreateBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void NewBooking()
        {

                var booking = new Booking();
            Console.WriteLine("");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new BookingMenu();
                backTo.BookingMenuChoice();
            }
            Console.WriteLine($"Samtliga gäster\n");

            var activeGuests =
              (from g in _dbContext.Guest
              
               where g.IsActive == true
               select g).ToList();

            foreach (var guest in activeGuests)
            {
                Console.WriteLine($"ID: {guest.GuestId}\nNamn: {guest.GuestLastName}, {guest.GuestFirstName}\n");
            }
                Console.Write("\nAnge gästens Id: ");



                var guestId = Convert.ToInt32(Console.ReadLine());
                var guestIdToBook = _dbContext.Guest.FirstOrDefault(g => g.GuestId  == guestId);

                if (guestIdToBook != null)
                {
                    booking.GuestId = guestIdToBook.GuestId;
                }
                else 
                {
                    Console.WriteLine("Gäst ID som du söker finns inte.");
                return;
                }
            Console.WriteLine("=================\n");
            Console.WriteLine($"Samtliga rum\n");
            
            var isAvail = new Room();
            

            
            foreach (var room in _dbContext.Room)
            {
                Console.WriteLine($"ID: {room.RoomId}\nNummer: {room.RoomNumber}\nTyp av rum:{room.TypeOfRoom}\n");
            }
           
            Console.WriteLine("Ange rummets Id: ");
                var roomId = Convert.ToInt32(Console.ReadLine());
                var roomIdToBook = _dbContext.Room.FirstOrDefault(r => r.RoomId == roomId);
                
                if (roomIdToBook != null) 
                {
                    booking.RoomId = roomIdToBook.RoomId;

                }

                else
                {
                    Console.WriteLine("Rum ID som du söker finns inte.");
                return;
                }

            roomIdToBook.IsAvailable = false;


            Console.WriteLine("Ange antal nätter för bokningen:");
            var numberOfNights = Convert.ToInt32(Console.ReadLine());

            booking.CheckInDate = DateTime.Now;

            booking.CheckOutDate = booking.CheckInDate.AddDays(numberOfNights);

            Console.WriteLine($"Bokning skapad för {guestIdToBook.GuestFirstName} {guestIdToBook.GuestLastName} och rum {roomIdToBook.RoomNumber} från {booking.CheckInDate.ToShortDateString()} - {booking.CheckOutDate.ToShortDateString()}.");
            Console.ReadLine();

            guestIdToBook.IsActive = false;

                _dbContext.Booking.Add(booking);
                _dbContext.SaveChanges();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
