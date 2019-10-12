using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = "2^3";
            var numbers = new Stack<double>();
            var result = Evaluate(expression);
            Console.WriteLine(result);
        }

        private static object Evaluate(string expression)
        {
            var numbers = new Stack<double>();
            var operators = new Stack<char>();
            var allowedOperators = "+-/*";
            for (int i = 0; i < expression.Length; i++)
            {
                var @char = expression[i];
                if(@char=='(')
                {
                    operators.Push(@char);
                }
                else if(@char==')')
                {
                    while (operators.Peek()!='(')
                    {
                        var op = operators.Pop();
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Pop(); //(
                }
                else if(allowedOperators.Contains(@char))
                {
                    while (operators.Count>0&&Priority(operators.Peek())>Priority(@char))
                    {
                        var op = operators.Pop();
                        var param2 = numbers.Pop();
                        var param1 = numbers.Pop();
                        var newValue = ApplyOperation(op, param1, param2);
                        numbers.Push(newValue);
                    }
                    operators.Push(@char);
                }
                else if(char.IsDigit(@char)||@char=='.')
                {
                    var number = new StringBuilder();
                    while (char.IsDigit(@char)||@char=='.')
                    {
                        number.Append(@char);
                        i++;
                        if(i==expression.Length)
                        {
                            break;
                        }
                        @char = expression[i];
                    }
                    i--;
                    numbers.Push(double.Parse(number.ToString()));
                }
            }

            while (operators.Count>0)
            {
                var op = operators.Pop();
                var param2 = numbers.Pop();
                var param1 = numbers.Pop();
                var newValue = ApplyOperation(op, param1, param2);
                numbers.Push(newValue);
            }

            return numbers.Pop();
        }

        static double ApplyOperation(char operation,double operand1,double operand2)
        {
            switch (operation)
            {
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '^': return Math.Pow(operand1, operand2);
                case '/':
                    if(operand2==0)
                    {
                        throw new Exception("Divison by zero!");
                    }
                    return operand1 / operand2;
                default:
                    return 0.0;
            }
        }
       static  int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default:
                    return 0;
            }
        }
    }
}
