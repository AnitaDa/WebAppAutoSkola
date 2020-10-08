using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class UplateViewModel
    {
        public List<Uplata> uplate { get; set; } = new List<Uplata>();
        public Uplata uplata { get; set; }

        public List<UposlenikTipUposlenika> TipUposlenikaUposlenici { get; set; }
        public List<Kandidat> kandidats { get; set; }

        public string Poruka { get; set; }

    }
}
