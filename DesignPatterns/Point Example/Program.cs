namespace Point_Example
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public class Point
    {
        //factory Method
        private double x, y;
        //internal
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        //public static Point Origin => new Point(0, 0);
        public static Point Origin2 = new Point(0, 0); // better 因為直接initial once in field
        //透過中間先做好一次靜態的實體化類別去給呼叫函式者做使用
        //public static PointFactory Factory => new PointFactory();
        public static class Factory
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
            var point = Point.Factory.NewPolarPoint(1.0,Math.PI/2);
            Console.WriteLine(point);
            var origin = Point.Origin2;
            
        }
    }
}