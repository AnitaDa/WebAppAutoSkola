using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface IUposlenikTipUposlenika
    {
        List<UposlenikTipUposlenika> GetInstruktori();
        void Add(UposlenikTipUposlenika uposlenikTip);
        List<UposlenikTipUposlenika> GetReferenti();
    }
}
