using AbdiHotelConsole.Data;

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

            Console.WriteLine("Ny bokning                 ||Enkelrum/kväll 1500SEK||  ||Dubbelrum per kväll 20000SEK||");
            Console.WriteLine("\n====================================================================================");

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Gör en bokning");
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

                        while (!int.TryParse(Console.ReadLine(), out guestId))
                        {
                            Console.WriteLine("Inmatningen är ogiltig. Vänligen ange ett nummer");
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
                        Console.WriteLine("==============================================================================\n");
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

                        int roomId = 0;

                        while (!int.TryParse(Console.ReadLine(), out roomId))
                        {
                            Console.WriteLine("The input is invalid. Please type a number");
                        }

                        var roomIdToBook = _dbContext.Room.FirstOrDefault(r => r.RoomId == roomId);

                        if (roomIdToBook != null)
                        {
                            booking.RoomId = roomIdToBook.RoomId;
                            roomIdToBook.IsAvailable = false;

                        }

                        else
                        {
                            Console.WriteLine("\nRum ID som du söker finns inte. Välj igen!");
                            Console.ReadLine();
                        }

                        Console.WriteLine("\nAnge antal nätter för bokningen:");
                        var numberOfNights = Convert.ToInt32(Console.ReadLine());

                        booking.CheckInDate = DateTime.Now;

                        booking.CheckOutDate = booking.CheckInDate.AddDays(numberOfNights);

                        var priceToPay = numberOfNights * roomIdToBook.PricePerNight;

                        booking.Price = (double)priceToPay;


                        Console.WriteLine($"\nPris: {priceToPay} SEK");
                        Console.WriteLine("\nVälj 1 för att betala nu eller 2 för att få betalningen på faktura");
                        string payMent = Console.ReadLine();

                        if (payMent == "1")
                        {
                            booking.IsPaid = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nBetalningen är genomförd!$$$");
                            Console.ResetColor();
                        }
                        else if (payMent == "2")
                        {
                            booking.IsPaid = false;
                            Console.WriteLine("\nGästen ska få faktura. Välj 'Faktura' i huvudmenyn och sedan 'Skapa faktura' för att registrera en faktura.");
                        }
                        else if (payMent != "2" || payMent != "1")
                        {
                            Console.WriteLine("Välj ett av alternativen");
                            Console.ReadLine();
                        }

                        if (string.IsNullOrWhiteSpace(payMent))
                        {
                            Console.WriteLine("Ogiltigt.");
                        }

                        Console.WriteLine($"\nBokning skapad för {guestIdToBook.GuestFirstName} {guestIdToBook.GuestLastName} och rum {roomIdToBook.RoomNumber} från {booking.CheckInDate.ToShortDateString()} - {booking.CheckOutDate.ToShortDateString()}.");
                        Console.ReadLine();

                        _dbContext.Booking.Add(booking);
                        _dbContext.SaveChanges();
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
