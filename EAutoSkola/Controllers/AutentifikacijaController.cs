using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.EF;
using EAutoSkola.Models;
using EAutoSkola.Models.Repository;
using EAutoSkola.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace EAutoSkola.Controllers
{
    
    public class AutentifikacijaController : Controller

    {
        private readonly IKandidatiRepository _reposKandidat;
        private readonly IUposleniciRepository _reposUposlenik;
        private readonly ITipUposlenika _reposTipUposlenika;
        private readonly IUposlenikTipUposlenika _reposUposlenikTipUposlenika;
        
        private readonly SignInManager<Korisnik> _singInManager;
        private readonly UserManager<Korisnik> _UserManager;
        private readonly RoleManager<Rola> _roleMng;
        private readonly ILogger<AutentifikacijaController> _logger;
        public AutentifikacijaController(
            SignInManager<Korisnik> signInManager,
            UserManager<Korisnik> userManager,
            RoleManager<Rola> roleManager,
            ILogger<AutentifikacijaController> logger,
            IKandidatiRepository reposKandidat,
            IUposleniciRepository reposUposlenik,
            ITipUposlenika reposTipUposlenika,
            IUposlenikTipUposlenika reposUposlenikTipUposlenika)

        {
            _reposTipUposlenika =reposTipUposlenika;
            _reposUposlenik = reposUposlenik;
            _reposUposlenikTipUposlenika = reposUposlenikTipUposlenika;
            _reposKandidat = reposKandidat;
            _singInManager = signInManager;
            _UserManager = userManager;
            _roleMng = roleManager;
            _logger = logger;
          

        }
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logKorisnik)

        {
            //Odjava prethodne sesije
          
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            if (ModelState.IsValid)
            {
                ViewBag.ImePrezime = logKorisnik.Email;
                //Pronadji nalog
                var postojanjeNaloga = await _UserManager.FindByEmailAsync(logKorisnik.Email);
                if (postojanjeNaloga == null)
                {
                    ModelState.AddModelError(string.Empty, "Nepostojeci nalog");
                    return View("Login");
                }
                else
                {
                    var signInResult = await _singInManager.PasswordSignInAsync(postojanjeNaloga.UserName, logKorisnik.Lozinka,logKorisnik.ZapamtiMe, false);
                        
                        if (signInResult.Succeeded)
                    {
                        return RedirectToAction("PocetnaReferent", "Referent");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Netacna lozinka");
                    }
                }
            }
         
            return View("Login");
        }
        [HttpGet]
        public IActionResult Registracija()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistracijaAsync(RegistracijaViewModel korisnik)
        {
           
            if (ModelState.IsValid)
            {
                var noviKorisnik = new Korisnik
                {
                    UserName = korisnik.KorisnickoIme,
                    Email = korisnik.Email,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled=false,
                    LockoutEnabled=false,
                   
                    AccessFailedCount=1
                
                };
                var rezultat = await _UserManager.CreateAsync(noviKorisnik, korisnik.Lozinka);
               
                if (rezultat.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(noviKorisnik, "Kandidat");

                    //Potvrda naloga
                    var token = await _UserManager.GenerateEmailConfirmationTokenAsync(noviKorisnik);
                    var confirmationLink = Url.Action("ConfirmEmail", "Autentifikacija", new { korisnikId = noviKorisnik.Id, token = token }, Request.Scheme);
                    ViewBag.token = confirmationLink;
                    _logger.Log(LogLevel.Warning, confirmationLink);

                    var kandidat = new Kandidat
                    {
                        ImePrezime = korisnik.Ime + " " + korisnik.Prezime,
                        JMBG = korisnik.JMBG,
                        DatumRodjenja = korisnik.DatumRodjenja,
                        Email = korisnik.Email,
                        Korisnik = noviKorisnik,
                        Status=false
                    };

                    _reposKandidat.Add(kandidat);
              
                    var text = " Klikom na link, aktiviracete korisnicki nalog " + "<a href=\"" + confirmationLink + "\">Link</a> ";

                    SlanjeEmaila(text, noviKorisnik,false);
        
                }
                foreach(var error in rezultat.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("UspjesnaRegistracija");
            }
            return RedirectToAction("Registracija", "Autentifikacija");
           
        }
        [HttpGet]
        
        public async Task<IActionResult> ConfirmEmail(string korisnikId, string token)
        {
            if (korisnikId == null || token == null)
            {
                return RedirectToAction("Login", "Autentifikacija");
            }
            var user = await _UserManager.FindByIdAsync(korisnikId);
            if (user == null)
            {
                ViewBag.ErrorMassage = $"Korisnik {korisnikId} ne postoji";
                return View("NepostojeciKorisnik");
            }
            var result = await _UserManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        public void SlanjeEmaila( string text,Korisnik noviKorisnik,bool IzmjenaLozinke)
        {
           
            var novaPoruka = new MimeMessage();
            novaPoruka.From.Add(new MailboxAddress("EAutoSkola", "proba6446@gmail.com"));
            novaPoruka.To.Add(new MailboxAddress(noviKorisnik.UserName, noviKorisnik.Email));
            if (IzmjenaLozinke == false)
            {
                novaPoruka.Subject = "Aktivacijski email";
            }
            else
            {
                novaPoruka.Subject = "Izmjena lozinke";
            }
            novaPoruka.Body = new TextPart("html") {
                Text = text
            };
            using (var klijent=new SmtpClient())
            {
                klijent.Connect("smtp.gmail.com", 587, false);
                klijent.Authenticate("proba6446@gmail.com", "ProbaAnita123");
                klijent.Send(novaPoruka);
                klijent.Disconnect(true);
            }
           
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Login","Autentifikacija");
        }
        //[HttpGet]
        //public IActionResult CreateRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateRoleAsync(CreateRoleViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var novaRola = new Rola {
        //            Name = model.RoleName
        //        };
        //        var result = await _roleMng.CreateAsync(novaRola);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("DetaljiRasporedCasova", "Referent");
        //        }
        //        else
        //        {
        //            foreach(var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }
        //    }
           
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult IzmjenaLozinke()
        {
            return View();
        }
       [HttpPost]
        public async Task<IActionResult> IzmjenaLozinke(IzmjenaLozinkeViewModel lozinka)
        {
            if (ModelState.IsValid)
            {
                var korisnik = await _UserManager.GetUserAsync(User);
                if (korisnik == null)
                {
                    return RedirectToAction("Login");
                }
                var rezultat = await _UserManager.ChangePasswordAsync(korisnik, lozinka.TrenutnaLozinka, lozinka.NovaLozinka);
                if (!rezultat.Succeeded)
                {
                    foreach(var error in rezultat.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("IzmjenaLozinke");
                }
                await _singInManager.RefreshSignInAsync(korisnik);
                return View("IzmjenaLozinkePotvrdnaPoruka");
            }
            return View(lozinka);
        }
        [HttpGet]
       
        public IActionResult ZaboravljenaLozinka()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> ZaboravljenaLozinka(ZaboravljenaLozinkaEmailViewModel zaboravljenaLozinka)
        {
           
            if (ModelState.IsValid)
            {
                var korisnik = await _UserManager.FindByEmailAsync(zaboravljenaLozinka.Email);
                if (korisnik != null && await _UserManager.IsEmailConfirmedAsync(korisnik))
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(korisnik);
                    var lozinkaResetLink = Url.Action("ZaboravljenaLozinkaIzmjena", "Autentifikacija", new { email = zaboravljenaLozinka.Email, token = token }, Request.Scheme);
                    _logger.Log(LogLevel.Warning, lozinkaResetLink);
                    var text = " Klikom na link, omogucena Vam je izmjena lozinke" + "<a href=\"" + lozinkaResetLink + "\">Link</a> ";

                    SlanjeEmaila(text, korisnik, true);
                    return View("ZaboravljenaLozinkaPotvrda");
                }
                return View("ZaboravljenaLozinkaPotvrda");
            }

            return View(zaboravljenaLozinka);
          
        }
        [HttpGet]
        
        public IActionResult ZaboravljenaLozinkaIzmjena( string email, string Token)
        {
            if(Token==null || email == null)
            {
                ModelState.AddModelError("", "Netacan token ili email adresa!");
            }
            return View();
        }

        [HttpPost]
   
        public async Task<IActionResult> ZaboravljenaLozinkaIzmjena(ZaboravljenaLozinkaViewModel lozinkaZ)
        {
            if (ModelState.IsValid)
            {
                var korisnik = await _UserManager.FindByEmailAsync(lozinkaZ.Email);
                if (korisnik != null)
                {
                    var rezultat = await _UserManager.ResetPasswordAsync(korisnik, lozinkaZ.Token, lozinkaZ.Lozinka);
                    if (rezultat.Succeeded)
                    {
                        return View("NakonIzmjeneZaboravljeneLozinkePoruka");
                    }
                    foreach(var error in rezultat.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(lozinkaZ);
                }
                return View("NakonIzmjeneZaboravljeneLozinkePoruka");

            }
            return View(lozinkaZ);
        }

        [HttpGet]
        public async Task  < IActionResult> IzmjenaProfila( )
        {
            var korisnicki = await _UserManager.GetUserAsync(User);
            IzmjenaPodatakaKorisnikaVM izmjena = new IzmjenaPodatakaKorisnikaVM { 
                KorisnikId=korisnicki.Id,
                Email=korisnicki.Email,
                KorisnickoIme=korisnicki.UserName
            };
            return View(izmjena);
        }
        [HttpPost]
        public async Task<IActionResult> IzmjenaProfila(IzmjenaPodatakaKorisnikaVM podaci)
        {

            var k = await _UserManager.FindByIdAsync(podaci.KorisnikId);
            if (k == null)
            {
                ViewBag.Greska = $"Korisnik sa Id={podaci.KorisnikId} nije pronadjen";
                return View("Greska");
            }
            else
            {
                k.Email = podaci.Email;
                k.UserName = podaci.KorisnickoIme;
                var rez = await _UserManager.UpdateAsync(k);
                if (rez.Succeeded)
                {
                    return RedirectToAction("PrikazKorisnickihPodataka");
                }
                foreach(var i in rez.Errors)
                {
                    ModelState.AddModelError("", i.Description);
                }
                return View(podaci);
            }
            
        }
        public async Task<IActionResult> PrikazKorisnickihPodataka()
        {
            var pr = await _UserManager.GetUserAsync(User);
            IzmjenaPodatakaKorisnikaVM m = new IzmjenaPodatakaKorisnikaVM { 
            KorisnickoIme=pr.UserName,
            Email=pr.Email
            };
            return View(m);
        }
    }
 }
