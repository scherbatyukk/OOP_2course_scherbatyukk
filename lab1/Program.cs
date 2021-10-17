using System;

namespace lab1
{
    class Program
    {
        static void Main()
        {
            Pet pet = new Pet("Yaroslav Scherbatyuk", "ABCD1234");
            FarmPet farmPet = new FarmPet("Yaroslav Scherbatyuk", "ABCD1234", 5);
            HomePet homePet = new HomePet("Yaroslav Scherbatyuk", "ABCD1234", 300);
            Dog dog = Dog.GetPet("Ivan", "OO0000OO", 450, 900);

            DisposePets();

            Console.WriteLine("\nMemory before creating 10_000 obj: " + GC.GetTotalMemory(false));
            
            for (int i = 0; i < 10_000; i++)
            {            
                Pet pet1 = new Pet();

                pet1.Dispose();
            }

            Console.WriteLine($"Memory after creating 10_000 obj: {GC.GetTotalMemory(false)}\n");
            Console.WriteLine($"Generation of 'dog' obj before collecting: {GC.GetGeneration(dog)}\n");

            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            
            Console.WriteLine($"\nMemory after collecting garbage: {GC.GetTotalMemory(false)}\n");
            Console.WriteLine($"Generation of 'dog' obj after collecting: {GC.GetGeneration(dog)}");
            Console.WriteLine($"Garbage Collection count: {GC.CollectionCount(0)}\n");
        }

        private static void DisposePets()
        {
            Horse horse = Horse.GetPet();
            Dog dog = Dog.GetPet();
            horse.Dispose();
            dog.Dispose();
            GC.ReRegisterForFinalize(horse);
            GC.ReRegisterForFinalize(dog);
        }
    }
}
