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
    public class UslugeController : Controller
    {
        private readonly IUslugeRepository reposUsluge;
        private readonly IKategorijaRepository reposKategorija;

        public UslugeController(IUslugeRepository reposUsluge,IKategorijaRepository reposKategorija)
        {
            this.reposUsluge = reposUsluge;
            this.reposKategorija = reposKategorija;
        }
        [AllowAnonymous]
        public IActionResult PrikaziUsluge()
        {

            List<Usluga> us = reposUsluge.GetAll();/*baza.Usluge.Include(s => s.Kategorija).ToList();*/
            var uslugeView = new UslugeViewModel
            {
                Usluge = us
            };
            return View(uslugeView);
        }
        public IActionResult DodajUsluguForm()
        {

            List<Kategorija> kat = reposKategorija.GetAll();/*baza.Kategorije.ToList();*/
            var kateg = new KategorijeViewModel
            {
                Kategorije = kat
            };
            return View(kateg);
        }
        public IActionResult DodajUslugu(string Naziv, string Opis, float Cijena, int KategorijaId)
        {

            Usluga u = new Usluga
            {
                Naziv = Naziv,
                Opis = Opis,
                Cijena = Cijena,
                KategorijaId = KategorijaId
            };
            reposUsluge.Add(u);

            return RedirectToAction("PrikaziUsluge");
        }
        public IActionResult ObrisiUslugu(int UslugaId)
        {

            Usluga u = reposUsluge.GetById(UslugaId); /*baza.Usluge.Find(UslugaId);*/
            if (u == null)
            {
                Content("Nepostojeca uplata!");
            }
            else
            {
                reposUsluge.Remove(u);
            }
            return RedirectToAction(nameof(PrikaziUsluge));
        }
        public IActionResult UrediUslugu(int UslugaId)
        {

            Usluga usluga = reposUsluge.GetById(UslugaId); /*baza.Usluge.Find(UslugaId);*/
            List<Kategorija> kategorije = reposKategorija.GetAll();
            UslugeViewModel uslugeVM = new UslugeViewModel()
            {
                Usluga = usluga,
                Kategorije = kategorije
            };
            return View(uslugeVM);
        }
        public IActionResult DodajUredjenuUslugu(int UslugaId, string Naziv, string Opis,int Cijena, int KategorijaId)
        {

            Usluga k = reposUsluge.GetById(UslugaId);/* baza.Usluge.Find(UslugaId);*/
            k.Naziv = Naziv;
            k.Opis = Opis;
            k.Cijena = Cijena;
            k.KategorijaId = KategorijaId;
            reposUsluge.Save();
           
            return RedirectToAction(nameof(PrikaziUsluge));
        }
    }
}