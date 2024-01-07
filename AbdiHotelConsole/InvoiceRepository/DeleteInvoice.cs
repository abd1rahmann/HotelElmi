using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.InvoiceRepository
{
    public class DeleteInvoice
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteInvoice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete() 
        {
            Console.WriteLine("Makulera en faktura");
            Console.WriteLine("=================================================================================");

            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new InvoiceMenu();
                backTo.InvoiceMenuChoice();
            }

            Console.WriteLine("\nVälj Id på den fakturan som du vill ta bort");

            foreach (var invoice in _dbContext.Invoice)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine($"Id: {invoice.InvoiceId}");
                Console.WriteLine($"Incheckning: {invoice.InvoiceNumber}");
                Console.WriteLine($"Utcheckning: {invoice.DueDate}");
                Console.WriteLine("============================================\n");

            }


            var invoiceIdToDelete = Convert.ToInt32(Console.ReadLine());
            var invoiceToDelete = _dbContext.Invoice.First(i => i.InvoiceId == invoiceIdToDelete);

            invoiceToDelete.IsValid = false;
            _dbContext.SaveChanges();

            Console.WriteLine("Fakturan har tagits bort");



            Console.Clear();
            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
    
}
