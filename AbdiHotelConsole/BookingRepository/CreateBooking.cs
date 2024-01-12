using AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.BookingRepository
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
            Console.WriteLine("Ny boknig                 ||Enkelrum/kväll 1500SEK||  ||Dubbelrum per kväll 20000SEK||");
            Console.WriteLine("\n====================================================================================");
            
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new BookingMenu();
                backTo.BookingMenuChoice();
            }
            Console.WriteLine($"Gäster\n");

            var inActiveGuests =
              (from g in _dbContext.Guest

               where g.IsActive == false
               select g).ToList();

            foreach (var guest in inActiveGuests)
            {
                Console.WriteLine("\n===========================================================================");
                Console.WriteLine($"ID: {guest.GuestId}\nNamn: {guest.GuestLastName}, {guest.GuestFirstName}");
                Console.WriteLine("===========================================================================\n");
            }
            Console.Write("\nAnge gästens Id: ");

            int guestId = 0;

            while(!int.TryParse(Console.ReadLine(), out guestId))
            {
                Console.WriteLine("The input is invalid. Please type a number");
            }

            var guestIdToBook = _dbContext.Guest.FirstOrDefault(g => g.GuestId == guestId);

            if (guestIdToBook != null)
            {
                booking.GuestId = guestIdToBook.GuestId;
                guestIdToBook.IsActive = true;
            }
            else
            {
                Console.WriteLine("\nGäst ID som du söker finns inte. Välj igen!");
                Console.ReadLine();

            }
            Console.WriteLine("==============================================================================\n==============================================================================\n==============================================================================\n==============================================================================");
            Console.WriteLine($"Samtliga rum\n");

            var availableRooms =
             (from r in _dbContext.Room

              where r.IsAvailable == true
              select r).ToList();

            foreach (var room in availableRooms)
            {
                Console.WriteLine("\n===========================================================================");
                Console.WriteLine($"ID: {room.RoomId}\nNummer: {room.RoomNumber}\nTyp av rum:{room.TypeOfRoom}");
                Console.WriteLine("============================================================================\n");
            }

            Console.WriteLine("\nAnge rummets Id: ");
            var roomId = Convert.ToInt32(Console.ReadLine());
            var roomIdToBook = _dbContext.Room.FirstOrDefault(r => r.RoomId == roomId);

            if (roomIdToBook != null)
            {
                booking.RoomId = roomIdToBook.RoomId;
                roomIdToBook.IsAvailable = false;

            }

            else
            {
                Console.WriteLine("\nRum ID som du söker finns inte. Välj igen!");
                Console.ReadLine ();
            }

            Console.WriteLine("\nAnge antal nätter för bokningen:");
            var numberOfNights = Convert.ToInt32(Console.ReadLine());

            booking.CheckInDate = DateTime.Now;

            booking.CheckOutDate = booking.CheckInDate.AddDays(numberOfNights);

            var priceToPay = numberOfNights * roomIdToBook.PricePerNight;

            booking.Price = (double)priceToPay;


            Console.WriteLine($"\nPris: {priceToPay} SEK");
            Console.WriteLine("\nVälj 1 för att betala nu eller 2 för att få betalningen på faktura:");
            string payMent = Console.ReadLine();

            if ( payMent == "1" ) 
            { 
            booking.IsPaid = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBetalningen är genomförd!$$$");
                Console.ResetColor();
            }
            else if ( payMent == "2" ) 
            {
                booking.IsPaid = false;
                Console.WriteLine("\nGästen ska få faktura. Välj 'Faktura' i huvudmenyn och sedan 'Skapa faktura' för att registrera en faktura.");
            }
            else if ( payMent != "2" || payMent != "1" ) 
            {
                Console.WriteLine("Välj ett av alternativen");
                Console.ReadLine();
            }

            Console.WriteLine($"\nBokning skapad för {guestIdToBook.GuestFirstName} {guestIdToBook.GuestLastName} och rum {roomIdToBook.RoomNumber} från {booking.CheckInDate.ToShortDateString()} - {booking.CheckOutDate.ToShortDateString()}.");
            Console.ReadLine();



            _dbContext.Booking.Add(booking);
            _dbContext.SaveChanges();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
