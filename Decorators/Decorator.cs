using System;
using CalculatorProject.Commands;

namespace CalculatorProject.Decorators
{
    class Decorator
    {
        public static void Activate(ICalculatorComponent calculator)
        {
            bool repeat = true;

            while (repeat)
            {

                Console.WriteLine(
                    "What operation functionality would you like to give the calculator? (Enter one at a time.)");
                Console.WriteLine("Options: addition, subtraction, multiplication, division, square root, square\n");

                String Done = "";
                string operationInput = Console.ReadLine();

                while ((!operationInput.Equals("addition")) && (!operationInput.Equals("subtraction")) && (!operationInput.Equals("multiplication")) && (!operationInput.Equals("division") && (!operationInput.Equals("square root") && (!operationInput.Equals("square")) && (!operationInput.Equals("DONE")))))
                {
                    Console.WriteLine("\nThat is not available. Please choose another.\n");
                    operationInput = Console.ReadLine();
                }

                while (!Done.Equals("DONE"))
                {
                    Invoker command1 = new Invoker(operationInput);
                    calculator.Commands.Add(command1);
                    Console.WriteLine("\nEnter another operation functionality or type 'DONE' to continue.\n");
                    operationInput = Console.ReadLine();
                    while ((!operationInput.Equals("addition")) && (!operationInput.Equals("subtraction")) && (!operationInput.Equals("multiplication")) && (!operationInput.Equals("division") && (!operationInput.Equals("square root") && (!operationInput.Equals("square")) && (!operationInput.Equals("DONE")))))
                    {
                        Console.WriteLine("\nThat is not available. Please choose another.\n");
                        operationInput = Console.ReadLine();
                    }
                    Done = operationInput;
                    repeat = false;
                }
            }

            Invoker finalCommand = new Invoker("Final Command");
            calculator.Commands.Add(finalCommand);

            // Handle User Input
            foreach (Invoker command in calculator.Commands)
            {
                string op = command.OperationString;

                while (op != "Final Command")
                {
                    command.Addition.Execute(command, calculator);
                    command.Subtraction.Execute(command, calculator);
                    command.Multiplication.Execute(command, calculator);
                    command.Division.Execute(command, calculator);
                    command.SquareRoot.Execute(command, calculator);
                    command.Square.Execute(command, calculator);
                    op = "Final Command";
                }
            }
        }
    }
}
