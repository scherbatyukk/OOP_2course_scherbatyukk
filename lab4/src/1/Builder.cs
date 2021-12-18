using System.Text;

public class Computer
{
    public string Processor {get; set;}
    public string VideoCard {get; set;}
    public string Motherboard {get; set;}

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Computer:\n");
        sb.Append($"Processor: {this.Processor}\n");
        sb.Append($"Video card: {this.VideoCard}\n");
        sb.Append($"Motherboard: {this.Motherboard}\n");
        return sb.ToString();
    }
}
public abstract class ComputerBuilder
{
    public abstract void SetProcessor();
    public abstract void SetVideoCard();
    public abstract void SetMotherboard();
    public abstract Computer GetComputer();
}
public class CheapComputerBuilder : ComputerBuilder
{
    public Computer Computer { get; private set; }
    public CheapComputerBuilder()
    {
        this.Computer = new Computer();
    }
    public override void SetProcessor()
    {
        this.Computer.Processor = "Intel Core i3";
    }
    public override void SetVideoCard()
    {
        this.Computer.VideoCard = "NVIDIA GeForce GTX 880M 8 ГБ GDDR5";
    }
    public override void SetMotherboard()
    {
        this.Computer.Motherboard = "Asus Prime B460M-K";
    }
    public override Computer GetComputer()
    {
        return this.Computer;
    }
}
public class MidleComputerBuilder : ComputerBuilder
{
    public Computer Computer { get; private set; }
    public MidleComputerBuilder()
    {
        this.Computer = new Computer();
    }
    public override void SetProcessor()
    {
        this.Computer.Processor = "Intel Core i5";
    }
    public override void SetVideoCard()
    {
        this.Computer.VideoCard = "Palit GeForce GTX 1660";
    }
    public override void SetMotherboard()
    {
        this.Computer.Motherboard = "Asus TUF Gaming Z590-Plus";
    }
    public override Computer GetComputer()
    {
        return this.Computer;
    }
}
public class ExpensiveComputerBuilder : ComputerBuilder
{
    public Computer Computer { get; private set; }
    public ExpensiveComputerBuilder()
    {
        this.Computer = new Computer();
    }
    public override void SetProcessor()
    {
        this.Computer.Processor = "Intel Core i9";
    }
    public override void SetVideoCard()
    {
        this.Computer.VideoCard = "NVIDIA Quadro RTX 5000 MXM";
    }
    public override void SetMotherboard()
    {
        this.Computer.Motherboard = "Asus ROG STRIX Z690-F Gaming";
    }
    public override Computer GetComputer()
    {
        return this.Computer;
    }
}
public class Assistant
{
    public void Build(ComputerBuilder builder)
    {
        builder.SetMotherboard();
        builder.SetVideoCard();
        builder.SetProcessor();
    }
    public ComputerBuilder SelectComputer(double budget)
    {
        if(budget < 1000)
        {
            throw new System.Exception("Unable to biuld computer");
        }
        ComputerBuilder builder;
        if(budget > 1000 && budget < 2000)
        {
            builder = new CheapComputerBuilder();
        }
        else if (budget > 2000 && budget < 4000)
        {
            builder = new MidleComputerBuilder();
        }
        else
        {
            builder = new ExpensiveComputerBuilder();
        }
        return builder;
    }
}