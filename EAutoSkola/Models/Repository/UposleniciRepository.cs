using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class UposleniciRepository : IUposleniciRepository
    {
        private readonly MyContext context;
        public UposleniciRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Uposlenik uposlenik)
        {
            context.Uposlenici.Add(uposlenik);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Uposlenici.ToList().Count();
        }

        public List<Uposlenik> GetAll()
        {
            return context.Uposlenici.ToList();
        }

        public Uposlenik GetById(int uposlenikId)
        {
            return context.Uposlenici.Find(uposlenikId);
        }

       public Uposlenik  GetByKorisnikId(string id)
        {
            return context.Uposlenici.Where(f => f.Korisnik.Id == id).SingleOrDefault();
        }
    }
}
