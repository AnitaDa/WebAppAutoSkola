using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAutoSkola.Models;
using EAutoSkola.Models.Repository;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EAutoSkola.Controllers
{
    public class KandidatController : Controller
    {
        private readonly IKandidatiRepository reposKandidat;
        private readonly IZahtjevRepository reposZahtjev;


        public KandidatController(IKandidatiRepository reposKandidat, IZahtjevRepository reposZahtjev)
        {
            this.reposKandidat = reposKandidat;
            this.reposZahtjev = reposZahtjev;
        }
      
        public IActionResult IzmjeniStatus(int KandidatId,bool Odobren,int ZahtjevId)
        {
            string text;
            if (Odobren)
            {
                var kandidat = reposKandidat.GetById(KandidatId);
                kandidat.Status = true;
                 text = "Odobren Vam je zahtjev za uslugu!";
                reposKandidat.Save();
            }
            else
            {
                Zahtjev z = reposZahtjev.GetById(ZahtjevId);
                z.Odbacen = true;
                reposZahtjev.Save();
                text = "Odbacen Vam je zahtjev za uslugu!";
            }
            ObavestajniEmail(KandidatId,text);
          
            return RedirectToAction("PrikaziListuZahtjeva", "Zahtjevi");
        }
        
        public void ObavestajniEmail(int KandidatId,string text)
        {
            Kandidat k = reposKandidat.GetById(KandidatId);
            var novaPoruka = new MimeMessage();
            novaPoruka.From.Add(new MailboxAddress("EAutoSkola", "anita96dautovic@gmail.com"));
            novaPoruka.To.Add(new MailboxAddress(k.Korisnik.UserName, k.Korisnik.Email));

            novaPoruka.Subject = "Odobrenje";

            novaPoruka.Body = new TextPart("html")
            {
               Text=text
            };
            using (var klijent = new SmtpClient())
            {
                klijent.Connect("smtp.gmail.com", 587, false);
                klijent.Authenticate("anita96dautovic@gmail.com", "Programiranje123");
                klijent.Send(novaPoruka);
                klijent.Disconnect(true);
            }

        }
    }
}