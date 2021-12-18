using System;
class Program
{
    static void Main(string[] args)
    {
        OneModeVacumCleanerFactory one = new OneModeVacumCleanerFactory();
        TwoModeVacumCleanerFactory two = new TwoModeVacumCleanerFactory();
        string lineMode = "one";
        VacumCleanerFactory factory = one;

        while(true)
        {
            RobotVacumCleaner robot = factory.CreateRobotVacumCleaner();
            HandVacumCleaner hand = factory.CreateHandVacumCleaner();
            PortableVacumCleaner portable = factory.CreatePortableVacumCleaner();

            Console.WriteLine($"{robot.Name}\n{hand.Name}\n{portable.Name}");

            Console.WriteLine("Enter command");
            string command = Console.ReadLine();

            if(command == "exit")
            {
                break;
            }
            
            if(command == "switch")
            {
                if(lineMode == "one")
                {
                    lineMode = "two";
                    factory = two;
                }
                else
                {
                    lineMode = "one";
                    factory = one;
                }
            }
        }
    }
}
