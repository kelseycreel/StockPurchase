using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchase
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("DIS", "Walt Disney Co");
            stocks.Add("GE", "General Electric");

            // Create list of ValueTuples that represents stock purchases. Properties will be `ticker`, `shares`, `price`.

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>(); // this is something called a "TUPLE" whatever that is

            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 150, price: 18.42));
            purchases.Add((ticker: "CAT", shares: 150, price: 103.12));
            purchases.Add((ticker: "DIS", shares: 150, price: 95.99));

            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.

            Dictionary<string, double> Ownership = new Dictionary<string, double>();

            foreach (var purchase in purchases)
            {
                var stock = stocks[purchase.ticker];

                var purch = purchases.Where(x => purchase.ticker == x.ticker);

                foreach (var p in purch)
                {
                    //Console.WriteLine($"{stock} {p.ticker} stocks are worth ${Math.Round((p.shares * p.price), 2)}.");

                    var value = Math.Round((p.shares * p.price), 2);
                    
                    Ownership.Add(stock, value);
                }
                
                // this "works" but it helped figure out the above which works better
                //var purchTicker = purchases.Where(x => purchase.ticker == x.ticker).Select(x => x.ticker);
                //var purchShares = purchases.Where(x => purchase.ticker == x.ticker).Select(x => Convert.ToDouble(x.shares));
                //var purchPrice = purchases.Where(x => purchase.ticker == x.ticker).Select(x => x.price);

                //foreach (var pp in purchPrice)
                //{
                //    foreach (var ps in purchShares)
                //    {
                //        Console.WriteLine($"{stock} stocks are worth ${(ps * pp)}.");
                //    }
                //}

            }

            /*
             * Define a new Dictionary to hold the aggregated purchase information. - The key should be a string that is the full company name.
             * The value will be the valuation of each stock (price*amount) { "General Electric": 35900, "AAPL": 8445, ... }
            */

            foreach (var own in Ownership)
            {
                Console.WriteLine($"The {own.Key} is worth {own.Value}.");
            }

            //// Iterate over the purchases and update the valuation for each stock
            //foreach ((string ticker, int shares, double price) purchase in purchases)
            //{
            //    // Does the company name key already exist in the report dictionary?
            //    // If it does, update the total valuation
            //    // If not, add the new key and set its value
            //}
        }
    }
}
