using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class UposlenikTipUposlenikaRepository : IUposlenikTipUposlenika
    {
        private readonly MyContext context;
        public UposlenikTipUposlenikaRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(UposlenikTipUposlenika uposlenikTip)
        {
            context.uposlenikTipUposlenika.Add(uposlenikTip);
            context.SaveChanges();
        }

        public List<UposlenikTipUposlenika> GetInstruktori()
        {
            return context.uposlenikTipUposlenika.Include(x => x.Uposlenik).Include(x => x.TipUposlenika).Where(x => x.TipUposlenika.Id == 2).ToList();//vraca instruktore
            
        }

        public List<UposlenikTipUposlenika> GetReferenti()
        {
            return context.uposlenikTipUposlenika.Include(x => x.Uposlenik).Include(x => x.TipUposlenika).Where(x => x.TipUposlenika.Id == 1).ToList();//vraca referente
        }
    }
}
