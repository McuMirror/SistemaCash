﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Clases
{
    public interface ICreador
    {
        Mascota Crear();
    }
}