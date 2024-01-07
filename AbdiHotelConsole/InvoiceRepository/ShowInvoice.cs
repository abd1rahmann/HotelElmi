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
            
            foreach (var invoice in _dbContext.Invoice)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine($"ID: {invoice.InvoiceId}\nFakturanummer: {invoice.InvoiceNumber}\nFörfallodatum: {invoice.DueDate}");
                Console.WriteLine("============================================================");
            }

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new InvoiceMenu();
                backTo.InvoiceMenuChoice();
            }
            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
