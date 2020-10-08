using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class Zahtjev
    {
        public int Id { get; set; }
        public DateTime DatumPodnosenjaZahtjeva { get; set; }
        public int LjekarskoUvjerenjeId { get; set; }
        public LjekarskoUvjerenje LjekarskoUvjerenje { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }
        public bool Procitano { get; set; } = false;
        public bool Odbacen { get; set; } = false;
    }
}
