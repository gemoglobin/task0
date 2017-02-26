using System;
using System.Collections.Generic;

namespace task0.Sources
{
    public static class Calculator
    {        
        /// <summary>
        /// Вычисление мат. действий
        /// </summary>
        /// <param name="actions">Список мат. действий</param>
        public static void Calculate(List<MathAction> actions)
        {
            foreach (var act in actions)
            {
                try
                {
                    switch (act.operation._view)
                    {
                        case "+":
                            act.result = checked(act.leftOperand + act.rightOperand);
                            break;
                        case "-":
                            act.result = act.leftOperand - act.rightOperand;
                            break;
                        case "*":
                            act.result = checked(act.leftOperand * act.rightOperand);
                            break;
                        case "/":
                            if (act.rightOperand == 0)
                            {
                                act.message = "деление на 0";
                                act.result = int.MaxValue;
                            }
                            else
                                act.result = act.leftOperand / act.rightOperand;
                            break;
                        case "^":
                            act.result = checked((int)Math.Pow(act.leftOperand, act.rightOperand));
                            break;
                        case "#":
                            act.result = gcd(act.leftOperand, act.rightOperand);
                            break;
                    }
                }
                catch (System.OverflowException e)
                {
                    act.message = "арифмитическое переполнение";
                }
            }
        }

        /// <summary>
        /// Метод нахождения НОД 2-ух чисел
        /// </summary>
        /// <param name="a">1-ое число</param>
        /// <param name="b">2-ое число</param>
        /// <returns>НОД</returns>
        private static int gcd(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            return gcd(b, a % b);
        }


    }
}
