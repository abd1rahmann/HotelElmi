//1. jag ska kunna visa rätt data på IsAvailable i ssms


//var activeGuests =
//    (from g in _dbContext.Guest
//     join b in _dbContext.Booking on g.GuestId equals b.GuestId
//     where g.IsActive == false
//     select g).ToList();
//roomIdToBook.IsAvailable = false; funkar ej i createbooking

//Applikationen skall hantera ett antal rum 

//max 2 extra beds





//Console.Write("\nAnge gästens Id: ");



//var guestId = Convert.ToInt32(Console.ReadLine());
//var guestIdToBook = _dbContext.Guest.FirstOrDefault(g => g.GuestId == guestId);

//if (guestIdToBook != null)
//{
//    booking.GuestId = guestIdToBook.GuestId;
//    guestIdToBook.IsActive = true;
//}
//else
//{
//    Console.WriteLine("\nGäst ID som du söker finns inte. Välj igen!");
//    Console.ReadLine();

//}




//SELECT* FROM Room;

//SELECT* FROM Booking;

//SELECT* FROM Guest;

//SELECT* FROM Booking WHERE GuestId = 1;

//SELECT* FROM Booking WHERE RoomId = 103;

//SELECT* FROM Room WHERE IsAvailable = 1;

//SELECT Room.RoomId, Room.ExtraBeds FROM Room;

//SELECT Guest.GuestId, Guest.GuestFirstName, Guest.GuestLastName, COUNT(Booking.BookingId) AS NumberOfBookings
//FROM Guest
//LEFT JOIN Booking ON Guest.GuestId = Booking.GuestId
//GROUP BY Guest.GuestId, Guest.GuestFirstName, Guest.GuestLastName;