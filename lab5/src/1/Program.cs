using System;
class Program
{
    public static void ProductProcess(Product product)
    {
        while(true)
        {
            Console.WriteLine("Enter command(product mode)");
            string str = Console.ReadLine();
            if(str == "exit")
            {
                break;
            }
            if(str == "eat")
            {
                product.Eat();
                continue;
            }
            Console.WriteLine("Wrong command");
        }
    }
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Enter commmand");
            string str = Console.ReadLine();
            if(str == "exit")
            {
                break;
            }
            if(str.StartsWith("createProduct"))
            {
                string[] data = str.Split(' ');
                DateTime date = DateTime.Now;
                date = date.AddDays(int.Parse(data[2]));
                Product product = new Product(data[1], date);
                ProductProcess(product);
            }
        }
        
    }
}

