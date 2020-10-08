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
    public class LjekarskoUvjerenjeController : Controller
    {
        private readonly ILjekarskoUvjerenje repos;
        public LjekarskoUvjerenjeController(ILjekarskoUvjerenje repo)
        {
            repos = repo;
        }

        public IActionResult PrikaziLjekarskoUvjerenje(int LjekarskoID)
        {

            LjekarskoUvjerenje pronadjenoLjekarsko = repos.GetById(LjekarskoID);
               
            PrikazLjekarskogUvjerenjeViewModel prikazLjekarskog = new PrikazLjekarskogUvjerenjeViewModel
            {
                LjekarskoId = pronadjenoLjekarsko.Id,
                DatumIzdavanja = pronadjenoLjekarsko.DatumIzdavanje,
                DatumVazenja = pronadjenoLjekarsko.DatumVazenja,
                Opis = pronadjenoLjekarsko.Opis,
                Kandidat = pronadjenoLjekarsko.Kandidat.ImePrezime,
                ZdrastveniRadnik = pronadjenoLjekarsko.ZdrastveniRadnik.ImePrezime,
                Sposoban = pronadjenoLjekarsko.SposobanZaObuku
            };
            return View(prikazLjekarskog);
        }
    }
}