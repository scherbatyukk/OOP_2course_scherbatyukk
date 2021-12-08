using System;
public class ChessDesk
{
    private Figure[,] desk = new Figure[8, 8];
    public ChessDesk(FigureFactory factory)
    {
        for(int i = 0; i < this.desk.GetLength(0); i++)
        {
            for(int j = 0; j < this.desk.GetLength(1); j++)
            {
                if(i == 1 || i == 6)
                {
                    this.desk[i, j] = factory.GetFigure('P');
                    continue;
                }
                else if(i == 0 || i == 7)
                {
                    if(j == 0 || j == 7)
                    {
                        this.desk[i, j] = factory.GetFigure('R');
                        continue;
                    }
                    if(j == 1 || j == 6)
                    {
                        this.desk[i, j] = factory.GetFigure('N');
                        continue;
                    }
                    if(j == 2 || j == 5)
                    {
                        this.desk[i, j] = factory.GetFigure('B');
                        continue;
                    }
                    if(j == 3)
                    {
                        this.desk[i, j] = factory.GetFigure('Q');
                        continue;
                    }
                    if(j == 4)
                    {
                        this.desk[i, j] = factory.GetFigure('K');
                        continue;
                    }
                }
                this.desk[i, j] = factory.GetFigure('E');
            }
        }
    }
    public void PrintDesk()
    {
        for(int i = 0; i < this.desk.GetLength(0); i++)
        {
            for(int j = 0; j < this.desk.GetLength(1); j++)
            {
                Console.Write($"{this.desk[i, j].Symbol} ");
            }
            Console.WriteLine();
        }
    }
}
