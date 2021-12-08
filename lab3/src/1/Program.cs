using System;
using System.Collections.Generic;
class Program
{
    delegate void UIOperation();
    static void Main(string[] args)
    {
        LanguageGenerator generator = new LanguageGenerator();
        ProgramUI programUI = new MyProgramUI();

        Dictionary<string, UIOperation> opDict = new Dictionary<string, UIOperation>();
        opDict.Add("notif", programUI.Notificate);
        opDict.Add("dialog", programUI.ShowDialog);
        opDict.Add("info", programUI.ShowInfo);

        while(true)
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();
            if(command == "exit")
            {
                break;
            }

            string[] commandData = command.Split(' ');

            try
            {
                if(commandData[0] == "changeLang")
                {
                    programUI.LanguageInterface = generator.GetLanguageInterface(commandData[1]);
                }
                else
                {
                    opDict[commandData[0]]();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
