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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Inaktivera rum");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");

            bool run = true;
            while   (run) 
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
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
                        var rec = new Reception();
                        rec.ReceptionMenu();
                        break;

                        case "0":
                        Console.Clear();
                        var reception = new Reception();
                        reception.ReceptionMenu();
                        break;

                    default:
                        Console.WriteLine("Fel val! Välj igen");
                        break;
                }
            }
        }
    }
}
