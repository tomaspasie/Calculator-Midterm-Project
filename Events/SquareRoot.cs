using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class SquareRoot : Event
    {
        // Event Handler
        public static void Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent squareroot = new SquareRootDecorator(calculator);
            calculator.operations["square root"] = squareroot;
        }
    }
}
