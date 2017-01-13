using System.ComponentModel.DataAnnotations;

namespace ArLib.Classes
{
    public class Administrator
    {
        [Key]
        public int ID { get; set; }
        public string imię { get; set; }
        public string nazwisko { get; set; }
        public string login { get; set; }
        public string hasło { get; set; }

        internal Administrator()
        {
            ID = GetHashCode();
        }
    }
}
