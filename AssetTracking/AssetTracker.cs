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

            Console.WriteLine(
                $"{"Office",-12}" +
                $"{"Type",-12}" +
                $"{"Brand",-12}" +
                $"{"Model",-18}" +
                $"{"Purchase Date",-18}" +
                $"{"Price",-12}" +
                $"{"Currency",-10}"
            );


            foreach (var asset in sortedAssets)
            {
                // Claculate the age of the asset
                var age = DateTime.Now - asset.PurchaseDate;
                var lifeSpan = TimeSpan.FromDays(365 * 3);
                var remaining = lifeSpan - age;

                string formattedDate = asset.PurchaseDate.ToString("yyyy-MM-dd");


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
                Console.WriteLine(
                    $"{asset.Office.Name,-12}" +
                    $"{asset.GetTypeName(),-12}" +
                    $"{asset.Brand,-12}" +
                    $"{asset.Model,-18}" +
                    $"{formattedDate,-18}" +
                    $"{localPrice,-12}" +
                    $"{asset.Office.Currency,-10}"
                );

                Console.ResetColor();

            }


        }

        public void AddAssetFromUser()
        {
            string type = "";
            while (true)
            {
                Console.Write("Enter asset type (computer / smartphone) or 'exit' to cancel: ");
                type = Console.ReadLine()?.Trim().ToLower();

                if (type == "exit") return;

                if (type == "computer" || type == "smartphone") break;

                Console.WriteLine("❌ Invalid type. Please enter 'computer' or 'smartphone'.");
            }

            Console.Write("Enter Brand (or 'exit' to cancel): ");
            string brand = Console.ReadLine()?.Trim();
            if (brand?.ToLower() == "exit") return;

            Console.Write("Enter Model (or 'exit' to cancel): ");
            string model = Console.ReadLine()?.Trim();
            if (model?.ToLower() == "exit") return;

            DateTime purchaseDate;
            while (true)
            {
                Console.Write("Enter Purchase Date (yyyy-mm-dd) or 'exit' to cancel: ");
                string dateInput = Console.ReadLine()?.Trim();
                if (dateInput?.ToLower() == "exit") return;

                if (DateTime.TryParse(dateInput, out purchaseDate)) break;

                Console.WriteLine("❌ Invalid date format. Please try again.");
            }

            decimal amount;
            while (true)
            {
                Console.Write("Enter Price (positive number) or 'exit' to cancel: ");
                string priceInput = Console.ReadLine()?.Trim();
                if (priceInput?.ToLower() == "exit") return;

                if (decimal.TryParse(priceInput, out amount) && amount >= 0) break;

                Console.WriteLine("❌ Invalid price. Please enter a positive number.");
            }

            string currency;
            while (true)
            {
                Console.Write("Enter Currency (USD, SEK, EUR) or 'exit' to cancel: ");
                currency = Console.ReadLine()?.Trim().ToUpper();
                if (currency == "EXIT") return;

                if (currency == "USD" || currency == "SEK" || currency == "EUR") break;

                Console.WriteLine("❌ Invalid currency. Must be USD, SEK, or EUR.");
            }

            string officeName;
            while (true)
            {
                Console.Write("Enter Office Name (USA / Sweden / Germany) or 'exit' to cancel: ");
                officeName = Console.ReadLine()?.Trim();
                if (officeName?.ToLower() == "exit") return;

                if (!string.IsNullOrWhiteSpace(officeName)) break;

                Console.WriteLine("❌ Invalid office name. Please try again.");
            }

            var office = new Office(officeName, currency);
            var price = new Price(amount, currency);

            Asset asset = type == "computer"
                ? new Computer(price, brand, model, purchaseDate, office)
                : new Smartphone(price, brand, model, purchaseDate, office);

            AddAsset(asset);
            Console.WriteLine("✅ Asset added successfully.\n");
        }

    }
}
