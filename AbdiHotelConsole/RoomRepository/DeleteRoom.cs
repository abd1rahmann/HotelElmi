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
            Console.WriteLine("Inaktivera rum");
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }



            Console.WriteLine("Välj Id på det rum som du vill inaktivera");

           
            foreach (var room in _dbContext.Room)
            {
                Console.WriteLine($"\nID: {room.RoomId}\nRumsnummer: {room.RoomNumber}\nTyp av rum: {room.TypeOfRoom}\n");
               
            }

            
            var roomIdToDelete = Convert.ToInt32(Console.ReadLine());
            var roomToDelete = _dbContext.Room.First(r => r.RoomId == roomIdToDelete);

            roomToDelete.IsAvailable = false;
            _dbContext.SaveChanges();

            Console.WriteLine("Rummet är inaktiverat!");
            Console.ReadLine();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
