﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAutoSkola.Models.Repository
{
    public interface ISatnicaRepository
    {
        List<Satnica> GetAll();
    }
}
