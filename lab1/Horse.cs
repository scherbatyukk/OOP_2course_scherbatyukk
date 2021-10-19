using System;
using static System.Console;
namespace lab1
{
    class Horse : FarmPet
    {
        private DateTime birthDate;
        private double consumptionPerDay;
        private Horse()
        {
            this.birthDate = DateTime.Now;
            this.consumptionPerDay = 0;
        }
        private Horse(string ownerName, string licenceID, double amountOfWaterToOvercomeThirst, double consumptionPerDay) : base(ownerName, licenceID, amountOfWaterToOvercomeThirst)
        {
            this.birthDate = DateTime.Now;
            this.consumptionPerDay = consumptionPerDay;
        }
        private static int price = 100;
        private bool bought = false;
        public static Horse GetPet(int money)
        {
            if(money >= price)
            {
                return new Horse(){
                    bought = true
                }; 
            }
            else
            {
                return null;
            }
        }
        public static Horse GetPet(string name, string licenceID, double amountOfFoodToBeFull, double consumptionPerDay, int money)
        {
            if(money >= price)
            {
                return new Horse(name, licenceID, amountOfFoodToBeFull, consumptionPerDay){
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
        public double Drinks
        {
            get
            {
                if (ConsumptionPerDay != 0)
                {
                    return ConsumptionPerDay / amountOfWaterToOvercomeThirst;
                }
                else
                {
                    return -1;
                }
            }
        }
        public void StrokeTheHorse()
        {
            WriteLine("Horse is happy that you stroked her! Horse love u <3");
        }
        public override string GetPetDescription()
        {
            return $"Horse description:\n - Owner: {ownerName}\n - Licence ID: {licenceID}" + 
            $"\n - Type: {petType}\n - Amount of water to not be thirst: {amountOfWaterToOvercomeThirst}" + 
            $"\n - Birth Date: {birthDate.ToString("d")}";
        }
        ~Horse()
        {
            WriteLine("- Dog destructor called -");
        }
    }
}