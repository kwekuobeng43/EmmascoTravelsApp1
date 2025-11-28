


namespace EmmascoTravelsApp1.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalPackages { get; set; }
        public int TotalBookings { get; set; }
        public int TotalTrackings { get; set; }


        // Booking Status Stats
        public int CompletedBookings { get; set; }
        public int PendingBookings { get; set; }
        public int CancelledBookings { get; set; }

      
        
    }
}

