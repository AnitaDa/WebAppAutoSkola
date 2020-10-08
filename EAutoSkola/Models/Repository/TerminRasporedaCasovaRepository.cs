using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class TerminRasporedaCasovaRepository : ITerminRasporedaCasova
    {
        private readonly MyContext context;
        public TerminRasporedaCasovaRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(TerminRasporedaCasova terminRaspored)
        {
            context.TerminRasporedaCasova.Add(terminRaspored);
            context.SaveChanges();
        }

        public List<TerminRasporedaCasova> GetAll(int rasporedId)
        {
            return context.TerminRasporedaCasova.Include(n => n.RasporedCasova).Include(n => n.Vozilo).Include(n => n.Uposlenik).Where(m => m.RasporedCasovaId == rasporedId).ToList();
        }

        public TerminRasporedaCasova GetById(int terminId)
        {
            return context.TerminRasporedaCasova.Find(terminId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool Vozilo(int voziloId)
        {
            TerminRasporedaCasova u = context.TerminRasporedaCasova.Where(k => k.VoziloId == voziloId).SingleOrDefault();
            if (u == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
