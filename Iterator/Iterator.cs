using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CalculatorProject.State;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Newtonsoft.Json.Linq;

namespace CalculatorProject.Iterator
{
    // Concrete Iterator Class (Iterator Design Pattern)
    class Iterator : ICalculationIterator
    {
        public Collection calculationHistory;
        public int index = 0;
        public int next = 1;
        public int previous = -1;

        // Iterator Constructor (Iterator Design Pattern)
        public Iterator(Collection history)
        {
            this.calculationHistory = history;
        }

        public void Next(ICalculatorComponent calculator)
        {
            index += next;
            bool end = EndOfCollection();

            while (!end)
            {
                ShowSingle(index, calculator);
                end = true;
            }

            end = EndOfCollection();
            while (end)
            {
                index = calculationHistory.Count - 1;
                Console.WriteLine("\nYou are at the end of the calculation history.");
                Last(calculator);
                end = false;
            }
        }

        public void Previous(ICalculatorComponent calculator)
        {
            index += previous;
            bool end = EndOfCollection();
            int temp = index;

            while (temp >= 0)
            {
                while (!end)
                {
                    ShowSingle(index, calculator);
                    end = true;
                }

                temp = -1;
            }

            temp = index;
            while (temp < 0)
            {
                index = 0;
                temp = index;
                Console.WriteLine("\nYou are at the beginning of the calculation history.");
                First(calculator);
            }
        }

        public void First(ICalculatorComponent calculator)
        {
            index = 0;
            ShowSingle(index, calculator);
        }

        public void Last(ICalculatorComponent calculator)
        {
            index = calculationHistory.Count - 1;
            ShowSingle(index, calculator);
        }

        public void Current(ICalculatorComponent calculator)
        {
            ShowSingle(index, calculator);
        }

        public Calculation CurrentCalculation(ICalculatorComponent calculator)
        {
            return calculator.Calculation_History[index];
        }

        public void SetTwoVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign)
        {
            calculator.Calculation_History[index] = Calculation.Create(updated.A, updated.B, updated.Operation, calculator);
            calculator.UserOperations[index] = newSign;
            calculator.CalculatorState[index] = new Context(new Modified());
        }

        public void SetOneVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign)
        {
            calculator.Calculation_History[index] = Calculation.Create(updated.A, 0, updated.Operation, calculator);
            calculator.UserOperations[index] = newSign;
            calculator.CalculatorState[index] = new Context(new Modified());
        }

        public int GetIndex()
        {
            return index;
        }

        public bool EndOfCollection()
        {
            return index >= calculationHistory.Count;
        }

        public void ShowSingle(int i, ICalculatorComponent calculator)
        {
            int num = i;
            int location = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;

                while (i == location)
                {

                    num += 1;

                    while (sign.Equals("+"))
                    {
                        Console.WriteLine("\n>>> Calculation #" + num.ToString() + " | " +
                                          calculator.Calculation_History[i].A + " " + sign + " " +
                                          calculator.Calculation_History[i].B + " = " +
                                          calculator.Calculation_History[i].Operation(
                                              calculator.Calculation_History[i].A,
                                              calculator.Calculation_History[i].B));
                        sign = "";
                    }

                    while (sign.Equals("-"))
                    {
                        Console.WriteLine("\n>>> Calculation #" + num.ToString() + " | " +
                                          calculator.Calculation_History[i].A + " " + sign + " " +
                                          calculator.Calculation_History[i].B + " = " +
                                          calculator.Calculation_History[i].Operation(
                                              calculator.Calculation_History[i].A,
                                              calculator.Calculation_History[i].B));
                        sign = "";
                    }

                    while (sign.Equals("*"))
                    {
                        Console.WriteLine("\n>>> Calculation #" + num.ToString() + " | " +
                                          calculator.Calculation_History[i].A + " " + sign + " " +
                                          calculator.Calculation_History[i].B + " = " +
                                          calculator.Calculation_History[i].Operation(
                                              calculator.Calculation_History[i].A,
                                              calculator.Calculation_History[i].B));
                        sign = "";
                    }

                    while (sign.Equals("/"))
                    {
                        Console.WriteLine("\n>>>Calculation #" + num.ToString() + " | " +
                                          calculator.Calculation_History[i].A + " " + sign + " " +
                                          calculator.Calculation_History[i].B + " = " +
                                          calculator.Calculation_History[i].Operation(
                                              calculator.Calculation_History[i].A,
                                              calculator.Calculation_History[i].B));
                        sign = "";
                    }

                    while (sign.Equals("SQUARE ROOT OF"))
                    {
                        Console.WriteLine("\n>>>Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.Calculation_History[i].A + " = " +
                                          calculator.Calculation_History[i].Operation(calculator.Calculation_History[i].A, 0));
                        sign = "";
                    }

                    while (sign.Equals("SQUARE OF"))
                    {
                        Console.WriteLine("\n>>>Calculation #" + num.ToString() + " | " + sign + " " +
                                          calculator.Calculation_History[i].A + " = " +
                                          calculator.Calculation_History[i].Operation(calculator.Calculation_History[i].A, 0));
                        sign = "";
                    }

                    location += 1;
                }

                location += 1;
            }
        }

        public void ShowAll(ICalculatorComponent calculator)
        {
            int num = 1;
            int i = 0;
            int j = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;
                bool again = true;

                while (again)
                {
                    try
                    {
                        while (sign.Equals("+"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("-"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("*"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("/"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE ROOT OF"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " + sign + " " +
                                              calculator.Calculation_History[i].A + " = " +
                                              calculator.Calculation_History[i]
                                                  .Operation(calculator.Calculation_History[i].A, 0));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE OF"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " + sign + " " +
                                              calculator.Calculation_History[i].A + " = " +
                                              calculator.Calculation_History[i]
                                                  .Operation(calculator.Calculation_History[i].A, 0));
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }

                    j += 1;
                    while (j > 25)
                    {
                        again = false;
                        j = 0;
                    }
                }

            }
        }

        public void ShowState(ICalculatorComponent calculator)
        {
            int num = 1;
            int i = 0;
            int j = 0;
            foreach (String s in calculator.UserOperations)
            {
                String sign = s;
                bool again = true;

                while (again)
                {
                    try
                    {
                        while (sign.Equals("+"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("-"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("*"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("/"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " +
                                              calculator.Calculation_History[i].A + " " + sign + " " +
                                              calculator.Calculation_History[i].B + " = " + calculator
                                                  .Calculation_History[i].Operation(
                                                      calculator.Calculation_History[i].A,
                                                      calculator.Calculation_History[i].B) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE ROOT OF"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " + sign + " " +
                                              calculator.Calculation_History[i].A + " = " +
                                              calculator.Calculation_History[i]
                                                  .Operation(calculator.Calculation_History[i].A, 0) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }

                        while (sign.Equals("SQUARE OF"))
                        {
                            Console.WriteLine("Calculation #" + num.ToString() + " | " + sign + " " +
                                              calculator.Calculation_History[i].A + " = " +
                                              calculator.Calculation_History[i]
                                                  .Operation(calculator.Calculation_History[i].A, 0) + "\t| State: " + calculator.CalculatorState[i].State.GetType().Name);
                            num += 1;
                            i += 1;
                            again = false;
                            sign = "";
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }

                    j += 1;
                    while (j > 25)
                    {
                        again = false;
                        j = 0;
                    }
                }

            }
        }

    }
}
