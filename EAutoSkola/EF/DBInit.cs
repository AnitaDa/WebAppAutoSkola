using EAutoSkola.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EAutoSkola.EF
{
    public class DBInit
    {
        private static readonly UserManager<Korisnik> _UserManager;
        public static void Seed(MyContext context)

            {
            AddKategorije(context);
            AddUloge(context);
            AddKorisnik(context);
            AddKorisnik(context);
            AddUsluge(context);
            AddRasporedPolaganja(context);
                Console.WriteLine("SVE DODANO :-D!");
            }
       
        private static int GenerisiInt(int from, int to)

            {

                var rand = new Random();

                return rand.Next(from, to);

            }

            private static DateTime GenerisiDatum()

            {

                return new DateTime(year: GenerisiInt(2017, 2020),

                    month: GenerisiInt(1, 13),

                    day: GenerisiInt(1, 29));

            }

            private static void AddKategorije(MyContext context)

            {
                if (context.Kategorije.ToList().Count > 0)
                    return;

                context.Kategorije.AddRange(

                    new Kategorija { Naziv = "A kategorija", Opis = "A kategorija je kategorija za upravljanje motorima i teškim triciklima čija snaga motora je veća od 15 KW" },
                    new Kategorija { Naziv = "B kategorija", Opis = "B – kategorija je dozvola za upravljanje putničkim vozilom" },
                    new Kategorija { Naziv = "C kategorija", Opis = "C kategorija je dozvola za upravljanje teretnim vozilom čija je najveća dozvoljena masa veća od 3.5t" },
                    new Kategorija { Naziv = "D kategorija", Opis = "D kategorija je kategorija za upravljanje autobusima" }
                );

                context.SaveChanges();



            }

            private static void AddUloge(MyContext context)
            {
                if (context.UserRoles.ToList().Count > 0) return;
                var referent = new Rola()
                {
                    Name = "Referent",
                    NormalizedName = "Referent"
                };
                var kandidat = new Rola()
                {
                    Name = "Kandidat",
                    NormalizedName = "Kandidat"
                };
                var instruktor = new Rola()
                {
                    Name = "Instruktor",
                    NormalizedName = "Instruktor"
                };

                context.Add(referent);
                context.Add(kandidat);
                context.Add(instruktor);

                context.SaveChanges();
            }

            private async static void AddKorisnik(MyContext context)
            {
           
            if (context.Users.ToList().Count > 0)
                    return;
              //korisnicki nalozi
                var korisnik = new Korisnik()
                {
                    Email = "uposlenik1@gmail.com",
                    UserName = "referent1",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,

                    AccessFailedCount = 1
                };
                var korisnik2 = new Korisnik()
                {
                    Email = "uposlenik2@gmail.com",
                    UserName = "referent2",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,

                    AccessFailedCount = 1
                };
                var korisnik3 = new Korisnik()
                {
                    Email = "kandidat1@gmail.com",
                    UserName = "kandidat",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,

                    AccessFailedCount = 1
                };
            //pass
            await _UserManager.CreateAsync(korisnik, "test");
            await _UserManager.CreateAsync(korisnik2, "test");
            await _UserManager.CreateAsync(korisnik3, "test");
            context.SaveChanges();

            //uposlenici i kandidati
            var uposlenik = new Uposlenik { 
            DatumRodjenja=GenerisiDatum(),
            ImePrezime="Uposlenik",
            JMBG="0000234234234",
            Korisnik=korisnik,
            Email="test@gmail.com"
            };
           var kandidat = new Kandidat { DatumRodjenja = GenerisiDatum(),
               ImePrezime = "Kandidat", Email = "kandidat@gmail.com", Korisnik = korisnik2, JMBG = "234234234", Status = true };
            var kandidat2 = new Kandidat
            {
                DatumRodjenja = GenerisiDatum(),
                ImePrezime = "Kandidat2",
                Email = "kandidat2@gmail.com",
                Korisnik = korisnik3,
                JMBG = "232222234234",
                Status = true
            };

            var tipReferent = new TipUposlenika()
                {
                    Naizv = "Referent"
                };

                var tipInstruktor = new TipUposlenika()
                {
                    Naizv = "Instruktor"
                };

            var tipKandidat = new TipUposlenika()
            {
                Naizv = "Kandidat"
            };

            var tip1referent = context.TipUposlenika.Add(tipReferent);        
            var tipKandidatr= context.TipUposlenika.Add(tipKandidat);
            var tipInstuktor= context.TipUposlenika.Add(tipInstruktor);

            context.SaveChanges();



                //referenti
                context.uposlenikTipUposlenika.Add(new UposlenikTipUposlenika()
                {
                  Uposlenik=uposlenik,
                  TipUposlenika=tipReferent
                });
               
                context.SaveChanges();


                //Ljekarsko
                if (context.LjekarskoUvjerenje.ToList().Count() > 0)
                    return;
                var lj1 = context.LjekarskoUvjerenje.Add(
                    new LjekarskoUvjerenje { DatumVazenja = GenerisiDatum(), DatumIzdavanje = GenerisiDatum(), KandidatId = kandidat.Id, SposobanZaObuku = true, Opis = "Sposoban" }
                    );
            var lj2 = context.LjekarskoUvjerenje.Add(
                    new LjekarskoUvjerenje { DatumVazenja = GenerisiDatum(), DatumIzdavanje = GenerisiDatum(), KandidatId = kandidat2.Id, SposobanZaObuku = true, Opis = "Sposoban" }
                    );
            context.SaveChanges();




                //potvrde
                if (context.Potvrde.ToList().Count() > 0)
                    return;
                context.Potvrde.Add(
                    new Potvrda { DatumPolaganja = DateTime.Now, KandidatId = kandidat.Id, KategorijaId = 2, BrojBodova=34 }
                    );
                context.Potvrde.Add(
                   new Potvrda { DatumPolaganja = DateTime.Now, KandidatId = kandidat2.Id, KategorijaId = 2, BrojBodova=63}
                   );
                context.SaveChanges();

                //raspored casova
                if (context.RasporedCasova.ToList().Count() > 0)
                    return;

                var rc1 = context.RasporedCasova.Add(
                   new RasporedCasova { KandidatId = kandidat.Id }
                   );
                var rc2 = context.RasporedCasova.Add(
                  new RasporedCasova { KandidatId = kandidat2.Id }
                  );

                context.SaveChanges();
            var path= Path.Combine(Directory.GetCurrentDirectory(), "images", "car.png");
            var slika = File.ReadAllText(path);
            var vozilo = new Vozilo { KategorijaId = context.Kategorije.FirstOrDefault().Id, Marka = "VW", Model = "Golf", PhotoPath = slika, RegistarskaOznaka = "234-K-423" };
               context.SaveChanges();
                //termin rasporeda casova
                if (context.TerminRasporedaCasova.ToList().Count() > 0)
                    return;

            context.TerminRasporedaCasova.AddRange(
               //kandidat
               new TerminRasporedaCasova
               {
                   RasporedCasovaId = rc1.Entity.Id,
                   TerminOd = "12"
                   ,
                   TerminDo = "13"
                   ,
                   Datum = DateTime.Today,
                   VoziloId = vozilo.Id,
                   UposlenikId = uposlenik.Id

               });
             
                context.SaveChanges();

                //Uplate
                if (context.Uplate.ToList().Count() > 0)
                    return;

                context.Uplate.AddRange(
                   new Uplata { DatumUplate = DateTime.Now, KandidatId = kandidat.Id, Iznos = 450, Svrha = "Rata" },
                   new Uplata { DatumUplate = GenerisiDatum(), KandidatId = kandidat.Id, Iznos = 450, Svrha = "Rata" },
                   new Uplata { DatumUplate = GenerisiDatum(), KandidatId = kandidat.Id, Iznos = 450, Svrha = "Rata" },
                   new Uplata { DatumUplate = GenerisiDatum(), KandidatId = kandidat.Id, Iznos = 30, Svrha = "Rata" },
                   new Uplata { DatumUplate = GenerisiDatum(), KandidatId = kandidat.Id, Iznos = 360, Svrha = "Rata" }           
                   );
                context.SaveChanges();

                //Zahtjevi
                if (context.Zahtjev.ToList().Count() > 0)
                    return;
                context.Zahtjev.AddRange(
                    new Zahtjev { DatumPodnosenjaZahtjeva = GenerisiDatum(), LjekarskoUvjerenjeId = lj1.Entity.Id,  UslugaId = 1, Procitano = false, Odbacen = false },
                    new Zahtjev { DatumPodnosenjaZahtjeva = GenerisiDatum(), LjekarskoUvjerenjeId = lj1.Entity.Id,  UslugaId = 1, Procitano = false, Odbacen = false },
                    new Zahtjev { DatumPodnosenjaZahtjeva = GenerisiDatum(), LjekarskoUvjerenjeId = lj2.Entity.Id, UslugaId = 1, Procitano = false, Odbacen = false }          
                    );
                context.SaveChanges();

            }
     
            private static void AddUsluge(MyContext context)

            {

                if (context.Usluge.ToList().Count > 0)

                    return;

                context.Usluge.AddRange(

                    new Usluga { Naziv = "Obuka", Cijena = 1800, Opis = "40 casova teorije, 40 casova voznje, polaganje prve pomoci", KategorijaId = 2 },
                    new Usluga { Naziv = "Obuka", Cijena = 1800, Opis = "40 casova teorije, 40 casova voznje, polaganje prve pomoci", KategorijaId = 2 },
                    new Usluga { Naziv = "Obuka", Cijena = 900, Opis = "20 casova teorije, 20 casova voznje, polaganje prve pomoci", KategorijaId = 1 },
                    new Usluga { Naziv = "Obuka", Cijena = 2000, Opis = "40 casova teorije, 40 casova voznje, polaganje prve pomoci", KategorijaId = 3 },
                    new Usluga { Naziv = "Obuka", Cijena = 2000, Opis = "40 casova teorije, 40 casova voznje, polaganje prve pomoci", KategorijaId = 4 },
                    new Usluga { Naziv = "Dodatni čas(teorija) ", Cijena = 20, Opis = "Predavanje iz oblasti koju kandidat odabere", KategorijaId = 1 },
                    new Usluga { Naziv = "Dodatni čas(teorija) ", Cijena = 20, Opis = "Predavanje iz oblasti koju kandidat odabere", KategorijaId = 2 },
                    new Usluga { Naziv = "Dodatni čas(teorija) ", Cijena = 20, Opis = "Predavanje iz oblasti koju kandidat odabere", KategorijaId = 3 },
                    new Usluga { Naziv = "Dodatni čas(teorija) ", Cijena = 20, Opis = "Predavanje iz oblasti koju kandidat odabere", KategorijaId = 4 },
                    new Usluga { Naziv = "Dodatni čas(praktično) ", Cijena = 15, Opis = "Vožnja po gradu i poligonu", KategorijaId = 1 },
                    new Usluga { Naziv = "Dodatni čas(praktično) ", Cijena = 20, Opis = "Vožnja po gradu i poligonu", KategorijaId = 2 },
                    new Usluga { Naziv = "Dodatni čas(praktično) ", Cijena = 25, Opis = "Vožnja po gradu i poligonu", KategorijaId = 3 },
                    new Usluga { Naziv = "Dodatni čas(praktično) ", Cijena = 25, Opis = "Vožnja po gradu i poligonu", KategorijaId = 4 },
                    new Usluga { Naziv = "Prva pomoć", Cijena = 80, Opis = "Prakticno i teoretsko predavanje o davanju prve pomoći ", KategorijaId = 4 }
                );

                context.SaveChanges();



            }

           
            private static void AddRasporedPolaganja(MyContext context)

            {
                if (context.RasporedPolaganja.ToList().Count > 0)
                    return;
                var rp1 = context.RasporedPolaganja.Add(
                             new RasporedPolaganja { DatumPolaganja = DateTime.Now }
                             );
                var rp2 = context.RasporedPolaganja.Add(
                             new RasporedPolaganja { DatumPolaganja = GenerisiDatum() }
                             );
                context.SaveChanges();

                //termin rasporeda polaganja
                if (context.TerminRasporedPolaganja.ToList().Count() > 0)
                    return;
                context.TerminRasporedPolaganja.AddRange(
                    new TerminRasporedPolaganja { TerminOd = "10:00", TerminDo = "12:00", KandidatId = 1, RasporedPolaganjaId = rp1.Entity.Id },
                    new TerminRasporedPolaganja { TerminOd = "12:00", TerminDo = "13:00", KandidatId = 2, RasporedPolaganjaId = rp1.Entity.Id },
                    new TerminRasporedPolaganja { TerminOd = "13:00", TerminDo = "15:00", KandidatId = 3, RasporedPolaganjaId = rp1.Entity.Id }
                    );                                                
                context.SaveChanges();


            }

        }
    }

