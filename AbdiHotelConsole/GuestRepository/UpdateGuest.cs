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

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Uppdatera bokning");
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
                        foreach (var guest in _dbContext.Guest)
                        {
                            Console.WriteLine($"Id: {guest.GuestId}");
                            Console.WriteLine($"Förnamn: {guest.GuestFirstName}");
                            Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                            Console.WriteLine($"E-mail: {guest.GuestEmail}");
                            Console.WriteLine($"Adress: {guest.Address}");
                            Console.WriteLine("====================");
                        }

                        Console.WriteLine("Välj Id på den gäst som du vill uppdatera");
                        int guestId = 0;

                        while (!int.TryParse(Console.ReadLine(), out guestId))
                        {
                            Console.WriteLine("Fel inmatning!");
                        }
                        var guestToUpdate = _dbContext.Guest.FirstOrDefault(g => g.GuestId == guestId);
                        if (guestToUpdate == null)
                        {
                            Console.WriteLine("Ogiltigt ID!");
                        }

                        Console.WriteLine("Ange förnamn: ");
                        var guestFirstNameUpdate = Console.ReadLine();

                        Console.WriteLine("Ange efternamn: ");
                        var guestLastNameUpdate = Console.ReadLine();

                        Console.WriteLine("Ange e-mail: ");
                        var guestEmailUpdate = Console.ReadLine();

                        Console.WriteLine("Ange adress: ");
                        var guestAddressUpdate = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(guestFirstNameUpdate) || string.IsNullOrWhiteSpace(guestLastNameUpdate) || string.IsNullOrWhiteSpace(guestEmailUpdate) || string.IsNullOrWhiteSpace(guestAddressUpdate))
                        {
                            Console.WriteLine("Ogiltigt, försök igen. Alla fält måste fyllas i.");
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
                        break;

                    case "0":

                        Console.Clear();
                        var rec = new Reception();
                        rec.ReceptionMenu();
                        break;

                    default:
                        Console.WriteLine("Välj ett av alternativen!");
                        break;
                }
            }
        }
    }
}
