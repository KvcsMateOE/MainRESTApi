﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCZ6Y1_HFT_2022231.Models
{
  public class Publisher
    {
        public Publisher()
        {
            //Books3 = new HashSet<Book>();
            //PublisherName = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        
        public string PublisherName { get; set; }

        public string Address { get; set; }
        [Required]
       
        public int NumberOfContacts { get; set; }

        [Required]
       
        public int PrintingCapacity { get; set; }

        [Required]
        public int PublishingPrice { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"PublisherId: {PublisherId}\nPublisher name: {PublisherName}\nAddress: {Address}\nNumber of contacts: {NumberOfContacts}\nPrinting capacity: {PrintingCapacity}\nPublishing price: {PublishingPrice}\n";
        }
    }
}
