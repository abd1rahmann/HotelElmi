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

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Registrera ny gäst");
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
                        Console.Write("Ange gästens förnamn: ");
                        string guestFirstName = Console.ReadLine();

                        Console.Write("Ange gästens efternamn: ");
                        string guestLastName = Console.ReadLine();

                        Console.Write("Ange gästens e-postadress: ");
                        string guestEmail = Console.ReadLine();

                        Console.Write("Ange gästens adress: ");
                        string address = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(guestFirstName) || string.IsNullOrWhiteSpace(guestLastName) || string.IsNullOrWhiteSpace(guestEmail) || string.IsNullOrWhiteSpace(address))
                        {
                            Console.WriteLine("Ogiltigt, försök igen. Alla fält måste fyllas i.");
                        }
                        
                        guest.GuestFirstName = guestFirstName;
                        guest.GuestLastName = guestLastName;
                        guest.GuestEmail = guestEmail;
                        guest.Address = address;

                        _dbContext.Guest.Add(guest);
                        _dbContext.SaveChanges();

                        Console.WriteLine("Gästen är registrerad!");
                        Console.ReadLine();

                        Console.Clear();
                        var rec = new Reception();
                        rec.ReceptionMenu();
                        break;

                        case "0":
                        Console.Clear();
                        var reception = new Reception();
                        reception.ReceptionMenu();
                        break;

                    default:
                        Console.WriteLine("Fel inmatning!");
                        break;
                }
            }
        }
    }
}











