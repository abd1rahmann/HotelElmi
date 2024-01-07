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

            Console.WriteLine("Lägg till ny rum\n");
            Console.WriteLine("====================================================================================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }

            Console.Write("\nAnge rumsnummer: ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nAnge rumstyp (enkelrum/dubbelrum): ");
            string typeOfRoom = Console.ReadLine();


            room.RoomNumber = roomNumber;
            room.TypeOfRoom = typeOfRoom;

            Console.WriteLine("\nAnge pris/kväll: ");
            int priceForRoom = Convert.ToInt32(Console.ReadLine());
            room.PricePerNight = priceForRoom;



            Console.WriteLine("\nAnge status på rummet (tryck 1 för tillgänglig eller 2 för ej tillgänglig): ");
            string isAvailableStr = Console.ReadLine();

            switch (isAvailableStr)
            {
                case "1":
                    room.IsAvailable = true;
                    break;

                    case "2":
                    room.IsAvailable = false;
                    break;

                default:
                    Console.WriteLine("\nTryck endast 1 eller 2!");
                    break;
            }
            
            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();

            Console.WriteLine("\nRummet är tillagd!");
            Console.ReadLine();

            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }

    }

}
