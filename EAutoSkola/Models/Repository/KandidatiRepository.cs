using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class KandidatiRepository : IKandidatiRepository
    {
        private readonly MyContext context;
        public KandidatiRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Kandidat kandidat)
        {
            context.Kandidati.Add(kandidat);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Kandidati.ToList().Count();
        }

        public List<Kandidat> GetAll()
        {
            return context.Kandidati.ToList();
        }

        public Kandidat GetById(int kandidatId)
        {
            return context.Kandidati.Where(g => g.Id == kandidatId).Include(g => g.Korisnik).SingleOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
