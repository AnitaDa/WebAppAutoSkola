using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class ZahtjeviRepository : IZahtjevRepository
    {
        private readonly MyContext context;
        public ZahtjeviRepository(MyContext context)
        {
            this.context = context;
        }

        public int Count()
        {
            return context.Zahtjev.Where(l => l.Procitano == false).Count();
        }

        public List<Zahtjev> GetAll()
        {
           return context.Zahtjev.Include(l => l.LjekarskoUvjerenje).ThenInclude(k => k.Kandidat).ToList();
        }

        public Zahtjev GetById(int zahtjevId)
        {
            return context.Zahtjev.Where(i => i.Id == zahtjevId).Include(i => i.LjekarskoUvjerenje).ThenInclude(u => u.Kandidat).Include(i => i.Usluga).ThenInclude(s => s.Kategorija).SingleOrDefault();
        }

        public List<Zahtjev> GetNeprocitani()
        {
            return context.Zahtjev.Where(l=>l.Procitano==false).Include(l => l.LjekarskoUvjerenje).ThenInclude(k => k.Kandidat).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
