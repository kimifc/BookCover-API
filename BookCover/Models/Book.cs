using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookCover.Models
{
    public class Book
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Edition { get; set; }
        public string HighlightInfo { get; set; }
        public string SpecialOfferInfo { get; set; }
        public string ExtraInfo { get; set; }
        public string BrandImage { get; set; }
        public string SubInfo { get; set; }
       
        public virtual List<KeyPoint> KeyPoints { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}