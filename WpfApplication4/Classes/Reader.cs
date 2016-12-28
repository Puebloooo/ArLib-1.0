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
        public string imię { get; set; } = "Abecadło";
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string nrTelefonu { get; set; }
        public int limitWypożyczeń { get; set; }

    }
}
