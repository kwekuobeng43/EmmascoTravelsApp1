




using System;

namespace EmmascoTravelsApp1.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        // Linked to user
        public string Username { get; set; }

        // Linked to Booking
        public int BookingId { get; set; }

        // Linked to Package
        public int PackageId { get; set; }
        public string PackageName { get; set; }

        public decimal Amount { get; set; }

        public string PaymentOption { get; set; }

        public DateTime TransactionDate { get; set; }

        // Pending, Completed, Cancelled
        public string Status { get; set; }
    }
}

