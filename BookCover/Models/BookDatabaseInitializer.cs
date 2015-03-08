using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookCover.Models
{
    public class BookDatabaseInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            base.Seed(context);

            var books = new List<Book>();

            books.Add(new Book
            {
                Title = "Book Title",
                SubTitle = "Sub Title",
                Edition = "Edition",
                ExtraInfo = "Extra Info",
                BrandImage = "Brand Image",
                SubInfo = "Sub Info",
                KeyPoints = (new KeyPoint[]
                {
                    new KeyPoint { KeyPointInfo = "This is the best book in this world!" },
                    new KeyPoint { KeyPointInfo = "This can be the best book in this world!" },
                    new KeyPoint { KeyPointInfo = "This will be the best book in this world!" },
                    new KeyPoint { KeyPointInfo = "This should be the best book in this world!" }
                }).ToList(),
                Authors = (new Author[]
                {
                    new Author { FullName = "Kimi Chen", Title = "BS" }
                }).ToList()
            });

            books.ForEach(a => context.Books.Add(a));

            context.SaveChanges();
        }
    }
}