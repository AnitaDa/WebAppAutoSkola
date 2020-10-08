using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IUslugeRepository
    {
        List<Usluga> GetAll();
        void Add(Usluga u);
        Usluga GetById(int uslugaId);
        void Remove(Usluga u);
        void Save();
        bool Kategorija(int kategorijaId);
    }
}
