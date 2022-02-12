using buscandomitrago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buscandomitrago.Servicios.Classes
{
    public abstract class Drinks
    {
        public abstract Task<LBebida> ObtenerBebidas(string nombre);
    }
}
