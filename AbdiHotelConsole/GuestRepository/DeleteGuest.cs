using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.GuestRepository
{
    public class DeleteGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete()
        {
            Console.WriteLine("Ta bort en gäst");
            Console.WriteLine("=====================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new GuestMenu();
                backTo.GuestMenuChoice();
            }

            foreach (var guest in _dbContext.Guest)
            {
                Console.WriteLine($"Förnamn: {guest.GuestFirstName}");
                Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                Console.WriteLine($"Efternamn: {guest.GuestEmail}");
                Console.WriteLine($"Efternamn: {guest.Address}");
                Console.WriteLine($"Efternamn: {guest.IsActive}");
            }

            Console.WriteLine("Välj Id på den gäst som du vill ta inaktivera");
            var guestIdToDelete = Convert.ToInt32(Console.ReadLine());
            var guestToDelete = _dbContext.Guest.First(p => p.GuestId == guestIdToDelete);
            guestToDelete.IsActive = false;

            Console.WriteLine("Gästen är inaktiverad!");
            _dbContext.SaveChanges();

           



            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
