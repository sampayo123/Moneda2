using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static Moneda2.Client.Pages.Moneda;
using Moneda2.Shared.Models;

namespace Moneda2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedasController : Controller
    {
        public CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        public List<RegionInfo> countries = new List<RegionInfo>();
        public List<RegionInfo> ListaRegion = new List<RegionInfo>();
        public List<DatosMoneda> ListaDatosMoneda = new List<DatosMoneda>();
        string MonedaAnterior;
        [HttpGet]
        public async Task<ActionResult<List<DatosMoneda>>> GetOportunidad()
        {
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo regionInfo = new RegionInfo(ci.TextInfo.CultureName);
                //RegionInfo regionInfo = new RegionInfo("es-ES");
                if (countries.Count(x => x.CurrencyEnglishName == regionInfo.CurrencyNativeName) <= 0)
                {
                    if (MonedaAnterior != regionInfo.CurrencyNativeName)
                    {
                        MonedaAnterior =  regionInfo.CurrencyNativeName;
                        
                        countries.Add(regionInfo);

                    }

                }
                    
            }
            foreach (RegionInfo regionInfo in countries.OrderBy(x => x.Name))
            {

            
                ListaRegion.Add(regionInfo);
            }
            //Serializacion de los datos necesaria para region info
            var jsonString = JsonSerializer.Serialize(ListaRegion);
            ListaDatosMoneda = JsonSerializer.Deserialize<List<DatosMoneda>>(jsonString);

            return ListaDatosMoneda;
        }
    }



}
