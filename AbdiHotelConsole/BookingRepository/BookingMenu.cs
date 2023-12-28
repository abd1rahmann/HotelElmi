using AbdiHotelConsole.GuestRepository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class BookingMenu
    {
        public static void BookingMenuChoice() 
        {
                Console.WriteLine("Gäst\n\n");
                Console.WriteLine("1. Lägg till gäst\n2. Visa gäst\n3. Uppdatera information om gäst\n4. Ta bort gäst");

                var choice = Console.ReadLine();
                /*switch (choice)
                {
                    case "1":
                        CreateGuest.CreateNewGuest();
                        break;

                    case "2":
                        ShowGuest.DisplayGuest();
                        break;

                    case "3":
                        UpdateGuest.Update();
                        break;

                    case "4":
                        DeleteGuest.Delete();
                        break;
                }*/
         }
    }
}
