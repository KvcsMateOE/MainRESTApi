using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
            Publishers = new HashSet<Publisher>();
            Title = string.Empty;
            Translator = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public string? Genre { get; set; }

        [Required]
        public string Translator { get; set; }

        //public int? Budget { get; set; }

        public double? Rating { get; set; }
        public int Authorid { get; set; }
        public int Publisherid { get; set; }
        
        [NotMapped]
        public virtual ICollection<Author> Authors { get; }
        [NotMapped]
        public virtual ICollection<Publisher> Publishers { get; }
        [NotMapped]
        public virtual Author Author { get; set; }
        [NotMapped]
        public virtual Publisher Publisher { get; set; }

        public override string ToString()
        {
            return $"BookId: {BookId}\nBook name: {Title}\nRelease year: {ReleaseYear}\nGenre: {Genre}\nTranslator: {Translator}\nRating: {Rating}\n Authorid {Authorid}\n Publisherid: {Publisherid}";
        }
    }
}
