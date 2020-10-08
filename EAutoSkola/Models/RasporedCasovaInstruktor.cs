using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class RasporedCasovaInstruktor
    {
        public int Id { get; set; }
        public Uposlenik Instruktor { get; set; }
        public RasporedCasova RasporedCasova { get; set; }
    }
}
