using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Yellow", 2);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Orange", 3, 4);
        shapes.Add(s2);

        Circle s3 = new Circle("Violet", 5);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = Math.Round(s.GetArea(), 2);
           
            Console.WriteLine($"The {color} shape has an area of {area}");
        }

    }
}