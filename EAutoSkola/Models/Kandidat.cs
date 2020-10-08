using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace EAutoSkola.Models
{
    public class Kandidat
    {
        [Key]
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        [StringLength(14)]
        public string JMBG { get; set; }
        public bool Status{ get; set; }
        public string Email { get; set; }
     
        public RasporedCasova RasporedCasova { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
