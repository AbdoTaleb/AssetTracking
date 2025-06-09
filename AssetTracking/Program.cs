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


            /*
            tracker.AddAsset(new Smartphone(new Price(400, "USD"), "Motorola", "X3", DateTime.Now.AddMonths(-36 + 5), usa));
            tracker.AddAsset(new Smartphone(new Price(400, "USD"), "Motorola", "X2", DateTime.Now.AddMonths(-36 + 10), usa));
            tracker.AddAsset(new Smartphone(new Price(4500, "SEK"), "Samsung", "Galaxy 10", DateTime.Now.AddMonths(-36 + 6), sweden));
            tracker.AddAsset(new Smartphone(new Price(4500, "SEK"),"Samsung", "Galaxy 10", DateTime.Now.AddMonths(-36 + 7), sweden));
            tracker.AddAsset(new Smartphone(new Price(3000, "SEK"),"Sony", "XPeria 7", DateTime.Now.AddMonths(-36 + 4), sweden));
            tracker.AddAsset(new Smartphone(new Price(3000, "SEK"),"Sony", "XPeria 7", DateTime.Now.AddMonths(-36 + 5), sweden));
            tracker.AddAsset(new Smartphone(new Price(220, "EUR"),"Siemens", "Brick", DateTime.Now.AddMonths(-36 + 12), germany));

            tracker.AddAsset(new Computer(new Price(100, "USD"), "Dell", "Desktop 900", DateTime.Now.AddMonths(-38), usa));
            tracker.AddAsset(new Computer(new Price(100, "USD"), "Dell", "Desktop 900", DateTime.Now.AddMonths(-37), usa));
            tracker.AddAsset(new Computer(new Price(300, "USD"), "Lenovo", "X100", DateTime.Now.AddMonths(-36 + 1), usa));
            tracker.AddAsset(new Computer(new Price(300, "USD"), "Lenovo", "X200", DateTime.Now.AddMonths(-36 + 4), usa));
            tracker.AddAsset(new Computer(new Price(500, "USD"), "Lenovo", "X300", DateTime.Now.AddMonths(-36 + 9), usa));
            tracker.AddAsset(new Computer(new Price(1500, "SEK"), "Dell", "Optiplex 100", DateTime.Now.AddMonths(-36 + 7), sweden));
            tracker.AddAsset(new Computer(new Price(1400, "SEK"), "Dell", "Optiplex 200", DateTime.Now.AddMonths(-36 + 8), sweden));
            tracker.AddAsset(new Computer(new Price(1300, "SEK"), "Dell", "Optiplex 300", DateTime.Now.AddMonths(-36 + 9), sweden));
            tracker.AddAsset(new Computer(new Price(1600, "EUR"),"Asus", "ROG 600", DateTime.Now.AddMonths(-36 + 14), germany));
            tracker.AddAsset(new Computer(new Price(1200, "EUR"),  "Asus", "ROG 500", DateTime.Now.AddMonths(-36 + 4), germany));
            tracker.AddAsset(new Computer(new Price(1200, "EUR"),"Asus", "ROG 500", DateTime.Now.AddMonths(-36 + 3), germany));
            tracker.AddAsset(new Computer(new Price(1300, "EUR"),"Asus", "ROG 500", DateTime.Now.AddMonths(-36 + 2), germany));
            */
            
            
            //tracker.PrintAssets();
            
            while (true)
            {
                tracker.AddAssetFromUser();

                Console.Write("Add another asset? (y/n): ");
                string answer = Console.ReadLine()?.ToLower();

                if (answer != "y")
                    break;
            }

            tracker.PrintAssets();

            

        }
    }
}