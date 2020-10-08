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
    public class ZahtjeviController : Controller
    {
        private readonly IZahtjevRepository reposZahtjevi;
      
        public ZahtjeviController(IZahtjevRepository reposZahtjevi)
        {
            this.reposZahtjevi = reposZahtjevi;
        }
        
        public IActionResult PrikaziListuZahtjeva()
        {

            ListaZahtjevaViewModel zahtjevi = new ListaZahtjevaViewModel
            {
                Zahtjevi = reposZahtjevi.GetAll() /*baza.Zahtjev.Include(l => l.LjekarskoUvjerenje).ThenInclude(k => k.Kandidat).ToList()*/
            };
            return View(zahtjevi);

        }
        public IActionResult NeprocitaniZahtjevi()
        {

            ListaZahtjevaViewModel zahtjevi = new ListaZahtjevaViewModel
            {
                Zahtjevi = reposZahtjevi.GetNeprocitani() /*baza.Zahtjev.Include(l => l.LjekarskoUvjerenje).ThenInclude(k => k.Kandidat).ToList()*/
            };
            return PartialView( zahtjevi);

        }
        public IActionResult DetaljiZahtjeva(int ZahtjevId)
        {

            Zahtjev ponadjenZahtjev = reposZahtjevi.GetById(ZahtjevId); /*baza.Zahtjev.Where(i => i.Id == ZahtjevId).Include(i => i.LjekarskoUvjerenje).ThenInclude(u => u.Kandidat).Include(i => i.Usluga).ThenInclude(s => s.Kategorija).SingleOrDefault();*/
            ponadjenZahtjev.Procitano = true;
            reposZahtjevi.Save();
            DetaljiZahtjevaViewModel detaljiZahtjeva = new DetaljiZahtjevaViewModel
            {
                ZahtjevId = ZahtjevId,
                KandidatId=ponadjenZahtjev.LjekarskoUvjerenje.KandidatId,
                Kandidat = ponadjenZahtjev.LjekarskoUvjerenje.Kandidat.ImePrezime,
                DatumPodnosenja = ponadjenZahtjev.DatumPodnosenjaZahtjeva,
                LjekarskoUvjerenjeId = ponadjenZahtjev.LjekarskoUvjerenjeId,
                NazivUsluge = ponadjenZahtjev.Usluga.Naziv,
                Kategorija = ponadjenZahtjev.Usluga.Kategorija.Naziv
            };

            return View(detaljiZahtjeva);
        }
    }
}