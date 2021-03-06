namespace SquareCalculatorLib
{
    public static class Calculator
    {
        public static double CalculateSquareOf(params int[] measurements)
        {
            switch (measurements.Length)
            {
                case 1:
                    {
                        Circle circle = new Circle(measurements[0]);
                        Console.WriteLine("Circle");
                        return circle.GetSquare();
                    }

                case 3:
                    {
                        Triangle triangle = new Triangle(measurements[0], measurements[1], measurements[2]);
                        Console.WriteLine("Triangle");
                        return triangle.GetSquare();
                    }

                default: throw new Exception("Not supported.");

            }
        }
        public static bool IsThisRight(params int[] sides)
        {
            if (sides.Length == 3)
            {
                Triangle triangle = new Triangle(sides[0], sides[1], sides[2]);
                return triangle.IsRight();
            }
            else throw new ArgumentException("You didn't pass sufficient information about the triangle.");
        }
    }
}
