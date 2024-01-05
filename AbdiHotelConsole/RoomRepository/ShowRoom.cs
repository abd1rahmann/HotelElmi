using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;

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
            var activeRoom = _dbContext.Room.Where(r => r.IsAvailable == true).ToList();

            foreach (var room in activeRoom)
            {
                Console.WriteLine($"\nRumsnummer: {room.RoomNumber}");
                Console.WriteLine($"Rumstyp: {room.TypeOfRoom}");
                Console.WriteLine($"Tillgänglighet: {room.IsAvailable}");
               
            }

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();

        }
    }
}
