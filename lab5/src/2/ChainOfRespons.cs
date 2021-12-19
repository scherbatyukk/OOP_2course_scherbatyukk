using System.Collections.Generic;
using System;
public abstract class BankNoteHandler
{
    protected BankNoteHandler sucsessor;
    protected int bankNoteValue;
    public BankNoteHandler(int bankNoteValue)
    {
        this.bankNoteValue = bankNoteValue;
    }
    public void SetSucsessor(BankNoteHandler h)
    {
        this.sucsessor = h;
    }
    public abstract void GetBankNotes(double amount, Dictionary<int, int> bnDict);
    protected abstract int TakeBankNotes(ref double amount);

}
public class ConcreteBankNoteHandler : BankNoteHandler
{
    public ConcreteBankNoteHandler(int bankNoteValue) : base(bankNoteValue) {}
    public override void GetBankNotes(double amount, Dictionary<int, int> bnDict)
    {
        if(amount > 0 && this.sucsessor == null)
        {
            throw new System.Exception("Unable to give cash, try enter another amount");
        }
        int  takedBankNotes = TakeBankNotes(ref amount);
        bnDict[this.bankNoteValue] = takedBankNotes;
        if(amount > 0)
            this.sucsessor.GetBankNotes(amount, bnDict);
    }
    protected override int TakeBankNotes(ref double amount)
    {
        int takedBankNotes = 0;
        while(amount >= this.bankNoteValue)
        {
            amount -= this.bankNoteValue;
            takedBankNotes ++;
        }
        return takedBankNotes;
    }
}
public class ATM
{
    private BankNoteHandler handler;
    private Dictionary<int, int> bnDict;
    public ATM()
    {
        BankNoteHandler bankNote1000 = new ConcreteBankNoteHandler(1000);
        BankNoteHandler bankNote500 = new ConcreteBankNoteHandler(500);
        BankNoteHandler bankNote200 = new ConcreteBankNoteHandler(200);
        BankNoteHandler bankNote100 = new ConcreteBankNoteHandler(100);
        BankNoteHandler bankNote50 = new ConcreteBankNoteHandler(50);
        BankNoteHandler bankNote20 = new ConcreteBankNoteHandler(20);
        BankNoteHandler bankNote10 = new ConcreteBankNoteHandler(10);
        BankNoteHandler bankNote5 = new ConcreteBankNoteHandler(5);
        BankNoteHandler bankNote2 = new ConcreteBankNoteHandler(2);
        BankNoteHandler bankNote1 = new ConcreteBankNoteHandler(1);

        bankNote1000.SetSucsessor(bankNote500);
        bankNote500.SetSucsessor(bankNote200);
        bankNote200.SetSucsessor(bankNote100);
        bankNote100.SetSucsessor(bankNote50);
        bankNote50.SetSucsessor(bankNote20);
        bankNote20.SetSucsessor(bankNote10);
        bankNote10.SetSucsessor(bankNote5);
        bankNote5.SetSucsessor(bankNote2);
        bankNote2.SetSucsessor(bankNote1);
        this.FillDict();
        this.handler = bankNote1000;
    }
    private void FillDict()
    {
        if (this.bnDict == null)
            this.bnDict = new Dictionary<int, int>();
        
        this.bnDict[1] = 0;
        this.bnDict[2] = 0;
        this.bnDict[5] = 0;
        this.bnDict[10] = 0;
        this.bnDict[50] = 0;
        this.bnDict[100] = 0;
        this.bnDict[200] = 0;
        this.bnDict[500] = 0;
        this.bnDict[1000] = 0;
    }
    private void PrintDict()
    {
        System.Console.WriteLine("Cash:");
        foreach (KeyValuePair<int, int>  pair in this.bnDict)
        {
            if(pair.Value != 0)
                System.Console.WriteLine($"{pair.Key}x{pair.Value}");
        }
    }
    public void GiveCash(double amount)
    {
        if (amount < 0)
            throw new Exception("Amount can not be negative");
        try
        {
            this.handler.GetBankNotes(amount, this.bnDict);
            this.PrintDict();
            this.FillDict();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}