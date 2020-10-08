using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IPlataRepository
    {
        List<Plata> GetAll();
        void Add(Plata novaPlata);
        Plata GetById(int plataId);
        void Save();
    }
}
