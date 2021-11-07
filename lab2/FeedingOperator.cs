using System;
using static System.Console;
namespace lab2
{
    public class FeedingOperator
    {
        public event Order FeedingEvent;
        public FeedingEventArgs fArgs;
        private string fullname;
        public FeedingOperator(string name)
        {
            this.fullname = name;
        }
        public FeedingOperator() : this("unknown") {}
        public void FeedUp()
        {
            double foodAmount, waterAmount;
            FeedingEventArgs feedArgs = null;
            try
            {
                Write("Enter amount fo food: ");
                foodAmount = Double.Parse(ReadLine());
                Write("Enter amount of water: ");
                waterAmount = Double.Parse(ReadLine());
                feedArgs = new FeedingEventArgs(foodAmount, waterAmount);
            }
            catch (Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(ex.Message);
                WriteLine("Set to default values:\n Amount of water: 1 milliliter\n Charge power: 1 grams");
                ResetColor();
                feedArgs = new FeedingEventArgs();
            }
            finally
            {
                fArgs = feedArgs;
                WriteLine($"\nOperator {this.fullname} is responsible for feeding pet.\n");
                if (FeedingEvent != null)
                {
                    FeedingEvent((FeedingOperator)this, feedArgs);
                }   
            }
        }
        public string Fullname
        {
            get
            {
                return $"{this.fullname}";
            }
        }
    }
}