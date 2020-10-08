using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class PlataViewModel
    {
        public List<Uposlenik> Uposlenici { get;  set; }
        public float Iznos { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int UposlenikId { get; set; }
        public List<Plata> ListaPlata { get;  set; }
        public Plata Plata { get;  set; }
        public int PlataId { get;  set; }
    }
}
