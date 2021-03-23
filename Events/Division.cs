using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Division : Event
    {
        // Event Handler
        public static void Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent division = new DivisionDecorator(calculator);
            calculator.operations["division"] = division;
        }
    }
}
