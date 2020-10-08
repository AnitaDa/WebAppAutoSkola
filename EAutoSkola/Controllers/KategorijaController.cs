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
    public class KategorijaController : Controller
    {
        private readonly IKategorijaRepository repo;
        private readonly IPotvrdaRepository reposPotvda;
        private readonly IUslugeRepository reposUsluga;
        private readonly IvozilaRepository reposVozilo;



        public KategorijaController(IKategorijaRepository repo, IPotvrdaRepository reposPotvda, IUslugeRepository reposUsluga, IvozilaRepository reposVozilo)
        {
            this.repo = repo;
            this.reposPotvda = reposPotvda;
            this.reposUsluga = reposUsluga;
            this.reposVozilo = reposVozilo;

        }

        public IActionResult DodajKategorijuForm()
        {
            return View();
        }
        public IActionResult PrikaziKategorije()
        {

            List<Kategorija> kategorije = repo.GetAll();
            var viewModel = new DefaultViewModel
            {
                Kategorije = kategorije
            };
            return View(viewModel);
        }
        public IActionResult UrediKategoriju(int KategorijaId)
        {

            Kategorija kategorija = repo.GetByID(KategorijaId);
            KategorijeViewModel kategorijaVM = new KategorijeViewModel()
            {
                Kategorija = kategorija
            };
            return View(kategorijaVM);
        }
        public IActionResult ObrisiKategoriju(int KategorijaId)
        {
            //Provera da li postoji zapis u drugim tabelama
            if (reposPotvda.Kategorija(KategorijaId) == true ||
                reposUsluga.Kategorija(KategorijaId) == true ||
                   reposVozilo.Kategorija(KategorijaId) == true
                 ) return View("Alert");
            Kategorija ka = repo.GetByID(KategorijaId);
            if (ka != null)
            {
                repo.Remove(ka);
            }
                        
            return RedirectToAction(nameof(PrikaziKategorije));
        }
        public IActionResult DodajUredjenuKategoriju(int KategorijaId, string Naziv, string Opis)
        {

            Kategorija k = repo.GetByID(KategorijaId);
            k.Naziv = Naziv;
            k.Opis = Opis;
            repo.Save();
            return RedirectToAction("PrikaziKategorije");
        }
        public IActionResult DodajKategoriju(string Naziv, string Opis)
        {

            Kategorija kat = new Kategorija();
            kat.Naziv = Naziv;
            kat.Opis = Opis;
            repo.Add(kat);
            return Redirect("/Kategorija/PrikaziKategorije");
        }
    }
}