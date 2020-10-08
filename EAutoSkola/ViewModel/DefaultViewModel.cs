using EAutoSkola.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace EAutoSkola.ViewModel
{
    public class DefaultViewModel
    {
        public List<Kategorija> Kategorije { get; set; }
        public List<Vozilo> Vozila { get; set; }
        public Vozilo Vozilo { get; set; }
        public List<UposlenikTipUposlenika> UposlenikTipUposlenika { get; set; }
        public List<Satnica> Satnica { get; set; }
        public List<Kandidat> Kandidati { get; set; }
        public List<RasporedCasova> RasporedCasovaLista { get; set; }
        public List<TerminRasporedaCasova> TerminRasporedaCasova { get; set; } = new List<TerminRasporedaCasova>();
        public TerminRasporedaCasova TerminRaspored { get; set; }

        public int RasporedCasovaID { get; set; }
        public List<UposlenikTipUposlenika> Instruktori { get; set; }
        public IFormFile  Photo{ get; set; }
        public int VoziloId { get; set; }
        public int  GodinaProizvodnje {get;set;}
        public string Marka { get; set; }
        public string Model { get; set; }
        public string RegOznaka { get; set; }
        public int KategorijaId { get; set; }
    }
}
