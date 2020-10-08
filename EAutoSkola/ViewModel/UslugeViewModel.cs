using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class UslugeViewModel
    {
        public List<Usluga> Usluge { get; set; }
        public Usluga Usluga { get; set; }
        public List<Kategorija> Kategorije { get; internal set; }
    }
}
