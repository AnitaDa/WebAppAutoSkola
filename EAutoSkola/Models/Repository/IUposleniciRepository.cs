using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IUposleniciRepository
    {
        Uposlenik GetById(int uposlenikId);
        List<Uposlenik> GetAll();
        int Count();
        void Add(Uposlenik uposlenik);
        Uposlenik GetByKorisnikId(string id);
    }
}
