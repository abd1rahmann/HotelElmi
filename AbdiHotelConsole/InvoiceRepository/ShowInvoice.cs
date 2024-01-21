using AbdiHotelConsole.BookingRepository;
using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.InvoiceRepository
{
    public class ShowInvoice
    {
        private readonly ApplicationDbContext _dbContext;
        public ShowInvoice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DisplayInvoice() 
        {
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Visa faktura");
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
                        foreach (var invoice in _dbContext.Invoice)
                        {
                            Console.WriteLine("============================================================");
                            Console.WriteLine($"ID: {invoice.InvoiceId}\nFakturanummer: {invoice.InvoiceNumber}\nFörfallodatum: {invoice.DueDate}");
                            Console.WriteLine("============================================================");
                        }
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
