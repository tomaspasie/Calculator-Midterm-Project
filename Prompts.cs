using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject
{
    class Prompts
    {
        public static void Write(String x)
        {
            Console.WriteLine(x);
        }

        public static void Intro()
        {
            Write("------------------------");
            Write("| Calculator Activated |");
            Write("------------------------\n");
        }

        public static void Functionality()
        {
            Write("What operation functionality would you like to give the calculator? (Enter one at a time.)");
            Write("Options: addition, subtraction, multiplication, division, square root, square\n");
        }

        public static void _Functionality()
        {
            Write("\nEnter another operation functionality or type 'DONE' to continue.\n");
        }

        public static void Addition()
        {
            Write("\n\n- - - - - - - - - - -");
            Write("YOU CHOSE: Addition");
            Write("- - - - - - - - - - -\n");
        }

        public static void Subtraction()
        {
            Write("\n\n- - - - - - - - - - - -");
            Write("YOU CHOSE: Subtraction");
            Write("- - - - - - - - - - - -\n");
        }

        public static void Multiplication()
        {
            Write("\n\n- - - - - - - - - - - - - -");
            Write("YOU CHOSE: Multiplication");
            Write("- - - - - - - - - - - - - -\n");
        }

        public static void Division()
        {
            Write("\n\n- - - - - - - - - - -");
            Write("YOU CHOSE: Division");
            Write("- - - - - - - - - - -\n");
        }

        public static void SquareRoot()
        {
            Write("\n\n- - - - - - - - - - - -");
            Write("YOU CHOSE: Square Root");
            Write("- - - - - - - - - - - -\n");
        }

        public static void Square()
        {
            Write("\n\n- - - - - - - - - -");
            Write("YOU CHOSE: Square");
            Write("- - - - - - - - - -\n");
        }

        public static void Number()
        {
            Write("Enter number:");
        }

        public static void FirstNumber()
        {
            Write("Enter first number:");
        }

        public static void SecondNumber()
        {
            Write("\nEnter second number:");
        }

        public static void _Number()
        {
            Write("\nEnter number:");
        }

        public static void _FirstNumber()
        {
            Write("\nEnter first number:");
        }

        public static void _SecondNumber()
        {
            Write("\nEnter second number:");
        }

        public static void Zero()
        {
            Write("\nThis number cannot be 0.");
            Write("Please enter another number:");
        }

        public static void Divider()
        {
            Write("\n-----------------------------------------");
        }

        public static void Result(double result)
        {
            Write("\n---------------------------------");
            Write("ANSWER: " + Convert.ToString(result));
            Write("---------------------------------");
        }

        public static void Logger()
        {
            Write("\n---------------LOGGER---------------");
            Write("NOTE: Calculation will be skipped.");
        }

        public static void ChooseOperation()
        {
            Write("\n-----------------------------------------------------");
            Write("| Choose the operation you would like to calculate. |");
            Write("-----------------------------------------------------");
        }

        public static void Another()
        {
            Write("\n------------------------------------");
            Write("| Do another calculation? (YES/NO) |");
            Write("------------------------------------");
        }

        public static void Options()
        {
            Write("\n----------------------------------------------------------------------------------------------------------");
            Write("|                            OPTIONS: Choose an option by entering its number                            |");
            Write("----------------------------------------------------------------------------------------------------------");
            Write("| 1 | View Calculation History (Entire List)");
            Write("| 2 | View/Modify Calculation History [NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE]");
            Write("| 3 | Create New Calculations");
            Write("| 4 | Display What The Calculator Is Capable Of Doing (In Its Current State)");
            Write("| 5 | Check State Of All Calculations");
            Write("| 6 | Exit Program");
            Write("----------------------------------------------------------------------------------------------------------\n");
        }

        public static void ShowHistory()
        {
            Write("\n--------------------------------------");
            Write("| SHOWING ENTIRE CALCULATION HISTORY |");
            Write("--------------------------------------");
        }

        public static void ShowEdit()
        {
            Write("\n-------------------------------------------------------------");
            Write("|                     EDIT CALCULATION                      |");
            Write("-------------------------------------------------------------\n");
            Write("What Operation Do You Want To Change This Calculation To?");
        }

        public static void Changed()
        {
            Write("------------------------------------------------------------------------");
            Write("|  CALCULATION SUCCESSFULLY CHANGED | Press ENTER To Return To Options |");
            Write("------------------------------------------------------------------------");
        }

        public static void Removed()
        {
            Write("\n-----------------------------------------------------------");
            Write("|  CALCULATION REMOVED | Press ENTER To Return To Options |");
            Write("-----------------------------------------------------------");
        }

        public static void IteratorTitle()
        {
            Write("\n------------------------------------------------------------------------------------------------------");
            Write("|                                   SHOWING CALCULATIONS ONE BY ONE                                  |");
            Write("------------------------------------------------------------------------------------------------------");
        }

        public static void IteratorOptions()
        {
            Write("\n------------------------------------------------------------------------------------------------------");
            Write("| Choose An Option: NEXT, PREVIOUS, FIRST, LAST, CHANGE, REMOVE  | Or Type EXIT To Return To Options |");
            Write("------------------------------------------------------------------------------------------------------\n");
        }

        public static void StateTitle()
        {
            Write("\n--------------------------------------");
            Write("| CURRENT STATE OF ALL CALCULATIONS |");
            Write("--------------------------------------");
        }

        public static void StateOptions()
        {
            Write("--------------------------------------");
            Write("|  Press ENTER To Return To Options  |");
            Write("--------------------------------------");
        }

        public static void Capability()
        {
            Write("\n------------------------------------------");
            Write("| THE CALCULATOR IS CURRENTLY CAPABLE OF |");
            Write("------------------------------------------\n");
        }

        public static void Back()
        {
            Write("--------------------------------------");
            Write("|  Press ENTER To Return To Options  |");
            Write("--------------------------------------");
        }

        public static void Unavailable()
        {
            Write("\nThat is not available. Press ENTER To Return To Options.\n");
        }

        public static void Enter()
        {
            Write("\nThat is not available. Press ENTER To Return.");
        }

        public static void NotAvailable()
        {
            Write("\nThat is not available. Please choose another.\n");
        }

        public static void Outro()
        {
            Write("\n------------");
            Write("| Goodbye! |");
            Write("------------");
        }

    }
}
