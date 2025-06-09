using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Xml.Linq;

namespace AssetTracker
{
    public static class CurrencyConverter
    {
        private static Dictionary<string, decimal> rates = new Dictionary<string, decimal>();

        public static void UpdateRates()
        {
            string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";

            try
            {
                XDocument doc = XDocument.Load(url);
                XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

                rates.Clear();
                rates["EUR"] = 1m; 

                foreach (var cube in doc.Descendants().Where(x => x.Name.LocalName == "Cube" && x.Attribute("currency") != null))
                {
                    string currency = cube.Attribute("currency").Value;
                    decimal rate = decimal.Parse(cube.Attribute("rate").Value, CultureInfo.InvariantCulture);
                    rates[currency] = rate;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error fetching currency rates: " + ex.Message);
            }
        }

        public static decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            if (!rates.ContainsKey(fromCurrency) || !rates.ContainsKey(toCurrency))
            {
                throw new Exception($"Currency not found: {fromCurrency} or {toCurrency}");
            }

            decimal amountInEuro = fromCurrency == "EUR" ? amount : amount / rates[fromCurrency];
            decimal convertedAmount = toCurrency == "EUR" ? amountInEuro : amountInEuro * rates[toCurrency];

            return Math.Round(convertedAmount, 2);
        }
    }
}
