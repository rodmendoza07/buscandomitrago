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
            var listaBebidas = new LBebida();
            try
            {
                string url = string.Empty;
                url = _apiCocktail.Value.BusquedaNombre + nombre;
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                List<Bebida> bebidas = new List<Bebida>();
                dynamic Objlist = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                if (Objlist.drinks == null)
                {
                    throw new Exception();
                }

                foreach (var i in Objlist.drinks)
                {
                    Bebida b = new Bebida();
                    b.idDrink = i.idDrink;
                    b.strDrink = i.strDrink;
                    b.strTags = i.strTags != null ? i.strTags : "Sin categoria";
                    b.strCategory = i.strCategory;
                    b.strIBA = i.strIBA;
                    b.strGlass = i.strGlass;
                    b.strDrinkThumb = i.strDrinkThumb + "/preview";
                    b.strIngredient1 = i.strIngredient1;
                    b.strIngredient2 = i.strIngredient2;
                    b.strIngredient3 = i.strIngredient3;

                    bebidas.Add(b);
                }

                listaBebidas.bebida = bebidas;

                return listaBebidas;
            }
            catch (Exception ex)
            {
                listaBebidas.bebida = null;
                return listaBebidas;
            }
        }

        public async Task<LBebida> ObetenerBebidasIngredientes(string ingrediente)
        {
            var listaBebidas = new LBebida();
            try
            {
                string url = string.Empty;
                List<Bebida> bebidas = new List<Bebida>();
                url = _apiCocktail.Value.BusquedaIngrediente + ingrediente;
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                dynamic Objlist = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                foreach (var i in Objlist.drinks)
                {
                    Bebida b = new Bebida();
                    b.idDrink = i.idDrink;
                    b.strDrink = i.strDrink;
                    b.strDrinkThumb = i.strDrinkThumb + "/preview";
                    
                    bebidas.Add(b);
                }

                listaBebidas.bebida = bebidas;

                return listaBebidas;
            }
            catch (Exception)
            {
                listaBebidas.bebida = null;
                return listaBebidas;
            }
        }
    }
}
