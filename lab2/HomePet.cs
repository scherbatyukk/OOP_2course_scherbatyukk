using System;
using static System.Console;
namespace lab2
{
    abstract class HomePet : Pet, IHomePet
    {
        protected double amountOfFoodToBeFull;
        protected double currentAmountOfFoodNeeded;
        static HomePet()
        {
            petType = "Lives in a Home";
        }
        public HomePet(string ownerName, string licenceID, double amountOfFoodToBeFull) : base(ownerName, licenceID)
        {
            if (amountOfFoodToBeFull > 0)
            {
                this.amountOfFoodToBeFull = amountOfFoodToBeFull;    
            }
            else
            {
                this.amountOfFoodToBeFull = 0;
            }            
        }
        public HomePet() : base()
        {
            this.amountOfFoodToBeFull = 500;
        }
        void IHomePet.FeedThePet(FeedingOperator oper, FeedingEventArgs fArgs)
        {
            Action<FeedingOperator> newClientReact = oper => WriteLine($"{oper.Fullname} see new client pet, it's Home Pet");
            newClientReact(oper);
            Func<double, double, double> calcPercent = (currValue, maxValue) => currValue / maxValue * 100;
            if (currentAmountOfFoodNeeded > fArgs.FoodAmount)
            {
                currentAmountOfFoodNeeded -= fArgs.FoodAmount;
                double currPercentOfFood = calcPercent(amountOfFoodToBeFull - currentAmountOfFoodNeeded, amountOfFoodToBeFull);
                WriteLine($"Pet of {ownerName} serviced by {oper.Fullname}. Current lvl of satiety of pet: {currPercentOfFood:f2} %");
            }
            else
            {
                currentAmountOfFoodNeeded  = 0;
                WriteLine($"Pet of {ownerName} serviced by {oper.Fullname}. Current lvl of satiety of pet: 100 %");
            }
        }
        public override string GetPetDescription()
        {
            return $"Pet description:\n - Name of pet owner: {ownerName}\n - Licence ID: {licenceID}\n - Type: {petType}\n - Amount of food to be full: {amountOfFoodToBeFull} grams";
        }
        public override void Jump(int times)
        {
            WriteLine($"Home pet jumped {times} times");
        }
    }
}