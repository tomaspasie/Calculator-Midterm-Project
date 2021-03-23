using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Subtraction Decorator (Decorator Design Pattern)
    class SubtractionDecorator : CalculatorDecorator
    {
        public SubtractionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var difference = Calculation.Create(a, b, Operations.Subtraction, calculator);

            return difference;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A, calculator.Calculation_History[^1].B);
        }
    }
}