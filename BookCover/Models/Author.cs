using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace BookCover.Models
{
    public class Author
    {
        [Required]
        public int AuthorID { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }

        public int BookId { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; } 
    }
}