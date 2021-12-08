using System.Collections.Generic;
public abstract class Figure
{
    protected char figureSymbol;
    protected string role;
    public string Role
    {
        get { return this.role; }
    }
    public char Symbol
    {
        get { return this.figureSymbol; }
    }
}
public class Pawn : Figure
{
    public Pawn()
    {
        this.figureSymbol = 'P';
        this.role = "Pawn";
    }
} 
public class Rook : Figure
{
    public Rook()
    {
        this.figureSymbol = 'R';
        this.role = "Rook";
    }
}
public class Knight : Figure
{
    public Knight()
    {
        this.figureSymbol = 'N';
        this.role = "Knight";
    }
}
public class Bishop : Figure
{
    public Bishop()
    {
        this.figureSymbol = 'B';
        this.role = "Bishop";
    }
}
public class Queen : Figure
{
    public Queen()
    {
        this.figureSymbol = 'Q';
        this.role = "Queen";
    }
}
public class King : Figure
{
    public King()
    {
        this.figureSymbol = 'K';
        this.role = "King";
    }
}
public class Empty : Figure
{
    public Empty()
    {
        this.figureSymbol = ' ';
        this.role = "Empty";
    }
}
public class FigureFactory
{
    private Dictionary<char, Figure> figures;

    public FigureFactory()
    {
        this.figures = new Dictionary<char, Figure>();
        this.figures.Add('P', new Pawn());
        this.figures.Add('K', new King());
        this.figures.Add('Q', new Queen());
        this.figures.Add('B', new Bishop());
        this.figures.Add('N', new Knight());
        this.figures.Add('R', new Rook());
        this.figures.Add('E', new Empty());
    }
    public Figure GetFigure(char c)
    {
        Figure f = this.figures[c];
        return f;
    }
}