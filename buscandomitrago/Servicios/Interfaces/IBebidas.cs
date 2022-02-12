using buscandomitrago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buscandomitrago.Servicios.Interfaces
{
    public interface IBebidas
    {
        public Task<LBebida> ObtenerBebidas(string nombre);
        public Task<LBebida> ObetenerBebidasIngredientes(string ingrediente);
    }
}
