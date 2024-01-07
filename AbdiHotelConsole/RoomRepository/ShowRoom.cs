using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace  AbdiHotelConsole.RoomRepository
{
    public class ShowRoom
    {
        private readonly ApplicationDbContext _dbContext;

        public ShowRoom(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayRoom()
        {
            Console.WriteLine("1. Se tillgängliga rum\n2. Se alla rum\n0. Gå tillbaka till menyn\n");
            bool run = true;
            while (run)
            {
                string choice = Console.ReadLine();
                switch (choice)

                {
                    case "1":
                        var availableRooms = _dbContext.Room.Where(g => g.IsAvailable == true).ToList();
                        foreach (var room in availableRooms)
                        {


                            Console.WriteLine("===============================================");
                            Console.WriteLine($"Rumsnummer: {room.RoomNumber}                 &");
                            Console.WriteLine($"Rumstyp: {room.TypeOfRoom}                    &");
                            Console.WriteLine($"Extra säng/sängar: {room.ExtraBeds}           &");
                            Console.WriteLine("================================================");
                            
                            
                        }
                        break;

                    case "2":

                        foreach (var room in _dbContext.Room)
                        {
                            Console.WriteLine("===============================================");
                            Console.WriteLine($"Rumsnummer: {room.RoomNumber}                 &");
                            Console.WriteLine($"Rumstyp: {room.TypeOfRoom}                    &");
                            Console.WriteLine($"Extra säng/sängar: {room.ExtraBeds}           &");
                            Console.WriteLine("================================================");

                        }

                        break;

                    case "0":
                        Console.Clear();
                        var backTo = new RoomMenu();
                        backTo.RoomMenuChoice();
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Fel inmatning! Tryck enter för att gå vidare");

                        break;
                }


            }
        }
    }
}
