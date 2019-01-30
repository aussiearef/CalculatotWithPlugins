using Common;

namespace SubtractPlugin
{
    public class Class1 : ICalculator
    {
        public string Name => "Subtract";

        public double Calculate(double x, double y)
        {
            return x - y;
        }
    }
}