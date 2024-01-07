using AbdiHotelConsole.InvoiceRepository;
using AbdiHotelConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.InvoiceRepository
{
    public class UpdateInvoice
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateInvoice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update() 
        {
            Console.WriteLine("Uppdatera en faktura");
            Console.WriteLine("=====================");
            Console.WriteLine("\nTryck på '1' för att gå tillbaka ett steg, eller klicka 'enter' för att gå vidare.");

            string back = Console.ReadLine();

            if (back == "1")
            {
                Console.Clear();
                var backTo = new InvoiceMenu();
                backTo.InvoiceMenuChoice();
            }

            foreach (var invoice in _dbContext.Invoice)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine($"Id: {invoice.InvoiceId}");
                Console.WriteLine($"Fakturanummer: {invoice.InvoiceNumber}");
                Console.WriteLine($"Förfallodatum: {invoice.DueDate}");
                Console.WriteLine("============================================\n");

            }


            Console.WriteLine("\nVälj Id på den bokningen som du vill uppdatera");
            int invoiceIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var invoiceToUpdate = _dbContext.Invoice.First(i => i.InvoiceId == invoiceIdToUpdate);

            if (invoiceIdToUpdate == null)
            {
                Console.WriteLine("\nobefintlig bokning! Välj en befintlig bokning.");

            }

            Console.WriteLine("\nAnge nytt fakturanummer: ");
            int newInvoiceNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nAnge nya utcheckningsdatum (yyyy-MM-dd): ");
            string newDueDateString = Console.ReadLine();
            DateTime newDueDateToUpdate = DateTime.ParseExact( newDueDateString, "yyyy-MM-dd", null);

            invoiceToUpdate.InvoiceNumber = newInvoiceNumber; 
            invoiceToUpdate.DueDate = newDueDateToUpdate;

            _dbContext.SaveChanges();

            Console.WriteLine("\nUppdateringen är genomförd!");
            Console.ReadLine();


            Console.Clear();


            var reception = new Reception();
            reception.ReceptionMenu();
        }
    }
}
