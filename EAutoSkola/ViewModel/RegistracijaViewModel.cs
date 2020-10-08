using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class RegistracijaViewModel
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [StringLength(14,ErrorMessage ="Matcni broj mora sadrzavati 14 karaktera.")]
        public string JMBG { get; set; }

        [Required]
        public string KorisnickoIme { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Lozinka",ErrorMessage ="Lozinka i potvrdjena lozinka se ne podudaraju.")]
        public string PotvrdjenaLozinka { get; set; }
    }
}
