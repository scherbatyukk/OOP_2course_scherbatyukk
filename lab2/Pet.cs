using System;
using static System.Console;
namespace lab2
{
    abstract class Pet : IDisposable
    {
        protected string ownerName;
        protected string licenceID;
        protected static string petType;
        protected bool disposed;
        public Pet()
        {
            this.ownerName = "noOwner";
            this.licenceID = "OOOO0000";
        }
        public Pet(string ownerName, string licenceID)
        {
            this.ownerName = ownerName;
            this.licenceID = licenceID;
        }
        public virtual string GetPetDescription()
        {
            return $"Pet description:\n - Name of pet owner: {ownerName}\n - Licence ID: {licenceID}";
        }
        public virtual void Dispose()
        {
            CleanUp(true);
         
            GC.SuppressFinalize(this);
        }
        protected void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Disposing managed resources
                }

                // Disposing unmanaged resources
                
                disposed = true;
            }
        }
        // ~Pet()
        // {
        //     CleanUp(false);

        //     WriteLine("- Pet destructor called -");
        // }
        public abstract void Jump(int times);
    }
}