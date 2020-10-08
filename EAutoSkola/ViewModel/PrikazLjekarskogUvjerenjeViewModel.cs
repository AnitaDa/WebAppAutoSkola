using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class PrikazLjekarskogUvjerenjeViewModel
    {
        public int LjekarskoId { get;  set; }
        public DateTime DatumIzdavanja { get;  set; }
        public DateTime DatumVazenja { get;  set; }
        public string Kandidat { get;  set; }
        public string Opis { get;  set; }
        public string ZdrastveniRadnik { get;  set; }
        public bool Sposoban { get;  set; }
    }
}
