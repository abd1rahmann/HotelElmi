using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.GuestRepository
{
    public class CreateGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public void CreateNewGuest(DbContextOptionsBuilder)
        //{
        //    var guest = new Guest();
        //    Console.Write("Ange gästens förnamn: ");
        //    string guestFirstName = Console.ReadLine();

        //    Console.Write("Ange gästens efternamn: ");
        //    string guestLastName = Console.ReadLine();

        //    Console.Write("Ange gästens e-postadress: ");
        //    string guestEmail = Console.ReadLine();

        //    Console.Write("Ange faktureringsadress: ");
        //    string billingAddress = Console.ReadLine();


        //    guest.GuestFirstName = guestFirstName;

        //    _dbContext.Guest.Add(guest);
        //    _dbContext.SaveChanges();

        //}

        public void CreateNewGuest()
        {
            Console.WriteLine("Lägg till ny gäst\n\n");
            var guest = new Guest();
            Console.Write("Ange gästens förnamn: ");
            string guestFirstName = Console.ReadLine();

            Console.Write("Ange gästens efternamn: ");
            string guestLastName = Console.ReadLine();

            Console.Write("Ange gästens e-postadress: ");
            string guestEmail = Console.ReadLine();

            Console.Write("Ange faktureringsadress: ");
            string billingAddress = Console.ReadLine();

            guest.GuestFirstName = guestFirstName;

            _dbContext.Guest.Add(guest);
            _dbContext.SaveChanges();
        }
    }
}
