using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models
{
    public class Potvrda
    {
        public int Id { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public int BrojBodova { get; set; }
        public int KandidatId { get; set; }
       public  Kandidat Kandidat { get; set; }
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
