using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class PotvrdaViewModel
    {
        public List<Kategorija> Kategorije { get;  set; }
        public List<Kandidat> Kandidati { get;  set; }
        public List<Potvrda> Potvrde { get;  set; }
        public List<Uposlenik> Uposlenici { get;  set; }
        public int PotvrdaId { get;  set; }
        public Potvrda Potvrda { get;  set; }
    }
}
