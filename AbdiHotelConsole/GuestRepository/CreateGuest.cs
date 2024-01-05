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
    public class CreateGuest
    {
        private readonly ApplicationDbContext _dbContext;

        
        public CreateGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public void CreateNewGuest()
        {
            
            var guest = new Guest();

            Console.WriteLine("Lägg till ny gäst\n\n");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new GuestMenu();
                backTo.GuestMenuChoice();
            }
          
            
               
                Console.Write("Ange gästens förnamn: ");
                string guestFirstName = Console.ReadLine();

                Console.Write("Ange gästens efternamn: ");
                string guestLastName = Console.ReadLine();

                Console.Write("Ange gästens e-postadress: ");
                string guestEmail = Console.ReadLine();

                Console.Write("Ange gästens adress: ");
                string address = Console.ReadLine();



                guest.GuestFirstName = guestFirstName;
                guest.GuestLastName = guestLastName;
                guest.GuestEmail = guestEmail;
                guest.Address = address;

                _dbContext.Guest.Add(guest);
                _dbContext.SaveChanges();

                 Console.Clear();
                 var reception = new Reception();
                 reception.ReceptionMenu();
            
        }

    }
}











