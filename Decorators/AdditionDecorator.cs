using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Addition Decorator (Decorator Design Pattern)
    class AdditionDecorator : CalculatorDecorator
    {
        public AdditionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var sum = Calculation.Create(a, b, Operations.Addition, calculator);

            return sum;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A, calculator.Calculation_History[^1].B);
        }
    }
}