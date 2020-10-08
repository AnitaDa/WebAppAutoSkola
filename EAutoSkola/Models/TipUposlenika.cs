using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class TipUposlenika
    {
        [Key]
        public int Id { get; set; }
        public string Naizv { get; set; }
        //[ForeignKey("TipUposlenikaId")]
        [InverseProperty("TipUposlenika")]
       public virtual ICollection<UposlenikTipUposlenika> UposlenikTipUposlenika { get; set; }

    }
}
