using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;

namespace  AbdiHotelConsole.RoomRepository
{
    public class DeleteRoom
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteRoom(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete()
        {
            Console.WriteLine("Ta bort ett rum");
            Console.WriteLine("=====================");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }



            Console.WriteLine("Välj Id på det rum som du vill ta bort");

           
            foreach (var room in _dbContext.Room)
            {
                Console.WriteLine($"{room.RoomId}");
               
            }

            
            var roomIdToDelete = Convert.ToInt32(Console.ReadLine());
            var roomToDelete = _dbContext.Room.First(r => r.RoomId == roomIdToDelete);

            _dbContext.Room.Remove(roomToDelete);
            _dbContext.SaveChanges();

            Console.WriteLine("Bokningen gäller inte längre nu");

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
