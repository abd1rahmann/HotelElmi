using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.RoomRepository
{
    public class ReActivate
    {
        private readonly ApplicationDbContext _dbContext;
        public ReActivate(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void ReActivateRoom()
        {
            Console.WriteLine("Återaktivering av rum");
            Console.WriteLine("\n====================================================================================");

            Console.WriteLine("\nVälj ID på rummet du vill återaktivera:");

            var activeRooms = _dbContext.Room.Where(r => r.IsAvailable == false).ToList();
            foreach (var room in activeRooms)
            {
                Console.WriteLine($"\nID: {room.RoomId}");
                Console.WriteLine($"Rumnummer: {room.RoomNumber}");
                Console.WriteLine($"Typ av rum: {room.TypeOfRoom}");
                Console.WriteLine($"Extra säng/sängar: {room.ExtraBeds}\n");
            }


            int roomIdToReActive = Convert.ToInt32(Console.ReadLine());

            var roomToReActive = _dbContext.Room.FirstOrDefault(g => g.RoomId == roomIdToReActive);

            roomToReActive.IsAvailable = true;

            _dbContext.SaveChanges();

            Console.WriteLine("\nRummet är nu återaktiverad!!");
            Console.ReadLine();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();

        }
    }
}
