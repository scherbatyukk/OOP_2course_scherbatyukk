namespace lab2
{
    public class PetRestaurant
    {
        public PetRestaurant(FeedingOperator oper)
        {
            IFarmPet[] farmPets = new IFarmPet[2];
            farmPets[0] = Horse.GetPet(120);
            farmPets[1] = Horse.GetPet("Yaroslav Scherbatyuk", "OO0000OO", 10000, 30000, 200);

            IHomePet[] iceCars = new IHomePet[2];
            iceCars[0] = Dog.GetPet(120);
            iceCars[1] = Dog.GetPet("Not Yaroslav Scherbatyuk", "AA1234AA", 300, 700, 120);

            for (int i = 0; i < 2; i++)
            {
                oper.FeedingEvent += new Order(farmPets[i].WaterThePet);
                oper.FeedingEvent += new Order(iceCars[i].FeedThePet);
            }
        }
    }
}