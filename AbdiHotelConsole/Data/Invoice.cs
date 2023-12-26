using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbdiHotelConsole.Data
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int GuestId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Amount { get; set; }
        public DateTime DueDateUtc { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public bool Payed { get; set; }
    }
}
