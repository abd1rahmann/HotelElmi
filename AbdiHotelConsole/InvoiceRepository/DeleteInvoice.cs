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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Makulera faktura");
            Console.WriteLine("\t0. Huvudmenyn");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("===========================================================================");

            bool run = true;
            while (run)
            {
                string choice = Console.ReadLine();
                switch  (choice) 
                {
                    case "1":
                        

                        foreach (var invoice in _dbContext.Invoice)
                        {
                            Console.WriteLine("\n==========================================");
                            Console.WriteLine($"Id: {invoice.InvoiceId}");
                            Console.WriteLine($"Incheckning: {invoice.InvoiceNumber}");
                            Console.WriteLine($"Utcheckning: {invoice.DueDate}");
                            Console.WriteLine("============================================\n");

                        }

                        Console.WriteLine("\nVälj Id på den fakturan som du vill ta bort");
                        int invoiceId = 0;

                        while (!int.TryParse(Console.ReadLine(), out invoiceId))
                        {
                            Console.WriteLine("Inmatningen är ogiltig. Vänligen ange ett nummer");
                        }
                        var invoiceToDelete = _dbContext.Invoice.First(i => i.InvoiceId == invoiceId);

                        invoiceToDelete.IsValid = false;
                        _dbContext.SaveChanges();

                        Console.WriteLine("Fakturan har tagits bort");
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
