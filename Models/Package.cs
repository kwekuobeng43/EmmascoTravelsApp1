using System.ComponentModel.DataAnnotations;

namespace EmmascoTravelsApp1.Models
{

    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; } // e.g. "7 Days, 6 Nights"
        public string Accommodation { get; set; } // e.g. "4-Star Hotel"
        public string Meals { get; set; } // e.g. "Breakfast & Dinner"
        public string Transport { get; set; } // e.g. "Flight + Local Bus"
        public string Activities { get; set; } // e.g. "City Tour, Beach, Museum"
        public string Country { get; set; } // e.g. "Japan"

        // Navigation property
        public ICollection<Review> Reviews { get; set; }
    }
}