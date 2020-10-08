using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class KorisniciViewModel
    {
        public List<UposlenikTipUposlenika> UposleniciTipUposlenika { get; set; }
        public List<Kandidat> Kandidati { get; set; }

    }
}
