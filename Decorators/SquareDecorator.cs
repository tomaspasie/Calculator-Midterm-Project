using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Square Decorator (Decorator Design Pattern)
    class SquareDecorator : CalculatorDecorator
    {
        public SquareDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a)
        {
            var square = Calculation.Create(a, 0, Operations.Square, calculator);

            return square;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A, 0);
        }
    }
}