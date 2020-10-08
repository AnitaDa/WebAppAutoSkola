using EAutoSkola.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class RasporedPolaganjaRepository : IRasporedPolaganjaRepository
    {
        private readonly MyContext context;
        public RasporedPolaganjaRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(RasporedPolaganja noviRaspored)
        {
            context.RasporedPolaganja.Add(noviRaspored);
            context.SaveChanges();
        }

        public List<RasporedPolaganja> GetAll()
        {
            return context.RasporedPolaganja.ToList();
        }
    }
}
