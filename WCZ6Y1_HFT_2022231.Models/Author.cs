using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class Author
    {
      
            public Author()
            {
                //Books2 = new HashSet<Book>();
                //Name = string.Empty;
            }

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AuthorId { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            public int? BirthYear { get; set; }

            [MaxLength(100)]
            public string HomeCountry { get; set; }

            [Required]
            [Range(0, 1)]
            public int Gender { get; set; }
        public virtual Publisher AuthorPublisher { get; set; }
        public virtual int AuthorPublisherID { get; set; }

        public override string ToString()
            {
                return $"AuthorId: {AuthorId}\nName: {Name}\nBirth year: {BirthYear}\nHome country: {HomeCountry}\nGender: {Gender}\n";
            }
        }
    }

