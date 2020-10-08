using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EAutoSkola.Models
{
    public class TerminRasporedaCasova
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string TerminOd { get; set; }
        public string TerminDo { get; set; }
        public int UposlenikId { get; set; }
        [ForeignKey("UposlenikId")]
        public Uposlenik Uposlenik { get; set; }

        public int RasporedCasovaId { get; set; }
        [ForeignKey("RasporedCasovaId")]
        public RasporedCasova RasporedCasova { get; set; }
        public int VoziloId { get; set; }
        [ForeignKey("VoziloId")]
        public Vozilo Vozilo { get; set; }

       
    }
}
