using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.BookingRepository
{
    public class ShowBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public ShowBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
