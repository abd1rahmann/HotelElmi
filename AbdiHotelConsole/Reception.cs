using  AbdiHotelConsole.Data;
using  AbdiHotelConsole.GuestRepository;
using AbdiHotelLibrary;
using  AbdiHotelConsole.BookingRepository;
using  AbdiHotelConsole.RoomRepository;
using  AbdiHotelConsole.InvoiceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace  AbdiHotelConsole
{
    public class Reception
    {

        public void ReceptionMenu () 
        {
            int run = 1;
            while (run == 1)
            {
                //var choice = Console.ReadLine();
                //var options = new DbContextOptionsBuilder<ApplicationDbContext>();
                //Console.Clear();


                Console.WriteLine(@"

     ██╗  ██╗ ██████╗ ████████╗███████╗██╗         ███████╗██╗     ███╗   ███╗██╗
     ██║  ██║██╔═══██╗╚══██╔══╝██╔════╝██║         ██╔════╝██║     ████╗ ████║██║
     ███████║██║   ██║   ██║   █████╗  ██║         █████╗  ██║     ██╔████╔██║██║
     ██╔══██║██║   ██║   ██║   ██╔══╝  ██║         ██╔══╝  ██║     ██║╚██╔╝██║██║
     ██║  ██║╚██████╔╝   ██║   ███████╗███████╗    ███████╗███████╗██║ ╚═╝ ██║██║
     ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚══════╝╚══════╝    ╚══════╝╚══════╝╚═╝     ╚═╝╚═╝
                                                                                
 
                         
");
               

                Console.WriteLine(" 1. Gäst\n 2. Rum\n 3. Bokning\n 4. Faktura");

                //options.UseSqlServer("Server=localhost;Database=AbdiHotel;Trusted_Connection=True;TrustServerCertificate=true;");
                //using (var dbContext = new ApplicationDbContext(options.Options)) 
                //{
                    string c = Console.ReadLine();
                    Console.Clear();
                    switch (c)
                    {
                        case "1":
                            var guest = new GuestMenu();
                            guest.GuestMenuChoice();
                            break;

                        case "2":
                            var room = new RoomMenu();
                            room.RoomMenuChoice();
                            break;

                        case "3":
                            var booking = new BookingMenu();
                            booking.BookingMenuChoice();
                            break;

                        case "4":
                            var invoice = new InvoiceMenu();
                            invoice.InvoiceGuestMenu();
                            break;

                        default:
                            Console.WriteLine("\nFel inmatning! Vänligen välj ett av alternativen.\n");
                            break;
                            
                    }

                //}
                    
            }
            
        }
    }
}
