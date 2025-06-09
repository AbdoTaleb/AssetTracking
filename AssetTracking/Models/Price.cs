using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Price
    {
        public decimal Amount { get; set; } 
        public string Currency { get; set; }
        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
