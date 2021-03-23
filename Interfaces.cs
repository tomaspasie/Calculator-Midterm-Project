using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Iterator;
using CalculatorProject.State;

namespace CalculatorProject
{
    // Component Interface - Decorator Pattern
    interface ICalculatorComponent
    {
        Calculation createCalculation(ICalculatorComponent calculator, double a, double b);
        Calculation createCalculation(ICalculatorComponent calculator, double a);
        List<Calculation> Calculation_History { get; set; }
        List<Invoker> Commands { get; set; }
        List<Invoker> Commands2 { get; set; }
        List<String> UserOperations { get; set; }
        List<Context> CalculatorState { get; set; }
        double GetResult(ICalculatorComponent calculator);
        Dictionary<string, ICalculatorComponent> operations { get; set; }
        Dictionary<string, ICalculatorComponent> tempOperations { get; set; }
        void OnAdd_Addition(ICalculatorComponent calculator);
        void OnAdd_Subtraction(ICalculatorComponent calculator);
        void OnAdd_Multiplication(ICalculatorComponent calculator);
        void OnAdd_Division(ICalculatorComponent calculator);
        void OnAdd_SquareRoot(ICalculatorComponent calculator);
        void OnAdd_Square(ICalculatorComponent calculator);
    }


}
