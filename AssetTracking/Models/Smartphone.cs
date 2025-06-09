using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Smartphone : Asset
    {
        public Smartphone(Price price, string brand, string model, DateTime purchaseDate, Office office)
            : base(brand, model, purchaseDate, price, office) // هذا الترتيب يتطابق مع Asset
        {
        }


        public override string GetTypeName()
        {
            return "Smartphone";
        }

    }
}
