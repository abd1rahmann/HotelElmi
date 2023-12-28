using  AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.BookingRepository
{
    public class DeleteBooking
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteBooking(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
