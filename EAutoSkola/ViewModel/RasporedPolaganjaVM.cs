using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class RasporedPolaganjaVM
    {
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public List<RasporedPolaganja> ListaRasporeda { get; set; }
        public List<TerminRasporedPolaganja> Termini { get;  set; }
        public int RasporedId { get;  set; }
        public List<Kandidat> Kandidati { get;  set; }
        public TerminRasporedPolaganja Termin { get;  set; }
    }
}
