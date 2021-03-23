using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.History;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class Options
    {
        public static void Activate(ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            string choice = "";
            while (!choice.Equals("6"))
            {
                Console.WriteLine("\n----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("OPTIONS: Choose an option by entering its number");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| 1 | View Calculation History (Entire List)");
                Console.WriteLine("| 2 | View/Modify Calculation History [NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE]");
                Console.WriteLine("| 3 | Create New Calculations");
                Console.WriteLine("| 4 | Display What The Calculator Is Capable Of Doing (In Its Current State)");
                Console.WriteLine("| 5 | Check State Of All Calculations");
                Console.WriteLine("| 6 | Exit Program");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");

                choice = Console.ReadLine();

                CalculationHistory.Activate(calculator, choice);


                // | 3 | Create New Calculations
                while (choice.Equals("3"))
                {
                    Console.WriteLine("\n");
                    Receiver.Activate(calculator, logger);
                    choice = "pass";
                }

                // | 4 | Display What The Calculator Is Capable Of Doing (In Its Current State)
                while (choice.Equals("4"))
                {
                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine("| THE CALCULATOR IS CURRENTLY CAPABLE OF |");
                    Console.WriteLine("------------------------------------------\n");
                    Receiver.displayOperations(calculator,"");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("|  Press ENTER To Return To Options  |");
                    Console.WriteLine("--------------------------------------");
                    String enter = Console.ReadLine();
                    choice = "pass";
                }

                while ((!choice.Equals("1")) && (!choice.Equals("2")) && (!choice.Equals("3")) && (!choice.Equals("4") && (!choice.Equals("5")) && (!choice.Equals("6")) && (!choice.Equals("pass"))))
                {
                    Console.WriteLine("\nThat is not available. Press ENTER To Return To Options.\n");
                    String enter = Console.ReadLine();
                    choice = "pass";
                }

            }
        }
    }
}
