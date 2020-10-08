using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface ILjekarskoUvjerenje
    {
        LjekarskoUvjerenje GetById(int ljekarskoID);
    }
}
