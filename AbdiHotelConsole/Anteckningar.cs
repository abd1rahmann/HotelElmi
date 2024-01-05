//1. jag ska kunna visa rätt data på IsAvailable i ssms


//var activeGuests =
//    (from g in _dbContext.Guest
//     join b in _dbContext.Booking on g.GuestId equals b.GuestId
//     where g.IsActive == false
//     select g).ToList();