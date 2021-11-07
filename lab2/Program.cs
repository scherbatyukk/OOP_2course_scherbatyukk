using System;
using static System.Console;
namespace lab2
{
    public delegate void Order(FeedingOperator oper, FeedingEventArgs args);
    class Program
    {
        static void Main(string[] args)
        {
            // Pet pet = new Pet("Yaroslav Scherbatyuk", "ABCD1234");
            // FarmPet farmPet = new FarmPet("Yaroslav Scherbatyuk", "ABCD1234", 5);
            // HomePet homePet = new HomePet("Yaroslav Scherbatyuk", "ABCD1234", 300);
            // Dog dog = Dog.GetPet("Ivan", "OO0000OO", 450, 900, 120);

            // DisposePets();
            // Console.WriteLine("\nMemory before creating 10_000 obj: " + GC.GetTotalMemory(false));
            // for (int i = 0; i < 10_000; i++)
            // {            
            //     Pet pet1 = new Pet();
            //     pet1.Dispose();
            // }
            // Console.WriteLine($"Memory after creating 10_000 obj: {GC.GetTotalMemory(false)}\nGeneration of 'dog' obj before collecting: {GC.GetGeneration(dog)}\n");
            // GC.Collect(2);
            // GC.WaitForPendingFinalizers();
            // Console.WriteLine($"\nMemory after collecting garbage: {GC.GetTotalMemory(false)}\nGeneration of 'dog' obj after collecting: {GC.GetGeneration(dog)}\nGarbage Collection count: {GC.CollectionCount(0)}\n");
        
            FeedingOperator oper = new FeedingOperator("Taras Bulba");
            PetRestaurant station = new PetRestaurant(oper);
            oper.FeedUp();
            Order currentFillInfo = delegate(FeedingOperator oper, FeedingEventArgs fArgs)
            {
                Console.WriteLine($"Current filling/charging operator: [{oper.Fullname}]; Current filling volume: [{fArgs.WaterAmount}] milliliters; Current charging power: [{fArgs.FoodAmount}] grams");
            };
            currentFillInfo(oper, oper.fArgs);
            Console.WriteLine();
            Dog goldenRetriever = Dog.GetPet("Yaroslav Scherbatyuk", "AB1234CD", 500, 1050, 200);
            //tesla.OnPartyMode();
        }

        private static void DisposePets()
        {
            Horse horse = Horse.GetPet(120);
            Dog dog = Dog.GetPet(100);
            horse.Dispose();
            dog.Dispose();
            GC.ReRegisterForFinalize(horse);
            GC.ReRegisterForFinalize(dog);
        }
    }
}
