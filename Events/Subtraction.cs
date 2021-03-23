using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Subtraction : Event
    {
        // Event Handler
        public static void Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent subtraction = new SubtractionDecorator(calculator);
            calculator.operations["subtraction"] = subtraction;
        }
    }
}
