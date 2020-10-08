using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface ITerminRasporedPolaganjaRepository
    {
        List<TerminRasporedPolaganja> GetByRasporedId(int rasporedId);
        void Add(TerminRasporedPolaganja terminRaspored);
        TerminRasporedPolaganja GetById(int terminRasporedaPolaganjaId);
        void Save();
    }
}
