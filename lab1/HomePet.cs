using System;
using static System.Console;
namespace lab1
{
    class HomePet : Pet
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
        public void FeedThePet(double foodAmount)
        {
            if (currentAmountOfFoodNeeded > foodAmount)
            {
                currentAmountOfFoodNeeded -= foodAmount;
            }
            else
            {
                currentAmountOfFoodNeeded = 0;
            }
        }
        public override string GetPetDescription()
        {
            return $"Pet description:\n - Name of pet owner: {ownerName}\n - Licence ID: {licenceID}\n - Type: {petType}\n - Amount of food to be full: {amountOfFoodToBeFull} grams";
        }
        ~HomePet()
        {
            WriteLine("- HomePet destructor called -");
        }
    }
}