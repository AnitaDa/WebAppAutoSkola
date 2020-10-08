using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class TerminRasporedPolaganja
    {
        public int Id { get; set; }
        public string TerminOd { get; set; }
        public string TerminDo { get; set; }
        public int KandidatId { get; set; }
        public Kandidat Kandidat { get; set; }
        public int RasporedPolaganjaId { get; set; }
        public RasporedPolaganja RasporedPolaganja { get; set; }

    }
}
