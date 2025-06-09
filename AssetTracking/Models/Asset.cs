using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Asset
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Price Price { get; set; }
        public Office Office { get; set; }

        public Asset(string brand, string model, DateTime purchaseDate, Price price, Office office)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Office = office;
        }

        public virtual string GetTypeName()
        {
            return "Asset";
        }


    }
}
