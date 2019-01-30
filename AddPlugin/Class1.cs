using Common;

namespace AddPlugin
{
    public class Add : ICalculator
    {
        public string Name => "Add";

        public double Calculate(double x, double y)
        {
            return x + y;
        }
    }
}