using AbdiHotelConsole.BookingRepository;
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
    public class UpdateGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update() 
        {
           
                Console.WriteLine("Uppdatera en gäst");
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
                    Console.WriteLine($"Id: {guest.GuestId}");
                    Console.WriteLine($"Förnamn: {guest.GuestFirstName}");
                    Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                    Console.WriteLine($"E-mail: {guest.GuestEmail}");
                    Console.WriteLine($"Adress: {guest.Address}");
                    Console.WriteLine($"Status: {guest.IsActive}");
                    Console.WriteLine("====================");
                }
                Console.Clear();

                Console.WriteLine("Välj Id på den gäst som du vill uppdatera");
                var guestIdToUpdate = Convert.ToInt32(Console.ReadLine());
                var guestToUpdate = _dbContext.Guest.First(p => p.GuestId == guestIdToUpdate);

                
                Console.WriteLine("Ange förnamn: ");
                var guestFirstNameUpdate = Console.ReadLine();

                Console.WriteLine("Ange efternamn: ");
                var guestLastNameUpdate = Console.ReadLine();

                Console.WriteLine("Ange e-mail: ");
                var guestEmailUpdate = Console.ReadLine();

                Console.WriteLine("Ange adress: ");
                var guestAddressUpdate = Console.ReadLine();

                Console.WriteLine("Ange gästens status (aktiv/ej aktiv): ");
                string guestIsActiveUpdate = Console.ReadLine();

            
            if (guestIsActiveUpdate.ToLower() == "aktiv")
            {
                guestToUpdate.IsActive = true;
            }
            else if (guestIsActiveUpdate.ToLower() == "ej aktiv")
            {
                guestToUpdate.IsActive = false;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Ange endast 'aktiv' eller 'ej aktiv'.");
                return; 
            }

                guestToUpdate.GuestFirstName = guestFirstNameUpdate;
                guestToUpdate.GuestLastName = guestLastNameUpdate;
                guestToUpdate.GuestEmail = guestEmailUpdate;
                guestToUpdate.Address = guestAddressUpdate;

                _dbContext.SaveChanges();

            Console.WriteLine("Uppdateringen är genomförd!");

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
