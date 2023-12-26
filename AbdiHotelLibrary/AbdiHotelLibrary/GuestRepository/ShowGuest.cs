using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AbdiHotelLibrary.AbdiHotelLibrary.GuestRepository
{
    public class ShowGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public ShowGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
