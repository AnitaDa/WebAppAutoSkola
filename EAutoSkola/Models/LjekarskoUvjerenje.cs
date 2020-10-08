using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class LjekarskoUvjerenje
    {
        public int Id { get; set; }
        public DateTime DatumIzdavanje { get; set; }
        public DateTime DatumVazenja { get; set; }
        public string Opis { get; set; }
        public int KandidatId { get; set; }

        internal static object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public Kandidat Kandidat { get; set; }
        public bool  SposobanZaObuku{get;set;}
        public int ZdrastveniRadnikId { get; set; }
        public ZdrastveniRadnik ZdrastveniRadnik { get; set; }
    }
}
