using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArLib.Classes
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string tytuł { get; set; } 
        public string autor { get; set; }
        public string ISBN { get; set; }
        public int liczbaStron { get; set; }
        public string wydawnictwo { get; set; }
        public bool czyZagubiona { get; set; }
        public string seria { get; set; }

        internal Book()
        {
            ID = this.GetHashCode();
        }
        public Book(string tytuł, string autor, string ISBN, int liczbaStron, string wydawnictwo, string seria)
        {
            this.tytuł = tytuł;
            this.autor = autor;
            this.ISBN = ISBN;
            this.liczbaStron = liczbaStron;
            this.wydawnictwo = wydawnictwo;
            czyZagubiona = false;
            this.seria = seria;
            ID = this.GetHashCode();
        }
    }
}
