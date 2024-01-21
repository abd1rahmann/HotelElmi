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
            Console.WriteLine("===========================================================================");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.WriteLine("\t1. Uppdatera faktura");
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
                            Console.WriteLine("\n==========================================");
                            Console.WriteLine($"Id: {invoice.InvoiceId}");
                            Console.WriteLine($"Fakturanummer: {invoice.InvoiceNumber}");
                            Console.WriteLine($"Förfallodatum: {invoice.DueDate}");
                            Console.WriteLine("============================================\n");

                        }


                        Console.WriteLine("\nVälj Id på den fakturan som du vill uppdatera");
                        int invoiceId = 0;

                        while (!int.TryParse(Console.ReadLine(), out invoiceId))
                        {
                            Console.WriteLine("Inmatningen är ogiltig. Vänligen ange ett nummer");
                        }
                        var invoiceToUpdate = _dbContext.Invoice.First(i => i.InvoiceId == invoiceId);

                        if (invoiceId == null)
                        {
                            Console.WriteLine("\nobefintlig faktura! Välj en befintlig faktura.");

                        }

                        Console.WriteLine("\nAnge nytt fakturanummer: ");
                        int newInvoiceNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nAnge nya utcheckningsdatum (yyyy-MM-dd): ");
                        string newDueDateString = Console.ReadLine();
                        DateTime newDueDateToUpdate = DateTime.ParseExact(newDueDateString, "yyyy-MM-dd", null);

                        invoiceToUpdate.InvoiceNumber = newInvoiceNumber;
                        invoiceToUpdate.DueDate = newDueDateToUpdate;

                        _dbContext.SaveChanges();

                        Console.WriteLine("\nUppdateringen är genomförd!");
                        Console.ReadLine();

                        Console.Clear();
                        var reception = new Reception();
                        reception.ReceptionMenu();
                        break;

                        case "0":
                        Console.Clear();
                        var rec = new Reception();
                        break;

                        default: Console.WriteLine("Fel inmatning!");
                        break;
                }
            }

            


            
        }
    }
}
