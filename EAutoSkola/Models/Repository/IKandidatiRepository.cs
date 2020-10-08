using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IKandidatiRepository
    {
        List<Kandidat> GetAll();
        Kandidat GetById(int kandidatId);
        void Add(Kandidat kandidat);
        int Count();
        void Save();
    }
}
