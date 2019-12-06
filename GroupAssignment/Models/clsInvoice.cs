using System;

namespace GroupAssignment.Models {
    internal class Invoice {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}