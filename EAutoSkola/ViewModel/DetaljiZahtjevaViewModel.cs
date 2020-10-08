using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class DetaljiZahtjevaViewModel
    {
        public int ZahtjevId { get;  set; }
        public string Kandidat { get;  set; }
        public DateTime DatumPodnosenja { get;  set; }
        public int LjekarskoUvjerenjeId { get;  set; }
        public string NazivUsluge { get;  set; }
        public string Kategorija { get;  set; }
        public int KandidatId { get;  set; }
    }
}
