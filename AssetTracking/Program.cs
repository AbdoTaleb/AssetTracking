using AssetTracking.Models;
using System;

namespace AssetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyConverter.UpdateRates();

            var usa = new Office("USA", "USD");
            var sweden = new Office("Sweden", "SEK");
            var germany = new Office("Germany", "EUR");

            var tracker = new AssetManager();


            
            tracker.AddAsset(new Smartphone(new Price(400, "USD"), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", usa));
            tracker.AddAsset(new Smartphone(new Price(400, "USD"), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", usa));
            tracker.AddAsset(new Smartphone(new Price(4500, "SEK"), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", sweden));
            tracker.AddAsset(new Smartphone(new Price(4500, "SEK"), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", sweden));
            tracker.AddAsset(new Smartphone(new Price(3000, "SEK"), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", sweden));
            tracker.AddAsset(new Smartphone(new Price(3000, "SEK"), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", sweden));
            tracker.AddAsset(new Smartphone(new Price(220, "EUR"), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", germany));

            tracker.AddAsset(new Computer(new Price(100, "USD"), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", usa));
            tracker.AddAsset(new Computer(new Price(100, "USD"), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", usa));
            tracker.AddAsset(new Computer(new Price(300, "USD"), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", usa));
            tracker.AddAsset(new Computer(new Price(300, "USD"), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", usa));
            tracker.AddAsset(new Computer(new Price(500, "USD"), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", usa));
            tracker.AddAsset(new Computer(new Price(1500, "SEK"), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", sweden));
            tracker.AddAsset(new Computer(new Price(1400, "SEK"), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", sweden));
            tracker.AddAsset(new Computer(new Price(1300, "SEK"), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", sweden));
            tracker.AddAsset(new Computer(new Price(1600, "EUR"), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", germany));
            tracker.AddAsset(new Computer(new Price(1200, "EUR"), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", germany));
            tracker.AddAsset(new Computer(new Price(1200, "EUR"), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", germany));
            tracker.AddAsset(new Computer(new Price(1300, "EUR"), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", germany));

            // Step 5: Confirmation message
            Console.WriteLine("✅ Assets added successfully!");

            tracker.PrintAssets();

        }
    }
}