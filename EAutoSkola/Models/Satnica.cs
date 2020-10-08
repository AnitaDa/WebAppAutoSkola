using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAutoSkola.Models
{
    public class Satnica
    {
        [Key]
        public int Id { get; set; }
        public string TerminOD { get; set; }
        public string TerminDO { get; set; }
        public DateTime Datum { get; set; }
      
    }
}
