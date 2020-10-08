using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class LjekarskoRepository : ILjekarskoUvjerenje
    {
        private readonly MyContext context;
        public LjekarskoRepository(MyContext context)
        {
            this.context = context;
        }
        public LjekarskoUvjerenje GetById(int ljekarskoID)
        {
            return context.LjekarskoUvjerenje.Include(w => w.Kandidat).Include(w => w.ZdrastveniRadnik).Where(w => w.Id == ljekarskoID).SingleOrDefault();
        }
    }
}
