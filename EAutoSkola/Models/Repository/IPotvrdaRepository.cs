using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IPotvrdaRepository
    {
        void Add(Potvrda novaPotvrda);
        List<Potvrda> GetAll();
        Potvrda GetById(int potvrdaId);
        void Save();
        bool Kategorija(int kategorijaId);
    }
}
