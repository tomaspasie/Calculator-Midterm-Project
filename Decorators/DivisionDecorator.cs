using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    class DivisionDecorator : CalculatorDecorator
    {
        // Concrete Division Decorator (Decorator Design Pattern)
        public DivisionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var quotient = Calculation.Create(a, b, Operations.Division, calculator);

            return quotient;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A, calculator.Calculation_History[^1].B);
        }
    }
}