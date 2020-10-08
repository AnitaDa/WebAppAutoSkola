using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class PotvrdaRepository : IPotvrdaRepository
    {
        private readonly MyContext context;
        public PotvrdaRepository(MyContext context)
        {
            this.context = context;
        }
        public void Add(Potvrda novaPotvrda)
        {
            context.Potvrde.Add(novaPotvrda);
            context.SaveChanges();
        }

        public List<Potvrda> GetAll()
        {
            return context.Potvrde.Include(q => q.Kandidat).Include(q => q.Kategorija).ToList();
        }

        public Potvrda GetById(int potvrdaId)
        {
            return context.Potvrde.Where(w => w.Id == potvrdaId).Include(q => q.Kandidat).Include(q => q.Kategorija).SingleOrDefault();
        }

        public bool Kategorija(int kategorijaId)
        {
            Potvrda u = context.Potvrde.Where(k => k.KategorijaId == kategorijaId).SingleOrDefault();
            if (u == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
