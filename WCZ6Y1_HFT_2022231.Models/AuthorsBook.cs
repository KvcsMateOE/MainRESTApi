using System;

namespace WCZ6Y1_HFT_2022231.Models
{
    public class AuthorsBook
    {
        public AuthorsBook()
        {
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public override bool Equals(object obj)
        {
            AuthorsBook a = obj as AuthorsBook;
            if (a == null)
            {
                return false;
            }
            else
            {
                return this.Name == a.Name && this.Country == a.Country;
            }


        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Country);
        }
        public override string ToString()
        {
            return $"AuthorName: {Name}, Country: {Country}";
        }
    }
}