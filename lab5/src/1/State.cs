using System;
public interface IFoodState
{
    void EatFood(Product p);
}
public class HealthyFoodState : IFoodState
{
    public void EatFood(Product p)
    {
        if(p.ExpirationDate > p.DateOfUse)
        {
            Console.WriteLine($"Human eats {p.Name}");
        }
        else
        {
            p.State = new UnHealthyFoodState();
            Console.WriteLine($"Human do not eat {p.Name}. {p.Name} is spoiled");
        }
        p.DateOfUse = p.DateOfUse.AddDays(1);
    }
}
public class UnHealthyFoodState : IFoodState
{
    public void EatFood(Product p)
    {
        Console.WriteLine($"Human do not eat {p.Name}. {p.Name} is spoiled");
        p.DateOfUse = p.DateOfUse.AddDays(1);
    }
}
public class Product
{
    public DateTime ExpirationDate {get; private set;}
    public string Name {get; private set;}
    public IFoodState State {get; set;}
    public DateTime DateOfUse {get; set;}
    public Product(string name, DateTime expDate)
    {
        this.Name = name;
        this.ExpirationDate = expDate;
        this.DateOfUse = DateTime.Now;
        State = new HealthyFoodState();
    }
    public void Eat()
    {
        State.EatFood(this);
    }
}