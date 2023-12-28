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
           
                Console.WriteLine("(U)PDATE en befintlig person");
                Console.WriteLine("=====================");

                // Vilken person ska uppdateras?
                foreach (var guest in _dbContext.Guest)
                {
                    Console.WriteLine($"Id: {guest.Id}");
                    Console.WriteLine($"Namn: {guest.GuestFirstName}");
                    Console.WriteLine($"Namn: {guest.GuestLastName}");
                    Console.WriteLine($"Namn: {guest.GuestEmail}");
                    Console.WriteLine($"Namn: {guest.Address}");
                    Console.WriteLine($"Namn: {guest.IsActive}");
                    Console.WriteLine("====================");
                }

                Console.WriteLine("Välj Id på den Person som du vill uppdatera");
                var guestIdToUpdate = Convert.ToInt32(Console.ReadLine());
                var guestToUpdate = _dbContext.Guest.First(p => p.Id == guestIdToUpdate);

                // Uppdatera korrekt person
                Console.WriteLine("Ange namn: ");
                var guestFirstNameUpdate = Console.ReadLine();

                Console.WriteLine("Ange ålder: ");
                var guestLastNameUpdate = Console.ReadLine();

                Console.WriteLine("Ange skostorlek: ");
                var guestEmailUpdate = Console.ReadLine();

                Console.WriteLine("Ange skostorlek: ");
                var guestAddressUpdate = Console.ReadLine();

                Console.WriteLine("Ange gästens status: ");
                bool guestIsActiveUpdate = true;

                string userInput = Console.ReadLine();

                if (bool.TryParse(userInput, out guestIsActiveUpdate))
                {
                    Console.WriteLine("Värdet är giltigt: " + guestIsActiveUpdate);
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Ange endast 'true' eller 'false'.");
                }


                foreach (var guest in _dbContext.Guest)
                {
                    Console.WriteLine($"{guest.GuestFirstName}\n{guest.GuestLastName}\n{guest.GuestEmail}\n{guest.Address}\n{guest.IsActive}");
                }
                Console.WriteLine("Ange Id på County");
                var guestIdUpdate = Convert.ToInt32(Console.ReadLine());
                var guestUpdate = _dbContext.Guest.First(c => c.Id == guestIdUpdate);

                // Mappar input info till rätt person
                guestToUpdate.GuestFirstName = guestFirstNameUpdate;
                guestToUpdate.GuestLastName = guestLastNameUpdate;
                guestToUpdate.GuestEmail = guestEmailUpdate;
                guestToUpdate.Address = guestAddressUpdate;
                guestToUpdate.IsActive = guestIsActiveUpdate;
                _dbContext.SaveChanges();
           

        }
    }
}
