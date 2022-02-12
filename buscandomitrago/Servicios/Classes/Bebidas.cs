using buscandomitrago.Models;
using buscandomitrago.Servicios.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace buscandomitrago.Servicios.Classes
{
    public class Bebidas : Drinks, IBebidas
    {
        private readonly IOptions<ApiCocktail> _apiCocktail;

        public Bebidas(IOptions<ApiCocktail> apiCocktail)
        {
            _apiCocktail = apiCocktail;
        }
        public override async Task<LBebida> ObtenerBebidas(string nombre)
        {
            try
            {
                string url = string.Empty;
                List<Bebida> bebidas = new List<Bebida>();
                var listaBebidas = new LBebida();
                url = _apiCocktail.Value.BusquedaNombre + nombre;
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                dynamic Objlist = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                foreach (var i in Objlist.drinks)
                {
                    Bebida b = new Bebida();
                    b.idDrink = i.idDrink;
                    b.strDrink = i.strDrink;
                    b.strTags = i.strTags;
                    b.strCategory = i.strCategory;
                    b.strIBA = i.strIBA;
                    b.strGlass = i.strGlass;
                    b.strDrinkThumb = i.strDrinkThumb;

                    bebidas.Add(b);
                }

                listaBebidas.bebida = bebidas;

                return listaBebidas;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<LBebida> ObetenerBebidasIngredientes(string ingrediente)
        {
            string url = string.Empty;
            var lista = new LBebida();
            url = _apiCocktail.Value.BusquedaIngrediente + ingrediente;
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);

            lista = JsonConvert.DeserializeObject<LBebida>(response);

            return lista;
        }
    }
}
