using System;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class BooksByAuthor
    {
        public BooksByAuthor()
        {
        }

        public string AuthorName { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $"AuthorName: {AuthorName}, Title: {Title}";


        }
        public override bool Equals(object obj)
        {
            BooksByAuthor b = obj as BooksByAuthor;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.AuthorName == b.AuthorName && this.Title == b.Title;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AuthorName, this.Title);
        }
    }
}