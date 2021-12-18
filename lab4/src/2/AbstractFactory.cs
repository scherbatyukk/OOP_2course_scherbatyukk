public abstract class HandVacumCleaner
{
    public string Name {get; protected set;}
    public abstract void Clean();
}
public class OneModeHandVacumCleaner : HandVacumCleaner
{
    public OneModeHandVacumCleaner()
    {
        this.Name = "One Mode Hand Vacum Cleaner";
    }
    public override void Clean() {}
}
public class TwoModeHandVacumCleaner : HandVacumCleaner
{
    public TwoModeHandVacumCleaner()
    {
        this.Name = "Two Mode Hand Vacum Cleaner";
    }
    public override void Clean() {}
    public void SwichMode() {}
}
public abstract class RobotVacumCleaner
{
    public string Name {get; protected set;} 
    public abstract void Clean();
}
public class OneModeRobotVacumCleaner : RobotVacumCleaner
{
    public OneModeRobotVacumCleaner()
    {
        this.Name = "One Mode Robot Vacum Cleaner";
    }
    public override void Clean() {}
}
public class TwoModeRobotVacumCleaner : RobotVacumCleaner
{
    public TwoModeRobotVacumCleaner()
    {
        this.Name = "Two Mode Robot Vacum Cleaner";
    }
    public override void Clean() {}
    public void SwichMode() {}
}
public abstract class PortableVacumCleaner
{
    public string Name {get; protected set;}
    public abstract void Clean();
}
public class OneModePortableVacumCleaner : PortableVacumCleaner
{
    public OneModePortableVacumCleaner()
    {
        this.Name = "One Mode Portable Vacum Cleaner";
    }
    public override void Clean() {}
}
public class TwoModePortableVacumCleaner : PortableVacumCleaner
{
    public TwoModePortableVacumCleaner()
    {
        this.Name = "Two Mode Portable Vacum Cleaner";
    }
    public override void Clean() {}
    public void SwichMode() {}
}
public abstract class VacumCleanerFactory
{
    public abstract RobotVacumCleaner CreateRobotVacumCleaner();
    public abstract HandVacumCleaner CreateHandVacumCleaner();
    public abstract PortableVacumCleaner CreatePortableVacumCleaner(); 
}
public class OneModeVacumCleanerFactory : VacumCleanerFactory
{
    public override HandVacumCleaner CreateHandVacumCleaner()
    {
        return new OneModeHandVacumCleaner();
    }
    public override PortableVacumCleaner CreatePortableVacumCleaner()
    {
        return new OneModePortableVacumCleaner();
    }
    public override RobotVacumCleaner CreateRobotVacumCleaner()
    {
        return new OneModeRobotVacumCleaner();
    }
}
public class TwoModeVacumCleanerFactory : VacumCleanerFactory
{
    public override HandVacumCleaner CreateHandVacumCleaner()
    {
        return new TwoModeHandVacumCleaner();
    }
    public override PortableVacumCleaner CreatePortableVacumCleaner()
    {
        return new TwoModePortableVacumCleaner();
    }
    public override RobotVacumCleaner CreateRobotVacumCleaner()
    {
        return new TwoModeRobotVacumCleaner();
    }
}