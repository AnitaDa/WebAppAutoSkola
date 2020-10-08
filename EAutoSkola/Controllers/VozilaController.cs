using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.Models;
using EAutoSkola.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using EAutoSkola.Models.Repository;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EAutoSkola.Controllers
{
    [Authorize(Roles = "Referent")]
    public class VozilaController : Controller
    {
        private readonly IvozilaRepository reposVozila;
        private readonly IKategorijaRepository reposKategorije;
        private static IWebHostEnvironment _hostingEnvironment;
        private readonly ITerminRasporedaCasova reposTerminRasporedC;




        public VozilaController(IvozilaRepository reposVozila, 
            IKategorijaRepository reposKategorije,
            IWebHostEnvironment hostEnvironment,
            ITerminRasporedaCasova reposTerminRasporedC)
        {
            this.reposTerminRasporedC = reposTerminRasporedC;
            this.reposVozila = reposVozila;
            this.reposKategorije = reposKategorije;
            _hostingEnvironment = hostEnvironment;
           

        }
        public IActionResult EvidentirajVoziloForm()
        {

            List<Kategorija> kategorije = reposKategorije.GetAll(); /*baza.Kategorije.ToList();*/
            DefaultViewModel kategorijeVM = new DefaultViewModel()
            {
                Kategorije = kategorije
            };
            return View(kategorijeVM);
        }
        [AllowAnonymous]
        public async Task<IActionResult> PrikaziVozila(int page=1)
        {

           var vozila = reposVozila.GetVozila(); /*baza.Vozila.Include(s => s.Kategorija).ToList();*/
            
            var model = await PagingList.CreateAsync<Vozilo>(vozila, 4, page);
            model.Action = "PrikaziVozila";
            return View(model);
        }
        public IActionResult DodajVozilo(DefaultViewModel voziloModel, int VoziloId)
        {

            Vozilo v;
            if (VoziloId == 0)
            {
                v = new Vozilo();

                //Slika
                string uniqueFileName = null;


                if (voziloModel.Photo != null)
                {
                    string _path = voziloModel.Photo.FileName;
                    string _imeExtenzija = System.IO.Path.GetFileName(_path);
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + _imeExtenzija;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    voziloModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                v.GodinaProizvodnje = voziloModel.GodinaProizvodnje;
                v.Model = voziloModel.Model;
                v.Marka = voziloModel.Marka;
                v.RegistarskaOznaka = voziloModel.RegOznaka;
                v.KategorijaId = voziloModel.KategorijaId;
                v.PhotoPath = uniqueFileName;
                reposVozila.Add(v);
            }
            else
            {
                v = reposVozila.GetById(voziloModel.VoziloId); /*baza.Vozila.Find(voziloModel.VoziloId);*/
                v.GodinaProizvodnje = voziloModel.GodinaProizvodnje;
                v.Model = voziloModel.Model;
                v.Marka = voziloModel.Marka;
                v.RegistarskaOznaka = voziloModel.RegOznaka;
                v.KategorijaId = voziloModel.KategorijaId;
                reposVozila.Save();
            }
            return RedirectToAction(nameof(PrikaziVozila));
        }
        public IActionResult UrediVoziloForm(int VoziloId)
        {

            Vozilo g = reposVozila.GetById(VoziloId);/* baza.Vozila.Find(VoziloId);*/
            List<Kategorija> kategorije = reposKategorije.GetAll(); /*baza.Kategorije.ToList();*/
            DefaultViewModel voziloVM = new DefaultViewModel()
            {
                Vozilo = g,
                Kategorije = kategorije
            };
            return View(voziloVM);
        }
        public IActionResult ObrisiVozilo(int VoziloId)
        {
            if (reposTerminRasporedC.Vozilo(VoziloId)==true) return View("Alert");
            Vozilo pronadjenoVozilo = reposVozila.GetById(VoziloId);/*baza.Vozila.Find(VoziloId);*/
            if (pronadjenoVozilo != null)
            {
                reposVozila.Remove(pronadjenoVozilo);
                //baza.Remove(pronadjenoVozilo);
               
            }
            else
            {
                return Content("Vozilo ne postoji u bazi!");
            }

            return RedirectToAction("PrikaziVozila");
        }
        public IActionResult DetaljiVozila(int VoziloId)
        {
            Vozilo vozilo = reposVozila.GetByIdWithInclude(VoziloId); /*baza.Vozila.Include(s => s.Kategorija).Where(s => s.Id == VoziloId).SingleOrDefault();*/
            VozilaDetaljiViewModel vozilaDetalji = new VozilaDetaljiViewModel
            {
                Vozilo = vozilo
            };
            return View(vozilaDetalji);
        }
    }
}