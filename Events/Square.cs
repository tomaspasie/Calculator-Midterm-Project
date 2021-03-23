using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Square : Event
    {
        // Event Handler
        public static void Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent square = new SquareDecorator(calculator);
            calculator.operations["square"] = square;
        }

    }
}
