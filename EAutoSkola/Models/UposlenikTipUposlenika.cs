using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class UposlenikTipUposlenika
    {
        [Key]
  public int Id { get; set; }
        //public int UposlenikId { get; set; }
        //[ForeignKey("UposlenikId")]

        public Uposlenik Uposlenik { get; set; }
        //public int TipUposlenikaId { get; set; }
        //[ForeignKey("TipUposlenikaId")]

        public TipUposlenika TipUposlenika { get; set; }
       
    }
}
