using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.BookingRepository
{
    public class UpdateBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
