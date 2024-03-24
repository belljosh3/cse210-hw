using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        Square sShape = new Square("red", 3);
        Rectangle rShape = new Rectangle("blue", 3, 5);
        Circle cShape = new Circle ("yellow", 1);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(sShape);
        shapes.Add(rShape);
        shapes.Add(cShape);

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
        }
    }
}