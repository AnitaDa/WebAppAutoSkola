using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.Models;
using EAutoSkola.Models.Repository;
using EAutoSkola.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAutoSkola.Controllers
{
    [Authorize(Roles = "Referent")]
    public class RasporedPolaganjaController : Controller
    {
        private readonly IRasporedPolaganjaRepository reposRaspored;
        private readonly ITerminRasporedPolaganjaRepository reposTermin;
        private readonly IKandidatiRepository reposKandidat;


        public RasporedPolaganjaController(IRasporedPolaganjaRepository reposRaspored, ITerminRasporedPolaganjaRepository reposTermin, IKandidatiRepository reposKandidat)
        {
            this.reposRaspored = reposRaspored;
            this.reposTermin = reposTermin;
            this.reposKandidat = reposKandidat;
        }
        [HttpGet]
        public IActionResult KreirajRaspored()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KreirajRaspored(RasporedPolaganjaVM raspored)
        {
            RasporedPolaganja noviRaspored = new RasporedPolaganja { 
            DatumPolaganja=raspored.Datum
            };
            reposRaspored.Add(noviRaspored);
            return RedirectToAction("PrikaziRaspored");

        }
        public IActionResult PrikaziRaspored()
        {
            List<RasporedPolaganja> raspPolaganja = reposRaspored.GetAll();
            RasporedPolaganjaVM lista = new RasporedPolaganjaVM {
                ListaRasporeda = raspPolaganja
            };
            return View(lista);
        }
        public IActionResult DetaljiRasporedaPolaganja(int RasporedId)
        {
            List<TerminRasporedPolaganja> termini = reposTermin.GetByRasporedId(RasporedId);
            RasporedPolaganjaVM tem = new RasporedPolaganjaVM {
            RasporedId=RasporedId,
            Termini=termini
            };
            return View(tem);
        }
        public IActionResult DodajTerminForm(int RasporedId)
        {
            List<Kandidat> kandidati = reposKandidat.GetAll();
            RasporedPolaganjaVM terminVM = new RasporedPolaganjaVM()
            {
                RasporedId=RasporedId,
               Kandidati=kandidati
            };

            return View(terminVM);
        }
        public IActionResult Dodajtermin(int TerminRasporedaPolaganjaId,int RasporedId, string TerminOd, string TerminDo,int KandidatId)
        {

            TerminRasporedPolaganja terminRaspored;
            if (TerminRasporedaPolaganjaId == 0)
            {
                terminRaspored = new TerminRasporedPolaganja();
               
                terminRaspored.TerminOd = TerminOd;
                terminRaspored.TerminDo = TerminDo;
                terminRaspored.KandidatId = KandidatId;
                terminRaspored.RasporedPolaganjaId = RasporedId;
                reposTermin.Add(terminRaspored);
            }
            else
            {
                terminRaspored = reposTermin.GetById(TerminRasporedaPolaganjaId);
                terminRaspored.TerminOd = TerminOd;
                terminRaspored.TerminDo = TerminDo;
                terminRaspored.KandidatId = KandidatId;
                reposTermin.Save();

            }

            return RedirectToAction("DetaljiRasporedaPolaganja", "RasporedPolaganja", new { RasporedId = @RasporedId });
        }
        public IActionResult UrediTermin(int TerminId)
        {

            TerminRasporedPolaganja terminRaspored = reposTermin.GetById(TerminId);
            List<Kandidat> kandidati = reposKandidat.GetAll();
            RasporedPolaganjaVM terminRasporedVM = new RasporedPolaganjaVM()
            {
                Termin = terminRaspored,
                Kandidati=kandidati
            };
            return View(terminRasporedVM);
        }
    }
}