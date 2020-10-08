using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IRasporedPolaganjaRepository
    {
        List<RasporedPolaganja> GetAll();
        void Add(RasporedPolaganja noviRaspored);
    }
}
