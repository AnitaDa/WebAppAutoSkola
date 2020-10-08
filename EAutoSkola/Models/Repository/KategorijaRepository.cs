using EAutoSkola.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class KategorijaRepository : IKategorijaRepository
    {
        private readonly MyContext context;

        public KategorijaRepository(MyContext context)
        {
            this.context = context;
        }
        public void Add(Kategorija kat)
        {
            context.Kategorije.Add(kat);
            Save();
        }

        public void Remove(Kategorija kat)
        {
            context.Kategorije.Remove(kat);
            context.SaveChanges();
        }

        public List<Kategorija> GetAll()
        {
            return context.Kategorije.ToList();
        }

        public Kategorija GetByID(int kategorijaId)
        {
            return context.Kategorije.Find(kategorijaId);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
