using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EAutoSkola.Models
{
    public class RasporedCasova
    {
        [Key]
        public int Id { get; set; }
        public int KandidatId { get; set; }
        [ForeignKey("KandidatId")]
        public Kandidat Kandidat { get; set; }
        [InverseProperty("RasporedCasova")]
        public virtual ICollection<RasporedCasovaInstruktor> RasporedCasovaInstruktor { get; set; }
       
    }
}
