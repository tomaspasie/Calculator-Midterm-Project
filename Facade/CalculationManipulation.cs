using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Iterator;

namespace CalculatorProject.Facade
{
    // The Facade Class (Facade Design Pattern)
    class CalculationManipulation
    {
        public Edit _edit = new Edit();
        public Remove _remove = new Remove();

        public void RemoveCalculation(ICalculatorComponent calculator, int index)
        {
            _remove.Execute(calculator, index);
        }

        public Calculation EditCalculation(String operation, Calculation calculation, ICalculatorComponent calculator, Iterator.Iterator iterator)
        {
            bool end1 = operation.Equals("addition");
            bool end2 = operation.Equals("subtraction");
            bool end3 = operation.Equals("multiplication");
            bool end4 = operation.Equals("division");
            bool end5 = operation.Equals("square root");
            bool end6 = operation.Equals("square");

            while (end1)
            {
                Console.WriteLine("\nEnter first number:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nEnter second number:");
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "+");

                end1 = false;
            }

            while (end2)
            {
                Console.WriteLine("\nEnter first number:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nEnter second number:");
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "-");

                end2 = false;
            }

            while (end3)
            {
                Console.WriteLine("\nEnter first number:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nEnter second number:");
                double b = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "*");

                end3 = false;
            }

            while (end4)
            {
                Console.WriteLine("\nEnter first number:");
                double a = Convert.ToDouble(Console.ReadLine());
                double b = 0;
                bool c = true;

                while (c)
                {
                    Console.WriteLine("\nEnter second number:");
                    b = Convert.ToDouble(Console.ReadLine());

                    while (b == 0)
                    {
                        Console.WriteLine("\nThis number cannot be 0.");
                        Console.WriteLine("Please enter another number:");
                        b = Convert.ToDouble(Console.ReadLine());
                    }

                    c = false;
                }

                calculation = _edit.TwoVariables(calculation, a, b, operation);
                iterator.SetTwoVariableCalculation(calculator, calculation, "/");

                end4 = false;
            }

            while (end5)
            {
                Console.WriteLine("\nEnter number:");
                double a = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.OneVariable(calculation, a, operation);
                iterator.SetOneVariableCalculation(calculator, calculation, "SQUARE ROOT OF");

                end5 = false;
            }

            while (end6)
            {
                Console.WriteLine("\nEnter number:");
                double a = Convert.ToDouble(Console.ReadLine());

                calculation = _edit.OneVariable(calculation, a, operation);
                iterator.SetOneVariableCalculation(calculator, calculation, "SQUARE OF");

                end6 = false;
            }

            return calculation;
        }

    }
}
