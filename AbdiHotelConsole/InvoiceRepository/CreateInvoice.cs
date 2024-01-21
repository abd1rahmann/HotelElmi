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

            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Skapa faktura");
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
                        Console.WriteLine("Ange ID för bokning för fakturan:");
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
                        invoice.InvoiceNumber = invoiceNumber;
                        invoice.IsValid = true;


                        _dbContext.Add(invoice);
                        _dbContext.SaveChanges();

                        Console.WriteLine($"\nFakturans förfallodatum: {dueDate}");
                        Console.WriteLine("\nFakturan är skapad!");
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
                        Console.WriteLine("Fel val! Välj igen");
                        break;
                }
            }

           

        }
    }
}
