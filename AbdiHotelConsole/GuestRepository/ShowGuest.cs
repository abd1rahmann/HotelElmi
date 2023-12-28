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
    public class ShowGuest
    {
        private readonly ApplicationDbContext _dbContext;

        public ShowGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayGuest() 
        {    
                    
                        foreach (var guest in _dbContext.Guest)
                        {
                            Console.WriteLine($"\nFörnamn: {guest.GuestFirstName}");
                            Console.WriteLine($"Efternamn: {guest.GuestLastName}");
                            Console.WriteLine($"Efternamn: {guest.GuestEmail}");
                            Console.WriteLine($"Efternamn: {guest.Address}");
                            Console.WriteLine($"Efternamn: {guest.IsActive}\n");

                        }

        }
    }
}
