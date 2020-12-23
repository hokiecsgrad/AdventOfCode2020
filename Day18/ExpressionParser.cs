using System;
using System.Collections.Generic;

namespace AdventOfCode.Day18
{
    public class ExpressionParser
    {
        public string Expression { get; private set; } = string.Empty;
        public Queue<char> Postfix { get; private set; } = new();

        public ExpressionParser(string expression)
        {
            Expression = expression;
        }

        public void Parse()
        {
            Stack<char> operators = new();
            int expressionPosition = 0;
            // 1 + 2 * 3 + 4 * 5 + 6
            while (expressionPosition < Expression.Length)
            {
                char token = GetNextToken(ref expressionPosition);
                if (char.IsNumber(token))
                {
                    Postfix.Enqueue(token);
                }
                else if (token == '+' || token == '*')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                        Postfix.Enqueue(operators.Pop());
                    operators.Push(token);
                }
                else if (token == '(')
                {
                    operators.Push(token);
                }
                else if (token == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                        Postfix.Enqueue(operators.Pop());
                    operators.Pop();
                }
            }
            while (operators.Count > 0)
                Postfix.Enqueue(operators.Pop());
        }

        public void ParseDifferentPrecedence()
        {
            Stack<char> operators = new();
            int expressionPosition = 0;
            // 1 + 2 * 3 + 4 * 5 + 6
            while (expressionPosition < Expression.Length)
            {
                char token = GetNextToken(ref expressionPosition);
                if (char.IsNumber(token))
                {
                    Postfix.Enqueue(token);
                }
                else if (token == '+')
                {
                    while (operators.Count > 0 && (operators.Peek() != '(' && operators.Peek() != '*'))
                        Postfix.Enqueue(operators.Pop());
                    operators.Push(token);
                }
                else if (token == '*')
                {
                    while (operators.Count > 0 && (operators.Peek() != '(' || operators.Peek() == '+'))
                        Postfix.Enqueue(operators.Pop());
                    operators.Push(token);
                }
                else if (token == '(')
                {
                    operators.Push(token);
                }
                else if (token == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                        Postfix.Enqueue(operators.Pop());
                    operators.Pop();
                }
            }
            while (operators.Count > 0)
                Postfix.Enqueue(operators.Pop());
        }

        private char GetNextToken(ref int position)
        {
            while (position < Expression.Length && Expression[position] == ' ')
                position++;
            return Expression[position++];
        }

        public long Evaluate()
        {
            Stack<long> eval = new();
            while (Postfix.Count > 0)
            {
                char token = Postfix.Dequeue();
                if (char.IsNumber(token))
                {
                    eval.Push((long)char.GetNumericValue(token));
                }
                else if (token == '+')
                {
                    var a = eval.Pop();
                    var b = eval.Pop();
                    eval.Push(a + b);
                }
                else if (token == '*')
                {
                    var a = eval.Pop();
                    var b = eval.Pop();
                    eval.Push(a * b);
                }
            }
            return eval.Pop();
        }
    }
}