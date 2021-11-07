using System;
namespace lab2
{
    public class FeedingEventArgs : EventArgs
    {
        private double foodAmount;
        private double waterAmount;
        public FeedingEventArgs(double foodAmount, double waterAmount)
        {
            if (foodAmount <= 0 || waterAmount <= 0)
            {
                throw new FeedArgsException(this);
            }
            this.foodAmount = foodAmount;
            this.waterAmount = waterAmount;
        }
        public FeedingEventArgs() : this(1, 1) {}
        public double FoodAmount
        {
            get
            {
                return this.foodAmount;
            }
            set
            {
                if (value > 0)
                {
                    this.foodAmount = value;
                }
            }
        }
        public double WaterAmount
        {
            get
            {
                return waterAmount;
            }
            set
            {
                if (value > 0)
                {
                    this.waterAmount = value;
                }
            }
        }
    }
}