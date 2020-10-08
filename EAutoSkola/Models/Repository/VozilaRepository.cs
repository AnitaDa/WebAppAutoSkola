using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class VozilaRepository : IvozilaRepository
    {
        private readonly MyContext context;
        public VozilaRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Vozilo v)
        {
            context.Vozila.Add(v);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Vozila.ToList().Count();
        }

        public IOrderedQueryable<Vozilo> GetVozila()
        {
            //return context.Vozila.Include(s => s.Kategorija).ToList();
            return context.Vozila.Include(j => j.Kategorija).AsNoTracking().OrderBy(j => j.Id);
        }
        public List<Vozilo> GetAll()
        {
            return context.Vozila.Include(s => s.Kategorija).ToList();
        }
        public Vozilo GetById(int voziloId)
        {
            return context.Vozila.Find(voziloId);
        }

        public Vozilo GetByIdWithInclude(int voziloId)
        {
           return context.Vozila.Include(s => s.Kategorija).Where(s => s.Id == voziloId).SingleOrDefault();
        }

        public void Remove(Vozilo pronadjenoVozilo)
        {
            context.Vozila.Remove(pronadjenoVozilo);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Kategorija(int kategorijaId)
        {
            Vozilo u = context.Vozila.Where(k => k.KategorijaId == kategorijaId).SingleOrDefault();
            if (u == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
