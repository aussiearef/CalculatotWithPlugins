namespace common
{
    public interface ICalculatorPlugin
    {
        string Name { get; }
        double Calculate(double x, double y);
    }
}