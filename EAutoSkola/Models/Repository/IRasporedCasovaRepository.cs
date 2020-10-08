using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IRasporedCasovaRepository
    {
        List<RasporedCasova> GetAll();
       
        void Add(RasporedCasova raspored);
        RasporedCasova GetById(int rasporedId);
    }
}
