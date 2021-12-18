using System;

class Program
{
    static void Main(string[] args)
    {
        Assistant assistant = new Assistant();
        while(true)
        {
            Console.WriteLine("Enter budget");
            string str = Console.ReadLine();

            if(str == "exit")
            {
                break;
            }
            
            try
            {
                double budget = double.Parse(str);
                ComputerBuilder b = assistant.SelectComputer(budget);
                assistant.Build(b);
                Computer computer = b.GetComputer();
                Console.WriteLine(computer); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

