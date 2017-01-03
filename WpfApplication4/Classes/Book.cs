using System.ComponentModel.DataAnnotations;

namespace ArLib.Classes
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string tytuł { get; set; } 
        public string autor { get; set; }
        public string ISBN { get; set; }
        public string liczbaStron { get; set; }
        public string wydawnictwo { get; set; }
        public bool czyZagubiona { get; set; }
        public string seria { get; set; }
        public bool czyWypożyczona { get; set; }

        internal Book()
        {
            ID = GetHashCode();
        }
        public Book(string tytuł, string autor, string ISBN, string liczbaStron, string wydawnictwo, string seria)
        {
            this.tytuł = tytuł;
            this.autor = autor;
            this.ISBN = ISBN;
            this.liczbaStron = liczbaStron;
            this.wydawnictwo = wydawnictwo;
            czyZagubiona = false;
            this.seria = seria;
            ID = GetHashCode();
        }
    }
}
