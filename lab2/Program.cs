using System;
using static System.Console;
namespace lab2
{
    public delegate void Order(FeedingOperator oper, FeedingEventArgs args);
    class Program
    {
        static void Main(string[] args)
        {
            FeedingOperator oper = new FeedingOperator("Elon Mask");
            PetRestaurant station = new PetRestaurant(oper);
            oper.FeedUp();
            Order currentFeedInfo = delegate(FeedingOperator oper, FeedingEventArgs fArgs)
            {
                WriteLine($"Current feeding operator: {oper.Fullname}; Current water amount: {fArgs.WaterAmount} milliliters; Current food amount: {fArgs.FoodAmount} grams");
            };
            currentFeedInfo(oper, oper.fArgs);
            WriteLine();
            Dog goldenRetriever = Dog.GetPet("Yaroslav Scherbatyuk", "AB1234CD", 500, 1050, 200);
        }
    }
}
