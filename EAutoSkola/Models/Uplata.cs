using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAutoSkola.Models
{
    public class Uplata
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumUplate { get; set; }
        public float Iznos { get; set; }
        public string Svrha { get; set; }
        public int KandidatId { get; set; }
        [ForeignKey("KandidatId")]
        public Kandidat Kandidat { get; set; }
        public int UposlenikId { get; set; }
        [ForeignKey("UposlenikId")]
        public Uposlenik Uposlenik { get; set; }
        public string Pretraga { get; set; }
    }
}
