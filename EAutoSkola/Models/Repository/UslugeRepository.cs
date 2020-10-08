using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class UslugeRepository : IUslugeRepository
    {
        private readonly MyContext context;
        public UslugeRepository(MyContext context)
        {
            this.context = context;
        }
        public void Add(Usluga u)
        {
            context.Usluge.Add(u);
            context.SaveChanges();
     }

        public List<Usluga> GetAll()
        {
            return context.Usluge.Include(s => s.Kategorija).ToList();
        }

        public Usluga GetById(int uslugaId)
        {
            return context.Usluge.Find(uslugaId);
        }

        public bool Kategorija(int kategorijaId)
        {
            Usluga u = context.Usluge.Where(k => k.KategorijaId == kategorijaId).SingleOrDefault();
            if (u == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public void Remove(Usluga u)
        {
            context.Usluge.Remove(u);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
