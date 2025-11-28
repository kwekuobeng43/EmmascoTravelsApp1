

using System;
using System.ComponentModel.DataAnnotations;

namespace EmmascoTravelsApp1.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int PackageId { get; set; }

        public Package? Package { get; set; }// Navigation property (NO [Required])

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string CustomerEmail { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Number of people must be at least 1")]
        [Display(Name = "Number of People")]
        public int NumberOfPeople { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Travel Date")]
        public DateTime TravelDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
        public string PaymentOption { get; set; }

        [Display(Name = "Booking Status")]
        public string Status { get; set; } = "Pending";


        //this for relationship between booking and tracking
        public ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();
    }
}



