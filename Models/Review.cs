


namespace EmmascoTravelsApp1.Models
{
    public class Review
    {
        public int Id { get; set; }

        // Foreign Key → Package
        public int PackageId { get; set; }
        public Package Package { get; set; }

        // Review details
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // 1–5 stars
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

