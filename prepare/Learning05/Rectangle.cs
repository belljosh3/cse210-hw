public class Rectangle : Shape
{
    double _lSide;
    double _wSide;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _lSide = length;
        _wSide = width;
    }

    public override double GetArea()
    {
        return _lSide * _wSide;
    }
}