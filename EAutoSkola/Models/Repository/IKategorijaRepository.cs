using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IKategorijaRepository
    {
        List<Kategorija> GetAll();
        Kategorija GetByID(int kategorijaId);
        void Remove(Kategorija kategorija);
        void Save();
        void Add(Kategorija kat);
    }
}
