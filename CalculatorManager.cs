using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CalculatorProject.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class CalculatorManager
    {
        private readonly ILogger _logger;

        // Calculator Manager
        public CalculatorManager(ILogger<CalculatorManager> logger)
        {

            _logger = logger;

            Calculator calculator = new Calculator();
            calculator.AddAddition += Addition.Handler;
            calculator.AddSubtraction += Subtraction.Handler;
            calculator.AddMultiplication += Multiplication.Handler;
            calculator.AddDivision += Division.Handler;
            calculator.AddSquareRoot += SquareRoot.Handler;
            calculator.AddSquare += Square.Handler;
            ConsoleManager.Activate(calculator, logger);
        }

    }
}
