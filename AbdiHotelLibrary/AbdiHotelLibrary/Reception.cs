using AbdiHotelConsole.Data;
using AbdiHotelLibrary;
using AbdiHotelLibrary.AbdiHotelLibrary.BookingRepository;
using AbdiHotelLibrary.AbdiHotelLibrary.GuestRepository;
using AbdiHotelLibrary.AbdiHotelLibrary.InvoiceRepository;
using AbdiHotelLibrary.AbdiHotelLibrary.RoomRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AbdiHotelLibrary
{
    public class Reception
    {

        public static void ReceptionMenu () 
        {
            Console.WriteLine("+-------------------+");
            Console.WriteLine("|   Abdi Hotel     |");
            Console.WriteLine("+-------------------+");

            Console.WriteLine("1. Gäst\n2. Rum\n3. Bokning\n4. Faktura");

            string choice = Console.ReadLine();
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
