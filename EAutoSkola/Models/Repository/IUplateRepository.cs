using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IUplateRepository
    {
        IOrderedQueryable<Uplata> SortByDate();
        Uplata GetById(int uplataId);
        void Save();
        void Add(Uplata uplata);
        void Remove(Uplata u);
        IOrderedQueryable<Uplata> GetByImePrezime(string imePrezime);
        float GetUplata(int i,int Godina);
        IOrderedQueryable<Uplata> GetPretrazeno(string pretraga);
    }
}
