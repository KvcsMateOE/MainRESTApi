using System;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class BookByPublisher
    {
        public BookByPublisher()
        {
        }

        public string BookName { get; set; }
        public int ReleaseYear { get; set; }
        public string PublisherName { get; set; }
        public override bool Equals(object obj)
        {
            BookByPublisher b = obj as BookByPublisher;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.BookName == b.BookName && this.ReleaseYear == b.ReleaseYear && this.PublisherName == b.PublisherName;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BookName, this.ReleaseYear, this.PublisherName);
        }
        public override string ToString()
        {
            return $"BookName: {BookName}, ReleaseYear: {ReleaseYear}, PublisherName: {PublisherName}";
        }
    }
}