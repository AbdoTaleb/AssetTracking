using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AssetTracker;

namespace AssetTracking.Models
{
    public class AssetManager
    {
        private List<Asset> assets = new List<Asset>();

        public void AddAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset), "Asset cannot be null");
            }
            assets.Add(asset);
        }

        public void PrintAssets()
        {
            var sortedAssets = assets.OrderBy(a => a.Office.Name)
                .ThenBy(a => a.GetTypeName())
                .ThenBy(a => a.PurchaseDate)
                .ToList();

            Console.WriteLine($"{"Office",-10}{"Type",-10}{"Brand",-10}{"Model",-10}{"Purchase date",-30}{"Price",-10}");

            foreach (var asset in sortedAssets)
            {
                // Claculate the age of the asset
                var age = DateTime.Now - asset.PurchaseDate;
                var lifeSpan = TimeSpan.FromDays(365 * 3);
                var remaining = lifeSpan - age;

                // Convert price to local currency
                decimal localPrice = CurrencyConverter.Convert(asset.Price.Amount, asset.Price.Currency, asset.Office.Currency);
                if (remaining.TotalDays <= 90)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (remaining.TotalDays <= 180)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine($"{asset.Office.Name,-10} {asset.GetTypeName(),-10} {asset.Brand,-10} {asset.Model,-15} {asset.PurchaseDate:yyyy-MM-dd,-15} {localPrice,10} {asset.Office.Currency}");

                Console.ResetColor();

            }


        }

        public void AddAssetFromUser()
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Purchase Date (yyyy-MM-dd): ");
            DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Price Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Price Currency (e.g., USD, EUR): ");
            string currency = Console.ReadLine().ToUpper();

            Console.Write("Enter Office Name (USA, Sweden, Germany): ");
            string officeName = Console.ReadLine();

            Console.Write("Enter asset type (computer / smartphone): ");
            string type = Console.ReadLine()?.ToLower();

            Office office = new Office(officeName, currency);
            Price price = new Price(amount, currency);

            Asset asset;

            if (type == "computer") { 
                asset = new Computer(price, brand, model, purchaseDate, office);
            }
            else
            {
                asset = new Smartphone(price, brand, model, purchaseDate, office);
            }
                

            AddAsset(asset);

            Console.WriteLine("✅ Asset added successfully!\n");

            AddAsset(asset);
        }
    }
}
