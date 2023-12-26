using Microsoft.EntityFrameworkCore;

namespace AbdiHotelConsole.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            LoadData(dbContext);
            dbContext.SaveChanges();
        }
        public void LoadData(ApplicationDbContext dbContext)
        {
            var guests = new List<Guest>();
            var rooms = new List<Room>();

            guests.Add(new Guest { GuestFirstName = "Karl", GuestLastName = "Karlsson", Address = "Axbyplan 7", GuestEmail = "Karl.Karlsson@hotmail.com", IsActive = true });
            guests.Add(new Guest { GuestFirstName = "Anders", GuestLastName = "Andersson", Address = "Ljungbyplan 18", GuestEmail = "Anders.Andersson", IsActive = true });
            guests.Add(new Guest { GuestFirstName = "Malin", GuestLastName = "Persson", Address = "Mjölbyplan 11", GuestEmail = "Malin.Persson@hotmail.com", IsActive = true });
            guests.Add(new Guest { GuestFirstName = "Anna", GuestLastName = "Johnsson", Address = "Vimmerbyplan 20", GuestEmail = "Anna.Johnsson@hotmail.com", IsActive = true });

            rooms.Add(new Room { RoomNumber = 101, TypeOfRoom = "Enkelrum" });
            rooms.Add(new Room { RoomNumber = 102, TypeOfRoom = "Enkelrum" });
            rooms.Add(new Room { RoomNumber = 103, TypeOfRoom = "Enkelrum" });
            rooms.Add(new Room { RoomNumber = 104, TypeOfRoom = "Dubbelrum" });


            
            foreach (var guest in guests)
            {
                dbContext.Guest.Add(guest);
            }

            foreach (var room in rooms)
            {
                dbContext.Room.Add(room);
            }

            dbContext.SaveChanges();
        }
    }
}
