﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ArLib.Classes
{
    public class Transaction
    {
        [Key]
        public int idWypożyczenia { get; set; }
        public int idKsiążki { get; set; }
        public int idCzytelnika { get; set; }
        public DateTime dataWypożyczenia { get; set; }
        public DateTime terminOddania { get; set; }
        public DateTime? dataZwrotu { get; set; }

        public bool czyZwrócona { get; set; }

        internal Transaction()
        {
            idWypożyczenia = GetHashCode();
        }
        public Transaction(Book książka, Reader czytelnik)
        {
            idWypożyczenia = GetHashCode();
            idKsiążki = książka.ID;
            idCzytelnika = czytelnik.ID;
            dataWypożyczenia = DateTime.Now;
            terminOddania = dataWypożyczenia.AddMonths(1);
        }
    }
}
