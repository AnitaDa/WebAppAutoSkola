using EAutoSkola.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class SatnicaRepository : ISatnicaRepository
    {
        public readonly MyContext context;
        public SatnicaRepository(MyContext context)
        {
            this.context = context;
        }
        public List<Satnica> GetAll()
        {
            return context.Satnica.ToList();
        }
    }
}
