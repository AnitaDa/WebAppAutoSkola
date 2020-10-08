using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class UplateRepository : IUplateRepository
    {
        private readonly MyContext context;
        public UplateRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Uplata uplata)
        {
            context.Uplate.Add(uplata);
            context.SaveChanges();
        }

        public Uplata GetById(int uplataId)
        {
            return context.Uplate.Find(uplataId);
        }

        public IOrderedQueryable<Uplata> GetByImePrezime(string imePrezime)
        {
            return context.Uplate.Where(j=>j.Kandidat.ImePrezime.Equals(imePrezime)).Include(j => j.Kandidat).Include(j => j.Uposlenik).AsNoTracking().OrderBy(j => j.DatumUplate);
        }

        public IOrderedQueryable<Uplata> GetPretrazeno(string pretraga)
        {
            return context.Uplate.Where(d => d.Kandidat.ImePrezime.Contains(pretraga)).Include(d => d.Kandidat).Include(d => d.Uposlenik).AsNoTracking().OrderBy(d => d.DatumUplate);
        }

        public float GetUplata(int i,int Godina)
        {
            return context.Uplate.Where(d => d.DatumUplate.Month == i && d.DatumUplate.Year==Godina).Sum(d => d.Iznos);
        }

        public void Remove(Uplata u)
        {
            context.Uplate.Remove(u);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IOrderedQueryable<Uplata> SortByDate()
        {
            return context.Uplate.Include(j => j.Kandidat).Include(j => j.Uposlenik).AsNoTracking().OrderBy(j => j.DatumUplate); 
        }
    }
}
