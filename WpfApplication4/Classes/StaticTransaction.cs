using ArLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArLib.Classes
{
    public static class StaticTransaction
    {
        public static Book selectedBook { get; set; }
        public static Reader selectedReader { get; set; }
    }
}
