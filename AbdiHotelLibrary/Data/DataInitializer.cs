using Microsoft.EntityFrameworkCore;

namespace  AbdiHotelConsole.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            LoadData(dbContext);
        }
        public void LoadData(ApplicationDbContext dbContext)
        {
            if (dbContext.Guest.Any()) return;

            var guests = new List<Guest>();
            var rooms = new List<Room>();

            guests.Add(new Guest { GuestFirstName = "Karl", GuestLastName = "Karlsson", Address = "Axbyplan 7", GuestEmail = "Karl.Karlsson@hotmail.com", IsActive = false });
            guests.Add(new Guest { GuestFirstName = "Anders", GuestLastName = "Andersson", Address = "Ljungbyplan 18", GuestEmail = "Anders.Andersson", IsActive = false });
            guests.Add(new Guest { GuestFirstName = "Malin", GuestLastName = "Persson", Address = "Mjölbyplan 11", GuestEmail = "Malin.Persson@hotmail.com", IsActive = false });
            guests.Add(new Guest { GuestFirstName = "Anna", GuestLastName = "Johnsson", Address = "Vimmerbyplan 20", GuestEmail = "Anna.Johnsson@hotmail.com", IsActive = false });

            rooms.Add(new Room { RoomNumber = 101, TypeOfRoom = "Enkelrum", IsAvailable = true, PricePerNight = 1500});
            rooms.Add(new Room { RoomNumber = 102, TypeOfRoom = "Enkelrum", IsAvailable = true, PricePerNight = 1500});
            rooms.Add(new Room { RoomNumber = 103, TypeOfRoom = "Dubbelrum", IsAvailable = true, PricePerNight = 2000});
            rooms.Add(new Room { RoomNumber = 104, TypeOfRoom = "Dubbelrum", IsAvailable = true, PricePerNight = 2000});


            
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
