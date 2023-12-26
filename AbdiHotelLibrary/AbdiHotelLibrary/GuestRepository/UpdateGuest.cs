using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.GuestRepository
{
    public class UpdateGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
