using  AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace  AbdiHotelConsole.GuestRepository
{
    public class ShowGuest
    {
        private readonly ApplicationDbContext _dbContext;

        public ShowGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayGuest() 
        {

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Se aktiva gäster");
            Console.WriteLine("\t2. Se alla gäster");
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
                        var activeGuests = _dbContext.Guest.Where(g => g.IsActive == true).ToList();
                        foreach (var guest in activeGuests)
                        {
                        Console.WriteLine($"\nFörnamn: {guest.GuestFirstName}");
                        Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                        Console.WriteLine($"Email: {guest.GuestEmail}");
                        Console.WriteLine($"Address: {guest.Address}\n");
                        }
                        break;

                    case "2":
                    
                        foreach (var guest in _dbContext.Guest) 
                        {
                        Console.WriteLine($"\nFörnamn: {guest.GuestFirstName}");
                        Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                        Console.WriteLine($"Email: {guest.GuestEmail}");
                        Console.WriteLine($"Address: {guest.Address}\n");
                        }
                        break;
                   
                        case "0":
                        Console.Clear();
                        var backTo = new GuestMenu();
                        backTo.GuestMenuChoice();
                        run = false;
                        break;
                   
                    default: 
                        Console.WriteLine("Fel inmatning!");
                        break;
            }
            
           }
            
        }
        
    }
}
