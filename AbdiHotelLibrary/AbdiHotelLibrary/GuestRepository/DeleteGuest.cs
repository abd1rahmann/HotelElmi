using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelLibrary.AbdiHotelLibrary.GuestRepository
{
    public class DeleteGuest
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteGuest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
