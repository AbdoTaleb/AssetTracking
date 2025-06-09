using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Computer : Asset
    {
        public Computer(Price price, DateTime purchaseDate, string brand, string model, Office office)
            : base(brand, model, purchaseDate, price, office)
        {
        }
    }
}
