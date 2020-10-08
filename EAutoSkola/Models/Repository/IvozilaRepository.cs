using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IvozilaRepository
    {
        List<Vozilo> GetAll();
        IOrderedQueryable<Vozilo> GetVozila();

        Vozilo GetById(int voziloId);
        void Add(Vozilo v);
        void Save();
        void Remove(Vozilo pronadjenoVozilo);
        Vozilo GetByIdWithInclude(int voziloId);
        int Count();
        bool Kategorija(int kategorijaId);
    }
}
