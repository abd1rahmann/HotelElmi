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

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Uppdatera bokning");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");

            bool run = true;
            while (run)
            {
                string choic = Console.ReadLine();
                switch (choic)
                {
                    case "1":
                        foreach (var room in _dbContext.Room)
                        {
                            Console.WriteLine($"\nRum Id: {room.RoomId}");
                            Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
                            Console.WriteLine($"Typ av rum: {room.TypeOfRoom}");
                            
                        }

                        Console.WriteLine("Välj Id på det rum som du vill uppdatera");
                        int roomId = 0;

                        while (!int.TryParse(Console.ReadLine(), out roomId))
                        {
                            Console.WriteLine("Fel inmatning!");
                        }
                        var roomToUpdate = _dbContext.Room.FirstOrDefault(r => r.RoomId == roomId);
                        Console.Clear();

                        Console.WriteLine("Ange nytt rumsnummer: ");
                        var roomNumberUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ange ny rumstyp (enkelrum/dubbelrum): ");
                        var typeOfRoomUpdate = Console.ReadLine();

                        if (typeOfRoomUpdate == "1")
                        {

                        }

                        Console.WriteLine("Ange ny status. Tryck 1 för att aktivera eller 2 för att inaktivera: ");
                        var choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                roomToUpdate.IsAvailable = true;
                                Console.WriteLine("Rummet är aktiv!");
                                break;

                            case "2":
                                roomToUpdate.IsAvailable = false;
                                Console.WriteLine("Rummet är inaktiverad!");
                                break;
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

                            roomToUpdate.RoomNumber = roomNumberUpdate;
                            roomToUpdate.TypeOfRoom = typeOfRoomUpdate;

                            _dbContext.SaveChanges();

                            Console.WriteLine("Rummet är uppdaterad");
                            Console.ReadLine();

                            Console.Clear();
                            var reception = new Reception();
                            reception.ReceptionMenu();
                        }
                        break; 
                    case "0":
                        Console.Clear();
                        var rec = new Reception();
                        rec.ReceptionMenu();
                        break;

                    default: Console.WriteLine("Fel val! Välj igen");
                        break;
                }
            }
        }
    }
}
