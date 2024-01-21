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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Inaktivera en gäst");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");
            bool run = false;
            while (!run)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (var guest in _dbContext.Guest)
                        {
                            Console.WriteLine("\n===========================================");
                            Console.WriteLine($"ID: {guest.GuestId}");
                            Console.WriteLine($"Förnamn: {guest.GuestFirstName}");
                            Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                            Console.WriteLine($"Email: {guest.GuestEmail}");
                            Console.WriteLine($"Adress: {guest.Address}");
                            Console.WriteLine("=============================================\n");
                        }

                        Console.WriteLine("Välj Id på den gäst som du vill ta inaktivera");
                        var guestIdToDelete = Convert.ToInt32(Console.ReadLine());
                        var guestToDelete = _dbContext.Guest.First(p => p.GuestId == guestIdToDelete);
                        guestToDelete.IsActive = false;

                        _dbContext.SaveChanges();
                        Console.WriteLine("Gästen är inaktiverad!");
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
                        Console.WriteLine("Fel val! Välj igen");
                        break;
                }
            }
        }
    }
}
