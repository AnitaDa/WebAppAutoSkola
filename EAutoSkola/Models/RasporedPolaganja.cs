using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class RasporedPolaganja
    {
        public int Id { get; set; }
        public DateTime DatumPolaganja { get; set; }
        [InverseProperty("RasporedPolaganja")]
        public virtual ICollection<TerminRasporedPolaganja> TerminRasporedPolaganja { get; set; }

    }
}
