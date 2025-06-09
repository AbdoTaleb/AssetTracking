using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Office
    {
        public string Name { get; set; }
        public string Currency { get; set; }

        public Office(string name, string currency)
        {
            Name = name;
            Currency = currency;
        }
    }
}
