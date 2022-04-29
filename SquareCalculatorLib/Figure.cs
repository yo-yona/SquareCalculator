namespace SquareCalculatorLib
{
    internal abstract class Figure
    {
        public int[] Measurements { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }
        public Figure(params int[] measurements)
        {
            Measurements = new int[measurements.Length];
            measurements.CopyTo(Measurements, 0);
            CalcPerimeter();
            CalcArea();
        }
        public virtual void CalcPerimeter() => Perimeter = Measurements.Sum();
        public abstract void CalcArea();
        public virtual double GetArea() => Area;
        public double GetPerimeter() => Perimeter;
    }

    class Triangle : Figure
    {
        private int Hypotenuse;
        public Triangle(params int[] sides) : base(sides) { Hypotenuse = Measurements.Max();}
        public override void CalcArea()
        {
            var halfperim = Perimeter / 2;
            Area =  Math.Sqrt(halfperim * (halfperim - Measurements[0]) * (halfperim - Measurements[1]) * (halfperim - Measurements[2]));
        }
        public override double GetArea()
        {
            if (double.IsNaN(Area) || Area == 0) Console.WriteLine("Такого треугольника не существует.");
            return base.GetArea();
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
        public Circle(int radius) : base(radius) { }

        public new void CalcPerimeter() => Perimeter = Measurements[0] * 2 * Math.PI;
        public override void CalcArea() => Area = Measurements[0] * Measurements[0] * Math.PI;
    }
}
