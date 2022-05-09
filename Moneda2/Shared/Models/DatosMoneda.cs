using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneda2.Shared.Models
{
    public class DatosMoneda
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string EnglishName { get; set; }
        public bool IsMetric { get; set; }
        public string ThreeLetterISORegionName { get; set; }
        public string ThreeLetterWindowsRegionName { get; set; }
        public string TwoLetterISORegionName { get; set; }
        public string CurrencySymbol { get; set; }
        public string ISOCurrencySymbol { get; set; }
        public string CurrencyNativeName { get; set; }
        public string CurrencyEnglishName { get; set; }
        public string nativeName { get; set; }
        public string geoId { get; set; }

    }
}
