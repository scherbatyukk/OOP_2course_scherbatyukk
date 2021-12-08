using System;
using System.Collections.Generic;
public abstract class ProgramUI
{
    protected UILanguageInterface languageInterface;
    public UILanguageInterface LanguageInterface
    {
        set { this.languageInterface = value; }
    }
    public abstract void Notificate();
    public abstract void ShowInfo();
    public abstract void ShowDialog();
}
public class MyProgramUI : ProgramUI
{
    public override void Notificate()
    {
        this.languageInterface.Notificate();
    }
    public override void ShowDialog()
    {
        this.languageInterface.ShowDialog();
    }
    public override void ShowInfo()
    {
        this.languageInterface.ShowInfo();
    }
    public MyProgramUI()
    {
        this.languageInterface = new UkrainianLanguageInterface();
    }
    public MyProgramUI(UILanguageInterface languageInterface)
    {
        this.languageInterface = languageInterface;
    }
}

public abstract class UILanguageInterface
{
    public abstract void Notificate();
    public abstract void ShowInfo();
    public abstract void ShowDialog();
}

public class EnglishLanguageInterface : UILanguageInterface
{
    public override void Notificate()
    {
        Console.WriteLine("Notification");
    }
    public override void ShowDialog()
    {
        Console.WriteLine("Dialog window");
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Window with information");
    }
}
public class RussianLanguageInterface : UILanguageInterface
{
    public override void Notificate()
    {
        Console.WriteLine("Уведомление");
    }
    public override void ShowDialog()
    {
        Console.WriteLine("Диалоговое окно");
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Окно с информацией");
    }
}

public class UkrainianLanguageInterface : UILanguageInterface
{
    public override void Notificate()
    {
        Console.WriteLine("Сповіщення");
    }
    public override void ShowDialog()
    {
        Console.WriteLine("Діалогове вікно");
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Вікно з інформацією");
    }
}

public class LanguageGenerator
{
    private Dictionary<string, UILanguageInterface> langDict;
    public LanguageGenerator()
    {
        this.langDict = new Dictionary<string, UILanguageInterface>();
        this.langDict.Add("eng", new EnglishLanguageInterface());
        this.langDict.Add("rus", new RussianLanguageInterface());
        this.langDict.Add("ukr", new UkrainianLanguageInterface());
    }
    public UILanguageInterface GetLanguageInterface(string langName)
    {
        UILanguageInterface lang ;

        try
        {
            lang = this.langDict[langName];
        }
        catch(Exception)
        {
            throw new Exception($"Language '{langName}' do not supports");
        }

        return lang;
    }
}