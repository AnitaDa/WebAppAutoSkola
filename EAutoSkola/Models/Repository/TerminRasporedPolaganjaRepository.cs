using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class TerminRasporedPolaganjaRepository : ITerminRasporedPolaganjaRepository
    {
        private readonly MyContext context;
        public TerminRasporedPolaganjaRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(TerminRasporedPolaganja terminRaspored)
        {
            context.TerminRasporedPolaganja.Add(terminRaspored);
            context.SaveChanges();
        }

        public TerminRasporedPolaganja GetById(int terminRasporedaPolaganjaId)
        {
            return context.TerminRasporedPolaganja.Where(f => f.Id == terminRasporedaPolaganjaId).Include(f => f.Kandidat).SingleOrDefault();
        }

        public List<TerminRasporedPolaganja> GetByRasporedId(int rasporedId)
        {
            return context.TerminRasporedPolaganja.Where(s => s.RasporedPolaganjaId == rasporedId).Include(s=>s.Kandidat).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
