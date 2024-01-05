using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdiHotelConsole.Data;
using AbdiHotelConsole.GuestRepository;
using Microsoft.EntityFrameworkCore;

namespace  AbdiHotelConsole.RoomRepository
{
    public class RoomMenu
    {
        public void RoomMenuChoice() 
        {
            Console.WriteLine(@"
$$$$$$$\                          
$$  __$$\                         
$$ |  $$ |$$\   $$\ $$$$$$\$$$$\  
$$$$$$$  |$$ |  $$ |$$  _$$  _$$\ 
$$  __$$< $$ |  $$ |$$ / $$ / $$ |
$$ |  $$ |$$ |  $$ |$$ | $$ | $$ |
$$ |  $$ |\$$$$$$  |$$ | $$ | $$ |
\__|  \__| \______/ \__| \__| \__|
        
");

            Console.WriteLine("\n========================================================================================\n");
            Console.WriteLine("1. Lägg till rum\n2. Visa rum\n3. Uppdatera rum\n4. Ta bort rum\n5. Gå tillbaka ett steg");

            var choice = Console.ReadLine();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            Console.Clear();

            options.UseSqlServer("Server=localhost;Database=AbdiHotel;Trusted_Connection=True;TrustServerCertificate=true;");
            using (var dbContext = new ApplicationDbContext(options.Options))

            {
                switch (choice)
                {

                    case "1":
                        var createRoom = new CreateRoom(dbContext);
                        createRoom.CreateNewRoom();
                        break;

                    case "2":
                        var showRoom = new ShowRoom(dbContext);
                        showRoom.DisplayRoom();
                        break;

                    case "3":
                        var updateRoom = new UpdateRoom(dbContext);
                        updateRoom.Update();
                        break;

                    case "4":
                        var deleteRoom = new DeleteRoom(dbContext);
                        deleteRoom.Delete();
                        break;
                    case "5":
                        var rec = new Reception();
                        rec.ReceptionMenu();
                        break;

                    default:
                        Console.WriteLine("Välj ett av alternativen");
                        break;

                }
            }
        }
    }
}
