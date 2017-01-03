using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArLib.Classes
{
    public class Reader
    {
        [Key]
        public int ID { get; set; }
        public string imię { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string nrTelefonu { get; set; }
        public int limitWypożyczeń { get; set; }

        internal Reader()
        {
            ID = this.GetHashCode();
            limitWypożyczeń = 3;
        }
        public Reader(string imię, string nazwisko, string adres, string nrTelefonu)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.adres = adres;
            this.nrTelefonu = nrTelefonu;
            limitWypożyczeń = 3;
        }
    }
}
