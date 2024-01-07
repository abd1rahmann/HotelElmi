using AbdiHotelConsole.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AbdiHotelConsole.InvoiceRepository
{
    public class InvoiceMenu
    {
        public void InvoiceMenuChoice() 
        {

            int run = 1;
            while (run == 1) 
            {
                Console.WriteLine(@"
$$$$$$$$\       $$\        $$\                                 
$$  _____|      $$ |       $$ |                                
$$ |   $$$$$$\  $$ |  $$\$$$$$$\  $$\   $$\  $$$$$$\  $$$$$$\  
$$$$$\ \____$$\ $$ | $$  \_$$  _| $$ |  $$ |$$  __$$\ \____$$\ 
$$  __|$$$$$$$ |$$$$$$  /  $$ |   $$ |  $$ |$$ |  \__|$$$$$$$ |
$$ |  $$  __$$ |$$  _$$<   $$ |$$\$$ |  $$ |$$ |     $$  __$$ |
$$ |  \$$$$$$$ |$$ | \$$\  \$$$$  \$$$$$$  |$$ |     \$$$$$$$ |
\__|   \_______|\__|  \__|  \____/ \______/ \__|      \_______|
                                                               ");

                Console.WriteLine("\n============================================\n");
                Console.WriteLine("1. Skapa faktura\n2. Visa faktura\n3. Uppdatera information om faktura\n4. Makulera faktura\n0. Gå tillbaka till huvudmenyn");

                var choice = Console.ReadLine();
                var options = new DbContextOptionsBuilder<ApplicationDbContext>();
                Console.Clear();

                options.UseSqlServer("Server=localhost;Database=AbdiHotel;Trusted_Connection=True;TrustServerCertificate=true;");
                using (var dbContext = new ApplicationDbContext(options.Options))
                {
                    switch (choice)
                    {

                        case "1":
                            var createInvoice = new CreateInvoice(dbContext);
                            createInvoice.CreateNewInvoice();
                            break;

                        case "2":
                            var showInvoice = new ShowInvoice(dbContext);
                            showInvoice.DisplayInvoice();
                            break;

                        case "3":
                            var updateInvoice = new UpdateInvoice(dbContext);
                            updateInvoice.Update();
                            break;

                        case "4":
                            var deleteInvoice = new DeleteInvoice(dbContext);
                            deleteInvoice.Delete();
                            break;

                        case "0":
                            var rec = new Reception();
                            rec.ReceptionMenu();
                            break;

                        default:
                            Console.WriteLine("Välj ett av alternativen");
                            break;

                    }
                }
            }
        }
    }
}
