using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class ZaboravljenaLozinkaViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Lozinka",ErrorMessage ="Lozinke se ne podudaraju!")]
        public string PotvrdaLozinke { get; set; }
        public string Token { get; set; }
    }
}
