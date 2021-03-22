using System;
using System.Collections.Generic;
using System.Text;

namespace MatheKönig.Core.ViewModels
{
    public class Calculator 
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        private Func<int, int, int> Function { get; set; }

        private static Func<int, int, int> GetFunction(string identifier)
        {
            switch (identifier)
            {
                case "+":
                    return (a, b) => a + b;

                case "-":
                    return (a, b) => a - b;

                case "*":
                    return (a, b) => a * b;

                case "/":
                    return (a, b) => a / b;

                case "mod":
                    return (a, b) => a % b;

                default:
                    throw new ArgumentException("Invalid Operation");
            }
        }

        private void ExecuteFunction()
        {
            this.FirstNumber = this.Function(this.FirstNumber, this.SecondNumber);
            this.SecondNumber = 0;
        }

        public void SetOperation(string operation)
        {
            if (operation == "=")
            {
                this.ExecuteFunction();
                this.Function = null;
                return;
            }
            else if (this.Function != null)
            {
                this.ExecuteFunction();
            }

            this.Function = GetFunction(operation);
        }

        public void ExpandNumber(char number)
        {
            var newNumber = number - '0';
            if (this.Function != null)
            {
                this.SecondNumber = this.SecondNumber * 10 + newNumber;
            }
            else
            {
                this.FirstNumber = this.FirstNumber * 10 + newNumber;
            }
        }
    }
}

