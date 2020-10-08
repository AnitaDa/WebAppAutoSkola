using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class Plata
    {
        public int Id { get; set; }
        public float Iznos { get; set; }
        
        public DateTime Datum { get; set; }
        public int UposlenikId { get; set; }
        public Uposlenik Uposlenik { get; set; }
    }
}
