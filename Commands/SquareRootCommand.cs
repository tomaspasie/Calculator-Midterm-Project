using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Concrete Command Class (Command Design Pattern)
    class SquareRootCommand : Command
    {
        string SquareRoot = "square root";
        string choice = "square root_USER_CHOICE";
        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(SquareRoot);
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
                calculator.OnAdd_SquareRoot(calculator);
                calculator.tempOperations.Add("Square Root", new SquareRootDecorator(calculator));
                check = false;
            }
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Console.WriteLine("\n\n- - - - - - - - - - -");
                Console.WriteLine("YOU CHOSE: Square Root");
                Console.WriteLine("- - - - - - - - - - -\n");

                double a;
                double result;

                Console.WriteLine("Enter number:");
                a = Convert.ToDouble(Console.ReadLine());

                calculator.operations["square root"].createCalculation(calculator, a);
                result = calculator.operations["square root"].GetResult(calculator);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("ANSWER: " + Convert.ToString(result));
                Console.WriteLine("---------------------------------");

                calculator.UserOperations.Add("SQUARE ROOT OF");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }

    }
}
