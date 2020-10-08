using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.Models;
using EAutoSkola.Models.Repository;
using EAutoSkola.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace EAutoSkola.Controllers
{
    [Authorize(Roles = "Referent")]
    public class UplateController : Controller
    {
        private readonly IKandidatiRepository reposKandidati;
        private readonly IUposlenikTipUposlenika reposUposlenikTipUposlenika;
        private readonly IUplateRepository reposUplate;

        public UplateController(IKandidatiRepository reposKandidati, 
            IUposlenikTipUposlenika reposUposlenikTipUposlenika,
            IUplateRepository reposUplate)
        {
            this.reposKandidati = reposKandidati;
            this.reposUposlenikTipUposlenika = reposUposlenikTipUposlenika;
            this.reposUplate = reposUplate;
        }
        public IActionResult EvidentirajUplatuForm()
        {

            List<Kandidat> kandidati = reposKandidati.GetAll();
            List<UposlenikTipUposlenika> uposleniciTipUposlenika = reposUposlenikTipUposlenika.GetReferenti(); /*Include(u => u.Uposlenik).Include(t => t.TipUposlenika).Where(d => d.TipUposlenika.Id == ID).ToList();*/

            var korisniciView = new KorisniciViewModel
            {
                Kandidati = kandidati,
                UposleniciTipUposlenika = uposleniciTipUposlenika
            };
            return View(korisniciView);
        }
        public async Task<IActionResult> PrikaziUplate( string pretraga,int Godina=2019, int page = 1)
        {
            //Ovde sam pretrazivala na osnovu unetog kandidata
            IOrderedQueryable<Uplata> qry = null;
            if (!string.IsNullOrEmpty(pretraga))
            {
                qry = reposUplate.GetPretrazeno(pretraga);
            }
            else
            {
                qry = reposUplate.SortByDate();
            }
             
                var model = await PagingList.CreateAsync<Uplata>(qry, 5, page);
                model.Action = "PrikaziUplate";
            float uplataJanuar = 0;
            float uplataFebruar = 0;
            float uplataMart = 0;
            float uplataApril = 0;
            float uplataMaj = 0;
            float uplataJun = 0;
            float uplataJul = 0;
            float uplataAvgust = 0;
            float uplataSeptembar = 0;
            float uplataOktobar = 0;
            float uplataNovembar = 0;
            float uplataDecembar = 0;
            
                for (var i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1: uplataJanuar = reposUplate.GetUplata(i,Godina); break;
                        case 2: uplataFebruar = reposUplate.GetUplata(i, Godina); break;
                        case 3: uplataMart = reposUplate.GetUplata(i, Godina); break;
                        case 4: uplataApril = reposUplate.GetUplata(i, Godina); break;
                        case 5: uplataMaj = reposUplate.GetUplata(i, Godina); break;
                        case 6: uplataJul = reposUplate.GetUplata(i, Godina); break;
                        case 7: uplataJul = reposUplate.GetUplata(i, Godina); break;
                        case 8: uplataAvgust = reposUplate.GetUplata(i, Godina); break;
                        case 9: uplataSeptembar = reposUplate.GetUplata(i, Godina); break;
                        case 10: uplataOktobar = reposUplate.GetUplata(i, Godina); break;
                        case 11: uplataNovembar = reposUplate.GetUplata(i, Godina); break;
                        default:
                            uplataDecembar = reposUplate.GetUplata(i,Godina); break;
                    }
                }
           
            ViewData["JANUAR"] = uplataJanuar;  
            ViewData["FEBRUAR"] = uplataFebruar;
            ViewData["MART"] = uplataMart;
            ViewData["APRIL"] = uplataApril;
            ViewData["MAJ"] = uplataMaj;
            ViewData["JUN"] = uplataJun;
            ViewData["JUL"] = uplataJul;
            ViewData["AVGUST"] = uplataAvgust;
            ViewData["SEPTEMBAR"] = uplataSeptembar;
            ViewData["OKTOBAR"] = uplataOktobar;
            ViewData["NOVEMBAR"] = uplataNovembar;
            ViewData["DECEMBAR"] = uplataDecembar;
            ViewData["Godina"] = Godina;
            return View(model);
        }
        public IActionResult UrediUplatu(int UplataId)
        {

            Uplata upl = reposUplate.GetById(UplataId); /*baza.Uplate.Find(UplataId);*/

            if (upl == null)
            {
                return RedirectToAction(nameof(PrikaziUplate));
            }
            UplateViewModel uplateVM = new UplateViewModel();
            uplateVM.kandidats = reposKandidati.GetAll(); /*baza.Kandidati.ToList();*/
            uplateVM.TipUposlenikaUposlenici = reposUposlenikTipUposlenika.GetReferenti(); /*baza.uposlenikTipUposlenika.Include(u => u.Uposlenik).Include(t => t.TipUposlenika).Where(d => d.TipUposlenika.Id == TipUposlenikaID).ToList();*/
            uplateVM.uplata = upl;
            return View(uplateVM);
        }
        public IActionResult DodajUredjenuUplatu(int UplataId, DateTime Datum, float IznosUplate, string Svrha, int KandidatId, int ReferentId)
        {

            Uplata uplata = reposUplate.GetById(UplataId); /*baza.Uplate.Find(UplataId);*/

            uplata.DatumUplate = Datum;
            uplata.Iznos = IznosUplate;
            uplata.Svrha = Svrha;
            uplata.KandidatId = KandidatId;
            uplata.UposlenikId = ReferentId;


            reposUplate.Save();
            return Redirect("/Uplate/PrikaziUplate");
        }
        public IActionResult DodajUplatu(DateTime Datum, float IznosUplate, string Svrha, int KandidatId, int ReferentId)
        {

            Uplata uplata = new Uplata
            {
                DatumUplate = Datum,
                Iznos = IznosUplate,
                Svrha = Svrha,
                KandidatId = KandidatId,
                UposlenikId = ReferentId
            };
            reposUplate.Add(uplata);
            //baza.Add(uplata);
           
            return Redirect("/Uplate/PrikaziUplate?poruka=Uspjesno ste evidentirali uplatu");
        }
        public IActionResult ObrisiUplatu(int UplataId)
        {

            Uplata u = reposUplate.GetById(UplataId); /*baza.Uplate.Find(UplataId);*/
            if (u == null)
            {
                Content("Nepostojeca uplata!");
            }
            else
            {
                //baza.Remove(u);
                reposUplate.Remove(u);
              
            }
            return Redirect("/Uplate/PrikaziUplate");
        }
    }
}