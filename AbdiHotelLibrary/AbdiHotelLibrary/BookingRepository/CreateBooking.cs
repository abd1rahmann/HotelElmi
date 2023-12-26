using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.BookingRepository
{
    public class CreateBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void NewBooking()
        {
            Console.WriteLine("Creating Booking yey");
        }
    }
}
