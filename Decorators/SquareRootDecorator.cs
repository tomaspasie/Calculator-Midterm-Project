using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Square Root Decorator (Decorator Design Pattern)
    class SquareRootDecorator : CalculatorDecorator
    {
        public SquareRootDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a)
        {
            var squareRoot = Calculation.Create(a, 0, Operations.SquareRoot, calculator);

            return squareRoot;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A,0);
        }
    }
}