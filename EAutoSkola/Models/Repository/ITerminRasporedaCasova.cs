using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface ITerminRasporedaCasova
    {
        List<TerminRasporedaCasova> GetAll(int rasporedId);
        TerminRasporedaCasova GetById(int terminId);
        void Add(TerminRasporedaCasova terminRaspored);
        void Save();
        bool Vozilo(int voziloId);
    }
}
