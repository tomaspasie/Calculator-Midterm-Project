using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Concrete Command Class (Command Design Pattern)
    class MultiplicationCommand : Command
    {
        string Multiplication = "multiplication";
        string choice = "multiplication_USER_CHOICE";
        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Multiplication);
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
                calculator.OnAdd_Multiplication(calculator);
                calculator.tempOperations.Add("Multiplication", new MultiplicationDecorator(calculator));
                check = false;
            }
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Console.WriteLine("\n\n- - - - - - - - - - -");
                Console.WriteLine("YOU CHOSE: Multiplication");
                Console.WriteLine("- - - - - - - - - - -\n");

                double a, b;
                double result;

                Console.WriteLine("Enter first number:");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nEnter second number:");
                b = Convert.ToDouble(Console.ReadLine());

                calculator.operations["multiplication"].createCalculation(calculator, a, b);
                result = calculator.operations["multiplication"].GetResult(calculator);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("ANSWER: " + Convert.ToString(result));
                Console.WriteLine("---------------------------------");

                calculator.UserOperations.Add("*");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }

    }
}
