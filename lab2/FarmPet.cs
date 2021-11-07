using System;
using static System.Console;
namespace lab2
{
    abstract class FarmPet : Pet, IFarmPet
    {
        protected double amountOfWaterToOvercomeThirst;
        protected double currentAmountOfWaterNeeded;
        static FarmPet()
        {
            petType = "Lives in a Farm";
        }
        public FarmPet(string ownerName, string licenceID, double amountOfWaterToOvercomeThirst) : base(ownerName, licenceID)
        {
            if (amountOfWaterToOvercomeThirst > 0)
            {
                this.amountOfWaterToOvercomeThirst = amountOfWaterToOvercomeThirst;    
            }
            else
            {
                this.amountOfWaterToOvercomeThirst = 1000;
            }  
            this.currentAmountOfWaterNeeded = this.amountOfWaterToOvercomeThirst;        
        }
        public FarmPet() : base()
        {
            this.amountOfWaterToOvercomeThirst = 1000;
            this.currentAmountOfWaterNeeded = this.amountOfWaterToOvercomeThirst;
        }
        void IFarmPet.WaterThePet(FeedingOperator oper, FeedingEventArgs fArgs)
        {
            Action<FeedingOperator> newClientReact = oper => WriteLine($"{oper.Fullname} see new client pet, it's Farm Pet");
            newClientReact(oper);
            Func<double, double, double> calcPercent = (currValue, maxValue) => currValue / maxValue * 100;
            if (currentAmountOfWaterNeeded > fArgs.WaterAmount)
            {
                currentAmountOfWaterNeeded -= fArgs.WaterAmount;
                double currPercentOfWater = calcPercent(amountOfWaterToOvercomeThirst - currentAmountOfWaterNeeded, amountOfWaterToOvercomeThirst);
                WriteLine($"Pet of {ownerName} serviced by {oper.Fullname}. Current lvl of water of pet: {currPercentOfWater:f2} %");
            }
            else
            {
                currentAmountOfWaterNeeded  = 0;
                WriteLine($"Pet of {ownerName} serviced by {oper.Fullname}. Current lvl of water of pet: 100 %");
            }
        }
        public override string GetPetDescription()
        {
            return $"Pet description:\n - Name of pet owner: {ownerName}\n - Licence ID: {licenceID}\n - Type: {petType}\n - Amount of water to not be thirst: {amountOfWaterToOvercomeThirst} milliliters";
        }
        public override void Jump(int times)
        {
            WriteLine($"Farm pet jumped {times} times");
        }
    }
}