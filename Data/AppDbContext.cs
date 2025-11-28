

using BCrypt.Net;

using EmmascoTravelsApp1.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmmascoTravelsApp1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tracking>()
    .HasOne(t => t.Booking)
    .WithMany(b => b.Trackings)
    .HasForeignKey(t => t.BookingId);


            modelBuilder.Entity<Package>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();


            // Create default admin password
            /*string adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "Administrator",
                    Username = "admin",
                    Email = "admin@example.com",
                    Password = adminPasswordHash,
                    PhoneNumber = "0000000000",
                    Address = "System Address",
               */

            


        modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    Id = 1,
                    Name = "Tokyo",
                    Description = "Package for Tokyo. This is a nice package to fit your journey, book and get started with our team",
                    Price = 1700,
                    ImageUrl = "/image1/packageimg.jpg",
                    Status = "Active",
                    Duration = "7 Days, 6 Nights",
                    Accommodation = "4-Star Hotel",
                    Meals = "Breakfast Included",
                    Transport = "Flight + Bullet Train",
                    Activities = "Tokyo Tower, Shibuya Crossing, Mt. Fuji Tour",
                    Country = "Japan"
                },
                new Package
                {
                    Id = 2,
                    Name = "Personal Trip",
                    Description = "Customized Itenaries that you would match your prference",
                    Price = 2080,
                    ImageUrl = "/image1/packageimg1.jpg",
                    Status = "Active",
                    Duration = "Flexible",
                    Accommodation = "Customizable",
                    Meals = "Optional",
                    Transport = "Flexible Options",
                    Activities = "Custom itinerary, Personalized tours",
                    Country = "Worldwide"
                },
                new Package 
                { 
                    Id = 3, 
                    Name = "Beijing", 
                    Description = "China's diverse landscapes include stunning forests, ranging from ancient tropical rainforests to towering mountain forests.", 
                    Price = 2300, 
                    ImageUrl = "/image1/packageimg2.jpg", 
                    Status = "Active",
                    Duration = "8 Days, 7 Nights",
                    Accommodation = "3-Star Hotel",
                    Meals = "Breakfast + Lunch",
                    Transport = "Flight + High-speed Train",
                    Activities = "Great Wall, Forbidden City, Shanghai Tour",
                    Country = "China"
                },
                new Package 
                { 
                    Id = 4, 
                    Name = "London", 
                    Description = "Rich blend of historical landmarks, cultural experiences, and scenic landscapes", 
                    Price = 4100, ImageUrl = "/image1/UK.jpg", 
                    Status = "Active",
                    Duration = "10 Days, 9 Nights",
                    Accommodation = "4-Star Hotel",
                    Meals = "Breakfast",
                    Transport = "Flight + Train",
                    Activities = "London Eye, Buckingham Palace, Stonehenge",
                    Country = "United Kingdom"
                },
                new Package 
                { 
                    Id = 5, 
                    Name = "Bridgetown", 
                    Description = "Inquire in Barbados's breeze, exceptional cultures, customs to see more, feel more, and know around the world.", 
                    Price = 3000, 
                    ImageUrl = "/image1/packageimg5.jpg", 
                    Status = "Active",
                    Duration = "6 Days, 5 Nights",
                    Accommodation = "Resort",
                    Meals = "All Inclusive",
                    Transport = "Flight + Local Transport",
                    Activities = "Beaches, Island Tour, Snorkeling",
                    Country = "Barbados"
                },
                new Package 
                { Id = 6, 
                    Name = "Dubai", 
                    Description = "Habibi come to Dubai, get the best experience in Dubai", 
                    Price = 1800, 
                    ImageUrl = "/image1/packageimg10.jpg", 
                    Status = "Active",
                    Duration = "5 Days, 4 Nights",
                    Accommodation = "Luxury Hotel",
                    Meals = "Breakfast + Dinner",
                    Transport = "Flight + Private Car",
                    Activities = "Burj Khalifa, Desert Safari, Shopping Tour",
                    Country = "UAE"
                },
                new Package 
                { 
                    Id = 7, 
                    Name = "Bern", 
                    Description = "Beautiful exploration and extraodinary people to meet and connect, vibe, believe and trust us with you little step", 
                    Price = 1070, 
                    ImageUrl = "/image1/packageimg4.jpg", 
                    Status = "Active",
                    Duration = "4 Days, 3 Nights",
                    Accommodation = "3-Star Hotel",
                    Meals = "Breakfast",
                    Transport = "Flight + Train",
                    Activities = "City Tour, Old Town, Zytglogge Clock Tower",
                    Country = "Switzerland"
                },
                new Package 
                { 
                    Id = 8, 
                    Name = "Cairo", 
                    Description = "Explore Cairo with us to feels life's beauty, wonderful landscapes and their authentic city vibe they give", 
                    Price = 2200, 
                    ImageUrl = "/image1/packageimg11.jpg", 
                    Status = "Active",
                    Duration = "7 Days, 6 Nights",
                    Accommodation = "4-Star Hotel",
                    Meals = "Breakfast + Dinner",
                    Transport = "Flight + Local Bus",
                    Activities = "Pyramids of Giza, Nile Cruise, Egyptian Museum",
                    Country = "Egypt"
                },
                new Package 
                { 
                    Id = 9, 
                    Name = "New Delhi", 
                    Description = "Get the best of New Delhi, Mumbai with Emmasco Team, the coastals, cultures, and superb adventures", 
                    Price = 800, 
                    ImageUrl = "/image1/packageimg6.jpg", 
                    Status = "Active",
                    Duration = "6 Days, 5 Nights",
                    Accommodation = "3-Star Hotel",
                    Meals = "Breakfast + Lunch",
                    Transport = "Flight + Train",
                    Activities = "Gateway of India, Taj Mahal, Bollywood Tour",
                    Country = "India"
                },
                new Package 
                { 
                    Id = 10, 
                    Name = "Family Trip (Customized)", 
                    Description = "Looking for family?? no worries we're here for you, look our awesome customized itenaries to enjoy lifetime moments with your family", 
                    Price = 1900, 
                    ImageUrl = "/image1/package.jpg", 
                    Status = "Active",
                    Duration = "Flexible",
                    Accommodation = "Family Suites / Villas",
                    Meals = "Customizable",
                    Transport = "Flight + Private Van",
                    Activities = "Theme Parks, Family Adventures, Museums",
                    Country = "Worldwide"
                },
                new Package 
                { 
                    Id = 11, 
                    Name = "Friendship Travel", 
                    Description = "Enjoy our amazing friendship packages that suit your needs of personalization", 
                    Price = 2000, 
                    ImageUrl = "/image1/packageimg3.jpg", 
                    Status = "Active",
                    Duration = "5 Days, 4 Nights",
                    Accommodation = "Shared Apartments / Hotels",
                    Meals = "Breakfast + Drinks",
                    Transport = "Flight + Local Bus",
                    Activities = "Nightlife, Beaches, Hiking",
                    Country = "Various Destinations"
                },

                new Package 
                { 
                    Id = 12, 
                    Name = "Helsinki", 
                    Description = "Get to know more about Finland and get to the history of their customs, values and landscapes", 
                    Price = 500, 
                    ImageUrl = "/image1/FINLANDO.jpg", 
                    Status = "Active",
                    Duration = "5 Days, 4 Nights",
                    Accommodation = "3-Star Hotel",
                    Meals = "Breakfast",
                    Transport = "Flight + Train",
                    Activities = "Northern Lights, Helsinki Tour, Snow Activities",
                    Country = "Finland"
                },

                new Package 
                { 
                    Id = 13, 
                    Name = "Berlin", 
                    Description = "Unforgettable memories you will get, explore the beauty of Berlin and hikings etc book with us to see", 
                    Price = 6500, 
                    ImageUrl = "/image1/germanyapp.jpg", 
                    Status = "Active",
                    Duration = "8 Days, 7 Nights",
                    Accommodation = "Luxury Hotel",
                    Meals = "Breakfast + Dinner",
                    Transport = "Flight + Train",
                    Activities = "Alps Hiking, Lake Alpsee, Rhine Valley Tour",
                    Country = "Germany"
                },
                new Package 
                { 
                    Id = 14, 
                    Name = "Canberra", 
                    Description = "Enjoy the breathtaking and the best moments in Melbourne", 
                    Price = 1500, 
                    ImageUrl = "/image1/broaustra.jpg", 
                    Status = "Active",
                    Duration = "7 Days, 6 Nights",
                    Accommodation = "4-Star Hotel",
                    Meals = "Breakfast",
                    Transport = "Flight + Car Rental",
                    Activities = "Sydney Opera House, Great Barrier Reef, Melbourne Tour",
                    Country = "Australia"
                },
                new Package 
                { 
                    Id = 15, 
                    Name = "Toronto", 
                    Description = "A trip to explore the coastal and the excitement in Ontario, Canada", 
                    Price = 1000, 
                    ImageUrl = "/image1/canada0000.jpg", 
                    Status = "Active",
                    Duration = "6 Days, 5 Nights",
                    Accommodation = "3-Star Hotel",
                    Meals = "Breakfast",
                    Transport = "Flight + Train",
                    Activities = "Niagara Falls, Toronto CN Tower, National Parks",
                    Country = "Canada"
                }
            );
        }
    }
}
