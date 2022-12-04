using System;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class OlderThan30
    {
        public OlderThan30()
        {
        }

        public string AuthorName { get; set; }
        public int? Birthyear { get; set; }
        public string BookTitle { get; set; }
        public string PublisherName { get; set; }
        public override bool Equals(object obj)
        {
            OlderThan30 o = obj as OlderThan30;
            if (o == null)
            {
                return false;
            }
            else
            {
                return this.AuthorName == o.AuthorName && this.Birthyear == o.Birthyear && this.BookTitle == this.BookTitle && this.PublisherName == o.PublisherName;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AuthorName, this.Birthyear, this.BookTitle, this.PublisherName);
        }
        public override string ToString()
        {
            return $"AuthorName: {AuthorName}, Birthyear: {Birthyear}, BookTitle: {BookTitle}, PublisherName: {PublisherName}";
        }
    }
}