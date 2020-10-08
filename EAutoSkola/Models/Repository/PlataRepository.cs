using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public class PlataRepository : IPlataRepository
    {
        private readonly MyContext context;
        public PlataRepository (MyContext context)
        {
            this.context = context;
        }
        public List<Plata> GetAll()
        {
          return  context.Plata.Include(s=>s.Uposlenik).ToList();
        }

        public void Add(Plata plata)
        {
            context.Plata.Add(plata);
            context.SaveChanges();
        }

        public Plata GetById(int plataId)
        {
            return context.Plata.Find(plataId);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
