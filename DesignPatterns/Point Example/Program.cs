namespace Point_Example
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
    public class Point
    {
        //factory Method
        private double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        #region example for two types point
        //public Point(double a, double b,CoordinateSystem system = CoordinateSystem.Cartesian)
        //{

        //    switch (system)
        //    {
        //        case CoordinateSystem.Cartesian:
        //            x = a; y = b; break;
        //        case CoordinateSystem.Polar:
        //            x = a * Math.Cos(b);
        //            y = a * Math.Sin(b); break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(system), system, null);
        //    }

        //}
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var point = PointFactory.NewPolarPoint(1.0,Math.PI/2);
            Console.WriteLine(point);
        }
    }
}