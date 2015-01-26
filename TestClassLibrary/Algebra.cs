using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassLibrary
{
    public class Algebra
    {
        public double Addition(double x, double y)
        {
            return x + y;
        }
        private double Subtraction(double x, double y)
        {
            return x - y;
        }
        protected double Multiplication(double x, double y)
        {
            return x * y;
        }
        internal double Division(double x, double y)
        {
            return x / y;
        }
    }
}
