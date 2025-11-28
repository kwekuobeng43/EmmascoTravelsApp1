  


namespace EmmascoTravelsApp1.Models
{
    public class Tracking
    {
        public int Id { get; set; }
        public int BookingId { get; set; }  // Foreign key
        public Booking Booking { get; set; } // Navigation property for Booking Controller to deliver to the varoius actions
        public string Status { get; set; }
        public DateTime Date { get; set; }  // <-- add this



    }
}

    