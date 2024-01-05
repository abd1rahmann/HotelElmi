using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdiHotelConsole.BookingRepository;
using AbdiHotelConsole.Data;

namespace AbdiHotelConsole.RoomRepository
{
    public class UpdateRoom
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateRoom(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update()
        {
          
            Console.WriteLine("Uppdatera rum");
            Console.WriteLine("=====================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new RoomMenu();
                backTo.RoomMenuChoice();
            }

            foreach (var room in _dbContext.Room)
            {
                Console.WriteLine($"\nRum Id: {room.RoomId}");
                Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                Console.WriteLine($"Typ av rum: {room.TypeOfRoom}");
                Console.WriteLine($"Tillgänglighet: {room.IsAvailable}\n");

            }

            Console.WriteLine("Välj Id på det rum som du vill uppdatera");
            var roomIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var roomToUpdate = _dbContext.Room.First(r => r.RoomId == roomIdToUpdate);
            Console.Clear();

            Console.WriteLine("Ange nytt rumsnummer: ");
            var roomNumberUpdate = Console.ReadLine();

            Console.WriteLine("Ange ny rumstyp (enkelrum/dubbelrum): ");
            var typeOfRoomUpdate = Console.ReadLine();

            if ( typeOfRoomUpdate == "1" )
            {

            }

            Console.WriteLine("Ange ny status: ");
            var IsAvailableUpdate = Console.ReadLine();


            if (IsAvailableUpdate.ToLower() == "tillgänglig")
            {
                _ = roomToUpdate.IsAvailable;
            }
            else if (IsAvailableUpdate.ToLower() == "ej tillgänglig")
            {
                roomToUpdate.IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Ange endast 'tillgänglig' eller 'ej tillgänglig'.");
                return;
            }

            Console.WriteLine("Tryck '1' för att kunna lägga till extra säng i ett rum (OBS! Detta gäller endast dubbelrum).\nOm inte, fortsätt vidare.");
            string extraSäng = Console.ReadLine();
            if (extraSäng == "1")
            {

                if (roomToUpdate.TypeOfRoom.ToLower() == "dubbelrum")
                {
                    Console.WriteLine("Ange antal extra sängar (1 eller 2): ");
                    int extraBeds = Convert.ToInt32(Console.ReadLine());


                    roomToUpdate.ExtraBeds = extraBeds;
                }
                else
                {
                    Console.WriteLine("Extra sängar kan endast läggas till i dubbelrum. Återgår till huvudmenyn.");
                    return;
                }

                roomToUpdate.RoomNumber = roomIdToUpdate;
                roomToUpdate.TypeOfRoom = typeOfRoomUpdate;

                
                _dbContext.SaveChanges();

                Console.Clear();
                var reception = new Reception();
                reception.ReceptionMenu();
            }
        }
    }
}
