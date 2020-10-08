using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IZahtjevRepository
    {
        List<Zahtjev> GetAll();
        Zahtjev GetById(int zahtjevId);
        void Save();
        List<Zahtjev> GetNeprocitani();
        int Count();
    }
}
