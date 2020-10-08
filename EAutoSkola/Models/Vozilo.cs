using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EAutoSkola.Models
{
    public class Vozilo
    {
        [Key]
        public int Id { get; set; }
        public int GodinaProizvodnje { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string RegistarskaOznaka { get; set; }
        public int KategorijaId { get; set; }
        [ForeignKey("KategorijaId")]
        public Kategorija Kategorija { get; set; }
        public string PhotoPath { get; set; }
    }
}
