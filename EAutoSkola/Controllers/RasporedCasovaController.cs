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
    public class RasporedCasovaController : Controller
    {
        private readonly IRasporedCasovaRepository reposRaspored;
        private readonly IKandidatiRepository reposKandidati;
        private readonly IUposleniciRepository reposUposlenici;
        private readonly ITerminRasporedaCasova reposTerminRasporedCasova;
        private readonly ISatnicaRepository reposSatnica;
        private readonly IvozilaRepository reposVozila;
        private readonly IUposlenikTipUposlenika reposUposlenikTipUposlenika;

        public RasporedCasovaController(IRasporedCasovaRepository reposRaspored, 
            IKandidatiRepository reposKandidati, 
            IUposleniciRepository reposUposlenici, 
            ITerminRasporedaCasova reposTerminRasporedCasova,
            ISatnicaRepository reposSatnica,
            IvozilaRepository reposVozila,
            IUposlenikTipUposlenika reposUposlenikTipUposlenika)
        {
            this.reposRaspored = reposRaspored;
            this.reposKandidati = reposKandidati;
            this.reposUposlenici = reposUposlenici;
            this.reposTerminRasporedCasova = reposTerminRasporedCasova;
            this.reposSatnica = reposSatnica;
            this.reposVozila = reposVozila;
            this.reposUposlenikTipUposlenika = reposUposlenikTipUposlenika;
        }

        public IActionResult KreirajRaspoeredCasovaForm()
        {

            List<Kandidat> kandidati = reposKandidati.GetAll();/*Kandidati.ToList();*/
            List<UposlenikTipUposlenika> instruktori = reposUposlenikTipUposlenika.GetInstruktori();

            DefaultViewModel vozilaVM = new DefaultViewModel()
            {
                Kandidati = kandidati,
                Instruktori = instruktori
            };
            return View(vozilaVM);
        }
        public IActionResult PrikaziRaspored()
        {

            List<RasporedCasova> raspored = reposRaspored.GetAll();/*RasporedCasova.Include(m => m.Kandidat).ToList();*/
            DefaultViewModel rasporedVM = new DefaultViewModel
            {
                RasporedCasovaLista = raspored
            };
            return View(rasporedVM);
        }
        public IActionResult KreirajRaspored(int KandidatId)
        {

            Kandidat k = reposKandidati.GetById(KandidatId);/*Kandidati.Find(KandidatId);*/
            RasporedCasova raspored = new RasporedCasova()
            {
                Kandidat = k
            };
            reposRaspored.Add(raspored);
            //baza.SaveChanges();
            //baza.Dispose();
            return RedirectToAction(nameof(PrikaziRaspored));
        }

        public IActionResult DetaljiRasporedCasova(int RasporedId)
        {

            List<TerminRasporedaCasova> TerminRasporedaC = reposTerminRasporedCasova.GetAll(RasporedId); /*TerminRasporedaCasova.Include(n => n.RasporedCasova).Include(n => n.Vozilo).Include(n => n.Uposlenik).Where(m => m.RasporedCasovaId == RasporedId).ToList();*/
            DefaultViewModel rasporedTerminVM = new DefaultViewModel()
            {
                TerminRasporedaCasova = TerminRasporedaC,
                RasporedCasovaID = RasporedId

            };

            return View(rasporedTerminVM);
        }

        public IActionResult DodajTerminForm(int RasporedId)
        {

            List<Satnica> satnica = reposSatnica.GetAll();
            List<Vozilo> vozila = reposVozila.GetAll();/*Vozila.ToList();*/
            List<UposlenikTipUposlenika> uposleniciTipUposlenika = reposUposlenikTipUposlenika.GetInstruktori();/*uposlenikTipUposlenika.Include(b => b.Uposlenik).Where(b => b.TipUposlenika.Id == 1).ToList();*/
            DefaultViewModel terminVM = new DefaultViewModel()
            {
                Vozila = vozila,
                UposlenikTipUposlenika = uposleniciTipUposlenika,
                RasporedCasovaID = RasporedId
                
            };

            return View(terminVM);
        }
        public IActionResult Dodajtermin(int TerminRasporedCasovaId, int RasporedId, DateTime Datum, string TerminOd, string TerminDo, int VoziloId, int UposlenikId)
        {

            Vozilo v = reposVozila.GetById(VoziloId);/*Vozila.Find(VoziloId);*/
            Uposlenik u = reposUposlenici.GetById(UposlenikId);/*Uposlenici.Find(UposlenikId);*/
            RasporedCasova raspored = reposRaspored.GetById(RasporedId);
            TerminRasporedaCasova terminRaspored;
            if (TerminRasporedCasovaId == 0)
            {
                terminRaspored = new TerminRasporedaCasova();
                terminRaspored.Datum = Datum;
                terminRaspored.TerminOd = TerminOd;
                terminRaspored.TerminDo = TerminDo;
                terminRaspored.Vozilo = v;
                terminRaspored.Uposlenik = u;
                terminRaspored.RasporedCasova = raspored;
                reposTerminRasporedCasova.Add(terminRaspored);
            }
            else
            {
                terminRaspored = reposTerminRasporedCasova.GetById(TerminRasporedCasovaId);
            }

            terminRaspored.Datum = Datum;
            terminRaspored.TerminOd = TerminOd;
            terminRaspored.TerminDo = TerminDo;
            terminRaspored.Vozilo = v;
            terminRaspored.Uposlenik = u;
            terminRaspored.RasporedCasova = raspored;

            reposTerminRasporedCasova.Save();
            
            return RedirectToAction("DetaljiRasporedCasova", "RasporedCasova", new { RasporedId = @RasporedId });
        }
        public IActionResult UrediTermin(int TerminId)
        {

            TerminRasporedaCasova terminRaspored = reposTerminRasporedCasova.GetById(TerminId);/*TerminRasporedaCasova.Find(TerminId);*/
            List<UposlenikTipUposlenika> tipoviUposlenici = reposUposlenikTipUposlenika.GetInstruktori();/*uposlenikTipUposlenika.Include(x => x.Uposlenik).Include(x => x.TipUposlenika).Where(x => x.TipUposlenika.Id == 1).ToList();*/
            List<Vozilo> vozila = reposVozila.GetAll(); /*Vozila.ToList();*/
            DefaultViewModel terminRasporedVM = new DefaultViewModel()
            {
                TerminRaspored = terminRaspored,
                UposlenikTipUposlenika = tipoviUposlenici,
                Vozila = vozila
            };
            return View(terminRasporedVM);
        }
    }
}