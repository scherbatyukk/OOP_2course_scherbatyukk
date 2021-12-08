using System;
class Program
{
    static void Main(string[] args)
    {
        FigureFactory factory = new FigureFactory();
        ChessDesk desk = new ChessDesk(factory);
        desk.PrintDesk();
    }
}