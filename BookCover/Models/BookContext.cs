namespace BookCover.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<KeyPoint> KeyPoints { get; set; }
    }
}