using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AbdiHotelConsole.GuestRepository;

namespace  AbdiHotelConsole.RoomRepository
{

    public class CreateRoom
    {
        private readonly ApplicationDbContext _dbContext;


        public CreateRoom(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewRoom()
        {

            var room = new Room();

            Console.WriteLine("Lägg till ny rum\n\n");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }

            Console.Write("Ange rumsnummer: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange rumstyp (enkelrum/dubbelrum: ");
            string typeOfRoom = Console.ReadLine();

            Console.WriteLine("Ange status på rummet (tillgänglig/ej tillgänglig)");
            string isAvailableStr = Console.ReadLine();

            bool isAvailable;
            if (!bool.TryParse(isAvailableStr, out isAvailable))
            {
                Console.WriteLine("Ej tillgänglig.");
              
            }





            room.RoomNumber = roomNumber;
            room.TypeOfRoom = typeOfRoom;
          
            

            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }

    }

}
