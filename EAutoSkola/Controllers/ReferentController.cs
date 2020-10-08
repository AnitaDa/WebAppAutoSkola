using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.EF;
using EAutoSkola.Models;
using EAutoSkola.ViewModel;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using ReflectionIT.Mvc.Paging;
using System.IO;
using EAutoSkola.Models.Repository;


namespace EAutoSkola.Controllers
{
    [Authorize(Roles = "Referent")]
    public class ReferentController : Controller
    {
        private readonly IKandidatiRepository reposKandidat;
        private readonly IUposleniciRepository reposUposlenik;
        private readonly IvozilaRepository reposVozila;
        private readonly IZahtjevRepository reposZahtjev;


        public ReferentController(IKandidatiRepository reposKandidat, IUposleniciRepository reposUposlenik, IvozilaRepository reposVozila, IZahtjevRepository reposZahtjev)
        {
            this.reposKandidat = reposKandidat;
            this.reposUposlenik = reposUposlenik;
            this.reposVozila = reposVozila;
            this.reposZahtjev = reposZahtjev;

        }
        //pocetna
        public IActionResult PocetnaReferent()
        {
            StatistikaViewModel statistika = new StatistikaViewModel
            {
                Godina = DateTime.Now.Year - 1993,
                BrojKandidata = reposKandidat.Count(),
                BrojUposlenika = reposUposlenik.Count(),
                BrojVozila = reposVozila.Count(),
                BrojZahtjeva = reposZahtjev.Count()
            };
            return View(statistika);
        }
      

    }
}
