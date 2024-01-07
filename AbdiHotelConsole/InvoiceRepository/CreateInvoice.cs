using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.InvoiceRepository
{
    public class CreateInvoice
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateInvoice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewInvoice() 
        {
            var invoice = new Invoice();

            Console.WriteLine("Skapa faktura");
            Console.WriteLine("==========================================================================");

            Console.WriteLine("Ange ID för bokning:");
            Console.ReadLine();

            var unPaidBooking =
              (from b in _dbContext.Booking

               where b.IsPaid == false
               select b).ToList();

            foreach (var booking in unPaidBooking)
            {
                Console.WriteLine("\n===========================================================================");
                Console.WriteLine($"ID: {booking.BookingId}");
                Console.WriteLine("===========================================================================\n");
            }

            var bookingId = Convert.ToInt32(Console.ReadLine());
            var bookingIdToInvoice = _dbContext.Booking.FirstOrDefault(b => b.BookingId == bookingId);

            Console.WriteLine("\nAnge faktureringsnummer");
            int invoiceNumber = Convert.ToInt32(Console.ReadLine());

            DateTime dueDate = DateTime.Now.AddDays(30);
            invoice.DueDate = dueDate;

            Console.WriteLine($"\nFakturans förfallodatum: {dueDate}");
            Console.WriteLine("\nFakturan är skapad!");
            Console.ReadLine();

            _dbContext.SaveChanges();

            Console.Clear();
            var rec = new Reception();
            rec.ReceptionMenu();

        }
    }
}
