namespace SquareCalculatorLib
{
    internal abstract class Figure
    {
        protected int[] Measurements { get; }
        protected double Perimeter { get; set; }
        protected double Square { get; set; }
        protected string BadFigExceptionMessage { get; set; }
        public Figure(string exMsg = "Bad Figure", params int[] measurements)
        {
            Measurements = new int[measurements.Length];
            if (measurements.Any(x => x<=0)) throw new Exception(exMsg);
            measurements.CopyTo(Measurements, 0);
            BadFigExceptionMessage = exMsg;
            CalcPerimeter();
            CalcSquare();
        }
        protected virtual void CalcPerimeter() => Perimeter = Measurements.Sum();
        protected abstract void CalcSquare();
        public virtual double GetSquare()
        {
            if (double.IsNaN(Square) || Square <= 0)
                throw new Exception(BadFigExceptionMessage);
            return Square;
        }
        public double GetPerimeter() => Perimeter;
    }

    class Triangle : Figure
    {
        private int Hypotenuse;
        public Triangle(int a, int b, int c) : base("Such a triangle does not exist.", a, b, c) 
        { 
            Hypotenuse = Measurements.Max();
        }
        protected override void CalcSquare()
        {
            var halfperim = Perimeter / 2;
            Square =  Math.Sqrt(halfperim * (halfperim - Measurements[0]) * (halfperim - Measurements[1]) * (halfperim - Measurements[2]));
        }
        public bool IsRight()
        {
            int[] othersides = Measurements.Where(x => x != Hypotenuse).ToArray();
            if (Math.Sqrt(Math.Pow(othersides[0], 2) + Math.Pow(othersides[1], 2)) == Hypotenuse) 
                return true;
            else return false;
        }
    }

    class Circle : Figure
    {
        public Circle(int radius) : base("Such a circle does not exist.", radius) { }

        protected override void CalcPerimeter() => Perimeter = Measurements[0] * 2 * Math.PI;
        protected override void CalcSquare() => Square = Measurements[0] * Measurements[0] * Math.PI;
    }
}
