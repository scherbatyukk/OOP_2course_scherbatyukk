using System;
namespace lab2
{
    public class FeedArgsException : Exception
    {
        private FeedingEventArgs args;
        public FeedArgsException(FeedingEventArgs args)
        {
            this.args = args;
        }
        public override string Message => $"Incorrectly entered data! Only positive arguments allowed!";
    }
}