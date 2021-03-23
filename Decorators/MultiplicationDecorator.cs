using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Multiplication Decorator (Decorator Design Pattern)
    class MultiplicationDecorator : CalculatorDecorator
    {
        public MultiplicationDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation createCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var product = Calculation.Create(a, b, Operations.Multiplication, calculator);

            return product;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[^1].Operation(calculator.Calculation_History[^1].A, calculator.Calculation_History[^1].B);
        }
    }
}