using  AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace  AbdiHotelConsole.GuestRepository
{
    public class GuestMenu
    {

        public static void GuestMenuChoice() 
        {
            Console.WriteLine("Gäst\n\n");
            Console.WriteLine("1. Lägg till gäst\n2. Visa gäst\n3. Uppdatera information om gäst\n4. Ta bort gäst");

            var choice = Console.ReadLine();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
           
            options.UseSqlServer("Server=localhost;Database=AbdiHotel;Trusted_Connection=True;TrustServerCertificate=true;");
            using (var dbContext = new ApplicationDbContext(options.Options))
            
            {
                switch (choice)
                {
                    case "1":
                        var showGuest = new ShowGuest(dbContext);
                        showGuest.DisplayGuest();
                        break;
                    default:
                        break;
                        /*case "1":
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
                            break;*/
                }
            }
        }
    }
}
