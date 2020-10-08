using EAutoSkola.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class TipUposlenikaRepository : ITipUposlenika
    {
        private readonly MyContext context;
        public TipUposlenikaRepository(MyContext context)
        {
            this.context = context;
        }
        public TipUposlenika GetById(int v)
        {
            return context.TipUposlenika.Find(v);//Vraca instruktora
        }
    }
}
