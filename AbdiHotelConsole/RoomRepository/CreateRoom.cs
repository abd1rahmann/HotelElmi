using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AbdiHotelConsole.GuestRepository;
using System.Net;

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

           
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Lägg till ett rum");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");

            bool run = true;

            while (run)
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nAnge rumsnummer: ");
                        int roomNumber = 0;

                        while (!int.TryParse(Console.ReadLine(), out roomNumber))
                        {
                            Console.WriteLine("The input is invalid. Please type a number");
                        }

                        Console.Write("\nAnge rumstyp (enkelrum/dubbelrum): ");
                        string typeOfRoom = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(typeOfRoom))
                        {
                            Console.WriteLine("Ogiltigt, försök igen. Alla fält måste fyllas i.");
                        }


                        room.RoomNumber = roomNumber;
                        room.TypeOfRoom = typeOfRoom;
                        room.IsAvailable = true;

                        Console.WriteLine("\nAnge pris/kväll: ");
                        int priceForRoom = Convert.ToInt32(Console.ReadLine());
                        room.PricePerNight = priceForRoom;



                        //Console.WriteLine("\nAnge status på rummet (tryck 1 för tillgänglig eller 2 för ej tillgänglig): ");
                        //string isAvailableStr = Console.ReadLine();

                        //switch (isAvailableStr)
                        //{
                        //    case "1":
                        //        room.IsAvailable = true;
                        //        break;

                        //    case "2":
                        //        room.IsAvailable = false;
                        //        break;

                        //    default:
                        //        Console.WriteLine("\nTryck endast 1 eller 2!");
                        //        break;
                        //}

                        _dbContext.Room.Add(room);
                        _dbContext.SaveChanges();

                        Console.WriteLine("\nRummet är tillagd!");
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
                        Console.WriteLine("Fel inmatning!");
                        break;
                }
            }
        }
    }
}
