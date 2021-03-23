using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Facade;
using CalculatorProject.Iterator;

namespace CalculatorProject.History
{
    // Facade Class
    class CalculationHistory
    {
        public static void Activate(ICalculatorComponent calculator, String userInput)
        {

            Collection collection = new Collection();

            foreach (Calculation _calculation in calculator.Calculation_History)
            {
                collection.CalculationHistory.Add(_calculation);
            }

            Iterator.Iterator iterator = collection.CreateIterator();
            
            
            // | 1 | View Calculation History (Format: Entire List)
            while (userInput.Equals("1"))
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("| SHOWING ENTIRE CALCULATION HISTORY |");
                Console.WriteLine("--------------------------------------");
                iterator.ShowAll(calculator);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("|  Press ENTER To Return To Options  |");
                Console.WriteLine("--------------------------------------");
                String enter = Console.ReadLine();
                userInput = "pass";
            }

            // | 2 | View Calculation History (Format: One By One)
            while (userInput.Equals("2"))
            {
                String enter = "";

                Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|                                   SHOWING CALCULATIONS ONE BY ONE                                  |");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                iterator.First(calculator);

                while (enter != "EXIT")
                {
                    Console.WriteLine("\n------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("| Choose An Option: NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE  | Or Type EXIT To Return To Options |");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------\n");
                    enter = Console.ReadLine();

                    while (enter.Equals("NEXT"))
                    {
                        iterator.Next(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("PREVIOUS"))
                    {
                        iterator.Previous(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("FIRST"))
                    {
                        iterator.First(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("LAST"))
                    {
                        iterator.Last(calculator);
                        enter = "pass";
                    }

                    while (enter.Equals("CHANGE"))
                    {
                        Console.WriteLine("\n-------------------------------------------------------------");
                        Console.WriteLine("|                     EDIT CALCULATION                      |");
                        Console.WriteLine("-------------------------------------------------------------\n");
                        Console.WriteLine("What Operation Do You Want To Change This Calculation To?");
                        Receiver.displayOperations(calculator, "");
                        String operation = Console.ReadLine();

                        CalculationManipulation manipulator = new CalculationManipulation();
                        Calculation oldCalculation = iterator.CurrentCalculation(calculator);
                        manipulator.EditCalculation(operation, oldCalculation, calculator, iterator);

                        iterator.Current(calculator);
                        Console.WriteLine("");

                        Console.WriteLine("------------------------------------------------------------------------");
                        Console.WriteLine("|  CALCULATION SUCCESSFULLY CHANGED | Press ENTER To Return To Options |");
                        Console.WriteLine("------------------------------------------------------------------------");
                        String temp = Console.ReadLine();
                        enter = "EXIT";
                    }

                    while (enter.Equals("REMOVE"))
                    {
                        CalculationManipulation manipulator = new CalculationManipulation();
                        manipulator.RemoveCalculation(calculator, iterator.GetIndex());
                        enter = "pass";
                        Console.WriteLine("\n-----------------------------------------------------------");
                        Console.WriteLine("|  CALCULATION REMOVED | Press ENTER To Return To Options |");
                        Console.WriteLine("-----------------------------------------------------------");
                        String temp = Console.ReadLine();
                        enter = "EXIT";
                    }

                    while ((!enter.Equals("NEXT")) && (!enter.Equals("PREVIOUS")) && (!enter.Equals("FIRST")) && (!enter.Equals("LAST") && (!enter.Equals("CHANGE") && (!enter.Equals("REMOVE")) && (!enter.Equals("pass")) && (!enter.Equals("EXIT")))))
                    {
                        Console.WriteLine("\nThat is not available. Press ENTER To Return.");
                        String temp = Console.ReadLine();
                        enter = "pass";
                    }
                }

                userInput = "pass";
            }

            // | 5 | Check State Of All Calculations
            while (userInput.Equals("5"))
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("| CURRENT STATE OF ALL CALCULATIONS |");
                Console.WriteLine("--------------------------------------");
                iterator.ShowState(calculator);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("|  Press ENTER To Return To Options  |");
                Console.WriteLine("--------------------------------------");
                String enter = Console.ReadLine();
                userInput = "pass";
            }
        }
    }
}
