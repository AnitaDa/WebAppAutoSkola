using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class Uposlenik
    {
        [Key]
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }
        [StringLength(14)]
        public string JMBG { get; set; }
        public string Email { get; set; }
        //[ForeignKey("UposlenikId")
        [InverseProperty("Uposlenik")]
        public virtual  ICollection<UposlenikTipUposlenika> UposlenikTipUposlenika { get; set; }
        [InverseProperty("Instruktor")]
        public virtual ICollection<RasporedCasovaInstruktor> RasporedCasovaInstruktor { get; set; }

        public Korisnik Korisnik { get; set; }


    }
}