using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Concrete Command Class (Command Design Pattern)
    class DivisionCommand : Command
    {
        string Division = "division";
        string choice = "division_USER_CHOICE";
        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Division);
        }
        public override bool UserChoiceCheck(Invoker command)
        {
            return command.OperationString.Equals(choice);
        }

        public override void Execute(Invoker command, ICalculatorComponent calculator)
        {
            bool check = UserInputCheck(command);
            while (check)
            {
                calculator.OnAdd_Division(calculator);
                calculator.tempOperations.Add("Division", new DivisionDecorator(calculator));
                check = false;
            }
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Console.WriteLine("\n\n- - - - - - - - - - -");
                Console.WriteLine("YOU CHOSE: Division");
                Console.WriteLine("- - - - - - - - - - -\n");

                double a, b;
                int c, d;
                double result, test;
                bool skip = false;

                Console.WriteLine("Enter first number:");
                a = Convert.ToDouble(Console.ReadLine());
                c = (int)a;

                Console.WriteLine("\nEnter second number:");
                b = Convert.ToDouble(Console.ReadLine());
                d = (int)b;

                // Handles Divide By Zero Condition + Log Entry
                try
                {
                    test = c / d;
                }
                catch (DivideByZeroException e)
                {
                    skip = true;
                    Console.WriteLine("\n---------------LOGGER---------------");
                    logger.LogInformation(e.Message);
                    Console.WriteLine("Calculation will be skipped.");
                    
                }

                while ((skip.Equals(false)) && (b != 0))
                {
                    calculator.operations["division"].createCalculation(calculator, a, b);
                    result = calculator.operations["division"].GetResult(calculator);

                    Console.WriteLine("\n---------------------------------");
                    Console.WriteLine("ANSWER: " + Convert.ToString(result));
                    Console.WriteLine("---------------------------------");

                    calculator.UserOperations.Add("/");
                    calculator.CalculatorState.Add(new Context(new Unmodified()));
                    check = false;
                    skip = true;
                }

                check = false;
                skip = false;
            }
        }

    }
}
