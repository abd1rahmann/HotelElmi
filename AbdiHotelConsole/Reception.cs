using  AbdiHotelConsole.Data;
using  AbdiHotelConsole.GuestRepository;
using AbdiHotelLibrary;
using  AbdiHotelConsole.BookingRepository;
using  AbdiHotelConsole.Room;
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
            Console.WriteLine("+-------------------+");
            Console.WriteLine("|   Abdi Hotel     |");
            Console.WriteLine("+-------------------+\n");

            Console.WriteLine("1. Gäst\n2. Rum\n3. Bokning\n4. Faktura");
            

            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice) 
            {
                case "1":
                    GuestMenu.GuestMenuChoice();
                    break; 
                
                case "2":
                    RoomMenu.RoomMenuChoice();
                    break; 
               
                case "3":
                    BookingMenu.BookingMenuChoice();
                    break;
                    
                case "4":
                    InvoiceMenu.InvoiceGuestMenu();
                    break;
            }
        }
    }
}
