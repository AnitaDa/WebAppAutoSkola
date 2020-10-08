using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class Usluga
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public float Cijena { get; set; }
        public int KategorijaId { get; set; }
        [ForeignKey("KategorijaId")]
        public Kategorija Kategorija { get; set; }
    }
}
