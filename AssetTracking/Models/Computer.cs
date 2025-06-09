using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Computer : Asset
    {
        public Computer(Price price, string brand, string model, DateTime purchaseDate, Office office)
            : base(brand, model, purchaseDate, price, office) 
        {
        }


        public override string GetTypeName()
        {
            return "Computer";
        }

    }
}
