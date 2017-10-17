using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2__NUnit_
{
    public class Calculator
    {
        public static double Plus(double x, double y)
        {
            return x + y;
        }
        public static double Minus(double x, double y)
        {
            return x - y;
        }
        public static double Square(double x)
        {
            return Math.Sqrt(x);
        }
        public static double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
