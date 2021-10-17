using System;
using static System.Console;
namespace lab1
{
    class FarmPet : Pet
    {
        protected double amountOfWaterToOvercomeThirst;
        protected double currentAmountOfWaterNeeded;
        public FarmPet(string ownerName, string licenceID, double amountOfWaterPerDay) : base(ownerName, licenceID)
        {
            if (amountOfWaterPerDay > 0)
            {
                this.amountOfWaterToOvercomeThirst = amountOfWaterPerDay;    
            }
            else
            {
                this.amountOfWaterToOvercomeThirst = 0;
            }            
        }
        public FarmPet() : base()
        {
            this.amountOfWaterToOvercomeThirst = 0;
            petType = "Lives in a Farm";
        }
        public void FeedThePet(double waterAmount)
        {
            if (currentAmountOfWaterNeeded > waterAmount)
            {
                currentAmountOfWaterNeeded  -= waterAmount;
            }
            else
            {
                currentAmountOfWaterNeeded  = 0;
            }
        }
        public override string GetPetDescription()
        {
            return $"Pet description:\n - Name of pet owner: {ownerName}\n - Licence ID: {licenceID}\n - Type: {petType}\n - Amount of water to not be thirst: {amountOfWaterToOvercomeThirst} grams";
        }
        ~FarmPet()
        {
            WriteLine("- FarmPet destructor called -");
        }
    }
}