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
    public class PlataController : Controller
    {
        private readonly IUposleniciRepository reposUposlenici;
        private readonly IPlataRepository reposPlata;

        public PlataController(IUposleniciRepository reposUposlenici, IPlataRepository reposPlata)
        {
            this.reposUposlenici = reposUposlenici;
            this.reposPlata = reposPlata;

        }
        public IActionResult EvidentirajPlatu()
        {
            List<Uposlenik> uposlenici = reposUposlenici.GetAll();
            PlataViewModel plateVM = new PlataViewModel {
                Uposlenici = uposlenici
            };
            return View(plateVM);
        }
        public IActionResult SnimiPlatu(int PlataId,int Iznos, DateTime Datum, int UposlenikId)
        {
            if (PlataId == 0)
            {
                Plata novaPlata = new Plata
                {
                    Iznos = Iznos,
                    Datum = Datum,
                    UposlenikId = UposlenikId
                };
                reposPlata.Add(novaPlata);
            }
            else
            {
                Plata p = reposPlata.GetById(PlataId);
                p.Datum = Datum;
                p.Iznos = Iznos;
                p.UposlenikId = UposlenikId;
                reposPlata.Save();
            }
            return RedirectToAction("PrikaziPlate");
        }
        public IActionResult PrikaziPlate()
        {
            List<Plata> plate = reposPlata.GetAll();
            var prikazPlata = new PlataViewModel {
                ListaPlata = plate
            };
            return View(prikazPlata);
        }
        public IActionResult UrediPlatu(int PlataId)
        {
           Plata pronadjenaPlata=reposPlata.GetById(PlataId);
            List<Uposlenik> uposlenici = reposUposlenici.GetAll();
            PlataViewModel plataVM = new PlataViewModel()
            {
              Plata=pronadjenaPlata,
              Uposlenici=uposlenici
            };
            return View(plataVM);
        }
       
    }
}