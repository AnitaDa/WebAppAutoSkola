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
    public class PotvrdaController : Controller
    {
        private readonly IKandidatiRepository reposKandidati;
        private readonly IKategorijaRepository reposKategorija;
        private readonly IPotvrdaRepository reposPotvrda;
        private readonly IUposleniciRepository reposUposlenici;


        public PotvrdaController(IKandidatiRepository reposKandidati, IKategorijaRepository reposKategorija, IPotvrdaRepository reposPotvrda, IUposleniciRepository reposUposlenici)
        {
            this.reposKandidati = reposKandidati;
            this.reposKategorija = reposKategorija;
            this.reposPotvrda = reposPotvrda;
            this.reposUposlenici = reposUposlenici;

        }
        public IActionResult EvidentirajPotvrduForm() 
        {
            List<Kategorija> kategorije = reposKategorija.GetAll();
            List<Kandidat> kandidati = reposKandidati.GetAll();

            PotvrdaViewModel potvrda = new PotvrdaViewModel { 
            Kategorije=kategorije,
            Kandidati=kandidati
            };
            return View(potvrda);
        }
        public IActionResult SnimiPotvrdu(DateTime Datum,int Bodovi,int KategorijaId, int KandidatId, int PotvrdaId=0)
        {
            if (PotvrdaId == 0)
            {
                Potvrda novaPotvrda = new Potvrda
                {
                    DatumPolaganja = Datum,
                    BrojBodova = Bodovi,
                    KategorijaId = KategorijaId,
                    KandidatId = KandidatId
                };
                reposPotvrda.Add(novaPotvrda);
            }
            else
            {
                Potvrda pronadjenaPotv = reposPotvrda.GetById(PotvrdaId);
                pronadjenaPotv.DatumPolaganja = Datum;
                pronadjenaPotv.BrojBodova = Bodovi;
                pronadjenaPotv.KategorijaId = KategorijaId;
                pronadjenaPotv.KandidatId = KandidatId;
                reposPotvrda.Save();
            }
            return RedirectToAction("PrikaziPotvrde");
        }
        public IActionResult PrikaziPotvrde()
        {
            List<Potvrda> potvrde = reposPotvrda.GetAll();
            PotvrdaViewModel p = new PotvrdaViewModel()
            {
               Potvrde=potvrde
            };
            return View(p);
        }
        public IActionResult UrediPotvrdu(int PotvrdaId)
        {
           
            List<Kategorija> kategorije = reposKategorija.GetAll();
            List<Kandidat> kandidati = reposKandidati.GetAll();
            Potvrda potvrda = reposPotvrda.GetById(PotvrdaId);
            
           PotvrdaViewModel potvrdaUredjivanje = new PotvrdaViewModel() {
             
                Kategorije=kategorije,
                Kandidati=kandidati,
                Potvrda=potvrda
            };
            return View(potvrdaUredjivanje);
        }
    }
}