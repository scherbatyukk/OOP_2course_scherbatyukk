using System;
class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM();
        while(true)
        {
            Console.WriteLine("Enter amount");
            string str = Console.ReadLine();
            if(str == "exit")
            {
                break;
            }
            try
            {
                double amount = double.Parse(str);
                atm.GiveCash(amount);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

