using System;
using static System.Console;
namespace lab1
{
    class Dog : HomePet
    {
        private DateTime birthDate;
        private double consumptionPerDay;
        private Dog()
        {
            this.birthDate = DateTime.Now;
            this.consumptionPerDay = 0;
        }
        private Dog(string ownerName, string licenceID, double amountOfFoodToBeFull, double consumptionPerDay) : base(ownerName, licenceID, amountOfFoodToBeFull)
        {
            this.birthDate = DateTime.Now;
            this.consumptionPerDay = consumptionPerDay;
        }
        private static int price = 100;
        private bool bought = false;
        public static Dog GetPet(int money)
        {
            if(money >= price)
            {
                return new Dog(){
                    bought = true
                };
            }
            else
            {
                return null;
            }
        }
        public static Dog GetPet(string name, string licenceID, double amountOfFoodToBeFull, double consumptionPerDay, int money)
        {
            if(money >= price)
            {
                return new Dog(name, licenceID, amountOfFoodToBeFull, consumptionPerDay){
                    bought = true
                }; 
            }
            else
            {
                return null;
            }
        }
        public double ConsumptionPerDay
        {
            get
            {
                return consumptionPerDay;
            }
            set
            {
                if (value > 0)
                {
                    this.consumptionPerDay = value;
                }
                else
                {
                    this.consumptionPerDay = 0;
                }
            }
        }
        public double Meals
        {
            get
            {
                if (ConsumptionPerDay != 0)
                {
                    return ConsumptionPerDay / amountOfFoodToBeFull;
                }
                else
                {
                    return -1;
                }
            }
        }
        public void GiveTheCommandToGiveAPaw (int pawNumber)
        {
            if(pawNumber == 1)
            {
                WriteLine("Dog gives you left paw!");
            }
            else if(pawNumber == 2)
            {
                WriteLine("Dog gives you right paw!");
            }
            else
            {
                WriteLine("Dog doesn't have paws with number like that!");
            }
        }
        public override string GetPetDescription()
        {
            return $"Pet description:\n - Owner: {ownerName}\n - Licence ID: {licenceID}" + 
            $"\n - Type: {petType}\n - Amount of food to be full: {amountOfFoodToBeFull}" + 
            $"\n - Birth Date: {birthDate.ToString("d")}";
        }
        ~Dog()
        {
            WriteLine("- Dog destructor called -");
        }
    }
}