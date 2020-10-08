using EAutoSkola.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.ViewModel
{
    public class IzmjenaPodatakaKorisnikaVM
    {
        [Required]
        public string KorisnikId { get;  set; }
        [Required]
        public string Email { get;  set; }
        [Required]
        public string KorisnickoIme { get;  set; }
    }
}
