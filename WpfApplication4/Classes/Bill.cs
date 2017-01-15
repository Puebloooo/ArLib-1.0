using System;
using System.ComponentModel.DataAnnotations;

namespace ArLib.Classes
{
    public class Bill
    {
        [Key]
        public int idKary { get; set; }
        public int idCzytelnika { get; set; }
        public DateTime dataWystawienia { get; set; }
        public double wartość { get; set; }
        public bool czyOpłacona { get; set; }

        internal Bill()
        {
            idKary = GetHashCode();
        }
        public Bill(int idCzytelnika, DateTime dataWystawienia, double wartość)
        {
            idKary = GetHashCode();
            this.idCzytelnika = idCzytelnika;
            this.dataWystawienia = dataWystawienia;
            this.wartość = wartość;
        }
    }
}
