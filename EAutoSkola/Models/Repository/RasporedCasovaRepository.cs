using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class RasporedCasovaRepository : IRasporedCasovaRepository
    {
        private readonly MyContext context;
        public RasporedCasovaRepository(MyContext context)
        {
            this.context = context;
        }
        public void Add(RasporedCasova raspored)
        {
            context.RasporedCasova.Add(raspored);
            context.SaveChanges();
        }

        public List<RasporedCasova> GetAll()
        {
            return context.RasporedCasova.Include(m => m.Kandidat).ToList();
        }

        public RasporedCasova GetById(int rasporedId)
        {
            return context.RasporedCasova.Find(rasporedId);
        }
    }
}
